//================================================
//描 述 :  开始lua流程
//作 者 : 杜鑫 
//创建时间 : 2021-07-04 17-23-05  
//修改作者 : 杜鑫 
//修改时间 : 2021-07-04 17-23-05  
//版 本 : 0.1 
// ===============================================
using GameFramework;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace Deer
{
    public class ProcedureStartLua : ProcedureBase
    {
        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameEntry.Lua.StartLuaMain();
            
        }
        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            procedureOwner.SetData<VarString>(ProcedureData.NextProcedureId, "ProcedureMain");
            ChangeState<ProcedureMain>(procedureOwner);
            GameEntry.Messenger.SendEvent(EventName.EVENT_CS_UI_OPEN_INITFORM_UI,false);
        }

    }
}