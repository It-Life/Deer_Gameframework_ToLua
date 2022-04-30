
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2022-03-09 19-08-08  
---修改作者 : 杜鑫 
---修改时间 : 2022-03-09 19-08-08  
---版 本 : 0.1 
---===============================================
---@class LuaARComponent:LuaComponentBase
LuaARComponent = Class("LuaARComponent",LuaComponentBase)

function LuaARComponent:__init()

end

function LuaARComponent:__delete()

end

function LuaARComponent:RegisterLuaEvent()
    self._onhandlearputsuccess = LuaGameEntry.LuaEvent:RegisterCSEvent(EventName.EVENT_CS_AR_PUT_SUCCESS,self.OnHandleARPutSuccess,self)
end

function LuaARComponent:UnRegisterLuaEvent()
    LuaGameEntry.LuaEvent:UnRegisterCSEvent(EventName.EVENT_CS_AR_PUT_SUCCESS,self._onhandlearputsuccess)

end
---@field value boolean 是否开启检查AR平面
function LuaARComponent:SetStartARCheck(value)
    GameEntry.AR.StartARCheck = value;
end

function LuaARComponent:OnHandleARPutSuccess()
    self:SetStartARCheck(false)
    --生成Plane
end

return LuaARComponent