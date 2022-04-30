-- Generated By protoc-gen-lua Do not Edit
local protobuf = require "protobuf.protobuf"
local _M = {}

_M.SYSTEM_CONFIG = protobuf.Descriptor();
_M.SYSTEM_CONFIG_ID_FIELD = protobuf.FieldDescriptor();
_M.SYSTEM_CONFIG_SYSTEMNAME_FIELD = protobuf.FieldDescriptor();
_M.SYSTEM_CONFIG_SYSTEMICON_FIELD = protobuf.FieldDescriptor();
_M.SYSTEM_CONFIG_DATA = protobuf.Descriptor();
_M.SYSTEM_CONFIG_DATA_ITEMS_FIELD = protobuf.FieldDescriptor();

_M.SYSTEM_CONFIG_ID_FIELD.name = "ID"
_M.SYSTEM_CONFIG_ID_FIELD.full_name = ".ConfigData.System_Config.ID"
_M.SYSTEM_CONFIG_ID_FIELD.number = 1
_M.SYSTEM_CONFIG_ID_FIELD.index = 0
_M.SYSTEM_CONFIG_ID_FIELD.label = 1
_M.SYSTEM_CONFIG_ID_FIELD.has_default_value = false
_M.SYSTEM_CONFIG_ID_FIELD.default_value = ""
_M.SYSTEM_CONFIG_ID_FIELD.type = 9
_M.SYSTEM_CONFIG_ID_FIELD.cpp_type = 9

_M.SYSTEM_CONFIG_SYSTEMNAME_FIELD.name = "SystemName"
_M.SYSTEM_CONFIG_SYSTEMNAME_FIELD.full_name = ".ConfigData.System_Config.SystemName"
_M.SYSTEM_CONFIG_SYSTEMNAME_FIELD.number = 2
_M.SYSTEM_CONFIG_SYSTEMNAME_FIELD.index = 1
_M.SYSTEM_CONFIG_SYSTEMNAME_FIELD.label = 1
_M.SYSTEM_CONFIG_SYSTEMNAME_FIELD.has_default_value = false
_M.SYSTEM_CONFIG_SYSTEMNAME_FIELD.default_value = ""
_M.SYSTEM_CONFIG_SYSTEMNAME_FIELD.type = 9
_M.SYSTEM_CONFIG_SYSTEMNAME_FIELD.cpp_type = 9

_M.SYSTEM_CONFIG_SYSTEMICON_FIELD.name = "SystemIcon"
_M.SYSTEM_CONFIG_SYSTEMICON_FIELD.full_name = ".ConfigData.System_Config.SystemIcon"
_M.SYSTEM_CONFIG_SYSTEMICON_FIELD.number = 3
_M.SYSTEM_CONFIG_SYSTEMICON_FIELD.index = 2
_M.SYSTEM_CONFIG_SYSTEMICON_FIELD.label = 1
_M.SYSTEM_CONFIG_SYSTEMICON_FIELD.has_default_value = false
_M.SYSTEM_CONFIG_SYSTEMICON_FIELD.default_value = ""
_M.SYSTEM_CONFIG_SYSTEMICON_FIELD.type = 9
_M.SYSTEM_CONFIG_SYSTEMICON_FIELD.cpp_type = 9

_M.SYSTEM_CONFIG.name = "System_Config"
_M.SYSTEM_CONFIG.full_name = ".ConfigData.System_Config"
_M.SYSTEM_CONFIG.nested_types = {}
_M.SYSTEM_CONFIG.enum_types = {}
_M.SYSTEM_CONFIG.fields = {_M.SYSTEM_CONFIG_ID_FIELD, _M.SYSTEM_CONFIG_SYSTEMNAME_FIELD, _M.SYSTEM_CONFIG_SYSTEMICON_FIELD}
_M.SYSTEM_CONFIG.is_extendable = false
_M.SYSTEM_CONFIG.extensions = {}
_M.SYSTEM_CONFIG_DATA_ITEMS_FIELD.name = "items"
_M.SYSTEM_CONFIG_DATA_ITEMS_FIELD.full_name = ".ConfigData.System_Config_Data.items"
_M.SYSTEM_CONFIG_DATA_ITEMS_FIELD.number = 1
_M.SYSTEM_CONFIG_DATA_ITEMS_FIELD.index = 0
_M.SYSTEM_CONFIG_DATA_ITEMS_FIELD.label = 3
_M.SYSTEM_CONFIG_DATA_ITEMS_FIELD.has_default_value = false
_M.SYSTEM_CONFIG_DATA_ITEMS_FIELD.default_value = {}
_M.SYSTEM_CONFIG_DATA_ITEMS_FIELD.message_type = _M.SYSTEM_CONFIG
_M.SYSTEM_CONFIG_DATA_ITEMS_FIELD.type = 11
_M.SYSTEM_CONFIG_DATA_ITEMS_FIELD.cpp_type = 10

_M.SYSTEM_CONFIG_DATA.name = "System_Config_Data"
_M.SYSTEM_CONFIG_DATA.full_name = ".ConfigData.System_Config_Data"
_M.SYSTEM_CONFIG_DATA.nested_types = {}
_M.SYSTEM_CONFIG_DATA.enum_types = {}
_M.SYSTEM_CONFIG_DATA.fields = {_M.SYSTEM_CONFIG_DATA_ITEMS_FIELD}
_M.SYSTEM_CONFIG_DATA.is_extendable = false
_M.SYSTEM_CONFIG_DATA.extensions = {}

_M.System_Config = protobuf.Message(_M.SYSTEM_CONFIG)
_M.System_Config_Data = protobuf.Message(_M.SYSTEM_CONFIG_DATA)

return _M