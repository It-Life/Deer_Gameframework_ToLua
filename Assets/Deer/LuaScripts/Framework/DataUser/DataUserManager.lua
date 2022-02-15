
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-05 08-27-11  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-05 08-27-11  
---版 本 : 0.1 
---===============================================
DataUserManager = Class("DataUserManager",SingletonClass)

function DataUserManager:__init()
    self.m_listUserData = nil;
end

function DataUserManager:__delete()
    self:Dispose();
end

---------------------------------------------------------------------------
function DataUserManager:Startup()
    self.m_listUserData = {};
    self:InitAllData();
    self._m_cbevent_lua_loginsyncplayerstart = self:RegistLuaEvent(PTC_S2C_LOGINSYNCPLAYERSTART, self.OnHandleLogInSyncPlayerStart, self);
end

function DataUserManager:Dispose()
    if (self.m_listUserData) then
        for strName, tbInfo in pairs(self.m_listUserData) do
            tbInfo:Delete();
        end
    end
    
    self:UnRegistLuaEvent(PTC_S2C_LOGINSYNCPLAYERSTART, self._m_cbevent_lua_loginsyncplayerstart);

    self.m_listUserData = nil;
    self._m_cbevent_lua_loginsyncplayerstart = nil;
end

function DataUserManager:InitAllData()
    self.m_listUserData = {};
    for _, tbInfo in pairs(DataUserDefine.InitDataConfig) do
        local tbClass = tbInfo.tbModuleClass;
        local tbInst = tbClass.New();
        tbInst:Create(tbInfo.strName);
        self.m_listUserData[tbInfo.strName] = tbInst;
    end
end

function DataUserManager:ClearAllData(bState)
    for _, tbInfo in pairs(self.m_listUserData) do
        tbInfo:OnInitData(bState);
    end
end

--清除除角色列表外的所有数据 不需要了 会重新同步角色列表
function DataUserManager:ResetLoginData()
--[[    for i, tbInfo in pairs(self.m_listUserData) do
        if i == DataUserNames.DataUserInfoManager then
            tbInfo:OnInitData(true);
        else
            tbInfo:OnInitData(false);
        end
    end]]
    self:ClearAllData(self, true);
end

-- 获取配置表实例
function DataUserManager:GetUserDataInst(strDataName)
    if (not self.m_listUserData) then
        return nil;
    end

    return self.m_listUserData[strDataName];
end

function DataUserManager:OnHandleLogInSyncPlayerStart(tbBGGSLoginSyncPlayerStartResp)
    if (not tbBGGSLoginSyncPlayerStartResp) then
        return;
    end

    local nLoginType = tonumber(tbBGGSLoginSyncPlayerStartResp.nLoginType);
    if nLoginType == 0 or nLoginType == 1 then
        self:ClearAllData(true);
        GameEntry.Character:ClearMainPlayerInfo();
    end
end

return DataUserManager