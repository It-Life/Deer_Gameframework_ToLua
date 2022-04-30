
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-09-08 07-50-34  
---修改作者 : 杜鑫 
---修改时间 : 2021-09-08 07-50-34  
---版 本 : 0.1 
---===============================================
---@class LuaCharacterMonster:LuaEntityBase
LuaCharacterMonster = Class("LuaCharacterMonster",LuaCharacterBase)

function LuaCharacterMonster:__init(...)

end

function LuaCharacterMonster:__delete(...)

end

function LuaCharacterMonster:OnShow(entityId,csEntity,luaEntityData)
    self.super.OnShow(self,entityId,csEntity,luaEntityData)

end

function LuaCharacterMonster:OnHide()
    self.super.OnHide(self)

end

return LuaCharacterMonster