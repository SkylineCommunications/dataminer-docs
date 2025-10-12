---
uid: MaintenanceSettings.WatchDog.TechsupportNotifications.Reports
---

# Reports element

Configures what needs to be included in the reports.

## Parents

[TechsupportNotifications](xref:MaintenanceSettings.WatchDog.TechsupportNotifications)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [emailtime](xref:MaintenanceSettings.WatchDog.TechsupportNotifications.Reports-emailtime) | integer |  | Specifies the hour of the day to send the email.s |
| [interval](xref:MaintenanceSettings.WatchDog.TechsupportNotifications.Reports-interval) | integer |  | Specifies the report interval in hours. |

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| [Disable](xref:MaintenanceSettings.WatchDog.TechsupportNotifications.Reports.Disable) |  | Disables the specified items from being included in the reports. |
