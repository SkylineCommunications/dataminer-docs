---
uid: MaintenanceSettings.AutoElementLock
---

# AutoElementLock element

When set to "true", an element will automatically be locked when a parameter set is performed on it by a user who is allowed to lock and unlock elements.

## Type

string

## Content Type

string

## Parents

[MaintenanceSettings](xref:MaintenanceSettings)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [time](xref:MaintenanceSettings.AutoElementLock-time) | integer |  | Specifies the automatic unlock delay in ms. |

## Remarks

To activate this setting, do the following:

1. Set the value of the AutoElementLock tag to TRUE.
1. Set the automatic unlock delay in the time attribute (default: 5000 ms).

A locked element will automatically be unlocked

- after 5 seconds (default setting), or
- when the client disconnects.

> [!NOTE]
> If the element is already locked, DataMiner will not automatically force unlock it. In that case, the user has to do this manually.
