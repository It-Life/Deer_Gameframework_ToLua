// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2022-03-09 19-28-53  
//修改作者 : 杜鑫 
//修改时间 : 2022-03-09 19-28-53  
//版 本 : 0.1 
// ===============================================
using GameFramework;
using GameFramework.ObjectPool;
using GameFramework.Resource;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Deer
{
    public delegate void LoadAssetObjectComplete(bool success, object assetObj, int nLoadSerial);

    [DisallowMultipleComponent]
    [AddComponentMenu("Deer/AssetPrefab")]
    public class AssetObjectComponent : GameFrameworkComponent
    {
        private IObjectPool<AssetInstanceObject> m_InstancePool; //AssetObject资源池   
        private LoadAssetCallbacks m_LoadAssetCallbacks; //AssetObject加载回调
        private Dictionary<int, string> m_AssetObjectBeingLoaded; //正在加载的AssetObject列表      
        private HashSet<int> m_AssetObjectToReleaseOnLoad; //加载完毕要卸载的AssetObject  
        private string m_luaModuleHelperName = "AssetObjectManagerHelper";
        private int m_nLoadSerial = 0;
        [SerializeField]
        private float m_InstanceAutoReleaseInterval = 5f;

        [SerializeField]
        private int m_InstanceCapacity = 16;

        [SerializeField]
        private float m_InstanceExpireTime = 60f;

        [SerializeField]
        private int m_InstancePriority = 0;

        private Dictionary<int, LoadAssetObjectComplete> m_LoadAssetObjectComplete;


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
            m_LoadAssetCallbacks = new LoadAssetCallbacks(LoadAssetObjectSuccessCallback, LoadAssetObjectFailureCallback, LoadAssetObjectUpdateCallback, LoadAssetObjectDependencyAssetCallback);
            m_AssetObjectBeingLoaded = new Dictionary<int, string>();
            m_AssetObjectToReleaseOnLoad = new HashSet<int>();
            m_LoadAssetObjectComplete = new Dictionary<int, LoadAssetObjectComplete>();
        }

        private void Start()
        {
            m_InstancePool = GameEntry.ObjectPool.CreateSingleSpawnObjectPool<AssetInstanceObject>("Asset Object Pool", 10, 16, 2, 0);
            m_InstancePool.Priority = m_InstancePriority;
            m_InstancePool.ExpireTime = m_InstanceExpireTime;
            m_InstancePool.Capacity = m_InstanceCapacity;
            m_InstancePool.AutoReleaseInterval = m_InstanceAutoReleaseInterval;
        }
        protected void OnDestroy()
        {
            m_AssetObjectBeingLoaded.Clear();
            m_AssetObjectToReleaseOnLoad.Clear();
            m_LoadAssetCallbacks = null;
            m_InstancePool = null;
        }
        public void LoadAssetAsync(int nLoadSerial, string strPath, string strShowName, LoadAssetObjectComplete loadAssetObjectComplete = null)
        {
            m_LoadAssetObjectComplete.Add(nLoadSerial, loadAssetObjectComplete);
            AssetInstanceObject assetObject = m_InstancePool.Spawn(strPath);
            if (assetObject == null)
            {
                AssetObjectInfo assetObjectInfo = AssetObjectInfo.Create(nLoadSerial, strPath, strShowName);
                m_AssetObjectBeingLoaded.Add(nLoadSerial, strPath);
                GameEntry.Resource.LoadAsset(strPath, typeof(GameObject), Constant.AssetPriority.SceneUnit, m_LoadAssetCallbacks, assetObjectInfo);
            }
            else
            {
                CallFunction("LoadAssetObjectSuccessCallback", (GameObject)assetObject.Target, nLoadSerial);
            }
        }
        /// <summary>
        /// 回收资源(不要调用 只用于AssetObjectBase destroy的时候)
        /// </summary>
        /// <param name="asset"></param>
        public void Unspawn(object asset)
        {
            if (m_InstancePool == null)
            {
                Log.Error("AssetObjectComponent Unspwn m_InstancePool null");
                return;
            }
            m_InstancePool.Unspawn(asset);
        }
        /// <summary>
        /// 是否正在加载预制体
        /// </summary>
        /// <param name="uiFormAssetName">界面资源名称</param>
        /// <returns>是否正在加载预制体</returns>
        public bool IsLoadingUIForm(int serialId)
        {
            return m_AssetObjectBeingLoaded.ContainsKey(serialId);
        }
        /// <summary>
        /// 是否正在加载预制体
        /// </summary>
        /// <param name="assetObjectName">资源名称</param>
        /// <returns>是否正在加载预制体</returns>
        public bool IsLoadingAssetObject(string assetObjectName)
        {
            return m_AssetObjectBeingLoaded.ContainsValue(assetObjectName);
        }
        private void LoadAssetObjectDependencyAssetCallback(string assetName, string dependencyAssetName, int loadedCount, int totalCount, object userData)
        {
            AssetObjectInfo assetObjectInfo = (AssetObjectInfo)userData;
            if (assetObjectInfo == null)
            {
                Log.Error("Open AssetObject info is invalid.");
            }
        }

        private void LoadAssetObjectUpdateCallback(string assetName, float progress, object userData)
        {
            AssetObjectInfo assetObjectInfo = (AssetObjectInfo)userData;
            if (assetObjectInfo == null)
            {
                Log.Error("Open AssetObject info is invalid.");
            }
        }

        private void LoadAssetObjectFailureCallback(string assetName, LoadResourceStatus status, string errorMessage, object userData)
        {
            AssetObjectInfo assetObjectInfo = (AssetObjectInfo)userData;
            if (assetObjectInfo == null)
            {
                throw new GameFrameworkException("Open AssetObject info is invalid.");
            }

            if (m_AssetObjectToReleaseOnLoad.Contains(assetObjectInfo.SerialId))
            {
                m_AssetObjectToReleaseOnLoad.Remove(assetObjectInfo.SerialId);
                ReferencePool.Release(assetObjectInfo);
                return;
            }

            m_AssetObjectBeingLoaded.Remove(assetObjectInfo.SerialId);

            string appendErrorMessage = Utility.Text.Format("Load assetObject failure, asset name '{0}', status '{1}' , error message '{2}'.", assetName, status.ToString(), errorMessage);
            CallFunction("LoadAssetObjectFailureCallback", assetObjectInfo.SerialId);

            ReferencePool.Release(assetObjectInfo);
            Log.Error(appendErrorMessage);
        }

        private void LoadAssetObjectSuccessCallback(string assetName, object asset, float duration, object userData)
        {
            AssetObjectInfo assetObjectInfo = (AssetObjectInfo)userData;
            if (assetObjectInfo == null)
            {
                throw new Exception("Open AssetObject info is invalid.");
            }
            if (m_AssetObjectToReleaseOnLoad.Contains(assetObjectInfo.SerialId))
            {
                m_AssetObjectToReleaseOnLoad.Remove(assetObjectInfo.SerialId);
                ReferencePool.Release(assetObjectInfo);
                GameEntry.Resource.UnloadAsset(asset);
                return;
            }
            m_AssetObjectBeingLoaded.Remove(assetObjectInfo.SerialId);
            AssetInstanceObject assetObject = AssetInstanceObject.Create(assetName, asset, Instantiate((UnityEngine.Object)asset));
            m_InstancePool.Register(assetObject, true);
            CallFunction("LoadAssetObjectSuccessCallback", (GameObject)assetObject.Target, assetObjectInfo.SerialId);
            ReferencePool.Release(assetObjectInfo);

        }
        private void CallFunction(string func, int serialId)
        {
            if (m_LoadAssetObjectComplete.TryGetValue(serialId, out LoadAssetObjectComplete loadAssetObjectComplete))
            {
                loadAssetObjectComplete?.Invoke(false, null, 0);
            }
            GameEntry.Lua.CallFunction(m_luaModuleHelperName + "." + func, serialId);
        }
        private void CallFunction(string func, GameObject gameObject, int serialId)
        {
            if (m_LoadAssetObjectComplete.TryGetValue(serialId, out LoadAssetObjectComplete loadAssetObjectComplete))
            {
                loadAssetObjectComplete?.Invoke(true, gameObject, serialId);
            }
            GameEntry.Lua.CallFunction(m_luaModuleHelperName + "." + func, gameObject, serialId);
        }
        public int GenSerialId()
        {
            m_nLoadSerial += 1;
            return m_nLoadSerial;
        }
    }
}