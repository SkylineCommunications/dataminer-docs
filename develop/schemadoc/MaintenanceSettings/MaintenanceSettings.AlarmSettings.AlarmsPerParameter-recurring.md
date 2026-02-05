---
uid: MaintenanceSettings.AlarmSettings.AlarmsPerParameter-recurring
---

# recurring attribute

Configures whether and when a notice will be generated if the number of alarms in an alarm tree exceeds the AlarmsPerParameter setting.

> [!NOTE]
>
> - As of DataMiner 10.6.0 [CU1]/10.5.0 [CU13]/10.6.4 the recurring attribute is not applied anymore. No notice alarms will be generated anymore.

## Content Type

| Item | Facet Value | Description |
| --- | --- | --- |
| ***string restriction*** |  |  |
| &#160;&#160;Enumeration | true | An "Alarm history exceeded XXX alarms" notice will appear in the Alarm Console every time the number of alarms in an alarm tree exceeds the AlarmsPerParameter setting. (Default setting.) |
| &#160;&#160;Enumeration | false | An "Alarm history exceeded XXX alarms" notice will appear in the Alarm Console the first time the number of alarms in an alarm tree exceeds the AlarmsPerParameter setting. |
| &#160;&#160;Enumeration | disabled | An "Alarm history exceeded XXX alarms" notice will never appear in the Alarm Console when the number of alarms in an alarm tree exceeds the AlarmsPerParameter setting. |

## Parents

[AlarmsPerParameter](xref:MaintenanceSettings.AlarmSettings.AlarmsPerParameter)
