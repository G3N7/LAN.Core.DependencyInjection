@echo off
Setlocal EnableDelayedExpansion

set /p apiKey=Enter API Key:%=%
.nuget\nuget setApiKey %apiKey% -source https://www.nuget.org

SET /p deployDependencyInjection=Would you like to deploy the Core DependencyInjection Project? (y/n) %=%
IF (!deployDependencyInjection!) EQU (y) (
    .nuget\nuget pack LAN.Core.DependencyInjection\LAN.Core.DependencyInjection.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories -Build -Symbols -Properties Configuration=Release
    @echo Finished Building: LAN.Core.DependencyInjection
    set /p diVersion=Enter DependencyInjection Package Version:%=%
    .nuget\nuget push LAN.Core.DependencyInjection.!diVersion!.nupkg -Source https://www.nuget.org/api/v2/package
)

@echo ---------------------------------------------------
SET /p deployNinject=Would you like to deploy the Ninject DependencyInjection Project? (y/n) %=%
IF (!deployNinject!) EQU (y) (
    .nuget\nuget pack LAN.Core.DependencyInjection.Ninject\LAN.Core.DependencyInjection.Ninject.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories -Build -Symbols -Properties Configuration=Release
    @echo Finished Building: LAN.Core.DependencyInjection.Ninject
    set /p diNinjectVersion=Enter Ninject Package Version:%=%
    .nuget\nuget push LAN.Core.DependencyInjection.Ninject.!diNinjectVersion!.nupkg -Source https://www.nuget.org/api/v2/package
)

@echo ---------------------------------------------------
SET /p deploySimpleInjector=Would you like to deploy the SimpleInjector DependencyInjection Project? (y/n) %=%
IF (!deploySimpleInjector!) EQU (y) (
    .nuget\nuget pack LAN.Core.DependencyInjection.SimpleInjector\LAN.Core.DependencyInjection.SimpleInjector.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories -Build -Symbols -Properties Configuration=Release
    @echo Finished Building: LAN.Core.DependencyInjection.SimpleInjector
    set /p diSimpleInjectorVersion=Enter SimpleInjector Package Version:%=%
    .nuget\nuget push LAN.Core.DependencyInjection.SimpleInjector.!diSimpleInjectorVersion!.nupkg -Source https://www.nuget.org/api/v2/package
)

@echo ---------------------------------------------------
SET /p deployStructureMap=Would you like to deploy the StructureMap DependencyInjection Project? (y/n) %=%
IF (!deployStructureMap!) EQU (y) (
    .nuget\nuget pack LAN.Core.DependencyInjection.StructureMap\LAN.Core.DependencyInjection.StructureMap.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories -Build -Symbols -Properties Configuration=Release
    @echo Finished Building: LAN.Core.DependencyInjection.StructureMap
    set /p diStructureMapVersion=Enter StructureMap Package Version:%=%
    .nuget\nuget push LAN.Core.DependencyInjection.StructureMap.!diStructureMapVersion!.nupkg -Source https://www.nuget.org/api/v2/package
)