// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-07-13 23-39-43  
//修改作者 : 杜鑫 
//修改时间 : 2021-07-13 23-39-43  
//版 本 : 0.1 
// ===============================================
using GameFramework;
using GameFramework.ObjectPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Deer
{
    public class AssetInstanceObject : ObjectBase
    {
        private object m_AssetInstanceObject;

        public AssetInstanceObject()
        {
            m_AssetInstanceObject = null;
        }


        public static AssetInstanceObject Create(string name, object unityObjectAsset)
        {
            if (unityObjectAsset == null)
            {
                throw new GameFrameworkException("Asset is invalid.");
            }

            AssetInstanceObject unityAssetObject = ReferencePool.Acquire<AssetInstanceObject>();
            unityAssetObject.Initialize(name, unityObjectAsset);
            unityAssetObject.m_AssetInstanceObject = unityObjectAsset;
            return unityAssetObject;
        }

        public override void Clear()
        {
            base.Clear();
            m_AssetInstanceObject = null;

        }

        protected override void Release(bool isShutdown)
        {
            GameEntry.Resource.UnloadAsset(m_AssetInstanceObject);
        }
    }
}