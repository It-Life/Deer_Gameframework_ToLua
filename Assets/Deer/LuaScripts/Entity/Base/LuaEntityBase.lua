
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-09-08 07-50-34  
---修改作者 : 杜鑫 
---修改时间 : 2021-09-08 07-50-34  
---版 本 : 0.1 
---===============================================
---@class LuaEntityBase:BaseClass
LuaEntityBase = Class("LuaEntityBase",BaseClass)

function LuaEntityBase:__init(...)
    self.m_csEntity = nil
    self.m_entityId = 0
    self.m_luaEntityData = nil
    self.m_isValid = false
end

function LuaEntityBase:__delete(...)
    self.m_csEntity = nil
    self.m_entityId = nil
end

function LuaEntityBase:SetEntityId(entityId)
    self.m_entityId = entityId
end
function LuaEntityBase:GetEntityId()
    return self.m_entityId
end

function LuaEntityBase:SetCsEntity(csEntity)
    self.m_csEntity = csEntity
end
---@param csEntity Character
function LuaEntityBase:GetCsEntity()
    return self.m_csEntity
end

function LuaEntityBase:GetLuaEntityData()
    return self.m_luaEntityData
end

function LuaEntityBase:Valid()
    return self.m_isValid
end

---@param entityId number
---@param csEntity EntityLogicBase
---@param luaEntityData EntityDataBase
function LuaEntityBase:OnShow(entityId,csEntity,luaEntityData)
    self.m_isValid = true
    self.m_csEntity = csEntity
    self.m_entityId = entityId
    self.m_luaEntityData = luaEntityData
    if csEntity then
        csEntity.m_LuaData = luaEntityData
        csEntity:InitLuaTable(self)
        csEntity.CachedTransform.name = string.format("Entity %s",self.m_entityId)
        csEntity.CachedTransform.localPosition = luaEntityData:GetPosition();
    end
end

function LuaEntityBase:OnHide()
    self.m_isValid = false
    self.m_csEntity = nil
    self.m_entityId = nil
    self.m_luaEntityData = nil
    self:Delete()
end
---@param physicsEnum PhysicsEnum
function LuaEntityBase:OnCollision(physicsEnum,gameObject)
    Logger.Info(""..physicsEnum)
end

function LuaEntityBase:OnTrigger(physicsEnum,gameObject)

end

return LuaEntityBase