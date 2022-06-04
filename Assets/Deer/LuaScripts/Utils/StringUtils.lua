
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-11 22-28-47  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-11 22-28-47  
---版 本 : 0.1 
---===============================================
StringUtils = {}

-- 将字符串转换为boolean值
function StringUtils:ToBoolean(s)
    local transform_map = {
        ["true"] = true,
        ["false"] = false,
    }
    return transform_map[s]
end


---是不是空字串或者是空地址
function string.isnullorempty(str)
    if (str == nil) then
        return true;
    end

    if (str == "") then
        return true;
    end

    return false;
end

---字符串分隔方法
function StringUtils:Split(str, sep)
    local sep, fields = sep or ":", {}
    local pattern = string.format("([^%s]+)", sep)
    str:gsub(pattern, function (c) fields[#fields + 1] = c end)
    return fields
end


return StringUtils