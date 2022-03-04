
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
end

function LuaUIComponent:__delete()
    self.m_uiManager:Delete()
end

---@param uiName UINameConfig
---@param tbShowUIInfo table enumGroup[option] UIFormGroupType,
function LuaUIComponent:CreateUI(uiName,tbShowUIInfo)
    self.m_uiManager:CreateForm(uiName,tbShowUIInfo)
end

function LuaUIComponent:CloseUI(uiName)
    self.m_uiManager:CloseForm(uiName)
end

function LuaUIComponent:BindUIUnit(gameObject,unitScript)
    return self.m_uiManager:BindUIUnit(gameObject,unitScript)
end

return LuaUIComponent