LAN.Core.DependencyInjection
============================

Thin DI Abstraction

Bind
=====
		void Bind<TAbstract, TConcrete>(bool singleton)

Allows you to bind an implementation to a concrete, this is usually the way we register types with the container

Register Singleton
====
		void RegisterSingleton<T>(T service) where T : class;

Allows you to bind a specific singleton instance to be used anywhere the given type is required.

GetInstance - Known Type
=====
		T GetInstance<T>()

Allows you to retrieve an instance of a given type known at compile time.

GetInstance - Discovered Type
=====
		object GetInstance(Type type);

Allows you to retrieve an instance of a given type that will be known at runtime.