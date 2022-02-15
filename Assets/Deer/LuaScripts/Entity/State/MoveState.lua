
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-09-08 07-50-34  
---修改作者 : 杜鑫 
---修改时间 : 2021-09-08 07-50-34  
---版 本 : 0.1 
---===============================================
---@class MoveState:StateBase
MoveState = Class("MoveState",StateBase)

function MoveState:OnEnter()
    self.super.OnEnter(self)
    self.m_currMoveState = MoveMode.Forward
    self.m_currMoveSpeed = 0
    --self:GetOwner():GetOwner():GetAnimator():Play("Walk")
    self:GetOwner():GetAnimator():CrossFade("Walk",0.1)
    Logger.Debug("Onenenenenenen")
end

function MoveState:OnExit()
    self.super.OnExit(self)

end

function MoveState:OnUpdate()
    self.super.OnUpdate(self)
    if self:GetOwner():IsPlayerSelf() then
        if self.m_currMoveState ~= self:GetOwner():GetMoveMode() then
            if self.m_currMoveState == MoveMode.Forward then
                Logger.Debug("eeeeeeeeeeeeeee")
                self:GetOwner():GetAnimator():CrossFade("Run",0.1)
            else
                Logger.Debug("aaaaaaaaaaaaaa")
                self:GetOwner():GetAnimator():CrossFade("Walk",0.1)
            end
            self.m_currMoveState = self:GetOwner():GetMoveMode()
        end
        if not self:GetOwner():GetData():IsJumpCanMove() then
            self:GetOwner():GetLuaCharacterManager():OnMove()
        end
    end
end

function MoveState:CheckCurrMoveState()
    
end

return MoveState