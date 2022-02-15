
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-09-08 07-50-34  
---修改作者 : 杜鑫 
---修改时间 : 2021-09-08 07-50-34  
---版 本 : 0.1 
---===============================================
---@class LuaCharacterBase:LuaEntityBase
---@field m_entityId number
---@field m_csEntity CharacterPlayer
---@field m_animator UnityEngine.Animator
LuaCharacterBase = Class("LuaCharacterBase",LuaEntityBase)

function LuaCharacterBase:SetOwner(owner)
    self.m_owner = owner
end

function LuaCharacterBase:GetOwner()
    return self.m_owner
end
---@param moveMode MoveMode
function LuaCharacterBase:SetMoveMode(moveMode)
    self.m_moveMode = moveMode
end
---@return MoveMode
function LuaCharacterBase:GetMoveMode()
    return self.m_moveMode
end

function LuaCharacterBase:SetEntityId(entityId)
    self.m_entityId = entityId
end
function LuaCharacterBase:GetEntityId()
    return self.m_entityId
end
function LuaCharacterBase:SetCsEntity(csEntity)
    self.m_csEntity = csEntity
end
---@param csEntity Character
function LuaCharacterBase:GetCsEntity()
    return self.m_csEntity
end
---@return EntityEnum
function LuaCharacterBase:GetEntityType()
    return csEntity.EntityType
end
---@return UnityEngine.Animator
function LuaCharacterBase:GetAnimator()
    return self.m_animator
end

---@return CharacterDataBase
function LuaCharacterBase:GetData()
    return self.m_characterData
end

---@return UnityEngine.Vector3
function LuaCharacterBase:GetJoyStickDirection()
    return self.m_JoyStickDirection
end

---@return LuaCharacterManager
function LuaCharacterBase:GetLuaCharacterManager()
    return self.m_luaCharacterManager
end

---@return StateController
function LuaCharacterBase:GetStateController()
    return self.m_stateController
end

function LuaCharacterBase:IsPlayerSelf()
    return self.m_isPlayerSelf
end

function LuaCharacterBase:__init()
    self.m_owner = nil
    self.m_isPlayerSelf = true
    self.m_EntityId = 0
    self.m_csEntity = nil
    self.m_animator = nil
    self.m_stateController = nil
    self.m_characterData = nil
    self.m_luaCharacterManager = nil
    self.m_moveMode = MoveMode.Forward
    self.m_JoyStickDirection = Vector3.zero
end

function LuaCharacterBase:__delete()

end

function LuaCharacterBase:ForceSetToDir(vec3Dir)
    self:GetCsEntity().CachedTransform.rotation = Quaternion.LookRotation(vec3Dir);
end

function LuaCharacterBase:SetToDir(vec3Dir)
    if vec3Dir == Vector3.zero then
        return
    end
    if vec3Dir.magnitude > 0 then
        local freeRotation = Quaternion.LookRotation(vec3Dir);
        local diferenceRotation = freeRotation.eulerAngles.y - self:GetCsEntity().CachedTransform.eulerAngles.y
        local eulerY = self:GetCsEntity().CachedTransform.eulerAngles.y
        if diferenceRotation < 0 or diferenceRotation > 0 then
            eulerY = freeRotation.eulerAngles.y
        end
        local euler = Vector3(0, eulerY, 0)
        self:GetCsEntity().CachedTransform.rotation = Quaternion.Slerp(self:GetCsEntity().CachedTransform.rotation, Quaternion.Euler(euler), Time.deltaTime * self:GetData():GetTurnSpeed());
    end
end
---@return boolean
function LuaCharacterBase:CanJump()
    if not self:GetLuaCharacterManager():IsInGround() then
        return false
    end
    if self:GetStateController():IsInState(CharacterStateEnum.JumpState) then
        return false
    end
    if self:GetStateController():IsInState(CharacterStateEnum.IdleState) 
            or self:GetStateController():IsInState(CharacterStateEnum.MoveState)
    then
        return true
    end
    return false
end


return LuaCharacterBase