
---================================================
---描 述 :
---作 者 : 杜鑫
---创建时间 : 2021-07-04 17-19-18 
---修改作者 : 杜鑫
---修改时间 : 2021-07-04 17-19-18 
---版 本 : 0.1
-- ===============================================
---@class ProcedureMain:ProcedureBase
ProcedureMain = Class("ProcedureMain",ProcedureBase)

function ProcedureMain:OnEnter(csProcedure)
    self.super.OnEnter(self,csProcedure)
    self.csProcedure = csProcedure
    self:OnChangeProcedure(ProcedureConfig.ProcedureLogin)
end

function ProcedureMain:OnLeave()
    self.super.OnLeave(self)
end

return ProcedureMain