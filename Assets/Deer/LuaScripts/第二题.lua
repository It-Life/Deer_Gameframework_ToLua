
function isOuNumber(num)
    local num1,num2=math.modf(num/2)--返回整数和小数部分
    if(num2==0)then
        return true
    else
        return false
    end
end

function arraySort(a,b)
    for i = 1, #b do
        table.insert(a,b[i])
    end
    local index = 0
    for i = 1, #a - 1 do
        local isSorder = true
        for j = 1, #a - 1 do
            if a[j] < a[j + 1] then
                a[j],a[j + 1] = a[j+1], a[j]
                isSorder = false
            end
            index = index + 1
        end
        if isSorder then
            break
        end
    end
    local sortList = {}
    local tempList = {}
    local num = 0
    for i = 1, #a do
        if #a ~= i and a[i] == a[i+1] then
            table.insert(tempList,a[i])
        else
            table.insert(tempList,a[i])
            if num==0 or isOuNumber(num) then
                for j = 1, #tempList do
                    table.insert(sortList,tempList[j])
                end
            else
                for j = 1, #tempList do
                    table.insert(sortList,1,tempList[j])
                end
            end
            tempList = {}
            num = num + 1
        end
    end
    return sortList
end

a = {98,95,91,79}
b = {96,91,83}

c = arraySort(a,b)
for i = 1, #c do
    print(c[i])
end
