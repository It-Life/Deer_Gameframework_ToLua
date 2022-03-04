
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

--[[
    tbShowUIInfo =
    {
        ---@field enumGroup 不传默认为 UIFormGroupType.Group1
        enumGroup = UIFormGroupType.Group1 or nil, 
    }
]]
function UIManager:CreateForm(strUIName,tbShowUIInfo)
    self:InstantiatedUI(strUIName,tbShowUIInfo)
end

function UIManager:CloseForm(strUIName)
    for enumGroup,tbGroup in pairs(self._listUIForms) do
        for strUINameKey,ui in pairs(tbGroup) do
            if strUIName == strUINameKey then
                local gameObject = ui.gameObject
                if gameObject then
                    GameObject.Destroy(gameObject)
                end
                ui.Delete()
                ui:OnDestroy()
                tbGroup[strUINameKey] = nil
            end
        end
    end
end

function UIManager:InstantiatedUI(strUIName,tbShowUIInfo)
    local _strUIPrefabPath = UIPrefabPathConfig[strUIName]
    if not _strUIPrefabPath then
        return
    end
    self._nLoadSerial = self._nLoadSerial + 1;
    _strUIPrefabPath = LuaGameUtils.GetUIPrefabPath(_strUIPrefabPath)
    
    local tbLoadAssetInfo = {
        strUIName = strUIName,
        strUIPrefabPath = _strUIPrefabPath,
        tbShowUIInfo = tbShowUIInfo or {}
    };
    self._listLoadFormShowInfo[self._nLoadSerial] = tbLoadAssetInfo;
    GameEntry.UI:LoadAssetAsync(self._nLoadSerial, _strUIPrefabPath, strUIName);
end

function UIManager:LoadUIFormSuccessCallback(goPrefab,serialId)
    local tbLoadAssetInfo = self._listLoadFormShowInfo[serialId]
    if not tbLoadAssetInfo then
        return false
    end
    local transDeerGFRoot = GameObject.Find("DeerGF").transform
    if not transDeerGFRoot then
        return false
    end
    local uiNode = transDeerGFRoot:Find("Customs/UI/UIRoot")
    if not uiNode then
        return false
    end
    local strUIName = tbLoadAssetInfo.strUIName
    local enumGroup = tbLoadAssetInfo.tbShowUIInfo.enumGroup or UIFormGroupType.Group1
    self._listUIForms[enumGroup] = self._listUIForms[enumGroup] or {}

    if self._listUIForms[enumGroup][strUIName] then
        local gameObject = self._listUIForms[enumGroup][strUIName].gameObject
        if gameObject then
            GameObject.Destroy(gameObject)
        end
        self._listUIForms[enumGroup][strUIName] = nil
    end
    
    local transUIGroup = self:CreateGroup(enumGroup,uiNode).transform
    local gameObject = GameObject.Instantiate(goPrefab,transUIGroup);
    local ui = self:BindLuaScript(gameObject)
    ui.gameObject.name = serialId .. ":" .. enumGroup .. ":" .. strUIName
    ui.transform.localScale = Vector3(1,1,1)
    ui.name = strUIName
    local canvas = GObjUtils.GetOrAddComponent(gameObject,typeof(Canvas))
    canvas.overrideSorting = true
    canvas.sortingOrder = table.total(self._listUIForms[enumGroup])
    local graphicRaycaster = GObjUtils.GetOrAddComponent(gameObject,typeof(GraphicRaycaster))
    ui.canvas = canvas
    ui.graphicRaycaster = graphicRaycaster
    if ui.uIComponentBinder then
        ui.uIComponentBinder:BindLua(ui)
    end
    ui:OnAwake()
    ui:OnEnable()
    ui:OnStart()
    self._listUIForms[enumGroup][strUIName] = ui
--[[    if strUIName == "UIMainHallPanel" then
        LuaGameEntry.UI:CloseUI(ui)
    end]]
    return true
end

function UIManager:BindLuaScript(gameObject,uiScript)
    if GObjUtils.IsNull(gameObject) then
        return
    end
    local uIComponentBinder = gameObject.transform:GetComponent(typeof(UIComponentBinder))
    if not uIComponentBinder then
        return
    end
    local ui = uiScript
    if not ui then
        local filePath = uIComponentBinder.filePath
        local scriptPath = LuaGameUtils.GetLuaUIScriptPath(filePath)
        ui = require(scriptPath)
        ui = ui.New()
    end
    ui.go = gameObject
    ui.gameObject = gameObject
    ui.transform = gameObject.transform
    ui.uIComponentBinder = uIComponentBinder
    return ui
end

function UIManager:BindUIUnit(gameObject,unitScript)
    local ui = self:BindLuaScript(gameObject,unitScript)
    if ui.uIComponentBinder then
        ui.uIComponentBinder:BindLua(ui)
    end
    ui:OnAwake()
    ui:OnEnable()
    ui:OnStart()
    return ui
end

function UIManager:CreateGroup(enumGroup,uiNode)
    local goGroup = self._listUIGroups[enumGroup]
    if not goGroup then
        local strGroupName = "Group" .. enumGroup
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
        GameEntry.UI:Unspwn(goPrefab);
    end
    return nil
end

function UIManagerHelper.LoadUIFormFailureCallback(serialId)
    UIManager:GetInstance():LoadUIFormFailureCallback(serialId)
    return nil
end

return UIManager