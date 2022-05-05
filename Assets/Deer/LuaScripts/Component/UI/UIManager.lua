
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

function UIManager:GetGroups()

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

---@param strUIConfig UINameConfig
---@param userData any
---@param results function
function UIManager:CloseForm(strUIConfig,userData,results)
    local strUIName = strUIConfig.name
    for enumGroup,tbGroup in pairs(self._listUIForms) do
        for _serialId,ui in pairs(tbGroup) do
            local strUINameKey = ui.name
            if strUIName == strUINameKey then
                ui:OnDisable(userData)
                self:Unspawn(ui.gameObject)
                ui.gameObject = nil
                if results then
                    results(true,ui.serialId)
                end
                ui = nil
                tbGroup[_serialId] = nil
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
                ui:OnDisable(userData)
                self:Unspawn(ui.gameObject)
                ui.gameObject = nil
                if results then
                    results(true,ui.serialId)
                end
                ui = nil
                tbGroup[serialId] = nil
            end
        end
    end
    if results then
        results(false)
    end
end

---@param strUIConfig UINameConfig
---@param userData any
function UIManager:CreateForm(strUIConfig,userData,results)
    local strUIName = strUIConfig.name
    local _strUIPrefabPath = UIPrefabPathConfig[strUIName]
    if not _strUIPrefabPath then
        return
    end
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

function UIManager:LoadUIFormSuccessCallback(assetObj,serialId)
    local tbLoadAssetInfo = self._listLoadFormShowInfo[serialId]
    if not tbLoadAssetInfo then
        return false
    end
    local uiNode = self:GetUIRoot()
    local strUIName = tbLoadAssetInfo.strUIConfig.name
    local enumGroup = tbLoadAssetInfo.strUIConfig.group or UIFormGroupType.Common
    self._listUIForms[enumGroup] = self._listUIForms[enumGroup] or {}
    if self._listUIForms[enumGroup][serialId] then
        local gameObject = self._listUIForms[enumGroup][serialId].gameObject
        if not GObjUtils.IsNull(gameObject) then
            self:Unspawn(gameObject)
        end
        self._listUIForms[enumGroup][serialId] = nil
    end
    local transUIGroup = self:CreateGroup(enumGroup,uiNode).transform
    local ui = self:CreateLuaUI(assetObj,transUIGroup,enumGroup)
    if ui then
        ui.serialId = serialId
        ui.gameObject.name = strUIName
        ui.name = strUIName
        ui:OnAwake(tbLoadAssetInfo.userData)
        ui:OnEnable(tbLoadAssetInfo.userData)
        ui:OnStart(tbLoadAssetInfo.userData)
        self._listUIForms[enumGroup][serialId] = ui
        if tbLoadAssetInfo.openUIComplete then
            tbLoadAssetInfo.openUIComplete(true,serialId)
        end
        return true
    else
        if tbLoadAssetInfo.openUIComplete then
            tbLoadAssetInfo.openUIComplete(false,serialId)
        end
    end
    return false
end

function UIManager:CreateLuaUI(ObjInstance,transUIGroup,enumGroup)
    local gameObject = ObjInstance
    gameObject.transform:SetParent(transUIGroup)
    gameObject.transform.localScale = Vector3(1,1,1)
    gameObject.transform.localPosition = Vector3(0,0,0)
    local rect = gameObject:GetComponent(typeof(RectTransform))
    rect.anchorMin = Vector2(0,0)
    rect.anchorMax = Vector2(1,1)
    rect.offsetMin = Vector2(0,0)
    rect.offsetMax = Vector2(0,0)
    local canvas = GObjUtils.GetOrAddComponent(gameObject,typeof(Canvas))
    canvas.overrideSorting = true
    canvas.sortingOrder = table.total(self._listUIForms[enumGroup])
    local graphicRaycaster = GObjUtils.GetOrAddComponent(gameObject,typeof(GraphicRaycaster))
    local ui = self:BindLuaScript(gameObject)
    ui.canvas = canvas
    ui.graphicRaycaster = graphicRaycaster
    if ui.componentBinder then
        ui.componentBinder:BindLua(ui)
    end
    return ui
end

function UIManager:CreateUIUnit(gameObject,unitScript)
    local ui = self:BindLuaScript(gameObject,unitScript)
    if ui.componentBinder then
        ui.componentBinder:BindLua(ui)
    end
    ui:OnAwake()
    ui:OnEnable()
    ui:OnStart()
    return ui
end

function UIManager:DestroyUIUnit(ui)
    if ui and ui.Destroy ~=nil then
        ui:OnDestroy()
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
    local goGroup = self._listUIGroups[enumGroup]
    if not goGroup then
        local strGroupName = "UI Group" .. enumGroup
        goGroup = GameObject.New(strGroupName)
        goGroup.transform:SetParent(uiNode)
        goGroup.transform.localPosition = Vector3(0,0,0)
        local canvasComp = GObjUtils.GetOrAddComponent(goGroup,typeof(Canvas))
        canvasComp.overrideSorting = true
        canvasComp.sortingOrder = enumGroup * 100
        GObjUtils.GetOrAddComponent(goGroup,typeof(GraphicRaycaster))
        local rect = goGroup:GetComponent(typeof(RectTransform))
        rect.localScale = Vector3(1,1,1)
        rect.anchorMin = Vector2(0,0)
        rect.anchorMax = Vector2(1,1)
        rect.offsetMin = Vector2(0,0)
        rect.offsetMax = Vector2(0,0)
        self._listUIGroups[enumGroup] = goGroup
    end
    return goGroup
end

function UIManager:LoadUIFormFailureCallback(serialId)
    print("serialId"..serialId)
end

UIManagerHelper = {}
function UIManagerHelper.LoadUIFormSuccessCallback(goPrefab,serialId)
    local bIsSuccess = UIManager:GetInstance():LoadUIFormSuccessCallback(goPrefab,serialId)
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

return UIManager