---
uid: MaintenanceSettings.AlarmSettings.Blinking
---

# Blinking element

Configures elements, services and views to blink in DataMiner Cube if they have an alarm of which nobody has taken ownership.

## Parents

[AlarmSettings](xref:MaintenanceSettings.AlarmSettings)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [alarmFilter](xref:MaintenanceSettings.AlarmSettings.Blinking-alarmFilter) | string |  | Specifies the name of a shared, public alarm filter. Alarms will only blink if they match the filter. |
| [blankInterval](xref:MaintenanceSettings.AlarmSettings.Blinking-blankInterval) | integer | Yes | The number of milliseconds the item (icon, card header, alarm in Alarm Console, etc.) is hidden. Default: 200. |
| [blinkInterval](xref:MaintenanceSettings.AlarmSettings.Blinking-blinkInterval) | integer | Yes | The number of milliseconds the item (icon, card header, alarm in Alarm Console, etc.) is shown. Default: 1000. |
| [elementFilter](xref:MaintenanceSettings.AlarmSettings.Blinking-elementFilter) | string |  | Specifies the name of a shared, public alarm filter. Elements will only blink if they match the filter. |
| [enabled](xref:MaintenanceSettings.AlarmSettings.Blinking-enabled) | boolean | Yes | Whether the Blinking feature is activated or not. |
| [serviceFilter](xref:MaintenanceSettings.AlarmSettings.Blinking-serviceFilter) | string |  | Specifies the name of a shared, public alarm filter. Services will only blink if they match the filter. |
| [serviceSeveritiesFilter](xref:MaintenanceSettings.AlarmSettings.Blinking-serviceSeveritiesFilter) | string |  | Comma-separated list of alarm severities. If the overall alarm severity of a service matches one of the listed severities, it will blink. |
| [viewFilter](xref:MaintenanceSettings.AlarmSettings.Blinking-viewFilter) | string |  | Specifies the name of a shared, public alarm filter. Views will only blink if they match the filter. Note that any alarm that is contained in a view that matches the filter will blink, and any other views that contain that same alarm will also blink. |

## Remarks

> [!NOTE]
>
> - For optimal effect, the blankInterval should be less than the blinkInterval.
> - There are also several optional filter attributes to enable blinking of alarms based on certain conditions. For more information, see [Making alarms without owner blink](xref:Making_alarms_without_owner_blink).