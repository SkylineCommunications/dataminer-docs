---
uid: MaintenanceSettings.DeltCache
---

# DeltCache element

Configures the cleanup instructions for the `C:\Skyline DataMiner\System Cache\DELT\` folder. Every time a .dmimport package is exported from or imported onto a DataMiner Agent, it is stored in this folder. By default, the 20 most recent packages are kept.

## Parents

[MaintenanceSettings](xref:MaintenanceSettings)

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| [DELTCacheMode](xref:MaintenanceSettings.DeltCache.DELTCacheMode) | [0, 1] | Specifies the DELT cache mode. |

## Remarks

> [!NOTE]
>
> - DELT stands for *DataMiner Element Location Transparency*. It is the feature that allows the exporting and importing of packages as well as migration of elements across DMAs in a cluster.
> - If no cleanup instructions are configured in *MaintenanceSettings.xml*, by default only the 20 most recent packages will be kept.

## Examples

### Example 1

If you specify the following cleanup condition, after each import or export operation, DataMiner will delete all packages except the four most recent ones.

```xml
<DELTCache activated="true">
  <DELTCacheMode mode="CleanupKeepRecentPackages" value="4"/>
</DELTCache>
```

### Example 2

In the following example, three cleanup conditions have been specified.

When you specify multiple conditions, they will be combined into one expression using OR operators. In other words: a package will be deleted as soon as one of the conditions match.

```xml
<DELTCache activated="true">
  <DELTCacheMode mode="CleanupKeepRecentPackages" value="4"/>
  <DELTCacheMode mode="CleanupLargerThan" value="2099200"/>
  <DELTCacheMode mode="CleanupOlderThan" value="2024-04-25 00:00"/>
</DELTCache>
```
