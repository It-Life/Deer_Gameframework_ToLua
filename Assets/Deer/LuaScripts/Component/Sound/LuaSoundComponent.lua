
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-12-15 22-29-50  
---修改作者 : 杜鑫 
---修改时间 : 2021-12-15 22-29-50  
---版 本 : 0.1 
---===============================================
---@class LuaSoundComponent:LuaComponentBase
LuaSoundComponent = Class("LuaSoundComponent",LuaComponentBase)



function LuaSoundComponent:__init()
    self:AddSoundGroup(SoundGroup.Music,1)
    self:AddSoundGroup(SoundGroup.Sound,10)
    self:AddSoundGroup(SoundGroup.UISound,10)
end

function LuaSoundComponent:__delete()
end

function LuaSoundComponent:AddSoundGroup(soundGroupName,soundAgentHelperCount)
    return GameEntry.Sound:AddSoundGroup(soundGroupName,soundAgentHelperCount)
end

function LuaSoundComponent:PlayMusic(soundId,userData)
    return GameEntry.Sound:PlayMusic(soundId,userData)
end

function LuaSoundComponent:StopMusic()
    GameEntry.Sound:StopMusic()
end

function LuaSoundComponent:PlaySound(soundId,bindingEntity,userData)
    return GameEntry.Sound:PlaySound(soundId,bindingEntity,userData)
end

function LuaSoundComponent:PlayUISound(soundId,userData)
    return GameEntry.Sound:PlayUISound(soundId,userData)
end

function LuaSoundComponent:IsMuted(soundGroupName)
    return GameEntry.Sound:IsMuted(soundGroupName)
end
---获取音量
---@return number
function LuaSoundComponent:GetVolume(soundGroupName)
    return GameEntry.Sound:GetVolume(soundGroupName)
end

return LuaSoundComponent