﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class GameEntryWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(GameEntry), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("__eq", new LuaCSFunction(op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Base", new LuaCSFunction(get_Base), null);
		L.RegVar("DataNode", new LuaCSFunction(get_DataNode), null);
		L.RegVar("Debugger", new LuaCSFunction(get_Debugger), null);
		L.RegVar("Download", new LuaCSFunction(get_Download), null);
		L.RegVar("Entity", new LuaCSFunction(get_Entity), null);
		L.RegVar("Event", new LuaCSFunction(get_Event), null);
		L.RegVar("FileSystem", new LuaCSFunction(get_FileSystem), null);
		L.RegVar("Fsm", new LuaCSFunction(get_Fsm), null);
		L.RegVar("Localization", new LuaCSFunction(get_Localization), null);
		L.RegVar("Network", new LuaCSFunction(get_Network), null);
		L.RegVar("ObjectPool", new LuaCSFunction(get_ObjectPool), null);
		L.RegVar("Procedure", new LuaCSFunction(get_Procedure), null);
		L.RegVar("Resource", new LuaCSFunction(get_Resource), null);
		L.RegVar("Scene", new LuaCSFunction(get_Scene), null);
		L.RegVar("Setting", new LuaCSFunction(get_Setting), null);
		L.RegVar("Sound", new LuaCSFunction(get_Sound), null);
		L.RegVar("WebRequest", new LuaCSFunction(get_WebRequest), null);
		L.RegVar("GameSettings", new LuaCSFunction(get_GameSettings), null);
		L.RegVar("Lua", new LuaCSFunction(get_Lua), null);
		L.RegVar("UI", new LuaCSFunction(get_UI), null);
		L.RegVar("TPSprite", new LuaCSFunction(get_TPSprite), null);
		L.RegVar("Messenger", new LuaCSFunction(get_Messenger), null);
		L.RegVar("Camera", new LuaCSFunction(get_Camera), null);
		L.RegVar("NetConnector", new LuaCSFunction(get_NetConnector), null);
		L.RegVar("Config", new LuaCSFunction(get_Config), null);
		L.RegVar("MainThreadDispatcher", new LuaCSFunction(get_MainThreadDispatcher), null);
		L.EndClass();
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
	static int get_Base(IntPtr L)
	{
		try
		{
			ToLua.PushSealed(L, GameEntry.Base);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DataNode(IntPtr L)
	{
		try
		{
			ToLua.PushSealed(L, GameEntry.DataNode);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Debugger(IntPtr L)
	{
		try
		{
			ToLua.PushSealed(L, GameEntry.Debugger);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Download(IntPtr L)
	{
		try
		{
			ToLua.PushSealed(L, GameEntry.Download);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Entity(IntPtr L)
	{
		try
		{
			ToLua.PushSealed(L, GameEntry.Entity);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Event(IntPtr L)
	{
		try
		{
			ToLua.PushSealed(L, GameEntry.Event);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_FileSystem(IntPtr L)
	{
		try
		{
			ToLua.PushSealed(L, GameEntry.FileSystem);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Fsm(IntPtr L)
	{
		try
		{
			ToLua.PushSealed(L, GameEntry.Fsm);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Localization(IntPtr L)
	{
		try
		{
			ToLua.PushSealed(L, GameEntry.Localization);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Network(IntPtr L)
	{
		try
		{
			ToLua.PushSealed(L, GameEntry.Network);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ObjectPool(IntPtr L)
	{
		try
		{
			ToLua.PushSealed(L, GameEntry.ObjectPool);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Procedure(IntPtr L)
	{
		try
		{
			ToLua.PushSealed(L, GameEntry.Procedure);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Resource(IntPtr L)
	{
		try
		{
			ToLua.PushSealed(L, GameEntry.Resource);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Scene(IntPtr L)
	{
		try
		{
			ToLua.PushSealed(L, GameEntry.Scene);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Setting(IntPtr L)
	{
		try
		{
			ToLua.PushSealed(L, GameEntry.Setting);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Sound(IntPtr L)
	{
		try
		{
			ToLua.PushSealed(L, GameEntry.Sound);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_WebRequest(IntPtr L)
	{
		try
		{
			ToLua.PushSealed(L, GameEntry.WebRequest);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GameSettings(IntPtr L)
	{
		try
		{
			ToLua.Push(L, GameEntry.GameSettings);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Lua(IntPtr L)
	{
		try
		{
			ToLua.PushSealed(L, GameEntry.Lua);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UI(IntPtr L)
	{
		try
		{
			ToLua.Push(L, GameEntry.UI);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TPSprite(IntPtr L)
	{
		try
		{
			ToLua.Push(L, GameEntry.TPSprite);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Messenger(IntPtr L)
	{
		try
		{
			ToLua.Push(L, GameEntry.Messenger);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Camera(IntPtr L)
	{
		try
		{
			ToLua.Push(L, GameEntry.Camera);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_NetConnector(IntPtr L)
	{
		try
		{
			ToLua.Push(L, GameEntry.NetConnector);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Config(IntPtr L)
	{
		try
		{
			ToLua.Push(L, GameEntry.Config);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MainThreadDispatcher(IntPtr L)
	{
		try
		{
			ToLua.Push(L, GameEntry.MainThreadDispatcher);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

