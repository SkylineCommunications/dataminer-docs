---
uid: MaintenanceSettings.DELTUpgrades
---

# DELTUpgrades element

Configures the automatic cleanup of DELT-related packages in the folder `C:\Skyline DataMiner\Upgrades\`.

## Parents

[MaintenanceSettings](xref:MaintenanceSettings)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [activated](xref:MaintenanceSettings.DELTUpgrades-activated) | anySimpleType |  | Specifies whether this functionality is activated. |

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| [Delete](xref:MaintenanceSettings.DELTUpgrades.Delete) | [1, *] | Specifies a particular deletion mode with a mode attribute and a corresponding value with a value attribute. |

## Remarks

The tag contains a number of [Delete](xref:MaintenanceSettings.DELTUpgrades.Delete) subtags, which each specify a particular deletion mode with a *mode* attribute and a corresponding value with a *value* attribute.

## Examples

```xml
<DELTUpgrades activated="true">
  <Delete mode="CleanupKeepRecentPackages" value="4"/>
  <Delete mode="CleanupLargerThan" value="2099200"/>
  <Delete mode="CleanupOlderThan" value="2016-04-25 00:00"/>
  <Delete mode="CleanupAll" />
</DELTUpgrades>
```
