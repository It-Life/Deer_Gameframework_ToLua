
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-08-14 22-10-00  
---修改作者 : 杜鑫 
---修改时间 : 2021-08-14 22-10-00  
---版 本 : 0.1 
---===============================================
ProcedureMainHall = Class("ProcedureMainHall",ProcedureBase)
---@field _data CharacterData
function ProcedureMainHall:OnEnter(csProcedure)
    self.super.OnEnter(self,csProcedure)
    LuaGameEntry.LuaSound:PlayMusic(SoundId.MAIN_BGM)
    LuaGameEntry.UI:CreateUI(UINameConfig.UIMainHallPanel)
    local entityId = LuaGameEntry.LuaEntity:GenerateSerialId()
    local _data = EntityData.New(entityId,1,"Character/Blade_girl/Blade_Girl_Prefab")
    _data.Position = Vector3(75,11,120)
    _data.IsOwner = false
    LuaGameEntry.LuaEntity:ShowCharacter(_data)
    
    local entityId = LuaGameEntry.LuaEntity:GenerateSerialId()
    local _data1 = EntityData.New(entityId,1,"Character/Blade_Warrior/Blade_Warrior_Prefab")
    _data1.Position = Vector3(76,11,125)
    _data1.IsOwner = true
    LuaGameEntry.LuaEntity:ShowCharacter(_data1)

end

function ProcedureMainHall:OnLeave()
    self.super.OnLeave(self)

end

return ProcedureMainHall