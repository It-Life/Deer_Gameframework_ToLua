
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-08-26 23-23-48  
---修改作者 : 杜鑫 
---修改时间 : 2021-08-26 23-23-48  
---版 本 : 0.1 
---===============================================
---@class LuaEntityComponent:LuaComponentBase
---@field m_serialId number @关于 EntityId 的约定： 0 为无效 正值用于和服务器通信的实体（如玩家角色、NPC、怪等，服务器只产生正值）负值用于本地生成的临时实体（如特效、FakeObject等）
---@field m_luaEntityManager LuaEntityManager
LuaEntityComponent = Class("LuaEntityComponent",LuaComponentBase)

function LuaEntityComponent:__init()
    self.m_luaEntityManager = LuaEntityManager:GetInstance()
    self.m_serialId = 0
end

function LuaEntityComponent:__delete()
    self.m_luaEntityManager:Delete()
end
---@return EntityLogicBase
function LuaEntityComponent:GetGameEntity(entityId)
    local entity = GameEntry.Entity:GetGameEntity(entityId)
    if entity == nil then
        return nil
    end
    return entity
end
---@param data CharacterData
function LuaEntityComponent:ShowCharacter(data)
    GameEntry.Entity:ShowEntity(typeof(CharacterPlayer),"Character",AssetPriority.RolePlayerAsset,data)
end

function LuaEntityComponent:HideEntity(entityId,data)
    GameEntry.Entity:HideEntity(entityId,data)
end

function LuaEntityComponent:GenerateSerialId()
    self.m_serialId = self.m_serialId - 1
    return self.m_serialId
end

return LuaEntityComponent