-- Generated By protoc-gen-lua Do not Edit
local protobuf = require "protobuf.protobuf"
local _M = {}

_M.CURRENCY_CONFIG = protobuf.Descriptor();
_M.CURRENCY_CONFIG_ID_FIELD = protobuf.FieldDescriptor();
_M.CURRENCY_CONFIG_CCYNAME_FIELD = protobuf.FieldDescriptor();
_M.CURRENCY_CONFIG_CCYICON_FIELD = protobuf.FieldDescriptor();
_M.CURRENCY_CONFIG_DATA = protobuf.Descriptor();
_M.CURRENCY_CONFIG_DATA_ITEMS_FIELD = protobuf.FieldDescriptor();

_M.CURRENCY_CONFIG_ID_FIELD.name = "ID"
_M.CURRENCY_CONFIG_ID_FIELD.full_name = ".ConfigData.Currency_Config.ID"
_M.CURRENCY_CONFIG_ID_FIELD.number = 1
_M.CURRENCY_CONFIG_ID_FIELD.index = 0
_M.CURRENCY_CONFIG_ID_FIELD.label = 1
_M.CURRENCY_CONFIG_ID_FIELD.has_default_value = false
_M.CURRENCY_CONFIG_ID_FIELD.default_value = ""
_M.CURRENCY_CONFIG_ID_FIELD.type = 9
_M.CURRENCY_CONFIG_ID_FIELD.cpp_type = 9

_M.CURRENCY_CONFIG_CCYNAME_FIELD.name = "CcyName"
_M.CURRENCY_CONFIG_CCYNAME_FIELD.full_name = ".ConfigData.Currency_Config.CcyName"
_M.CURRENCY_CONFIG_CCYNAME_FIELD.number = 2
_M.CURRENCY_CONFIG_CCYNAME_FIELD.index = 1
_M.CURRENCY_CONFIG_CCYNAME_FIELD.label = 1
_M.CURRENCY_CONFIG_CCYNAME_FIELD.has_default_value = false
_M.CURRENCY_CONFIG_CCYNAME_FIELD.default_value = ""
_M.CURRENCY_CONFIG_CCYNAME_FIELD.type = 9
_M.CURRENCY_CONFIG_CCYNAME_FIELD.cpp_type = 9

_M.CURRENCY_CONFIG_CCYICON_FIELD.name = "CcyIcon"
_M.CURRENCY_CONFIG_CCYICON_FIELD.full_name = ".ConfigData.Currency_Config.CcyIcon"
_M.CURRENCY_CONFIG_CCYICON_FIELD.number = 3
_M.CURRENCY_CONFIG_CCYICON_FIELD.index = 2
_M.CURRENCY_CONFIG_CCYICON_FIELD.label = 1
_M.CURRENCY_CONFIG_CCYICON_FIELD.has_default_value = false
_M.CURRENCY_CONFIG_CCYICON_FIELD.default_value = ""
_M.CURRENCY_CONFIG_CCYICON_FIELD.type = 9
_M.CURRENCY_CONFIG_CCYICON_FIELD.cpp_type = 9

_M.CURRENCY_CONFIG.name = "Currency_Config"
_M.CURRENCY_CONFIG.full_name = ".ConfigData.Currency_Config"
_M.CURRENCY_CONFIG.nested_types = {}
_M.CURRENCY_CONFIG.enum_types = {}
_M.CURRENCY_CONFIG.fields = {_M.CURRENCY_CONFIG_ID_FIELD, _M.CURRENCY_CONFIG_CCYNAME_FIELD, _M.CURRENCY_CONFIG_CCYICON_FIELD}
_M.CURRENCY_CONFIG.is_extendable = false
_M.CURRENCY_CONFIG.extensions = {}
_M.CURRENCY_CONFIG_DATA_ITEMS_FIELD.name = "items"
_M.CURRENCY_CONFIG_DATA_ITEMS_FIELD.full_name = ".ConfigData.Currency_Config_Data.items"
_M.CURRENCY_CONFIG_DATA_ITEMS_FIELD.number = 1
_M.CURRENCY_CONFIG_DATA_ITEMS_FIELD.index = 0
_M.CURRENCY_CONFIG_DATA_ITEMS_FIELD.label = 3
_M.CURRENCY_CONFIG_DATA_ITEMS_FIELD.has_default_value = false
_M.CURRENCY_CONFIG_DATA_ITEMS_FIELD.default_value = {}
_M.CURRENCY_CONFIG_DATA_ITEMS_FIELD.message_type = _M.CURRENCY_CONFIG
_M.CURRENCY_CONFIG_DATA_ITEMS_FIELD.type = 11
_M.CURRENCY_CONFIG_DATA_ITEMS_FIELD.cpp_type = 10

_M.CURRENCY_CONFIG_DATA.name = "Currency_Config_Data"
_M.CURRENCY_CONFIG_DATA.full_name = ".ConfigData.Currency_Config_Data"
_M.CURRENCY_CONFIG_DATA.nested_types = {}
_M.CURRENCY_CONFIG_DATA.enum_types = {}
_M.CURRENCY_CONFIG_DATA.fields = {_M.CURRENCY_CONFIG_DATA_ITEMS_FIELD}
_M.CURRENCY_CONFIG_DATA.is_extendable = false
_M.CURRENCY_CONFIG_DATA.extensions = {}

_M.Currency_Config = protobuf.Message(_M.CURRENCY_CONFIG)
_M.Currency_Config_Data = protobuf.Message(_M.CURRENCY_CONFIG_DATA)

return _M