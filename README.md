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
  - Explore different lifetimes: When will the DI container create a new instance?
    - Transient: A new instamce is created every time a type is requested.
      - Scope is a sub-container. NOTE: Resolving on the scope results in a new instance as well.
      ```csharp
        var one = host.Services.GetService<Interface>();
        var two = host.Services.GetService<Interface>();
        var equal = Object.ReferenceEquals(one, two); // false
      ```
      - When resolving the same type multiple times, a new instance will be returned every time.
    - Scoped: A new instance is created once per scope, and then reused in the scope.
      - Most difficult to understand. e.g.: Container with two seperate scopes under it.
        - First scope returns a new instance.
        - Second scope returns a new instance.
          ```csharp
            using var scope1 = host.Services.CreateScope();
            var one = scope1.ServiceProvider.GetRequiredService<Interface>();
            var two = scope1.ServiceProvider.GetRequiredService<Interface>();
            var equal1 = Object.ReferenceEquals(one, two); // true

            using var scope2 = host.Services.CreateScope();
            var three = scope1.ServiceProvider.GetRequiredService<Interface>();
            var four = scope1.ServiceProvider.GetRequiredService<Interface>();
            var equal2 = Object.ReferenceEquals(one, three); // false
            var equal3 = Object.ReferenceEquals(three, four); // true
          ```
    - Singleton: A new instance is created once and reused from then onward.
      - Scope is a sub-container. NOTE: Resolving on the scope results in the same instance as well.
      ```csharp
        var one = host.Services.GetService<Interface>();
        var two = host.Services.GetService<Interface>();
        var equal = Object.ReferenceEquals(one, two); // true
      ```
      - When resolving the same type multiple times on the same container, the same instance will be returned every time.
  - Service Locator Pattern. Generally not recommended:
    ```csharp
      var context = scope.ServiceProvider.GetRequiredService<IProductTransformationContext>();
    ```
  - Dependency captivity:
    - Generate a reference for a product every time that it is imported.
    - NOTE: ReferenceGenerator implements DateTimeProvider. This makes IDateTimeProvider a "Singleton" as well.
      ```csharp
        services.AddSingleton<IReferenceGenerator, ReferenceGenerator>();
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
      ```
    - Turn on ValidateScopes. You will rewceive descriptive errors during run time.
      - e.g.: "Cannot consume scoped service from singleton."
      - Not all dependency captivitiy errors are captured by this.
        ```csharp
            using var host = Host.CreateDefaultBuilder(args)
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateScopes = true;
                }).ConfigureServices((null, null));
        ```
      - Solution: ReferenceGenerator as scoped. 
        - Add a new singleton Incrementing counter and leave the date time provider as scoped.
  - Choosing the correct lifetime:
    - Pointers: How an implementating type handles state is the best indicator for choosing a lifetime.
      - If there is no state at all, choose transient.
      - If the state is derived or can be calculated on the fly, choose transient.
      - Move to scoped or singleton only when performance issues are apparent.
      - If the state relates to a single item, request or context, and needs to be sgared between dependending classes, choose scoped.
      - If the state relates to everything in the application, choose singleton.
      - Shy away from (too many) custom scopes. Leave that to the framework.
    - Lifetime-related bugs: Chosing an incorrect lifetime can lead to unexpected behaviours, also known as bugs.
      - When in doubt, error on the side of transient.
      - Check your framework! Use their recommendations.
        - e.g.: DbContext. The lifetime should correspond to the unit of work (transient.) In practice: Scoped.
        - e.g.: CosmosClient: Thread-safe and intended for reuse. A single instance is recommended. Hence: Singleton.

- EXPANDING THE PRODUCT IMPORTER:

- COMMON PITFALLS AND CHALLENGES:

- ADVANCED TECHNIQUES: