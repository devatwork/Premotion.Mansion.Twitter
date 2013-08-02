@echo Off
set config=%1
if "%config%" == "" (
	set config=Release
)

set nuget=
if "%nuget%" == "" (
    set nuget=.nuget\NuGet.exe
)

set apikey=
if "%apikey%" == "" (
    set apikey=%2
)

rem Update self %nuget%
%nuget% update -self
if %errorlevel% neq 0 goto failure

rem Set API key
%nuget% setapikey %apikey% -Source "https://www.myget.org/F/premotion/api/v2/package"
if %errorlevel% neq 0 goto failure
%nuget% setapikey %apikey% -Source "https://nuget.symbolsource.org/MyGet/premotion"
if %errorlevel% neq 0 goto failure

rem Build
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild Premotion.Mansion.Twitter.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false
if %errorlevel% neq 0 goto failure

rem Package
%nuget% pack Premotion.Mansion.Twitter\Premotion.Mansion.Twitter.csproj -sym -Prop Configuration=Release
if %errorlevel% neq 0 goto failure

rem Publish
%nuget% push Premotion.Mansion.Twitter.0.0.1-alpha.nupkg -Source "https://www.myget.org/F/premotion/api/v2/package"
if %errorlevel% neq 0 goto failure
%nuget% push Premotion.Mansion.Twitter.0.0.1-alpha.symbols.nupkg -Source "https://nuget.symbolsource.org/MyGet/premotion"
if %errorlevel% neq 0 goto failure

:success
echo success
goto end

:failure
echo Failed

:end