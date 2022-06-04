
---================================================
---描 述 :  GameObjectUtils
---作 者 : 杜鑫 
---创建时间 : 2021-07-20 07-57-26  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-20 07-57-26  
---版 本 : 0.1 
---===============================================
GObjUtils = {}

function GObjUtils.IsNull(gameObject)
    if not gameObject then
        return true
    end
    if type(gameObject) == "userdata" then
        return gameObject:Equals(nil);
    end
    return false
end
---获取组件
---@param gameObject any 获取组件的物体
---@param compTypeof any 组件
---@return any
function GObjUtils.GetOrAddComponent(gameObject,compTypeof)
    if GObjUtils.IsNull(gameObject) then
        return nil
    end
    if not compTypeof then
        return nil
    end
    local comp = gameObject.transform:GetComponent(compTypeof)
    if not comp then
        comp = gameObject:AddComponent(compTypeof)
    end
    return comp
end
---获取所有子物体
---@param gameObject UnityEngine.GameObject parent
---@param compTypeof any 组件
---@param callBack function 回调 包含参数 index 下标，对象trans
---@return table 子物体列表
function GObjUtils.GetAllChildren(gameObject,compTypeof,callBack)
    local children = {}
    if GObjUtils.IsNull(gameObject) then
        return children
    end
    local transItem = gameObject.transform
    local childCount = transItem.childCount
    for i = 1, childCount do
        local child = transItem:GetChild(i-1)
        if compTypeof then
            local comp = child:GetComponent(compTypeof)
            if comp then
                if callBack then
                    callBack(i,comp)
                end
                table.insert(children,comp)
            else
                if callBack then
                    callBack(i,child)
                end
                table.insert(children,child)
            end
        else
            if callBack then
                callBack(i,child)
            end
            table.insert(children,child)
        end
    end
    return children
end

function GObjUtils.GetFrezzeModeDirection(dirX,dirZ)
    local forward = GameEntry.Camera.MainCamera.transform:TransformDirection(Vector3.forward);
    forward.y = 0;
    local right = GameEntry.Camera.MainCamera.transform:TransformDirection(Vector3.right);
    local v = dirZ;
    local h = dirX;
    local targetDirection = right * h + forward * v
    if (targetDirection ~= Vector3.zero) then
        targetDirection = targetDirection.normalized
    end
    return targetDirection;
end

function GObjUtils.GetFrezzeModeDirectionBySelf(dirX,dirZ,tras)
    local forward = tras:TransformDirection(Vector3.forward);
    forward.y = 0;
    local right =tras:TransformDirection(Vector3.right);
    local v = dirZ;
    local h = dirX;
    local targetDirection = right * h + forward * v
    if (targetDirection ~= Vector3.zero) then
        targetDirection = targetDirection.normalized
    end
    return targetDirection;
end
