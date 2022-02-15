
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-21 23-29-46  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-21 23-29-46  
---版 本 : 0.1 
---===============================================

----------------------------------------------------扩展
---total function 总数
---@param t table 表
---@return number
function table.total(t)
    if type(t) ~= "table" then
        return 0
    end
    local n = 0
    for k,v in pairs(t) do
        n = n + 1
    end
    return n
end
---获取哈希表所有key
---@param hashT table
---@return table
function table.keys(hashT)
    local keys = {}
    for k, v in pairs(hashT) do
        keys[#keys + 1] = k
    end
    return keys
end

---获取哈希表所有key
---@param hashT table
---@return table
function table.values(hashT)
    local values = {}
    for k, v in pairs(hashT) do
        values[#values + 1] = v
    end
    return values
end

---从数组中查找指定值，返回其索引，没找到返回false
---@param t table
---@param value any
---@param begin number
---@return any
function table.indexof(t, value, begin)
    for i = begin or 1, #t do
        if t[i] == value then
            return i
        end
    end
    return false
end
---从哈希表查找指定值，返回其键，没找到返回nil
---@param hashtable table
---@param value any
---@return any
function table.keyof(hashtable,value)
    for k, v in pairs(hashtable) do
        if v == value then
            return k
        end
    end
    return nil
end

--- 判断数组中是否存在key
---@param array table
---@param key any
---@return boolean
function table.containsKey(array,key)
    for k, v in pairs(array) do
        if k == key then
            return true;
        end
    end
    return false
end

---从数组中删除指定值，返回删除的值的个数
---@param array table
---@param value any
---@param removeAll boolean
---@return number
function table.removeByValue(array, value, removeAll)
    local remove_count = 0
    for i = #array, 1, -1 do
        if array[i] == value then
            table.remove(array, i)
            remove_count = remove_count + 1
            if not removeAll then
                break
            end
        end
    end
    return remove_count
end

----------------------------------------------------扩展end
TableUtils = {}
