
---================================================
---描 述 :  
---作 者 : XinDu 
---创建时间 : 2022/3/26 22:40:46 
---修改作者 : XinDu 
---修改时间 : 2022/3/26 22:40:46  
---版 本 : 0.1 
---===============================================

---Do not modify it, it is automatically generated
---服务器发送协议的proto解码信息

local _M = {
    [PTC_C2S_HeartBeat] = { ModulePb = DeerGameBase_pb, ProtoName = "CSHeartBeat" },
    [PTC_S2C_HeartBeat] = { ModulePb = DeerGameBase_pb, ProtoName = "SCHeartBeat" },
    [PTC_C2G_LOGININFO] = { ModulePb = DPLogin_pb, ProtoName = "DPUserLoginInfoReq" },
    [PTC_G2C_ACC_VERIFY_RESULT] = { ModulePb = DPLogin_pb, ProtoName = "DPAccountVerifyResultResp" },
    [PTC_C2S_LOGICLOGIN] = { ModulePb = DPLogin_pb, ProtoName = "DPGSLogicLoginReq" },
    [PTC_S2C_LOGICLOIN_RET] = { ModulePb = DPLogin_pb, ProtoName = "DPGSLogicLoginRetResp" },
    [PTC_G2C_ROLELIST_RESPONE] = { ModulePb = DPLogin_pb, ProtoName = "DPRoleListResponeResp" },
    [PTC_C2G_GAMELOGIN_REQUEST] = { ModulePb = DPLogin_pb, ProtoName = "DPGameLoginRequestReq" },
    [PTC_C2G_CREATE_ROLE] = { ModulePb = DPLogin_pb, ProtoName = "DPCreateRoleReq" },
    [PTC_G2C_CREATEROLE_RESULT] = { ModulePb = DPLogin_pb, ProtoName = "DPCreateRoleResultResp" },
    [PTC_G2C_KICKOUTCLIENT] = { ModulePb = DPLogin_pb, ProtoName = "DPKickOutClientResp" },
    [PTC_C2S_EXITACCOUNT] = { ModulePb = DPLogin_pb, ProtoName = "DPGSExitAccountReq" },
    [PTC_C2S_EXITROLE] = { ModulePb = DPLogin_pb, ProtoName = "DPGSExitRoleReq" },
}
return _M

