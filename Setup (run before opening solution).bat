:: This script creates a symlink to the SpaceEngineers to account for different installation directories on different systems.

@echo off
set /p path="Please enter the folder location of your SpaceEngineers.exe (in Bin64 folder): "
cd %~dp0
cd .
mklink /J ..\SpaceEngineers "%path%"
if errorlevel 1 goto Error
echo Done! You can now open the SE-RG-System solution without issue.
goto End
:Error
echo An error occured creating the symlink.
:End
pause