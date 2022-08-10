---
uid: Linking_a_shape_to_an_alarm_filter
---

# Linking a shape to an alarm filter

If you link a shape to an alarm filter, it can be used to show statistical information about the alarms that match the filter.

> [!NOTE]
>
> - Depending on their security level, different users may see different statistics.
> - Because Visio files need to be able to display information for all users, only shared filters can be used.
> - Cleared alarms are automatically removed from alarm filters in Visio. For information or suggestion events, this means that only open events are included, e.g. when a backup is currently ongoing.
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[linking > ALARM]* page.

Configure the shape data fields as follows:

1. Add a shape data field of type **AlarmSummary** to the shape, and set its value as follows:

   ```txt
   type|sharedfiltername|ApplyLinkedViewServiceOrElementFilter|Alarm|FilterContext=X
   ```

   - **type**: Can be "all", "active", "information", or "masked". This corresponds with the type of alarm list: all alarms (including suggestion events), active alarms, information events or masked alarms.

   - **sharedfiltername**: The name of the shared alarm filter, without "(shared filter)" suffix.

   - **ApplyLinkedViewServiceOrElementFilter**: Can be "true" or "false". If true, an additional dynamic filter is added, requiring the alarms to match the view, service or element to which the Visio file is linked.

   - **Alarm**: Use this option if you want the shape background to take the color associated with the summary alarm state of the alarm list.

   - **FilterContext=X**: Allows you to specify a filter context.

     - From DataMiner 10.0.3 onwards, this can be an **element, service or view filter**. In this case, "X" is the name or ID of the element, service or view.
     - From DataMiner 10.3.0/10.2.3 onwards, you can add an **EPM system name filter**. In that case, "X" should be "SystemName=" followed by the EPM system name.
     - From DataMiner 10.3.0/10.2.3 onwards, you can add an **EPM system type filter**. In that case, "X" should be "SystemType="followed by the EPM system type.
     - The SystemName and SystemType context can be combined using the syntax `FilterContext=SystemName=X;SystemType=Y`.

   For example:

   | Shape data field | Value                                                      |
   | ---------------- | ---------------------------------------------------------- |
   | AlarmSummary     | all\|MySharedFilter\|false\|Alarm\|FilterContext=MyService |

   | Shape data field | Value                                                                          |
   | ---------------- | ------------------------------------------------------------------------------ |
   | AlarmSummary     | active\|MySharedFilter\|false\|Alarm\|FilterContext=SystemName=MyEPMSystemName |

1. Optionally, from DataMiner 9.5.8/9.5.0 \[CU4\] onwards, to customize the default alarm level of the shape when the filter yields no results, add a shape data field of type **Options** and set its value to "DefaultAlarmLevel=*AlarmLevel*". For example:

   | Shape data field | Value                    |
   | ---------------- | ------------------------ |
   | Options          | DefaultAlarmLevel=Normal |

1. Optionally, from DataMiner 10.0.2 onwards, you can configure the shape so that clicking it opens an alarm tab in the Alarm Console, containing the alarms matching the alarm filter. To do so, add a shape data field of type **AlarmTab**, and set it to "Name=\*\*AlarmTabName".

   For example:

   | Shape data field | Value              |
   | ---------------- | ------------------ |
   | AlarmTab         | Name=MyFilteredTab |

## Placeholders

The value of an **AlarmSummary** shape data field can contain dynamic placeholders like \[param:...\], etc. See [Placeholders for variables in shape data values](xref:Placeholders_for_variables_in_shape_data_values).

In addition, you can also use the following placeholders in the shape text itself, so that they are replaced by statistical information in Visual Overview.

| Placeholder  | Value                        |
| ------------ | ---------------------------- |
| #Alarms      | Number of alarms             |
| #NewAlarms   | Number of new alarms         |
| #Critical    | Number of critical alarms    |
| #Major       | Number of major alarms       |
| #Minor       | Number of minor alarms       |
| #Warning     | Number of warning alarms     |
| #Notice      | Number of notice alarms      |
| #Error       | Number of error alarms       |
| #Information | Number of information events |
| #Masked      | Number of masked alarms      |
| #Normal      | Number of normal alarms      |
| #Timeout     | Number of timeout alarms     |
