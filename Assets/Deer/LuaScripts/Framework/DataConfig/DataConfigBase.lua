
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-05 07-54-07  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-05 07-54-07  
---版 本 : 0.1 
---===============================================
---@class DataConfigBase:SingletonClass
DataConfigBase = Class("DataConfigBase",SingletonClass)

function DataConfigBase:__init(...)

end

function DataConfigBase:__delete(...)
    self._m_strName                 = nil;
    self._m_strProtoParseName       = nil;
    self._m_strProtoDataListName    = nil;
    self._m_tbConfigPbModule        = nil;
    self._m_strCsvName              = nil;
end

function DataConfigBase:Create(strName, strProtoParseName, strCsvName, tbConfigPbModule, strProtoDataListName)
    self._m_strName                 = strName;
    self._m_strProtoParseName       = strProtoParseName;
    self._m_strProtoDataListName    = strProtoDataListName;
    self._m_tbConfigPbModule        = tbConfigPbModule;
    self._m_strCsvName              = strCsvName;
    self:OnCreate();
end

function DataConfigBase:LoadConfigData(strConfigModule, strProtoParseName, strCsvName, tbConfigPbModule, strProtoDataListName,callBack)
    if (not strConfigModule) then
        Logger.Debug("[DataUserConfigBase][LoadConfigData] Error Nil strConfigModule");
        return;
    end
    
    if (not strProtoParseName) then
        Logger.Debug("[DataUserConfigBase][LoadConfigData] Error Nil strProtoParseName %s", strConfigModule);
        return;
    end

    if (not strCsvName) then
        Logger.Debug("[DataUserConfigBase][LoadConfigData] Error Nil strCsvName %s", strConfigModule);
        return;
    end

    if (not tbConfigPbModule) then
        Logger.Debug("[DataUserConfigBase][LoadConfigData] Error Nil tbConfigPbModule %s", strConfigModule);
        return;
    end

    if (not strProtoDataListName) then
        Logger.Debug("[DataUserConfigBase][LoadConfigData] Error Nil strProtoDataListName %s", strConfigModule);
        return;
    end

    Logger.Debug("[DataUserConfigBase][LoadConfigData] Load File Data start %s %s %s %s", strConfigModule, strProtoParseName, strProtoDataListName, strCsvName);

    local szPath = self:GetConfigFileDir(strCsvName);
    FileUtils.FileReadAllBytes(szPath,FileUtils.CanConfigReadWritePath(),function(isRead,result)
        if isRead then
            local tbByteData = result
            if (not tbByteData) then
                Logger.Debug("[DataUserConfigBase][LoadConfigData] Error Not LoadFileData %s %s", strConfigModule, strCsvName);
                return;
            end
            local protoConfig = tbConfigPbModule[strProtoParseName]();
            if (not protoConfig) then
                Logger.Debug("[DataUserConfigBase][LoadConfigData] Error Not Have protoConfig %s %s", strConfigModule, strCsvName);
                return;
            end
            --反序列
            protoConfig:ParseFromString(tbByteData);
            if callBack then
                callBack(protoConfig[strProtoDataListName])
            end
        else
            Logger.Debug("[DataUserConfigBase][LoadConfigData] Error Not LoadFileData %s %s", strConfigModule, strCsvName);
            return;
        end
    end);
end

function DataConfigBase:GetConfigFileDir(strCsvName)    
    return "Config/" .. strCsvName .. ".bin";
end

return DataConfigBase