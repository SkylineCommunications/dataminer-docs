---
uid: MaintenanceSettings.AlarmSettings
---

# AlarmSettings element

Configures how timeout alarms are visualized in Microsoft Visio shapes.

## Parents

[MaintenanceSettings](xref:MaintenanceSettings)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [elementTimeoutMode](xref:MaintenanceSettings.AlarmSettings-elementTimeoutMode) | string |  | Configures what color will be shown for shapes linked to elements. |
| [serviceTimeoutMode](xref:MaintenanceSettings.AlarmSettings-serviceTimeoutMode) | string |  | Configures what color will be shown for shapes linked to services. |
| [viewTimeoutMode](xref:MaintenanceSettings.AlarmSettings-viewTimeoutMode) | string |  | Configures what color will be shown for shapes linked to views. |

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| All |  |  |
| &#160;&#160;[AlarmsPerParameter](xref:MaintenanceSettings.AlarmSettings.AlarmsPerParameter) | [0, 1] | Specifies the maximum number of alarms that can be included in an alarm tree. |
| &#160;&#160;[AutoClear](xref:MaintenanceSettings.AlarmSettings.AutoClear) | [0, 1] | If you set AutoClear to "false", alarms will not be cleared automatically. Instead, they will go into a "clearable" state and must be cleared manually. |
| &#160;&#160;[Blinking](xref:MaintenanceSettings.AlarmSettings.Blinking) | [0, 1] | Configures elements, services, and views to blink in DataMiner Cube if they have an alarm of which nobody has taken ownership. |
| &#160;&#160;[MaxFreezeAlarms](xref:MaintenanceSettings.AlarmSettings.MaxFreezeAlarms) | [0, 1] | Specifies the maximum number of alarms that will be kept in the alarm buffer when the Alarm Console is frozen. |
| &#160;&#160;[MaxFreezeTime](xref:MaintenanceSettings.AlarmSettings.MaxFreezeTime) | [0, 1] | Specifies the maximum period of time the Alarm Console can stay frozen (in milliseconds). |
| &#160;&#160;[MustSquashAlarms](xref:MaintenanceSettings.AlarmSettings.MustSquashAlarms) | [0, 1] | Enables (true) or disables (false) alarm consolidation by default. If this is enabled, consecutive alarm events without a severity change will be combined into a consolidated event in the DataMiner client software. This may be useful to reduce the load on DataMiner Cube and on the SLNet process. |
| &#160;&#160;[PersistParameterLatchState](xref:MaintenanceSettings.AlarmSettings.PersistParameterLatchState) | [0, 1] | Enables persistent parameter latch states. |
| &#160;&#160;[UseCreationTimeAsMainTime](xref:MaintenanceSettings.AlarmSettings.UseCreationTimeAsMainTime) | [0, 1] | Specifies whether to use the creation time as main time. |
