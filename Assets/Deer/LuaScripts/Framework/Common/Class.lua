
---================================================
---描 述 :
---作 者 : 杜鑫
---创建时间 : 2021-10-30 23-47-19 
---修改作者 : 杜鑫
---修改时间 : 2021-10-30 23-47-19 
---版 本 : 0.1
---===============================================

---保存类类型的虚表
local classTemp = {}
-- added by wsh @ 2017-12-09
-- 自定义类型
local ClassType = {
    class = 1,
    instance = 2,
}
function SetMetaTableIndex(t, index)
    if t == nil or index == nil then
        ---error
        return
    end
    local mt = getmetatable(t)
    if not mt then
        mt = {}
    end
    if not mt.__index then
        mt.__index = index
        setmetatable(t, mt)
    elseif mt.__index ~= index then
        SetMetaTableIndex(mt, index)
    end
end

---@class Class
--[[---@field New function
---@field Delete function
---@field __init function
---@field __delete function]]
function Class(classname, super)
    assert(type(classname) == "string" and #classname > 0)
    -- 生成一个类类型
    local class_type = {}

    -- 在创建对象的时候自动调用
    class_type.__init = false
    class_type.__delete = false
    class_type.__cname = classname
    class_type.__ctype = ClassType.class

    class_type.super = super
    class_type.New = function(...)
        -- 生成一个类对象
        local obj = DeepCopy(class_type)
        obj._class_type = class_type
        obj.__ctype = ClassType.instance
        -- 在初始化之前注册基类方法
        setmetatable(obj, {
            __index = classTemp[class_type],
        })
        -- 调用初始化方法
        do
            local create
            create = function(c, ...)
                if c.super then
                    create(c.super, ...)
                end
                if c.__init then
                    c.__init(obj, ...)
                end
            end

            create(class_type, ...)
        end

        -- 注册一个delete方法
        obj.Delete = function(self)
            local now_super = self
            while now_super ~= nil do
                if now_super.__delete then
                    now_super.__delete(self)
                end
                now_super = now_super.super
            end
        end

        return obj
    end

    local vtbl = {}
    classTemp[class_type] = vtbl

    setmetatable(class_type, {
        __newindex = function(t, k, v)
            vtbl[k] = v
        end
    ,
        --For call parent method
        __index = vtbl,
    })

    if super then
        setmetatable(vtbl, {
            __index = function(t, k)
                local ret = classTemp[super][k]
                --do not do accept, make hot update work right!
                --vtbl[k] = ret
                return ret
            end
        })
    end
    return class_type
end

--[[
function SetMetaTableIndex(t, index)
	if t == nil or index == nil then
		---error
		return
	end
	local mt = getmetatable(t)
	if not mt then
		mt = {}
	end
	if not mt.__index then
		mt.__index = index
		setmetatable(t, mt)
	elseif mt.__index ~= index then
		SetMetaTableIndex(mt, index)
	end
end

function Class(classname, ...)
	local cls = { __cname = classname }
	local supers = { ... }
	for _, super in ipairs(supers) do
		if  type(super) == "table" then
			cls.__supers = cls.__supers or {}
			cls.__supers[#cls.__supers + 1] = super
			if not cls.super then
				cls.super = super
			end
		else
			---error
			return
		end
	end

	cls.__index = cls
	if not cls.__supers or #cls.__supers == 1 then
		setmetatable(cls, { __index = cls.super })
	else
		setmetatable(cls, { __index = function(_, key)
			local supers = cls.__supers
			for i = 1, #supers do
				local super = supers[i]
				if super[key] then
					return super[key]
				end
			end
		end })
	end

	if not cls.__init then
		cls.__init = function()
		end
	end
	if not cls.__delete then
		cls.__delete = function()
		end
	end
	cls.New = function(...)
		local instance = {}
		SetMetaTableIndex(instance, cls)
		instance.class = cls
		instance:__init(...)
		return instance
	end
	-- 注册一个delete方法
	cls.Delete = function(self)
		local now_super = self
		while now_super ~= nil do
			if now_super.__delete then
				now_super.__delete(self)
				break
			end
			now_super = now_super.super
		end
	end
	return cls
end]]

--[[function Class(classname, super)
	local superType = type(super)
	local cls

	if superType ~= "function" and superType ~= "table" then
		superType = nil
		super = nil
	end

	if superType == "function" or (super and super.__ctype == 1) then
		-- inherited from native C++ Object
		cls = {}

		if superType == "table" then
			-- copy fields from super
			for k, v in pairs(super) do
				cls[k] = v
			end
			cls.__create = super.__create
			cls.super = super
		else
			cls.__create = super
			cls.ctor = function()
			end
		end

		cls.__cname = classname
		cls.__ctype = 1

		function cls.new(...)
			local instance = cls.__create(...)
			-- copy fields from class to native object
			for k, v in pairs(cls) do
				instance[k] = v
			end
			instance.class = cls
			instance:_init(...)
			return instance
		end

	else
		-- inherited from Lua Object
		if super then
			cls = {}
			setmetatable(cls, { __index = super })
			cls.super = super
			cls.__tostring = super.__tostring
		else
			cls = { ctor = function()
			end }
		end

		cls.__cname = classname
		cls.__ctype = 2 -- lua
		cls.__index = cls

		function cls.new(...)
			local instance = setmetatable({}, cls)
			instance.class = cls
			instance:__init(...)
			return instance
		end
	end

	return cls
end]]

--[[
--https://blog.csdn.net/chqj_163/article/details/87191719?spm=1000.2123.3001.4430
-- Get current version number.
local _, _, majorv, minorv, rev = string.find(_VERSION, "(%d).(%d)[.]?([%d]?)")
local VersionNumber = tonumber(majorv) * 100 + tonumber(minorv) * 10 + (((string.len(rev) == 0) and 0) or tonumber(rev))

-- Declare current version number.
TX_VERSION = VersionNumber
TX_VERSION_510 = 510
TX_VERSION_520 = 520
TX_VERSION_530 = 530

-- The hold all class type.
local __TxClassTypeList = {}

-- The inherit class function.
local function Class(TypeName, SuperType)
	-- Create new class type.
	local ClassType = {}

	-- Set class type property.
	ClassType.TypeName = TypeName
	ClassType.Constructor = false
	ClassType.SuperType = SuperType

	-- The new alloc function of this class.
	ClassType.new = function (...)
		-- Create a new object first and set metatable.
		local Obj = {}

		-- Give a tostring method.
		Obj.ToString = function (self)
			local str = tostring(self)
			local _, _, addr = string.find(str, "table%s*:%s*(0?[xX]?%x+)")
			return ClassType.TypeName .. ":" .. addr
		end

		-- Do constructor recursively.
		local CreateObj = function (Class, Object, ...)
			local Create
			Create = function (c, ...)
				if c.SuperType then
					Create(c.SuperType, ...)
				end

				if c.Constructor then
					c.Constructor(Object, ...)
				end
			end

			Create(Class, ...)
		end

		-- Do destructor recursively.
		local ReleaseObj = function (Class, Object)
			local Release
			Release = function (c)
				if c.Destructor then
					c.Destructor(Object)
				end

				if c.SuperType then
					Release(c.SuperType)
				end
			end

			Release(Class)
		end

		-- Do the destructor by lua version.
		if TX_VERSION < TX_VERSION_520 then
			-- Create a empty userdata with empty metatable.
			-- And mark gc method for destructor.
			local Proxy = newproxy(true)
			getmetatable(Proxy).__gc = function (o)
				ReleaseObj(ClassType, Obj)
			end

			-- Hold the one and only reference to the proxy userdata.
			Obj.__gc = Proxy

			-- Set metatable.
			setmetatable(Obj, {__index = __TxClassTypeList[ClassType]})
		else
			-- Directly set __gc field of the metatable for destructor of this object.
			setmetatable(Obj,
					{
						__index = __TxClassTypeList[ClassType],

						__gc = function (o)
							ReleaseObj(ClassType, o)
						end
					})
		end

		-- Do constructor for this object.
		CreateObj(ClassType, Obj, ...)
		return Obj
	end

	-- Give a ToString method.
	ClassType.ToString = function (self)
		return self.TypeName
	end

	-- The super class type of this class.
	if SuperType then
		ClassType.super = setmetatable({},
				{
					__index = function (t, k)
						local Func = __TxClassTypeList[SuperType][k]
						if "function" == type(Func) then
							t[k] = Func
							return Func
						else
							error("Accessing super class field are not allowed!")
						end
					end
				})
	end

	-- Virtual table
	local Vtbl = {}
	__TxClassTypeList[ClassType] = Vtbl

	-- Set index and new index of ClassType, and provide a default create method.
	setmetatable(ClassType,
			{
				__index = function (t, k)
					return Vtbl[k]
				end,

				__newindex = function (t, k, v)
					Vtbl[k] = v
				end,

				__call = function (self, ...)
					return ClassType.new(...)
				end
			})

	-- To copy super class things that this class not have.
	if SuperType then
		setmetatable(Vtbl,
				{
					__index = function (t, k)
						local Ret = __TxClassTypeList[SuperType][k]
						Vtbl[k] = Ret
						return Ret
					end
				})
	end

	return ClassType
end
]]

