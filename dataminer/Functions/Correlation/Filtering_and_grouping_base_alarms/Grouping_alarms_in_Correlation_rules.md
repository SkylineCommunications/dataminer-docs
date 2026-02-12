---
uid: Grouping_alarms_in_Correlation_rules
---

# Grouping alarms in correlation rules

With the DataMiner Cube Correlation engine, you can group alarms matching the same criteria into separate correlated alarms. For example, all alarms from various services can be grouped into one correlated alarm per service.

In the Correlation module, the *Alarm Grouping* section of the details pane allows you to specify the way the alarms should be grouped before they are evaluated:

1. Click *Add grouping* and select one of the listed grouping options:

   - by alarm: Creates a correlated alarm per individual alarm update.

   - by component info. See [Creating an information template](xref:Creating_an_information_template).

   - by connectivity: Groups alarms that are part of the same connectivity chain.

   - by DataMiner

   - by element

   - by function. See [Service and Resource Management](xref:About_SRM).

   - by key point. See [Creating an information template](xref:Creating_an_information_template).

   - by parameter

   - by property value

     > [!NOTE]
     > From DataMiner 10.3.0 [CU7]/10.3.4 onwards, when a correlation rule is configured to use alarm grouping via an alarm property, the value of the alarm property by which the alarms are grouped will by default be added to the correlated alarm. Because of this added functionality, by looking at the correlated alarm, you can easily see based on what shared value the alarms were grouped. If you do not want the alarm property value to be added to the correlation alarm, contact [support.data-insights@skyline.be](mailto:support.data-insights@skyline.be). <!-- RN 35583 -->

   - by service

   - by table index

   - by view

     > [!NOTE]
     > If you have alarms grouped by view, and an alarm event occurs on an element that is in multiple views, the alarm is added for each of these views. However, only elements directly under a view will be grouped. Elements from subviews will not be part of the same group.

1. If you want to select an additional grouping method, go back to step 1.

1. If you want to move one of the grouping methods up or down in the list, hover over the method and click the upward or downward triangle.

1. If you want to delete one of the grouping methods, hover over the method and click the X.
