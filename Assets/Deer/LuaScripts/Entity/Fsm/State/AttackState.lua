
---================================================
---描 述 :  
---作 者 : ShiKaiLong 
---创建时间 : 2022-04-27 14-26-34  
---修改作者 : ShiKaiLong 
---修改时间 : 2022-04-27 14-26-34  
---版 本 : 0.1 
---===============================================
------@class AttackState:StateBase
AttackState = Class("AttackState",StateBase)
function AttackState:OnEnter()
    self.super.OnEnter(self)
    --修改动画
    self:GetOwner():GetAnimator():CrossFade("Attack",0.1)
end

function AttackState:OnExit()
    self.super.OnExit(self)
end

function AttackState:OnUpdate()
    self.super.OnUpdate(self)
    local stateInfo = self:GetOwner():GetAnimator():GetCurrentAnimatorStateInfo(0)
    local playingJump = stateInfo:IsName("Attack")
    if playingJump then
        if stateInfo.normalizedTime >= 1 then
            self:GetOwner():GetStateController():OnChangeState(CharacterStateEnum.IdleState)
        end
    end

end
return AttackState