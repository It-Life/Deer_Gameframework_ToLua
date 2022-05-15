# Deer_Gameframework_ToLua
Gameframework 框架接入原生Tolua，框架旨在提供完整开发热更新流程，以及快速开发工具。

上手框架需要一定的开发经验程序。

### 1.Unity版本2021.3.0f1

### 2.[基于GameFramework](https://github.com/EllanJiang/GameFramework) 

### 3.基于**[tolua](https://github.com/topameng/tolua)**

### 4.消息协议及表读取**[protobuf](https://github.com/protocolbuffers/protobuf)**3.0，[提供生成表和协议工具](https://github.com/It-Life/Deer_Excel2Proto)支持多语言

### 5. [Idea](https://www.jetbrains.com/idea/)开发Lua 用到lua插件[emmylua](https://github.com/EmmyLua/IntelliJ-EmmyLua) [VS2022](https://visualstudio.microsoft.com/zh-hans/)开发C#

### 6.为了我们方便开发Lua，可以详细看Lua注释，可以快捷键定位代码块[emmylua 注释说明](https://emmylua.github.io/annotations/class.html)

### 7.提供[基础java服务器](https://github.com/It-Life/Deer_GameServer_Java_Netty) 用来测试网络消息传送用到消息模块Netty

框架以实现脱离C#,全部逻辑在Lua侧开发，实体生成，消息注册，UI框架，fsm状态机，网络消息，心跳，无限循环滑动等重要模块已经在Lua实现，lua实现流程化开发。目前实现（ProcedureMain入口流程）ProcedureLogin，ProcedureMainHall，ProcedureChangeScene

### 快捷键及快捷方式增加

​	1.Shift + A GameObject 显隐

​	2.Shift + S GameObject 预制件及变体 Apply All

​	3.Ctrl  + Shift + D 删除Hierarchy物体

​	4.Alt + K 显示Project里的文件大小

​	4.快速打开Idea Lua 工程 Assets--Open Lua Project In IDE,需要先设置Idea安装目录MyTools--SetPath--SetLuaIde(本质上支持vsCode),推荐Idea

### 

### 第三方插件 提供练习使用，商业项目请购买正版

​	1.AstarPathfindingProject 4.2.17

​	2.Demigiant

​	3.SuperScrollView

​	4.Sirenix

​	5.QHierarchy



