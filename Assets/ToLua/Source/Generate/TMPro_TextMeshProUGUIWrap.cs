﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class TMPro_TextMeshProUGUIWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TMPro.TextMeshProUGUI), typeof(TMPro.TMP_Text));
		L.RegFunction("ComputeMarginSize", new LuaCSFunction(ComputeMarginSize));
		L.RegFunction("CalculateLayoutInputHorizontal", new LuaCSFunction(CalculateLayoutInputHorizontal));
		L.RegFunction("CalculateLayoutInputVertical", new LuaCSFunction(CalculateLayoutInputVertical));
		L.RegFunction("SetVerticesDirty", new LuaCSFunction(SetVerticesDirty));
		L.RegFunction("SetLayoutDirty", new LuaCSFunction(SetLayoutDirty));
		L.RegFunction("SetMaterialDirty", new LuaCSFunction(SetMaterialDirty));
		L.RegFunction("SetAllDirty", new LuaCSFunction(SetAllDirty));
		L.RegFunction("Rebuild", new LuaCSFunction(Rebuild));
		L.RegFunction("GetModifiedMaterial", new LuaCSFunction(GetModifiedMaterial));
		L.RegFunction("RecalculateClipping", new LuaCSFunction(RecalculateClipping));
		L.RegFunction("Cull", new LuaCSFunction(Cull));
		L.RegFunction("UpdateMeshPadding", new LuaCSFunction(UpdateMeshPadding));
		L.RegFunction("ForceMeshUpdate", new LuaCSFunction(ForceMeshUpdate));
		L.RegFunction("GetTextInfo", new LuaCSFunction(GetTextInfo));
		L.RegFunction("ClearMesh", new LuaCSFunction(ClearMesh));
		L.RegFunction("UpdateGeometry", new LuaCSFunction(UpdateGeometry));
		L.RegFunction("UpdateVertexData", new LuaCSFunction(UpdateVertexData));
		L.RegFunction("UpdateFontAsset", new LuaCSFunction(UpdateFontAsset));
		L.RegFunction("__eq", new LuaCSFunction(op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("materialForRendering", new LuaCSFunction(get_materialForRendering), null);
		L.RegVar("autoSizeTextContainer", new LuaCSFunction(get_autoSizeTextContainer), new LuaCSFunction(set_autoSizeTextContainer));
		L.RegVar("mesh", new LuaCSFunction(get_mesh), null);
		L.RegVar("canvasRenderer", new LuaCSFunction(get_canvasRenderer), null);
		L.RegVar("maskOffset", new LuaCSFunction(get_maskOffset), new LuaCSFunction(set_maskOffset));
		L.RegVar("OnPreRenderText", new LuaCSFunction(get_OnPreRenderText), new LuaCSFunction(set_OnPreRenderText));
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ComputeMarginSize(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
			obj.ComputeMarginSize();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CalculateLayoutInputHorizontal(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
			obj.CalculateLayoutInputHorizontal();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CalculateLayoutInputVertical(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
			obj.CalculateLayoutInputVertical();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetVerticesDirty(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
			obj.SetVerticesDirty();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetLayoutDirty(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
			obj.SetLayoutDirty();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetMaterialDirty(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
			obj.SetMaterialDirty();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetAllDirty(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
			obj.SetAllDirty();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Rebuild(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
			UnityEngine.UI.CanvasUpdate arg0 = (UnityEngine.UI.CanvasUpdate)ToLua.CheckObject(L, 2, TypeTraits<UnityEngine.UI.CanvasUpdate>.type);
			obj.Rebuild(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetModifiedMaterial(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
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
	static int RecalculateClipping(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
			obj.RecalculateClipping();
			return 0;
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
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
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
	static int UpdateMeshPadding(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
			obj.UpdateMeshPadding();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ForceMeshUpdate(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
				obj.ForceMeshUpdate();
				return 0;
			}
			else if (count == 2)
			{
				TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
				bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
				obj.ForceMeshUpdate(arg0);
				return 0;
			}
			else if (count == 3)
			{
				TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
				bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
				bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
				obj.ForceMeshUpdate(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: TMPro.TextMeshProUGUI.ForceMeshUpdate");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTextInfo(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			TMPro.TMP_TextInfo o = obj.GetTextInfo(arg0);
			ToLua.PushObject(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearMesh(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
				obj.ClearMesh();
				return 0;
			}
			else if (count == 2)
			{
				TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
				bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
				obj.ClearMesh(arg0);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: TMPro.TextMeshProUGUI.ClearMesh");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UpdateGeometry(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
			UnityEngine.Mesh arg0 = (UnityEngine.Mesh)ToLua.CheckObject<UnityEngine.Mesh>(L, 2);
			int arg1 = (int)LuaDLL.luaL_checkinteger(L, 3);
			obj.UpdateGeometry(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UpdateVertexData(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
				obj.UpdateVertexData();
				return 0;
			}
			else if (count == 2)
			{
				TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
				TMPro.TMP_VertexDataUpdateFlags arg0 = (TMPro.TMP_VertexDataUpdateFlags)ToLua.CheckObject(L, 2, TypeTraits<TMPro.TMP_VertexDataUpdateFlags>.type);
				obj.UpdateVertexData(arg0);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: TMPro.TextMeshProUGUI.UpdateVertexData");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UpdateFontAsset(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
			obj.UpdateFontAsset();
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
	static int get_materialForRendering(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)o;
			UnityEngine.Material ret = obj.materialForRendering;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index materialForRendering on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_autoSizeTextContainer(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)o;
			bool ret = obj.autoSizeTextContainer;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index autoSizeTextContainer on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mesh(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)o;
			UnityEngine.Mesh ret = obj.mesh;
			ToLua.PushSealed(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index mesh on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_canvasRenderer(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)o;
			UnityEngine.CanvasRenderer ret = obj.canvasRenderer;
			ToLua.PushSealed(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index canvasRenderer on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maskOffset(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)o;
			UnityEngine.Vector4 ret = obj.maskOffset;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index maskOffset on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OnPreRenderText(IntPtr L)
	{
		ToLua.Push(L, new EventObject(typeof(System.Action<TMPro.TMP_TextInfo>)));
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_autoSizeTextContainer(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.autoSizeTextContainer = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index autoSizeTextContainer on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maskOffset(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)o;
			UnityEngine.Vector4 arg0 = ToLua.ToVector4(L, 2);
			obj.maskOffset = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index maskOffset on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_OnPreRenderText(IntPtr L)
	{
		try
		{
			TMPro.TextMeshProUGUI obj = (TMPro.TextMeshProUGUI)ToLua.CheckObject<TMPro.TextMeshProUGUI>(L, 1);
			EventObject arg0 = null;

			if (LuaDLL.lua_isuserdata(L, 2) != 0)
			{
				arg0 = (EventObject)ToLua.ToObject(L, 2);
			}
			else
			{
				return LuaDLL.luaL_throw(L, "The event 'TMPro.TextMeshProUGUI.OnPreRenderText' can only appear on the left hand side of += or -= when used outside of the type 'TMPro.TextMeshProUGUI'");
			}

			if (arg0.op == EventOp.Add)
			{
				System.Action<TMPro.TMP_TextInfo> ev = (System.Action<TMPro.TMP_TextInfo>)arg0.func;
				obj.OnPreRenderText += ev;
			}
			else if (arg0.op == EventOp.Sub)
			{
				System.Action<TMPro.TMP_TextInfo> ev = (System.Action<TMPro.TMP_TextInfo>)arg0.func;
				obj.OnPreRenderText -= ev;
			}

			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

