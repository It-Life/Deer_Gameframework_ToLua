﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class FileUtilsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(FileUtils), typeof(System.Object));
		L.RegFunction("CreateFile", new LuaCSFunction(CreateFile));
		L.RegFunction("FindFiles", new LuaCSFunction(FindFiles));
		L.RegFunction("ExistsFile", new LuaCSFunction(ExistsFile));
		L.RegFunction("BinToUtf8", new LuaCSFunction(BinToUtf8));
		L.RegFunction("FileReadAllBytes", new LuaCSFunction(FileReadAllBytes));
		L.RegFunction("GetPath", new LuaCSFunction(GetPath));
		L.RegFunction("Md5ByPathName", new LuaCSFunction(Md5ByPathName));
		L.RegFunction("GetLengthString", new LuaCSFunction(GetLengthString));
		L.RegFunction("GetByteLengthString", new LuaCSFunction(GetByteLengthString));
		L.RegFunction("New", new LuaCSFunction(_CreateFileUtils));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateFileUtils(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				FileUtils obj = new FileUtils();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: FileUtils.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateFile(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				string arg0 = ToLua.CheckString(L, 1);
				bool o = FileUtils.CreateFile(arg0);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else if (count == 2 && TypeChecker.CheckTypes<bool>(L, 2))
			{
				string arg0 = ToLua.CheckString(L, 1);
				bool arg1 = LuaDLL.lua_toboolean(L, 2);
				bool o = FileUtils.CreateFile(arg0, arg1);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else if (count == 2 && TypeChecker.CheckTypes<string>(L, 2))
			{
				string arg0 = ToLua.CheckString(L, 1);
				string arg1 = ToLua.ToString(L, 2);
				bool o = FileUtils.CreateFile(arg0, arg1);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else if (count == 3)
			{
				string arg0 = ToLua.CheckString(L, 1);
				string arg1 = ToLua.CheckString(L, 2);
				bool arg2 = LuaDLL.luaL_checkboolean(L, 3);
				bool o = FileUtils.CreateFile(arg0, arg1, arg2);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: FileUtils.CreateFile");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindFiles(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				string arg0 = ToLua.CheckString(L, 1);
				System.Collections.Generic.List<string> o = FileUtils.FindFiles(arg0);
				ToLua.PushSealed(L, o);
				return 1;
			}
			else if (count == 2)
			{
				string arg0 = ToLua.CheckString(L, 1);
				bool arg1 = LuaDLL.luaL_checkboolean(L, 2);
				System.Collections.Generic.List<string> o = FileUtils.FindFiles(arg0, arg1);
				ToLua.PushSealed(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: FileUtils.FindFiles");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ExistsFile(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			bool o = FileUtils.ExistsFile(arg0);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BinToUtf8(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			byte[] arg0 = ToLua.CheckByteBuffer(L, 1);
			string o = FileUtils.BinToUtf8(arg0);
			LuaDLL.lua_pushstring(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FileReadAllBytes(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			LuaInterface.LuaByteBuffer o = FileUtils.FileReadAllBytes(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPath(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			string o = FileUtils.GetPath(arg0);
			LuaDLL.lua_pushstring(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Md5ByPathName(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			string o = FileUtils.Md5ByPathName(arg0);
			LuaDLL.lua_pushstring(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLengthString(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			long arg0 = LuaDLL.tolua_checkint64(L, 1);
			string o = FileUtils.GetLengthString(arg0);
			LuaDLL.lua_pushstring(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetByteLengthString(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			long arg0 = LuaDLL.tolua_checkint64(L, 1);
			string o = FileUtils.GetByteLengthString(arg0);
			LuaDLL.lua_pushstring(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}
