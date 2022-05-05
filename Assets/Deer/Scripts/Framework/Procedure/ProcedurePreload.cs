//================================================
//描 述 :  开始加载lua脚本流程
//作 者 : 杜鑫 
//创建时间 : 2021-07-04 17-23-05  
//修改作者 : 杜鑫 
//修改时间 : 2021-07-04 17-23-05  
//版 本 : 0.1 
// ===============================================
using GameFramework.Resource;
using System.Collections.Generic;
using Deer;
using GameFramework;
using UnityEngine;
using ProcedureBase = GameFramework.Procedure.ProcedureBase;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace Deer
{
    public class ProcedurePreload : ProcedureBase
    {
        public override bool UseNativeDialog { get; }
        private HashSet<string> m_LoadConfigFlag = new HashSet<string>();
        private HashSet<string> m_LoadLuaFlags = new HashSet<string>();
        private float m_allLuaCount = 0;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            PreloadConfig();
            if (Application.isEditor && GameEntry.Base.EditorResourceMode)
            {
                return;
            }
            PreloadLuaScripts();
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            if (IsPreloadFinish())
            {
                ChangeState<ProcedureStartLua>(procedureOwner);
            }
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            m_LoadLuaFlags.Clear();
            base.OnLeave(procedureOwner, isShutdown);
        }

        private bool IsPreloadFinish()
        {
            if (m_LoadConfigFlag.Count == 0 
                && m_LoadLuaFlags.Count == 0)
            {
                return true;
            }

            return false;
        }

        #region Config
        private void PreloadConfig()
        {
            m_LoadConfigFlag.Clear();
            m_LoadConfigFlag.Add("Config");
            GameEntry.Config.LoadAllUserConfig(OnLoadConfigComplete);
        }

        private void OnLoadConfigComplete(bool result,string resultMessage = "")
        {
            if (result)
            {
                m_LoadConfigFlag.Remove("Config");
            }
            else
            {
                Log.ColorInfo(ColorType.cadetblue, resultMessage);
            }
        }
        #endregion

        #region LuaScript
        private void PreloadLuaScripts()
        {
            m_LoadLuaFlags.Clear();
            List<string> listLuaScriptsAssetName = GameEntry.GameSettings.GetAllAsset(ResourcePathPrefix.Lua);
            int nLength = ResourcePathPrefix.Lua.Length;
            for (int i = 0; i < listLuaScriptsAssetName.Count; ++i)
            {
                string AssetPathName = listLuaScriptsAssetName[i];
                string FileName = AssetPathName.Substring(nLength).Replace(".bytes", "");                
                m_LoadLuaFlags.Add(FileName);
                GameEntry.Lua.LoadFile(AssetPathName, FileName, OnLoadLuaScriptSuccess, OnLoadLuaScriptFailure);
            }

            m_allLuaCount = m_LoadLuaFlags.Count;
        }

        private void OnLoadLuaScriptSuccess(string fileName)
        {
            //Log.Info("Load lua script '{0}' success.", fileName);
            m_LoadLuaFlags.Remove(fileName);
            MessengerInfo messengerInfo = ReferencePool.Acquire<MessengerInfo>();
            messengerInfo.param1 = (m_allLuaCount - m_LoadLuaFlags.Count)/m_allLuaCount;
            messengerInfo.param2 = m_allLuaCount - m_LoadLuaFlags.Count + "/" + m_allLuaCount;
            GameEntry.Messenger.SendEvent(EventName.EVENT_CS_UI_REFRESH_LOADING_UI,messengerInfo);
            ReferencePool.Release(messengerInfo);
        }

        private void OnLoadLuaScriptFailure(string fileName, LoadResourceStatus status, string errorMessage)
        {
            Log.Error("Load lua script '{0}' failure. Status is '{1}'. Error message is '{2}'.", fileName, status, errorMessage);
        }

        #endregion

    }

}
