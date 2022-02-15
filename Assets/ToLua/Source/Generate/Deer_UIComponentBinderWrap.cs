﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Deer_UIComponentBinderWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Deer.UIComponentBinder), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("GetUIEventBinder", new LuaCSFunction(GetUIEventBinder));
		L.RegFunction("BindLua", new LuaCSFunction(BindLua));
		L.RegFunction("__eq", new LuaCSFunction(op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("_uIComponentBinderInfos", new LuaCSFunction(get__uIComponentBinderInfos), new LuaCSFunction(set__uIComponentBinderInfos));
		L.RegVar("FilePath", new LuaCSFunction(get_FilePath), new LuaCSFunction(set_FilePath));
		L.RegVar("filePath", new LuaCSFunction(get_filePath), null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetUIEventBinder(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Deer.UIComponentBinder obj = (Deer.UIComponentBinder)ToLua.CheckObject<Deer.UIComponentBinder>(L, 1);
			Deer.UIEventBinder o = obj.GetUIEventBinder();
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BindLua(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Deer.UIComponentBinder obj = (Deer.UIComponentBinder)ToLua.CheckObject<Deer.UIComponentBinder>(L, 1);
			LuaTable arg0 = ToLua.CheckLuaTable(L, 2);
			obj.BindLua(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get__uIComponentBinderInfos(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Deer.UIComponentBinder obj = (Deer.UIComponentBinder)o;
			System.Collections.Generic.List<Deer.UIComponentBinderInfo> ret = obj._uIComponentBinderInfos;
			ToLua.PushSealed(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index _uIComponentBinderInfos on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_FilePath(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Deer.UIComponentBinder obj = (Deer.UIComponentBinder)o;
			string ret = obj.FilePath;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index FilePath on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_filePath(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Deer.UIComponentBinder obj = (Deer.UIComponentBinder)o;
			string ret = obj.filePath;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index filePath on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set__uIComponentBinderInfos(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Deer.UIComponentBinder obj = (Deer.UIComponentBinder)o;
			System.Collections.Generic.List<Deer.UIComponentBinderInfo> arg0 = (System.Collections.Generic.List<Deer.UIComponentBinderInfo>)ToLua.CheckObject(L, 2, TypeTraits<System.Collections.Generic.List<Deer.UIComponentBinderInfo>>.type);
			obj._uIComponentBinderInfos = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index _uIComponentBinderInfos on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_FilePath(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Deer.UIComponentBinder obj = (Deer.UIComponentBinder)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.FilePath = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index FilePath on a nil value");
		}
	}
}

