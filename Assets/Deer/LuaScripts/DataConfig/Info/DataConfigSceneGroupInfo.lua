
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-12-23 09-05-22 
---修改作者 : 杜鑫 
---修改时间 : 2021-12-23 09-05-22 
---版 本 : 0.1 
---===============================================
---@class DataConfigSceneGroupInfo:DataConfigBase
DataConfigSceneGroupInfo = Class("DataConfigSceneGroupInfo",DataConfigBase)

function DataConfigSceneGroupInfo:InitConfigData()
    self._m_listInfo = {};
    local listConfigs = self:LoadConfigData(self._m_strName, self._m_strProtoParseName, self._m_strCsvName, self._m_tbConfigPbModule, self._m_strProtoDataListName)
    if (not listConfigs) then
        return 0;
    end
    for _, tbInfo in pairs(listConfigs) do
        local strScriptName = tbInfo.script_name;
        if strScriptName then
            local strProtoCsvName = "SceneScript_Config"
            local strProtoParseName = string.format("%s_Data",strScriptName)
            local tbConfigPbModule = _G[string.format("%s_pb",strProtoCsvName)] or nil
            local strProtoDataListName = "items"
            if tbConfigPbModule then
                local scriptConfigs = self:LoadConfigData(strProtoCsvName, strProtoParseName, strScriptName, tbConfigPbModule, strProtoDataListName)
                if scriptConfigs then
                    local tbScriptInfos = {}
                    for k, v in pairs(scriptConfigs) do
                        if v.script_stage then
                            local tbTempScriptInfo = {
                                script_name = strScriptName,
                                script_stage = v.script_stage,
                                remark = v.remark,
                                type = v.type,
                                is_repeat = v.is_repeat,
                                delay_time = v.delay_time,
                                num1 = v.num1,
                                num2 = v.num2,
                                num3 = v.num3,
                                num4 = v.num4,
                                num5 = v.num5,
                                num6 = v.num6,
                                next_stage = v.next_stage,
                                nScriptGroupId = v.ScriptGroupId,
                            };
                            tbScriptInfos[v.script_stage] = tbTempScriptInfo;
                        end
                    end
                    local tbTempInfo = {
                        strScriptName             = strScriptName,
                        tbScriptInfos             = tbScriptInfos,
                    };
                    self._m_listInfo[strScriptName] = tbTempInfo;
                end
            end
        end

    end
    return 1;
end

function DataConfigSceneGroupInfo:OnCreate()
    self._m_listInfo = nil;
    self:InitConfigData();
end

function DataConfigSceneGroupInfo:GetConfigList(self)
    return self._m_listLevelScriptInfo;
end

function DataConfigSceneGroupInfo:GetStageInfoById(self, strScriptsId)
    if (not self._m_listInfo) then
        return nil;
    end

    return self._m_listInfo[strScriptsId];
end


return DataConfigSceneGroupInfo