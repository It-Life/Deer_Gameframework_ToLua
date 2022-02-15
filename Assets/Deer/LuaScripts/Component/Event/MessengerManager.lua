
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-08-08 12-41-00  
---修改作者 : 杜鑫 
---修改时间 : 2021-08-08 12-41-00  
---版 本 : 0.1 
---===============================================
--[[
-- 消息系统
-- 使用范例：
-- TestEventCenter:AddEvent(Type, callback) --添加监听
-- TestEventCenter:AddListener(Type, callback, ...) --添加监听
-- TestEventCenter:Broadcast(Type, ...) --发送消息
-- TestEventCenter:RemoveEvent(Type, callback, ...) --移除监听
-- TestEventCenter:RemoveListener(Type, callback, ...) --移除监听
-- TestEventCenter:Cleanup() --清理消息中心
--]]
---@class MessengerManager
MessengerManager = Class("Messenger");

function MessengerManager:__init()
    self.events = {};
end

function MessengerManager:__delete()
    self.events = nil;
    self.error_handle = nil;
end

function MessengerManager:AddEvent(e_type, e_event, ...)
    local event = self.events[e_type]
    if event == nil then
        event = setmetatable({}, {__mode = "k"})
    end

    for k, v in pairs(event) do
        if k == e_event then
            error("Aready cotains e_event : "..tostring(e_event))
            return
        end
    end

    event[e_event] = setmetatable(SafePack(...), {__mode = "kv"})
    self.events[e_type] = event;
end

function MessengerManager:RemoveEvent(e_type, e_event)
    local event = self.events[e_type]
    if event == nil then
        return
    end

    event[e_event] = nil
end

function MessengerManager:Broadcast(e_type, ...)
    local event = self.events[e_type]
    if event ~= nil then
        for k, v in pairs(event) do
            assert(k ~= nil)
            local args = ConcatSafePack(v, SafePack(...))
            k(SafeUnpack(args))
        end
    end
end

function MessengerManager:RemoveEventByType(e_type)
    self.events[e_type] = nil
end

function MessengerManager:Cleanup()
    self.events = {};
end

return MessengerManager;