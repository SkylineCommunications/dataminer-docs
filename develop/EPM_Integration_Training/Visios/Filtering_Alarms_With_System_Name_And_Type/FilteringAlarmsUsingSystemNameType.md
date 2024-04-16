---
uid: FilteringAlarmsUsingSystemNameType
---

# Filtering Alarms Using System Name and Type

You can link a shape to an alarm filter in Visio, it can be used to show statistical information about the alarms that match the filter. This can be done by adding shape data fields called AlarmSummary with the following syntax.

- AlarmSummary

  ```xml
      type|sharedfiltername|ApplyLinkedViewServiceOrElementFilter|Alarm|FilterContext=X
  ```
  
> [!NOTE]
> The FilterContext option will allow you to link the shape to an EPM object by using one or both of the following options:
>
> - From DataMiner 10.3.0/10.2.3 onwards, you can add an EPM system name filter. In that case, "X" should be "SystemName=" followed by the EPM system name.
> - From DataMiner 10.3.0/10.2.3 onwards, you can add an EPM system type filter. In that case, "X" should be "SystemType="followed by the EPM system type.
> - The SystemName and SystemType context can be combined using the syntax FilterContext=SystemName=X;SystemType=Y.

For more detailed information, see [Linking a shape to an alarm filter](xref:Linking_a_shape_to_an_alarm_filter).

# Visual Example

![image](~/develop/images/EPM_filtering_alarms_example.png)
