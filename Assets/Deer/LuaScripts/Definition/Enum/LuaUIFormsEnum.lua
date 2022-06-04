
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-15 07-58-24  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-15 07-58-24  
---版 本 : 0.1 
---===============================================
---@class UIFormGroupType
UIFormGroupType = {}
---@field AlwaysBottom 如果不想区分太复杂那最底层的UI请使用这个
UIFormGroupType.AlwaysBottom = {name = "AlwaysBottom",sortingOrder = 1}
---@field Background 背景层 UI 打开此界面的时候隐藏其他Common界面
UIFormGroupType.Background = {name = "Background",sortingOrder = 2}
---@field AnimationUnder 动画层
UIFormGroupType.AnimationUnder = {name = "AnimationUnder",sortingOrder = 3}
---@field Common 普通层 UI 打开此类型界面，他的兄弟界面会被覆盖掉
UIFormGroupType.Common = {name = "Common",sortingOrder = 4}
---@field AnimationOn 动画层
UIFormGroupType.AnimationOn = {name = "AnimationOn",sortingOrder = 5}
---@field PopUI 弹出层UI 打开此类型的界面，不影响其他界面，可以打开多个
UIFormGroupType.PopUI = {name = "PopUI",sortingOrder = 6}
---@field Guide 引导层UI
UIFormGroupType.Guide = {name = "Guide",sortingOrder = 7}
---@field Const 持续存在层 UI
UIFormGroupType.Const = {name = "Const",sortingOrder = 8}
---@field Toast 对话框层 UI
UIFormGroupType.Toast = {name = "Toast",sortingOrder = 9}
---@field Forward 最高UI层用来放置UI特效和模型
UIFormGroupType.Forward = {name = "Forward",sortingOrder = 10}
---@field AlwaysTop 如果不想区分太复杂那最上层的UI请使用这个
UIFormGroupType.AlwaysTop = {name = "AlwaysTop",sortingOrder = 11}

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