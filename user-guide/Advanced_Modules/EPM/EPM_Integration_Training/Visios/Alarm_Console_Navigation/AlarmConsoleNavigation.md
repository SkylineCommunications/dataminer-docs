---
uid: AlarmConsoleNavigation
---

# Alarm Console Navigation

This builds on the Filtering Alarm With System Name and Type section, by adding an extra attribute that allows the user to navigate to the alarm filter tab in the alarm console. This can be done by adding shape data fields called AlarmTab with the following syntax.

- AlarmTab

    ```xml
      Name=MyFilteredTab
    ```

> [!NOTE]
> From DataMiner 10.0.2 onwards, you can configure the shape so that clicking it opens an alarm tab in the Alarm Console.

For more detailed information, see [Linking a shape to an alarm filter](xref:Linking_a_shape_to_an_alarm_filter).

## Visual example

![image](~/user-guide/images/EPM_alarm_console_navigation_example.png)
