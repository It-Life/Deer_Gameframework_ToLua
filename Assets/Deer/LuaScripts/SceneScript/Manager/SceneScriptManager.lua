
---================================================
---描 述 :
---作 者 : 杜鑫
---创建时间 : 2021-12-17 07-56-56 
---修改作者 : 杜鑫
---修改时间 : 2021-12-17 07-56-56 
---版 本 : 0.1
---===============================================
---@class SceneScriptManager:SingletonClass
SceneScriptManager = Class("SceneScriptManager",SingletonClass)

function SceneScriptManager:__init()
    self:ClearScript()
    self._onhandleloadscenesuccess = self:RegisterLuaEvent(EventId.EVENT_LUA_LOAD_SCENE_SUCCESS,self.OnHandleLoadSceneSuccess,self)
    Logger.Debug("1212")
end

function SceneScriptManager:__delete()
    self:UnRegisterLuaEvent(EventId.EVENT_LUA_LOAD_SCENE_SUCCESS,self._onhandleloadscenesuccess)
end

function SceneScriptManager:Update()

end

function SceneScriptManager:ClearScript()
    self._m_tbRunStageID = {};--立即执行的脚本阶段
    self._m_strCurScriptName = nil
end

function SceneScriptManager:StartRun()
    ---立即执行的脚本阶段
    if self._m_tbRunStageID ~= nil then
        for nStageID, nTag in pairs(self._m_tbRunStageID) do
            self:DoSceneScript(nStageID)
        end
    end
end

function SceneScriptManager:DoSceneScript(nStageID)
    if self._m_strCurScriptName == nil then
        local tbLevelConfig = GameSceneManager:GetInstance():GetCurrentLevelConfig();
        if tbLevelConfig == nil then
            return;
        end

        self._m_strCurScriptName = tbLevelConfig.strScriptID;--当前关卡脚本名字
    end

    self:DoLevelScriptGroup(self._m_strCurScriptName, nil, nStageID);
end

function SceneScriptManager:DoSceneScriptGroup(strScriptsId, nGroupId, nStartStageID)
    Logger.ColorInfo(ColorType.pink, string.format("执行脚本组，脚本组Id '%s'", strScriptsId));

    local tbScriptListInfo = DataConfigManager:GetInstance():GetConfigInst(DataConfigNames.LevelScriptGroup);
    local tbLevelScriptInfoList =tbScriptListInfo:GetStageInfoById(strScriptsId);
    if (not tbLevelScriptInfoList or not tbLevelScriptInfoList.tbScriptInfos or #tbLevelScriptInfoList.tbScriptInfos == 0) then
        Logger.Error("脚本组是空的  组Id '{0}'", strScriptsId);
        return;
    end

    local bIsComplete = GameActivityManager:GetInstance():GetIsCompleteLevel();
    if (nGroupId) then
        local tempLevelScriptInfoList = {}
        local tbScriptInfos = {}
        for _, tbInfo in pairs(tbLevelScriptInfoList.tbScriptInfos) do
            local nIsRepeat = tbInfo.nIsRepeat;
            --1 通关过这关跳过    0不跳过
            if bIsComplete == false then
                nIsRepeat = 0;
            end

            local tbTempScriptInfo = {
                strScriptName = tbInfo.strScriptName;
                nScriptStage = tbInfo.nScriptStage;
                strREMARK = tbInfo.strREMARK;
                nType = tbInfo.nType;
                bIsRepeat = nIsRepeat == 1;
                nDelayTime = tbInfo.nDelayTime;
                strNum1 = tbInfo.strNum1;
                strNum2 = tbInfo.strNum2;
                strNum3 = tbInfo.strNum3;
                strNum4 = tbInfo.strNum4;
                strNum5 = tbInfo.strNum5;
                strNum6 = tbInfo.strNum6;
                strNextStage = tbInfo.strNextStage;
                nScriptGroupId = nGroupId;
            };
            tbScriptInfos[tbInfo.nScriptStage] = tbTempScriptInfo;
        end
        local tbTempInfo = {
            strScriptName             = tbLevelScriptInfoList.strScriptName,
            tbScriptInfos             = tbScriptInfos,
        };

        tbLevelScriptInfoList = tbTempInfo;
    else
        for _, tbInfo in pairs(tbLevelScriptInfoList.tbScriptInfos) do
            local nIsRepeat = tbInfo.nIsRepeat;
            --1 通关过这关跳过    0不跳过
            if bIsComplete == false then
                nIsRepeat = 0;
            end
            tbInfo.bIsRepeat = nIsRepeat == 1;
            tbInfo.bIsStop = false;
        end
    end

    nStartStageID = nStartStageID or 1;
    self:DoSceneScripts(tbLevelScriptInfoList.tbScriptInfos, nStartStageID);
end

function SceneScriptManager:DoSceneScripts(tbLevelScriptInfos, nStageId)
    local tblevelScriptInfo = tbLevelScriptInfos[nStageId];
    if not tblevelScriptInfo then
        Logger.Warning("脚本表阶段Id 不存在,  阶段: '{0}'", nStageId);
        return;
    end

    local tbClass = LevelScriptTypeConfig[tblevelScriptInfo.nType];
    if (tbClass) then
        if JudgeIsMain(self, tblevelScriptInfo.strScriptName) == true then
            local nIsServer;
            if self._m_tbRunStageID[nStageId] ~= nil then
                nIsServer = self._m_tbRunStageID[nStageId];
                self._m_tbRunStageID[nStageId] = 2;
            elseif self._m_tbServerStage[nStageId] == nil then
                self._m_tbWaitServerStage[nStageId] = tbLevelScriptInfos;
                return;
            else
                nIsServer = self._m_tbServerStage[nStageId];
                self._m_tbServerStage[nStageId] = 2;
            end

            if nIsServer == 1 then
                -- 仅服务器运行脚本,直接执行下一阶段
                Logger.ColorInfo(ColorType.green, nStageId.." 仅服务器运行脚本,直接执行下一阶段");

                if not StringUtil.IsNullOrEmpty(tblevelScriptInfo.strNextStage) then
                    local nextStageIds = StringUtil.SplitToInt(tblevelScriptInfo.strNextStage, '|');
                    for i = 0, nextStageIds.Length-1 do
                        if tblevelScriptInfo.nScriptStage == nextStageIds[i] then
                            Logger.Error("当前脚本阶段Id 与下一个要进入的阶段Id 重复 !!! 表Id : '{0}', 阶段: '{1}'", tblevelScriptInfo.strScriptName, nStageId);
                        else
                            DoLevelScripts(self, tbLevelScriptInfos, nextStageIds[i]);
                        end
                    end
                end
                return;
            elseif nIsServer == 2 then
                return;
            end
        end
        local tbInst = tbClass.New();
        local nScriptId = self:GetScriptId();
        tbInst:SetId(nScriptId);
        self._m_tbActiveScriptList[nScriptId] = tbInst;
        tbInst:Enter(tbLevelScriptInfos, tblevelScriptInfo);
        return tbInst;
    else
        Logger.Error("脚本类型不存在 类型 :'{0}',请在LevelScriptTypeConfig.lua中添加", tblevelScriptInfo.nType);
    end
end

function SceneScriptManager:OnHandleLoadSceneSuccess()
    self:StartRun()
end

return SceneScriptManager