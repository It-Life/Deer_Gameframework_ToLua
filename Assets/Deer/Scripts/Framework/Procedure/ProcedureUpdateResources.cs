// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-10-07 22-20-53  
//修改作者 : 杜鑫 
//修改时间 : 2021-10-07 22-20-53  
//版 本 : 0.1 
// ===============================================

using System;
using GameFramework;
using GameFramework.Event;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace Deer
{
    public enum UpdateStateType
    {
        Start = 0,
        Change,
        Success,
        Failure
    }

    public class ProcedureUpdateResources : ProcedureBase
    {
        public override bool UseNativeDialog
        {
            get
            {
                return true;
            }
        }
        private float m_LastUpdateTime;
        private bool m_NoticeUpdate = false;
        private bool m_CheckConfigComplete = false;
        private bool m_CheckResourcesComplete = false;
        private bool m_NeedUpdateConfig = false;
        private bool m_NeedUpdateResources = false;
        private int m_UpdateConfigCount = 0;
        private int m_UpdateResourceCount = 0; 
        private long m_UpdateTotalZipLength = 0;
        private int m_UpdateSuccessCount = 0;
        private bool m_UpdateConfigsComplete = false;
        private bool m_UpdateResourcesComplete = false;
        private List<UpdateInfoData> m_UpdateInfoDatas = new List<UpdateInfoData>();
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            m_NoticeUpdate = false;
            m_CheckConfigComplete = false;
            m_CheckResourcesComplete = false;
            m_NeedUpdateConfig = false;
            m_NeedUpdateResources = false;
            m_UpdateConfigsComplete = false;
            m_UpdateResourcesComplete = false;
            m_UpdateTotalZipLength = 0;
            m_UpdateSuccessCount = 0;
            m_LastUpdateTime = 0;
            m_UpdateConfigCount = 0;
            m_UpdateResourceCount = 0;
            m_UpdateInfoDatas.Clear(); 
            
            GameEntry.Event.Subscribe(ResourceUpdateStartEventArgs.EventId, OnResourceUpdateStart);
            GameEntry.Event.Subscribe(ResourceUpdateChangedEventArgs.EventId, OnResourceUpdateChanged);
            GameEntry.Event.Subscribe(ResourceUpdateSuccessEventArgs.EventId, OnResourceUpdateSuccess);
            GameEntry.Event.Subscribe(ResourceUpdateFailureEventArgs.EventId, OnResourceUpdateFailure);
            GameEntry.Event.Subscribe(DownloadStartEventArgs.EventId, OnDownloadStart);
            GameEntry.Event.Subscribe(DownloadSuccessEventArgs.EventId, OnDownloadSuccess);
            GameEntry.Event.Subscribe(DownloadFailureEventArgs.EventId, OnDownloadFailure);
            GameEntry.Messenger.RegisterEvent(EventName.EVENT_CS_UI_TIPS_CALLBACK,NoticeTipsUpdate);

            if (Application.isEditor)
            {
                PlayerPrefs.SetInt(PrefsKey.FIRST_MOVE_READWRITE_PATH,1);
            }
            GameEntry.Config.CheckConfigVersion(OnCheckConfigComplete);
            if (GameEntry.Base.EditorResourceMode)
            {
                m_NeedUpdateResources = false;
                m_UpdateResourcesComplete = true;
                OnNoticeUpdate();
                return;
            }
            GameEntry.Resource.CheckResources(OnCheckResourcesComplete);
        }
        
        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            GameEntry.Event.Unsubscribe(ResourceUpdateStartEventArgs.EventId, OnResourceUpdateStart);
            GameEntry.Event.Unsubscribe(ResourceUpdateChangedEventArgs.EventId, OnResourceUpdateChanged);
            GameEntry.Event.Unsubscribe(ResourceUpdateSuccessEventArgs.EventId, OnResourceUpdateSuccess);
            GameEntry.Event.Unsubscribe(ResourceUpdateFailureEventArgs.EventId, OnResourceUpdateFailure);
            GameEntry.Event.Unsubscribe(DownloadStartEventArgs.EventId, OnDownloadStart);
            GameEntry.Event.Unsubscribe(DownloadSuccessEventArgs.EventId, OnDownloadSuccess);
            GameEntry.Event.Unsubscribe(DownloadFailureEventArgs.EventId, OnDownloadFailure);
            GameEntry.Messenger.UnRegisterEvent(EventName.EVENT_CS_UI_TIPS_CALLBACK,NoticeTipsUpdate);
            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (m_CheckResourcesComplete && m_CheckConfigComplete)
            {
                if (!m_NoticeUpdate)
                {
                    OnNoticeUpdate();
                }
            }
            if (!m_UpdateResourcesComplete || !m_UpdateConfigsComplete)
            {
                return;
            }

            ChangeState<ProcedureReadResourcePath>(procedureOwner);
        }
        
        private void OnCheckConfigComplete(int movedCount,int removedCount, int updateCount, long updateTotalZipLength)
        {
            m_CheckConfigComplete = true;
            m_NeedUpdateConfig = updateCount > 0;
            m_UpdateConfigCount = updateCount;
            m_UpdateTotalZipLength += updateTotalZipLength;
        }
        private void OnCheckResourcesComplete(int movedCount,int removedCount, int updateCount, long updateTotalLength, long updateTotalZipLength)
        {
            m_CheckResourcesComplete = true;
            m_NeedUpdateResources = updateCount > 0;
            m_UpdateResourceCount = updateCount;
            m_UpdateTotalZipLength += updateTotalZipLength;
        }

        private void OnNoticeUpdate()
        {
            m_NoticeUpdate = true;
            if (m_UpdateTotalZipLength > 0)
            {
                string conetnt = Utility.Text.Format("有{0}更新", FileUtils.GetLengthString(m_UpdateTotalZipLength));
                UnityGameFramework.Runtime.Log.Info(conetnt);
                MessengerInfo messengerInfo = new MessengerInfo();
                messengerInfo.param1 = true;
                messengerInfo.param2 = Utility.Text.Format("客官,有{0}更新，请立马更新！", FileUtils.GetLengthString(m_UpdateTotalZipLength));
                GameEntry.Messenger.SendEvent(EventName.EVENT_CS_UI_OPEN_TIPS_UI, messengerInfo);
            }
            else
            {
                StartUpdate();
            }
        }

        private object NoticeTipsUpdate(object pSender)
        {
            MessengerInfo messengerInfo = (MessengerInfo) pSender;
            bool bIsOk = bool.Parse(messengerInfo.param1.ToString());
            if (bIsOk)
            {
                StartUpdate();
            }
            else
            {
                Application.Quit();
            }
            return null;
        }

        private void StartUpdate()
        {
            if (m_NeedUpdateConfig)
            {
                StartUpdateConfigs(null);
            }
            else
            {
                m_UpdateConfigsComplete = true;
            }

            if (m_NeedUpdateResources)
            {
                StartUpdateResources(null);
            }
            else
            {
                m_UpdateResourcesComplete = true;
            }
        }

        private void StartUpdateConfigs(object userData)
        {
            Log.Info("Start update config ");
            GameEntry.Config.UpdateConfigs(OnUpdateConfigsComplete);
        }

        private void StartUpdateResources(object userData)
        {
            Log.Info("Start update resource group ");
            GameEntry.Resource.UpdateResources(OnUpdateResourcesComplete);
        }
        private void RefreshProgress()
        {
            string updateProgress = string.Empty;
            long currentTotalUpdateLength = 0L;
            for (int i = 0; i < m_UpdateInfoDatas.Count; i++)
            {
                currentTotalUpdateLength += m_UpdateInfoDatas[i].Length;
            }
            if (Time.time - m_LastUpdateTime > 1f)
            {
                m_LastUpdateTime = Time.time;
                int needTime = 0;
                if (GameEntry.Download.CurrentSpeed > 0)
                {
                    needTime = (int)((m_UpdateTotalZipLength - currentTotalUpdateLength) / GameEntry.Download.CurrentSpeed);
                }

                TimeSpan ts = new TimeSpan(0, 0, needTime);
                string timeStr = ts.ToString(@"mm\:ss");
                updateProgress = string.Format("剩余时间 {0}({1}/s)", timeStr, FileUtils.GetLengthString((int)GameEntry.Download.CurrentSpeed));
                Log.Info(updateProgress);
            }
            float progressTotal = (float)currentTotalUpdateLength / m_UpdateTotalZipLength;
            Log.Info($"更新成功数量:{m_UpdateSuccessCount} 总更新数量:{m_UpdateConfigCount + m_UpdateResourceCount} 资源数量:{m_UpdateResourceCount} Config数量:{m_UpdateConfigCount}");
            Log.Info($"当前下载:{FileUtils.GetByteLengthString(currentTotalUpdateLength)} 总下载:{FileUtils.GetByteLengthString(m_UpdateTotalZipLength)} 下载进度:{progressTotal}");
            Log.Info($"下载速度:{FileUtils.GetByteLengthString((int)GameEntry.Download.CurrentSpeed)}");
            MessengerInfo messengerInfo = ReferencePool.Acquire<MessengerInfo>();
            messengerInfo.param1 = progressTotal;
            messengerInfo.param2 = $"{FileUtils.GetByteLengthString(currentTotalUpdateLength)}/{FileUtils.GetByteLengthString(m_UpdateTotalZipLength)}  当前下载速度每秒{FileUtils.GetByteLengthString((int)GameEntry.Download.CurrentSpeed)}";
            GameEntry.Messenger.SendEvent(EventName.EVENT_CS_UI_REFRESH_LOADING_UI,messengerInfo);
        }
        private void OnUpdateConfigsComplete(bool result)
        {
            if (result)
            {
                m_UpdateConfigsComplete = true;
                Log.Info("Update config complete with no errors.");
            }
            else
            {
                Log.Error("Update config complete with errors.");
            }
        }
        private void OnUpdateResourcesComplete(GameFramework.Resource.IResourceGroup resourceGroup, bool result)
        {
            if (result)
            {
                m_UpdateResourcesComplete = true;
                Log.Info("Update resources complete with no errors.");
            }
            else
            {
                Log.Error("Update resources complete with errors.");
            }
        }
        private void OnUpdateCompleteOne(string name,int length,UpdateStateType type)
        {
            for (int i = 0; i < m_UpdateInfoDatas.Count; i++)
            {
                if (m_UpdateInfoDatas[i].Name == name)
                {
                    if (type==UpdateStateType.Failure)
                    {
                        Log.Warning("Update '{0}' is failure.", name);
                        m_UpdateInfoDatas.Remove(m_UpdateInfoDatas[i]);
                    }
                    else
                    {
                        if (type == UpdateStateType.Start)
                        {
                            Log.Warning("Update '{0}' is invalid.", name);
                        }

                        if (type == UpdateStateType.Success)
                        {
                            Log.Warning("Update '{0}' is success.", name);
                        }
                        m_UpdateInfoDatas[i].Length = length;
                    }
                    RefreshProgress();
                    return;
                }
            }
        }
        private void OnResourceUpdateStart(object sender, GameEventArgs e)
        {
            ResourceUpdateStartEventArgs ne = (ResourceUpdateStartEventArgs)e;
            OnUpdateCompleteOne(ne.Name, 0,UpdateStateType.Start);
            m_UpdateInfoDatas.Add(new UpdateInfoData(ne.Name));
        }

        private void OnResourceUpdateChanged(object sender, GameEventArgs e)
        {
            ResourceUpdateChangedEventArgs ne = (ResourceUpdateChangedEventArgs)e;
            OnUpdateCompleteOne(ne.Name, ne.CurrentLength,UpdateStateType.Change);
        }

        private void OnResourceUpdateSuccess(object sender, GameEventArgs e)
        {
            ResourceUpdateSuccessEventArgs ne = (ResourceUpdateSuccessEventArgs)e;
            OnUpdateCompleteOne(ne.Name, ne.ZipLength,UpdateStateType.Success);
        }

        private void OnResourceUpdateFailure(object sender, GameEventArgs e)
        {
            ResourceUpdateFailureEventArgs ne = (ResourceUpdateFailureEventArgs)e;
            if (ne.RetryCount >= ne.TotalRetryCount)
            {
                Log.Error("Update resource '{0}' failure from '{1}' with error message '{2}', retry count '{3}'.", ne.Name, ne.DownloadUri, ne.ErrorMessage, ne.RetryCount.ToString());
                return;
            }
            else
            {
                Log.Info("Update resource '{0}' failure from '{1}' with error message '{2}', retry count '{3}'.", ne.Name, ne.DownloadUri, ne.ErrorMessage, ne.RetryCount.ToString());
            }
            OnUpdateCompleteOne(ne.Name, 0,UpdateStateType.Failure);
        }

        private void OnDownloadStart(object sender, GameEventArgs e)
        {
            DownloadStartEventArgs ne = (DownloadStartEventArgs)e;
            if (!(ne.UserData is ConfigInfo configInfo))
            {
                return;
            }
            OnUpdateCompleteOne(configInfo.Name,0,UpdateStateType.Start);
            m_UpdateInfoDatas.Add(new UpdateInfoData(configInfo.Name));
        }
        private void OnDownloadSuccess(object sender, GameEventArgs e)
        {
            DownloadSuccessEventArgs ne = (DownloadSuccessEventArgs)e;
            if (!(ne.UserData is ConfigInfo configInfo))
            {
                return;
            }
            int size = configInfo.Size.ToInt();
            OnUpdateCompleteOne(configInfo.Name,(size > 0 ? size : 1) * 1024,UpdateStateType.Success);
        }
        private void OnDownloadFailure(object sender, GameEventArgs e)
        {
            DownloadFailureEventArgs ne = (DownloadFailureEventArgs)e;
            if (!(ne.UserData is ConfigInfo configInfo))
            {
                return;
            }
            OnUpdateCompleteOne(configInfo.Name,0,UpdateStateType.Failure);
        }
        private class UpdateInfoData
        {
            private readonly string m_Name;

            public UpdateInfoData(string name)
            {
                m_Name = name;
            }

            public string Name => m_Name;

            public int Length
            {
                get;
                set;
            }
        }
    }
}