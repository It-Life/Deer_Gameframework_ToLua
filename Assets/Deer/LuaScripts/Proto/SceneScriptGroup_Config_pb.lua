-- Generated By protoc-gen-lua Do not Edit
local protobuf = require "protobuf.protobuf"
local _M = {}

_M.SCENESCRIPTGROUP_CONFIG = protobuf.Descriptor();
_M.SCENESCRIPTGROUP_CONFIG_ID_FIELD = protobuf.FieldDescriptor();
_M.SCENESCRIPTGROUP_CONFIG_SCRIPT_NAME_FIELD = protobuf.FieldDescriptor();
_M.SCENESCRIPTGROUP_CONFIG_REMARK_FIELD = protobuf.FieldDescriptor();
_M.SCENESCRIPTGROUP_CONFIG_DATA = protobuf.Descriptor();
_M.SCENESCRIPTGROUP_CONFIG_DATA_ITEMS_FIELD = protobuf.FieldDescriptor();

_M.SCENESCRIPTGROUP_CONFIG_ID_FIELD.name = "id"
_M.SCENESCRIPTGROUP_CONFIG_ID_FIELD.full_name = ".ConfigData.SceneScriptGroup_Config.id"
_M.SCENESCRIPTGROUP_CONFIG_ID_FIELD.number = 1
_M.SCENESCRIPTGROUP_CONFIG_ID_FIELD.index = 0
_M.SCENESCRIPTGROUP_CONFIG_ID_FIELD.label = 1
_M.SCENESCRIPTGROUP_CONFIG_ID_FIELD.has_default_value = false
_M.SCENESCRIPTGROUP_CONFIG_ID_FIELD.default_value = 0
_M.SCENESCRIPTGROUP_CONFIG_ID_FIELD.type = 13
_M.SCENESCRIPTGROUP_CONFIG_ID_FIELD.cpp_type = 3

_M.SCENESCRIPTGROUP_CONFIG_SCRIPT_NAME_FIELD.name = "script_name"
_M.SCENESCRIPTGROUP_CONFIG_SCRIPT_NAME_FIELD.full_name = ".ConfigData.SceneScriptGroup_Config.script_name"
_M.SCENESCRIPTGROUP_CONFIG_SCRIPT_NAME_FIELD.number = 2
_M.SCENESCRIPTGROUP_CONFIG_SCRIPT_NAME_FIELD.index = 1
_M.SCENESCRIPTGROUP_CONFIG_SCRIPT_NAME_FIELD.label = 1
_M.SCENESCRIPTGROUP_CONFIG_SCRIPT_NAME_FIELD.has_default_value = false
_M.SCENESCRIPTGROUP_CONFIG_SCRIPT_NAME_FIELD.default_value = ""
_M.SCENESCRIPTGROUP_CONFIG_SCRIPT_NAME_FIELD.type = 9
_M.SCENESCRIPTGROUP_CONFIG_SCRIPT_NAME_FIELD.cpp_type = 9

_M.SCENESCRIPTGROUP_CONFIG_REMARK_FIELD.name = "remark"
_M.SCENESCRIPTGROUP_CONFIG_REMARK_FIELD.full_name = ".ConfigData.SceneScriptGroup_Config.remark"
_M.SCENESCRIPTGROUP_CONFIG_REMARK_FIELD.number = 3
_M.SCENESCRIPTGROUP_CONFIG_REMARK_FIELD.index = 2
_M.SCENESCRIPTGROUP_CONFIG_REMARK_FIELD.label = 1
_M.SCENESCRIPTGROUP_CONFIG_REMARK_FIELD.has_default_value = false
_M.SCENESCRIPTGROUP_CONFIG_REMARK_FIELD.default_value = ""
_M.SCENESCRIPTGROUP_CONFIG_REMARK_FIELD.type = 9
_M.SCENESCRIPTGROUP_CONFIG_REMARK_FIELD.cpp_type = 9

_M.SCENESCRIPTGROUP_CONFIG.name = "SceneScriptGroup_Config"
_M.SCENESCRIPTGROUP_CONFIG.full_name = ".ConfigData.SceneScriptGroup_Config"
_M.SCENESCRIPTGROUP_CONFIG.nested_types = {}
_M.SCENESCRIPTGROUP_CONFIG.enum_types = {}
_M.SCENESCRIPTGROUP_CONFIG.fields = {_M.SCENESCRIPTGROUP_CONFIG_ID_FIELD, _M.SCENESCRIPTGROUP_CONFIG_SCRIPT_NAME_FIELD, _M.SCENESCRIPTGROUP_CONFIG_REMARK_FIELD}
_M.SCENESCRIPTGROUP_CONFIG.is_extendable = false
_M.SCENESCRIPTGROUP_CONFIG.extensions = {}
_M.SCENESCRIPTGROUP_CONFIG_DATA_ITEMS_FIELD.name = "items"
_M.SCENESCRIPTGROUP_CONFIG_DATA_ITEMS_FIELD.full_name = ".ConfigData.SceneScriptGroup_Config_Data.items"
_M.SCENESCRIPTGROUP_CONFIG_DATA_ITEMS_FIELD.number = 1
_M.SCENESCRIPTGROUP_CONFIG_DATA_ITEMS_FIELD.index = 0
_M.SCENESCRIPTGROUP_CONFIG_DATA_ITEMS_FIELD.label = 3
_M.SCENESCRIPTGROUP_CONFIG_DATA_ITEMS_FIELD.has_default_value = false
_M.SCENESCRIPTGROUP_CONFIG_DATA_ITEMS_FIELD.default_value = {}
_M.SCENESCRIPTGROUP_CONFIG_DATA_ITEMS_FIELD.message_type = _M.SCENESCRIPTGROUP_CONFIG
_M.SCENESCRIPTGROUP_CONFIG_DATA_ITEMS_FIELD.type = 11
_M.SCENESCRIPTGROUP_CONFIG_DATA_ITEMS_FIELD.cpp_type = 10

_M.SCENESCRIPTGROUP_CONFIG_DATA.name = "SceneScriptGroup_Config_Data"
_M.SCENESCRIPTGROUP_CONFIG_DATA.full_name = ".ConfigData.SceneScriptGroup_Config_Data"
_M.SCENESCRIPTGROUP_CONFIG_DATA.nested_types = {}
_M.SCENESCRIPTGROUP_CONFIG_DATA.enum_types = {}
_M.SCENESCRIPTGROUP_CONFIG_DATA.fields = {_M.SCENESCRIPTGROUP_CONFIG_DATA_ITEMS_FIELD}
_M.SCENESCRIPTGROUP_CONFIG_DATA.is_extendable = false
_M.SCENESCRIPTGROUP_CONFIG_DATA.extensions = {}

_M.SceneScriptGroup_Config = protobuf.Message(_M.SCENESCRIPTGROUP_CONFIG)
_M.SceneScriptGroup_Config_Data = protobuf.Message(_M.SCENESCRIPTGROUP_CONFIG_DATA)

return _M