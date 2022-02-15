// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-08-04 23-59-25  
//修改作者 : 杜鑫 
//修改时间 : 2021-08-04 23-59-25  
//版 本 : 0.1 
// ===============================================
using GameFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Deer
{
    public class LoadSpriteInfo : IReference
    {
        private Object m_Target;
        private string m_StrAssetPath;
        private string m_StrSpriteName;
        private bool m_SetNativeSize;
        public LoadSpriteInfo()
        {
            m_Target = null;
            m_StrAssetPath = "";
            m_StrSpriteName = "";
            m_SetNativeSize = false;
        }

        /// <summary>
        /// 获取要替换的目标图片
        /// </summary>
        public Object Target
        {
            get
            {
                return m_Target;
            }
        }

        /// <summary>
        /// 获取要替换的目标图片资源名称
        /// </summary>
        public string TargetAssetPath
        {
            get
            {
                return m_StrAssetPath;
            }
        }

        /// <summary>
        /// 获取要替换的目标图片资源名称
        /// </summary>
        public string TargetSpriteName
        {
            get
            {
                return m_StrSpriteName;
            }
        }

        /// <summary>
        /// 获取是否设置NativeSize
        /// </summary>
        public bool SetNativeSize
        {
            get
            {
                return m_SetNativeSize;
            }
        }


        public static LoadSpriteInfo Create(Image targetImage, string strAssetPath, string strSpriteName, bool setNativeSize) 
        {
            LoadSpriteInfo loadSpriteInfo = ReferencePool.Acquire<LoadSpriteInfo>();
            loadSpriteInfo.m_Target = targetImage;
            loadSpriteInfo.m_StrAssetPath = strAssetPath;
            loadSpriteInfo.m_StrSpriteName = strSpriteName;
            loadSpriteInfo.m_SetNativeSize = setNativeSize;
            return loadSpriteInfo;
        }

        public void Clear()
        {
            m_Target = null;
            m_StrAssetPath = null;
            m_StrSpriteName = null;
            m_SetNativeSize = false;
        }
    }
}