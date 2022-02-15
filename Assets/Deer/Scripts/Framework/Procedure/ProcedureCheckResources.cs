﻿// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-10-07 22-27-47  
//修改作者 : 杜鑫 
//修改时间 : 2021-10-07 22-27-47  
//版 本 : 0.1 
// ===============================================
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
namespace Deer
{
    public class ProcedureCheckResources : ProcedureBase
    {
        private bool m_CheckResourcesComplete = false;
        private bool m_NeedUpdateResources = false;
        private int m_UpdateResourceCount = 0;
        private long m_UpdateResourceTotalZipLength = 0L;

        public override bool UseNativeDialog
        {
            get
            {
                return true;
            }
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            m_CheckResourcesComplete = false;
            m_NeedUpdateResources = false;
            m_UpdateResourceCount = 0;
            m_UpdateResourceTotalZipLength = 0L;

            GameEntry.Resource.CheckResources(OnCheckResourcesComplete);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (!m_CheckResourcesComplete)
            {
                return;
            }

            if (m_NeedUpdateResources)
            {
                procedureOwner.SetData<VarInt>("UpdateResourceCount", m_UpdateResourceCount);
                procedureOwner.SetData<VarLong>("UpdateResourceTotalZipLength", m_UpdateResourceTotalZipLength);
                ChangeState<ProcedureUpdateResources>(procedureOwner);
            }
            else
            {
                ChangeState<ProcedureReadResourcePath>(procedureOwner);
            }
        }

        private void OnCheckResourcesComplete(int movedCount, int removedCount, int updateCount, long updateTotalLength, long updateTotalZipLength)
        {
            m_CheckResourcesComplete = true;
            m_NeedUpdateResources = updateCount > 0;
            m_UpdateResourceCount = updateCount;
            m_UpdateResourceTotalZipLength = updateTotalZipLength;
            Log.Info("Check resources complete, '{0}' resources need to update, zip length is '{1}', unzip length is '{2}'.", updateCount.ToString(), updateTotalZipLength.ToString(), updateTotalLength.ToString());
        }
    }
}