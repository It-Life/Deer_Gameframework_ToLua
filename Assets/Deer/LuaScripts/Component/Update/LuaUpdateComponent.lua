
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-12 00-05-08  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-12 00-05-08  
---版 本 : 0.1 
---===============================================
---@class LuaUpdateComponent:LuaComponentBase
---@field m_timerManager TimerManager
---@field m_updateManager UpdateManager
LuaUpdateComponent = Class("LuaUpdateComponent",LuaComponentBase)

function LuaUpdateComponent:__init()
    self.m_timerManager = TimerManager:GetInstance()
    self.m_updateManager = UpdateManager:GetInstance()
    self.m_listTimer = {}
end

function LuaUpdateComponent:__delete()
    self.m_timerManager:Delete()
    self.m_updateManager:Delete()
end
---@return function
function LuaUpdateComponent:AddUpdate(callback, ...)
    if not callback then
        return
    end
    return self.m_updateManager:AddUpdate(callback, ...)
end
---@return function
function LuaUpdateComponent:AddLateUpdate(callback, ...)
    if not callback then
        return
    end
    return self.m_updateManager:AddLateUpdate(callback, ...)
end
---@return function
function LuaUpdateComponent:AddFixedUpdate(callback, ...)
    if not callback then
        return
    end
    return self.m_updateManager:AddFixedUpdate(callback, ...)
end

function LuaUpdateComponent:RemoveUpdate(callback)
    if not callback then
        return
    end
    self.m_updateManager:RemoveUpdate(callback)
end

function LuaUpdateComponent:RemoveLateUpdate(callback)
    if not callback then
        return
    end
    self.m_updateManager:RemoveLateUpdate(callback)
end

function LuaUpdateComponent:RemoveFixedUpdate(callback)
    if not callback then
        return
    end
    self.m_updateManager:RemoveFixedUpdate(callback)
end

function LuaUpdateComponent:AddTimer(callback, duration, loop, unscaled)
    if not callback then
        return nil
    end
    local tbTimer = self.m_timerManager:GetTimer(callback, duration, loop, unscaled);
    if (not tbTimer) then
        Logger.Error("LuaUpdateComponent CreateTimer Failed!! Get Timer Null ");
        return nil
    end
    tbTimer:Start()
    return tbTimer;
end

function LuaUpdateComponent:RemoveTimer(tbTimer)
    if not tbTimer then
        return 0
    end
    tbTimer:Stop()
    return 1
end

return LuaUpdateComponent