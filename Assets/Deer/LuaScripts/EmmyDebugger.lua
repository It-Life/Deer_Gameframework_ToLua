
---================================================
---描 述 :  
---作 者 : 杜鑫 
---创建时间 : 2021-07-20 23-17-38  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-20 23-17-38  
---版 本 : 0.1 
---===============================================
package.cpath = package.cpath .. ';C:/Users/Admin/AppData/Roaming/JetBrains/IntelliJIdea2020.2/plugins/intellij-emmylua/classes/debugger/emmy/windows/x64/?.dll'
local dbg = require('emmy_core')
dbg.tcpConnect('localhost', 9966)
