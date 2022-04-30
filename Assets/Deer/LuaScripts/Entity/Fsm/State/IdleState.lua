
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-09-08 07-50-34  
---修改作者 : 杜鑫 
---修改时间 : 2021-09-08 07-50-34  
---版 本 : 0.1 
---===============================================
---@class IdleState:StateBase
IdleState = Class("IdleState",StateBase)

function IdleState:OnEnter()
    self.super.OnEnter(self)
    --修改动画
    --self:GetOwner():GetOwner():GetAnimator():Play("Idle")
    self:GetOwner():GetAnimator():CrossFade("Idle",0.1)
    
end

function IdleState:OnExit()
    self.super.OnExit(self)
end

function IdleState:OnUpdate()
    self.super.OnUpdate(self)

end

return IdleState