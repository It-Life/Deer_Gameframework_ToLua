
---================================================
---描 述 :  
---作 者 : ShiKaiLong 
---创建时间 : 2022-04-25 16-49-21  
---修改作者 : ShiKaiLong 
---修改时间 : 2022-04-25 16-49-21  
---版 本 : 0.1 
---===============================================
---@class LuaCharacterPlayerNet : LuaCharacterBase
---@field m_stateController StateController
---@field m_characterPlayerData CharacterPlayerData
LuaCharacterPlayerNet = Class("LuaCharacterPlayerNet",LuaCharacterBase)
--{{{ property
---@return CharacterPlayerData
function LuaCharacterPlayerNet:GetData()
    return self.m_characterData
end

--}}}
---构造函数
function LuaCharacterPlayerNet:__init(...)
    self.m_isJoyStickControl = false
    self:RegisterLuaEvent()
end
---构造函数
function LuaCharacterPlayerNet:__delete(...)
    self:UnRegisterLuaEvent()
end

function LuaCharacterPlayerNet:RegisterLuaEvent()
    self._onhandlemovedirectioncallback = LuaGameEntry.LuaEvent:RegisterLuaEvent(EventId.EVENT_LUA_GAME_MOVE_DIRECTION, self.OnHandleMoveDirectionCallback,self)
    self._onhandlemoveendcallback = LuaGameEntry.LuaEvent:RegisterLuaEvent(EventId.EVENT_LUA_GAME_MOVE_END,self.OnHandleMoveEndCallback,self)
    self._onhandlejumpcallback = LuaGameEntry.LuaEvent:RegisterLuaEvent(EventId.EVENT_LUA_GAME_START_JUMP,self.OnHandleJumpCallback,self)
    self._onhandlejumpcallback = LuaGameEntry.LuaEvent:RegisterLuaEvent(EventId.EVENT_LUA_GAME_DEATH,self.OnHandleDeathCallBack,self)
end

function LuaCharacterPlayerNet:UnRegisterLuaEvent()
    LuaGameEntry.LuaEvent:UnRegisterLuaEvent(EventId.EVENT_LUA_GAME_MOVE_DIRECTION,self._onhandlemovedirectioncallback)
    LuaGameEntry.LuaEvent:UnRegisterLuaEvent(EventId.EVENT_LUA_GAME_MOVE_END,self._onhandlemoveendcallback)
    LuaGameEntry.LuaEvent:UnRegisterLuaEvent(EventId.EVENT_LUA_GAME_START_JUMP,self._onhandlejumpcallback)
    LuaGameEntry.LuaEvent:UnRegisterLuaEvent(EventId.EVENT_LUA_GAME_DEATH,self._onhandlejumpcallback)
end
---@param csEntity CharacterPlayer
---@param csEntityData EntityData
function LuaCharacterPlayerNet:OnShow(entityId,csEntity,csEntityData)
    self.super.OnShow(self,entityId,csEntity,csEntityData)
    Logger.Debug("LuaCharacterPlayerNet   entityId  " ..entityId)
    self.m_csEntity = csEntity
    self.m_entityId = entityId
    self.m_isMoveing = false
    if csEntityData then
        self.m_isPlayerSelf = csEntityData.IsOwner
        if self.m_isPlayerSelf then
            local transCamTarget = csEntity.CachedTransform:Find("CamTaget")
            GameEntry.Camera:FollowAndLookAtTarget(csEntity.CachedTransform,transCamTarget)
        end
        csEntity.CachedTransform.localPosition = csEntityData.Position;
    end
    local characterController = csEntity.CachedTransform:GetComponent(typeof(UnityEngine.CharacterController))
    self.m_luaCharacterManager = LuaCharacterManager.New(self,characterController)
    self.m_animator = csEntity.CachedTransform:Find("Model"):GetComponent(typeof(UnityEngine.Animator))
    self.m_characterData = CharacterPlayerData.New()
    self.m_stateController = StateController.New(self)

    csEntity.CachedTransform.name = string.format("Entity %s",self.m_entityId)

    self.m_updateEvent = LuaGameEntry.LuaUpdate:AddUpdate(self.Update,self)
end

function LuaCharacterPlayerNet:OnHide()
    self.super.OnHide(self)
    self:UnRegisterLuaEvent()
    GameEntry.Camera:FollowAndLookAtTarget(nil,nil)
    LuaGameEntry.LuaUpdate:RemoveUpdate(self.m_updateEvent)
    self.m_luaCharacterManager:Delete()
    self.m_luaCharacterManager = nil
    self.m_characterData:Delete()
    self.m_characterData = nil
    self.m_stateController:Delete()
    self.m_stateController = nil
end

function LuaCharacterPlayerNet:Update()
    if self.m_luaCharacterManager then
        self.m_luaCharacterManager:OnUpdate()
    end
    if self.m_stateController then
        self.m_stateController:OnUpdate()
    end
end

---开始移动
function LuaCharacterPlayerNet:OnHandleMoveDirectionCallback(messageInfo,bIsJoyStickControl)
    local direction = Vector2(messageInfo.param1,messageInfo.param2)
    Logger.Debug("messageInfo.param1   " ..messageInfo.param1 ..  "messageInfo.param2 "..messageInfo.param2)
    self.m_isJoyStickControl = bIsJoyStickControl
    Logger.Debug(bIsJoyStickControl)
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
function LuaCharacterPlayerNet:OnHandleMoveEndCallback(bIsJoyStickControl)
    self.m_isJoyStickControl = false
    self.m_JoyStickDirection = Vector3.zero
    self.m_stateController:OnChangeState(CharacterStateEnum.IdleState)
end
---跳跃
function LuaCharacterPlayerNet:OnHandleJumpCallback()
    self:SetMoveMode(self:GetMoveMode() == MoveMode.ForwardRun and MoveMode.JumpRun or MoveMode.Jump)
    self:GetLuaCharacterManager():SetCharacterGravitySpeed(self:GetData():GetJumpPower())
    self:GetStateController():OnChangeState(CharacterStateEnum.JumpState)
end

---死亡
function LuaCharacterPlayerNet: OnHandleDeathCallBack()
    self:GetStateController():OnChangeState(CharacterStateEnum.DeathState)
end
return LuaCharacterPlayerNet