﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class EntityDataWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(EntityData), typeof(System.Object));
		L.RegFunction("New", new LuaCSFunction(_CreateEntityData));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("IsOwner", new LuaCSFunction(get_IsOwner), new LuaCSFunction(set_IsOwner));
		L.RegVar("Id", new LuaCSFunction(get_Id), null);
		L.RegVar("TypeId", new LuaCSFunction(get_TypeId), null);
		L.RegVar("AssetName", new LuaCSFunction(get_AssetName), new LuaCSFunction(set_AssetName));
		L.RegVar("Position", new LuaCSFunction(get_Position), new LuaCSFunction(set_Position));
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateEntityData(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3)
			{
				int arg0 = (int)LuaDLL.luaL_checkinteger(L, 1);
				int arg1 = (int)LuaDLL.luaL_checkinteger(L, 2);
				string arg2 = ToLua.CheckString(L, 3);
				EntityData obj = new EntityData(arg0, arg1, arg2);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: EntityData.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsOwner(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			EntityData obj = (EntityData)o;
			bool ret = obj.IsOwner;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index IsOwner on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Id(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			EntityData obj = (EntityData)o;
			int ret = obj.Id;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Id on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TypeId(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			EntityData obj = (EntityData)o;
			int ret = obj.TypeId;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index TypeId on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AssetName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			EntityData obj = (EntityData)o;
			string ret = obj.AssetName;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index AssetName on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Position(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			EntityData obj = (EntityData)o;
			UnityEngine.Vector3 ret = obj.Position;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Position on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_IsOwner(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			EntityData obj = (EntityData)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.IsOwner = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index IsOwner on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AssetName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			EntityData obj = (EntityData)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.AssetName = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index AssetName on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Position(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			EntityData obj = (EntityData)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.Position = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Position on a nil value");
		}
	}
}
