﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Constant_AssetPriorityWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("AssetPriority");
		L.RegConstant("SceneAsset", 0);
		L.RegConstant("ConfigAsset", 100);
		L.RegConstant("UIFormAsset", 50);
		L.RegConstant("RolePlayerAsset", 90);
		L.RegConstant("TextureAsset", 50);
		L.RegConstant("SoundAsset", 30);
		L.RegConstant("UISoundAsset", 30);
		L.RegConstant("MusicAsset", 20);
		L.RegConstant("HUDAsset", 35);
		L.RegConstant("SceneUnit", 80);
		L.RegConstant("Weapon", 85);
		L.RegConstant("Material", 95);
		L.EndStaticLibs();
	}
}
