@echo off

set /p apiKey=Enter API Key:%=%
.nuget\nuget setApiKey %apiKey%

@echo ---------------------------------------------------
.nuget\nuget pack LAN.Core.DependencyInjection.SimpleInjector\LAN.Core.DependencyInjection.SimpleInjector.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories -Build -Symbols -Properties Configuration=Release
@echo Finished Building: LAN.Core.DependencyInjection.SimpleInjector
@echo ---------------------------------------------------

@echo Pushing To Nuget and SymbolSource...
set /p diSimpleInjectorVersion=Enter SimpleInjector Package Version:%=%
.nuget\nuget push LAN.Core.DependencyInjection.SimpleInjector.%diSimpleInjectorVersion%.nupkg
@echo ---------------------------------------------------
