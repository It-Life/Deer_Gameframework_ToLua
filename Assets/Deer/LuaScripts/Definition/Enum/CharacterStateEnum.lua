
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-09-08 07-50-34  
---修改作者 : 杜鑫 
---修改时间 : 2021-09-08 07-50-34  
---版 本 : 0.1 
---===============================================
---@class CharacterStateEnum
CharacterStateEnum =
{
    IdleState = "IdleState",
    MoveState = "MoveState",
    JumpState = "JumpState",
}
---@class CharacterAppearEnum
CharacterAppearEnum = 
{
    IdleAppear = "IdleAppear",
    MoveAppear = "MoveAppear",
}


---@class MoveMode
MoveMode =
{
    Null = 0,
    ---往前走
    Forward = 1,
    ---往前跑
    ForwardRun = 2,
    ---往后退
    Back = 3,
    ---往后跑
    BackRun = 4,
    ---走路进入跳跃
    Jump = 5,
    ---跑步进入跳跃
    JumpRun = 6,
}
---@class MoveType
MoveType =
{
    Null = 0,
    ---向点运动
    MoveToPos = 1,
    ---向角色运动
    MoveToTarget = 2,
    ---向方向运动
    MoveToDir = 3,
    ---向点运动(不带寻路，用于网络同步情况)
    TransToPos = 4,
}