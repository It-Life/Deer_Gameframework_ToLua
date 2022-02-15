
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-15 07-58-24  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-15 07-58-24  
---版 本 : 0.1 
---===============================================
---@class UIFormGroupType
---@field Group1 基础窗体
UIFormGroupType = 
{
    Group1 = 1,
    Group2 = 2,
    Group3 = 3,
    Group4 = 4,
    Group5 = 5,
    Group6 = 6,
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