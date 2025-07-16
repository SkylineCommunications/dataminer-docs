---
uid: EPMManagerGeneralConfiguration
---

# General configuration EPM Manager connector

When you set up a DataMiner EPM Solution, you must configure the header of the EPM Manager connector.

The [Protocol.Type](#type-configuration) and [Protocol.Display](#display-configuration) configuration are essential for this.

## Type configuration

| Tag | Attribute | Value | Description |
|--|--|--|--|
| [Type](xref:Protocol.Type) | [options](xref:Protocol.Type-options) | `disableViewRefresh` | Disables updates of view tables and partial subscriptions. |
| [Type](xref:Protocol.Type) | [databaseOptions](xref:Protocol.Type-databaseOptions) | `partitionedTrending` | Activates partitioning on trend tables. |

For example:

```xml
<Type relativeTimers="true" options="disableViewRefresh" databaseOptions="partitionedTrending">virtual</Type>
```

> [!NOTE]
> The connector is defined as virtual, as it does not require any communication settings.

## Display configuration

| Tag         | Attribute     | Value             | Description                                        |
|-------------|---------------|-------------------|----------------------------------------------------|
| [Display](xref:Protocol.Display) | [type](xref:Protocol.Display-type)        | `element manager` | Enables the EPM interface.                         |
| [Display](xref:Protocol.Display) | [pageOptions](xref:Protocol.Display-pageOptions) | `*;CPEOnly`       | Data pages are hidden for all users except the Administrator user. We do not recommended logging on as the Administrator in a Production environment. |

For example:

```xml
<Display type="element manager" pageOptions="*;CPEOnly" defaultPage="General" pageOrder="General" wideColumnPages="">
```
