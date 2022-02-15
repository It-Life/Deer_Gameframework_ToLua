
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-24 16-27-08  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-24 16-27-08  
---版 本 : 0.1 
---===============================================
---@class LuaConfigManager:SingletonClass
LuaConfigManager = Class("LuaConfigManager",SingletonClass)

function LuaConfigManager:__init(...)
    self.m_listConfigLoadData = {}
end

function LuaConfigManager:__delete(...)

end
---加载所有config
function LuaConfigManager:LoadAllUserConfig()
    self.m_listConfigLoadData = {}
    for _, tbInfo in pairs(DataConfigDefine.LoadFileConfig) do
        local tbClass = tbInfo.tbModuleClass
        local tbInst = tbClass:GetInstance()
        tbInst:Create(tbInfo.strName, tbInfo.strProtoParseName, tbInfo.strCsvName, tbInfo.tbConfigPbModule, tbInfo.strProtoDataListName)
        self.m_listConfigLoadData[tbInfo.strName] = tbInst
    end
end
-- 获取配置表实例
function LuaConfigManager:GetConfigInst(strConfigName)
    if (not self.m_listConfigLoadData) then
        return nil;
    end
    return self.m_listConfigLoadData[strConfigName];
end

return LuaConfigManager