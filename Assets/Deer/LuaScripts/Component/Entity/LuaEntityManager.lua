
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-09-08 07-08-39  
---修改作者 : 杜鑫 
---修改时间 : 2021-09-08 07-08-39  
---版 本 : 0.1 
---===============================================
---@class LuaEntityManager:SingletonClass 
LuaEntityManager = Class("LuaEntityManager",SingletonClass)

-- 变量定义
function LuaEntityManager:__init(...)
    self.m_listEntity = {}
    self:RegisterEvent()
end

function LuaEntityManager:__delete(...)
    self:UnRegisterEvent()
    for k, v in pairs(self.m_listEntity) do
        v:Delete()
    end
    self.m_listEntity = nil
end

function LuaEntityManager:RegisterEvent()
    self.m_onhandlegameentityshow = LuaGameEntry.LuaEvent:RegisterCSEvent(EventName.EVENT_CS_GAME_ENTITY_SHOW,self.OnHandleGameEntityShow,self)
    self.m_onhandlegameentityhide =  LuaGameEntry.LuaEvent:RegisterCSEvent(EventName.EVENT_CS_GAME_ENTITY_HIDE,self.OnHandleGameEntityHide,self)
end

function LuaEntityManager:UnRegisterEvent()
    LuaGameEntry.LuaEvent:UnRegisterCSEvent(EventName.EVENT_CS_GAME_ENTITY_SHOW,self.m_onhandlegameentityshow)
    LuaGameEntry.LuaEvent:UnRegisterCSEvent(EventName.EVENT_CS_GAME_ENTITY_HIDE,self.m_onhandlegameentityhide)
end

function LuaEntityManager:GetEntity(entityId)
    return self.m_listEntity[entityId] or nil
end

function LuaEntityManager:OnHandleGameEntityShow(csMessengerInfo)
    if not csMessengerInfo then
        return 0
    end
    local entityId = csMessengerInfo.param1
    ---@field EntityData
    local luaEntityData = csMessengerInfo.param2
    if not entityId then
        return 0
    end
    local csEntity = LuaGameEntry.LuaEntity:GetCSEntity(entityId)
    if not csEntity then
        return 0
    end
    if luaEntityData:GetEntityType() == EntityEnum.CharacterPlayer then
        if self.m_listEntity[entityId] then
            self.m_listEntity[entityId]:OnShow(entityId,csEntity,luaEntityData)
        else
            self.m_listEntity[entityId] = LuaCharacterPlayer.New()
            self.m_listEntity[entityId]:OnShow(entityId,csEntity,luaEntityData)
        end
    elseif luaEntityData:GetEntityType() == EntityEnum.CharacterPlayerNet then
        if self.m_listEntity[entityId] then
            self.m_listEntity[entityId]:OnShow(entityId,csEntity,luaEntityData)
        else
            self.m_listEntity[entityId] = LuaCharacterPlayerNet.New()
            self.m_listEntity[entityId]:OnShow(entityId,csEntity,luaEntityData)
        end

    end
end

function LuaEntityManager:OnHandleGameEntityHide(csMessengerInfo)
    if not csMessengerInfo then
        return 0
    end
    local entityId = csMessengerInfo.param1
    if not entityId then
        return 0
    end
    if self.m_listEntity[entityId] then
        self.m_listEntity[entityId]:OnHide()
    end
end

return LuaEntityManager