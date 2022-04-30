
---================================================
---描 述 :  
---作 者 : ShiKaiLong 
---创建时间 : 2022-04-26 15-41-05  
---修改作者 : ShiKaiLong 
---修改时间 : 2022-04-26 15-41-05  
---版 本 : 0.1 
---===============================================
---@class DeathState:StateBase
DeathState = Class("DeathState",StateBase)
function DeathState:OnEnter()
    self.super.OnEnter(self)
    --修改动画
    --self:GetOwner():GetOwner():GetAnimator():Play("Idle")
    self:GetOwner():GetAnimator():CrossFade("Death",0.1)
end

function DeathState:OnExit()
    self.super.OnExit(self)
end

function DeathState:OnUpdate()
    self.super.OnUpdate(self)
    local stateInfo = self:GetOwner():GetAnimator():GetCurrentAnimatorStateInfo(0)
    local playingJump = stateInfo:IsName("Death")
    if playingJump then
        if stateInfo.normalizedTime >= 1 then
            local entityId = self:GetOwner():GetEntityId()
            Logger.Debug("entityId "..entityId)
            --LuaGameEntry.LuaEntity:HideEntity(entityId)
            LuaGameEntry.LuaEvent:SendLuaEvent(EventId.EVENT_LUA_PLAYER_EXIT,entityId)
        end
    end

end
return DeathState