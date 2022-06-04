
---================================================
---描 述 :  
---作 者 :杜鑫
---创建时间 : 2021-07-04 23-20-18
---修改作者 :杜鑫
---修改时间 : 2021-07-04 23-20-18
---版 本 :0.1
---===============================================
---@class UIBaseClass :BaseClass
UIBaseClass = Class("UIBaseClass",BaseClass)

---@function __init  构造函数
function UIBaseClass:__init()
    self.gameObject = nil
    self.transform = nil
    self.m_Available = false
    self.m_Visible = false
    self.serialId = 0
    self.m_tbSubPanel = {}
    self.m_tbPanelUnit = {}
end
---@function __delete 析构函数
function UIBaseClass:__delete()
    self.gameObject = nil
    self.transform = nil
    self.m_Available = false
    self.m_Visible = false
    self.serialId = nil
    for k,v in pairs(self.m_tbSubPanel) do
        if v.uiClass and v.uiClass.gameObject then
            UnityEngine.GameObject.Destroy(v.uiClass.gameObject)
        end
    end
    self.m_tbSubPanel = nil
    self.m_tbPanelUnit = nil
end

--- 重写函数
---@function OnShow 主动调用
function UIBaseClass:OnShow()
    self.m_Available = true;
    self:SetVisible(true);
end

---@function OnEnter 界面不销毁 重新进入调用
function UIBaseClass:OnHide()
    self:SetVisible(false);
    self.m_Available = false;
end

--不可重写函数
function UIBaseClass:Close()
    LuaGameEntry.UI:CloseUIById(self.serialId)
end

function UIBaseClass:GetName()
    if not GObjUtils.IsNull(self.gameObject) then
        return self.gameObject.name
    end
    return ""
end
function UIBaseClass:SetName(value)
    if not GObjUtils.IsNull(self.gameObject) then
        self.gameObject.name = value
    end
end
---获取界面是否可用
function UIBaseClass:Available()
    return self.m_Available
end
---获取或设置界面是否可见
function UIBaseClass:GetVisible()
    return self.m_Available and self.m_Visible
end
---获取或设置界面是否可见
function UIBaseClass:SetVisible(value)
    if not self.m_Available then
        Logger.Warning(string.format("UI form %s is not available.",self:GetName()))
        return;
    end
    if self.m_Visible == value then
        return
    end
    self.m_Visible = value
    self:InternalSetVisible(value)
end

function UIBaseClass:InternalSetVisible(value)
    self.gameObject:SetActive(value)
end
---@param name string
---@param subPanelNode UnityEngine.GameObject
function UIBaseClass:OpenSubPanel(name,subPanelNode)
    if not self.m_tbSubPanel then
        Logger.Error(string.format("this %s view doesn't have table name is %s.",self:GetName(),name))
        return
    end
    if not self.m_tbSubPanel[name] then
        Logger.Error(string.format("this %s view doesn't have subPanel name is %s.",self:GetName(),name))
        return
    end
    if GObjUtils.IsNull(self.m_tbSubPanel[name].object) then
        Logger.Error(string.format("this %s view have subPanel object is null, name is %s.",self:GetName(),name))
        return
    end
    if GObjUtils.IsNull(subPanelNode) and GObjUtils.IsNull(self.m_tbSubPanel[name].subPanelNode) then
        Logger.Error(string.format("this %s view have subPanel node is null, name is %s.",self:GetName(),name))
        return
    end
    local ui
    if self.m_tbSubPanel[name].uiClass then
        self.m_tbSubPanel[name].uiClass:OnShow()
        ui = self.m_tbSubPanel[name].uiClass
    else
        local _subPanelNode = nil
        if subPanelNode then
            _subPanelNode = subPanelNode
        else
            _subPanelNode = self.m_tbSubPanel[name].subPanelNode
        end

        local objInstance = GameObject.Instantiate(self.m_tbSubPanel[name].object)
        ui = LuaGameEntry.UI:BindUISubPanel(objInstance)
        ui:SetParent(self)
        ui.transform:SetParent(_subPanelNode.transform)
        ui.transform.localScale = Vector3(1,1,1)
        ui.transform.localPosition = Vector3(0,0,0)
        local rect = ui.gameObject:GetComponent(typeof(RectTransform))
        rect.anchorMin = Vector2(0,0)
        rect.anchorMax = Vector2(1,1)
        rect.offsetMin = Vector2(0,0)
        rect.offsetMax = Vector2(0,0)
        self.m_tbSubPanel[name].uiClass = ui
    end
    return ui
end

function UIBaseClass:CloseSubPanel(name)
    if not self.m_tbSubPanel then
        Logger.Error(string.format("this %s view doesn't have table name is %s.",self:GetName(),name))
        return
    end
    if not self.m_tbSubPanel[name] then
        Logger.Error(string.format("this %s view doesn't have subPanel name is %s.",self:GetName(),name))
        return
    end
    if not self.m_tbSubPanel[name].uiClass then
        Logger.Error(string.format("this %s view doesn't have subPanel class name is %s.",self:GetName(),name))
        return
    end
    self.m_tbSubPanel[name].uiClass:OnHide()
end

function UIBaseClass:GetSubPanelIsVisible(name)
    if not self.m_tbSubPanel then
        Logger.Error(string.format("this %s view doesn't have table name is %s.",self:GetName(),name))
        return false
    end
    if not self.m_tbSubPanel[name] then
        Logger.Error(string.format("this %s view doesn't have subPanel name is %s.",self:GetName(),name))
        return false
    end
    if not self.m_tbSubPanel[name].uiClass then
        Logger.Error(string.format("this %s view doesn't have subPanel class name is %s.",self:GetName(),name))
        return false
    end
    return self.m_tbSubPanel[name].uiClass:GetVisible()
end

function UIBaseClass:CreateUIUnit(name)
    if not self.m_tbPanelUnit then
        Logger.Error(string.format("this %s view doesn't have table name is %s.",self:GetName(),name))
        return
    end
    if not self.m_tbPanelUnit[name] then
        Logger.Error(string.format("this %s view doesn't have unit name is %s.",self:GetName(),name))
        return
    end
    if GObjUtils.IsNull(self.m_tbPanelUnit[name].object) then
        Logger.Error(string.format("this %s view have unit object is null, name is %s.",self:GetName(),name))
        return
    end
    return self.m_tbPanelUnit[name].object
end
---实例化所有的子界面
function UIBaseClass:__InstantiationAllSubPanel(name,object,subPanelNode)
    self.m_tbSubPanel[name] = {object = object,subPanelNode = subPanelNode}
end
---实例化所有的界面单位
function UIBaseClass:__InstantiationAllPanelUnit(name,object)
    self.m_tbPanelUnit[name] = {object = object}
end

return UIBaseClass