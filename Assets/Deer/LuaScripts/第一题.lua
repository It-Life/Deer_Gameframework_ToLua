
function outSpliceText(str)
    if #str == 0 then
        return ""
    end
    local spFun = function(numStr,tempStr)
        local out2 = ""
        if numStr ~= "" then
            local num = tonumber(numStr)
            for i = 1, num-1 do
                out2 = out2 .. tempStr
            end
        end
        return out2
    end
    local out1 = ""
    local numStr = ""
    local tempStr = ""
    for i = 1, #str do
        local cValue = string.sub(str,i,i)
        if tonumber(cValue) ~= nil then
            numStr = numStr .. cValue
            if i == #str then
                out1 = out1 .. spFun(numStr,tempStr)
            end
        else
            out1 = out1 .. spFun(numStr,tempStr)
            numStr = ""
            tempStr=cValue
            out1 = out1 .. cValue
        end
    end
    return out1
end

a = "g4h5"
b = outSpliceText(a)
print(b)