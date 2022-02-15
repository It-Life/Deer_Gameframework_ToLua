
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-09-08 07-50-34  
---修改作者 : 杜鑫 
---修改时间 : 2021-09-08 07-50-34  
---版 本 : 0.1 
---===============================================
---@class CharacterDataBase
CharacterDataBase = Class("CharacterDataBase")

function CharacterDataBase:__init()
    self.g_walkSpeed = 2
    self.g_runSpeed = 4
    self.g_turningSpeed = 4
    self.g_gravity = 10
    self.g_jumpPower = 4
    self.g_jumpCanMove = true
end

function CharacterDataBase:__delete()
    self.g_walkSpeed = nil
    self.g_runSpeed = nil
end

function CharacterDataBase:GetWalkSpeed()
    return self.g_walkSpeed
end

function CharacterDataBase:GetRunSpeed()
    return self.g_runSpeed
end

function CharacterDataBase:GetTurnSpeed()
    return self.g_turningSpeed
end

function CharacterDataBase:GetGravity()
    return self.g_gravity
end

---跳跃力
function CharacterDataBase:GetJumpPower()
    return self.g_jumpPower
end
---跳的同时是否可以移动
function CharacterDataBase:IsJumpCanMove()
    return self.g_jumpCanMove
end

return CharacterDataBase

