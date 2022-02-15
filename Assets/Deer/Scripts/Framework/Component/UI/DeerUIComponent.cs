// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-07-11 23-29-11  
//修改作者 : 杜鑫 
//修改时间 : 2021-07-11 23-29-11  
//版 本 : 0.1 
// ===============================================
using GameFramework;
using GameFramework.ObjectPool;
using GameFramework.Resource;
using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Deer
{
    [DisallowMultipleComponent]
    [AddComponentMenu("Deer/DeerUI")]
    public class DeerUIComponent : GameFrameworkComponent
    {
        private IObjectPool<AssetInstanceObject> m_InstancePool; //UI资源池   
        private LoadAssetCallbacks m_LoadAssetCallbacks; //UI加载回调                    
        private Dictionary<int, OpenUIInfo> m_UIFormsBeingLoaded; //正在加载的UI列表      
        private HashSet<int> m_UIFormsToReleaseOnLoad; //加载完毕要卸载的UI   
        private string m_luaModuleHelperName = "UIManagerHelper";

        protected override void Awake()
        {
            base.Awake();
            m_LoadAssetCallbacks = new LoadAssetCallbacks(LoadUIFormSuccessCallback, LoadUIFormFailureCallback, LoadUIFormUpdateCallback, LoadUIFormDependencyAssetCallback);
            m_UIFormsBeingLoaded = new Dictionary<int, OpenUIInfo>();
            m_UIFormsToReleaseOnLoad = new HashSet<int>();
        }

        private void Start()
        {
            m_InstancePool = GameEntry.ObjectPool.CreateMultiSpawnObjectPool<AssetInstanceObject>("UI Asset Pool", 10, 16, 2, 0);
        }

        protected void OnDestroy()
        {
        }

        protected void OnApplicationQuit()
        {

        }

        public void LoadAssetAsync(int nLoadSerial, string strUIPath, string strShowName)
        {
            AssetInstanceObject uiFormAsset = m_InstancePool.Spawn(strUIPath);
            if (uiFormAsset == null)
            {
                OpenUIInfo openUIInfo = OpenUIInfo.Create(nLoadSerial, strUIPath, strShowName);
                m_UIFormsBeingLoaded.Add(nLoadSerial, openUIInfo);
                GameEntry.Resource.LoadAsset(strUIPath, typeof(GameObject), Constant.AssetPriority.UIFormAsset, m_LoadAssetCallbacks, openUIInfo);
            }
            else
            {
                //ProcessAfterFinishLoadAssetSuccess((GameObject)uiFormAsset.Target, nLoadSerial);
                CallFunction("LoadUIFormSuccessCallback", (GameObject)uiFormAsset.Target, nLoadSerial);
            }
        }

        /// <summary>
        /// 回收资源(不要调用 只用于UIBase destroy的时候)
        /// </summary>
        /// <param name="asset"></param>
        public void Unspwn(object asset)
        {
            if (m_InstancePool == null)
            {
                Log.Error("UIComponent Unspwn m_InstancePool null");
                return;
            }
            m_InstancePool.Unspawn(asset);
        }

        /// <summary>
        /// 是否正在加载界面
        /// </summary>
        /// <param name="uiFormAssetName">界面资源名称</param>
        /// <returns>是否正在加载界面</returns>
        public bool IsLoadingUIForm(string uiname)
        {
            if (string.IsNullOrEmpty(uiname))
            {
                throw new GameFrameworkException("UI name is invalid.");
            }

            foreach (KeyValuePair<int, OpenUIInfo> uiFormBeingLoaded in m_UIFormsBeingLoaded)
            {
                if (uiFormBeingLoaded.Value.ShowUIName.Equals(uiname))
                {
                    return true;
                }
            }
            return false;
        }

        private void LoadUIFormDependencyAssetCallback(string assetName, string dependencyAssetName, int loadedCount, int totalCount, object userData)
        {
            OpenUIInfo openUIInfo = (OpenUIInfo)userData;
            if (openUIInfo == null)
            {
                Log.Error("Open UI info is invalid.");
            }
        }

        private void LoadUIFormUpdateCallback(string assetName, float progress, object userData)
        {
            OpenUIInfo openUIInfo = (OpenUIInfo)userData;
            if (openUIInfo == null)
            {
                Log.Error("Open UI info is invalid.");
            }
        }

        private void LoadUIFormFailureCallback(string assetName, LoadResourceStatus status, string errorMessage, object userData)
        {
            OpenUIInfo openUIInfo = (OpenUIInfo)userData;
            if (openUIInfo == null)
            {
                throw new GameFrameworkException("Open UI info is invalid.");
            }

            if (m_UIFormsToReleaseOnLoad.Contains(openUIInfo.SerialId))
            {
                m_UIFormsToReleaseOnLoad.Remove(openUIInfo.SerialId);
                ReferencePool.Release(openUIInfo);
                return;
            }

            m_UIFormsBeingLoaded.Remove(openUIInfo.SerialId);

            string appendErrorMessage = Utility.Text.Format("Load UI failure, asset name '{0}', status '{1}' , error message '{2}'.", assetName, status.ToString(), errorMessage);

            //ProcessAfterFinishLoadAssetFailed(openUIFormInfo.SerialId);
            CallFunction("LoadUIFormFailureCallback", openUIInfo.SerialId);

            ReferencePool.Release(openUIInfo);
            Log.Error(appendErrorMessage);
        }

        private void LoadUIFormSuccessCallback(string assetName, object asset, float duration, object userData)
        {
            OpenUIInfo openUIInfo = (OpenUIInfo)userData;
            if (openUIInfo == null)
            {
                throw new Exception("Open UI info is invalid.");
            }
            m_UIFormsBeingLoaded.Remove(openUIInfo.SerialId);
            if (m_UIFormsToReleaseOnLoad.Contains(openUIInfo.SerialId))
            {
                m_UIFormsToReleaseOnLoad.Remove(openUIInfo.SerialId);
                GameEntry.Resource.UnloadAsset(asset);
                return;
            }
            AssetInstanceObject assetObject = m_InstancePool.Spawn(assetName);
            if (assetObject == null)
            {
                assetObject = AssetInstanceObject.Create(assetName, asset);
                m_InstancePool.Register(assetObject, true);
            }
            else 
            {
                GameEntry.Resource.UnloadAsset(asset);
            }
            CallFunction("LoadUIFormSuccessCallback", (GameObject)assetObject.Target, openUIInfo.SerialId);
            ReferencePool.Release(openUIInfo);
        }
        private void CallFunction(string func, int serialId)
        {
            GameEntry.Lua.CallFunction(m_luaModuleHelperName + "." + func, serialId);
        }
        private void CallFunction(string func,GameObject gameObject,int serialId) 
        {
            GameEntry.Lua.CallFunction(m_luaModuleHelperName + "." + func, gameObject, serialId);
        }
    }

   

}