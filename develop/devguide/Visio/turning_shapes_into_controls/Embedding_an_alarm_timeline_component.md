---
uid: Embedding_an_alarm_timeline_component
---

# Embedding an alarm timeline component

Using an alarm timeline component, you can visualize the alarm history of parameters as a dynamic timeline.

> [!TIP]
> For examples, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[controls > TIMELINE1 and TL2]* pages.

To configure a shape as an alarm timeline component:

1. Add a shape data field of type **Options** to the shape, and set its value to "alarmtimelines".

1. Add a shape data field of type **Parameters**, and set its value as follows in order to define the timeline bands and parameters:

   - Define the parameters in a band definition by specifying an element, a list of parameter IDs, an index, and the necessary options, separated as follows:

     ```txt
     element:pid:index;options
     ```

     | Components | Description                 |
     | ---------- | --------------------------- |
     | element | The element, which can be specified as a wildcard character "\*", in the format DMA ID/Element ID (e.g., 320/510), or with the element name. |
     | pid | The parameter, which can be specified by means of the parameter ID, or with a \[ServiceSelectionFilter\] placeholder.<br>Note: If you want to show the communication state timeline of a particular element (indicating the timeouts), use parameter 64501. |
     | index | If, in *pid*, you specified a table parameter, you can specify a table column index (or a variable containing an index) here.<br>Alternatively, you can also omit the index and specify a subscription filter in an additional shape data field of type **SubscriptionFilter**. If this filter returns multiple rows, the different timelines will be aggregated into one.<br>For more info on the syntax that can be used in the SubscriptionFilter shape data field, refer to [Dynamic table filter syntax](xref:Dynamic_table_filter_syntax). |
     | options | The following options can be specified, separated by semicolons (";").<br>- *IncludeInSummary*: If you specify this option, the parameter will be included in the calculation of the summary alarm timeline, which is displayed at the bottom of the control.<br>- *DisplayName=XXX*: Use this option to specify the band name to be displayed. If you do not specify this option, the default band name will be "elementName/parameterName/Index".<br>Note: This option can only be specified for a parameter for which you have also specified the *IncludeInSummary* option (since there can only be one title per band).<br>- *Height=0.xx*: If you specify this option, the parameter will take up xx% of the total band height. The specified height has to be a number between 0 and 1 (e.g., 0.75 means 75%). Each parameter within a particular band will have a top and bottom margin of 0.05 (i.e., 5% of the band height). |

   - Separate the parameter definitions by hyphens ("-") within a band definition.

     ```txt
     parameterDefinition-parameterDefinition-parameterDefinition
     ```

   - Separate the different band definitions by pipe characters ("\|").

     ```txt
     bandDefinition|bandDefinition|bandDefinition|bandDefinition
     ```

   For example, with the configuration below, the timeline control will have two bands. The first band will show two parameters, and the second band will show one parameter.

   ```txt
   320/508910:1019;Height=.20-320/508910:350;IncludeInSummary; Height=.65|183/67:1007:1;IncludeInSummary;Height=.60
   ```

1. If necessary, add the following additional options in the **Options** shape data field, separated by pipe characters:

   - To display custom text if the timeline control does not contain any timelines, add "EmptyText=", followed by the text to be displayed.
   - If dynamic placeholders are used in the shape data field of type **Parameters** and some dynamic placeholders cannot be resolved, by default the entire time line control will not be displayed. If you want the timeline control to instead disregard the bands for which no data could be retrieved and display those bands for which data could be retrieved, add "AllowEmptyDynamicValues".

   For example:

   ```txt
   alarmtimelines|EmptyText=No service selected|AllowEmptyDynamicValues
   ```

1. Optionally, you can add a shape data field of type **AlarmFilter**, so that you can pass an alarm filter to the Alarm Console by right-clicking a section of the timeline control and selecting *Show alarms in new tab*, or *Show alarms in linked tab* in case a linked Alarm Console tab is already open. The new tab page will show the alarms corresponding with the filter at the moment of the timeline where you clicked.

   For detailed information about the supported syntax for the AlarmFilter shape data field, see [Making a shape filter Alarm Console tabs when clicked](xref:Making_a_shape_filter_Alarm_Console_tabs_when_clicked).

   > [!NOTE]
   >
   > - You can define a custom name for the alarm tab page by adding "TabName=", followed by the custom name to the value of the **AlarmFilter** data field, separated from the actual alarm filter with a pipe character ("\|").
   > - In certain EPM environments, filters can be specified to the left of the timeline in Visual Overview. You can insert these filters in the alarm filter by using the following placeholders:
   >   - *\[ServiceFilterName\]* refers to the left column.
   >   - *\[ServiceFilterName2\]* refers to the right column.
   >   - Example: *Alarm.Service:"\[\[ServiceFilterName\]\]" Alarm.Tx:"\[\[ServiceFilterName2\]\]"*

1. Normally, as long as not all configured timelines have been received by the client, Visual Overview will indicate that content is still loading. Optionally, you can disable this, by adding "EnableLoading=False" to the **Options** shape data field.

   ```txt
   alarmtimelines|...|EnableLoading=False
   ```
