LAN.Core.DependencyInjection
===

Thin DI Abstraction with Implementations for:
---
* StructureMap - [Nuget](https://www.nuget.org/packages/LAN.Core.DependencyInjection.StructureMap/)
* SimpleInjector - [Nuget](https://www.nuget.org/packages/LAN.Core.DependencyInjection.SimpleInjector/)
* Ninject - [Nuget](https://www.nuget.org/packages/LAN.Core.DependencyInjection.Ninject/)

Bind
---
```c#
void Bind<TAbstract, TConcrete>(bool singleton)
```

Allows you to bind an implementation to a concrete, this is usually the way we register types with the container

Register Singleton
---
```c#
void RegisterSingleton<T>(T service) where T : class;
```

Allows you to bind a specific singleton instance to be used anywhere the given type is required.

GetInstance - Known Type
---
```c#
T GetInstance<T>()
```

Allows you to retrieve an instance of a given type known at compile time.

GetInstance - Discovered Type
---
```c#
object GetInstance(Type type);
```

Allows you to retrieve an instance of a given type that will be known at runtime.
