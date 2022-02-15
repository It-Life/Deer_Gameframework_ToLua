
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-06 07-44-14  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-06 07-44-14  
---版 本 : 0.1 
---===============================================
---@class DataNoticeInfoManager:DataUserBase
DataNoticeInfoManager = Class("DataNoticeInfoManager",DataUserBase)

function DataNoticeInfoManager:OnCreate()
    self._m_listNoticeInfo = nil;
    self._m_bNeedAutoOpenPanel = true;
    
    --self._m_funcWebRequestSuccessEvent = BindCallback(self.OnHandleWebRequestSuccess, self);
    GameEntry.Event:Subscribe(WebRequestSuccessEventArgs.EventId, self.OnHandleWebRequestSuccess)
    --self._m_flWebReqId = GameEntry.WebRequest:AddWebRequest(GameEntry.Builtin.RealyResourceVersion.."/Notice.txt");
end

function DataNoticeInfoManager:OnDestroy()
    self._m_bNeedAutoOpenPanel = nil;
    self._m_listNoticeInfo = nil;
    GameEntry.Event:Unsubscribe(WebRequestSuccessEventArgs.EventId, self.OnHandleWebRequestSuccess)
    self._m_funcNetConnect = nil;
    self._m_flWebReqId = nil;
end

function DataNoticeInfoManager:OnInitData(bIsInit)    
    
end

--Web 请求成功
function DataNoticeInfoManager:OnHandleWebRequestSuccess(cs_sender, cs_WebRequestSuccessEventArgs)
    if self._m_flWebReqId == cs_WebRequestSuccessEventArgs.SerialId then
        local cs_bytes = cs_WebRequestSuccessEventArgs:GetWebResponseBytes();
        local strContent = GameFramework.Utility.Converter.GetString(cs_bytes);

        local cs_listnotice = OtherTool.GetNotice(strContent);
        self._m_listNoticeInfo = {};

        for i = 0, cs_listnotice.list.Count - 1 do
            local tbTempInfo = {};
            tbTempInfo.SendTime = cs_listnotice.list[i].SendTime;
            tbTempInfo.NoticeType = cs_listnotice.list[i].NoticeType;
            tbTempInfo.MainTitle = cs_listnotice.list[i].MainTitle;
            tbTempInfo.Content = cs_listnotice.list[i].Content;
            self._m_listNoticeInfo[i+1] = tbTempInfo;
        end

        if self._m_bNeedAutoOpenPanel then
            self._m_bNeedAutoOpenPanel = false;
            local tbShowUIInfo = {};
            tbShowUIInfo.strUIName = UIPanelNames.UINoticePanel;
            self:SendLuaEvent(EventIdDef.EventLua.EVENT_LUA_UI_SHOW_UI, tbShowUIInfo);
        end
    end
end

--开启公告
function DataNoticeInfoManager:OpenNoticePanel(bIsAuto)
    if bIsAuto == true and self._m_bNeedAutoOpenPanel == false then
        return;
    end
    
    if self._m_listNoticeInfo then
        self._m_bNeedAutoOpenPanel = false;
        local tbShowUIInfo = {};
        tbShowUIInfo.strUIName = UIPanelNames.UINoticePanel;
        self:SendLuaEvent(EventIdDef.EventLua.EVENT_LUA_UI_SHOW_UI, tbShowUIInfo);
    else
        GameEntry.WebRequest:AddWebRequest(GameEntry.Builtin.RealyResourceVersion.."/Notice.txt");
    end
end

--获取公告信息
function DataNoticeInfoManager:GetNoticeInfo()
    return self._m_listNoticeInfo;
end


return DataNoticeInfoManager