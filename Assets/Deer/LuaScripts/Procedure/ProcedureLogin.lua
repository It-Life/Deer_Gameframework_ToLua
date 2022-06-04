
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
    self:RegisterEvent()

    LuaGameEntry.LuaSound:PlayMusic(SoundId.LOGIN_BGM)
    --弹出登录界面
    LuaGameEntry.UI:OpenUI(UINameConfig.UILoginPanel,nil,function(result)
        if result then
            LuaGameEntry.LuaEvent:SendCSEvent(EventName.EVENT_CS_UI_OPEN_INITFORM_UI,false)
        end
    end)
    --LuaGameEntry.UI:OpenUI(UINameConfig.UIMagicalBrushSelectPanel)
    --LuaGameEntry.UI:OpenUI(UINameConfig.UIBagPanel)
end

---注册事件
function ProcedureLogin:RegisterEvent()

end

---移除事件
function ProcedureLogin:UnRegisterEvent()

end


function ProcedureLogin:OnLeave()
    self.super.OnLeave(self)
    self:UnRegisterEvent()
end

return ProcedureLogin