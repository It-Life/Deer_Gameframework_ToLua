
---================================================
---描 述 :  所有lua单利东西写这里统一调用
---作 者 : 杜鑫 
---创建时间 : 2022-01-01 00-05-08 
---修改作者 : 杜鑫 
---修改时间 : 2022-01-01 00-05-08 
---版 本 : 0.1 
---===============================================

---@class LuaGameConfig
LuaGameConfig = {}
---@return DataConfigLanguageInfo
function LuaGameConfig:GetLanguageConfig()
    return DataConfigLanguageInfo:GetInstance()
end

LuaGameConfig.Language = LuaGameConfig:GetLanguageConfig()
