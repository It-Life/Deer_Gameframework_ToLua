
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-04 17-19-18  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-04 17-19-18  
---版 本 : 0.1 
---===============================================
---@class ProcedureLogin:ProcedureBase
ProcedureLogin = Class("ProcedureLogin",ProcedureBase)

function ProcedureLogin:OnEnter(csProcedure)
    self.super.OnEnter(self,csProcedure)
    self.csProcedure = csProcedure
    LuaGameEntry.LuaSound:PlayMusic(SoundId.LOGIN_BGM)
    --弹出登录界面
    LuaGameEntry.UI:OpenUI(UINameConfig.UILoginPanel)
    --LuaGameEntry.UI:OpenUI(UINameConfig.UIBagPanel)
end

function ProcedureLogin:OnLeave()
    self.super.OnLeave(self)

end

return ProcedureLogin