---
uid: Configuring_normal_alarm_thresholds
---

# Configuring normal alarm thresholds

The way you can configure the alarm thresholds for a parameter in the [alarm template editor](xref:About_the_alarm_template_editor) depends on the type of parameter, as detailed below.

Note the following:

- Depending on whether you are working on a new or existing alarm template, some parameters may not be shown by default. See [The alarm template editor user interface](xref:About_the_alarm_template_editor#the-alarm-template-editor-user-interface).

- It is not necessary to enter a value for each severity level. See [Guidelines for assigning alarm severity levels](xref:Guidelines_for_assigning_alarm_severity_levels).

- When multiple values are specified for one alarm severity, the existing alarm will be updated with a new value each time it crosses a new threshold.

- If you select the *Monitored* checkbox next to a parameter, but do not define any threshold, the parameter will be set to an undefined state.

- If you want to quickly enable or disable a large number of parameters, first select them by keeping the Ctrl key pressed or by selecting the first parameter, keeping the Shift key pressed, and then selecting the last parameter. Then right-click and select *Enable selected parameters* or *Disable selected parameters*, respectively. To select all parameters at once or clear the selection for all parameters at once, right-click the column header of the list of parameters and select *Enable all parameters* or *Disable all parameters*, respectively.

- For DVE elements, the parent element and child element alarm templates function as if they were part of an [alarm template group](xref:Alarm_template_groups), with the child element template getting the highest priority. This means that if a parameter is monitored in the parent element template, but not in the child element template, the parameter will not be monitored in the child element.

> [!NOTE]
> Instead of defining alarm thresholds as a fixed value, you can also set them as a dynamic threshold. See [Configuring dynamic alarm thresholds](xref:Configuring_dynamic_alarm_thresholds).

### Configuring alarm thresholds for analog parameters

To configure alarm thresholds for an [analog parameter](xref:Discrete_analog_and_hybrid_parameters#analog-parameters):

1. Select the checkbox in the first column next to the parameter to enable alarm monitoring

1. Enter the values you want for the different alarm severities.

   Specifying multiple values for one severity level can be done in two ways:

   - Add the different values in the threshold field, separating them by semicolons.

   - Click the threshold field and then click the + icon to the right of it. Then specify the value in the box below the field. Repeat for each value you want to add.

> [!NOTE]
> When incorrect or illogical data is entered for the analog values, a red warning message will appear in the header, and you will need to correct your alarm limits.

### Configuring alarm thresholds for discrete parameters

To configure alarm thresholds for a [discrete parameter](xref:Discrete_analog_and_hybrid_parameters#discrete-parameters):

1. Select the checkbox in the first column next to the parameter to enable alarm monitoring

1. Enter the values by clicking the threshold fields and then selecting the values in the list below.

   To specify multiple values, select multiple checkboxes in the list.

### Configuring alarm thresholds for hybrid parameters

To configure alarm thresholds for a [hybrid parameter](xref:Discrete_analog_and_hybrid_parameters#hybrid-parameters):

1. Select the checkbox in the first column next to the parameter to enable alarm monitoring

1. Enter the values you want for the different alarm severities, or select the exception value displayed below the threshold field.

   Multiple values can be specified in the same way as for [analog parameters](#configuring-alarm-thresholds-for-analog-parameters), except that you can also specify the exception value as well.

### Configuring alarm thresholds for string parameters

To configure alarm thresholds for a string parameter, i.e. a parameter that has a string as its value:

1. Select the checkbox in the first column next to the parameter to enable alarm monitoring

1. Specify the threshold(s) in the field similar to for an [analog parameter](#configuring-alarm-thresholds-for-analog-parameters).

   You can also use an asterisk (`*`) or question mark as a wildcard. If you enter only an asterisk for a particular alarm level, this means that any value other than the ones defined for the other alarm levels will trigger an alarm for this alarm level.

### Configuring alarm thresholds for dynamic table parameters

By default, each column of a [dynamic table](xref:Table_parameters#dynamic-tables) that has monitoring enabled will be represented by one row in the alarm template, so the alarm thresholds need to be determined per row.

1. To enable alarm monitoring for a table parameter column, select the checkbox in the first column of the template editor next to the table parameter column name.

1. Optionally, specify a mask in the *Filter* column to apply the alarm configuration only on a filtered selection of available rows of the dynamic table.

   > [!NOTE]
   > You can use the wildcard characters \* and ? in this filter mask. For more information on wildcards, see [Searching with wildcard characters](xref:Searching_in_DataMiner_Cube#searching-with-wildcard-characters).

1. When you hover the mouse over a parameter, several buttons appear that allow additional options:

   - Duplicate column parameters using the *+* button to define different alarm thresholds with different filters, so that different rows in the dynamic table will have different alarm thresholds.

   - When you have duplicated a column parameter, you can remove the duplicate again using the *x* button.

   - Use the up and down buttons, visible as an upwards and a downwards triangle, to change the order of the filters. This may be important as alarming is applied top to bottom.

1. Enter the values you want for the different alarm severities, as for a regular parameter.

> [!NOTE]
>
> - If an alarm template contains multiple duplicate instances of the same table column parameter, all those instances are displayed as soon as one of them is marked as being monitored, even if *Only monitored parameters* is selected in the top-right corner of the card.
> - If you want to configure a table to have all rows monitored, except certain specific rows, add an entry with a filter for those rows above the entry for the entire table, and make sure the entry with the filter is not selected. For example: <br>![Row filter in alarm template](~/user-guide/images/MonitorTableRow.png)

### Configuring alarm thresholds for matrix parameters

Depending on how they are configured in the protocol, for matrix parameters, alarm thresholds may need to be configured in a dedicated alarm level editor. You can set a different alarm level for any input or output, separately, or combined.

1. Select the checkbox in the first column for the matrix parameter to enable alarm monitoring for this parameter.

1. Click *Open Matrix Alarmlevel Editor*.

1. In the *Alarm level editor*:

   - To change the alarm level for an empty input or output, select the selection mode *Inputs/Outputs*, select the corresponding circle for the input or output and choose an alarm level.

     The circle you have selected will get the color of the selected alarm level.

   - To change the alarm level for a crosspoint, select the selection mode *Crosspoints*, select the corresponding cell and choose an alarm level.

     The cell you have selected will get the color of the selected alarm level.

   - Select either of the selection modes and click *All* to select all the inputs and outputs, or all the crosspoints, depending on the mode.

   - Click *None* to clear your selection.

> [!NOTE]
> For a [table-based matrix](xref:UIComponentsTableMatrix), it is not possible to use the matrix alarm level editor. Instead, the alarm thresholds for the crosspoints depend on the thresholds configured for the outputs tables.
