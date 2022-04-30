
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-08-14 00-09-35  
---修改作者 : 杜鑫 
---修改时间 : 2021-08-14 00-09-35  
---版 本 : 0.1 
---===============================================
---@class LuaProcedureComponent:LuaComponentBase
LuaProcedureComponent = Class("LuaProcedureComponent",LuaComponentBase)

function LuaProcedureComponent:__init()
    self.g_currLuaProcedure = nil
    self.m_isLuaProcedure = false
    self.g_nextLuaProcedureName = nil
end

function LuaProcedureComponent:__delete()
end

function LuaProcedureComponent:GetCurrLuaProcedure()
    return self.g_currLuaProcedure
end

function LuaProcedureComponent:GetNextLuaProcedure()
    return self.g_nextLuaProcedureName
end

function LuaProcedureComponent:SetNextLuaProcedure(nextLuaProcedureName)
    self.g_nextLuaProcedureName = nextLuaProcedureName
end

function LuaProcedureComponent:SetCurrLuaProcedure(procedure)
    self.m_isLuaProcedure = true
    self.g_currLuaProcedure = procedure
end

function LuaProcedureComponent:GetIsChangeSceneProcedure(nextProcedureId)
    if nextProcedureId == ProcedureConfig.ProcedureMainHall then
        return true
    end
    return false
end

function LuaProcedureComponent:OnChangeLuaProcedure(nextProcedureId)
    if self.g_nextLuaProcedureName then
        self.g_currLuaProcedure:OnChangeProcedure(self.g_nextLuaProcedureName)
        self:SetNextLuaProcedure(nil)
    else
        if not self.g_currLuaProcedure then
            return
        end
        if self:GetIsChangeSceneProcedure(nextProcedureId) then
            self:SetNextLuaProcedure(nextProcedureId)
            GameEntry.Camera:CameraActive(true)
            self.g_currLuaProcedure:OnChangeProcedure(ProcedureConfig.ProcedureChangeScene)
        else
            GameEntry.Camera:CameraActive(false)
            self:UnloadAllEntity()
            self:UnloadAllScene()
            self.g_currLuaProcedure:OnChangeProcedure(nextProcedureId)
        end
    end
end

function LuaProcedureComponent:EnterScene()

end

function LuaProcedureComponent:UnloadAllScene()
    -- 卸载所有场景
    local loadedSceneAssetNames = GameEntry.Scene:GetLoadedSceneAssetNames();
    for i = 1, loadedSceneAssetNames.Length do
        GameEntry.Scene:UnloadScene(loadedSceneAssetNames[i-1]);
    end
end
---卸载所有实体
function LuaProcedureComponent:UnloadAllEntity()
    GameEntry.Entity:HideAllLoadedEntities()
    GameEntry.Entity:HideAllLoadingEntities()
end

function LuaProcedureComponent:GetIsLuaProcedure()
    return self.m_isLuaProcedure
end

return LuaProcedureComponent