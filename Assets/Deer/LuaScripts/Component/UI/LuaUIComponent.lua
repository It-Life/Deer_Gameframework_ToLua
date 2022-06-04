
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-12 23-12-30  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-12 23-12-30  
---版 本 : 0.1 
---===============================================
---@class LuaUIComponent:LuaComponentBase
---@field m_uiManager UIManager
LuaUIComponent = Class("LuaUIComponent",LuaComponentBase)

function LuaUIComponent:__init()
    self.m_uiManager = UIManager:GetInstance()
    self:RegisterEvent()
end

function LuaUIComponent:__delete()
    self.m_uiManager:Delete()
    self:UnRegisterEvent()
end

function LuaUIComponent:RegisterEvent()
    self._onhandleopenuiform = LuaGameEntry.LuaEvent:RegisterLuaEvent(EventId.EVENT_LUA_OPEN_UI_FORM,self.OnHandleOpenUIForm,self)
    self._onhandlecloseuiform = LuaGameEntry.LuaEvent:RegisterLuaEvent(EventId.EVENT_LUA_CLOSE_UI_FORM,self.OnHandleCloseUIForm,self)
end

function LuaUIComponent:UnRegisterEvent()
    LuaGameEntry.LuaEvent:UnRegisterLuaEvent(EventId.EVENT_LUA_OPEN_UI_FORM,self._onhandleopenuiform)
    LuaGameEntry.LuaEvent:UnRegisterLuaEvent(EventId.EVENT_LUA_CLOSE_UI_FORM,self._onhandlecloseuiform)
end

---@param uiName UINameConfig
---@param userData table enumGroup[option] UIFormGroupType,
function LuaUIComponent:OpenUI(strUIConfig,userData,results)
    self.m_uiManager:CreateForm(strUIConfig,userData,results)
end

function LuaUIComponent:CloseUI(strUIConfig,userData,results)
    self.m_uiManager:CloseForm(strUIConfig,userData,results)
end

function LuaUIComponent:CloseUIById(serialId,userData,results)
    self.m_uiManager:CloseFormById(serialId,userData,results)
end

function LuaUIComponent:BindUISubPanel(gameObject)
    return self.m_uiManager:CreateUISubPanel(gameObject)
end

function LuaUIComponent:BindUIUnit(gameObject,unitScript)
    return self.m_uiManager:CreateUIUnit(gameObject,unitScript)
end

function LuaUIComponent:OnHandleOpenUIForm(strUIConfig,userData,results)
    self:OpenUI(strUIConfig,userData,results)
end

function LuaUIComponent:OnHandleCloseUIForm(strUIConfig,userData,results)
    self:CloseUI(strUIConfig,userData,results)
end

function LuaUIComponent:Unspawn(gameObject)
    self.m_uiManager:Unspawn(gameObject)
end

return LuaUIComponent