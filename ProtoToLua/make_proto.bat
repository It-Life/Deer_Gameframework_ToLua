::@%1 cmd /k %0 :
@::make_proto.bat
@echo off

set UnityProtolDir=..\Assets\Deer\LuaScripts\Proto
set LuaProtoTmpDir=.\__tmp
set LuaProtoSrcDir=.\genproto
set LuaPluginDir=.\plugin

if exist "%UnityProtolDir%" del /q "%UnityProtolDir%\*.lua"
::for /r "%UnityProtolDir%" %%a in (*.lua)do del "%%a"/f /q
::del /s /q "%UnityProtolDir%\*.lua"
::rd /s /q "%UnityProtolDir%"
md "%UnityProtolDir%"

if exist "%LuaProtoTmpDir%" rd /s /q "%LuaProtoTmpDir%"
md "%LuaProtoTmpDir%"

for /r "%LuaProtoSrcDir%" %%i in (*.proto) do (
	copy /y "%%i" "%LuaProtoTmpDir%\%%~nxi"
)  

cd "%LuaProtoTmpDir%"
call :stringlenth "%cd%" num 
setlocal enabledelayedexpansion
for /r %%i in (*.proto) do (   
	set absolute=%%i
	set relative=.!absolute:~%num%!
	echo !relative!
	"..\protoc.exe" --plugin=protoc-gen-lua="..\plugin\build.bat" --lua_out="..\%UnityProtolDir%" "!relative!" 
)  

cd ..
if exist "%LuaProtoTmpDir%" rd /s /q "%LuaProtoTmpDir%"

echo DONE

pause
exit

:show
set fileName=%~n1 

:StringLenth 
	set theString=%~1
	if not defined theString goto :eof 
	set Return=0 
:StringLenth_continue 
	set /a Return+=1
	set theString=%theString:~,-1%
	if defined theString goto StringLenth_continue 
	if not "%2"=="" set %2=%Return%
goto :eof