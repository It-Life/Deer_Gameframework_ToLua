﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_RendererWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.Renderer), typeof(UnityEngine.Component));
		L.RegFunction("ResetBounds", new LuaCSFunction(ResetBounds));
		L.RegFunction("ResetLocalBounds", new LuaCSFunction(ResetLocalBounds));
		L.RegFunction("HasPropertyBlock", new LuaCSFunction(HasPropertyBlock));
		L.RegFunction("SetPropertyBlock", new LuaCSFunction(SetPropertyBlock));
		L.RegFunction("GetPropertyBlock", new LuaCSFunction(GetPropertyBlock));
		L.RegFunction("GetMaterials", new LuaCSFunction(GetMaterials));
		L.RegFunction("GetSharedMaterials", new LuaCSFunction(GetSharedMaterials));
		L.RegFunction("GetClosestReflectionProbes", new LuaCSFunction(GetClosestReflectionProbes));
		L.RegFunction("New", new LuaCSFunction(_CreateUnityEngine_Renderer));
		L.RegFunction("__eq", new LuaCSFunction(op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("bounds", new LuaCSFunction(get_bounds), new LuaCSFunction(set_bounds));
		L.RegVar("localBounds", new LuaCSFunction(get_localBounds), new LuaCSFunction(set_localBounds));
		L.RegVar("enabled", new LuaCSFunction(get_enabled), new LuaCSFunction(set_enabled));
		L.RegVar("isVisible", new LuaCSFunction(get_isVisible), null);
		L.RegVar("shadowCastingMode", new LuaCSFunction(get_shadowCastingMode), new LuaCSFunction(set_shadowCastingMode));
		L.RegVar("receiveShadows", new LuaCSFunction(get_receiveShadows), new LuaCSFunction(set_receiveShadows));
		L.RegVar("forceRenderingOff", new LuaCSFunction(get_forceRenderingOff), new LuaCSFunction(set_forceRenderingOff));
		L.RegVar("staticShadowCaster", new LuaCSFunction(get_staticShadowCaster), new LuaCSFunction(set_staticShadowCaster));
		L.RegVar("motionVectorGenerationMode", new LuaCSFunction(get_motionVectorGenerationMode), new LuaCSFunction(set_motionVectorGenerationMode));
		L.RegVar("lightProbeUsage", new LuaCSFunction(get_lightProbeUsage), new LuaCSFunction(set_lightProbeUsage));
		L.RegVar("reflectionProbeUsage", new LuaCSFunction(get_reflectionProbeUsage), new LuaCSFunction(set_reflectionProbeUsage));
		L.RegVar("renderingLayerMask", new LuaCSFunction(get_renderingLayerMask), new LuaCSFunction(set_renderingLayerMask));
		L.RegVar("rendererPriority", new LuaCSFunction(get_rendererPriority), new LuaCSFunction(set_rendererPriority));
		L.RegVar("rayTracingMode", new LuaCSFunction(get_rayTracingMode), new LuaCSFunction(set_rayTracingMode));
		L.RegVar("sortingLayerName", new LuaCSFunction(get_sortingLayerName), new LuaCSFunction(set_sortingLayerName));
		L.RegVar("sortingLayerID", new LuaCSFunction(get_sortingLayerID), new LuaCSFunction(set_sortingLayerID));
		L.RegVar("sortingOrder", new LuaCSFunction(get_sortingOrder), new LuaCSFunction(set_sortingOrder));
		L.RegVar("allowOcclusionWhenDynamic", new LuaCSFunction(get_allowOcclusionWhenDynamic), new LuaCSFunction(set_allowOcclusionWhenDynamic));
		L.RegVar("isPartOfStaticBatch", new LuaCSFunction(get_isPartOfStaticBatch), null);
		L.RegVar("worldToLocalMatrix", new LuaCSFunction(get_worldToLocalMatrix), null);
		L.RegVar("localToWorldMatrix", new LuaCSFunction(get_localToWorldMatrix), null);
		L.RegVar("lightProbeProxyVolumeOverride", new LuaCSFunction(get_lightProbeProxyVolumeOverride), new LuaCSFunction(set_lightProbeProxyVolumeOverride));
		L.RegVar("probeAnchor", new LuaCSFunction(get_probeAnchor), new LuaCSFunction(set_probeAnchor));
		L.RegVar("lightmapIndex", new LuaCSFunction(get_lightmapIndex), new LuaCSFunction(set_lightmapIndex));
		L.RegVar("realtimeLightmapIndex", new LuaCSFunction(get_realtimeLightmapIndex), new LuaCSFunction(set_realtimeLightmapIndex));
		L.RegVar("lightmapScaleOffset", new LuaCSFunction(get_lightmapScaleOffset), new LuaCSFunction(set_lightmapScaleOffset));
		L.RegVar("realtimeLightmapScaleOffset", new LuaCSFunction(get_realtimeLightmapScaleOffset), new LuaCSFunction(set_realtimeLightmapScaleOffset));
		L.RegVar("materials", new LuaCSFunction(get_materials), new LuaCSFunction(set_materials));
		L.RegVar("material", new LuaCSFunction(get_material), new LuaCSFunction(set_material));
		L.RegVar("sharedMaterial", new LuaCSFunction(get_sharedMaterial), new LuaCSFunction(set_sharedMaterial));
		L.RegVar("sharedMaterials", new LuaCSFunction(get_sharedMaterials), new LuaCSFunction(set_sharedMaterials));
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_Renderer(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UnityEngine.Renderer obj = new UnityEngine.Renderer();
				ToLua.Push(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.Renderer.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetBounds(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.CheckObject<UnityEngine.Renderer>(L, 1);
			obj.ResetBounds();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetLocalBounds(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.CheckObject<UnityEngine.Renderer>(L, 1);
			obj.ResetLocalBounds();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HasPropertyBlock(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.CheckObject<UnityEngine.Renderer>(L, 1);
			bool o = obj.HasPropertyBlock();
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetPropertyBlock(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.CheckObject<UnityEngine.Renderer>(L, 1);
				UnityEngine.MaterialPropertyBlock arg0 = (UnityEngine.MaterialPropertyBlock)ToLua.CheckObject<UnityEngine.MaterialPropertyBlock>(L, 2);
				obj.SetPropertyBlock(arg0);
				return 0;
			}
			else if (count == 3)
			{
				UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.CheckObject<UnityEngine.Renderer>(L, 1);
				UnityEngine.MaterialPropertyBlock arg0 = (UnityEngine.MaterialPropertyBlock)ToLua.CheckObject<UnityEngine.MaterialPropertyBlock>(L, 2);
				int arg1 = (int)LuaDLL.luaL_checkinteger(L, 3);
				obj.SetPropertyBlock(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Renderer.SetPropertyBlock");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPropertyBlock(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.CheckObject<UnityEngine.Renderer>(L, 1);
				UnityEngine.MaterialPropertyBlock arg0 = (UnityEngine.MaterialPropertyBlock)ToLua.CheckObject<UnityEngine.MaterialPropertyBlock>(L, 2);
				obj.GetPropertyBlock(arg0);
				return 0;
			}
			else if (count == 3)
			{
				UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.CheckObject<UnityEngine.Renderer>(L, 1);
				UnityEngine.MaterialPropertyBlock arg0 = (UnityEngine.MaterialPropertyBlock)ToLua.CheckObject<UnityEngine.MaterialPropertyBlock>(L, 2);
				int arg1 = (int)LuaDLL.luaL_checkinteger(L, 3);
				obj.GetPropertyBlock(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Renderer.GetPropertyBlock");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMaterials(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.CheckObject<UnityEngine.Renderer>(L, 1);
			System.Collections.Generic.List<UnityEngine.Material> arg0 = (System.Collections.Generic.List<UnityEngine.Material>)ToLua.CheckObject(L, 2, TypeTraits<System.Collections.Generic.List<UnityEngine.Material>>.type);
			obj.GetMaterials(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSharedMaterials(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.CheckObject<UnityEngine.Renderer>(L, 1);
			System.Collections.Generic.List<UnityEngine.Material> arg0 = (System.Collections.Generic.List<UnityEngine.Material>)ToLua.CheckObject(L, 2, TypeTraits<System.Collections.Generic.List<UnityEngine.Material>>.type);
			obj.GetSharedMaterials(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClosestReflectionProbes(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.CheckObject<UnityEngine.Renderer>(L, 1);
			System.Collections.Generic.List<UnityEngine.Rendering.ReflectionProbeBlendInfo> arg0 = (System.Collections.Generic.List<UnityEngine.Rendering.ReflectionProbeBlendInfo>)ToLua.CheckObject(L, 2, TypeTraits<System.Collections.Generic.List<UnityEngine.Rendering.ReflectionProbeBlendInfo>>.type);
			obj.GetClosestReflectionProbes(arg0);
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
	static int get_bounds(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Bounds ret = obj.bounds;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index bounds on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localBounds(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Bounds ret = obj.localBounds;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index localBounds on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enabled(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			bool ret = obj.enabled;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index enabled on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isVisible(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			bool ret = obj.isVisible;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index isVisible on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowCastingMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Rendering.ShadowCastingMode ret = obj.shadowCastingMode;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index shadowCastingMode on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_receiveShadows(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			bool ret = obj.receiveShadows;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index receiveShadows on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_forceRenderingOff(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			bool ret = obj.forceRenderingOff;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index forceRenderingOff on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_staticShadowCaster(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			bool ret = obj.staticShadowCaster;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index staticShadowCaster on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_motionVectorGenerationMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.MotionVectorGenerationMode ret = obj.motionVectorGenerationMode;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index motionVectorGenerationMode on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lightProbeUsage(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Rendering.LightProbeUsage ret = obj.lightProbeUsage;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index lightProbeUsage on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_reflectionProbeUsage(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Rendering.ReflectionProbeUsage ret = obj.reflectionProbeUsage;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index reflectionProbeUsage on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_renderingLayerMask(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			uint ret = obj.renderingLayerMask;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index renderingLayerMask on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rendererPriority(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			int ret = obj.rendererPriority;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index rendererPriority on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rayTracingMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Experimental.Rendering.RayTracingMode ret = obj.rayTracingMode;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index rayTracingMode on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sortingLayerName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			string ret = obj.sortingLayerName;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index sortingLayerName on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sortingLayerID(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			int ret = obj.sortingLayerID;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index sortingLayerID on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sortingOrder(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			int ret = obj.sortingOrder;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index sortingOrder on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_allowOcclusionWhenDynamic(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			bool ret = obj.allowOcclusionWhenDynamic;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index allowOcclusionWhenDynamic on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isPartOfStaticBatch(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			bool ret = obj.isPartOfStaticBatch;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index isPartOfStaticBatch on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_worldToLocalMatrix(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Matrix4x4 ret = obj.worldToLocalMatrix;
			ToLua.PushValue(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index worldToLocalMatrix on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localToWorldMatrix(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Matrix4x4 ret = obj.localToWorldMatrix;
			ToLua.PushValue(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index localToWorldMatrix on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lightProbeProxyVolumeOverride(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.GameObject ret = obj.lightProbeProxyVolumeOverride;
			ToLua.PushSealed(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index lightProbeProxyVolumeOverride on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_probeAnchor(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Transform ret = obj.probeAnchor;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index probeAnchor on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lightmapIndex(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			int ret = obj.lightmapIndex;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index lightmapIndex on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_realtimeLightmapIndex(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			int ret = obj.realtimeLightmapIndex;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index realtimeLightmapIndex on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lightmapScaleOffset(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Vector4 ret = obj.lightmapScaleOffset;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index lightmapScaleOffset on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_realtimeLightmapScaleOffset(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Vector4 ret = obj.realtimeLightmapScaleOffset;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index realtimeLightmapScaleOffset on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_materials(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Material[] ret = obj.materials;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index materials on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_material(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Material ret = obj.material;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index material on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sharedMaterial(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Material ret = obj.sharedMaterial;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index sharedMaterial on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sharedMaterials(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Material[] ret = obj.sharedMaterials;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index sharedMaterials on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_bounds(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Bounds arg0 = ToLua.ToBounds(L, 2);
			obj.bounds = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index bounds on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_localBounds(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Bounds arg0 = ToLua.ToBounds(L, 2);
			obj.localBounds = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index localBounds on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enabled(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.enabled = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index enabled on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowCastingMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Rendering.ShadowCastingMode arg0 = (UnityEngine.Rendering.ShadowCastingMode)ToLua.CheckObject(L, 2, TypeTraits<UnityEngine.Rendering.ShadowCastingMode>.type);
			obj.shadowCastingMode = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index shadowCastingMode on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_receiveShadows(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.receiveShadows = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index receiveShadows on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_forceRenderingOff(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.forceRenderingOff = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index forceRenderingOff on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_staticShadowCaster(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.staticShadowCaster = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index staticShadowCaster on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_motionVectorGenerationMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.MotionVectorGenerationMode arg0 = (UnityEngine.MotionVectorGenerationMode)ToLua.CheckObject(L, 2, TypeTraits<UnityEngine.MotionVectorGenerationMode>.type);
			obj.motionVectorGenerationMode = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index motionVectorGenerationMode on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lightProbeUsage(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Rendering.LightProbeUsage arg0 = (UnityEngine.Rendering.LightProbeUsage)ToLua.CheckObject(L, 2, TypeTraits<UnityEngine.Rendering.LightProbeUsage>.type);
			obj.lightProbeUsage = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index lightProbeUsage on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_reflectionProbeUsage(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Rendering.ReflectionProbeUsage arg0 = (UnityEngine.Rendering.ReflectionProbeUsage)ToLua.CheckObject(L, 2, TypeTraits<UnityEngine.Rendering.ReflectionProbeUsage>.type);
			obj.reflectionProbeUsage = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index reflectionProbeUsage on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_renderingLayerMask(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			uint arg0 = (uint)LuaDLL.luaL_checkinteger(L, 2);
			obj.renderingLayerMask = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index renderingLayerMask on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rendererPriority(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			int arg0 = (int)LuaDLL.luaL_checkinteger(L, 2);
			obj.rendererPriority = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index rendererPriority on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rayTracingMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Experimental.Rendering.RayTracingMode arg0 = (UnityEngine.Experimental.Rendering.RayTracingMode)ToLua.CheckObject(L, 2, TypeTraits<UnityEngine.Experimental.Rendering.RayTracingMode>.type);
			obj.rayTracingMode = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index rayTracingMode on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sortingLayerName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.sortingLayerName = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index sortingLayerName on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sortingLayerID(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			int arg0 = (int)LuaDLL.luaL_checkinteger(L, 2);
			obj.sortingLayerID = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index sortingLayerID on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sortingOrder(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			int arg0 = (int)LuaDLL.luaL_checkinteger(L, 2);
			obj.sortingOrder = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index sortingOrder on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_allowOcclusionWhenDynamic(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.allowOcclusionWhenDynamic = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index allowOcclusionWhenDynamic on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lightProbeProxyVolumeOverride(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject<UnityEngine.GameObject>(L, 2);
			obj.lightProbeProxyVolumeOverride = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index lightProbeProxyVolumeOverride on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_probeAnchor(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckObject<UnityEngine.Transform>(L, 2);
			obj.probeAnchor = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index probeAnchor on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lightmapIndex(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			int arg0 = (int)LuaDLL.luaL_checkinteger(L, 2);
			obj.lightmapIndex = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index lightmapIndex on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_realtimeLightmapIndex(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			int arg0 = (int)LuaDLL.luaL_checkinteger(L, 2);
			obj.realtimeLightmapIndex = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index realtimeLightmapIndex on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lightmapScaleOffset(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Vector4 arg0 = ToLua.ToVector4(L, 2);
			obj.lightmapScaleOffset = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index lightmapScaleOffset on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_realtimeLightmapScaleOffset(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Vector4 arg0 = ToLua.ToVector4(L, 2);
			obj.realtimeLightmapScaleOffset = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index realtimeLightmapScaleOffset on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_materials(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Material[] arg0 = ToLua.CheckObjectArray<UnityEngine.Material>(L, 2);
			obj.materials = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index materials on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_material(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Material arg0 = (UnityEngine.Material)ToLua.CheckObject<UnityEngine.Material>(L, 2);
			obj.material = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index material on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sharedMaterial(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Material arg0 = (UnityEngine.Material)ToLua.CheckObject<UnityEngine.Material>(L, 2);
			obj.sharedMaterial = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index sharedMaterial on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sharedMaterials(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Renderer obj = (UnityEngine.Renderer)o;
			UnityEngine.Material[] arg0 = ToLua.CheckObjectArray<UnityEngine.Material>(L, 2);
			obj.sharedMaterials = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index sharedMaterials on a nil value");
		}
	}
}

