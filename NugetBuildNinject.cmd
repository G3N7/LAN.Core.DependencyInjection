@echo off

set /p apiKey=Enter API Key:%=%
.nuget\nuget setApiKey %apiKey%

@echo ---------------------------------------------------
.nuget\nuget pack LAN.Core.DependencyInjection.Ninject\LAN.Core.DependencyInjection.Ninject.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories -Build -Symbols -Properties Configuration=Release
@echo Finished Building: LAN.Core.DependencyInjection.Ninject
@echo ---------------------------------------------------

@echo Pushing To Nuget and SymbolSource...
set /p diNinjectVersion=Enter Ninject Package Version:%=%
.nuget\nuget push LAN.Core.DependencyInjection.Ninject.%diNinjectVersion%.nupkg
@echo ---------------------------------------------------