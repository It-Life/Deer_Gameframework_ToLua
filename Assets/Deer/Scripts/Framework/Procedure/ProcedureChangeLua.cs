//================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-07-04 16-44-43  
//修改作者 : 杜鑫 
//修改时间 : 2021-07-04 16-44-43  
//版 本 : 0.1 
// ===============================================
using GameFramework;
using GameFramework.Fsm;
using GameFramework.Procedure;
using LuaInterface;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace Deer
{
    public class ProcedureChangeLua : ProcedureBase
    {
        private ProcedureOwner _ProcedureOwner;
        private string _NextProcedurName;
        private LuaTable _LuaModule;
        private bool _IsEnter = false;
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
            IsLuaProcedure = true;
            _IsEnter = false;
            _ProcedureOwner = procedureOwner;
            _NextProcedurName = _ProcedureOwner.GetData<VarString>(ProcedureData.NextProcedureId);
            _LuaModule = GameEntry.Lua.GetMainState().GetTable(_NextProcedurName);
            if (_LuaModule == null)
            {
                Log.Error("Lua 流程 '{0}' 不存在", _NextProcedurName);
                return;
            }
            CallLuaFunc("OnEnter");
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            CallLuaFunc("OnEnter");
        }

        private void CallLuaFunc(string strFunName)
        {
            if (_LuaModule == null)
            {
                return;
            }

            if (_IsEnter)
            {
                return;
            }

            _LuaModule.Call(strFunName, _LuaModule,this);
            _IsEnter = true;
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            if (_LuaModule != null)
            {
                _LuaModule.Call("OnLeave", _LuaModule);
            }
            _IsEnter = false;
            base.OnLeave(procedureOwner, isShutdown);
        }
        /// <summary>
        /// 切换lua流程
        /// </summary>
        /// <param name="NextProcedureId">lua流程id</param>
        public void ChangeStateToMain(string NextProcedureId) 
        {
            _ProcedureOwner.SetData<VarString>(ProcedureData.NextProcedureId, NextProcedureId);
            ChangeState<ProcedureMain>(_ProcedureOwner);
        }

        public string GetCurProcedureId() 
        {
            return _NextProcedurName;
        }
    }
}