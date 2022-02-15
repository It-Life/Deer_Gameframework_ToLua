
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-12 00-05-08  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-12 00-05-08  
---版 本 : 0.1 
---===============================================
---@class TimerManager:SingletonClass
TimerManager = Class("TimerManager",SingletonClass)

function TimerManager:__init()
    self.m_listTimer = {}
end

function TimerManager:__delete()
    for k, v in pairs(self.m_listTimer) do
        if v.running then
            v:Stop()
        end
    end
    self.m_listTimer = nil
end

-- 获取Update定时器
function TimerManager:GetTimer(func, duration, loop, unscaled)
    local timer = nil
    if self.m_listTimer[func] then
        timer = self.m_listTimer[func]
        timer:Reset(func, duration, loop, unscaled)
    else
        timer = Timer.New(func, duration, loop, unscaled)
    end
    self.m_listTimer[func] = timer
    return timer
end

-- 清理：可用在场景切换前，不清理关系也不大，只是缓存池不会下降
function TimerManager:Cleanup()
    self.m_listTimer = {}
end

return TimerManager