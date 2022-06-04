
---================================================
---描 述 :
---作 者 : Admin
---创建时间 : 2021-12-12 12-52-24 
---修改作者 : Admin 
---修改时间 : 2021-12-12 12-52-24 
---版 本 : $Version
---===============================================
UILoadingPanel = UILoadingPanel --Assets/Deer/Asset/UI/UIPrefab/UILoading/UILoadingPanel.prefab
---@class UILoadingPanel:UIBaseClass
--------------AutoGenerated--------------
---@field progressValue UnityEngine.UI.Image
--------------Do not modify!-------------
local UILoadingPanel = Class('UILoadingPanel', UIBaseClass)

function UILoadingPanel:OnShow()
    self.super.OnShow(self)
    self:RegisterEvent()
end

function UILoadingPanel:OnHide()
    self.super.OnHide(self)
    self:UnRegisterEvent()
end

function UILoadingPanel:RegisterEvent()
    self._onhandleloadscenesuccess = LuaGameEntry.LuaEvent:RegisterLuaEvent(EventId.EVENT_LUA_LOAD_SCENE_SUCCESS,self.OnHandleLoadSceneSuccess,self)
    self._onhandleloadsceneprogress = LuaGameEntry.LuaEvent:RegisterLuaEvent(EventId.EVENT_LUA_LOAD_SCENE_PROGRESS,self.OnHandleLoadSceneProgress,self)
end

function UILoadingPanel:UnRegisterEvent()
    LuaGameEntry.LuaEvent:UnRegisterLuaEvent(EventId.EVENT_LUA_LOAD_SCENE_SUCCESS,self._onhandleloadscenesuccess)
    LuaGameEntry.LuaEvent:UnRegisterLuaEvent(EventId.EVENT_LUA_LOAD_SCENE_PROGRESS,self._onhandleloadsceneprogress)
end

-----------------------------logic----------------------------------

-----------------------------event----------------------------------
function UILoadingPanel:OnHandleLoadSceneSuccess()
    self:Close()
end
function UILoadingPanel:OnHandleLoadSceneProgress(progress)
    self.progressValue.fillAmount = progress
end
-----------------------------button----------------------------------
return UILoadingPanel
