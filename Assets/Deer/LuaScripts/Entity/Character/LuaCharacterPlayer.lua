
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-09-08 07-50-34  
---修改作者 : 杜鑫 
---修改时间 : 2021-09-08 07-50-34  
---版 本 : 0.1 
---===============================================
---@class LuaCharacterPlayer : LuaCharacterBase
---@field m_stateController StateController
---@field m_characterPlayerData CharacterPlayerData
LuaCharacterPlayer = Class("LuaCharacterPlayer",LuaCharacterBase)
--{{{ property 
---@return CharacterPlayerData
function LuaCharacterPlayer:GetData()
    return self.m_characterData
end

--}}}
---构造函数
function LuaCharacterPlayer:__init(...)
    self.m_isJoyStickControl = false
    self:RegisterLuaEvent()
end
---构造函数
function LuaCharacterPlayer:__delete(...)
    self:UnRegisterLuaEvent()
end

function LuaCharacterPlayer:RegisterLuaEvent()
    self._onhandlemovedirectioncallback = LuaGameEntry.LuaEvent:RegisterLuaEvent(EventId.EVENT_LUA_GAME_MOVE_DIRECTION, self.OnHandleMoveDirectionCallback,self)
    self._onhandlemoveendcallback = LuaGameEntry.LuaEvent:RegisterLuaEvent(EventId.EVENT_LUA_GAME_MOVE_END,self.OnHandleMoveEndCallback,self)
    self._onhandlejumpcallback = LuaGameEntry.LuaEvent:RegisterLuaEvent(EventId.EVENT_LUA_GAME_START_JUMP,self.OnHandleJumpCallback,self)
end

function LuaCharacterPlayer:UnRegisterLuaEvent()
    LuaGameEntry.LuaEvent:UnRegisterLuaEvent(EventId.EVENT_LUA_GAME_MOVE_DIRECTION,self._onhandlemovedirectioncallback)
    LuaGameEntry.LuaEvent:UnRegisterLuaEvent(EventId.EVENT_LUA_GAME_MOVE_END,self._onhandlemoveendcallback)
    LuaGameEntry.LuaEvent:UnRegisterLuaEvent(EventId.EVENT_LUA_GAME_START_JUMP,self._onhandlejumpcallback)
end
---@param csEntity CharacterPlayer
---@param luaEntityData CharacterPlayerData
function LuaCharacterPlayer:OnShow(entityId,csEntity,luaEntityData)
    self.super.OnShow(self,entityId,csEntity,luaEntityData)
    self.m_csEntity = csEntity
    self.m_entityId = entityId
    self.m_isMoveing = false
    if luaEntityData then
        self.m_isPlayerSelf = luaEntityData:GetIsOwner()
        if self.m_isPlayerSelf then
            local transCamTarget = csEntity.CachedTransform:Find("CamTaget")
            GameEntry.Camera:FollowAndFreeViewTarget(csEntity.CachedTransform,transCamTarget)
        end
        csEntity.CachedTransform.localPosition = luaEntityData:GetPosition();
    end
    self.m_animator = csEntity.CachedTransform:Find("Model"):GetComponent(typeof(UnityEngine.Animator))
    self.m_characterData = luaEntityData
    self.m_stateController = StateController.New(self)
    self.m_updateEvent = LuaGameEntry.LuaUpdate:AddUpdate(self.Update,self)
end

function LuaCharacterPlayer:OnHide()
    self.super.OnHide(self)
    self:UnRegisterLuaEvent()
    GameEntry.Camera:FollowAndFreeViewTarget(nil,nil)

    LuaGameEntry.LuaUpdate:RemoveUpdate(self.m_updateEvent)
    self.m_luaCharacterManager:Delete()
    self.m_luaCharacterManager = nil
    self.m_characterData:Delete()
    self.m_characterData = nil
    self.m_stateController:Delete()
    self.m_stateController = nil
end

function LuaCharacterPlayer:Update()
    if self.m_luaCharacterManager then
        self.m_luaCharacterManager:OnUpdate()
    end
    if self.m_stateController then
        self.m_stateController:OnUpdate()
    end
    if not self:IsPlayerSelf() then
        return nil
    end
    if Input.GetAxisRaw("Horizontal") ~= 0 or Input.GetAxisRaw("Vertical") ~= 0 then
        self.m_isMoveing = true
        LuaGameEntry.LuaEvent:SendLuaEvent(EventId.EVENT_LUA_GAME_MOVE_DIRECTION,{param1 = Input.GetAxisRaw("Horizontal"),param2 = Input.GetAxisRaw("Vertical")})
    else
        if self.m_isMoveing then
            self:OnHandleMoveEndCallback()
            self.m_isMoveing = false
        end
    end
    if Input.GetKeyDown(KeyCode.Space) then
        self:OnHandleJumpCallback()
    end
    if Input.GetKeyDown(KeyCode.H) then
        self:OnHandleDeathCallBack()
    end
end

---开始移动
function LuaCharacterPlayer:OnHandleMoveDirectionCallback(messageInfo,bIsJoyStickControl)
    if not self:IsPlayerSelf() then
        return nil
    end
    local direction = Vector2(messageInfo.param1,messageInfo.param2)
    self.m_isJoyStickControl = bIsJoyStickControl
    self:SetMoveMode(direction.magnitude >= 0.9 and MoveMode.ForwardRun or MoveMode.Forward)
    self.m_JoyStickDirection = GObjUtils.GetFrezzeModeDirection(direction.x, direction.y)
    if not self:GetStateController():IsInState(CharacterStateEnum.JumpState) then
        self.m_stateController:OnChangeState(CharacterStateEnum.MoveState)
    end
    if self:GetData():IsJumpCanMove() then
        self:GetLuaCharacterManager():OnMove()
    end
end
---移动结束
function LuaCharacterPlayer:OnHandleMoveEndCallback(bIsJoyStickControl)
    if not self:IsPlayerSelf() then
        return nil
    end
    if self.m_isJoyStickControl then
        if not bIsJoyStickControl then
            return
        end
    end
    self.m_isJoyStickControl = false
    self.m_JoyStickDirection = Vector3.zero
    self.m_stateController:OnChangeState(CharacterStateEnum.IdleState)
end
---跳跃
function LuaCharacterPlayer:OnHandleJumpCallback()
    if not self:CanJump() then
        return nil
    end
    self:SetMoveMode(self:GetMoveMode() == MoveMode.ForwardRun and MoveMode.JumpRun or MoveMode.Jump)
    self:GetLuaCharacterManager():SetCharacterGravitySpeed(self:GetData():GetJumpPower())
    self:GetStateController():OnChangeState(CharacterStateEnum.JumpState)

    LuaGameEntry.LuaEvent:SendLuaEvent(EventId.EVENT_LUA_GAME_START_JUMP)
end

---死亡
function LuaCharacterPlayer : OnHandleDeathCallBack()
    self:GetStateController():OnChangeState(CharacterStateEnum.DeathState)
    LuaGameEntry.LuaEvent:SendLuaEvent(EventId.EVENT_LUA_GAME_DEATH)
end

return LuaCharacterPlayer