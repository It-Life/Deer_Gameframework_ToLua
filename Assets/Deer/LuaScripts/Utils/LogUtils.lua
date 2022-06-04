
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-08-14 16-56-50  
---修改作者 : 杜鑫 
---修改时间 : 2021-08-14 16-56-50  
---版 本 : 0.1 
---===============================================
---@class Logger @日志类
Logger = Class("Logger")

local logType = 
{
    Debug = "Debug",
    Info = "Info",
    ColorInfo = "ColorInfo",
    Warning = "Warning",
    Error = "Error",
    Fatal = "Fatal",
}

function Logger.Debug(message,arg1,arg2,arg3,arg4)
    Logger.__InputLog(logType.Debug,message,arg1,arg2,arg3,arg4)
end

function Logger.Info(message,arg1,arg2,arg3,arg4)
    Logger.__InputLog(logType.Info,message,arg1,arg2,arg3,arg4)
end
---打印颜色日志，EnableDebugAndAboveLogs EnableInfoAndAboveLogs 和 EnableAllLogs 显示
---@param message string
---@param color UnityEngine.Color
---@param color Color
---@param color ColorType
function Logger.ColorInfo(color,message)
    if GameEntry.GameSettings.g_logEnum == LogEnum.EnableDebugAndAboveLogs
            or GameEntry.GameSettings.g_logEnum == LogEnum.EnableAllLogs
            or GameEntry.GameSettings.g_logEnum == LogEnum.EnableInfoAndAboveLogs then
        Log.ColorInfo(color,debug.traceback(message,3))
    end
end

function Logger.Warning(message,arg1,arg2,arg3,arg4)
    Logger.__InputLog(logType.Warning,message,arg1,arg2,arg3,arg4)
end

function Logger.Error(message,arg1,arg2,arg3,arg4)
    Logger.__InputLog(logType.Error,message,arg1,arg2,arg3,arg4)
end

function Logger.Fatal(message,arg1,arg2,arg3,arg4)
    Logger.__InputLog(logType.Fatal,message,arg1,arg2,arg3,arg4)
end

function Logger.__InputLog(type,message,arg1,arg2,arg3,arg4)
    local _strMessage = message
    if arg1 and arg2 and arg3 and arg4 then
        _strMessage = string.format(_strMessage,arg1,arg2,arg3,arg4)
    end
    if arg1 and arg2 and arg3 and not arg4 then
        _strMessage = string.format(_strMessage,arg1,arg2,arg3)
    end
    if arg1 and arg2 and not arg3 and not arg4 then
        _strMessage = string.format(_strMessage,arg1,arg2)
    end
    if arg1 and not arg2 and not arg3 and not arg4 then
        _strMessage = string.format(_strMessage,arg1)
    end
    if GameEntry.GameSettings.g_logEnum == LogEnum.DisableAllLogs then
        return
    end
    if GameEntry.GameSettings.g_logEnum == LogEnum.EnableDebugAndAboveLogs or GameEntry.GameSettings.g_logEnum == LogEnum.EnableAllLogs then
        if type == logType.Debug then
            Log.Info(debug.traceback(_strMessage,3))
        elseif type == logType.Info then
            Log.Info(debug.traceback(_strMessage,3))
        elseif type == logType.Warning then
            Log.Warning(debug.traceback(_strMessage,3))
        elseif type == logType.Error then
            --Log.Error(debug.traceback(_strMessage,3))
        elseif type == logType.Fatal then
            Log.Error(debug.traceback(_strMessage,3))
        else
            Log.Error(debug.traceback(_strMessage,3))
        end
    elseif GameEntry.GameSettings.g_logEnum == LogEnum.EnableInfoAndAboveLogs then
        if type == logType.Info then
            print(debug.traceback(_strMessage,3))
        elseif type == logType.Warning then
            Log.Warning(debug.traceback(_strMessage,3))
        elseif type == logType.Error then
            Log.Error(debug.traceback(_strMessage,3))
        elseif type == logType.Fatal then
            Log.Error(debug.traceback(_strMessage,3))
        end
    elseif GameEntry.GameSettings.g_logEnum == LogEnum.EnableWarningAndAboveLogs then
        if type == logType.Warning then
            Log.Warning(debug.traceback(_strMessage,3))
        elseif type == logType.Error then
            Log.Error(debug.traceback(_strMessage,3))
        elseif type == logType.Fatal then
            Log.Error(debug.traceback(_strMessage,3))
        end
    elseif GameEntry.GameSettings.g_logEnum == LogEnum.EnableErrorAndAboveLogs then
        if type == logType.Error then
            Log.Error(debug.traceback(_strMessage,3))
        elseif type == logType.Fatal then
            Log.Error(debug.traceback(_strMessage,3))
        end
    elseif GameEntry.GameSettings.g_logEnum == LogEnum.EnableFatalAndAboveLogs then
        if type == logType.Fatal then
            Log.Error(debug.traceback(_strMessage,3))
        end
    end
end

function Logger.DrawLine(startVet3,endVet3,color)
    Log.DrawLine(startVet3.x,startVet3.y,startVet3.z,endVet3.x,endVet3.y,endVet3.z,color)
end

function Logger.DrawRay(startVet3,endVet3,color)
    Log.DrawLine(startVet3.x,startVet3.y,startVet3.z,endVet3.x,endVet3.y,endVet3.z,color)
end

return Logger
