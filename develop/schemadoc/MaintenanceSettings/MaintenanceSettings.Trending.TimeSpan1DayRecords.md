---
uid: MaintenanceSettings.Trending.TimeSpan1DayRecords
---

# TimeSpan1DayRecords element

Customizes the interval of the 1-day "average trending" records.

## Type

decimal

## Content Type

decimal

## Parents

[Trending](xref:MaintenanceSettings.Trending)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [unit](xref:MaintenanceSettings.Trending.TimeSpan1DayRecords-unit) | string |  | Specifies the unit. |
| [window](xref:MaintenanceSettings.Trending.TimeSpan1DayRecords-window) | decimal |  | Specifies the window. |

## Remarks

By default, this is not included. If you do include this tag, make sure to not set it to "0", as this configuration is invalid and would lead to issues.

> [!NOTE]
> If you are looking to configure how long these records need to be stored, see [DBMaintenanceDMS.xml](xref:DBMaintenanceDMS_xml).
