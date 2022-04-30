
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-09-08 07-50-34  
---修改作者 : 杜鑫 
---修改时间 : 2021-09-08 07-50-34  
---版 本 : 0.1 
---===============================================
---@class CharacterPlayerData: CharacterDataBase
CharacterPlayerData = Class("CharacterPlayerData",CharacterDataBase)


function CharacterPlayerData:__init()
    self.m_entityType = EntityEnum.CharacterPlayer
end

function CharacterPlayerData:__delete()

end

return CharacterPlayerData