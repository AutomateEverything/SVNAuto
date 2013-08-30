@echo off
call :treeProcess
goto :eof

:treeProcess
for %%f in (*) do echo %%f
for /D %%d in (*) do (
    cd %%d
    call :treeProcess
    cd ..
)
exit /b