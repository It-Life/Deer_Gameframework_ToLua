﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_UI_MaskableGraphicWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.UI.MaskableGraphic), typeof(UnityEngine.UI.Graphic));
		L.RegFunction("GetModifiedMaterial", new LuaCSFunction(GetModifiedMaterial));
		L.RegFunction("Cull", new LuaCSFunction(Cull));
		L.RegFunction("SetClipRect", new LuaCSFunction(SetClipRect));
		L.RegFunction("SetClipSoftness", new LuaCSFunction(SetClipSoftness));
		L.RegFunction("RecalculateClipping", new LuaCSFunction(RecalculateClipping));
		L.RegFunction("RecalculateMasking", new LuaCSFunction(RecalculateMasking));
		L.RegFunction("__eq", new LuaCSFunction(op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("onCullStateChanged", new LuaCSFunction(get_onCullStateChanged), new LuaCSFunction(set_onCullStateChanged));
		L.RegVar("maskable", new LuaCSFunction(get_maskable), new LuaCSFunction(set_maskable));
		L.RegVar("isMaskingGraphic", new LuaCSFunction(get_isMaskingGraphic), new LuaCSFunction(set_isMaskingGraphic));
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetModifiedMaterial(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.UI.MaskableGraphic obj = (UnityEngine.UI.MaskableGraphic)ToLua.CheckObject<UnityEngine.UI.MaskableGraphic>(L, 1);
			UnityEngine.Material arg0 = (UnityEngine.Material)ToLua.CheckObject<UnityEngine.Material>(L, 2);
			UnityEngine.Material o = obj.GetModifiedMaterial(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Cull(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.UI.MaskableGraphic obj = (UnityEngine.UI.MaskableGraphic)ToLua.CheckObject<UnityEngine.UI.MaskableGraphic>(L, 1);
			UnityEngine.Rect arg0 = StackTraits<UnityEngine.Rect>.Check(L, 2);
			bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
			obj.Cull(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetClipRect(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.UI.MaskableGraphic obj = (UnityEngine.UI.MaskableGraphic)ToLua.CheckObject<UnityEngine.UI.MaskableGraphic>(L, 1);
			UnityEngine.Rect arg0 = StackTraits<UnityEngine.Rect>.Check(L, 2);
			bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
			obj.SetClipRect(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetClipSoftness(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.UI.MaskableGraphic obj = (UnityEngine.UI.MaskableGraphic)ToLua.CheckObject<UnityEngine.UI.MaskableGraphic>(L, 1);
			UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
			obj.SetClipSoftness(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RecalculateClipping(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.UI.MaskableGraphic obj = (UnityEngine.UI.MaskableGraphic)ToLua.CheckObject<UnityEngine.UI.MaskableGraphic>(L, 1);
			obj.RecalculateClipping();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RecalculateMasking(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.UI.MaskableGraphic obj = (UnityEngine.UI.MaskableGraphic)ToLua.CheckObject<UnityEngine.UI.MaskableGraphic>(L, 1);
			obj.RecalculateMasking();
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
	static int get_onCullStateChanged(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.MaskableGraphic obj = (UnityEngine.UI.MaskableGraphic)o;
			UnityEngine.UI.MaskableGraphic.CullStateChangedEvent ret = obj.onCullStateChanged;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index onCullStateChanged on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maskable(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.MaskableGraphic obj = (UnityEngine.UI.MaskableGraphic)o;
			bool ret = obj.maskable;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index maskable on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isMaskingGraphic(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.MaskableGraphic obj = (UnityEngine.UI.MaskableGraphic)o;
			bool ret = obj.isMaskingGraphic;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index isMaskingGraphic on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onCullStateChanged(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.MaskableGraphic obj = (UnityEngine.UI.MaskableGraphic)o;
			UnityEngine.UI.MaskableGraphic.CullStateChangedEvent arg0 = (UnityEngine.UI.MaskableGraphic.CullStateChangedEvent)ToLua.CheckObject<UnityEngine.UI.MaskableGraphic.CullStateChangedEvent>(L, 2);
			obj.onCullStateChanged = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index onCullStateChanged on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maskable(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.MaskableGraphic obj = (UnityEngine.UI.MaskableGraphic)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.maskable = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index maskable on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isMaskingGraphic(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.MaskableGraphic obj = (UnityEngine.UI.MaskableGraphic)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.isMaskingGraphic = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index isMaskingGraphic on a nil value");
		}
	}
}

