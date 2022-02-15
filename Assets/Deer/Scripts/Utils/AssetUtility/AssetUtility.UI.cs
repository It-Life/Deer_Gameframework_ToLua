using System;
using GameFramework;

/// <summary>
/// 资源路径相关
/// </summary>
public static partial class AssetUtility
{
    /// <summary>
    /// UI相关
    /// </summary>
    public static class UI
    {

        /// <summary>
        /// 获取伤害预制
        /// </summary>
        /// <returns></returns>
        public static string GetUIDamagePrefabPath(string damagePrefabName)
        {
            return string.Format("Assets/Asset/UI/UIPrefab/UIUnit/DamagePrefab/{0}.prefab", damagePrefabName);
        }

        /// <summary>
        /// 获取UITopUnit预制
        /// </summary>
        /// <returns></returns>
        public static string GetUITopUnitPrefabPath(string prefabName)
        {
            return string.Format("Assets/Asset/UI/UIPrefab/UIUnit/UIFightUnit/{0}.prefab", prefabName);
        }

        /// <summary>
        /// 获取伤害预制
        /// </summary>
        /// <returns></returns>
        public static string GetHPChangePrefabPath()
        {
            return "Assets/Asset/UI/UIPrefab/UIUnit/HPChange.prefab";
        }

        /// <summary>
        /// 获取角色血条路径
        /// </summary>
        /// <returns></returns>
        public static string GetPlayerHudPath()
        {
            return "Assets/Asset/UI/UIPrefab/UIHUD/UIPlayerHUDPanel.prefab";
        }

        /// <summary>
        /// 获取怪物血条路径
        /// </summary>
        /// <returns></returns>
        public static string GetMonsterHudPath()
        {
            return "Assets/Asset/UI/UIPrefab/UIHUD/UIMonsterHUD.prefab";
        }

        /// <summary>
        /// 获取Npc头顶预制路径
        /// </summary>
        /// <returns></returns>
        public static string GetNpcHudPath()
        {
            return "Assets/Asset/UI/UIPrefab/UIHUD/UINpcHUDPanel.prefab";
        }

        /// <summary>
        /// 获取头像资源名称
        /// </summary>
        /// <param name="iconName"></param>
        /// <returns></returns>
        public static string GetHeadIcon(string iconName)
        {
            return string.Format("Assets/Asset/UI/IconNew/{0}.png", iconName);
        }

        /// <summary>
        /// 获取武器头像资源名称
        /// </summary>
        /// <param name="iconName"></param>
        /// <returns></returns>
        public static string GetWeaponIcon(string iconName)
        {
            return string.Format("Assets/Asset/UI/IconNew/{0}.png", iconName);
        }

        /// <summary>
        /// 获取默认Icon
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultIcon()
        {
            return "Assets/Asset/UI/IconNew/Icon_Empty.png";
        }
    }
}