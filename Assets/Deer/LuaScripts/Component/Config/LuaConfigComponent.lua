
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-24 16-27-08  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-24 16-27-08  
---版 本 : 0.1 
---===============================================
---@class LuaConfigComponent:LuaComponentBase
---@field m_LuaConfigManager LuaConfigManager
LuaConfigComponent = Class("LuaConfigComponent",LuaComponentBase)

function LuaConfigComponent:__init()
    self.m_LuaConfigManager = LuaConfigManager:GetInstance()
    self:LoadAllUserConfig()
end

function LuaConfigComponent:__delete()
end

function LuaConfigComponent:LoadAllUserConfig()
    self.m_LuaConfigManager:LoadAllUserConfig()
end

return LuaConfigComponent