@echo off

@echo !! Rebuild in Release mode prior to running !!
.nuget\nuget pack LAN.Core.DependencyInjection\LAN.Core.DependencyInjection.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories
@echo Finished Building: LAN.Core.DependencyInjection

@echo ---------------------------------------------------
.nuget\nuget pack LAN.Core.DependencyInjection.Ninject\LAN.Core.DependencyInjection.Ninject.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories
@echo Finished Building: LAN.Core.DependencyInjection.Ninject

@echo ---------------------------------------------------
.nuget\nuget pack LAN.Core.DependencyInjection.SimpleInjector\LAN.Core.DependencyInjection.SimpleInjector.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories
@echo Finished Building: LAN.Core.DependencyInjection.SimpleInjector

@echo ---------------------------------------------------
.nuget\nuget pack LAN.Core.DependencyInjection.StructureMap\LAN.Core.DependencyInjection.StructureMap.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories
@echo Finished Building: LAN.Core.DependencyInjection.StructureMap

@echo ---------------------------------------------------
@echo !! Rebuild in Release mode prior to running !!
pause