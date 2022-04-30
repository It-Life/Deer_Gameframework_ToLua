﻿// ================================================
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
        private Dictionary<int, string> m_UIFormsBeingLoaded; //正在加载的UI列表      
        private HashSet<int> m_UIFormsToReleaseOnLoad; //加载完毕要卸载的UI   
        private string m_luaModuleHelperName = "UIManagerHelper";
        [SerializeField]
        private float m_InstanceAutoReleaseInterval = 5f;

        [SerializeField]
        private int m_InstanceCapacity = 16;

        [SerializeField]
        private float m_InstanceExpireTime = 60f;

        [SerializeField]
        private int m_InstancePriority = 0;
        /// <summary>
        /// 获取或设置界面实例对象池自动释放可释放对象的间隔秒数。
        /// </summary>
        public float InstanceAutoReleaseInterval
        {
            get
            {
                return m_InstancePool.AutoReleaseInterval;
            }
            set
            {
                m_InstancePool.AutoReleaseInterval = value;
            }
        }
        /// <summary>
        /// 获取或设置界面实例对象池的容量。
        /// </summary>
        public int InstanceCapacity
        {
            get
            {
                return m_InstancePool.Capacity;
            }
            set
            {
                m_InstancePool.Capacity = value;
            }
        }
        /// <summary>
        /// 获取或设置界面实例对象池对象过期秒数。
        /// </summary>
        public float InstanceExpireTime
        {
            get
            {
                return m_InstancePool.ExpireTime;
            }
            set
            {
                m_InstancePool.ExpireTime = value;
            }
        }
        /// <summary>
        /// 获取或设置界面实例对象池的优先级。
        /// </summary>
        public int InstancePriority
        {
            get
            {
                return m_InstancePool.Priority;
            }
            set
            {
                m_InstancePool.Priority = value;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            m_LoadAssetCallbacks = new LoadAssetCallbacks(LoadUIFormSuccessCallback, LoadUIFormFailureCallback, LoadUIFormUpdateCallback, LoadUIFormDependencyAssetCallback);
            m_UIFormsBeingLoaded = new Dictionary<int, string>();
            m_UIFormsToReleaseOnLoad = new HashSet<int>();

        }

        private void Start()
        {
            m_InstancePool = GameEntry.ObjectPool.CreateMultiSpawnObjectPool<AssetInstanceObject>("UI Asset Pool", 10, 16, 2, 0);
            m_InstancePool.Priority = m_InstancePriority;
            m_InstancePool.ExpireTime = m_InstanceExpireTime;
            m_InstancePool.Capacity = m_InstanceCapacity;
            m_InstancePool.AutoReleaseInterval = m_InstanceAutoReleaseInterval;
        }

        protected void OnDestroy()
        {
            m_UIFormsBeingLoaded.Clear();
            m_UIFormsToReleaseOnLoad.Clear();
            m_LoadAssetCallbacks = null;
            m_InstancePool = null;
        }

        public void LoadAssetAsync(int nLoadSerial, string strUIPath, string strShowName)
        {
            AssetInstanceObject uiFormAsset = m_InstancePool.Spawn(strUIPath);
            if (uiFormAsset == null)
            {
                OpenUIInfo openUIInfo = OpenUIInfo.Create(nLoadSerial, strUIPath, strShowName);
                m_UIFormsBeingLoaded.Add(nLoadSerial, strUIPath);
                GameEntry.Resource.LoadAsset(strUIPath, typeof(GameObject), Constant.AssetPriority.UIFormAsset, m_LoadAssetCallbacks, openUIInfo);
            }
            else
            {
                CallFunction("LoadUIFormSuccessCallback", (GameObject)uiFormAsset.Target, nLoadSerial);
            }
        }

        /// <summary>
        /// 回收资源
        /// </summary>
        /// <param name="asset"></param>
        public void Unspawn(object asset)
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
        public bool IsLoadingUIForm(int serialId)
        {
            return m_UIFormsBeingLoaded.ContainsKey(serialId);
        }
        /// <summary>
        /// 是否正在加载界面。
        /// </summary>
        /// <param name="uiFormAssetName">界面资源名称。</param>
        /// <returns>是否正在加载界面。</returns>
        public bool IsLoadingUIForm(string uiFormAssetName)
        {
            if (string.IsNullOrEmpty(uiFormAssetName))
            {
                throw new GameFrameworkException("UI form asset name is invalid.");
            }

            return m_UIFormsBeingLoaded.ContainsValue(uiFormAssetName);
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
            if (m_UIFormsToReleaseOnLoad.Contains(openUIInfo.SerialId))
            {
                m_UIFormsToReleaseOnLoad.Remove(openUIInfo.SerialId);
                ReferencePool.Release(openUIInfo);
                GameEntry.Resource.UnloadAsset(asset);
                return;
            }
            m_UIFormsBeingLoaded.Remove(openUIInfo.SerialId);
            AssetInstanceObject assetObject = AssetInstanceObject.Create(assetName, asset, Instantiate((UnityEngine.Object)asset));
            m_InstancePool.Register(assetObject, true);
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