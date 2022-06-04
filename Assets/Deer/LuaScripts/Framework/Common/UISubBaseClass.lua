
---================================================
---描 述 :  
---作 者 :杜鑫
---创建时间 : 2021-07-04 23-20-18
---修改作者 :杜鑫
---修改时间 : 2021-07-04 23-20-18
---版 本 :0.1
---===============================================
---@class UISubBaseClass:BaseClass
UISubBaseClass = Class("UISubBaseClass",BaseClass)

---析构函数

---@function __init 构造
function UISubBaseClass:__init()
    self.gameObject = nil
    self.transform = nil
    self.m_Available = false
    self.m_Visible = false
    self.m_parent = nil
end
---@function __delete 析构调用
function UISubBaseClass:__delete()
    self.gameObject = nil
    self.transform = nil
    self.m_Available = false
    self.m_Visible = false
    self.m_parent = nil
end

--- 重写函数
---@function OnShow 主动调用
function UISubBaseClass:OnShow()
    self.m_Available = true;
    self:SetVisible(true);
end

---@function OnHide 主动调用
function UISubBaseClass:OnHide()
    self:SetVisible(false);
    self.m_Available = false;
end

function UISubBaseClass:GetParent()
    return self.m_parent
end

function UISubBaseClass:SetParent(value)
    self.m_parent = value
end

--不可重写函数
function UISubBaseClass:GetName()
    if not GObjUtils.IsNull(self.gameObject) then
        return self.gameObject.name
    end
    return ""
end

---获取界面是否可用
function UISubBaseClass:Available()
    return self.m_Available
end
---获取或设置界面是否可见
function UISubBaseClass:GetVisible()
    return self.m_Available and self.m_Visible
end

---获取或设置界面是否可见
function UISubBaseClass:SetVisible(value)
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

function UISubBaseClass:InternalSetVisible(value)
    self.gameObject:SetActive(value)
end

return UISubBaseClass