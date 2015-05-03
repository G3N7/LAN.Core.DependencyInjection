@echo off

set /p apiKey=Enter API Key:%=%
.nuget\nuget setApiKey %apiKey%

.nuget\nuget pack LAN.Core.DependencyInjection\LAN.Core.DependencyInjection.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories -Build -Symbols -Properties Configuration=Release
@echo Finished Building: LAN.Core.DependencyInjection

@echo ---------------------------------------------------
.nuget\nuget pack LAN.Core.DependencyInjection.Ninject\LAN.Core.DependencyInjection.Ninject.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories -Build -Symbols -Properties Configuration=Release
@echo Finished Building: LAN.Core.DependencyInjection.Ninject

@echo ---------------------------------------------------
.nuget\nuget pack LAN.Core.DependencyInjection.SimpleInjector\LAN.Core.DependencyInjection.SimpleInjector.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories -Build -Symbols -Properties Configuration=Release
@echo Finished Building: LAN.Core.DependencyInjection.SimpleInjector

@echo ---------------------------------------------------
.nuget\nuget pack LAN.Core.DependencyInjection.StructureMap\LAN.Core.DependencyInjection.StructureMap.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories -Build -Symbols -Properties Configuration=Release
@echo Finished Building: LAN.Core.DependencyInjection.StructureMap

@echo ---------------------------------------------------

@echo Pushing To Nuget and SymbolSource...
set /p diVersion=Enter DependencyInjection Package Version:%=%
.nuget\nuget push LAN.Core.DependencyInjection.%diVersion%.nupkg
set /p diNinjectVersion=Enter Ninject Package Version:%=%
.nuget\nuget push LAN.Core.DependencyInjection.Ninject.%diNinjectVersion%.nupkg
set /p diSimpleInjectorVersion=Enter SimpleInjector Package Version:%=%
.nuget\nuget push LAN.Core.DependencyInjection.SimpleInjector.%diSimpleInjectorVersion%.nupkg
set /p diStructureMapVersion=Enter StructureMap Package Version:%=%
.nuget\nuget push LAN.Core.DependencyInjection.StructureMap.%diStructureMapVersion%.nupkg

@echo ---------------------------------------------------
