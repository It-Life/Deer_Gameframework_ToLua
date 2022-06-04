
---================================================
---描 述:
---作 者:XinDu
---创建时间:2022-05-07 10-59-55
---修改作者:XinDu
---修改时间:2022-05-07 10-59-55
---版 本:0.1
---===============================================
---@class LuaGameManager
LuaGameManager = {}

---@return DataLoginInfoManager
function LuaGameManager:GetDataLoginInfoManager()
    return DataLoginInfoManager:GetInstance()
end
---@return DataBagInfoManager
function LuaGameManager:GetDataBagInfoManager()
    return DataBagInfoManager:GetInstance()
end
---@return DataUserManager
function LuaGameManager:GetDataUserManager()
    return DataUserManager:GetInstance()
end
---@return DataAwardInfoManager
function LuaGameManager:GetDataAwardInfoManager()
    return DataAwardInfoManager:GetInstance()
end

---@return DataChooseManager
--人物选择单例
function LuaGameManager:GetDataChooseInfoManager()
    return DataChooseManager:GetInstance()
end

LuaGameManager.LoginInfo = LuaGameManager:GetDataLoginInfoManager()
LuaGameManager.BagInfo = LuaGameManager:GetDataBagInfoManager()
LuaGameManager.UserData = LuaGameManager:GetDataUserManager()
LuaGameManager.AwardInfo = LuaGameManager:GetDataAwardInfoManager()
LuaGameManager.ChooseInfo = LuaGameManager:GetDataChooseInfoManager() --人物选择单例