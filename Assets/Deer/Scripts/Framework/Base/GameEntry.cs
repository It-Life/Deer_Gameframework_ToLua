using UnityEngine;


/// <summary>
/// 游戏入口。
/// </summary>
public partial class GameEntry : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        // 初始化内置组件
        InitBuiltinComponents();

        // 初始化自定义组件
        InitCustomComponents();

        // 初始化自定义调试器
        InitCustomDebuggers();
    }
}
