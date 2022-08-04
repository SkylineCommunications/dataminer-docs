---
uid: DOM_TtlSettings
---

# TtlSettings

From DataMiner 10.2.6/10.3.0 onwards, these settings can be used to optionally define a separate time to live (TTL) for specific types of objects of a DOM manager. The time is defined as a `TimeSpan` object. By default, this will be `TimeSpan.Zero`, which represents no TTL. When this is for example set to 1 year for a type of object, those objects will be removed within 30 minutes when they have last been modified longer than a year ago.

TTL can currently be configured for the following objects:

| Object type | Property name |
|--|--|
| DomInstance | DomInstanceTtl |
| DomTemplate | DomTemplateTtl |
| HistoryChange (DomInstanceHistory) | DomInstanceHistoryTtl |

## Example

```csharp
var moduleSettings = new ModuleSettings("example")
{
    DomManagerSettings = new DomManagerSettings()
    {
        TtlSettings = new TtlSettings()
        {
            DomTemplateTtl = TimeSpan.Zero,                 // No TTL
            DomInstanceHistoryTtl = TimeSpan.FromDays(365), // 1 Year
            DomInstanceTtl = TimeSpan.FromDays(730)         // 2 Years
        }
    }
};
```

## Notes

- **Always reinitialize the DOM manager after updating the TTL settings** on the `ModuleSettings`. Otherwise, the updated time will not be applied to existing `DomManager` instances.

- To ensure the TTL is respected for a type in a DOM manager, make sure that **at least one instance of that manager is running** AND that **at least one CRUD action** for that type has been executed since the latest startup. This makes sure that the SLDataGateway process that manages the TTL is aware of the database index for that type and manager.

- The TTL is managed by the SLDataGateway process and is checked every 30 minutes. When you configure a very short TTL (e.g. 15 minutes), keep in mind that the removal may be later than expected, as the next cleanup cycle has to occur first.

- The TTL is applied on the complete database index of the various object types. That means that when the TTL is updated, it will be applied to all existing objects as well (when the DOM manager has been reinitialized).
