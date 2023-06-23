---
uid: DOM_StorageSettings
---

# StorageSettings

The `StorageSettings` currently contains the configuration to define the caching behavior in the DOM manager. This is the only configurable option available in terms of storage at the moment.

## CachingSettings

The `CachingSettings` can be used to define whether or not the configuration DOM objects should be cached. This settings object contains the following properties:

|Property                           |Type                   |Description |
|-----------------------------------|-----------------------|------------|
|DomDefinitionCachingPolicy         |DomConfigCachingPolicy |Caching policy for the `DomDefinition` objects. |
|DomBehaviorDefinitionCachingPolicy |DomConfigCachingPolicy |Caching policy for the `DomBehaviorDefinition` objects. |
|SectionDefinitionCachingPolicy     |DomConfigCachingPolicy |Caching policy for the `SectionDefinition` objects. |

For each type, you can define one of three caching policy options:

- **Default** : The default option. This will be selected for any new and existing manager. Behaves the same as the 'Full' option.
- **Disabled** : The cache will be disabled and all reads will go to the database.
- **Full** : The cache will be enabled and all objects of this type will be loaded in the cache when the DOM manager is initialized. All reads will go to this cache.
