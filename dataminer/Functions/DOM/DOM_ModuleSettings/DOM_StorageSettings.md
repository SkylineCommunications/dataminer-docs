---
uid: DOM_StorageSettings
---

# StorageSettings

The `StorageSettings` currently contains the configuration to define the caching behavior in the DOM manager. This is the only configurable option available in terms of storage at the moment.

## CachingSettings

From DataMiner 10.3.9/10.4.0 onwards<!-- RN 36412 -->, these settings can be used to define whether or not the configuration DOM objects should be cached. This settings object contains the following properties:

|Property                           |Type                   |Description |
|-----------------------------------|-----------------------|------------|
|DomDefinitionCachingPolicy         |DomConfigCachingPolicy |Caching policy for the `DomDefinition` objects. |
|DomBehaviorDefinitionCachingPolicy |DomConfigCachingPolicy |Caching policy for the `DomBehaviorDefinition` objects. |
|SectionDefinitionCachingPolicy     |DomConfigCachingPolicy |Caching policy for the `SectionDefinition` objects. |

For each type, you can define one of three caching policy options:

- **Default**: The default option. This will be automatically selected for new managers and for any managers that already existed before this feature was introduced. Behaves the same way as the "Full" option.
- **Disabled**: The cache will be disabled, and all read actions will use the database.
- **Full**: The cache will be enabled, and all objects of this type will be loaded in the cache when the DOM manager is initialized. All read actions will use this cache.
