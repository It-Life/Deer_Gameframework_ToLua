﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class CameraComponentWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(CameraComponent), typeof(UnityGameFramework.Runtime.GameFrameworkComponent));
		L.RegFunction("OpenCameraType", new LuaCSFunction(OpenCameraType));
		L.RegFunction("LookAtTarget", new LuaCSFunction(LookAtTarget));
		L.RegFunction("FollowTarget", new LuaCSFunction(FollowTarget));
		L.RegFunction("FollowAndLockViewTarget", new LuaCSFunction(FollowAndLockViewTarget));
		L.RegFunction("FollowAndFreeViewTarget", new LuaCSFunction(FollowAndFreeViewTarget));
		L.RegFunction("CameraActive", new LuaCSFunction(CameraActive));
		L.RegFunction("GetAxisCustom", new LuaCSFunction(GetAxisCustom));
		L.RegFunction("SetMiniMapFollowTarget", new LuaCSFunction(SetMiniMapFollowTarget));
		L.RegFunction("MiniMapZoomIn", new LuaCSFunction(MiniMapZoomIn));
		L.RegFunction("MiniMapZoomOut", new LuaCSFunction(MiniMapZoomOut));
		L.RegFunction("__eq", new LuaCSFunction(op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("MainCamera", new LuaCSFunction(get_MainCamera), new LuaCSFunction(set_MainCamera));
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OpenCameraType(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			CameraComponent obj = (CameraComponent)ToLua.CheckObject<CameraComponent>(L, 1);
			obj.OpenCameraType();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LookAtTarget(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			CameraComponent obj = (CameraComponent)ToLua.CheckObject<CameraComponent>(L, 1);
			UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckObject<UnityEngine.Transform>(L, 2);
			obj.LookAtTarget(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FollowTarget(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				CameraComponent obj = (CameraComponent)ToLua.CheckObject<CameraComponent>(L, 1);
				UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckObject<UnityEngine.Transform>(L, 2);
				obj.FollowTarget(arg0);
				return 0;
			}
			else if (count == 3)
			{
				CameraComponent obj = (CameraComponent)ToLua.CheckObject<CameraComponent>(L, 1);
				UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckObject<UnityEngine.Transform>(L, 2);
				UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 3);
				obj.FollowTarget(arg0, arg1);
				return 0;
			}
			else if (count == 4)
			{
				CameraComponent obj = (CameraComponent)ToLua.CheckObject<CameraComponent>(L, 1);
				UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckObject<UnityEngine.Transform>(L, 2);
				UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 3);
				UnityEngine.Quaternion arg2 = ToLua.ToQuaternion(L, 4);
				obj.FollowTarget(arg0, arg1, arg2);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: CameraComponent.FollowTarget");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FollowAndLockViewTarget(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			CameraComponent obj = (CameraComponent)ToLua.CheckObject<CameraComponent>(L, 1);
			UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckObject<UnityEngine.Transform>(L, 2);
			UnityEngine.Transform arg1 = (UnityEngine.Transform)ToLua.CheckObject<UnityEngine.Transform>(L, 3);
			obj.FollowAndLockViewTarget(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FollowAndFreeViewTarget(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			CameraComponent obj = (CameraComponent)ToLua.CheckObject<CameraComponent>(L, 1);
			UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckObject<UnityEngine.Transform>(L, 2);
			UnityEngine.Transform arg1 = (UnityEngine.Transform)ToLua.CheckObject<UnityEngine.Transform>(L, 3);
			obj.FollowAndFreeViewTarget(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CameraActive(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			CameraComponent obj = (CameraComponent)ToLua.CheckObject<CameraComponent>(L, 1);
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.CameraActive(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAxisCustom(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			CameraComponent obj = (CameraComponent)ToLua.CheckObject<CameraComponent>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			float o = obj.GetAxisCustom(arg0);
			LuaDLL.lua_pushnumber(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetMiniMapFollowTarget(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			CameraComponent obj = (CameraComponent)ToLua.CheckObject<CameraComponent>(L, 1);
			UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckObject<UnityEngine.Transform>(L, 2);
			obj.SetMiniMapFollowTarget(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MiniMapZoomIn(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			CameraComponent obj = (CameraComponent)ToLua.CheckObject<CameraComponent>(L, 1);
			obj.MiniMapZoomIn();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MiniMapZoomOut(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			CameraComponent obj = (CameraComponent)ToLua.CheckObject<CameraComponent>(L, 1);
			obj.MiniMapZoomOut();
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
	static int get_MainCamera(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			CameraComponent obj = (CameraComponent)o;
			UnityEngine.Camera ret = obj.MainCamera;
			ToLua.PushSealed(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index MainCamera on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_MainCamera(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			CameraComponent obj = (CameraComponent)o;
			UnityEngine.Camera arg0 = (UnityEngine.Camera)ToLua.CheckObject<UnityEngine.Camera>(L, 2);
			obj.MainCamera = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index MainCamera on a nil value");
		}
	}
}

