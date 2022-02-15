if UnityEngine.Application.isEditor then
	print(pcall(function()
		dofile("EmmyDebugger")
	end) and "EmmyDebugger已启动" or "未配置EmmyDebugger.lua")
end

require "Framework.Require.RequireTable"

GameObject = UnityEngine.GameObject

--主入口函数。从这里开始lua逻辑
function Main()
	Logger.Debug("logic start")
end

--场景切换通知
function OnLevelWasLoaded(level)
	collectgarbage("collect")
	Time.timeSinceLevelLoad = 0
end

function OnApplicationQuit()
	LuaGameEntry:Cleanup()
end