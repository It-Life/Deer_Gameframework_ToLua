
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-08-10 08-21-46  
---修改作者 : 杜鑫 
---修改时间 : 2021-08-10 08-21-46  
---版 本 : 0.1 
---===============================================
-- C#的事件id，都在C#中定义，不会再这里定义了
-- 只有这里面的id是给lua脚本中交互使用的
---@class EventId
EventId = 
{
    -- lua事件
    --- lua发送连接
    EVENT_LUA_REQUEST_CONNECT       = 0x000001,
    --- 发送socket 请求
    EVENT_LUA_SEND_SOCKET_REQUEST   = 0x000002,

    --luaGame事件
    EVENT_LUA_GAME_MOVE_DIRECTION   = 0x010001,
    EVENT_LUA_GAME_MOVE_END         = 0x010002,
    EVENT_LUA_GAME_START_JUMP       = 0x010003,

    --Scene事件
    EVENT_LUA_LOAD_SCENE_SUCCESS    = 0x020001,
}
