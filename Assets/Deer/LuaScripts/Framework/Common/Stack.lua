
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-08-01 22-27-05  
---修改作者 : 杜鑫 
---修改时间 : 2021-08-01 22-27-05  
---版 本 : 0.1 
---===============================================
---@class Stack
Stack = Class("Stack")

function Stack:__init()
    self.stack_table = {}
end

function Stack:push(element)
    local size = self:size()
    self.stack_table[size + 1] = element
end

function Stack:pop()
    local size = self:size()
    if self:isEmpty() then
        printError("Error: Stack is empty!")
        return
    end
    return table.remove(self.stack_table,size)
end

function Stack:top()
    local size = self:size()
    if self:isEmpty() then
        printError("Error: Stack is empty!")
        return
    end
    return self.stack_table[size]
end

function Stack:isEmpty()
    local size = self:size()
    if size == 0 then
        return true
    end
    return false
end

function Stack:size()
    return table.nums(self.stack_table) or 0
end

function Stack:clear()
    -- body
    self.stack_table = nil
    self.stack_table = {}
end

function Stack:printElement()
    local size = self:size()

    if self:isEmpty() then
        printError("Error: Stack is empty!")
        return
    end

    local str = "{"..self.stack_table[size]
    size = size - 1
    while size > 0 do
        str = str..", "..self.stack_table[size]
        size = size - 1
    end
    str = str.."}"
    print(str)
end


return Stack