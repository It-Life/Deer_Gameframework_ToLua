// ================================================
//描 述:
//作 者:杜鑫
//创建时间:2022-05-12 16-31-38
//修改作者:杜鑫
//修改时间:2022-05-12 16-31-38
//版 本:0.1 
// ===============================================
using GameFramework;
using GameFramework.ObjectPool;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Deer
{
    public class UIFormInstanceObject : ObjectBase
    {
        private object m_AssetObject;
        private int m_LoadSerial;
        private Action<int> m_ReleaseComplete;

        public UIFormInstanceObject()
        {
            m_AssetObject = null;
        }


        public static UIFormInstanceObject Create(string name, object unityObjectAsset, object uiFormInstance,int loadSerial, Action<int> action)
        {
            if (unityObjectAsset == null)
            {
                throw new GameFrameworkException("Asset is invalid.");
            }

            UIFormInstanceObject unityAssetObject = ReferencePool.Acquire<UIFormInstanceObject>();
            unityAssetObject.Initialize(name, uiFormInstance);
            unityAssetObject.m_AssetObject = unityObjectAsset;
            unityAssetObject.m_LoadSerial = loadSerial;
            unityAssetObject.m_ReleaseComplete = action;
            return unityAssetObject;
        }

        public override void Clear()
        {
            base.Clear();
            m_AssetObject = null;
            m_LoadSerial = 0;
            m_ReleaseComplete = null;
        }

        protected override void Release(bool isShutdown)
        {
            GameEntry.Resource.UnloadAsset(m_AssetObject);
            UnityEngine.GameObject.Destroy((UnityEngine.Object)Target);
            m_ReleaseComplete?.Invoke(m_LoadSerial);
        }
    }
}