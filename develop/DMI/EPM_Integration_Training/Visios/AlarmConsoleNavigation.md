---
uid: AlarmConsoleNavigation
---

# Linking a shape to a filtered alarm tab

Often, shapes in an EPM visual overview will be configured so that clicking them opens a tab in the Alarm Console that is filtered to show alarms filtered based on the clicked shape.

When a shape is used to [filter alarms based on System Name and/or type](xref:FilteringAlarmsUsingSystemNameType), you can configure this by adding an extra **AlarmTab** shape data field (supported from DataMiner 10.0.2 onwards):

| Shape data field | Value syntax       |
|------------------|--------------------|
| AlarmTab         | `Name=MyFilteredTab` |

Example:

![AlarmTab configuration example](~/develop/images/EPM_alarm_console_navigation_example.png)

> [!TIP]
> For more detailed information, see [Linking a shape to an alarm filter](xref:Linking_a_shape_to_an_alarm_filter).

Example of a live system:

![Live system](~/develop/images/Linking_shape_to_filtered_alarm_tab.png)
