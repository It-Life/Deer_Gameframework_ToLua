
---================================================
---描 述 :  战斗流程
---作 者 : 杜鑫 
---创建时间 : 2021-12-13 22-42-53  
---修改作者 : 杜鑫 
---修改时间 : 2021-12-13 22-42-53  
---版 本 : 0.1 
---===============================================
ProcedureBattle = Class("ProcedureBattle")

function ProcedureBattle:OnEnter(csProcedure)
    self.super.OnEnter(self,csProcedure)
    self.csProcedure = csProcedure

end

function ProcedureBattle:OnLeave()
    self.super.OnLeave(self)

end

return ProcedureBattle