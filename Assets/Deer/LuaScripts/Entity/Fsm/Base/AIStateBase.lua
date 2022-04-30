
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2022-04-16 23-16-09  
---修改作者 : 杜鑫 
---修改时间 : 2022-04-16 23-16-09  
---版 本 : 0.1 
---===============================================
---@class AIStateBase:BaseClass
---@field m_owner AIStateController
AIStateBase = Class("AIStateBase",BaseClass)

function AIStateBase:SetOwner(owner)
    self.m_owner = owner
end
---@return LuaCharacterBase
function AIStateBase:GetOwner()
    return self.m_owner
end

return AIStateBase