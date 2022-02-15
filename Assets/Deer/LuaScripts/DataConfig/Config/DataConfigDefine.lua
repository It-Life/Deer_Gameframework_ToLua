
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-05 08-12-52  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-05 08-12-52  
---版 本 : 0.1 
---===============================================
---@class DataConfigDefine
---@field LoadFileConfig table
DataConfigDefine = {}
DataConfigDefine.LoadFileConfig = 
{
    [DataConfigNames.LanguageInfo]={ --语言表
        strName                 = DataConfigNames.LanguageInfo,
        strProtoParseName       = "Language_Config_Data",
        strProtoDataListName    = "items",
        tbConfigPbModule        = Language_Config_pb,
        strCsvName              = "Language_Config",
        tbModuleClass           = require "DataConfig/Info/DataConfigLanguageInfo",
    },
    [DataConfigNames.CharacterInfo]={ --语言表
        strName                 = DataConfigNames.CharacterInfo,
        strProtoParseName       = "Heroes_Config_Data",
        strProtoDataListName    = "items",
        tbConfigPbModule        = Heroes_Config_pb,
        strCsvName              = "Heroes_Config",
        tbModuleClass           = require "DataConfig/Info/DataConfigCharacterInfo",
    },
    [DataConfigNames.SceneScriptGroupInfo]={ --场景脚本组
        strName                 = DataConfigNames.SceneScriptGroupInfo,
        strProtoParseName       = "SceneScriptGroup_Config_Data",
        strProtoDataListName    = "items",
        tbConfigPbModule        = SceneScriptGroup_Config_pb,
        strCsvName              = "SceneScriptGroup_Config",
        tbModuleClass           = require "DataConfig/Info/DataConfigSceneGroupInfo",
    },
}

return DataConfigDefine