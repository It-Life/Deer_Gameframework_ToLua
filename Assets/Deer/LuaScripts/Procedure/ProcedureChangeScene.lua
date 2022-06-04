
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-08-13 08-09-28  
---修改作者 : 杜鑫 
---修改时间 : 2021-08-13 08-09-28  
---版 本 : 0.1 
---===============================================
---@class ProcedureChangeScene :ProcedureBase
ProcedureChangeScene = Class("ProcedureChangeScene",ProcedureBase)

function ProcedureChangeScene:OnEnter(csProcedure)
    self.super.OnEnter(self,csProcedure)
    self.csProcedure = csProcedure
    self.m_nextProcedureName = LuaGameEntry.Procedure:GetNextLuaProcedure()
    if not self.m_nextProcedureName then
        Logger.Error("nextProcedureName is nil")
    end
    self.m_LoadingProgress = 0
    self.m_IsChangeSceneComplete = false
    --维护一个计时器
    self.funUpdate = LuaGameEntry.LuaUpdate:AddUpdate(self.Update,self)
    self:RegisterEvent()
    LuaGameEntry.UI:OpenUI(UINameConfig.UILoadingPanel,nil,function(result)
        if result then
            self:OnStartLoadScene()
        end
    end)
end

function ProcedureChangeScene:OnLeave()
    self.super.OnLeave(self)
    self:UnRegisterEvent()
    LuaGameEntry.LuaUpdate:RemoveUpdate(self.funUpdate)
end

function ProcedureChangeScene:Update()
    if UnityEngine.Application.isEditor then
        self.m_LoadingProgress = self.m_LoadingProgress + 1
        self.m_LoadingProgress = Mathf.Clamp(self.m_LoadingProgress, 10, 100);
        if self.m_LoadingProgress < 100 then
            if not self.m_IsChangeSceneComplete then
                self.m_LoadingProgress = Mathf.Clamp(self.m_LoadingProgress, 10, 90);
            end
            --发送进度
            self:SendLuaEvent(EventId.EVENT_LUA_LOAD_SCENE_PROGRESS,self.m_LoadingProgress/100)
            return
        else
            self:SendLuaEvent(EventId.EVENT_LUA_LOAD_SCENE_SUCCESS)
            LuaGameEntry.Procedure:OnChangeLuaProcedure(self.m_nextProcedureName)
        end
    end
end

function ProcedureChangeScene:RegisterEvent()
    self.m_funLoadSceneSuccessEvent = BindCallback(self.OnHandleLoadSceneSuccess, self);
    self.m_funLoadSceneFailureEvent = BindCallback(self.OnHandleLoadSceneFailure, self);
    self.m_funLoadSceneUpdateEvent = BindCallback(self.OnHandleLoadSceneUpdate, self);
    self.m_funLoadSceneDependencyAssetEvent = BindCallback(self.OnHandleLoadSceneDependencyAsset, self);
    self.m_funcUnloadSceneSuccessEvent = BindCallback(self.OnHandleUnloadSceneSuccess, self);
    self.m_funUnloadSceneFailureEvent = BindCallback(self.OnHandleUnloadSceneFailure, self);
    GameEntry.Event:Subscribe(LoadSceneSuccessEventArgs.EventId, self.m_funLoadSceneSuccessEvent)
    GameEntry.Event:Subscribe(LoadSceneFailureEventArgs.EventId, self.m_funLoadSceneFailureEvent)
    GameEntry.Event:Subscribe(LoadSceneUpdateEventArgs.EventId, self.m_funLoadSceneUpdateEvent)
    GameEntry.Event:Subscribe(LoadSceneDependencyAssetEventArgs.EventId, self.m_funLoadSceneDependencyAssetEvent)
    --GameEntry.Event:Subscribe(UnloadSceneSuccessEventArgs.EventId, self.m_funUnloadSceneSuccessEvent)
    --GameEntry.Event:Subscribe(UnloadSceneFailureEventArgs.EventId, self.m_funUnloadSceneFailureEvent)
end

function ProcedureChangeScene:UnRegisterEvent()
    GameEntry.Event:Unsubscribe(LoadSceneSuccessEventArgs.EventId, self.m_funLoadSceneSuccessEvent)
    GameEntry.Event:Unsubscribe(LoadSceneFailureEventArgs.EventId, self.m_funLoadSceneFailureEvent)
    GameEntry.Event:Unsubscribe(LoadSceneUpdateEventArgs.EventId, self.m_funLoadSceneUpdateEvent)
    GameEntry.Event:Unsubscribe(LoadSceneDependencyAssetEventArgs.EventId, self.m_funLoadSceneDependencyAssetEvent)
    --GameEntry.Event:Unsubscribe(UnloadSceneSuccessEventArgs.EventId, self.m_funcUnloadSceneSuccessEvent)
    --GameEntry.Event:Unsubscribe(UnloadSceneFailureEventArgs.EventId, self.m_funUnloadSceneFailureEvent)
end
-----------------------------logic----------------------------------

function ProcedureChangeScene:OnStartLoadScene()
    GameEntry.Lua:LuaGC()
    LuaGameEntry.Procedure:UnloadAllScene()
    GameEntry.ObjectPool:ReleaseAllUnused()
    GameEntry.Resource:ForceUnloadUnusedAssets(true)
    local _assetPath = LuaGameUtils.GetScenePath("TestCity")
    LuaGameEntry.LuaScene:LoadScene(_assetPath)
end

-----------------------------event----------------------------------

function ProcedureChangeScene:OnHandleLoadSceneSuccess(sender,e)
    --LuaGameEntry.UI:CloseUI(UINameConfig.UILoadingPanel)
    self.m_IsChangeSceneComplete = true
    if not UnityEngine.Application.isEditor then
        self:SendLuaEvent(EventId.EVENT_LUA_LOAD_SCENE_SUCCESS)
        LuaGameEntry.Procedure:OnChangeLuaProcedure(self.m_nextProcedureName)
    end
end

function ProcedureChangeScene:OnHandleLoadSceneFailure(sender,e)
    Logger.Debug("OnHandleLoadSceneFailure")
end

function ProcedureChangeScene:OnHandleLoadSceneUpdate(sender,e)
    local progress = e.Progress
    Logger.Debug("OnHandleLoadSceneUpdate:" .. progress)
    if not UnityEngine.Application.isEditor then
        self:SendLuaEvent(EventId.EVENT_LUA_LOAD_SCENE_PROGRESS,progress)
    end
end

function ProcedureChangeScene:OnHandleLoadSceneDependencyAsset(sender,e)
    Logger.Debug(string.format("Load scene '%s' dependency asset '%s', count '%s/%s' 当前进度 ‘%s/100’.",
            e.SceneAssetName,e.DependencyAssetName,e.LoadedCount,e.TotalCount,(e.LoadedCount / e.TotalCount) * 100))
    if not UnityEngine.Application.isEditor then
        self:SendLuaEvent(EventId.EVENT_LUA_LOAD_SCENE_PROGRESS,e.LoadedCount / e.TotalCount)
    end
end

function ProcedureChangeScene:OnHandleUnloadSceneSuccess(sender,e)
    Logger.Debug("OnHandleUnloadSceneSuccess")
end

function ProcedureChangeScene:OnHandleUnloadSceneFailure(sender,e)
    Logger.Debug("OnHandleUnloadSceneFailure")
end

return ProcedureChangeScene