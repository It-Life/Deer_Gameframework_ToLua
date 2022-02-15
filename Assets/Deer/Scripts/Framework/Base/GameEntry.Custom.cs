using Deer;
using UnityEngine;

/// <summary>
/// 游戏入口。
/// </summary>
public partial class GameEntry
{
    /// <summary>
    /// 获取游戏设置组件
    /// </summary>
    public static GameSettingsComponent GameSettings
    {
        get;
        private set;
    }
    public static LuaComponent Lua
    {
        get;
        private set;
    }
    public static DeerUIComponent UI
    {
        get;
        private set;
    }
    public static TPSpriteComponent TPSprite
    {
        get;
        private set;
    }
    public static MessengerComponent Messenger
    {
        get;
        private set;
    }
    public static CameraComponent Camera
    {
        get;
        private set;
    }
    public static NetConnectorComponent NetConnector
    {
        get;
        private set;
    }
    public static ConfigComponent Config
    {
        get;
        private set;
    }
    public static MainThreadDispatcherComponent MainThreadDispatcher
    {
        get;
        private set;
    }
    private static void InitCustomComponents()
    {
        // 注册自定义的组件
        MainThreadDispatcher = UnityGameFramework.Runtime.GameEntry.GetComponent<MainThreadDispatcherComponent>();
        Messenger = UnityGameFramework.Runtime.GameEntry.GetComponent<MessengerComponent>();
        GameSettings = UnityGameFramework.Runtime.GameEntry.GetComponent<GameSettingsComponent>();
        Lua = UnityGameFramework.Runtime.GameEntry.GetComponent<LuaComponent>();
        UI = UnityGameFramework.Runtime.GameEntry.GetComponent<DeerUIComponent>();
        TPSprite = UnityGameFramework.Runtime.GameEntry.GetComponent<TPSpriteComponent>();
        Camera = UnityGameFramework.Runtime.GameEntry.GetComponent<CameraComponent>();
        NetConnector = UnityGameFramework.Runtime.GameEntry.GetComponent<NetConnectorComponent>();
        Config = UnityGameFramework.Runtime.GameEntry.GetComponent<ConfigComponent>();
        InitComponentsSet();
    }

    private static void InitCustomDebuggers()
    {
        // 将来在这里注册自定义的调试器
    }
    /// <summary>
    /// 初始化组件一些设置
    /// </summary>
    private static void InitComponentsSet()
    {

    }
}
