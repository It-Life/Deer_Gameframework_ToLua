
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
EventId = {}
-- lua事件
--- lua发送连接
EventId.EVENT_LUA_REQUEST_CONNECT       = 0x000001
--- 发送socket 请求
EventId.EVENT_LUA_SEND_SOCKET_REQUEST   = 0x000002

--luaGame事件
EventId.EVENT_LUA_GAME_MOVE_DIRECTION   = 0x010001
EventId.EVENT_LUA_GAME_MOVE_END         = 0x010002
EventId.EVENT_LUA_GAME_START_JUMP       = 0x010003
EventId.EVENT_LUA_GAME_DEATH            = 0x010004
EventId.EVENT_LUA_PLAYER_EXIT           = 0x010005
--Scene事件
EventId.EVENT_LUA_LOAD_SCENE_SUCCESS    = 0x020001
EventId.EVENT_LUA_LOAD_SCENE_PROGRESS    = 0x020002

--UI事件
---打开UI
EventId.EVENT_LUA_OPEN_UI_FORM    = 0x030001
---关闭UI
EventId.EVENT_LUA_CLOSE_UI_FORM    = 0x030002
