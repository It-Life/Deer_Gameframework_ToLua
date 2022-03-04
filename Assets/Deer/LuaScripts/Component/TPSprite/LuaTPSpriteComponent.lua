
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-08-05 01-02-56  
---修改作者 : 杜鑫 
---修改时间 : 2021-08-05 01-02-56  
---版 本 : 0.1 
---===============================================
---@class LuaTPSpriteComponent:LuaComponentBase
LuaTPSpriteComponent = Class("LuaTPSpriteComponent",LuaComponentBase)

function LuaTPSpriteComponent:__init()
end

function LuaTPSpriteComponent:__delete()
end

function LuaTPSpriteComponent:SetImageByAtlas(compImage,strPath,strSpriteName,setNativeSize)
    local str = LuaGameUtils.GetUIAtlasPath(strPath)
    self:SetImage(compImage,str,strSpriteName,setNativeSize)
end

function LuaTPSpriteComponent:SetImageByTexture(compImage,strPath,setNativeSize)
    local str = LuaGameUtils.GetUITexture2DPath(strPath)
    self:SetImage(compImage,str,"",setNativeSize)
end

function LuaTPSpriteComponent:SetImage(compImage,str,strSpriteName,setNativeSize)
    if setNativeSize then
        setNativeSize = true
    else
        setNativeSize = false
    end
    if string.isnullorempty(strSpriteName) then
        GameEntry.TPSprite:SetImage(compImage,str,setNativeSize)
    else
        GameEntry.TPSprite:SetImage(compImage,str,strSpriteName,setNativeSize)
    end
end


return LuaTPSpriteComponent