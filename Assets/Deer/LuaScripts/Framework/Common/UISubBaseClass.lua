
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-04 23-20-18  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-04 23-20-18  
---版 本 : 0.1 
---===============================================
---@class UISubBaseClass:BaseClass
UISubBaseClass = Class("UISubBaseClass",BaseClass)

---析构函数

---@function __init 析构调用
---调用父类 self.super.__init(self)
function UISubBaseClass:__init()
    print(self.name)
    print("---")
end
---@function __delete 析构调用
---调用父类 self.super.__delete(self)
function UISubBaseClass:__delete()
    print(self.name)
    print("---")
end

--- 重写函数
---@function OnAwake 主动调用
function UISubBaseClass:OnAwake()

end

---@function OnEnter 界面不销毁 重新进入调用
function UISubBaseClass:OnEnable()

end

---@function OnStart 主动调用
function UISubBaseClass:OnStart()

end

---@function OnDisable 界面不销毁 隐藏时调用
function UISubBaseClass:OnDisable()

end

--@function OnDestroy 界面销毁时候调用
function UISubBaseClass:OnDestroy()

end

--不可重写函数


return UISubBaseClass