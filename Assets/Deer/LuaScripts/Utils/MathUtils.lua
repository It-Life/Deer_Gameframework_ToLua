
---================================================
---描 述 :
---作 者 : 杜鑫
---创建时间 : 2021-08-01 21-25-32 
---修改作者 : 杜鑫
---修改时间 : 2021-08-01 21-25-32 
---版 本 : 0.1
---===============================================
---@function ldexp
---
function math.ldexp(x,y)
    return x * (2 ^ y)
end

---最小数值和最大数值指定返回值的范围。
---@function [parent=#math] clamp
function math.clamp(v, minValue, maxValue)
    if v < minValue then
        return minValue
    end
    if( v > maxValue) then
        return maxValue
    end
    return v
end

---根据系统时间初始化随机数种子，让后续的 math.random() 返回更随机的值
---@function [parent=#math] newrandomseed
function math.newrandomseed()
    local ok, socket = pcall(function()
        return require("socket")
    end)
    math.randomseed(os.time())

    math.random()
    math.random()
    math.random()
    math.random()
end

--- 对数值进行四舍五入，如果不是数值则返回 0
--- @function [parent=#math] round
--- @param value number 输入值
--- @return number#number
function math.round(value)
    value = tonumber(value) or 0
    return math.floor(value + 0.5)
end

---角度转弧度
---@function [parent=#math] angle2radian
function math.angle2radian(angle)
    return angle*math.pi/180
end

---弧度转角度
---@function [parent=#math] radian2angle
function math.radian2angle(radian)
    return radian/math.pi*180
end

