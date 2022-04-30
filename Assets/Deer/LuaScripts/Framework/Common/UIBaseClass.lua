
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-04 23-20-18  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-04 23-20-18  
---版 本 : 0.1 
---===============================================
---@class UIBaseClass :BaseClass
UIBaseClass = Class("UIBaseClass",BaseClass)

---@function __init  构造函数
---调用父类 self.super.__init(self)
function UIBaseClass:__init()
    self.gameObject = nil
    self.transform = nil
    self.m_Available = false
    self.m_Visible = false
    self.m_tbUnit = {}
end
---@function __delete 析构函数
---调用父类 self.super.__delete(self)
function UIBaseClass:__delete()
    self.gameObject = nil
    self.transform = nil
    self.m_Available = false
    self.m_Visible = false
    self.m_tbUnit = {}
end

--- 重写函数
---@function OnAwake 主动调用
function UIBaseClass:OnAwake()
    self.m_Available = true;
    self:SetVisible(true);
end

---@function OnEnter 界面不销毁 重新进入调用
function UIBaseClass:OnEnable()

end

---@function OnStart 主动调用
function UIBaseClass:OnStart()

end

---@function OnDisable 界面不销毁 隐藏时调用
function UIBaseClass:OnDisable()
    self:SetVisible(false);
    self.m_Available = false;
end

--@function OnDestroy 界面销毁时候调用
function UIBaseClass:OnDestroy()

end

--不可重写函数
function UIBaseClass:Close()
    LuaGameEntry.UI:CloseUI()
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

function UIBaseClass:CreateUIUnit()

end

return UIBaseClass