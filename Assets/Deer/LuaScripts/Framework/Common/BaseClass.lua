
---================================================
---描 述 :  继承此类的父类写析构函数
---作 者 : 杜鑫 
---创建时间 : 2021-07-04 23-19-15  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-04 23-19-15  
---版 本 : 0.1 
---===============================================
---@class BaseClass:Class
BaseClass = Class("BaseClass")

function BaseClass:__init(...)
    
end

function BaseClass:__delete(...)
    
end

function BaseClass:RegisterLuaEvent(nEventId, ...)
    return LuaGameEntry.LuaEvent:RegisterLuaEvent(nEventId,...)
end

function BaseClass:UnRegisterLuaEvent(nEventId, ...)
    LuaGameEntry.LuaEvent:UnRegisterLuaEvent(nEventId,...)
end

function BaseClass:SendLuaEvent(nEventId, ...)
    LuaGameEntry.LuaEvent:SendLuaEvent(nEventId,...)
end


function BaseClass:RegisterCSEvent(nEventId, ...)
    return LuaGameEntry.LuaEvent:RegisterCSEvent(nEventId,...)
end

function BaseClass:UnRegisterCSEvent(nEventId, ...)
    LuaGameEntry.LuaEvent:UnRegisterCSEvent(nEventId,...)
end

function BaseClass:SendCSEvent(nEventId, ...)
    LuaGameEntry.LuaEvent:SendCSEvent(nEventId,...)
end

return BaseClass