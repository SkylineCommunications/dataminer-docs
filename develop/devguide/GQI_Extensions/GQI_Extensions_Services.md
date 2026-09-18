---
uid: GQI_Extensions_Services
---

# Services in GQI extensions

From DataMiner 10.5.0 [CU18]/10.6.0 [CU6]/10.6.9 onwards<!-- RN 45635 -->, GQI extensions using the [Skyline.DataMiner.Core.GQI.Extensions](xref:GQI_Extension_API) API can use constructor injection to share service instances across extension instances.

Services are useful when an extension library needs a reusable state or functionality, for example a cache, a client for an external system, or shared helper logic. A service belongs to the extension library worker process in which it is loaded. It is not shared across different extension libraries or across DataMiner Agents.

> [!IMPORTANT]
> GQI services require the [GQI DxM](xref:GQI_DxM) and the `Skyline.DataMiner.Core.GQI.Extensions` NuGet package.

## Registering a service

Register a service by adding one of the GQI service attributes to a class in the same extension library:

| Attribute | Scope | Default idle expiration |
|--|--|--|
| [GQIWorkerServiceAttribute](xref:GQI_GQIWorkerServiceAttribute) | One instance shared across all users and all queries in the extension worker process. | None |
| [GQISecurityServiceAttribute](xref:GQI_GQISecurityServiceAttribute) | One instance per security context, shared by users with the same security group combination. | 60 minutes |
| [GQIUserServiceAttribute](xref:GQI_GQIUserServiceAttribute) | One instance per user within the current security context. | 5 minutes |

The idle expiration is a sliding timeout that starts when the service instance was last used. Each time the service is used again, the timeout is reset. Set `IdleExpirationMinutes` to `0` to disable idle expiration.

```csharp
using System;
using Skyline.DataMiner.Core.GQI.Extensions;

public interface IInventoryCache
{
    string[] GetItems();
}

[GQISecurityService(typeof(IInventoryCache), IdleExpirationMinutes = 15)]
public sealed class InventoryCache : IInventoryCache, IDisposable
{
    private readonly IGQISecurity _security;

    public InventoryCache(IGQISecurity security)
    {
        _security = security;
    }

    public string[] GetItems()
    {
        // Fetch or return cached data for _security.SecurityKey.
        return Array.Empty<string>();
    }

    public void Dispose()
    {
        // Clean up cached data or external resources.
    }
}
```

When a class is marked with a service attribute, GQI registers it by its concrete type by default. This means that constructor parameters can request that concrete type to inject a service instance. You can also specify a different service type as the injection contract. In that case, the marked class must be assignable to the specified service type. This is typically used to register a service by an interface, for example to decouple extensions from the implementation or to make unit testing easier.

> [!NOTE]
> Do not register multiple services for the same service type in one extension library. Duplicate service definitions are ignored.

## Service lifetime

A service instance is created when GQI resolves that service for the first time within its scope:

- A worker service is shared across all users and queries in the extension worker process.
- A security service is shared within the current security context.
- A user service is shared for the current user within the current security context.

When a service instance is created, GQI calls its constructor. The constructor can use injection in the same way as an ad hoc data source or custom operator, and it can also [inject other services](#injecting-services-into-other-services). If a constructor dependency cannot be resolved or the constructor throws an exception, the service instance cannot be created.

A service instance remains available until GQI removes it from its scope. This can happen when the configured idle expiration has elapsed since the service instance was last used, when the scope is no longer valid, or when the extension worker process is cleaned up. The next time the service is requested within that scope, GQI creates a new instance.

If the service class implements [IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable), GQI calls `Dispose` when the service instance is removed from its scope. Use `Dispose` to release resources that are tied to the service instance, such as cached data, subscriptions, or external connections.

## Injecting services into an extension

To receive services, add constructor parameters to an ad hoc data source or custom operator. If the extension class does not explicitly declare a constructor, C# provides a public parameterless constructor and GQI uses it. If the extension class has an explicit parameterless public constructor, GQI also uses that constructor for backward compatibility. Otherwise, the extension class must have exactly one public constructor.

Constructor parameters can use any of the [supported constructor dependencies](#supported-constructor-dependencies).

```csharp
using System;
using System.Linq;
using Skyline.DataMiner.Core.GQI.Extensions;

[GQIMetaData(Name = "Inventory")]
public sealed class InventoryDataSource : IGQIDataSource
{
    private readonly IInventoryCache _cache;
    private readonly IGQILogger _logger;

    public InventoryDataSource(IInventoryCache cache, IGQILogger logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public GQIColumn[] GetColumns()
    {
        return new GQIColumn[]
        {
            new GQIStringColumn("Item"),
        };
    }

    public GQIPage GetNextPage(GetNextPageInputArgs args)
    {
        var rows = _cache.GetItems()
            .Select(item => new GQIRow(new[] { new GQICell { Value = item } }))
            .ToArray();

        _logger.Information($"Returned {rows.Length} inventory items.");
        return new GQIPage(rows);
    }
}
```

Constructor injection happens before [OnInit](xref:GQI_IGQIOnInit) is called. If a constructor dependency cannot be resolved or the constructor throws an exception, the extension instance cannot be created.

## Injecting services into other services

Services can also use constructor injection to depend on other services in the same extension library. A service class must have exactly one public constructor. If it does not explicitly declare a constructor, the default public parameterless constructor is used.

Service constructor parameters can use any of the [supported constructor dependencies](#supported-constructor-dependencies), as long as they are available in the service scope.

A service can depend on services from its own scope or from a broader scope:

| Service being created | Services it can inject |
|--|--|
| Worker service | Worker services |
| Security service | Worker services and security services |
| User service | Worker services, security services, and user services |

Services cannot depend on services from a narrower scope. For example, a worker service cannot inject a security or user service, and a security service cannot inject a user service.

If a service constructor dependency cannot be resolved or the constructor throws an exception, the service instance cannot be created.

### Retrieving data from DataMiner in services

User-scoped services can inject [IGQIDMSInterface](xref:GQI_IGQIDMSInterface) or [IConnection](xref:Skyline.DataMiner.Net.IConnection). GQI provides the same user connection as it would provide if the dependency were injected directly into the extension for that query. This allows a user-scoped service to cache and reuse user-specific data.

Security-scoped services do not support injecting these dependencies yet.

> [!TIP]
> See also: [Retrieving data from DataMiner](xref:GQI_Extensions_Retrieving_Data_From_DataMiner#choosing-an-approach).

## Deferred service injection

Use [GQILazy\<T\>](xref:GQI_GQILazyT) when a dependency is only needed conditionally or only in specific lifecycle methods. The service is resolved the first time the `Value` property is accessed.

```csharp
public sealed class InventoryDataSource : IGQIDataSource
{
    private readonly GQILazy<IInventoryCache> _cache;

    public InventoryDataSource(GQILazy<IInventoryCache> cache)
    {
        _cache = cache;
    }

    public GQIPage GetNextPage(GetNextPageInputArgs args)
    {
        var items = _cache.Value.GetItems();

        // Return rows based on the items.
        return new GQIPage(Array.Empty<GQIRow>());
    }

    // Other IGQIDataSource members omitted for brevity.
}
```

Direct constructor injection should be preferred when the dependency is always needed. Use `GQILazy<T>` when resolving the dependency can be postponed until it is actually used.

## Supported constructor dependencies

The following types can be used as constructor parameters:

| Type | Provides | Can be injected into |
|--|--|--|
| [IGQILogger](xref:GQI_IGQILogger) | A logger for the extension or service. | Extensions and services |
| [IGQIFactory](xref:GQI_IGQIFactory) | Factory methods to create GQI objects. | Extensions and services |
| [IGQIDMSInterface](xref:GQI_IGQIDMSInterface) | Access to the DataMiner System. | Extensions and [user-scoped services](#retrieving-data-from-dataminer-in-services) |
| [IConnection](xref:Skyline.DataMiner.Net.IConnection) | A live SLNet connection to the DataMiner System. | Extensions and [user-scoped services](#retrieving-data-from-dataminer-in-services) |
| [IGQISecurity](xref:GQI_IGQISecurity) | The current security context. | Extensions, security services, and user services |
| [IGQIUser](xref:GQI_IGQIUser) | The user context. | Extensions and user services |
| [IGQISession](xref:GQI_IGQISession) | The session context. | Extensions |
| [`CultureInfo`](https://learn.microsoft.com/dotnet/api/system.globalization.cultureinfo) | The culture used in the current query session. | Extensions |
| [`TimeZoneInfo`](https://learn.microsoft.com/dotnet/api/system.timezoneinfo) | The time zone used in the current query session. | Extensions |
| [GQILazy\<T\>](xref:GQI_GQILazyT) | [Deferred resolution](#deferred-service-injection) of a service dependency. | Extensions and services |
| [Registered GQI services](#registering-a-service) | A service instance registered in the same extension library. | Extensions and services, depending on the [service scope](#injecting-services-into-other-services) |

> [!IMPORTANT]
> Security-scoped and user-scoped services are tied to the current security context. When a user's security context changes, references to existing service instances remain valid but new service instances with the updated security context will be created for new references.
