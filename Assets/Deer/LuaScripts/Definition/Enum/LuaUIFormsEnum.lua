
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-15 07-58-24  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-15 07-58-24  
---版 本 : 0.1 
---===============================================
---@class UIFormGroupType
---@field AlwaysBottom 如果不想区分太复杂那最底层的UI请使用这个
---@field Background 背景层 UI
---@field AnimationUnder 动画层
---@field Common 普通层 UI
---@field AnimationOn 动画层
---@field PopUI 弹出层UI
---@field Guide 引导层UI
---@field Const 持续存在层 UI
---@field Toast 对话框层 UI
---@field Forward 最高UI层用来放置UI特效和模型
---@field AlwaysTop 如果不想区分太复杂那最上层的UI请使用这个
UIFormGroupType =
{
    AlwaysBottom = 1,
    Background = 2,
    AnimationUnder = 3,
    Common = 4,
    AnimationOn = 5,
    PopUI = 6,
    Guide = 7,
    Const = 8,
    Toast = 9,
    Forward = 10,
    AlwaysTop = 11,
}
---@class UIFormType
---@field Normal 基础窗体
---@field Fixed 固定窗体
---@field PopUp 弹出窗体
UIFormType = 
{
    Normal = "Normal",
    Fixed = "Fixed",
    PopUp = "PopUp",
}
---@class UIFormShowMode
---@field Normal 普通
---@field ReverseChange 反向切换
---@field HideOther 隐藏其他
UIFormShowMode = 
{
    Normal = "Normal",
    ReverseChange = "ReverseChange",
    HideOther = "HideOther",
}
---@class UIFormLucenyType
---@field Lucency 完全透明不能穿透
---@field Translucence 半透明不能穿透
---@field ImPenetrable 低透明度不能穿透
---@field Pentrate 可以穿透
UIFormLucenyType = 
{
    Lucency = "Lucency",
    Translucence = "Translucence",
    ImPenetrable = "ImPenetrable",
    Pentrate = "Pentrate",
}