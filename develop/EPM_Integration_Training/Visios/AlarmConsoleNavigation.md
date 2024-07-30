---
uid: AlarmConsoleNavigation
---

# Linking a shape to a filtered alarm tab

Often, shapes in an EPM visual overview will be configured so that clicking them opens a tab in the Alarm Console that is filtered to show alarms filtered based on the clicked shape.

When a shape is used to [filter alarms based on System Name and/or type](xref:FilteringAlarmsUsingSystemNameType), you can configure this by adding an extra **AlarmTab** shape data field (supported from DataMiner 10.0.2 onwards):

| Shape data field | Value syntax       |
|------------------|--------------------|
| AlarmTab         | ```text Name=MyFilteredTab``` |

Example:

![image](https://github.com/user-attachments/assets/d0962a8e-6c93-4468-acf0-038a6fac52f7)


> [!TIP]
> For more detailed information, see [Linking a shape to an alarm filter](xref:Linking_a_shape_to_an_alarm_filter).

Live system example:
![image](https://github.com/user-attachments/assets/43d16a91-a3af-4bce-b943-cc79d4cd3b74)

