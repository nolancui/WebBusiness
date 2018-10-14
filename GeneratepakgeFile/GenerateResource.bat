::generate rar file

@if not exist SystemManage (
@mkdir SystemManage
@xcopy /y ..\WebApplication\SystemManage\* .\SystemManage        /s /e
)

@if not exist MenuManage (
@mkdir MenuManage
@xcopy /y ..\WebApplication\MenuManage\*	.\MenuManage         /s /e
)

@if not exist BaseShearch (
@mkdir BaseShearch
@xcopy /y ..\WebApplication\BaseShearch\* 	.\BaseShearch          /s /e
)

@if not exist DataBase (
@mkdir DataBase
@xcopy /y ..\WebApplication\DataBase\*.accdb   	.\DataBase           /s /e
)

@if not exist Js (
@mkdir Js
@xcopy /y ..\WebApplication\Js\*   	        .\Js           /s /e
)

@if not exist images (
@mkdir images
@xcopy /y ..\WebApplication\images\*   	        .\images          /s /e
)

@if not exist bin (
@mkdir bin
@xcopy /y ..\WebApplication\bin\*.dll           .\bin         /s /e
)

copy Rar.exe c:\windows\system32

cd SystemManage 
for /r %%a in (*.cs) do (
del "%%a"
)
Rar a -r SystemManage
move SystemManage.rar ..

cd ../MenuManage
for /r %%a in (*.cs) do (
del "%%a"
)
Rar a -r MenuManage 
move MenuManage.rar ..

cd ../BaseShearch
for /r %%a in (*.cs) do (
del "%%a"
)
Rar a -r BaseShearch
move BaseShearch.rar ..

cd ../DataBase
Rar a -r DataBase
move DataBase.rar ..

cd ../Js
Rar a -r Js
move Js.rar ..

cd ../images
Rar a -r images
move images.rar ..

cd ../bin
Rar a -r bin
move bin.rar ..


cd ..



rd /q /s SystemManage 
rd /q /s MenuManage 
rd /q /s BaseShearch 
rd /q /s DataBase
rd /q /s Js
rd /q /s images
rd /q /s bin

cd ..\WebApplication\

for /f %%a in ('dir /a-d /b *.aspx') do (
copy %%a ..\GeneratepakgeFile\
)


for /f %%a in ('dir /a-d /b *.config') do (
copy %%a ..\GeneratepakgeFile\
)

del c:\windows\system32\Rar.exe\
