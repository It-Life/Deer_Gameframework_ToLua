-- Generated By protoc-gen-lua Do not Edit
local protobuf = require "protobuf.protobuf"
local _M = {}

_M.ITEM_CONFIG = protobuf.Descriptor();
_M.ITEM_CONFIG_ID_FIELD = protobuf.FieldDescriptor();
_M.ITEM_CONFIG_ITEM_NAME_FIELD = protobuf.FieldDescriptor();
_M.ITEM_CONFIG_ITEM_ICON_FIELD = protobuf.FieldDescriptor();
_M.ITEM_CONFIG_ITEM_QUA_FIELD = protobuf.FieldDescriptor();
_M.ITEM_CONFIG_ITEM_TYPE_FIELD = protobuf.FieldDescriptor();
_M.ITEM_CONFIG_ITEM_PILE_NUM_FIELD = protobuf.FieldDescriptor();
_M.ITEM_CONFIG_DATA = protobuf.Descriptor();
_M.ITEM_CONFIG_DATA_ITEMS_FIELD = protobuf.FieldDescriptor();

_M.ITEM_CONFIG_ID_FIELD.name = "id"
_M.ITEM_CONFIG_ID_FIELD.full_name = ".ConfigData.Item_Config.id"
_M.ITEM_CONFIG_ID_FIELD.number = 1
_M.ITEM_CONFIG_ID_FIELD.index = 0
_M.ITEM_CONFIG_ID_FIELD.label = 1
_M.ITEM_CONFIG_ID_FIELD.has_default_value = false
_M.ITEM_CONFIG_ID_FIELD.default_value = 0
_M.ITEM_CONFIG_ID_FIELD.type = 13
_M.ITEM_CONFIG_ID_FIELD.cpp_type = 3

_M.ITEM_CONFIG_ITEM_NAME_FIELD.name = "item_name"
_M.ITEM_CONFIG_ITEM_NAME_FIELD.full_name = ".ConfigData.Item_Config.item_name"
_M.ITEM_CONFIG_ITEM_NAME_FIELD.number = 2
_M.ITEM_CONFIG_ITEM_NAME_FIELD.index = 1
_M.ITEM_CONFIG_ITEM_NAME_FIELD.label = 1
_M.ITEM_CONFIG_ITEM_NAME_FIELD.has_default_value = false
_M.ITEM_CONFIG_ITEM_NAME_FIELD.default_value = ""
_M.ITEM_CONFIG_ITEM_NAME_FIELD.type = 9
_M.ITEM_CONFIG_ITEM_NAME_FIELD.cpp_type = 9

_M.ITEM_CONFIG_ITEM_ICON_FIELD.name = "item_icon"
_M.ITEM_CONFIG_ITEM_ICON_FIELD.full_name = ".ConfigData.Item_Config.item_icon"
_M.ITEM_CONFIG_ITEM_ICON_FIELD.number = 3
_M.ITEM_CONFIG_ITEM_ICON_FIELD.index = 2
_M.ITEM_CONFIG_ITEM_ICON_FIELD.label = 1
_M.ITEM_CONFIG_ITEM_ICON_FIELD.has_default_value = false
_M.ITEM_CONFIG_ITEM_ICON_FIELD.default_value = ""
_M.ITEM_CONFIG_ITEM_ICON_FIELD.type = 9
_M.ITEM_CONFIG_ITEM_ICON_FIELD.cpp_type = 9

_M.ITEM_CONFIG_ITEM_QUA_FIELD.name = "item_qua"
_M.ITEM_CONFIG_ITEM_QUA_FIELD.full_name = ".ConfigData.Item_Config.item_qua"
_M.ITEM_CONFIG_ITEM_QUA_FIELD.number = 4
_M.ITEM_CONFIG_ITEM_QUA_FIELD.index = 3
_M.ITEM_CONFIG_ITEM_QUA_FIELD.label = 1
_M.ITEM_CONFIG_ITEM_QUA_FIELD.has_default_value = false
_M.ITEM_CONFIG_ITEM_QUA_FIELD.default_value = 0
_M.ITEM_CONFIG_ITEM_QUA_FIELD.type = 13
_M.ITEM_CONFIG_ITEM_QUA_FIELD.cpp_type = 3

_M.ITEM_CONFIG_ITEM_TYPE_FIELD.name = "item_type"
_M.ITEM_CONFIG_ITEM_TYPE_FIELD.full_name = ".ConfigData.Item_Config.item_type"
_M.ITEM_CONFIG_ITEM_TYPE_FIELD.number = 5
_M.ITEM_CONFIG_ITEM_TYPE_FIELD.index = 4
_M.ITEM_CONFIG_ITEM_TYPE_FIELD.label = 1
_M.ITEM_CONFIG_ITEM_TYPE_FIELD.has_default_value = false
_M.ITEM_CONFIG_ITEM_TYPE_FIELD.default_value = 0
_M.ITEM_CONFIG_ITEM_TYPE_FIELD.type = 13
_M.ITEM_CONFIG_ITEM_TYPE_FIELD.cpp_type = 3

_M.ITEM_CONFIG_ITEM_PILE_NUM_FIELD.name = "item_pile_num"
_M.ITEM_CONFIG_ITEM_PILE_NUM_FIELD.full_name = ".ConfigData.Item_Config.item_pile_num"
_M.ITEM_CONFIG_ITEM_PILE_NUM_FIELD.number = 6
_M.ITEM_CONFIG_ITEM_PILE_NUM_FIELD.index = 5
_M.ITEM_CONFIG_ITEM_PILE_NUM_FIELD.label = 1
_M.ITEM_CONFIG_ITEM_PILE_NUM_FIELD.has_default_value = false
_M.ITEM_CONFIG_ITEM_PILE_NUM_FIELD.default_value = 0
_M.ITEM_CONFIG_ITEM_PILE_NUM_FIELD.type = 13
_M.ITEM_CONFIG_ITEM_PILE_NUM_FIELD.cpp_type = 3

_M.ITEM_CONFIG.name = "Item_Config"
_M.ITEM_CONFIG.full_name = ".ConfigData.Item_Config"
_M.ITEM_CONFIG.nested_types = {}
_M.ITEM_CONFIG.enum_types = {}
_M.ITEM_CONFIG.fields = {_M.ITEM_CONFIG_ID_FIELD, _M.ITEM_CONFIG_ITEM_NAME_FIELD, _M.ITEM_CONFIG_ITEM_ICON_FIELD, _M.ITEM_CONFIG_ITEM_QUA_FIELD, _M.ITEM_CONFIG_ITEM_TYPE_FIELD, _M.ITEM_CONFIG_ITEM_PILE_NUM_FIELD}
_M.ITEM_CONFIG.is_extendable = false
_M.ITEM_CONFIG.extensions = {}
_M.ITEM_CONFIG_DATA_ITEMS_FIELD.name = "items"
_M.ITEM_CONFIG_DATA_ITEMS_FIELD.full_name = ".ConfigData.Item_Config_Data.items"
_M.ITEM_CONFIG_DATA_ITEMS_FIELD.number = 1
_M.ITEM_CONFIG_DATA_ITEMS_FIELD.index = 0
_M.ITEM_CONFIG_DATA_ITEMS_FIELD.label = 3
_M.ITEM_CONFIG_DATA_ITEMS_FIELD.has_default_value = false
_M.ITEM_CONFIG_DATA_ITEMS_FIELD.default_value = {}
_M.ITEM_CONFIG_DATA_ITEMS_FIELD.message_type = _M.ITEM_CONFIG
_M.ITEM_CONFIG_DATA_ITEMS_FIELD.type = 11
_M.ITEM_CONFIG_DATA_ITEMS_FIELD.cpp_type = 10

_M.ITEM_CONFIG_DATA.name = "Item_Config_Data"
_M.ITEM_CONFIG_DATA.full_name = ".ConfigData.Item_Config_Data"
_M.ITEM_CONFIG_DATA.nested_types = {}
_M.ITEM_CONFIG_DATA.enum_types = {}
_M.ITEM_CONFIG_DATA.fields = {_M.ITEM_CONFIG_DATA_ITEMS_FIELD}
_M.ITEM_CONFIG_DATA.is_extendable = false
_M.ITEM_CONFIG_DATA.extensions = {}

_M.Item_Config = protobuf.Message(_M.ITEM_CONFIG)
_M.Item_Config_Data = protobuf.Message(_M.ITEM_CONFIG_DATA)

return _M