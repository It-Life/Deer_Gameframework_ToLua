
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
    LuaGameEntry.UI:OpenUI(UINameConfig.UIMainHallPanel,nil,function(result,serialId)
        if result then
            LuaGameEntry.UI:CloseUI(UINameConfig.UILoginPanel)
        end
    end)

    local entityId = LuaGameEntry.LuaEntity:GenerateSerialId()
    local data = CharacterPlayerData.New()
    data:SetId(entityId)
    data:SetAssetName("Character/Blade_girl/Blade_Girl_Prefab")
    data:SetIsOwner(true)
    data:SetPosition(75,0,120)
    LuaGameEntry.LuaEntity:ShowCharacter(data)
end

function ProcedureMainHall:OnLeave()
    self.super.OnLeave(self)

end

return ProcedureMainHall