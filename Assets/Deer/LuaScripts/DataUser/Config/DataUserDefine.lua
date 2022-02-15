
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-05 08-36-29  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-05 08-36-29  
---版 本 : 0.1 
---===============================================

DataUserDefine = {}

DataUserDefine.InitDataConfig = 
{
    {   -- 公告数据中心
        strName                 = DataUserNames.DataNoticeInfo,
        tbModuleClass           = require "DataUser/Info/DataNoticeInfoManager",
    },
    {   ---登录数据中心
        strName                 = DataUserNames.DataLoginInfo,
        tbModuleClass           = require "DataUser/Info/DataLoginInfoManager",
    },
}

return DataUserDefine