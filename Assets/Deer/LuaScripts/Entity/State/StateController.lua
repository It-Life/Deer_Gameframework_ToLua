
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-09-08 07-50-34  
---修改作者 : 杜鑫 
---修改时间 : 2021-09-08 07-50-34  
---版 本 : 0.1 
---===============================================
---@class StateController:BaseClass
---@field m_owner LuaCharacterBase
---@field s_currState StateBase
---@field s_moveState MoveState
---@field s_idleState IdleState
---@field s_jumpState JumpState
StateController = Class("StateController",BaseClass)
--{{{ property
function StateController:SetOwner(owner)
    self.m_owner = owner
end
---@return LuaCharacterBase
function StateController:GetOwner()
    return self.m_owner
end

---@return StateBase
function StateController:GetCurrState()
    return self.s_currState
end

--}}}

function StateController:__init(owner)
    self.m_owner = owner
    self.s_currState = nil
    self.s_dicState = {}
    self.s_moveState = MoveState.New(self:GetOwner(),CharacterStateEnum.MoveState)
    self.s_dicState[CharacterStateEnum.MoveState] = self.s_moveState
    self.s_idleState = IdleState.New(self:GetOwner(),CharacterStateEnum.IdleState)
    self.s_dicState[CharacterStateEnum.IdleState] = self.s_idleState
    self.s_jumpState = JumpState.New(self:GetOwner(),CharacterStateEnum.JumpState)
    self.s_dicState[CharacterStateEnum.JumpState] = self.s_jumpState
    self:OnChangeState(CharacterStateEnum.IdleState)
end
function StateController:__delete()
    for k, v in pairs(self.s_dicState) do
        v:Delete()
    end
end

function StateController:OnUpdate()
    if self.s_currState then
        self.s_currState:OnUpdate()
    end
end
---@param characterStateEnum CharacterStateEnum
function StateController:OnChangeState(characterStateEnum)
    if self.s_currState then
        if self.s_currState:GetStateEnum() == characterStateEnum then
            return
        end
        self.s_currState:OnExit()
    end
    if not self.s_dicState[characterStateEnum] then
        Logger.Error("want change state is nil")
        return
    end
    self.s_currState = self.s_dicState[characterStateEnum]
    self.s_currState:OnEnter()
end
---是否在状态中
---@param characterStateEnum CharacterStateEnum
---@return boolean
function StateController:IsInState(characterStateEnum)
    if characterStateEnum == self:GetCurrState():GetStateEnum() then
        return true
    end
    return false
end

return StateController