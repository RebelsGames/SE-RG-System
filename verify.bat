@echo on

cd "..\SpaceEngineers\"

".\SEWorkshopTool.exe" --upload --dry-run --compile --mods "SE-RG-System" --exclude .csproj .sln .user .gitignore

@echo off

echo upload zakonczony

pause