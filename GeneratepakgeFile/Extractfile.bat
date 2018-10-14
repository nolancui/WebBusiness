::this file just Extract file to local path

copy C:\inetpub\wwwroot\Rar.exe c:\windows\system32

::entry into webpage local directory
cd /d c:\inetpub\wwwroot\

::extract charisma file

for /f %%a in ('dir /a-d /b *.rar') do (
for /f "delims=." %%i in ("%%a") do (
mkdir %%i
Rar.exe x %%a %%i
)
) 


::delete the rar.exe file which copy to system directory
del c:\windows\system32\Rar.exe\

icacls c:\inetpub\wwwroot\database /t /grant everyone:f