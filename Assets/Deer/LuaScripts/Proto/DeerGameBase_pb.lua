-- Generated By protoc-gen-lua Do not Edit
local protobuf = require "protobuf.protobuf"
local _M = {}

_M.PACKETTYPE = protobuf.EnumDescriptor();
_M.PACKETTYPE_UNDEFINED_ENUM = protobuf.EnumValueDescriptor();
_M.PACKETTYPE_CLIENTTOSERVER_ENUM = protobuf.EnumValueDescriptor();
_M.PACKETTYPE_SERVERTOCLIENT_ENUM = protobuf.EnumValueDescriptor();
_M.PACKETHEADER = protobuf.Descriptor();
_M.PACKETHEADER_PACKETTYPE_FIELD = protobuf.FieldDescriptor();
_M.PACKETHEADER_ID_FIELD = protobuf.FieldDescriptor();
_M.PACKETHEADER_PACKETLENGTH_FIELD = protobuf.FieldDescriptor();
_M.PACKETHEADER_ISVALID_FIELD = protobuf.FieldDescriptor();
_M.CSHEARTBEAT = protobuf.Descriptor();
_M.CSHEARTBEAT_DWTIME_FIELD = protobuf.FieldDescriptor();
_M.SCHEARTBEAT = protobuf.Descriptor();
_M.SCHEARTBEAT_DWTIME_FIELD = protobuf.FieldDescriptor();
_M.DPROLEBASEINFO = protobuf.Descriptor();
_M.DPROLEBASEINFO_ULLROLEGUID_FIELD = protobuf.FieldDescriptor();
_M.DPROLEBASEINFO_SZROLENAME_FIELD = protobuf.FieldDescriptor();
_M.DPROLEBASEINFO_NLEVEL_FIELD = protobuf.FieldDescriptor();
_M.DPROLEBASEINFO_NPROFESSIONID_FIELD = protobuf.FieldDescriptor();
_M.DPROLEBASEINFO_NPORTRAITID_FIELD = protobuf.FieldDescriptor();
_M.DPROLEBASEINFO_NFIGHTPOWER_FIELD = protobuf.FieldDescriptor();
_M.DPROLEBASEINFO_NCLOTHID_FIELD = protobuf.FieldDescriptor();

_M.PACKETTYPE_UNDEFINED_ENUM.name = "Undefined"
_M.PACKETTYPE_UNDEFINED_ENUM.index = 0
_M.PACKETTYPE_UNDEFINED_ENUM.number = 0
_M.PACKETTYPE_CLIENTTOSERVER_ENUM.name = "ClientToServer"
_M.PACKETTYPE_CLIENTTOSERVER_ENUM.index = 1
_M.PACKETTYPE_CLIENTTOSERVER_ENUM.number = 1
_M.PACKETTYPE_SERVERTOCLIENT_ENUM.name = "ServerToClient"
_M.PACKETTYPE_SERVERTOCLIENT_ENUM.index = 2
_M.PACKETTYPE_SERVERTOCLIENT_ENUM.number = 2
_M.PACKETTYPE.name = "PacketType"
_M.PACKETTYPE.full_name = ".DeerGameBase.PacketType"
_M.PACKETTYPE.values = {_M.PACKETTYPE_UNDEFINED_ENUM,_M.PACKETTYPE_CLIENTTOSERVER_ENUM,_M.PACKETTYPE_SERVERTOCLIENT_ENUM}
_M.PACKETHEADER_PACKETTYPE_FIELD.name = "packetType"
_M.PACKETHEADER_PACKETTYPE_FIELD.full_name = ".DeerGameBase.PacketHeader.packetType"
_M.PACKETHEADER_PACKETTYPE_FIELD.number = 1
_M.PACKETHEADER_PACKETTYPE_FIELD.index = 0
_M.PACKETHEADER_PACKETTYPE_FIELD.label = 1
_M.PACKETHEADER_PACKETTYPE_FIELD.has_default_value = false
_M.PACKETHEADER_PACKETTYPE_FIELD.default_value = nil
_M.PACKETHEADER_PACKETTYPE_FIELD.enum_type = _M.PACKETTYPE
_M.PACKETHEADER_PACKETTYPE_FIELD.type = 14
_M.PACKETHEADER_PACKETTYPE_FIELD.cpp_type = 8

_M.PACKETHEADER_ID_FIELD.name = "id"
_M.PACKETHEADER_ID_FIELD.full_name = ".DeerGameBase.PacketHeader.id"
_M.PACKETHEADER_ID_FIELD.number = 2
_M.PACKETHEADER_ID_FIELD.index = 1
_M.PACKETHEADER_ID_FIELD.label = 1
_M.PACKETHEADER_ID_FIELD.has_default_value = false
_M.PACKETHEADER_ID_FIELD.default_value = 0
_M.PACKETHEADER_ID_FIELD.type = 3
_M.PACKETHEADER_ID_FIELD.cpp_type = 2

_M.PACKETHEADER_PACKETLENGTH_FIELD.name = "packetLength"
_M.PACKETHEADER_PACKETLENGTH_FIELD.full_name = ".DeerGameBase.PacketHeader.packetLength"
_M.PACKETHEADER_PACKETLENGTH_FIELD.number = 3
_M.PACKETHEADER_PACKETLENGTH_FIELD.index = 2
_M.PACKETHEADER_PACKETLENGTH_FIELD.label = 1
_M.PACKETHEADER_PACKETLENGTH_FIELD.has_default_value = false
_M.PACKETHEADER_PACKETLENGTH_FIELD.default_value = 0
_M.PACKETHEADER_PACKETLENGTH_FIELD.type = 3
_M.PACKETHEADER_PACKETLENGTH_FIELD.cpp_type = 2

_M.PACKETHEADER_ISVALID_FIELD.name = "isValid"
_M.PACKETHEADER_ISVALID_FIELD.full_name = ".DeerGameBase.PacketHeader.isValid"
_M.PACKETHEADER_ISVALID_FIELD.number = 4
_M.PACKETHEADER_ISVALID_FIELD.index = 3
_M.PACKETHEADER_ISVALID_FIELD.label = 1
_M.PACKETHEADER_ISVALID_FIELD.has_default_value = false
_M.PACKETHEADER_ISVALID_FIELD.default_value = false
_M.PACKETHEADER_ISVALID_FIELD.type = 8
_M.PACKETHEADER_ISVALID_FIELD.cpp_type = 7

_M.PACKETHEADER.name = "PacketHeader"
_M.PACKETHEADER.full_name = ".DeerGameBase.PacketHeader"
_M.PACKETHEADER.nested_types = {}
_M.PACKETHEADER.enum_types = {}
_M.PACKETHEADER.fields = {_M.PACKETHEADER_PACKETTYPE_FIELD, _M.PACKETHEADER_ID_FIELD, _M.PACKETHEADER_PACKETLENGTH_FIELD, _M.PACKETHEADER_ISVALID_FIELD}
_M.PACKETHEADER.is_extendable = false
_M.PACKETHEADER.extensions = {}
_M.CSHEARTBEAT_DWTIME_FIELD.name = "dwTime"
_M.CSHEARTBEAT_DWTIME_FIELD.full_name = ".DeerGameBase.CSHeartBeat.dwTime"
_M.CSHEARTBEAT_DWTIME_FIELD.number = 1
_M.CSHEARTBEAT_DWTIME_FIELD.index = 0
_M.CSHEARTBEAT_DWTIME_FIELD.label = 1
_M.CSHEARTBEAT_DWTIME_FIELD.has_default_value = false
_M.CSHEARTBEAT_DWTIME_FIELD.default_value = 0
_M.CSHEARTBEAT_DWTIME_FIELD.type = 3
_M.CSHEARTBEAT_DWTIME_FIELD.cpp_type = 2

_M.CSHEARTBEAT.name = "CSHeartBeat"
_M.CSHEARTBEAT.full_name = ".DeerGameBase.CSHeartBeat"
_M.CSHEARTBEAT.nested_types = {}
_M.CSHEARTBEAT.enum_types = {}
_M.CSHEARTBEAT.fields = {_M.CSHEARTBEAT_DWTIME_FIELD}
_M.CSHEARTBEAT.is_extendable = false
_M.CSHEARTBEAT.extensions = {}
_M.SCHEARTBEAT_DWTIME_FIELD.name = "dwTime"
_M.SCHEARTBEAT_DWTIME_FIELD.full_name = ".DeerGameBase.SCHeartBeat.dwTime"
_M.SCHEARTBEAT_DWTIME_FIELD.number = 1
_M.SCHEARTBEAT_DWTIME_FIELD.index = 0
_M.SCHEARTBEAT_DWTIME_FIELD.label = 1
_M.SCHEARTBEAT_DWTIME_FIELD.has_default_value = false
_M.SCHEARTBEAT_DWTIME_FIELD.default_value = 0
_M.SCHEARTBEAT_DWTIME_FIELD.type = 3
_M.SCHEARTBEAT_DWTIME_FIELD.cpp_type = 2

_M.SCHEARTBEAT.name = "SCHeartBeat"
_M.SCHEARTBEAT.full_name = ".DeerGameBase.SCHeartBeat"
_M.SCHEARTBEAT.nested_types = {}
_M.SCHEARTBEAT.enum_types = {}
_M.SCHEARTBEAT.fields = {_M.SCHEARTBEAT_DWTIME_FIELD}
_M.SCHEARTBEAT.is_extendable = false
_M.SCHEARTBEAT.extensions = {}
_M.DPROLEBASEINFO_ULLROLEGUID_FIELD.name = "ullRoleGuid"
_M.DPROLEBASEINFO_ULLROLEGUID_FIELD.full_name = ".DeerGameBase.DPRoleBaseInfo.ullRoleGuid"
_M.DPROLEBASEINFO_ULLROLEGUID_FIELD.number = 1
_M.DPROLEBASEINFO_ULLROLEGUID_FIELD.index = 0
_M.DPROLEBASEINFO_ULLROLEGUID_FIELD.label = 1
_M.DPROLEBASEINFO_ULLROLEGUID_FIELD.has_default_value = false
_M.DPROLEBASEINFO_ULLROLEGUID_FIELD.default_value = 0
_M.DPROLEBASEINFO_ULLROLEGUID_FIELD.type = 4
_M.DPROLEBASEINFO_ULLROLEGUID_FIELD.cpp_type = 4

_M.DPROLEBASEINFO_SZROLENAME_FIELD.name = "szRoleName"
_M.DPROLEBASEINFO_SZROLENAME_FIELD.full_name = ".DeerGameBase.DPRoleBaseInfo.szRoleName"
_M.DPROLEBASEINFO_SZROLENAME_FIELD.number = 2
_M.DPROLEBASEINFO_SZROLENAME_FIELD.index = 1
_M.DPROLEBASEINFO_SZROLENAME_FIELD.label = 1
_M.DPROLEBASEINFO_SZROLENAME_FIELD.has_default_value = false
_M.DPROLEBASEINFO_SZROLENAME_FIELD.default_value = ""
_M.DPROLEBASEINFO_SZROLENAME_FIELD.type = 9
_M.DPROLEBASEINFO_SZROLENAME_FIELD.cpp_type = 9

_M.DPROLEBASEINFO_NLEVEL_FIELD.name = "nLevel"
_M.DPROLEBASEINFO_NLEVEL_FIELD.full_name = ".DeerGameBase.DPRoleBaseInfo.nLevel"
_M.DPROLEBASEINFO_NLEVEL_FIELD.number = 3
_M.DPROLEBASEINFO_NLEVEL_FIELD.index = 2
_M.DPROLEBASEINFO_NLEVEL_FIELD.label = 1
_M.DPROLEBASEINFO_NLEVEL_FIELD.has_default_value = false
_M.DPROLEBASEINFO_NLEVEL_FIELD.default_value = 0
_M.DPROLEBASEINFO_NLEVEL_FIELD.type = 5
_M.DPROLEBASEINFO_NLEVEL_FIELD.cpp_type = 1

_M.DPROLEBASEINFO_NPROFESSIONID_FIELD.name = "nProfessionId"
_M.DPROLEBASEINFO_NPROFESSIONID_FIELD.full_name = ".DeerGameBase.DPRoleBaseInfo.nProfessionId"
_M.DPROLEBASEINFO_NPROFESSIONID_FIELD.number = 4
_M.DPROLEBASEINFO_NPROFESSIONID_FIELD.index = 3
_M.DPROLEBASEINFO_NPROFESSIONID_FIELD.label = 1
_M.DPROLEBASEINFO_NPROFESSIONID_FIELD.has_default_value = false
_M.DPROLEBASEINFO_NPROFESSIONID_FIELD.default_value = 0
_M.DPROLEBASEINFO_NPROFESSIONID_FIELD.type = 5
_M.DPROLEBASEINFO_NPROFESSIONID_FIELD.cpp_type = 1

_M.DPROLEBASEINFO_NPORTRAITID_FIELD.name = "nPortraitId"
_M.DPROLEBASEINFO_NPORTRAITID_FIELD.full_name = ".DeerGameBase.DPRoleBaseInfo.nPortraitId"
_M.DPROLEBASEINFO_NPORTRAITID_FIELD.number = 5
_M.DPROLEBASEINFO_NPORTRAITID_FIELD.index = 4
_M.DPROLEBASEINFO_NPORTRAITID_FIELD.label = 1
_M.DPROLEBASEINFO_NPORTRAITID_FIELD.has_default_value = false
_M.DPROLEBASEINFO_NPORTRAITID_FIELD.default_value = 0
_M.DPROLEBASEINFO_NPORTRAITID_FIELD.type = 5
_M.DPROLEBASEINFO_NPORTRAITID_FIELD.cpp_type = 1

_M.DPROLEBASEINFO_NFIGHTPOWER_FIELD.name = "nFightPower"
_M.DPROLEBASEINFO_NFIGHTPOWER_FIELD.full_name = ".DeerGameBase.DPRoleBaseInfo.nFightPower"
_M.DPROLEBASEINFO_NFIGHTPOWER_FIELD.number = 6
_M.DPROLEBASEINFO_NFIGHTPOWER_FIELD.index = 5
_M.DPROLEBASEINFO_NFIGHTPOWER_FIELD.label = 1
_M.DPROLEBASEINFO_NFIGHTPOWER_FIELD.has_default_value = false
_M.DPROLEBASEINFO_NFIGHTPOWER_FIELD.default_value = 0
_M.DPROLEBASEINFO_NFIGHTPOWER_FIELD.type = 5
_M.DPROLEBASEINFO_NFIGHTPOWER_FIELD.cpp_type = 1

_M.DPROLEBASEINFO_NCLOTHID_FIELD.name = "nClothId"
_M.DPROLEBASEINFO_NCLOTHID_FIELD.full_name = ".DeerGameBase.DPRoleBaseInfo.nClothId"
_M.DPROLEBASEINFO_NCLOTHID_FIELD.number = 7
_M.DPROLEBASEINFO_NCLOTHID_FIELD.index = 6
_M.DPROLEBASEINFO_NCLOTHID_FIELD.label = 1
_M.DPROLEBASEINFO_NCLOTHID_FIELD.has_default_value = false
_M.DPROLEBASEINFO_NCLOTHID_FIELD.default_value = 0
_M.DPROLEBASEINFO_NCLOTHID_FIELD.type = 5
_M.DPROLEBASEINFO_NCLOTHID_FIELD.cpp_type = 1

_M.DPROLEBASEINFO.name = "DPRoleBaseInfo"
_M.DPROLEBASEINFO.full_name = ".DeerGameBase.DPRoleBaseInfo"
_M.DPROLEBASEINFO.nested_types = {}
_M.DPROLEBASEINFO.enum_types = {}
_M.DPROLEBASEINFO.fields = {_M.DPROLEBASEINFO_ULLROLEGUID_FIELD, _M.DPROLEBASEINFO_SZROLENAME_FIELD, _M.DPROLEBASEINFO_NLEVEL_FIELD, _M.DPROLEBASEINFO_NPROFESSIONID_FIELD, _M.DPROLEBASEINFO_NPORTRAITID_FIELD, _M.DPROLEBASEINFO_NFIGHTPOWER_FIELD, _M.DPROLEBASEINFO_NCLOTHID_FIELD}
_M.DPROLEBASEINFO.is_extendable = false
_M.DPROLEBASEINFO.extensions = {}

ClientToServer = 1
ServerToClient = 2
Undefined = 0
_M.CSHeartBeat = protobuf.Message(_M.CSHEARTBEAT)
_M.DPRoleBaseInfo = protobuf.Message(_M.DPROLEBASEINFO)
_M.PacketHeader = protobuf.Message(_M.PACKETHEADER)
_M.SCHeartBeat = protobuf.Message(_M.SCHEARTBEAT)

return _M