
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-09-08 07-50-34  
---修改作者 : 杜鑫 
---修改时间 : 2021-09-08 07-50-34  
---版 本 : 0.1 
---===============================================
---@class EntityDataBase
EntityDataBase = Class("EntityDataBase")

function EntityDataBase:__init()
    self.m_id = 0
    self.m_entityType = EntityEnum.Normal
    self.m_assetName=""
    self.m_position = Vector3(0,0,0)
end

function EntityDataBase:__delete()
    self.m_id = nil
    self.m_entityType = nil
    self.m_assetName = nil
    self.m_position = nil
end

function EntityDataBase:GetId()
    return self.m_id
end


function EntityDataBase:SetId(value)
    self.m_id = value
end

function EntityDataBase:GetEntityType()
    return self.m_entityType
end

function EntityDataBase:SetEntityType(entityType)
    self.m_entityType = entityType
end


function EntityDataBase:GetAssetName()
    return self.m_assetName
end


function EntityDataBase:SetAssetName(value)
    self.m_assetName = value
end

function EntityDataBase:GetPosition()
    return self.m_position
end


function EntityDataBase:SetPosition(x,y,z)
    self.m_position = Vector3(x,y,z)
end

function EntityDataBase:SetPositionByPos(pos)
    self.m_position = pos
end


return EntityDataBase