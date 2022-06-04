
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-08-08 13-26-46  
---修改作者 : 杜鑫 
---修改时间 : 2021-08-08 13-26-46  
---版 本 : 0.1 
---===============================================
GlobalUtils = {}
--引用json解析
local cjson = require("cjson")

local unpack = unpack or table.unpack
-- 解决原生pack的nil截断问题，SafePack与SafeUnpack要成对使用
function SafePack(...)
    local params = {...}
    params.n = select('#', ...)
    return params
end

-- 对两个SafePack的表执行连接
function ConcatSafePack(safe_pack_l, safe_pack_r)
    local concat = {}
    for i = 1,safe_pack_l.n do
        concat[i] = safe_pack_l[i]
    end
    for i = 1,safe_pack_r.n do
        concat[safe_pack_l.n + i] = safe_pack_r[i]
    end
    concat.n = safe_pack_l.n + safe_pack_r.n
    return concat
end

-- 解决原生unpack的nil截断问题，SafePack与SafeUnpack要成对使用
function SafeUnpack(safe_pack_tb)
    return unpack(safe_pack_tb, 1, safe_pack_tb.n)
end

-- 闭包绑定
function Bind(self, func, ...)
    assert(self == nil or type(self) == "table")
    assert(func ~= nil and type(func) == "function")
    local params = nil
    if self == nil then
        params = SafePack(...)
    else
        params = SafePack(self, ...)
    end
    return function(...)
        local args = ConcatSafePack(params, SafePack(...))
        func(SafeUnpack(args))
    end
end

-- 回调绑定
-- 重载形式：
-- 1、成员函数、私有函数绑定：BindCallback(obj, callback, ...)
-- 2、闭包绑定：BindCallback(callback, ...)
function BindCallback(...)
    local bindFunc = nil
    local params = SafePack(...)
    assert(params.n >= 1, "BindCallback : error params count!")
    if type(params[1]) == "table" and type(params[2]) == "function" then
        bindFunc = Bind(...)
    elseif type(params[1]) == "function" then
        bindFunc = Bind(nil, ...)
    else
        error("BindCallback : error params list!")
    end
    return bindFunc
end

-- 深拷贝对象
function DeepCopy(object)
    local lookup_table = {}

    local function _copy(object)
        if type(object) ~= "table" then
            return object
        elseif lookup_table[object] then
            return lookup_table[object]
        end

        local new_table = {}
        lookup_table[object] = new_table
        for index, value in pairs(object) do
            new_table[_copy(index)] = _copy(value)
        end

        return setmetatable(new_table, getmetatable(object))
    end

    return _copy(object)
end
---json反序列化
---@param strJson string json字符串
function JsonDecode(strJson)
    return cjson.decode(strJson)
end
---json序列化
---@param tb table
--[[    local _jsonArray={}
    _jsonArray[1]=8
    _jsonArray[2]=9
    _jsonArray[3]=11
    _jsonArray[4]=14
    _jsonArray[5]=25
    local _arrayFlagKey={}
    _arrayFlagKey["array"]=_jsonArray
    local tab = {}
    tab["Himi"]= "himigame.com"
    tab["testArray"]=_arrayFlagKey
    tab["age"]= "23"]]
function JsonEncode(tb)
    return cjson.encode(tb)
end

return GlobalUtils