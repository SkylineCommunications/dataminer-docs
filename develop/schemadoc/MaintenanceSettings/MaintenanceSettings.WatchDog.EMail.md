---
uid: MaintenanceSettings.WatchDog.EMail
---

# EMail element

Configures email settings.

## Parents

[WatchDog](xref:MaintenanceSettings.WatchDog)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [active](xref:MaintenanceSettings.WatchDog.EMail-active) | boolean |  | Specifies whether email notification is active. |

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| All | [0, 1] |  |
| &#160;&#160;[BCCDestination](xref:MaintenanceSettings.WatchDog.EMail.BCCDestination) | [0, 1] | Specifies the blind carbon copy (BCC) destination email address. |
| &#160;&#160;[CCDestination](xref:MaintenanceSettings.WatchDog.EMail.CCDestination) | [0, 1] | Specifies the carbon copy (CC) destination email address. |
| &#160;&#160;[Destination](xref:MaintenanceSettings.WatchDog.EMail.Destination) |  | Specifies the destination email address. |
