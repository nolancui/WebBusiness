::clean those file

for /f %%a in ('dir /a-d /b *.rar *.aspx') do (
echo %%a>>test.txt
del %%a
) 
pause