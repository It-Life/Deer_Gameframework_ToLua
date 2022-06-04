
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-08-01 21-25-32  
---修改作者 : 杜鑫 
---修改时间 : 2021-08-01 21-25-32  
---版 本 : 0.1 
---===============================================
LuaGameUtils = {}

function LuaGameUtils.GetLuaUIScriptPath(strPath)
    local str = strPath
    return str
end

function LuaGameUtils.GetUIPrefabPath(strPath)
    local str = string.format("Assets/Deer/Asset/UI/UIPrefab/%s.prefab",strPath)
    return str
end

function LuaGameUtils.GetHealthBarPrefabPath(strPath)
    local str = string.format("Assets/Deer/Asset/UI/Prefab/HealthBar/%s.prefab",strPath)
    return str
end

function LuaGameUtils.GetUIAtlasPath(strPath)
    local str = string.format("Assets/Deer/Asset/UI/UIArt/Atlas/%s.asset",strPath)
    return str
end

function LuaGameUtils.GetUITexture2DPath(strPath)
    local str = string.format("Assets/Deer/Asset/UI/UIArt/Sprite/%s.png",strPath)
    return str
end

function LuaGameUtils.GetScenePath(strPath)
    local str = string.format("Assets/Deer/Asset/Scenes/%s.unity",strPath)
    return str
end

function LuaGameUtils.GetScenePrefabPath(strPath)
    local str = string.format("Assets/Deer/Asset/ScenesResources/Prefab/%s.prefab",strPath)
    return str
end

function LuaGameUtils.GetCharacterUIPrefabPath(strPath)
    local str = string.format("Assets/Deer/Asset/EntityPrefabs/Character/UI/%s.prefab",strPath)
    return str
end

function LuaGameUtils.GetEntityPrefabPath(strPath)
    local str = string.format("Assets/Deer/EntityPrefabs/%s.prefab",strPath)
    return str
end

return LuaGameUtils