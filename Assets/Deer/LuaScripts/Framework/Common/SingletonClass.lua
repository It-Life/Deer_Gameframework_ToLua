
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-04 23-26-34 
---修改作者 : 杜鑫
---修改时间 : 2021-07-04 23-26-34 
---版 本 : 0.1
---===============================================
---@class SingletonClass:BaseClass
SingletonClass = Class("SingletonClass",BaseClass)

function SingletonClass:__init(...)
    assert(rawget(self._class_type, "Instance") == nil, self._class_type.__cname.." to create singleton twice!")
    rawset(self._class_type, "Instance", self)
end

function SingletonClass:__delete(...)
    self.Instance = nil
end

--@return SingletonClass
function SingletonClass:GetInstance()
    if rawget(self, "Instance") == nil then
        rawset(self, "Instance", self.New())
    end
    assert(self.Instance ~= nil)
    return self.Instance
end

return SingletonClass
