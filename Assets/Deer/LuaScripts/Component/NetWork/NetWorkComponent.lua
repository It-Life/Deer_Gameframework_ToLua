
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-09-04 17-37-42  
---修改作者 : 杜鑫 
---修改时间 : 2021-09-04 17-37-42  
---版 本 : 0.1 
---===============================================
---@class NetWorkComponent:LuaComponentBase
NetWorkComponent = Class("NetWorkComponent",LuaComponentBase)

local text_format = require "protobuf.text_format";
---忽略显示协议消息列表
---@class tbIgnoreShowProtocolMsgList
local tbIgnoreShowProtocolMsgList = {
    Network 
};

---不需要输出Log的协议ID列表
---@class tbNoLogProto
local tbNoLogProto = {
    2016,
}
---网络频道
---@class tbNetworkChannel
local tbNetworkChannel = 
{
    DEFINE = "Define",
}

function NetWorkComponent:__init()
    self.m_listCreateNetworkChannel = {}
    self.m_netHaveConnect = false
    self:RegisterLuaEvent()
    self:CreateTcpNetworkChannel(tbNetworkChannel.DEFINE)
    self:Connect(tbNetworkChannel.DEFINE,"127.0.0.1","9000")
end

function NetWorkComponent:__delete()
    self:UnRegisterLuaEvent()
end

function NetWorkComponent:RegisterLuaEvent()
    self._onhandlesendsocketrequest = LuaGameEntry.LuaEvent:RegisterLuaEvent(EventId.EVENT_LUA_SEND_SOCKET_REQUEST,self.OnHandleSendSocketRequest,self)
    self._onhandlesocketconnected = LuaGameEntry.LuaEvent:RegisterCSEvent(EventName.EVENT_CS_NET_CONNECTED,self.OnHandleSocketConnected,self)
    self._onhandlesocketclose = LuaGameEntry.LuaEvent:RegisterCSEvent(EventName.EVENT_CS_NET_CLOSE,self.OnHandleSocketClose,self)
    self._onhandlereceivesocketrequest = LuaGameEntry.LuaEvent:RegisterCSEvent(EventName.EVENT_CS_NET_RECEIVE,self.OnHandleReceiveSocketRequest,self)
end

function NetWorkComponent:UnRegisterLuaEvent()
    LuaGameEntry.LuaEvent:UnRegisterLuaEvent(EventId.EVENT_LUA_SEND_SOCKET_REQUEST,self._onhandlesendsocketrequest)
    LuaGameEntry.LuaEvent:UnRegisterCSEvent(EventName.EVENT_CS_NET_CONNECTED,self._onhandlesocketconnected)
    LuaGameEntry.LuaEvent:UnRegisterCSEvent(EventName.EVENT_CS_NET_CLOSE,self._onhandlesocketclose)
    LuaGameEntry.LuaEvent:UnRegisterCSEvent(EventName.EVENT_CS_NET_RECEIVE,self._onhandlereceivesocketrequest)
end

---创建服务频道
---@param strName string
function NetWorkComponent:CreateTcpNetworkChannel(strName)
    if table.containsKey(self.m_listCreateNetworkChannel,strName) then
        return
    end
    GameEntry.NetConnector:CreateTcpNetworkChannel(strName)
    table.insert(self.m_listCreateNetworkChannel,strName)
end

---连接服务器
---@param strName string
---@param strIp string
---@param nPort number
function NetWorkComponent:Connect(strName,strIp,nPort,userData)
    if table.containsKey(self.m_listCreateNetworkChannel,strName) then
        return
    end
    GameEntry.NetConnector:Connect(strName,strIp,nPort,userData)
end

---是否打印proto消息
---@param nProtocolId number
---@return boolean
function NetWorkComponent:IsShowProtoMsg(nProtocolId)
    if (not nProtocolId) then
        return false;
    end
    if (tbIgnoreShowProtocolMsgList[nProtocolId]) then
        return false;
    end
    return true;
end
---寻找协议解析数据
---@param nProtocolId number
function NetWorkComponent:FindBodyProtoModule(nProtocolId)
    local info_tb = ServerDecodeProtoConfig[nProtocolId];
    if (not info_tb) then
        return nil;
    end
    return info_tb.ModulePb, info_tb.ProtoName;
end

---解析包体
---@param nProtocolId number
---@param byteBody any
function NetWorkComponent:ParseFromBodyBuffer(nProtocolId, byteBody)
    local tbProtoModulePB, strBodyProtoName = self:FindBodyProtoModule(nProtocolId)
    if (not tbProtoModulePB or not strBodyProtoName) then
        Log.ProtoColorInfo(ColorType.red, nProtocolId, "[NetworkManager] ParseFromBodyBuffer FindBodyProtoModule nil ")
        return nil
    end

    if (not tbProtoModulePB[strBodyProtoName]) then
        Log.ProtoColorInfo(ColorType.red, nProtocolId, "[NetworkManager] ParseFromBodyBuffer tbProtoModulePB[strBodyProtoName] nil " .. strBodyProtoName)
        return nil
    end

    local proto_info_tb = tbProtoModulePB[strBodyProtoName]()
    if (not proto_info_tb) then
        return nil
    end
    proto_info_tb:ParseFromString(byteBody)
    return proto_info_tb
end

---发送消息
---@private OnHandleSendSocketRequest
---@param nProtocolId number
---@param protoBody any
function NetWorkComponent:OnHandleSendSocketRequest(nProtocolId, protoBody)
    local nRetCode = self:IsShowProtoMsg(nProtocolId)
    if (nRetCode == true and table.indexof(tbNoLogProto, nProtocolId) == false) then
        local strProtocolPrint = text_format.msg_format(protoBody) or "nil"
        Log.ProtoColorInfo(ColorType.pink, nProtocolId, "Show_Send_ProtoMsg = " .. strProtocolPrint)
    end
    -- 包体序列化
    local byteBody = protoBody:SerializeToString();
    GameEntry.NetConnector:Send(tbNetworkChannel.DEFINE,nProtocolId,byteBody)
end

---网络连接成功
function NetWorkComponent:OnHandleSocketConnected(csMessengerInfo)
    self.m_netHaveConnect = true
    local name = csMessengerInfo.param1
    local localEndPoint = csMessengerInfo.param2
    local remoteEndPoint = csMessengerInfo.param3
    Logger.Info(string.format("Network channel '%s' connected, local address '%s', remote address '%s'.",name,localEndPoint,remoteEndPoint))
end

---网络连接关闭
function NetWorkComponent:OnHandleSocketClose(csMessengerInfo)
    self.m_netHaveConnect = false
    local name = csMessengerInfo.param1
    Logger.Info(string.format("Network channel '%s' closed.",name))
end

---接收消息
---private OnHandleReceiveSocketRequest
function NetWorkComponent:OnHandleReceiveSocketRequest(csMessengerInfo)
    if not csMessengerInfo then
        return 0
    end
    local protoId = csMessengerInfo.param1
    if not protoId then
        Logger.Error("[NetWorkComponent] OnHandleReceiveSocketRequest protoId is nil")
        return 0
    end
    local protoBody = csMessengerInfo.param2
    if (protoBody == nil) then
        Logger.Error("[NetWorkComponent] OnHandleReceiveSocketRequest protoBody is nil")
        return 0
    end
    local tbProtoParseResult = self:ParseFromBodyBuffer(protoId, protoBody)
    if (not tbProtoParseResult) then
        Log.ProtoColorInfo(ColorType.red, protoId, "[NetWorkComponent] OnHandleReceiveSocketRequest ParseFromBodyBuffer failed ")
        return 0
    end
    local nRetCode = self:IsShowProtoMsg(protoId)
    if (nRetCode == true and table.indexof(tbNoLogProto, protoId) == false) then
        -- 输出协议信息
        local strProtocolPrint = text_format.msg_format(tbProtoParseResult)  or "nil";
        Log.ProtoColorInfo(ColorType.yellowgreen, protoId, "Show_Recv_ProtoMsg = " .. strProtocolPrint);
    end
    self:SendLuaEvent(protoId, tbProtoParseResult);
end

return NetWorkComponent