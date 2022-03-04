
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

function DataConfigBase:LoadConfigData(strConfigModule, strProtoParseName, strCsvName, tbConfigPbModule, strProtoDataListName)    
    if (not strConfigModule) then
        Logger.Debug("[DataUserConfigBase][LoadConfigData] Error Nil strConfigModule");
        return;
    end
    
    if (not strProtoParseName) then
        Logger.Debug("[DataUserConfigBase][LoadConfigData] Error Nil strProtoParseName ", strConfigModule);
        return;
    end

    if (not strCsvName) then
        Logger.Debug("[DataUserConfigBase][LoadConfigData] Error Nil strCsvName ", strConfigModule);
        return;
    end

    if (not tbConfigPbModule) then
        Logger.Debug("[DataUserConfigBase][LoadConfigData] Error Nil tbConfigPbModule", strConfigModule);
        return;
    end

    if (not strProtoDataListName) then
        Logger.Debug("[DataUserConfigBase][LoadConfigData] Error Nil strProtoDataListName", strConfigModule);
        return;
    end

    Logger.Debug("[DataUserConfigBase][LoadConfigData] Load File Data start ", strConfigModule, strProtoParseName, strProtoDataListName, strCsvName);    

    local szPath = self:GetConfigFileDir(strCsvName);
    local tbByteData = FileUtils.FileReadAllBytes(szPath);

    if (not tbByteData) then
        Logger.Debug("[DataUserConfigBase][LoadConfigData] Error Not LoadFileData ", strConfigModule, strCsvName);
        return;
    end
    --optional运行代码
    -- 发送 --
--[[    local sendMail = Heroes_Config_pb.Appearance_Config()
    sendMail.id = 12

    -- 模拟接收 --
    local recvMail = Heroes_Config_pb.Appearance_Config()
    recvMail:ParseFromString(sendMail:SerializeToString())]]



    local protoConfig = tbConfigPbModule[strProtoParseName]();
    if (not protoConfig) then
        Logger.Debug("[DataUserConfigBase][LoadConfigData] Error Not Have protoConfig ", strConfigModule, strCsvName);
        return;
    end
    protoConfig:ParseFromString(tbByteData);
    return protoConfig[strProtoDataListName];
end

function DataConfigBase:GetConfigFileDir(strCsvName)    
    return GameEntry.Resource.ReadWritePath  .. "/Config/" .. strCsvName .. ".bin";
end

return DataConfigBase