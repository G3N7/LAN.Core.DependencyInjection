@echo off

set /p apiKey=Enter API Key:%=%
.nuget\nuget setApiKey %apiKey% -Source https://www.nuget.org/api/v2/package
 
@echo ---------------------------------------------------
.nuget\nuget pack LAN.Core.DependencyInjection.StructureMap\LAN.Core.DependencyInjection.StructureMap.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories -Build -Symbols -Properties Configuration=Release
@echo Finished Building: LAN.Core.DependencyInjection.StructureMap
@echo ---------------------------------------------------

@echo Pushing To Nuget and SymbolSource...
set /p diStructureMapVersion=Enter StructureMap Package Version:%=%
.nuget\nuget push LAN.Core.DependencyInjection.StructureMap.%diStructureMapVersion%.nupkg -Source https://www.nuget.org/api/v2/package
@echo ---------------------------------------------------