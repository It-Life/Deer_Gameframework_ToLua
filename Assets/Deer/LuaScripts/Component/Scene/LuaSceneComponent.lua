
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-12-15 22-29-50  
---修改作者 : 杜鑫 
---修改时间 : 2021-12-15 22-29-50  
---版 本 : 0.1 
---===============================================
---@class LuaSceneComponent:LuaComponentBase
---@field _sceneScriptManager SceneScriptManager
LuaSceneComponent = Class("LuaSceneComponent",LuaComponentBase)

function LuaSceneComponent:__init()
    self._sceneScriptManager = SceneScriptManager:GetInstance()
    self._updateEvent = LuaGameEntry.LuaUpdate:AddUpdate(self.Update,self)
end

function LuaSceneComponent:__delete()
    self._sceneScriptManager:Delete()
    LuaGameEntry.LuaUpdate:RemoveUpdate(self._updateEvent)
end

function LuaSceneComponent:Update()
    self._sceneScriptManager:Update()
end


function LuaSceneComponent:LoadScene(assetPath)
    GameEntry.Scene:LoadScene(assetPath,AssetPriority.SceneAsset)
end

return LuaSceneComponent