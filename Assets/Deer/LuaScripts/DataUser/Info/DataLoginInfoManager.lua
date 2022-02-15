
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-12-01 22-25-52  
---修改作者 : 杜鑫 
---修改时间 : 2021-12-01 22-25-52  
---版 本 : 0.1 
---===============================================
---@class DataLoginInfoManager:DataUserBase
DataLoginInfoManager = Class("DataLoginInfoManager",DataUserBase)

function DataLoginInfoManager:__init()

end

function DataLoginInfoManager:__delete()

end


--------------------Service-------------
---发送用户请求登录
function DataLoginInfoManager:SendUserLoginRequest()
    local asa = DPLogin_pb.DPUserLoginInfoReq()
    asa.szAccount = "1"
    asa.szPassword = "2"
    asa.szMacAdress = "3"
    asa.nClientVersion = 4
    asa.szUserName = "5"
    LuaGameEntry.NetWork:OnHandleSendSocketRequest(PTC_C2G_LOGININFO,asa)
end

return DataLoginInfoManager