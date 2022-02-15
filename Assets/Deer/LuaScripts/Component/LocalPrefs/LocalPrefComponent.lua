
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-08-20 21-07-19  
---修改作者 : 杜鑫 
---修改时间 : 2021-08-20 21-07-19  
---版 本 : 0.1 
---===============================================
---@class LocalPrefComponent:LuaComponentBase
LocalPrefComponent = Class("LocalPrefComponent",LuaComponentBase)

---@param key string
---@return string
function LocalPrefComponent:GenKey(key)
    return key
end

---@param key string
---@param defaultValue string
function LocalPrefComponent:GetString(key, defaultValue)
    return PlayerPrefs.GetString(self:GenKey(key), defaultValue)
end

---@param key string
---@param value string
function LocalPrefComponent:SetString(key, value)
    PlayerPrefs.SetString(self:GenKey(key), value)
end

---@param key string
---@param defaultValue number
function LocalPrefComponent:GetInt(key, defaultValue)
    return PlayerPrefs.GetInt(self:GenKey(key), defaultValue)
end
---@param key string
---@param value number
function LocalPrefComponent:SetInt(key, value)
    PlayerPrefs.SetInt(self:GenKey(key), value)
end

---@param key string
---@param defaultValue number
function LocalPrefComponent:GetFloat(key, defaultValue)
    return PlayerPrefs.GetInt(self:GenKey(key), defaultValue)
end
---@param key string
---@param value number
function LocalPrefComponent:SetFloat(key, value)
    PlayerPrefs.SetFloat(self:GenKey(key), value)
end

function LocalPrefComponent:DeleteAll()
    PlayerPrefs.DeleteAll()
end
---@param key string
function LocalPrefComponent:DeleteKey(key)
    PlayerPrefs.DeleteKey(self:GenKey(key))
end

---@param key string
---@return boolean
function LocalPrefComponent:HasKey(key)
    return PlayerPrefs.HasKey(self:GenKey(key))
end

function LocalPrefComponent:Save()
    PlayerPrefs.Save()
end

return LocalPrefComponent