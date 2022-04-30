﻿// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-08-10 08-32-01  
//修改作者 : 杜鑫 
//修改时间 : 2021-08-10 08-32-01  
//版 本 : 0.1 
// ===============================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class EventName
{
    #region NetWork 0--9999
    public const uint EVENT_CS_NET_START = 0x000000;
    /// <summary>
    /// 连接成功
    /// </summary>
    public const uint EVENT_CS_NET_CONNECTED = 0x000001;
    /// <summary>
    /// 网络断开
    /// </summary>
    public const uint EVENT_CS_NET_CLOSE = 0x000002;
    /// <summary>
    /// 收到消息
    /// </summary>
    public const uint EVENT_CS_NET_RECEIVE = 0x000003;

    #endregion

    #region UI 10000-19999
    public const uint EVENT_CS_UI_START = 0x010000;
    /// <summary>
    /// 显示UI
    /// </summary>
    public const uint EVENT_CS_UI_SHOW_UI = 0x010001;
    /// <summary>
    /// 刷新进度条
    /// </summary>
    public const uint EVENT_CS_UI_REFRESH_LOADING_UI = 0x010002;
    /// <summary>
    /// 打开Tips界面
    /// </summary>
    public const uint EVENT_CS_UI_OPEN_TIPS_UI = 0x010003;
    /// <summary>
    /// 打开initform界面
    /// </summary>
    public const uint EVENT_CS_UI_OPEN_INITFORM_UI = 0x010004;
    /// <summary>
    /// Tips按钮回调界面
    /// </summary>
    public const uint EVENT_CS_UI_TIPS_CALLBACK = 0x010005;
    #endregion
    #region Game 20000-29999
    public const uint EVENT_CS_GAME_START = 0x020000;
    /// <summary>
    /// 角色移动
    /// </summary>
    public const uint EVENT_CS_GAME_MOVE_DIRECTION = 0x020001;
    /// <summary>
    /// 角色移动结束
    /// </summary>
    public const uint EVENT_CS_GAME_MOVE_END = 0x020002;
    /// <summary>
    /// 实体创建
    /// </summary>
    public const uint EVENT_CS_GAME_ENTITY_SHOW = 0x020003;
    /// <summary>
    /// 实体隐藏
    /// </summary>
    public const uint EVENT_CS_GAME_ENTITY_HIDE = 0x020004;
    /// <summary>
    /// 实体碰撞
    /// </summary>
    public const uint EVENT_CS_GAME_ENTITY_COLLISION = 0x020005;
    /// <summary>
    /// 实体触发
    /// </summary>
    public const uint EVENT_CS_GAME_ENTITY_TRIGGER = 0x020006;
    #endregion
    #region AR 30000-39999
    public const uint EVENT_CS_AR_START = 0x030000;
    /// <summary>
    /// Ar放置成功
    /// </summary>
    public const uint EVENT_CS_AR_PUT_SUCCESS = 0x030001;

    #endregion
}