//================================================
//描 述 :  Lua组件  将 ToLua 插件集成到 UnityGameFramework 中。本类的实现参考 ToLua 中的 <see cref="LuaClient"/> 类
//作 者 : 杜鑫 
//创建时间 : 2021-07-03 10-47-49  
//修改作者 : 杜鑫 
//修改时间 : 2021-07-03 10-47-49  
//版 本 : 0.1 
// ===============================================

using LuaInterface;
using System.Collections.Generic;
using GameFramework.Resource;
using UnityEngine;
using UnityGameFramework.Runtime;

[DisallowMultipleComponent, AddComponentMenu("Deer/Lua")]
public sealed class LuaComponent : GameFrameworkComponent
{
    /// <summary>
    /// Lua 文件在 AssetBundle 中的扩展名。
    /// </summary>
    public const string LuaAssetExtInBundle = ".bytes";

    private LuaState _luaState;
    private Dictionary<string, byte[]> m_CachedLuaScripts = new Dictionary<string, byte[]>();
    private LoadAssetCallbacks m_LoadAssetCallbacks; //加载回调                    


    public delegate void OnLoadScriptSuccess(string fileName);

    public delegate void OnLoadScriptFailure(string fileName, LoadResourceStatus status, string errorMessage);

    protected override void Awake()
    {
        base.Awake();
        m_LoadAssetCallbacks = new LoadAssetCallbacks(OnLoadAssetSuccessCallback, OnLoadAssetFailureCallback);
    }

    public void StartLuaMain()
    {
        if (!LuaClient.Instance)
        {
            CustomLuaFileLoader.Instance.GetLuaScriptContent = GetScriptContent;
            gameObject.AddComponent<LuaClient>();
            _luaState = LuaClient.GetMainState();
        }
    }

    public LuaState GetMainState()
    {
        return _luaState;
    }

    public bool IsInitLuaComplete()
    {
        if (GetMainState()!= null)
        {
            return LuaClient.Instance.IsInitLuaComplete();
        }
        return false;
    }

    public object[] CallFunction(string funcName, int num)
    {
        if (_luaState == null)
        {
            return null;
        }

        LuaFunction func = _luaState.GetFunction(funcName);
        if (func != null)
        {
            //func.Call(args);
            //func.Dispose();
            //return null;
            //return func.LazyCall(args);
            return func.Invoke<int, object[]>(num);
        }

        return null;
    }

    public object[] CallFunction(string funcName, GameObject gameObject, int num)
    {
        if (_luaState == null)
        {
            return null;
        }

        LuaFunction func = _luaState.GetFunction(funcName);
        if (func != null)
        {
            //func.Call(args);
            //func.Dispose();
            //return null;
            //return func.LazyCall(args);
            return func.Invoke<GameObject, int, object[]>(gameObject, num);
        }

        return null;
    }

    public object[] CallFunction(string funcName, GameObject gameObject, int num,bool boolValue)
    {
        if (_luaState == null)
        {
            return null;
        }

        LuaFunction func = _luaState.GetFunction(funcName);
        if (func != null)
        {
            return func.Invoke<GameObject, int,bool, object[]>(gameObject, num, boolValue);
        }

        return null;
    }

    public void LuaGC()
    {
        if (GetMainState() != null)
        {
            GetMainState().LuaGC(LuaGCOptions.LUA_GCCOLLECT);
        }
    }

    private bool GetScriptContent(string fileName, out byte[] buffer)
    {
        return m_CachedLuaScripts.TryGetValue(fileName, out buffer);
    }

    /// <summary>
    /// 加载 Lua 脚本文件。
    /// </summary>
    /// <param name="assetPath">Lua 脚本的资源路径。</param>
    /// <param name="fileName">Lua 脚本文件名。</param>
    /// <param name="onSuccess">加载成功回调。</param>
    /// <param name="onFailure">加载失败回调。</param>
    public void LoadFile(string assetPath, string fileName, OnLoadScriptSuccess onSuccess,
        OnLoadScriptFailure onFailure = null)
    {
        if (m_CachedLuaScripts.ContainsKey(fileName) || Application.isEditor && GameEntry.Base.EditorResourceMode)
        {
            if (onSuccess != null)
            {
                onSuccess(fileName);
            }

            return;
        }

        // Load lua script from AssetBundle.
        var userData = new LoadLuaScriptUserData {FileName = fileName, OnSuccess = onSuccess, OnFailure = onFailure};

        // assetPath += LuaAssetExtInBundle;
        GameEntry.Resource.LoadAsset(assetPath, m_LoadAssetCallbacks, userData);
    }

    /// <summary>
    /// 卸载 Lua 脚本文件。
    /// </summary>
    /// <param name="fileName">文件名。</param>
    public void UnloadFile(string fileName)
    {
        if (Application.isEditor && GameEntry.Base.EditorResourceMode)
        {
            m_CachedLuaScripts.Remove(fileName);
        }
    }

    private void OnLoadAssetSuccessCallback(string assetName, object asset, float duration, object userData)
    {
        var myUserData = userData as LoadLuaScriptUserData;
        TextAsset textAsset = asset as TextAsset;
        if (textAsset == null)
        {
            throw new GameFramework.GameFrameworkException("The loaded asset should be a text asset.");
        }

        if (!m_CachedLuaScripts.ContainsKey(myUserData.FileName))
        {
            m_CachedLuaScripts.Add(myUserData.FileName, textAsset.bytes);
        }

        if (myUserData.OnSuccess != null)
        {
            myUserData.OnSuccess(myUserData.FileName);
        }

        GameEntry.Resource.UnloadAsset(asset);
    }

    private void OnLoadAssetFailureCallback(string assetName, LoadResourceStatus status, string errorMessage,
        object userData)
    {
        var myUserData = userData as LoadLuaScriptUserData;
        if (myUserData == null) return;

        if (myUserData.OnFailure != null)
        {
            myUserData.OnFailure(myUserData.FileName, status, errorMessage);
        }
    }

    private class LoadLuaScriptUserData
    {
        public string FileName;
        public OnLoadScriptSuccess OnSuccess;
        public OnLoadScriptFailure OnFailure;
    }
}