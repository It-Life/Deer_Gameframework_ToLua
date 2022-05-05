//================================================
//描 述 :  读取资源路径流程
//作 者 : 杜鑫 
//创建时间 : 2021-07-04 17-23-05  
//修改作者 : 杜鑫 
//修改时间 : 2021-07-04 17-23-05  
//版 本 : 0.1 
// ===============================================
using GameFramework.Fsm;
using GameFramework.Procedure;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using UnityGameFramework.Runtime;
using GameFramework.Resource;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace Deer
{
    public class ProcedureReadResourcePath : ProcedureBase
    {
        public override bool UseNativeDialog { get; }

        private bool m_Complete;
        private bool m_InitResourcesComplete = false;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            m_Complete = false;
            string path = "Assets/" + ResourcesPathData.AppResourcePathConfig;
            //string path = "Asset/EditorConfigs/ResourcePathCollection.txt";
            GameEntry.Resource.LoadAsset(path, new LoadAssetCallbacks(
                (assetName, asset, duration, userData) => { LoadCallBack(asset); },

                (assetName, status, errorMessage, userData) =>
                {
                    Log.Error("Can not load txt '{0}'  with error message '{1}'.", assetName, errorMessage);
                }));
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds,
            float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            if (m_Complete)
            {
                ChangeState<ProcedurePreload>(procedureOwner);
            }
        }

        private void LoadCallBack(object asset)
        {
            string content = ((TextAsset) asset).text;
            Dictionary<string, List<string>> startAssetInfos = new Dictionary<string, List<string>>();

            string[] lines = StringUtils.SplitRemoveEmpty(content, "\r\n");
            for (int i = 0; i < lines.Length; i++)
            {
                string[] arrData = lines[i].Split('|');
                if (arrData.Length == 2)
                {
                    AddInfo(arrData[0], arrData[1], startAssetInfos);
                }
            }

            foreach (var item in startAssetInfos)
            {
                GameEntry.GameSettings.SetStartAssetInfos(item.Key, item.Value);
            }

            GameEntry.Resource.UnloadAsset(asset);
            m_Complete = true;
        }

        private void AddInfo(string startPath, string fullPath, Dictionary<string, List<string>> startAssetInfos)
        {
            List<string> infos = null;
            if (!startAssetInfos.TryGetValue(startPath, out infos))
            {
                infos = new List<string>();
                startAssetInfos.Add(startPath, infos);
            }

            infos.Add(fullPath);
        }
    }
}

