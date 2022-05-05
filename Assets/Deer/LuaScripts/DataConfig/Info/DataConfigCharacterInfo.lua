
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-10-13 22-05-22  
---修改作者 : 杜鑫 
---修改时间 : 2021-10-13 22-05-22  
---版 本 : 0.1 
---===============================================
---@class DataConfigCharacterInfo:DataConfigBase
DataConfigCharacterInfo = Class("DataConfigCharacterInfo",DataConfigBase)
function DataConfigCharacterInfo:InitConfigData()
    self._m_listInfo = {};
    self:LoadConfigData(self._m_strName, self._m_strProtoParseName, self._m_strCsvName, self._m_tbConfigPbModule, self._m_strProtoDataListName,function(result)
        local listConfigs = result
        if (not listConfigs) then
            return 0;
        end
        for _, tbInfo in pairs(listConfigs) do
            local strKey = tbInfo.id;
            if (strKey and strKey ~= "") then
                local tbTempInfo = {};
                tbTempInfo.nHero_id = tbInfo.hero_id
                tbTempInfo.tbInit_position = tbInfo.init_position
                tbTempInfo.strHero_prefab_path = tbInfo.hero_prefab_path
                self._m_listInfo[strKey] = tbTempInfo;
            end
        end
    end);
    return 1;
end

function DataConfigCharacterInfo:OnCreate()
    self._m_listLangInfo = nil;
    self._m_nCurLangType = nil;

    self:InitConfigData();
end

return DataConfigCharacterInfo