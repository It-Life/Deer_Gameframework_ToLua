
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-09-08 07-50-34  
---修改作者 : 杜鑫 
---修改时间 : 2021-09-08 07-50-34  
---版 本 : 0.1 
---===============================================
---@class JumpState:StateBase
JumpState = Class("JumpState",StateBase)

function JumpState:OnEnter()
    self.super.OnEnter(self)
    self.m_curMoveMode = MoveMode.Jump
    --修改动画
    self:GetOwner():GetAnimator():CrossFade("Jump",0.1)
--[[    if self:GetOwner():GetMoveMode() == MoveMode.Jump then
    else
        self:GetOwner():GetAnimator():CrossFade("Jump_NoBlade",0.1)
        self.m_curMoveMode = MoveMode.JumpRun
    end]]
end

function JumpState:OnExit()
    self.super.OnExit(self)
end

function JumpState:OnUpdate()
    self.super.OnUpdate(self)
    local stateInfo = self:GetOwner():GetAnimator():GetCurrentAnimatorStateInfo(0)
    local playingJump = stateInfo:IsName("Jump")
    if playingJump then
        if stateInfo.normalizedTime >= 1 then
            self:GetOwner():GetStateController():OnChangeState(CharacterStateEnum.IdleState)
        end
    end
end

return JumpState