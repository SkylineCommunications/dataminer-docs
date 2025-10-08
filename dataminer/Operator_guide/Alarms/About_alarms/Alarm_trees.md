---
uid: Alarm_trees
---

# Alarm trees

Whenever there is a change to an alarm after the original alarm record is created, a new alarm record is created that is linked to the previous one. This way, (nearly) every alarm in the DataMiner System will be represented by a series of linked alarm records, also known as an **alarm tree**, reflecting the entire alarm lifecycle.

Initially, when the DataMiner System detects that a parameter no longer has a value that is considered normal, it creates an alarm record with the following properties:

| Property    | Value        |
|-------------|--------------|
| Owner       | System       |
| User Status | Not Assigned |
| Alarm Type  | New Alarm    |
| Status      | Open         |

From that moment, every subsequent change to that alarm (severity changes, ownership changes, masking or unmasking, comments added, etc.) will result in the creation of a separate alarm record that will replace the original record.

As long as the parameter in question does not have a value that is considered normal, the *Status* property of these replacement records will be "Open". The moment the parameter again has a normal value, a final replacement record will be created. The *Status* property of this last record will be "Cleared" or "Clearable", depending on the value of the ["AutoClear" alarm setting](xref:Clearing_alarms).

> [!NOTE]
> If an alarm update does not change the severity of the alarm, the alarm record can be combined with the previous records into one consolidated event in the client (also known as "alarm squashing"). This behavior can be enabled in the *MaintenanceSettings.xml* file. For more information, see [AlarmSettings.MustSquashAlarms](xref:MaintenanceSettings_xml#alarmsettingsmustsquashalarms).

> [!TIP]
> Alarm trees should be kept from growing too large. When setting up alarm templates and working with alarms, you should therefore keep the [best practices](xref:Best_practices_for_assigning_alarm_severity_levels#keep-alarm-trees-from-growing-too-large) in mind.
