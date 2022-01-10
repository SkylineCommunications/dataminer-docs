## Configuring alarm templates

In this section:

- [About the alarm template editor](#about-the-alarm-template-editor)

- [Configuring alarm thresholds](#configuring-alarm-thresholds)

- [Configuring alarm thresholds for matrix parameters](#configuring-alarm-thresholds-for-matrix-parameters)

- [Configuring alarm thresholds for dynamic table parameters](#configuring-alarm-thresholds-for-dynamic-table-parameters)

- [Configuring alarm hysteresis in an alarm template](#configuring-alarm-hysteresis-in-an-alarm-template)

- [Configuring an alarm template with dynamic alarm thresholds](#configuring-an-alarm-template-with-dynamic-alarm-thresholds)

- [Configuring an alarm template to generate information messages](#configuring-an-alarm-template-to-generate-information-messages)

- [Using conditions in an alarm template](#using-conditions-in-an-alarm-template)

- [Configuring anomaly detection alarms for specific parameters](#configuring-anomaly-detection-alarms-for-specific-parameters)

- [Setting the autoclear options for alarms in an alarm template](#setting-the-autoclear-options-for-alarms-in-an-alarm-template)

- [Scheduling an alarm template](#scheduling-an-alarm-template)

### About the alarm template editor

To configure an alarm template, you must first open the template editor. This can be done as follows:

- From the overview of all templates in the Protocols & Templates module:

    - In the app, right-click the template and select *Open*, *Open in new card* or *Open in new undocked card*.

- From a particular element or service in the Surveyor:

    - To open an existing template, right-click the element or service in the Surveyor and select *Protocols & Templates \> View alarm template '\[template name\]'*.

    - To create and configure a new template, right-click the element or service in the Surveyor and select *Protocols & Templates \> Assign alarm template* > *\<New alarm template>*. Then specify the name for the new template and click *OK*.

This will open the alarm template editor, which consists of two main sections:

- The *General* section at the top, which you can expand by clicking *Show details*:

    - At the top, you can specify a description for the template.

        > [!NOTE]
        > From DataMiner 9.0.5 onwards, templates can be quickly assigned via the Surveyor right-click menu. The description you enter here is shown as a tooltip in that menu, and may help users to select the correct template.

    - On the right, this section shows the protocol and protocol version linked to the template, and a list of elements to which it has been assigned.

    - At the bottom of the section, you can schedule when the alarm template should be applied. See [Scheduling an alarm template](#scheduling-an-alarm-template).

- The *Alarm template parameters* section, where alarm thresholds can be configured:

    - By default, for a new alarm template, general parameters are not displayed. To configure monitoring for these, click the *Only monitored parameters* button and select *Only protocol parameters* or *All parameters (protocol + general)*.

    - If you open an existing alarm template, only the parameters for which thresholds have been set are shown. To see other parameters as well, click the *Only monitored parameters* button and select *Only protocol parameters* or *All parameters (protocol + general)*.

    - To quickly find a particular parameter, you can use the filter box in the top-right corner.

For more information on how to configure alarm thresholds, refer to the sections below. Also keep the following information in mind:

- If you select the *Monitored* checkbox next to a parameter, but do not define any threshold, the parameter will be set to an undefined state.

- From DataMiner 9.0.0 CU14 onwards, you can select or deselect all parameters at once, by right-clicking the column header of the list of parameters and selecting *Enable all parameters* or *Disable all parameters*, respectively.

- For DVE elements, the parent element and child element alarm templates function as if they were part of an alarm template group, with the child element template getting the highest priority. This means that if a parameter is monitored in the parent element template, but not in the child element template, the parameter will not be monitored in the child element. See also [Alarm template groups](Alarm_template_groups.md).

- When you finish the configuration of an alarm template, from DataMiner 9.0.5 onwards, a dialog box will appear that allows you to immediately link that template to one or more elements.

### Configuring alarm thresholds

To determine the alarm thresholds for a parameter, first select the checkbox in the first column next to the parameter to enable alarm monitoring.

You can then specify the alarm thresholds:

- To do so for an **analog** parameter, simply enter the values you want for the different alarm severities.

    Specifying multiple values for one severity level can be done in two ways:

    - Add the different values in the threshold field, separating them by semicolons.

    - Click the threshold field and then click the + icon to the right of it. Then specify the value in the box below the field. Repeat for each value you want to add.

    > [!NOTE]
    > -  When incorrect or illogical data is entered for the analog values, a red warning message will appear in the header, and you will need to correct your alarm limits.

- For a **discrete** parameter, enter the values by clicking the threshold fields and then selecting the values in the list below.

    To specify multiple values, simply select multiple checkboxes in the list.

- For a **hybrid** parameter, you can enter the values manually like for an analog parameter, or select the exception value displayed below the threshold field.

    Multiple values can be specified in the same way as for analog parameters, except that you can also specify the exception value as well.

- For a **string** parameter, i.e. a parameter that has a string as its value, you can specify the threshold(s) in the field similar to for an analog parameter.

    However, for this type of parameter, it is also possible to use an asterisk (“\*”) or question mark as a wildcard. If you enter only an asterisk for a particular alarm level, this means that any value other than the ones defined for the other alarm levels will trigger an alarm for this alarm level.

When multiple values are specified for one alarm severity, the existing alarm will be updated with a new value each time it crosses a new threshold.

> [!NOTE]
> -  It is not necessary to enter a value for each severity level. See [Guidelines for assigning alarm severity levels](Guidelines_for_assigning_alarm_severity_levels.md).
> -  It is also possible to enable or disable parameters through the template editor right-click menu.

> [!TIP]
> See also:
> [Discrete, analog and hybrid parameters](../parameters/Discrete_analog_and_hybrid_parameters.md)

### Configuring alarm thresholds for matrix parameters

To determine the alarm thresholds for matrix parameters:

1. Select the checkbox in the first column for the matrix parameter to enable alarm monitoring for this parameter.

2. Click *Open Matrix Alarmlevel Editor*.

3. In the *Alarm level editor*:

    - To change the alarm level for an empty input or output, select the selection mode *Inputs/Outputs*, select the corresponding circle for the input or output and choose an alarm level.

        The circle you have selected will get the color of the selected alarm level.

    - To change the alarm level for a crosspoint, select the selection mode *Crosspoints*, select the corresponding cell and choose an alarm level.

        The cell you have selected will get the color of the selected alarm level.

    - Select either of the selection modes and click *All* to select all the inputs and outputs, or all the crosspoints, depending on the mode.

    - Click *None* to clear your selection.

> [!NOTE]
> With the matrix parameter alarm level editor, it is possible to set a different alarm level for any input or output, separately or combined.

### Configuring alarm thresholds for dynamic table parameters

By default, each column of a dynamic table that has monitoring enabled will be represented by one row in the alarm template, so the alarm thresholds need to be determined per row.

1. To enable alarm monitoring for a table parameter column, select the checkbox in the first column of the template editor next to the table parameter column name.

2. Optionally, specify a mask in the *Filter* column to apply the alarm configuration only on a filtered selection of available rows of the dynamic table.

    > [!NOTE]
    > You can use the wildcard characters \* and ? in this filter mask. For more information on wildcards, see [Searching with wildcard characters](../../part_1/GettingStarted/Searching_in_DataMiner_Cube.md#searching-with-wildcard-characters).

3. When you hover the mouse over a parameter, several buttons appear that allow additional options:

    - Duplicate column parameters using the *+* button to define different alarm thresholds with different filters, so that different rows in the dynamic table will have different alarm thresholds.

    - When you have duplicated a column parameter, you can remove the duplicate again using the *x* button.

    - Use the up and down buttons, visible as an upwards and a downwards triangle, to change the order of the filters. This may be important as alarming is applied top to bottom.

4. Enter the values you want for the different alarm severities, as for a regular parameter.

    > [!NOTE]
    > -  If an alarm template contains multiple duplicate instances of the same table column parameter, all those instances are displayed as soon as one of them is marked as being monitored, even if *Only monitored parameters* is selected in the top-right corner of the card.
    > -  If you want to configure a table to have all rows monitored, except certain specific rows, add an entry with a filter for those rows above the entry for the entire table, and make sure the entry with the filter is not selected. For example:<br>![](../../images/MonitorTableRow.png)

### Configuring alarm hysteresis in an alarm template

Two types of hysteresis are available, Clear hysteresis and Alarm hysteresis, respectively having an effect on the clearing and the triggering of alarms:

- Enter a value in the *Hyst off* column to determine the number of seconds before the severity level of an alarm decreases.

- Enter a value in the *Hyst on* column to determine the number of seconds before the severity level of an alarm increases.

- From DataMiner 9.5.7 onwards, it is possible to apply hysteresis to specific severity levels only. To do so, when you enter a value in the *Hyst off* or *Hyst on* box, select the severity levels in the drop-down list below the box.

> [!NOTE]
> -  For most parameters, the hysteresis interval has to be higher than the polling interval. For example, if a parameter is only polled every 10 seconds, you should not configure a hysteresis interval of 5 seconds. However, an exception to this are parameters updated via traps or via a smart-serial connection.
> -  For parameters of type string, hysteresis should only be applied to "high" severity levels (e.g. Warning High, Major High), not to "low" severity levels. From DataMiner 10.1.9/10.2.0 onwards, applying hysteresis to "low" severity levels is no longer possible for string parameters.

> [!TIP]
> See also:
> -  [Alarm hysteresis](../alarms/Alarm_hysteresis.md)
> -  <https://community.dataminer.services/video/alarm-templates-hysteresis/>



### Configuring an alarm template with dynamic alarm thresholds

You can either define the alarm thresholds as a fixed value, or you can set them as a dynamic threshold that is compared to a certain “normal” value. This value will automatically be determined at runtime, or via a normalization procedure for each separate element.

The different types of alarm thresholds can be selected in the drop-down list in the *Type* column:

| Type     | Description                                                                                                        |
|----------|--------------------------------------------------------------------------------------------------------------------|
| Normal   | The normal value and the different alarm thresholds are fixed by the operator. This option is selected by default. |
| Relative | Alarm thresholds are set as a percentage, which represents the delta with the baseline value.                      |
| Absolute | Alarm thresholds are set as an absolute value, which represents the delta with the baseline value.                 |
| Rate     | The alarm threshold value is the delta with the current value and the previously measured value.                   |

> [!NOTE]
> In case the type has been defined in the protocol, it will not be possible to modify this in DataMiner Cube.

Both for “absolute” and “relative” alarm thresholds, the “normal” value has to be set to a baseline value:

1. In the *Normal* column, click *\[BASELINE\]*.

2. In the Baseline editor, you can choose either a fixed baseline, or a smart baseline:

    - Set a fixed baseline value by entering this value in the table at the top of the editor. For discrete parameters, you will be able to select the value in a drop-down list.

        > [!NOTE]
        > -  With the right-click menu in the baseline editor you can copy or export lines from the table. You can also select one or more lines and then select the options *Use current value as baseline value*, *Set baseline value to current value if the baseline value is not defined* or *Set baseline value to current value if the baseline value is defined*.
        > -  From DataMiner 10.1.9/10.1.0 \[CU8\] onwards, if a baseline value has been defined in a protocol, it can be edited in the baseline editor.

    - Set a smart baseline by selecting *Automatically update the baseline values*.

        > [!NOTE]
        > You can only use a smart baseline if trending has been enabled for the parameter. If it is not, you will receive a warning message, and a warning icon will be shown in the Baseline editor.

3. If you chose a smart baseline, select one of the following options:

    - **To detect a continuous degradation**. This type of baseline is used in order to detect a deviation from a typically stable signal or fixed value. The median value of the average trend points during the selected trend window is calculated and kept for 24 hours. Every 15 minutes, DataMiner will check whether enough time has elapsed that the baseline value can be calculated again.

        Example of continuous degradation of a signal:<br>![](../../images/SmartBaselinesContinuous.png)

    - **To detect a deviation in the expected daily pattern**. This type of baseline is used to detect a deviation from a signal that follows a day/night pattern. In this case, the day/night pattern is checked by calculating the median value per 15 minutes of the trend window. The baselines are calculated every 24 hours at midnight for every 15-minute timeslot of the next day (e.g. 10:00, 10:15, 10:30, …).

        > [!NOTE]
        > If this option is selected, the DataMiner system will calculate the median value of all average trend points in the 15-minute time window equal to the current time window and apply a polynomial regression to these median values from the last x number of days.

        Example of a deviation in the expected daily pattern for a signal:

![](../../images/SmartBaselineDailyPattern.png)



4. Optionally, if you chose a smart baseline:

    - Enter a new value next to *Trend window* to set the trend window to a different number of days.

    - Select *Skip the last ... hours in the configured trend window* and specify a particular interval to exclude the most recent occurrence of this interval in the configured window. By default, this interval is set to 24 hours, but you can change the number of hours as required. You can use this option to avoid that your alarm thresholds degrade along with your signal.

    - If the smart baseline is set to detect a deviation in the expected daily pattern, select *Handle weekend days separately* if you want average values for weekdays not to be taken into account for weekend days and vice versa.

> [!NOTE]
> -  If you want to overrule the dynamic behavior for a certain limit and specify a fixed value instead, in the template editor, select the *Fixed* option for that limit.
> -  If normalization is triggered from the protocol, rather than from the template, up to DataMiner 9.5.1, the baseline editor is disabled. From DataMiner 9.5.1 onwards, baseline values are available as a read-only list.

> [!TIP]
> See also:
> <https://community.dataminer.services/video/ruis-rapid-recap-smart-baseline/>

### Configuring an alarm template to generate information messages

In the *Info* column, select the checkbox and enter a value to define when you want to receive an information message related to the value of a parameter:

- For a discrete parameter, a selection box is available with all possible values for that parameter. Select all values for which you want to receive an information message whenever the parameter gets that value.

- For an analog parameter, you can enter any value, and an information message will be generated each time a parameter value change occurs that crosses this boundary. The information message will indicate the change with *Dropped below* or *Escalated above*.

> [!NOTE]
> It is not required to select the checkbox for alarm triggering to generate these information messages.

### Using conditions in an alarm template

In the *Condition* column, you can add conditions for the alarm triggering of selected parameters. By specifying such a condition, you can ensure that a parameter is not monitored when another parameter of the same element has a specific value or alarm state. From DataMiner 10.2.0/10.1.11 onwards, it is also possible to let the monitoring of a parameter depend on whether the parameter (or another parameter of the same element) affects a service.

> [!NOTE]
> -  When you specify a condition for a parameter in an alarm template, that parameter will only be monitored when the condition is false.
> -  Some protocols specify default conditions, which are automatically filled in. However, it is possible to override these.

When you click in the selection box in the *Condition* column, the following actions are possible:

- Create a new condition as follows:

    1. Select *\<New>*. The window *Add condition to \[template name\]* opens.

    2. Enter a name for the condition next to *Name*.

    3. Click *Select a filter* to create a new filter.

    4. Select the parameter you want to filter on.

    5. Configure the filter:

        1. Select the parameter you want to filter on.

        2. Select the filter type. The default type is *Value*. Clicking *Value* allows you to select an alternative type, i.e. *Severity* or *Service impact*.

        3. Select the operator. The default operator is *Equal to*. Clicking *Equal to* allows you to select an alternative operator, i.e. *Not Equal to*, *Greater than*, or *Less than*.

        4. Specify the value, service impact or severity to filter on.

    6. Optionally, click *Add filter* to create more filters and combine them using logical operators (AND, OR).

    7. When the filters have been defined, click *OK*.

    > [!NOTE]
    > -  Prior to DataMiner 10.0.5, filters can only refer to columns from a different table, if these are linked to the first table via foreign key. <br>For example, in case of two tables Table A and Table B, where the foreign key of Table B is the primary key of Table A, in the alarm template for Table B, you can specify conditional alarm filters using columns from Table A. <br>From DataMiner 10.0.5 onwards, filters can also refer to columns from another table if the tables are not linked.
    > -  From DataMiner 10.0.5 onwards, you can configure a condition on a column parameter based on the value of a cell in the same table or a different table. However, note that this is not supported for view table columns. Note also that if the monitored table and the table used in the condition are the same or are not related, the condition will be applied to all cells in the monitored column, but only when the cell specified in the condition changes. If the two tables are related, the condition will apply to all cells in the monitored column that are linked to the row containing the cell specified in the condition.
    > -  From DataMiner 9.5.13 onwards, if you configure a condition based on the value of a string parameter, it is possible to use the wildcards "\*" and "?".
    > -  From DataMiner 10.0.7 onwards, conditions are supported that check whether a parameter value is equal or not equal to “Not Initialized”, i.e. the value of a parameter that has not yet been set. To configure such a condition, click the *Value* field in the second part of the condition and select *Not initialized*.

- Select an existing condition, if any are available. If necessary, click the pencil icon next to the selected condition to modify it.

- To remove a condition, select *\<No condition>*, or click the *x* next to the condition.

- To add an additional condition for the same parameter, hover the mouse over the condition and click the *+* sign that appears next to it.

    > [!NOTE]
    > If there are multiple alarm template entries for the same parameter, each with a different condition, then the first entry of which the condition is false, starting from the top, will be applied.

> [!TIP]
> See also:
> <https://community.dataminer.services/video/alarm-templates-conditional-monitoring/>

### Configuring anomaly detection alarms for specific parameters

From DataMiner 10.0.3 onwards, you can configure an alarm template so that alarms are generated instead of suggestion events when anomalies are detected for specific parameters.

You can enable or disable this for different types of anomaly detection:

1. Click the cogwheel button in the top-right corner of the alarm template editor.

2. Select the option *Advanced configuration of anomaly detection*. Three extra columns will be displayed in the template editor.

3. Click the toggle buttons in these columns to configure alarms for specific types of anomaly detection:

    - *Trend monitor*: Enables or disables alarms for trend changes.

    - *Variance monitor*: Enables or disables alarms for variance changes.

    - *Level shift*: Enables or disables alarms for level shift anomalies.

> [!NOTE]
> For more information on behavioral anomaly detection, see [Working with behavioral anomaly detection](../trending/Working_with_behavioral_anomaly_detection.md).

### Setting the autoclear options for alarms in an alarm template

For each parameter, it is possible to configure whether alarms will be automatically cleared or not, or if the system default settings will apply.

To do so:

1. Click the cogwheel button in the top-right corner of the alarm template editor.

2. Select the option *Allow override of parameter autoclear*. An extra column will appear in the template editor.

3. In the last column for the parameters where you want to override the autoclear parameter, select *True* or *False*.

    > [!NOTE]
    > By default, the field will be set to *System Default*. This means that the parameter will inherit the AutoClear setting specified in the AlarmSettings.AutoClear tag of the file *C:\\Skyline DataMiner\\MaintenanceSettings.xml*.

> [!TIP]
> See also:
> [Clearing alarms](../alarms/Clearing_alarms.md)

### Scheduling an alarm template

It is possible to schedule an alarm template so that it is only active at certain times. This way, you can for example make sure a particular alarm template is active on weekdays only.

To schedule an alarm template:

1. In the alarm template editor, click *Show details*, and then click the *Configure* button.

2. Select *Template is only active on*.

3. For every day or every separate time span on a day that you want to schedule, do the following:

    1. Click *Add schedule*.

    2. Select a day of the week and enter a time in the format HH:mm in the *begin* and *end* fields.

> [!NOTE]
> -  When scheduling an alarm template, you cannot create overlapping time spans. If, for example, you were to set a time span on Friday from 08:00 to 12:00 and another on Friday from 11:00 to 15:00, a warning message would appear and you would not be able to save the template. In case of this example, one time span should be created instead on Friday from 08:00 to 15:00.
> -  If you select *Template is only active on* without specifying when it should be active, the template will always be disabled.
>
