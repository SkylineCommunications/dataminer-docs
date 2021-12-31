## Linking a shape to an alarm filter

If you link a shape to an alarm filter, it can be used to show statistical information about the alarms that match the filter.

> [!NOTE]
> -  Depending on their security level, different users may see different statistics.
> -  Because Visio files need to be able to display information for all users, only shared filters can be used.
> -  Cleared alarms are automatically removed from alarm filters in Visio. For information or suggestion events, this means that only open events are included, e.g. when a backup is currently ongoing.

Configure the shape data fields as follows:

1. Add a shape data field of type **AlarmSummary** to the shape, and set its value as follows:

    ```txt
    type|sharedfiltername|ApplyLinkedViewServiceOrElementFilter|Alarm|FilterContext=X
    ```

    Refer to the table below for the value syntax:

    | Value                               | Explanation                                                                                                                                                                          |
    |---------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | type                                  | Can be “all”, “active”, “information”, or “masked”<br> This is the type of alarm list: all alarms (including suggestion events), active alarms, information events or masked alarms. |
    | sharedfiltername                      | The name of the shared alarm filter, without “(shared filter)” suffix.                                                                                                               |
    | ApplyLinkedViewServiceOrElementFilter | “true” or “false”<br> If true, an additional dynamic filter is added, requiring the alarms to match the view, service or element to which the Visio file is linked.                  |
    | Alarm                                 | Use this option if you want the shape background to take the color associated with the summary alarm state of the alarm list.                                                        |
    | FilterContext=X                       | Available from DataMiner 10.0.3 onwards.<br> This option allows you to add an element, service or view filter. “X” can be the name or ID of the element, service or view.            |

    For example:

    | Shape data field | Value                                                      |
    |--------------------|------------------------------------------------------------|
    | AlarmSummary       | all\|MySharedFilter\|false\|Alarm\|FilterContext=MyService |

2. Optionally, from DataMiner 9.5.8/9.5.0 \[CU4\] onwards, to customize the default alarm level of the shape when the filter yields no results, add a shape data field of type **Options** and set its value to *DefaultAlarmLevel=*AlarmLevel. For example:

    | Shape data field | Value                    |
    |--------------------|--------------------------|
    | Options            | DefaultAlarmLevel=Normal |

3. Optionally, from DataMiner 10.0.2 onwards, you can configure the shape so that clicking it opens an alarm tab in the Alarm Console, containing the alarms matching the alarm filter. To do so, add a shape data field of type **AlarmTab**, and set it to *Name=**AlarmTabName*.

    For example:

    | Shape data field | Value              |
    |--------------------|--------------------|
    | AlarmTab           | Name=MyFilteredTab |

### Placeholders

The value of an **AlarmSummary** shape data field can contain dynamic placeholders like \[param:...\], etc. See [Placeholders for variables in shape data values](Placeholders_for_variables_in_shape_data_values.md).

In addition, you can also use the following placeholders in the shape text itself, so that they are replaced by statistical information in Visual Overview.

| Placeholder  | Value                        |
|--------------|------------------------------|
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
