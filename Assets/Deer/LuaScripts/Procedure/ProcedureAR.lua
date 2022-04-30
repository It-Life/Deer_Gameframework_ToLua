
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2022-03-10 15-24-00  
---修改作者 : 杜鑫 
---修改时间 : 2022-03-10 15-24-00  
---版 本 : 0.1 
---===============================================
---@class ProcedureAR:ProcedureBase
ProcedureAR = Class("ProcedureAR",ProcedureBase)

function ProcedureAR:OnEnter(csProcedure)
    self.super.OnEnter(self,csProcedure)
    self.csProcedure = csProcedure
    LuaGameEntry.LuaAR:SetStartARCheck(true)
end

function ProcedureAR:OnLeave()
    self.super.OnLeave(self)

end

return ProcedureAR