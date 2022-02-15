
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-08-01 22-29-28  
---修改作者 : 杜鑫 
---修改时间 : 2021-08-01 22-29-28  
---版 本 : 0.1 
---===============================================
---@class Queue
Queue = Class("Queue")

function Queue:__init(capacity)
    self.capacity = capacity
    self.queue = {}
    self.size_ = 0
    self.head = -1
    self.rear = -1
end

function Queue:enQueue(element)
    if self.size_ == 0 then
        self.head = 0
        self.rear = 1
        self.size_ = 1
        self.queue[self.rear] = element
    else
        local temp = (self.rear + 1) % self.capacity
        if temp == self.head then
            printError("Error: capacity is full.")
            return
        else
            self.rear = temp
        end

        self.queue[self.rear] = element
        self.size_ = self.size_ + 1
    end

end

function Queue:deQueue()
    if self:isEmpty() then
        printError("Error: The Queue is empty.")
        return
    end
    self.size_ = self.size_ - 1
    self.head = (self.head + 1) % self.capacity
    local value = self.queue[self.head]
    return value
end

function Queue:clear()
    self.queue = nil
    self.queue = {}
    self.size_ = 0
    self.head = -1
    self.rear = -1
end

function Queue:isEmpty()
    if self:size() == 0 then
        return true
    end
    return false
end

function Queue:size()
    return self.size_
end

function Queue:printElement()
    local h = self.head
    local r = self.rear
    local str = nil
    local first_flag = true
    while h ~= r do
        if first_flag == true then
            str = "{"..self.queue[h]
            h = (h + 1) % self.capacity
            first_flag = false
        else
            str = str..","..self.queue[h]
            h = (h + 1) % self.capacity
        end
    end
    str = str..","..self.queue[r].."}"
    print(str)
end

return Queue