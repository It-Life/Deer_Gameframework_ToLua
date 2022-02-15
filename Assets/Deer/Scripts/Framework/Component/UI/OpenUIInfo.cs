// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-07-14 00-02-45  
//修改作者 : 杜鑫 
//修改时间 : 2021-07-14 00-02-45  
//版 本 : 0.1 
// ===============================================
using GameFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Deer
{
    /// <summary>
    /// 打开UI窗口信息
    /// </summary>
    public class OpenUIInfo : IReference
    {
        private int m_SerialId;
        private string m_UIAssetName;

        public OpenUIInfo()
        {
            m_SerialId = 0;
            m_UIAssetName = null;
        }

        public string ShowUIName
        {
            get;
            private set;
        }
        /// <summary>
        /// 获取UI序列号
        /// </summary>
        public int SerialId
        {
            get
            {
                return m_SerialId;
            }
        }

        /// <summary>
        /// 获取UI界面资源名称
        /// </summary>
        public string UIAssetName
        {
            get
            {
                return m_UIAssetName;
            }
        }


        public static OpenUIInfo Create(int serialId, string uiAssetName, string showUIName)
        {
            OpenUIInfo openUIInfo = ReferencePool.Acquire<OpenUIInfo>();
            openUIInfo.m_SerialId = serialId;
            openUIInfo.m_UIAssetName = uiAssetName;
            openUIInfo.ShowUIName = showUIName;
            return openUIInfo;
        }

        public void Clear()
        {
            m_SerialId = 0;
            m_UIAssetName = null;
        }
    }
}