
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-08-08 12-44-38  
---修改作者 : 杜鑫 
---修改时间 : 2021-08-08 12-44-38  
---版 本 : 0.1 
---===============================================
---@class LuaEventComponent:LuaComponentBase
---@field m_messengerCenter MessengerManager
LuaEventComponent = Class("LuaEventComponent",LuaComponentBase)

function LuaEventComponent:__init()
    self.m_messengerCenter = MessengerManager.New()
end

function LuaEventComponent:__delete()
    self.m_messengerCenter:Delete()
end

function LuaEventComponent:RegisterLuaEvent(nEventId, funcCallBack, ...)
    local funTemp = BindCallback(funcCallBack, ...);
    self.m_messengerCenter:AddEvent(nEventId, funTemp);
    return funTemp;
end

function LuaEventComponent:UnRegisterLuaEvent(nEventId, funcCallBack)
    if (not funcCallBack) then
        Logger.Error("UnRegistLuaEvent funcCallBack nil", nEventId);
        return;
    end
    self.m_messengerCenter:RemoveEvent(nEventId, funcCallBack);
end

function LuaEventComponent:SendLuaEvent(nEventId, ...)
    self.m_messengerCenter:Broadcast(nEventId, ...);
end

-----------------------CS侧----------------------------
-- C#的事件机制，C#侧会收到，这个事件机制的回调函数需要通过 BindCallback() 封装后才能正确调用回调函数
function LuaEventComponent:RegisterCSEvent(nEventId, funcCallBack, ...)
    local param = MessengerInfo.New();
    local funTemp = BindCallback(funcCallBack, ...);
    GameEntry.Messenger:RegisterEvent(nEventId, funTemp);
    return funTemp;
end

function LuaEventComponent:UnRegisterCSEvent(nEventId, funcCallBack)
    if (not funcCallBack) then
        Logger.Error("UnRegisterCSEvent funcCallBack nil", nEventId);
        return;
    end
    GameEntry.Messenger:UnRegisterEvent(nEventId, funcCallBack);
end

function LuaEventComponent:SendCSEvent(nEventId,pSender1,pSender2,pSender3)
    local param = MessengerInfo.New()
    param.param1 = pSender1
    param.param2 = pSender2
    param.param3 = pSender3
    GameEntry.Messenger:SendEvent(nEventId,param);
end

return LuaEventComponent