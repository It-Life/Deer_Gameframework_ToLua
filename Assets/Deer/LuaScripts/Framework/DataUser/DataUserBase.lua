
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-05 08-27-28  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-05 08-27-28  
---版 本 : 0.1 
---===============================================
---@class DataUserBase:SingletonClass
DataUserBase = Class("DataUserBase",SingletonClass)

function DataUserBase:ClearParam()
    self._m_strName                 = nil;    
    self._m_strProtoParseName       = nil;
    self._m_strProtoDataListName    = nil;
    self._m_tbConfigPbModule        = nil;
    self._m_strCsvName              = nil;
end

function DataUserBase:__init()
    self:ClearParam();
end

function DataUserBase:__delete()    
    self:Destory();
end

function DataUserBase:Create(strName, strProtoParseName, strCsvName, tbConfigPbModule, strProtoDataListName)  
    self._m_strName                 = strName;
    self._m_strProtoParseName       = strProtoParseName;
    self._m_strProtoDataListName    = strProtoDataListName;
    self._m_tbConfigPbModule        = tbConfigPbModule;
    self._m_strCsvName              = strCsvName;
    self:OnCreate();
end

function DataUserBase:Destory()
    self:OnDestroy();
    self:ClearParam(self);
end

function DataUserBase:OnCreate()
end

function DataUserBase:OnDestroy()
end

function DataUserBase:LoadConfigData(strConfigModule, strProtoParseName, strCsvName, tbConfigPbModule, strProtoDataListName)    
    if (not strConfigModule) then        
        print("[DataUserConfigBase][LoadConfigData] Error Nil strConfigModule");
        return;
    end
    
    if (not strProtoParseName) then
        print("[DataUserConfigBase][LoadConfigData] Error Nil strProtoParseName ", strConfigModule);
        return;
    end

    if (not strCsvName) then        
        print("[DataUserConfigBase][LoadConfigData] Error Nil strCsvName ", strConfigModule);
        return;
    end

    if (not tbConfigPbModule) then        
        print("[DataUserConfigBase][LoadConfigData] Error Nil tbConfigPbModule", strConfigModule);
        return;
    end

    if (not strProtoDataListName) then
        print("[DataUserConfigBase][LoadConfigData] Error Nil strProtoDataListName", strConfigModule);
        return;
    end

    print("[DataUserConfigBase][LoadConfigData] Load File Data start ", strConfigModule, strProtoParseName, strProtoDataListName, strCsvName);    

    local szPath = self:GetConfigFileDir(strCsvName);
    local tbByteData = OtherTool.FileReadAllBytes(szPath);

    if (not tbByteData) then
        print("[DataUserConfigBase][LoadConfigData] Error Not LoadFileData ", strConfigModule, strCsvName);
        return;
    end

    print("strProtoParseName " .. strProtoParseName);
    local protoConfig = tbConfigPbModule[strProtoParseName]();    
    if (not protoConfig) then
        print("[DataUserConfigBase][LoadConfigData] Error Not Have protoConfig ", strConfigModule, strCsvName);
        return;
    end

    protoConfig:ParseFromString(tbByteData);
    return protoConfig[strProtoDataListName];     
end

function DataUserBase:GetConfigFileDir(strCsvName)    
    return LuaFramework.LuaUtil.PersistentPath  .. "Config/" .. strCsvName .. ".KFPCfg";
end

return DataUserBase