
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-06 07-53-11  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-06 07-53-11  
---版 本 : 0.1 
---===============================================
---@class DataConfigLanguageInfo:DataConfigBase
DataConfigLanguageInfo = Class("DataConfigLanguageInfo",DataConfigBase)

function DataConfigLanguageInfo:InitConfigData()
    self._m_listInfo = {};    
    local listConfigs = self:LoadConfigData(self._m_strName, self._m_strProtoParseName, self._m_strCsvName, self._m_tbConfigPbModule, self._m_strProtoDataListName);
    if (not listConfigs) then
        return 0;
    end
    for _, tbInfo in pairs(listConfigs) do
        local strKey = tbInfo.id;
        if (strKey and strKey ~= "") then
            local tbTempInfo = {};
            tbTempInfo.strEnglish = tbInfo.english
            tbTempInfo.strSChinese = tbInfo.schinese
            self._m_listInfo[strKey] = tbTempInfo; 
        end
    end
    return 1;
end

function DataConfigLanguageInfo:OnCreate()
    self._m_listInfo = nil;
    self._m_nCurLangType = LanguageTypeEnum.Chinese;
    self:InitConfigData();
end

function DataConfigLanguageInfo:OnDestroy()
    self._m_listInfo = nil;
    self._m_nCurLangType = nil;
end

function DataConfigLanguageInfo:GetLanguageConfigList()
    return self._m_listInfo;
end

function DataConfigLanguageInfo:GetText(strKey)    
    if (not self._m_listInfo) then        
        return strKey;
    end
    local getText = function(tbInfo)
        if (self._m_nCurLangType == LanguageTypeEnum.Chinese) then
            return tbInfo.strChinese;
        elseif (self._m_nCurLangType == LanguageTypeEnum.English) then
            return tbInfo.strEnglish;
        end
        return ""
    end
    local tbInfo = self._m_listInfo[strKey];
    if (not tbInfo) then
        local tbLoaclInfo = LanguageId[strKey]
        if tbLoaclInfo then
            if string.isnullorempty(tbLoaclInfo.id) then
                if not string.isnullorempty(tbLoaclInfo.desc) then
                    return "*" .. tbLoaclInfo.desc
                end
            else
                tbInfo = self._m_listInfo[tbLoaclInfo.id]
                if not tbInfo then
                    return "*" .. tbLoaclInfo.desc
                end
            end
        end
    end
    local text = getText(tbInfo);
    if not string.isnullorempty(text) then
        return text
    end
    return "*" ..  strKey
end

return DataConfigLanguageInfo