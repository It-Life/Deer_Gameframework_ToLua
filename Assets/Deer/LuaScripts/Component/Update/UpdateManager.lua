
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-12 00-05-08  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-12 00-05-08  
---版 本 : 0.1 
---===============================================
---@class UpdateManager:SingletonClass
UpdateManager = Class("UpdateManager",SingletonClass)

function UpdateManager:__init()
    self.__update_timer = {}
    self.__lateupdate_timer = {}
    self.__fixedupdate_timer = {}
    self.__update_handle = UpdateBeat:CreateListener(self.UpdateHandle, self)
    self.__lateupdate_handle = LateUpdateBeat:CreateListener(self.LateUpdateHandle, self)
    self.__fixedupdate_handle = FixedUpdateBeat:CreateListener(self.FixedUpdateHandle, self)
    UpdateBeat:AddListener(self.__update_handle)
    LateUpdateBeat:AddListener(self.__lateupdate_handle)
    FixedUpdateBeat:AddListener(self.__fixedupdate_handle)
end

function UpdateManager:__delete()
    if self.__update_handle ~= nil then
        UpdateBeat:RemoveListener(self.__update_handle)
        self.__update_handle = nil
    end
    if self.__lateupdate_handle ~= nil then
        LateUpdateBeat:RemoveListener(self.__lateupdate_handle)
        self.__lateupdate_handle = nil
    end
    if self.__fixedupdate_handle ~= nil then
        FixedUpdateBeat:RemoveListener(self.__fixedupdate_handle)
        self.__fixedupdate_handle = nil
    end
end

function UpdateManager:UpdateHandle()
    for k, v in pairs(self.__update_timer) do
        if v then
            k()
        end
    end
end

function UpdateManager:LateUpdateHandle()
    for k, v in pairs(self.__lateupdate_timer) do
        if v then
            k()
        end
    end
end

function UpdateManager:FixedUpdateHandle()
    for k, v in pairs(self.__fixedupdate_timer) do
        if v then
            k()
        end
    end
end

-- 添加Update更新
function UpdateManager:AddUpdate(event_callback, ...)
    local handle = BindCallback(event_callback,...)
    self.__update_timer[handle] = true
    return handle
end

-- 添加LateUpdate更新
function UpdateManager:AddLateUpdate(event_callback, ...)
    local handle = BindCallback(event_callback,...)
    self.__lateupdate_timer[handle] = true
    return handle
end

-- 添加FixedUpdate更新
function UpdateManager:AddFixedUpdate(event_callback, ...)
    local handle = BindCallback(event_callback,...)
    self.__fixedupdate_timer[handle] = true
    return handle
end

-- 移除Update更新
function UpdateManager:RemoveUpdate(handle)
    self.__update_timer[handle] = nil
end

-- 移除LateUpdate更新
function UpdateManager:RemoveLateUpdate(handle)
    self.__lateupdate_timer[handle] = nil
end

-- 移除FixedUpdate更新
function UpdateManager:RemoveFixedUpdate(handle)
    self.__fixedupdate_timer[handle] = nil
end


return UpdateManager