
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-09-08 07-50-34  
---修改作者 : 杜鑫 
---修改时间 : 2021-09-08 07-50-34  
---版 本 : 0.1 
---===============================================
---@class StateBase:BaseClass
---@field m_owner StateController
StateBase = Class("StateBase",BaseClass)

function StateBase:GetIsActive()
    return self.m_isActive
end

function StateBase:SetOwner(owner)
    self.m_owner = owner
end
---@return LuaCharacterBase
function StateBase:GetOwner()
    return self.m_owner
end
---@return CharacterStateEnum
function StateBase:GetStateEnum()
    return self.m_characterStateEnum
end

function StateBase:__init(owner,characterStateEnum)
    self.m_owner = owner
    self.m_isActive = false
    self.m_characterStateEnum = characterStateEnum
end

function StateBase:__delete()

end

function StateBase:OnEnter()
    self.m_isActive = true
end

function StateBase:OnExit()
    self.m_isActive = false
end

function StateBase:OnUpdate()

end

return StateBase