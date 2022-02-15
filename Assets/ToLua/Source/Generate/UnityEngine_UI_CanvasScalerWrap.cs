﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_UI_CanvasScalerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.UI.CanvasScaler), typeof(UnityEngine.EventSystems.UIBehaviour));
		L.RegFunction("__eq", new LuaCSFunction(op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("uiScaleMode", new LuaCSFunction(get_uiScaleMode), new LuaCSFunction(set_uiScaleMode));
		L.RegVar("referencePixelsPerUnit", new LuaCSFunction(get_referencePixelsPerUnit), new LuaCSFunction(set_referencePixelsPerUnit));
		L.RegVar("scaleFactor", new LuaCSFunction(get_scaleFactor), new LuaCSFunction(set_scaleFactor));
		L.RegVar("referenceResolution", new LuaCSFunction(get_referenceResolution), new LuaCSFunction(set_referenceResolution));
		L.RegVar("screenMatchMode", new LuaCSFunction(get_screenMatchMode), new LuaCSFunction(set_screenMatchMode));
		L.RegVar("matchWidthOrHeight", new LuaCSFunction(get_matchWidthOrHeight), new LuaCSFunction(set_matchWidthOrHeight));
		L.RegVar("physicalUnit", new LuaCSFunction(get_physicalUnit), new LuaCSFunction(set_physicalUnit));
		L.RegVar("fallbackScreenDPI", new LuaCSFunction(get_fallbackScreenDPI), new LuaCSFunction(set_fallbackScreenDPI));
		L.RegVar("defaultSpriteDPI", new LuaCSFunction(get_defaultSpriteDPI), new LuaCSFunction(set_defaultSpriteDPI));
		L.RegVar("dynamicPixelsPerUnit", new LuaCSFunction(get_dynamicPixelsPerUnit), new LuaCSFunction(set_dynamicPixelsPerUnit));
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
	static int get_uiScaleMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;
			UnityEngine.UI.CanvasScaler.ScaleMode ret = obj.uiScaleMode;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index uiScaleMode on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_referencePixelsPerUnit(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;
			float ret = obj.referencePixelsPerUnit;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index referencePixelsPerUnit on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_scaleFactor(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;
			float ret = obj.scaleFactor;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index scaleFactor on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_referenceResolution(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;
			UnityEngine.Vector2 ret = obj.referenceResolution;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index referenceResolution on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_screenMatchMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;
			UnityEngine.UI.CanvasScaler.ScreenMatchMode ret = obj.screenMatchMode;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index screenMatchMode on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_matchWidthOrHeight(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;
			float ret = obj.matchWidthOrHeight;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index matchWidthOrHeight on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_physicalUnit(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;
			UnityEngine.UI.CanvasScaler.Unit ret = obj.physicalUnit;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index physicalUnit on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fallbackScreenDPI(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;
			float ret = obj.fallbackScreenDPI;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index fallbackScreenDPI on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_defaultSpriteDPI(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;
			float ret = obj.defaultSpriteDPI;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index defaultSpriteDPI on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dynamicPixelsPerUnit(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;
			float ret = obj.dynamicPixelsPerUnit;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index dynamicPixelsPerUnit on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uiScaleMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;
			UnityEngine.UI.CanvasScaler.ScaleMode arg0 = (UnityEngine.UI.CanvasScaler.ScaleMode)ToLua.CheckObject(L, 2, TypeTraits<UnityEngine.UI.CanvasScaler.ScaleMode>.type);
			obj.uiScaleMode = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index uiScaleMode on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_referencePixelsPerUnit(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.referencePixelsPerUnit = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index referencePixelsPerUnit on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_scaleFactor(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.scaleFactor = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index scaleFactor on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_referenceResolution(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;
			UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
			obj.referenceResolution = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index referenceResolution on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_screenMatchMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;
			UnityEngine.UI.CanvasScaler.ScreenMatchMode arg0 = (UnityEngine.UI.CanvasScaler.ScreenMatchMode)ToLua.CheckObject(L, 2, TypeTraits<UnityEngine.UI.CanvasScaler.ScreenMatchMode>.type);
			obj.screenMatchMode = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index screenMatchMode on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_matchWidthOrHeight(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.matchWidthOrHeight = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index matchWidthOrHeight on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_physicalUnit(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;
			UnityEngine.UI.CanvasScaler.Unit arg0 = (UnityEngine.UI.CanvasScaler.Unit)ToLua.CheckObject(L, 2, TypeTraits<UnityEngine.UI.CanvasScaler.Unit>.type);
			obj.physicalUnit = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index physicalUnit on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fallbackScreenDPI(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.fallbackScreenDPI = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index fallbackScreenDPI on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_defaultSpriteDPI(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.defaultSpriteDPI = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index defaultSpriteDPI on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_dynamicPixelsPerUnit(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.dynamicPixelsPerUnit = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index dynamicPixelsPerUnit on a nil value");
		}
	}
}

