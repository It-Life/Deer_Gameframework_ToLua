
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

---@param entityId number
---@param csEntity EntityLogicBase
---@param luaEntityData EntityDataBase
function LuaEntityBase:OnShow(entityId,csEntity,luaEntityData)
    self.m_csEntity = csEntity
    self.m_entityId = entityId
    self.m_luaEntityData = luaEntityData
    if csEntity then
        csEntity.CachedTransform.name = string.format("Entity %s",self.m_entityId)
    end
end

function LuaEntityBase:OnHide()

end

return LuaEntityBase