
---================================================
---描 述 :  所有lua单利东西写这里统一调用
---作 者 : 杜鑫 
---创建时间 : 2021-07-12 00-05-08  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-12 00-05-08  
---版 本 : 0.1 
---===============================================
---@class LuaGameEntry
LuaGameEntry = {}

---@return LuaUIComponent
function LuaGameEntry:GetUIComponent()
    return LuaUIComponent:GetInstance()
end

---@return LuaConfigComponent
function LuaGameEntry:GetLuaConfigComponent()
    return LuaConfigComponent:GetInstance()
end

---@return LuaTPSpriteComponent
function LuaGameEntry:GetTPSpriteComponent()
    return LuaTPSpriteComponent:GetInstance()
end

---@return LuaProcedureComponent
function LuaGameEntry:GetProcedureComponent()
    return LuaProcedureComponent:GetInstance()
end

---@return LocalPrefComponent
function LuaGameEntry:GetLocalPrefComponent()
    return LocalPrefComponent:GetInstance()
end

---@return LuaEventComponent
function LuaGameEntry:GetLuaEventComponent()
    return LuaEventComponent:GetInstance()
end

---@return LuaEntityComponent
function LuaGameEntry:GetLuaEntityComponent()
    return LuaEntityComponent:GetInstance()
end

---@return NetWorkComponent
function LuaGameEntry:GetNetWorkComponent()
    return NetWorkComponent:GetInstance()
end

---@return LuaUpdateComponent
function LuaGameEntry:GetLuaUpdateComponent()
    return LuaUpdateComponent:GetInstance()
end

---@return LuaSoundComponent
function LuaGameEntry:GetLuaSoundComponent()
    return LuaSoundComponent:GetInstance()
end

---@return LuaSceneComponent
function LuaGameEntry:GetLuaSceneComponent()
    return LuaSceneComponent:GetInstance()
end


LuaGameEntry.UI = LuaGameEntry:GetUIComponent()
LuaGameEntry.DataConfig = LuaGameEntry:GetLuaConfigComponent()
LuaGameEntry.TPSprite = LuaGameEntry:GetTPSpriteComponent()
LuaGameEntry.Procedure = LuaGameEntry:GetProcedureComponent()
LuaGameEntry.LocalPref = LuaGameEntry:GetLocalPrefComponent()
LuaGameEntry.LuaEvent = LuaGameEntry:GetLuaEventComponent()
LuaGameEntry.LuaEntity = LuaGameEntry:GetLuaEntityComponent()
LuaGameEntry.NetWork = LuaGameEntry:GetNetWorkComponent()
LuaGameEntry.LuaUpdate = LuaGameEntry:GetLuaUpdateComponent()
LuaGameEntry.LuaSound = LuaGameEntry:GetLuaSoundComponent()
LuaGameEntry.LuaScene = LuaGameEntry:GetLuaSceneComponent()

function LuaGameEntry:Cleanup()
    LuaGameEntry.UI:Delete()
    LuaGameEntry.DataConfig:Delete()
    LuaGameEntry.TPSprite:Delete()
    LuaGameEntry.Procedure:Delete()
    LuaGameEntry.LocalPref:Delete()
    LuaGameEntry.LuaEntity:Delete()
    LuaGameEntry.NetWork:Delete()
    LuaGameEntry.LuaUpdate:Delete()
    LuaGameEntry.LuaSound:Delete()
    LuaGameEntry.LuaScene:Delete()
    ---事件最后清理
    LuaGameEntry.LuaEvent:Delete()
end

return LuaGameEntry