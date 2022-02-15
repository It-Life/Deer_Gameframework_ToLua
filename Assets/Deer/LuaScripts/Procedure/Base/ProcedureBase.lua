
--================================================
--描 述 :  
--作 者 : 杜鑫 
--创建时间 : 2021-07-04 17-19-18  
--修改作者 : 杜鑫 
--修改时间 : 2021-07-04 17-19-18  
--版 本 : 0.1 
-- ===============================================
---@class ProcedureBase:BaseClass
ProcedureBase = Class("ProcedureBase",BaseClass)

function ProcedureBase:OnEnter(csProcedure)
    self.csProcedure = csProcedure
    Logger.Debug("Enter the current Procedure:%s",self.csProcedure:GetCurProcedureId())
    LuaGameEntry.Procedure:SetCurrLuaProcedure(self)
end

function ProcedureBase:OnLeave()
    Logger.Debug("Leave the current Procedure:%s",self.csProcedure:GetCurProcedureId())
end

function ProcedureBase:GetCurProcedureId()
    local strProcedureId = ""
    if self.csProcedure then
        strProcedureId = self.csProcedure:GetCurProcedureId()
    end
    return strProcedureId
end

function ProcedureBase:OnChangeProcedure(nextProcedureId)
    if self.csProcedure then
        self.csProcedure:ChangeStateToMain(nextProcedureId)
    end
end

return ProcedureBase