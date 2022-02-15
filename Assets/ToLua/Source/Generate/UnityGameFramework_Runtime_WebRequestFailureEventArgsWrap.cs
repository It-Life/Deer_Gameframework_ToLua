﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityGameFramework_Runtime_WebRequestFailureEventArgsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityGameFramework.Runtime.WebRequestFailureEventArgs), typeof(GameFramework.Event.GameEventArgs));
		L.RegFunction("Create", new LuaCSFunction(Create));
		L.RegFunction("Clear", new LuaCSFunction(Clear));
		L.RegFunction("New", new LuaCSFunction(_CreateUnityGameFramework_Runtime_WebRequestFailureEventArgs));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("EventId", new LuaCSFunction(get_EventId), null);
		L.RegVar("Id", new LuaCSFunction(get_Id), null);
		L.RegVar("SerialId", new LuaCSFunction(get_SerialId), null);
		L.RegVar("WebRequestUri", new LuaCSFunction(get_WebRequestUri), null);
		L.RegVar("ErrorMessage", new LuaCSFunction(get_ErrorMessage), null);
		L.RegVar("UserData", new LuaCSFunction(get_UserData), null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityGameFramework_Runtime_WebRequestFailureEventArgs(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UnityGameFramework.Runtime.WebRequestFailureEventArgs obj = new UnityGameFramework.Runtime.WebRequestFailureEventArgs();
				ToLua.PushSealed(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityGameFramework.Runtime.WebRequestFailureEventArgs.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameFramework.WebRequest.WebRequestFailureEventArgs arg0 = (GameFramework.WebRequest.WebRequestFailureEventArgs)ToLua.CheckObject<GameFramework.WebRequest.WebRequestFailureEventArgs>(L, 1);
			UnityGameFramework.Runtime.WebRequestFailureEventArgs o = UnityGameFramework.Runtime.WebRequestFailureEventArgs.Create(arg0);
			ToLua.PushSealed(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clear(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityGameFramework.Runtime.WebRequestFailureEventArgs obj = (UnityGameFramework.Runtime.WebRequestFailureEventArgs)ToLua.CheckObject<UnityGameFramework.Runtime.WebRequestFailureEventArgs>(L, 1);
			obj.Clear();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_EventId(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, UnityGameFramework.Runtime.WebRequestFailureEventArgs.EventId);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Id(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityGameFramework.Runtime.WebRequestFailureEventArgs obj = (UnityGameFramework.Runtime.WebRequestFailureEventArgs)o;
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
	static int get_SerialId(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityGameFramework.Runtime.WebRequestFailureEventArgs obj = (UnityGameFramework.Runtime.WebRequestFailureEventArgs)o;
			int ret = obj.SerialId;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index SerialId on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_WebRequestUri(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityGameFramework.Runtime.WebRequestFailureEventArgs obj = (UnityGameFramework.Runtime.WebRequestFailureEventArgs)o;
			string ret = obj.WebRequestUri;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index WebRequestUri on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ErrorMessage(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityGameFramework.Runtime.WebRequestFailureEventArgs obj = (UnityGameFramework.Runtime.WebRequestFailureEventArgs)o;
			string ret = obj.ErrorMessage;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index ErrorMessage on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UserData(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityGameFramework.Runtime.WebRequestFailureEventArgs obj = (UnityGameFramework.Runtime.WebRequestFailureEventArgs)o;
			object ret = obj.UserData;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index UserData on a nil value");
		}
	}
}

