## C# 10 Dependency Injection by Henry Been

- OVERVIEW:
  - For professional developers, dependency injection is an important technique to keep your codebase testable and maintainable. 
  - This course will teach you how to implement dependency injection when working with C# 10.

- GETTING STARTED WITH A PRODUCT IMPORTER:
  - Decoupling of interface and implementation.
  - DI: No longer calling constructors. Container calls the constructors.
    - Not concerned with ordering registrations. Not concerned with dependencies of each type.
  - About: Autofac. Ninject. Unity (discontinued.) Microsoft.Extensions.DependencyInjection (.NET Core default.)
    - Registration phase. Register types. Knows thier existence and when to construct them.
    - Resolving phase: Instantiating types and providing types ad-hoc.
    - Two types. Service type and implementation type. Can be the same type. Otherwise, polymorphism is leveraged.
      - And lifetime specified. So... lifetime, requested service type, and the implementating type.
    - Resolves and create types directly.
    - Provides dependencies of types you weork with.
    - Provides dependencies to dependencies of the types you work with.
    - Manages the lifetime of types.
  - Two principles:
    - Dependency inversion: High-level modules should not depend upon low-level modules. Implementating interfaces.
    - Inversion of Control: A framework controls which code is executed next. Not your code. 
      - Class requests an interface from the framework.
  - Maintainable solutions using DI.
    - Design classes that have a SRP. Dependencies upon interfaces. 
      - Interfaces are "owned" by the consumer. They should not reflect underlying implementation.
    - Apply DI and IoC.
  - SUMMARY:

- LIFETIME MANAGEMENT:
  - Explore different lifetimes:
  - Dependency captivity:

- EXPANDING THE PRODUCT IMPORTER:

- COMMON PITFALLS AND CHALLENGES:

- ADVANCED TECHNIQUES: