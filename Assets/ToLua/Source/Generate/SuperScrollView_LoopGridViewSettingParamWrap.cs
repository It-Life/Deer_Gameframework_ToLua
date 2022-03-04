﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class SuperScrollView_LoopGridViewSettingParamWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(SuperScrollView.LoopGridViewSettingParam), typeof(System.Object));
		L.RegFunction("New", new LuaCSFunction(_CreateSuperScrollView_LoopGridViewSettingParam));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("mItemSize", new LuaCSFunction(get_mItemSize), new LuaCSFunction(set_mItemSize));
		L.RegVar("mPadding", new LuaCSFunction(get_mPadding), new LuaCSFunction(set_mPadding));
		L.RegVar("mItemPadding", new LuaCSFunction(get_mItemPadding), new LuaCSFunction(set_mItemPadding));
		L.RegVar("mGridFixedType", new LuaCSFunction(get_mGridFixedType), new LuaCSFunction(set_mGridFixedType));
		L.RegVar("mFixedRowOrColumnCount", new LuaCSFunction(get_mFixedRowOrColumnCount), new LuaCSFunction(set_mFixedRowOrColumnCount));
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSuperScrollView_LoopGridViewSettingParam(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				SuperScrollView.LoopGridViewSettingParam obj = new SuperScrollView.LoopGridViewSettingParam();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: SuperScrollView.LoopGridViewSettingParam.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mItemSize(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SuperScrollView.LoopGridViewSettingParam obj = (SuperScrollView.LoopGridViewSettingParam)o;
			object ret = obj.mItemSize;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index mItemSize on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mPadding(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SuperScrollView.LoopGridViewSettingParam obj = (SuperScrollView.LoopGridViewSettingParam)o;
			object ret = obj.mPadding;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index mPadding on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mItemPadding(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SuperScrollView.LoopGridViewSettingParam obj = (SuperScrollView.LoopGridViewSettingParam)o;
			object ret = obj.mItemPadding;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index mItemPadding on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mGridFixedType(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SuperScrollView.LoopGridViewSettingParam obj = (SuperScrollView.LoopGridViewSettingParam)o;
			object ret = obj.mGridFixedType;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index mGridFixedType on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mFixedRowOrColumnCount(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SuperScrollView.LoopGridViewSettingParam obj = (SuperScrollView.LoopGridViewSettingParam)o;
			object ret = obj.mFixedRowOrColumnCount;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index mFixedRowOrColumnCount on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mItemSize(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SuperScrollView.LoopGridViewSettingParam obj = (SuperScrollView.LoopGridViewSettingParam)o;
			object arg0 = ToLua.ToVarObject(L, 2);
			obj.mItemSize = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index mItemSize on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mPadding(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SuperScrollView.LoopGridViewSettingParam obj = (SuperScrollView.LoopGridViewSettingParam)o;
			object arg0 = ToLua.ToVarObject(L, 2);
			obj.mPadding = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index mPadding on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mItemPadding(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SuperScrollView.LoopGridViewSettingParam obj = (SuperScrollView.LoopGridViewSettingParam)o;
			object arg0 = ToLua.ToVarObject(L, 2);
			obj.mItemPadding = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index mItemPadding on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mGridFixedType(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SuperScrollView.LoopGridViewSettingParam obj = (SuperScrollView.LoopGridViewSettingParam)o;
			object arg0 = ToLua.ToVarObject(L, 2);
			obj.mGridFixedType = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index mGridFixedType on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mFixedRowOrColumnCount(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SuperScrollView.LoopGridViewSettingParam obj = (SuperScrollView.LoopGridViewSettingParam)o;
			object arg0 = ToLua.ToVarObject(L, 2);
			obj.mFixedRowOrColumnCount = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index mFixedRowOrColumnCount on a nil value");
		}
	}
}
