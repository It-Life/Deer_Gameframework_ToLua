
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-12 22-40-58  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-12 22-40-58  
---版 本 : 0.1 
---===============================================
---@class UIManager:SingletonClass
UIManager = Class("UIManager",SingletonClass)

closeUIType = 
{
    hide = 1,
    destroy = 2,
}
-- 变量定义
function UIManager:__init(...)
    self._listUIForms = {}
    self._listUIGroups = {}
    self._lastPanelGroup = 1
    self._lastPanel = nil
    self._nLoadSerial = 0
    self._listLoadFormShowInfo = {}
    self._uiRoot = nil
    self._uiStack = Stack.New()
end

function UIManager:__delete(...)
    
end

function UIManager:GetCurUIStack()
    if not self._uiStack then
        self._uiStack = Stack.New()
    end
    return self._uiStack
end

function UIManager:GetUIRoot()
    if self._uiRoot == nil then
        local transDeerGFRoot = GameObject.Find("DeerGF").transform
        self._uiRoot = transDeerGFRoot:Find("Customs/UI/UIRoot")
        return self._uiRoot
    else
        return self._uiRoot
    end
end

function UIManager:HasUIForm(serialId)
    for enumGroup,tbGroup in pairs(self._listUIForms) do
        for _serialId,ui in pairs(tbGroup) do
            if _serialId == serialId then
                return true
            end
        end
    end
    return false
end

function UIManager:GetUIForm(serialId)
    for enumGroup,tbGroup in pairs(self._listUIForms) do
        for _serialId,ui in pairs(tbGroup) do
            if _serialId == serialId then
                return ui
            end
        end
    end
    return nil
end

function UIManager:GetUIForm(strUIConfig)
    local strUIName = strUIConfig.name
    for enumGroup,tbGroup in pairs(self._listUIForms) do
        for _serialId,ui in pairs(tbGroup) do
            local strUINameKey = ui.name
            if strUIName == strUINameKey then
                return ui
            end
        end
    end
    return nil
end

---@param strUIConfig UINameConfig
---@param userData any
---@param results function
function UIManager:CloseForm(strUIConfig,userData,results)
    local strUIName = strUIConfig.name
    for enumGroup,tbGroup in pairs(self._listUIForms) do
        for _serialId,ui in pairs(tbGroup) do
            local strUINameKey = ui.name
            if strUIName == strUINameKey then
                ui:OnHide(userData)
                self:Unspawn(ui.gameObject)
                ui.gameObject = nil
                if results then
                    results(true,ui.serialId)
                end
                tbGroup[ui.serialId] = nil
                ui = nil
                self:RefreshOtherGroup()
                return
            end
        end
    end
    if results then
        results(false)
    end
end

---@param serialId number
---@param userData any
---@param results function
function UIManager:CloseFormById(serialId,userData,results)
    for enumGroup,tbGroup in pairs(self._listUIForms) do
        for _serialId,ui in pairs(tbGroup) do
            if _serialId == serialId then
                ui:OnHide(userData)
                self:Unspawn(ui.gameObject)
                ui.gameObject = nil
                if results then
                    results(true,ui.serialId)
                end
                tbGroup[ui.serialId] = nil
                ui = nil
                self:RefreshOtherGroup()
                return
            end
        end
    end
    if results then
        results(false)
    end
end

function UIManager:RefreshOtherGroup()
    local olnyHaveMain = true
    for enumGroup,tbGroup in pairs(self._listUIForms) do
        for _serialId,ui in pairs(tbGroup) do
            if ui:GetVisible() and enumGroup ~= UIFormGroupType.Background.name  then
                olnyHaveMain =false
            end
        end
    end
    if olnyHaveMain then
        GameEntry.Camera.DisFreeLookCameraRotation = false
    else
        GameEntry.Camera.DisFreeLookCameraRotation = true
    end
end

---@param serialId number
---@param userData any
---@param results function
function UIManager:CloseFormByGroup(enumGroup,userData,results)
    for enumGroupName,tbGroup in pairs(self._listUIForms) do
        if enumGroupName == enumGroup.name then
            for _serialId,ui in pairs(tbGroup) do
                ui:OnHide(userData)
                self:Unspawn(ui.gameObject)
                ui.gameObject = nil
                if results then
                    results(true,ui.serialId)
                end
                tbGroup[ui.serialId] = nil
                ui = nil
            end
        end
    end
    self:RefreshOtherGroup()
    if results then
        results(true)
    end
end



function UIManager:ReleaseUIFormCallback(serialId)

end

function UIManager:CanOpenMorePanel(enumGroup)
    if enumGroup.name == UIFormGroupType.PopUI.name then
        return true
    end
    return false
end

---@param strUIConfig UINameConfig
---@param userData any
function UIManager:CreateForm(strUIConfig,userData,results)
    local strUIName = strUIConfig.name
    local _strUIPrefabPath = UIPrefabPathConfig[strUIName]
    if not _strUIPrefabPath then
        return
    end

    local enumGroup = strUIConfig.group or UIFormGroupType.Common
    local enumGroupName = enumGroup.name

    local _loadAssetAsync = function()
        self._nLoadSerial = self._nLoadSerial + 1;
        _strUIPrefabPath = LuaGameUtils.GetUIPrefabPath(_strUIPrefabPath)
        local tbLoadAssetInfo = {
            strUIPrefabPath = _strUIPrefabPath,
            strUIConfig = strUIConfig,
            userData = userData or {},
            openUIComplete = results
        };
        self._listLoadFormShowInfo[self._nLoadSerial] = tbLoadAssetInfo;
        GameEntry.UI:LoadAssetAsync(self._nLoadSerial, _strUIPrefabPath, strUIName);
    end
    if self:CanOpenMorePanel(enumGroup) then
        _loadAssetAsync()
    else
        local ui  = self:GetUIForm(strUIConfig)
        if ui then
            if ui:GetVisible() then
                return
            else
                ui:OnShow()
                if results then
                    results(true,ui.serialId)
                end
            end
        else
            _loadAssetAsync()
        end
    end
end

function UIManager:LoadUIFormSuccessCallback(assetObj,serialId,isPool)
    local tbLoadAssetInfo = self._listLoadFormShowInfo[serialId]
    if not tbLoadAssetInfo then
        return false
    end
    local uiNode = self:GetUIRoot()
    local strUIName = tbLoadAssetInfo.strUIConfig.name
    local enumGroup = tbLoadAssetInfo.strUIConfig.group or UIFormGroupType.Common
    local enumGroupName = enumGroup.name
    self._listUIForms[enumGroupName] = self._listUIForms[enumGroupName] or {}
    if self._listUIForms[enumGroupName][serialId] then
        local gameObject = self._listUIForms[enumGroupName][serialId].gameObject
        if not GObjUtils.IsNull(gameObject) then
            self:Unspawn(gameObject)
        end
        self._listUIForms[enumGroupName][serialId] = nil
    end
    local transUIGroup = self:CreateGroup(enumGroup,uiNode).transform
    local ui = self:CreateLuaUI(assetObj,transUIGroup,enumGroup)
    if ui then
        ui.serialId = serialId
        ui.gameObject.name = strUIName
        ui.name = strUIName
        ui:OnShow(tbLoadAssetInfo.userData)
        if tbLoadAssetInfo.openUIComplete then
            tbLoadAssetInfo.openUIComplete(true,serialId)
        end
        --更新group
        self:RefreshGroup(enumGroup)
        self._listUIForms[enumGroupName][serialId] = ui
        self:RefreshOtherGroup()
        return true
    else
        if tbLoadAssetInfo.openUIComplete then
            tbLoadAssetInfo.openUIComplete(false,serialId)
        end
    end
    return false
end

function UIManager:RefreshGroup(enumGroup)
    local enumGroupName = enumGroup.name
    if enumGroupName == UIFormGroupType.Background.name then
        self:CloseFormByGroup(UIFormGroupType.Background)
        self:CloseFormByGroup(UIFormGroupType.Common)
    elseif enumGroupName == UIFormGroupType.Common.name then
        self:CloseFormByGroup(UIFormGroupType.Common)
    end
end

function UIManager:CreateLuaUI(ObjInstance,transUIGroup,enumGroup)
    local gameObject = ObjInstance
    gameObject.transform:SetParent(transUIGroup)
    gameObject.transform.localScale = Vector3(1,1,1)
    gameObject.transform.localPosition = Vector3(0,0,table.total(self._listUIForms[enumGroup.name])*100)
    local rect = gameObject:GetComponent(typeof(RectTransform))
    rect.anchorMin = Vector2(0,0)
    rect.anchorMax = Vector2(1,1)
    rect.offsetMin = Vector2(0,0)
    rect.offsetMax = Vector2(0,0)
    local canvas = GObjUtils.GetOrAddComponent(gameObject,typeof(Canvas))
    canvas.overrideSorting = true
    local goGroup = self._listUIGroups[enumGroup.name]
    local canvasComp = GObjUtils.GetOrAddComponent(goGroup,typeof(Canvas))
    canvas.sortingOrder = canvasComp.sortingOrder + table.total(self._listUIForms[enumGroup.name])
    local graphicRaycaster = GObjUtils.GetOrAddComponent(gameObject,typeof(GraphicRaycaster))
    local ui = self:BindLuaScript(gameObject)
    ui.canvas = canvas
    ui.graphicRaycaster = graphicRaycaster
    if ui.componentBinder then
        ui.componentBinder:BindLua(ui)
    end
    return ui
end

function UIManager:CreateUISubPanel(gameObject)
    local ui = self:BindLuaScript(gameObject)
    if ui.componentBinder then
        ui.componentBinder:BindLua(ui)
    end
    ui:OnShow()
    return ui
end

function UIManager:CreateUIUnit(gameObject,unitScript)
    local ui = self:BindLuaScript(gameObject,unitScript)
    if ui.componentBinder then
        ui.componentBinder:BindLua(ui)
    end
    ui:OnShow()
    return ui
end

function UIManager:DestroyUIUnit(ui)
    if ui and ui.Destroy ~=nil then
        ui:OnHide()
        UnityEngine.Object.Destroy(ui.gameObject)
    end
end

function UIManager:BindLuaScript(gameObject,uiScript)
    if GObjUtils.IsNull(gameObject) then
        return
    end
    local componentBinder = gameObject.transform:GetComponent(typeof(ComponentBinder))
    if not componentBinder then
        return
    end
    local ui = uiScript
    if not ui then
        local filePath = componentBinder.filePath
        local scriptPath = LuaGameUtils.GetLuaUIScriptPath(filePath)
        ui = require(scriptPath)
        ui = ui.New()
    end
    ui.go = gameObject
    ui.gameObject = gameObject
    ui.transform = gameObject.transform
    ui.componentBinder = componentBinder
    return ui
end

function UIManager:Unspawn(objAsset)
    GameEntry.UI:Unspawn(objAsset)
end

function UIManager:CreateGroup(enumGroup,uiNode)
    local enumGroupName = enumGroup.name
    local sortingOrder = enumGroup.sortingOrder
    local goGroup = self._listUIGroups[enumGroupName]
    if not goGroup then
        local strGroupName = "UI Group " .. enumGroupName
        goGroup = GameObject.New(strGroupName)
        goGroup.transform:SetParent(uiNode)
        goGroup.transform.localPosition = Vector3(0,0,-(sortingOrder*1000))
        local canvasComp = GObjUtils.GetOrAddComponent(goGroup,typeof(Canvas))
        canvasComp.overrideSorting = true
        canvasComp.sortingOrder = sortingOrder * 100
        GObjUtils.GetOrAddComponent(goGroup,typeof(GraphicRaycaster))
        local rect = goGroup:GetComponent(typeof(RectTransform))
        rect.localScale = Vector3(1,1,1)
        rect.anchorMin = Vector2(0,0)
        rect.anchorMax = Vector2(1,1)
        rect.offsetMin = Vector2(0,0)
        rect.offsetMax = Vector2(0,0)
        self._listUIGroups[enumGroupName] = goGroup
    end
    return goGroup
end

function UIManager:LoadUIFormFailureCallback(serialId)
    print("serialId"..serialId)
end

UIManagerHelper = {}
function UIManagerHelper.LoadUIFormSuccessCallback(goPrefab,serialId,isPool)
    local bIsSuccess = UIManager:GetInstance():LoadUIFormSuccessCallback(goPrefab,serialId,isPool)
    if not bIsSuccess then
        -- 如果没有任何inst资源，需要卸载资源
        self:Unspawn(goPrefab)
    end
    return nil
end

function UIManagerHelper.LoadUIFormFailureCallback(serialId)
    UIManager:GetInstance():LoadUIFormFailureCallback(serialId)
    return nil
end

function UIManagerHelper.ReleaseUIFormCallback(serialId)
    UIManager:GetInstance():ReleaseUIFormCallback(serialId)
    return nil
end

return UIManager