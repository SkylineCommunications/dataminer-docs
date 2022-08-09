---
uid: General_Feature_Release_10.0.13
---

# General Feature Release 10.0.13

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

## New features

### DMS core functionality

#### SLSNMPAgent will now also use the SNMP++ library to forward SNMPv2 traps and inform messages \[ID_27590\]

From now on, SLSNMPAgent will also use the SNMP++ library to forward SNMPv2 traps and inform messages. This means that it will now use the same library to send SNMPv1 traps, SNMPv2 traps and inform messages and SNMPv3 traps and inform messages.

> [!NOTE]
>
> - Because of limitations of the SNMP++ library, the inform message resend time cannot be set to a value less than 10ms. If you set it to a value less than 10ms, the default setting will be used instead (i.e. 30 ms).
> - From now on, all SNMPv2 traps and inform messages will by default include the “1.3.6.1.2.1.1.3.0” (sysUpTime) and “1.3.6.1.6.3.1.1.4.1.0” (snmpTrapOID) bindings.

#### All client-server communication will now be encrypted by default \[ID_27747\]

From now on, all client-server communication will be encrypted by default.

### DMS Protocols

#### Values displayed using scientific notation will now use a dot as separator \[ID_27690\]

Values set to be displayed using scientific notation will now use a dot instead of a comma as separator.

### DMS Cube

#### DataMiner Cube - Alarm Console - Automatic incident tracking: Timeout and non-timeout alarms will now be grouped \[ID_27299\]\[ID_27877\]

Up to now, when *Automatic incident tracking* was activated, timeout and non-timeout alarms would not be grouped. From now on, those alarms will be grouped with each other.

#### DataMiner Cube will now display more detailed information when you try to connect to a DataMiner Agent that is starting up \[ID_27308\]\[ID_27770\]

When you try to connect to a DataMiner Agent that is starting up or that is being restarted, DataMiner Cube will now display more detailed information regarding the startup process.

Examples of messages that will be displayed:

- Offloaded files are currently being restored to Cassandra
- Starting element X

#### Correlation/Automation/Scheduler: Email report configuration \[ID_27521\]\[ID_27812\]\[ID_27878\] \[ID_28032\] \[ID_28038\]\[ID_28081\]

In an *Email* action of a Correlation rule, an Automation script or a scheduled task, as well as in the *Upload report to FTP* and *Upload report to shared folder* actions in an Automation script, if you add a report based on a dashboard, you can now click a *Configure* button to open an embedded browser window where you can configure the necessary data feed selections as well as the following options:

- *Add DMS info*: Determines whether company details are displayed in the report.
- *Add DMS logo*: Determines whether the company logo is displayed in the report.
- *Include feeds*: Determines whether feed components are included in the report. By default, this option is not enabled.
- *Stack components*: Select this option if you want all components to be displayed below one another. This can be especially useful for dashboards containing large components (e.g. pivot tables) in order to make sure all data is displayed.
- *Dashboard width*: Allows you to select a custom width for the report.

#### Visual Overview: Conditional shape manipulation actions no longer require the shape to be linked to an element, service or view \[ID_27569\]

Up to now, the following conditional shape manipulation actions could only be configured on shapes linked to an element, service or view. From now on, these actions will no longer require the shape to be linked to an element, service or view.

- Show
- Hide
- FlipX
- FlipY
- Enabled

> [!NOTE]
> In case of “Enabled”, the shape in question needs to be clickable.

#### Services and redundancy groups hosted by a disconnected DMA will now also be indicated as being disconnected \[ID_27611\]\[ID_27760\]

Up to now, when a DataMiner Agent disconnected from the DataMiner System, the elements hosted by it were indicated as being disconnected by means of a special icon. From now on, also the services and redundancy groups hosted by it will be indicated as being disconnected by means of a special icon.

#### Visual Overview: Linking the view range of a trend graph component to session variables & specifying a custom view range \[ID_27779\]

A Visio shape showing a trend graph component can now be made to update session variables with its view range (i.e. start time and end time). To do so, add a shape data field of type SetVar, and set its value to “RangeStart:\<VariableA>\|RangeEnd:\<VariableB>”

Example:

| Shape data field | Value                                        |
|------------------|----------------------------------------------|
| SetVar           | RangeStart:MyRangeVar1\|RangeEnd:MyRangeVar1 |

> [!NOTE]
> The values set in the session variables will be datetime text strings formatted according to the current culture.

Also, to have a trend graph component show a custom range, you can now add “Range:Start=\<dateTimeTextA>,End=\<dateTimeTextB>” to a shape data field of type ParametersOptions.

Example:

| Shape data field  | Value                                             |
|-------------------|---------------------------------------------------|
| ParametersOptions | Range:Start=\<dateTimeTextA>,End=\<dateTimeTextB> |

> [!NOTE]
>
> - You do not have to specify two time values. You can specify a start time, an end time or both (separated by a comma).
> - The datetime text strings need to be formatted according to the current or invariant culture.

#### Cube launcher tool: Silent installation, modification and uninstallation of Cube \[ID_27795\]

Using the following command-line arguments, it is now possible to use the Cube launcher tool to silently install, modify and uninstall DataMiner Cube without any user interface.

##### General syntax

```txt
PathToCubeExe.exe <arguments>
```

> [!NOTE]
> All arguments and options are case insensitive.

##### Arguments to install DataMiner Cube

| Argument | Description |
|--|--|
| /Install | Check whether DataMiner is installed, and if not, open the installation wizard. |
| /Install /Silent | Check whether DataMiner is installed, and if not, install DataMiner Cube and exit when done. If no options are specified using an /InstallOptions argument, the default installation options will be used. |
| /InstallOptions | Comma-separated list of additional installation options:<br> - DesktopShortcut (add a desktop shortcut)<br> - NoDesktopShortcut (do not add a desktop shortcut)<br> - StartMenuShortcut (add a start menu shortcut)<br> - NoStartMenuShortcut (do not add a start menu shortcut)<br> - StartOnLogin (start Cube in the system tray after login)<br> - NoStartOnLogin (do not start Cube in the system tray after login)<br> - OpenAfterInstall (open Cube launcher tool after installation)<br> - NoOpenAfterInstall\* (do not open Cube launcher tool after installation)<br> \* Default option for silent installs |

Example of a silent command to install DataMiner Cube when no installation could be found:

```txt
PathToCubeExe.exe /Install /Silent /InstallOptions:StartOnLogin
```

##### Arguments to modify DataMiner Cube after installation

| Argument | Description |
|--|--|
| /Modify | Open the “Modify installation” window. If there is a /ModifyOptions argument, the options specified in that argument will be preselected. |
| /Modify /Silent | Silently modify the DataMiner Cube installation using the options specified in the /ModifyOptions argument. |
| /ModifyOptions | Comma-separated list of modification options:<br> - ClearProtocolCache<br> - ClearVisioCache<br> - ClearVersionCache (remove all cached versions)<br> - RemoveVersion:versionnumber (remove the specified version from the cache) |

Example of a silent command that will clear the protocol cache, clear the Visio cache and remove two versions from the cache:

```txt
PathToCubeExe.exe /Modify /Silent /ModifyOptions:ClearProtocolCache,ClearVisioCache,RemoveVersion:9.5.1638.4080,RemoveVersion:10.0.2042.1636
```

##### Arguments to uninstall DataMiner Cube

| Argument          | Description                        |
|-------------------|------------------------------------|
| /Uninstall        | Open the uninstall window.         |
| /Uninstall/Silent | Silently uninstall DataMiner Cube. |

#### Protocols & Templates: Information template editor now also allows you to configure parameters of type Button and ToggleButton \[ID_27823\]

As to button parameters, up to now, the information template editor only allowed you to configure parameters of type PageButton. From now, it will also be possible to configure parameters of type Button and ToggleButton.

#### DataMiner Cube: Buttons to join and leave cluster renamed \[ID_27863\]

On the *Agents* > *Manage* page in System Center, the *Add cluster* and *Delete cluster* buttons have been renamed to *Join cluster* and *Leave cluster*, respectively.

#### New EPM card settings \[ID_27874\]

In the DataMiner Cube user settings, you can now configure the following EPM card settings:

- Default EPM card page
- How to show EPM card Visual pages

#### Visual Overview: Info keywords can now be used as dynamic placeholders in other shape data fields \[ID_27880\]

All keywords that can be specified in shape data fields of type “Info” can now also be used as dynamic placeholders in shape data fields of other types.

When using one of those keywords in a shape data field of type other that “Info”, make sure to enclose it in square brackets similar to other placeholders.

Example: \[var:\[NAME\]\]

#### Visual Overview: Automation script session variables & OnClosing shape data field \[ID_27895\]

In Visual Overview, it is now possible to pass Automation script output to session variables. Also, you can now use the page-level shape data field OnClosing to configure whether a Visual Overview window should automatically be closed or not.

##### Passing Automation script output to session variables

When an Automation script executed in Visual Overview finishes successfully, it is now possible to pass the output values of that script to session variables in Visual Overview using the new CreateKey(string variablename) method (namespace: Skyline.DataMiner.Automation, class name: UIVariables.VisualOverview).

In the following example, a session variable named “MyOutput” will be created and will receive the value “MyValue”.

```csharp
engine.AddScriptOutput(UIVariables.VisualOverview.CreateKey("MyOutput"), "MyValue");
```

- If you execute the same Automation script on different pages, then you can use the SessionVariablePrefix option to make sure the output is saved in separate session variables.

    If, for example, you use prefix “One\_” on one page and prefix “Two\_” on another page, and the Automation scripts pass their output to a session variable named “MyPage”, then the output will end up in two separate session variables named “One_MyPage” and “Two_MyPage” respectively.

- When you set the SetVarOnFail option to true (either on page level or shape level), then the session variables in question will always be created, regardless of whether the script finishes successfully or not.

##### New “OnClosing” shape data field

From now on, you can use the page-level shape data field OnClosing to configure whether a Visual Overview window should automatically be closed or not.

In a shape data field of type OnClosing, specify a script (example: Script:MyScript), and make sure the script contains an instruction like the following one:

```csharp
engine.AddScriptOutput(UIVariables.VisualOverview.ClosingWindow_Result, ClosingMode.Continue.ToString());
```

The session variable named ClosingWindow_Result can be set to “Continue”, “Stop” or “Abort”. In the example above, it is set to “Continue”.

If ClosingWindow_Result is set to “Stop”, a message box of type “Yes/No” will appear. If the user then clicks “Yes”, the window will be closed.

Note that, in the session variable named ClosingWindow_Message, you can specify a custom message to be displayed. If you specify such a message, then it will be shown in a message box of type “OK”, regardless of the value of the ClosingWindow_Result variable. However, if ClosingWindow_Result is set to “Stop”, then this custom message will be displayed in the message box of type “Yes/No” mentioned above.

> [!NOTE]
>
> - The OnClosing shape data field only works for windows. It does not work for popups or tooltips.
> - The OnClosing and OnClose shape data fields do not influence each other. Both function independently from each other.
> - If you want to combine OnClosing and OnClose, then in Visual Overview, you can pass session variable X to the OnClosing script and make it return session variable Y. That variable can then be passed to the OnClose script, which can optionally be made to return session variable Z.

#### Visual Overview: New AutoIgnoreExternalChanges option when embedding a Service Manager component \[ID_27899\]

Up to now, when embedding a Service Manager component in Visual Overview, you could specify the AutoLoadExternalChanges option if you wanted external changes to be loaded automatically when there were no local changes. From now on, you can also specify the AutoIgnoreExternalChanges option if you want external changes to be discarded automatically.

Both options will keep the information bar from being displayed at the bottom of the Visual Overview, asking the user to load or discard the external changes.

> [!NOTE]
> If you specify both options, then AutoLoadExternalChanges will take precedence over AutoIgnoreExternalChanges:
>
> - As long as there are no (unsaved) client-side changes, external changes will be loaded automatically.
> - As soon as there are (unsaved) client-side changes, external changes will be discarded.

#### Trending - Pattern matching: New options when adding or editing a tag \[ID_27954\]

When adding or editing a tag, you can now select the following additional options:

| Option                       | Description                                                                                                  |
|------------------------------|--------------------------------------------------------------------------------------------------------------|
| '\<instanceName>' only       | Select this option if you want the tag to only match one specific display key and parameter.                 |
| Generate alarm when detected | Select this option if you want suggestion events to be generated when a match is detected in the trend data. |

> [!NOTE]
> When you save a tag after selecting the *Generate alarm when detected* option, a message box may appear, saying that suggestion events cannot be generated for that tag. This is due to the range of the tag being too large. The tag itself will be saved and detected.

#### Trending: Trend percentile will now be calculated using either average or real-time trend data \[ID_27965\]

Up to now, the trend percentile was calculated using the most detailed data set that was available. In cases where the trend window contained both real-time and average trend data, it would be calculated using both types of data.

From now on, from the moment the trend window contains average data points in its most detailed set, only average data will be used for the calculation. This is also be reflected in the percentile menu, where a warning icon will be shown. A tool tip on the warning icon will indicate when only average data will be used.

#### Cube launcher tool: Aliases \[ID_27975\]\[ID_27999\]

When defining a DataMiner Agent in the Cube launcher tool, apart from the host name or IP address, you can now also specify an alias.

By default, the alias will be identical to the cluster name. If you specify a custom alias, it will replace the cluster name in the Cube header.

Command-line arguments: /Alias=Xyz /Host=hostname

> [!NOTE]
> Always use the /Alias argument in conjunction with the /Host argument.
>
> The alias will be used as long as the client is connected to the host specified in the Host argument.

#### System Center: Enhanced Database section \[ID_27976\]

The *Database* section of *System Center* now has three main tab pages.

- In the *General* tab page, you can select “Database per agent” or “Database per cluster”.

  - When you select “Database per agent”, you can configure the local databases per agent.
  - When you select “Database per cluster”, you can configure a Cassandra cluster acting as a shared local database.

- In the *Offload* tab page, you can configure the data offloads to a central database.
- In the *Other* tab page, you can configure an additional database.

#### Trending: Real-time pattern matching \[ID_28054\]

Up to now, pattern matching happened on the fly when a trend graph was opened. Now, apart from this so-called static pattern matching, DataMiner is also able to perform real-time pattern matching and generate an alarm as soon as a pattern is detected.

When you create a pattern in DataMiner Cube, you can now select the following new options:

- When you select the *Generate an alarm when detected* option, DataMiner will track the pattern in real time and trigger a suggestion event each time it detects the pattern.

  When you do not select this option, DataMiner will behave as before and use static pattern matching instead.

- When specifying the parameter, in case of a table parameter, you can now also add the display key.

> [!NOTE]
> This option is not linked to the type of pattern matching that is being used (static or real-time).

##### Limitations

- If you tag a pattern for a parameter of which the polling time is specified in the protocol, then the pattern must have less than 5000 real-time points. If the polling time is not specified in the protocol, then the pattern must be shorter than 24 hours. When you select a longer pattern, DataMiner Cube will display a warning and revert to static pattern matching for that specific pattern.

- For real-time pattern matching, DataMiner will only use a maximum of 2 GB of internal memory.

  - As soon as DataMiner uses more than 1.5 GB of internal memory for real-time pattern matching, the following notice will appear in the Alarm Console:

    `Pattern matching memory high, adding more patterns or parameters might reduce matching accuracy.`

    This notice will appear at most every 2 weeks or after a DataMiner restart.

    In order to reduce memory usage, users can either remove patterns that are being tracked in real time or restrict the number of parameters for which patterns are being tracked in real time (e.g. by specifying a display key in case of table parameters).

  - As soon as DataMiner uses more than 2 GB of internal memory for real-time pattern matching, the following notice will appear in the Alarm Console:

    `Pattern matching memory critical, patterns with suggestion events enabled may not match properly.`

    This notice will appear at most every 2 weeks or after a DataMiner restart.

    Also, when users create a pattern, DataMiner will now always revert to static pattern matching, even if they selected the *Generate an alarm when detected* option.

  - DataMiner checks all changes made to parameters for which patterns are being tracked in real time. If there are more than 6000 parameter changes per second, the following notice will appear in the Alarm Console:

    `High load on pattern matching functionality: reduced pattern match accuracy.`

##### Suggestion events

In case of real-time pattern matching, pattern occurrences are communicated to the user by means of suggestion events in the Alarm Console, i.e. alarms with severity “Information” and source “Suggestion Engine”. These events can be displayed in a separate *Suggestion events* alarm tab.

### DMS Reports & Dashboards

#### Dashboards app: Generic Query Interface \[ID_24048\]\[ID_24548\]\[ID_25898\]\[ID_25921\]\[ID_26050\] \[ID_26153\]\[ID_26448\]\[ID_26477\]\[ID_26793\]\[ID_27616\]\[ID_27678\]\[ID_27949\]\[ID_27987\]\[ID_28010\] \[ID_28071\]

The Generic Query Interface allows you to efficiently tap into the wealth of data available in your DataMiner System. In this release, the interface is available via the *Queries* data input for Bar chart and State visualizations, as well as in the new Table and Pie Chart visualizations, which were especially created for this feature. In future releases, additional functionality using the Generic Query Interface will become available. Note that this feature is only available if DataMiner uses a Cassandra database. For some queries, an Elasticsearch database is also required.

##### Using the Queries data input

You can construct a query to use as data input for a component by following these steps:

1. In edit mode, select the dashboard component for which you want to use a query as a data input. At present, this is support for Bar chart, State and Table components.

1. In the data pane, select *Queries* and click the + icon to add a new query.

1. Specify a name for the query.

1. In the drop-down box below this, select the data source you want to use. At present, the following options are available:

    - *Get elements*: The elements in the DataMiner System.
    - *Get parameter table by alias*: The parameter table using the specified alias in the Elasticsearch database.
    - *Get parameter table by ID*: The selected parameter table from the element with the specified DataMiner ID and element ID.
    - *Get parameters for element where*: The selected parameters for the specified protocol or the parameters linked to the specified profile definition. Note that if parameters are displayed based on a specific protocol, it is not possible to combine a table parameter with other parameters, and only column parameters from the same table can be displayed in the same query.
    - *Get services*: The services in the DataMiner System.

1. Select an operator. This step is optional; if you do not select an operator, the entire data set will be used. The following operators are available:

    - *Aggregate*: Allows you to aggregate data from the data source. After you have selected this option, first select the aggregation column, and the method that should be used. Depending on the type of data available in the selected column, different methods are available, e.g. Average, Count, Distinct Count, Maximum, Median, Minimum, Percentile 90/95/98 or Standard deviation.

        You can then further filter the result by applying another operator. An additional *Group by* operator is available for this, which will display the result of the aggregation operation for each different item in the column selected in the *Group by column* box.

    - *Column manipulations*: Creates a new column based on existing columns. When you select this option, you also need to select a manipulation method.

        If you choose the *Concatenate* method, you will need to select several columns and then specify the format that should be used to concatenate the content of those columns, using placeholders in the format {0}, {1}, etc. to refer to those columns.

        If you choose the *Regexmatch* method, you will need to select a column and specify a regular expression, so that the new column will only contain the items from the selected column that match the regular expression.

        For both manipulation methods, you will also need to specify the name for the new column. When the column manipulation operation is fully configured, you can further fine-tune the result by applying another operator.

    - *Filter*: Filters the data set. When you select this option, select the column to filter, specify the filter method (e.g. equals, greater than, etc.) and the value to use as a filter. The available filter methods depend on the type of data in the selected column. Once the filter has been fully configured, you can refine the results by applying another operator, e.g. an additional filter.

    - *Join*: Joins two tables together. When you select this option, in the *Type* drop-down box, you will first need to select how the tables should be joined. Then you will need to select another data source (optionally refined with one or more operators) in order to specify the table you want the first table to be joined with. Optionally, you can also specify a condition to determine when rows should be joined. For instance, if one table contains elements with a custom property that details a booking ID and the other lists bookings, you could add the condition that the property in the first table must match the ID in the second table.

        The *Inner* type of join only includes rows if they match the condition. *Left* displays all rows from the first table (i.e. the table on the left) and only the matching rows from the other table. *Right* does the opposite. *Outer* displays first the non-matching rows from the left table, then the matching rows from both tables, then the non-matching rows from the right table.

    - *Select*: Displays the selected columns only. When you have selected the columns to display, you can apply another operator to refine the query.

    - *Top X*: Displays the top or bottom items of a specific column, with X being the number of items to display. When you select this option, you will need to specify the column from which items should be displayed and the number of items that should be displayed. By default, the top items are displayed. To display the bottom items instead, select the *Ascending* checkbox.

1. Drag the configured query to the component in order to use it.

> [!NOTE]
>
> - It is possible to refer to a query in the dashboard URL, using the following format: *?queries=\[***alias***\]\\x1F\[***queryJsonString***\] <br>*In this format, \[alias\] is the name of the query and \[queryJsonString\] is the query in the format of a JSON string, for example: <br>*?queries=Get Elements/{"ID": "Elements"}*.
> - When a query has been created, the columns from the table that results from the query are available as individual data items in the data pane, so that you can use them to filter or group a component.
> - It is not possible to retrieve data from a stopped element.

##### Table visualization

This new visualization was especially designed to be able to display the results of queries in a table format. It only supports query data input. It displays the different data sources as follows:

- Elements are represented with a row for each element, with each column detailing different information for that element.
- Services are displayed in the same way as elements.
- Table parameters are displayed as they are, as determined by the applied operators.
- If parameters are retrieved by protocol or profile definition, each row will represent a matching element, and for each parameter a column will show the corresponding values.

You can resize the columns of the table by dragging the column edges. Clicking on a column header will sort the table by that column. To toggle between ascending and descending order, click the column header again. To sort by multiple columns, keep the Ctrl key pressed while clicking the column headers. The first column will then be used for the initial sorting, the next one to sort equal values of the first column, and so on.

In the *Layout* tab for this component, the *Column filters* option is available, which allows you to highlight cells based on a condition. To do so, select the parameter you want to use for highlighting, indicate a range to be highlighted, select the range and then click the color icon on the right to specify a highlight color. Multiple ranges can be indicated for one parameter, each with a color of its own.

##### Pie Chart visualization

This new visualization was designed to display the results of queries in a chart shaped like a pie or donut. It only supports query data input.

The following layout options are available for this visualization:

- *Chart shape*: Can be set to *Pie* or *Donut*.

- *Legend*: The legend can be hidden. If it is set to be displayed, you can select whether it should be displayed on the left, on the right, at the top or at the bottom of the visualization.

- *Tooltips*: Tooltips can be hidden. If they are set to be displayed, you can select whether these should include the label, dimension, value and/or percentage.

In addition, the following settings are available for this visualization:

- *Label*: Allows you to select which data should be used as a label.

- *Segment size*: Allows you to select which data should determine the size of segments in the chart.

##### Bar chart visualization changes

A number of changes have been implement to the bar chart visualization, in order to optimize this visualization to display queries.

If the visualization displays a query, in the *Settings* tab, the following options are available instead of the usual options for a bar chart:

- *Label*: Allows you to select which data should be used as a label.
- *Bars*: Allows you to select which data should determine the size of bars.

In addition, the following layout options can now be configured for this visualization:

- *Chart layout*: Can be set to *Relative* or *Absolute*. *Relative* means that the dimension of each bar is shown as a relative percentage. *Absolute* means that the dimension of each bar is shown as an absolute numeric value.
- *Chart orientation*: Determines how the chart is displayed, i.e. from left to right, from right to left, from top to bottom or from bottom to top.
- *Legend*: The legend can be hidden. If it is set to be displayed, you can select whether it should be displayed on the left, on the right, at the top or at the bottom of the visualization.
- *Tooltips*: Tooltips can be hidden. If they are set to be displayed, you can select whether these should include the label, dimension and/or value.

#### Dashboards app: Selecting an empty folder will now cause a “Create dashboard” button and a “Import dashboard” button to appear \[ID_27579\]\[ID_27844\]

When, in the sidebar of the Dashboards app, you select an empty folder, two large buttons will now appear in the large pane on the right.

| Click...         | to...                                                           |
|------------------|-----------------------------------------------------------------|
| Create dashboard | create a new dashboard from scratch in the folder you selected. |
| Import dashboard | import an example dashboard in the folder you selected.         |

> [!NOTE]
> The two above-mentioned options will also be available in the context menu when you right-click a folder in the navigation pane.

#### Dashboards app: Default themes updated \[ID_27636\]

In the Dashboards app, the default themes have all been updated.

#### Dashboards app - Line chart component: Value range \[ID_27774\]

When configuring a line chart component, you can now specify a value range for the trend graph by entering a minimum limit and/or a maximum limit.

The value range you specify will apply to all trend lines displayed on the graph.

#### Dashboards app - Line chart component: Show minimum, maximum and/or average trend lines \[ID_27815\]

When configuring a line chart component that does not show real-time trend data, you can now make the trend graph show a minimum, a maximum and/or an average trend line by switching on the following options:

- Show average (default setting: switched on)
- Show minimum (default setting: switched off)
- Show maximum (default setting: switched off)

#### Dashboards app - Parameter feed: “Auto-select all” option \[ID_27816\]\[ID_28033\]

When configuring the Parameter feed, up to now, it was possible to either have a specific number of indices selected automatically or have all indices selected automatically.

- Auto-select number of indices
- Auto-select all indices

Now, the above-mentioned options have been replaced by the “Auto-select all” option. When this option is selected, all items will be selected according to the "Select all behavior" settings below it:

- If you select the “Select all items” option, "Select all" will select all items. For a partial table, only the items from the first page will be selected.
- If you select the “Select specific number of items” option, a box is displayed below it. In this box, you should specify how many items "Select all" should select. For a partial table, these items will be selected across different pages.

#### Dashboards app - Line chart component: New “Chart limit behavior” setting \[ID_27841\]

When configuring a line chart component, you can now use the *Chart limit behavior* setting to indicate what needs to happen when the number of parameters in the chart exceeds the defined chart limit:

| Option | Behavior |
|--|--|
| Disable parameters in legend | The excess parameters are disabled in the chart but remain available in the chart legend, so that they can be enabled again manually. This option is selected by default. |
| Create additional charts | Additional charts are displayed that include the parameters that exceed the limit. If necessary, multiple additional charts will be displayed, each respecting the configured limit. |

#### Dashboards app - Pivot table component: Sort ascending/descending \[ID_27862\]

When configuring a pivot table component, you can now find the following settings in the Sort section of the Settings tab:

| Setting | Description |
|--|--|
| Sort | Allows you to select a protocol (if the pivot table contains multiple protocols) and a parameter by which the table should be sorted. |
| Sort ascending | Determines the order in which the pivot table is sorted. If you clear this checkbox, it is sorted in descending order. |

> [!NOTE]
> Using these sort settings in conjunction with the *Limit* setting in the *Configure indices* section, you can produce a top X or bottom X list.

### DMS Automation

#### Interactive Automation scripts: Tree view items now have an IsCollapsed property \[ID_27756\]

When, in an interactive Automation script, you define a tree view control (i.e. a UIBlockDefinition of type TreeView), you can now use the TreeViewItem property *IsCollapsed* to indicate whether an item should be collapsed or expanded.

> [!NOTE]
> This property will not be updated when you collapse or expand tree view items in the UI.

### DMS Web Services

#### Web Service API v1: New GetDataMinerClusterName method \[ID_27951\]

The GetDataMinerClusterName method can now be used to retrieve the name of the DataMiner System a DMA is part of.

### DMS Mobile apps

#### Ticketing app: Move to Elasticsearch database and other improvements \[ID_24667\]\[ID_25539\] \[ID_25713\]\[ID_26644\]\[ID_26676\]\[ID_26677\]\[ID_26911\]\[ID_26982\]\[ID_27974\]\[ID_28016\]\[ID_28043\] \[ID_28079\]\[ID_28153\]

Multiple changes and improvements have been implemented to the Ticketing app. The most important change is that the app will now use the Elasticsearch database instead of the Cassandra database.

When you install DataMiner 10.0.13 and you already use an Elasticsearch database, all ticketing data will be migrated automatically. If you do not have an Elasticsearch database and you have installed DataMiner 10.0.13, the ticketing data will be migrated automatically as soon as you add an Elasticsearch database to you DataMiner System. However, until you do so, you will no longer be able to use the Ticketing app. A run-time error in the Alarm Console will indicate that Ticketing Manager could not be initialized because there is no Elasticsearch database.

When you interact with the Ticketing Manager in scripts, keep the following changes in mind:

- A ticket now has a *UID* property of type GUID, which is always unique and which replaces the *TicketID* object. This object was used with the Cassandra database and consisted of a DataMiner ID and ticket ID. However, in Elasticsearch, the DataMiner ID is no longer needed. While tickets will still have a unique ticket ID, new implementations should make use of the *UID* instead.

- A new *TicketingHelper* is available that should be used to read, create, update and delete tickets, ticket field resolvers and ticket history in scripts. The existing *TicketingGatewayHelper* remains backwards compatible, but should not be used for new implementations or to update existing code. Below you can find an example of how to use this helper:

    ```csharp
    public void Run(Engine engine)
    {
        // Create the helper
        var helper = new TicketingHelper(engine.SendSLNetMessages);

        // helper.[OBJECT TYPE].[ACTION]
        // helper.Tickets.Update();
        // helper.TicketFieldResolvers.Delete();
        // helper.TicketHistories.Read();

        // Create a TicketFieldResolver
        var ticketFieldResolver = TicketFieldResolver.Factory.CreateDefaultResolver();
        var createdResolver = helper.TicketFieldResolvers.Create(ticketFieldResolver);

        // Create a Ticket
        var newTicket = new Ticket()
        {
            CustomFieldResolverID =  createdResolver.ID
        };
        var createdTicket = helper.Tickets.Create(newTicket);

        // Read the TicketHistory
        var historyFilter = TicketHistoryExposers.UniqueID.Equal(createdTicket.UID);
        var history = helper.TicketHistories.Read(historyFilter);

        // Read all Tickets linked to a TicketFieldResolver
        var ticketFilter = TicketingExposers.ResolverID.Equal(createdTicket.CustomFieldResolverID);
        var tickets = helper.Tickets.Read(ticketFilter);

        // Delete Tickets
        foreach (var ticket in tickets)
        {
            helper.Tickets.Delete(ticket);
        }

        // Check if the last Ticket request failed
        var traceData = helper.Tickets.GetTraceDataLastCall();
        if (!traceData.HasSucceeded())
        {
            engine.GenerateInformation($"Previous action failed! {traceData}");
        }
    }
    ```

- To check if a request was successful, you can now retrieve the *TraceData* using the *GetTraceDataLastCall()* method on the *CrudComponentHelper* type used for the request. This returns the TraceData object, which can contain TicketingManagerError objects, each containing a reason for the error and extra data on what caused it. These are the possible errors:

  - *TicketFieldResolverInUseByTickets*: The ticket field resolver still has tickets linked to it. (The property *RelatedTickets* contains the IDs of the tickets.)

  - *NotInitialized*: The Ticketing Manager is not initialized.

  - *LegacyError*: A legacy error has occurred. (The property *LegacyErrorMessage* contains the error message.)

  - *TicketLinkedToNonExistingTicketFieldResolver*: The created/updated ticket has a link to a ticket field resolver that does not exist. (The property *TicketFieldResolverId* contains the ID of that ticket field resolver.)

  - *TicketFieldResolverIsUnknownOrNotMasked*: The ticket field resolver is unknown or not masked.

  - *UnexpectedException*: An unexpected exception occurred. (The property *Exception* contains the exception.)

  - *TicketLinkedToMaskedTicketFieldResolver*: The created/updated ticket has a link to a ticket field resolver that is masked. (The property *TicketFieldResolverId* contains the ID of that ticket field resolver.

  Calling *ToString()* on the *TraceData* object will return a formatted string that shows all errors and associated data.

- When paging is started using *TicketingGatewayHelper.NewPagingRequest()*, the out parameter will no longer return the total number of tickets.

- When an invalid page size or page number is used in a request, an empty list will now be returned, while previously the ticketing helper returned all tickets matching the filter.

- Subscribing to *TicketingGatewayEventMessage* will no longer return an initial bulk. Instead tickets and ticket field resolvers should be retrieved via paging with the new *TicketingHelper*.

- Previously, when the Cassandra database was used, all open tickets were stored in the cache as well as the database. It was therefore possible to use the *CacheOnly* boolean in requests to retrieve only open tickets. This cache is no longer used, so using the *CacheOnly* boolean will no longer work when you use *NewPagedTicketsWithFilterMessage*. To resolve this, concatenate the filter with an open tickets filter, which you can retrieve using the new method *GetTicketStateFilter(TicketState ticketState)*. An exception was made for the *GetTickets* method of the existing *TicketingGatewayHelper*, which will still only return the open tickets.

- "Null" values of ticket fields will no longer be saved or returned.

- The open state of a ticket can no longer be linked to the state of an alarm.

- If *GenericEnumEntry\<int>* is used in *VisualData* on a *TicketFieldResolver*, this will now always be returned as a long integer instead of an integer.

- If the ticket field resolver defines a state *TicketFieldDescriptor*, tickets must now always contain a field indicating their state. When tickets are initially migrated to Elasticsearch, a state will automatically be defined for any tickets where this was not yet the case.

The following changes have been implemented in the web services API v1:

- The *DMATicket*, *DMATicketSelection* and *DMATicketUpdate* objects have a new *UID* property which contains the new GUID identifier of a ticket.

- The *PageSessionID* and *TotalTicketsCount* properties of the *DMATicketsPage* object are now obsolete.

- The *DMATicketsPage* object now has a new *HasNextPage* property, which indicates if there is another page after the currently requested page.

- The new methods *GetTicketV2*, *RemoveTicketV2*, *GetActiveTicketsV2* and *GetHistoryTicketsV2* are now available, to be used instead of *GetTicket*, *RemoveTicket*, *GetActiveTickets* and *GetHistoryTickets*.

Finally, the following changes have also been implemented:

- To include tickets in a custom backup, the backup option *Create a backup of the database* > *Include Ticketing in backup* must be selected.

- When you embed the Ticketing app in another page, you can now add *embed=true* to its URL in order to hide the side bar and header bar of the app.

- You can now add a filter in the Ticketing URL to only show tickets affecting a specific element, service, view or redundancy groups. To do so, add a filter in the following format: *affecting=**\[type\]**/**\[DataMiner ID\]**/**\[object ID\]*, where \[type\] can be *element*, *service*, *view* or *redundancy group*. For example: *affecting=element/299/31*

- When you view or edit a ticket in the app, the URL has now changed; while previously, it contained the DMA ID and ticket ID, it now contains the ticket UID. If you use an old URL, the Ticketing app will automatically try to adjust this to the new URL.

- The default page size for the ticket list in the Ticketing app has been increased to 50.

- Instead of AngularJS, the Ticketing app now uses Angular.

- The log file SLTicketingGateway.txt has now been replaced by SLTicketingManager.txt.

> [!NOTE]
> The Ticketing Gateway entry in the Cube Logging app now refers to the new file.

#### HTML5 apps: Loading indicator of selection boxes will now be displayed on the right \[ID_27871\]

When values are being loaded into a selection box, from now on, the loading indicator will be displayed on the right instead of on the left.

### DMS Service & Resource Management

#### Binding between a VirtualFunctionResource and a physical device element will now automatically be updated when the protocol of the device element changes \[ID_27466\]

When a virtual function resource is bound to a physical device element, that binding will now automatically be updated when the protocol of the physical device element changes.

- When the updated protocol of the physical device element is no longer supported by the VirtualFunctionDefinition of the resource, the resource will automatically become unbound and a notice will be generated for all such resources, stating that the new protocol no longer supports the binding.

- When the updated protocol of the physical device element is still supported by the VirtualFunctionDefinition but now uses an entry point table, the resource will be unbound as the row in the entry point table that needs to be bound to is unknown.

- When the updated protocol of the physical device element is still supported but no longer uses an entry point table, the resource will be unbound as the protocol used to support multiple resources binding and now only supports one resource binding.

- When the protocol of the physical device element is changed to a different protocol, which is also supported by the VirtualFunctionDefinition used by the resource and which uses the same binding method (entry point table or not), the resource binding will automatically be updated.

### DMS tools

#### StandaloneElasticBackup tool \[ID_27683\]

The StandaloneElasticBackup.exe tool allows you to back up and restore Elasticsearch database clusters.

##### General syntax

```txt
StandaloneElasticBackup.exe <action> <arguments>
```

##### Actions

This tool allows you to perform the following actions:

| Action  | Description                |
|---------|----------------------------|
| init    | Initialize a repository.   |
| backup  | Take a backup/snapshot.    |
| restore | Restore a backup/snapshot. |

Example:

```txt
StandaloneElasticBackup.exe backup --host 127.0.0.1 -u elastic --pw mypw123 -r reponame
```

##### General arguments

- `--host` or `-h`: The host on which the command has to be run. Default: 127.0.0.1.
- `--port` or `-p`: The port on which Elasticsearch will be contacted. Default: 9200.
- `--username` or `-u`: The username that has to used to connect to Elasticsearch. Only use this option when credentials have to be used.
- `--pw`: The password that has to used to connect to Elasticsearch. Only use this option when credentials have to be used.

##### Arguments to add when you want to initialize the repository

Run StandaloneElasticBackup.exe with the following two (mandatory) arguments to initialize the repository that should be made to take a snapshot.

- `--repo` or `-r`: The name of the repository to be created.
- `--path`: The path of the repository as defined in the yaml.xml file of the Elasticsearch cluster, enclosed by “”. This is the location where the snapshot will be placed.

> [!NOTE]
>
> - Snapshots are incremental. Do not delete any of them.
> - See also: <https://www.elastic.co/guide/en/elasticsearch/reference/current/snapshots-register-repository.html>

##### Arguments to add when you want to take a backup/snapshot

Run StandaloneElasticBackup.exe with the following two (mandatory) arguments to take a backup/snapshot.

- `--repo` or `-r`: The repository in which to take the backup.

  - If none is defined and only one repository is found in the Elasticsearch cluster, then that one will be used.
  - If none is defined and none can be found, then no backup will be taken.

- `--snapshotname` or `-n`: The (lowercase) name of the snapshot to be taken. Default: DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"); |

##### Arguments to add when you want to restore a backup/snapshot

Run StandaloneElasticBackup.exe with the following two (mandatory) arguments to restore a backup/snapshot.

- `--repo` or `-r`: The repository containing the backup to be restored.

  - If none is defined and only one repository is found in the Elasticsearch cluster, then that one will be used.
  - If none is defined and none can be found, then an error will be thrown.

- `--snapshotname` or `-n`: The name of the snapshot to be restored.

> [!NOTE]
>
> - If, before restoring a backup, you notice that all data was deleted from the database, then re-initialize the repository.
> - It is advised to disable security when restoring a backup with security enabled. To do so, comment the security setting in the yaml file.

## Changes

### Enhancements

#### Dashboards app: Right-clicking a component now only shows “Copy embed URL” in edit mode \[ID_27629\]

Previously, when a dashboard component was right-clicked, this always showed the option *Copy embed URL*. However, as this option is not as useful for a dashboard operator as the default right-click menu, it will now only be displayed when the component is right-clicked in edit mode. Otherwise, the default right-click menu will be displayed.

#### DataMiner Cube - Services app: Enhanced retrieval of service information \[ID_27647\]

In the Services app, all SRM service information will now be retrieved page by page.

#### StandAloneBpaExecutor now supports asynchronous execution of BPA tests across a DMS \[ID_27652\]

The StandAloneBpaExecutor tool now supports asynchronous execution of one or more BPA tests across a DataMiner System.

#### BPA test metadata now indicates whether a test contains corrective actions \[ID_27704\]

The metadata of a BPA test now includes a HasCorrectiveActions property.

If a BPA test contains corrective actions, this property will be set to true.

#### Enhanced performance when processing alarm template actions \[ID_27706\]

Due to a number of enhancements, overall performance has increased when processing alarm template actions.

#### DataMiner Cube - Resources app: A popup message will now be displayed when trying to configure resources on a system with an SRM license but no Indexing Engine \[ID_27737\]

When, on a system with an SRM license but no Indexing Engine, you try to configure resources, from now on, DataMiner Cube will show a message, saying that this is not possible.

#### BPA test framework: New flag to indicate whether a test can be run against an offline agent in a Failover setup \[ID_27762\]

When you create a BPA test, you can now use the BpaFlags.CanRunOnOfflineAgents flag to indicate whether the test can be run against an offline agent in a Failover setup.

Default: False

#### Long running actions will now be canceled when a DataMiner upgrade finishes \[ID_27765\]

When a DataMiner upgrade finishes (successful or not), from now on, all remaining long running actions will be canceled.

#### Client applications now also get notified when cell alarm levels in the source data tables of direct views change due to updates that do not change the cell value \[ID_27785\]

From now on, client applications displaying direct views will also be notified when cell alarm levels in the source data tables change due to updates that do not change the cell value. (e.g. when a cell in a source table gets masked).

#### Live Sharing Service: Enhanced error handling \[ID_27791\]

A number of enhancements have been made to the overall error handling in the Live Sharing Service.

#### DataMiner Cube: Enhanced consistency of trend graph legends \[ID_27831\]

From now on, when multiple trend graphs show similar data, they will all have a similar legend.

#### DataMiner Cube: Virtual functions now in separate section in Protocols & Templates app + made unavailable for regular element creation \[ID_27832\]

Virtual functions are now displayed in a separate *Virtual Functions* section in the Protocols & Templates app. In addition, when you create an element, virtual functions are not listed among the protocols you can choose for the element.

#### DataMiner Cube: Enhanced performance when connecting to a DMA with a large amount of alarms \[ID_27837\]

Due to a number of enhancements, overall performance has increased when connecting to a DataMiner Agent with a large amount of alarms.

#### Interactive Automation scripts: No longer possible to clear the value of a selection box control \[ID_27845\]

Up to now, in an interactive Automation script, it was possible to clear the value of a selection box control by clicking an X button. From now on, this is no longer possible.

#### DataMiner Cube: Enhanced performance when logging in and logging out \[ID_27851\]

Due to a number of enhancements, overall performance has increased when logging in and logging out, especially on large systems.

#### Interactive Automation scripts: Multi-line text boxes will no longer expand when selected \[ID_27858\]

Up to now, a multi-line text box (i.e. a UIBlock of type TextBox with IsMultiline set to true) would by default have a height of 1 line and would expand when it was selected. From now on, its initial height will be fixed. It will no longer expand when selected.

#### Failover: More information will now be returned after synchronizing the two agents \[ID_27870\]

After synchronizing the two agents in a Failover setup, from now on, more detailed information about the synchronization process will be returned.

#### DataMiner Cube - Data Display: Background color of tree control table tabs has been adapted in order to enhance readability \[ID_27881\]

In the Skyline Black theme, the background color of tree control table tabs has been adapted in order to enhance readability.

#### SLPort now automatically resizes the socket buffer before receiving data from a socket \[ID_27891\]

From now on, the SLPort process will automatically resize the socket buffer before receiving data from a socket.

#### DataMiner Cube - Settings: No longer possible to set Connection type to “Web services” \[ID_27904\]

Since Web Services Enhancements (WSE) for Microsoft .NET has been deprecated, the only way for DataMiner Cube to connect to a DataMiner Agent is by using .NET Remoting. As a result, in the *Settings* window, it is no longer possible to set the *Computer \> Connection \> Connection type* setting to “Web services”.

#### Service & Resource Management: Deleting resources only allowed when all DMAs in the DMS are reachable \[ID_27921\]

From now on, you will only be allowed to delete resources when all agents in the DMS are reachable. This will prevent deleted resources from re-appearing when a DMA is started up again.

When you try to delete a resource, an error will now be returned in the following circumstances:

- When at least one agent is disconnected from the agent that hosts the resource you are trying to delete.
- When at least one agent is not in a running state.
- When there is at least one agent on which the ResourceManager module is not initialized.

#### DataMiner Jobs: new ResourceFieldDescriptor field \[ID_27922\]

A new *ResourceFieldDescriptor* field is now available for DataMiner jobs. This field requires a GUID value, which should be the GUID of a resource. It also has a *ResourcePoolIds* property which can be used to filter resources based on resource pools. This feature is intended to support the upcoming PLM app.

#### Performance enhancement: An element card page containing a direct view table will only show the alarm severity of that table when the page is opened \[ID_27928\]

When you open an element card, pages containing direct view tables will no longer show the alarm severity of those tables. Only when you open a page containing a direct view table will the alarm severity of that table be calculated and displayed.

#### DataMiner Jobs: New DefaultValue property of FieldDescriptor class \[ID_27934\]

The *FieldDescriptor* class for DataMiner jobs now has a new *DefaultValue* property, so that it is now possible to add a default field value to each FieldDescriptor. This feature is intended to support the upcoming PLM app.

#### DataMiner Cube: Enhanced performance when opening the Reports page of a view card \[ID_27937\]

Due to a number of enhancements, overall performance has increased when opening the Reports page of a view card, especially when that page shows a large amount of elements with heatlines (e.g. the root view).

#### Service & Resource Management: ResourcesNotMatchWithServiceDefinition check removed \[ID_27938\]

The ResourcesNotMatchWithServiceDefinition check has been removed.

As a result, an error will no longer be returned when saving a ServiceReservationInstance where the booked resources do not match the functions or virtual functions required by the ServiceDefinition.

#### Service & Resource Management: New VirtualFunctionID property added to NodeDefinition class \[ID_27953\]

A new *VirtualFunctionID* property is now available for *NodeDefinition* objects for service profiles.

When a service profile definition is created, DataMiner will check if the virtual function ID exists. If it does not exist, a new error reason *InvalidVirtualFunctionDefinitions* will be added in the trace data. The property *InvalidVirtualFunctionIDs* of the trace data will be filled in with the non-existing virtual function IDs. The property *ServiceProfileDefinition* of the trace data will allow you to identify which service profile definition has an error.

Note that this property can currently not yet be configured in DataMiner Cube.

#### Ticketing app: Enhanced “Edit ticket field” window \[ID_27962\]

Due to a number of enhancements to the *Edit ticket field* window, especially the section that allows you to define the possible values, configuring a ticket state field has been made more intuitive.

#### DataMiner Cube - System Center: Refresh button in Logging section \[ID_27986\]

In the Logging section of System Center, you can now click Refresh to reload the log entries.

#### BPA test framework: Abstraction layer added to allow backward compatibility of BPA tests \[ID_27988\]

An abstraction layer has now been added to the BPA test framework. This will prevent older tests from being rendered incompatible when changes are made to the framework.

#### SLNet.exe.config: TcpWebServicePort key will now be ignored \[ID_27990\]

As Web Services Enhancements (WSE) for Microsoft .NET has been deprecated, in the appSettings section of the SLNet.exe.config file, the TcpWebServicePort key will now be ignored.

#### BPA tests can now be assigned a maximum DataMiner version \[ID_27997\]

When creating a BPA test, it is now possible to indicate the most recent DataMiner version on which the test will work.

When a DataMiner Agent is upgraded to a version equal to or above the one specified in the MaxVersion setting of a test, that test will no longer be executed. Also, you will not be able to upload a BPA test to a DataMiner Agent with a version equal to or above the one specified in the MaxVersion setting.

#### Dashboards app - Parameter feed: “partial table” renamed to “paged table” \[ID_28048\]

In the tool tip of the “Select all items” and “Select specific number of items” options, “partial table” has been renamed to “paged table”.

#### New icons added to Icons.xml file \[ID_28060\]

The following new icons have been added to the file Icons.xml, located in the folder C:\\Skyline DataMiner\\Protocols.

- Trash
- New item

### Fixes

#### Dashboards app: Navigation pane issue after refresh in edit mode \[ID_27339\]

If you exited edit mode in the Dashboards app after refreshing while edit mode was active, all folders in the navigation pane were collapsed and the current dashboard was no longer indicated as selected.

#### DataMiner Cube - Visual Overview: Unnecessary subscription on property when highlight condition was configured based on name \[ID_27409\]

When a highlight condition was configured on a Visual Overview shape based on the name of an element, service or view, an unnecessary property subscription was also made. This will no longer occur.

#### DataMiner Cube - Visual Overview: No log entry would get created when a Visio shape contained a reference to an element on a disconnected DMA \[ID_27527\]

No log entry would get created when a Visio shape displaying a chart contained a reference to an element located on a disconnected DataMiner Agent.

#### Failover: Problem with SLSNMPManager \[ID_27599\]

During a Failover switch, in some cases, an error could occur in SLSNMPManager.

#### Jobs app: Problem when no domains were configured \[ID_27635\]

When no domains had been configured, in some cases, the jobs list would incorrectly keep loading. Also, when you refreshed an empty jobs list, a “page not found” error would be displayed.

> [!NOTE]
> Up to now, when no domains were configured, a popup message would be displayed, asking you to create one. From now on, visual indication and a button will be displayed instead.

#### DataMiner Cube: When one client forcefully disconnected another client, the latter would incorrectly reconnect \[ID_27638\]\[ID_27671\]

When two different Cube clients were connected to the same DataMiner Agent, and one forcefully disconnected the other, up to now, that forceful disconnection would incorrectly be considered as abnormal, causing the disconnected client to immediately reconnect.

From now on, when one client forcefully disconnects another client, the disconnection will be treated as a forceful logout instead.

#### Problem with excessive memory usage of SLDataGateway and SLNet during DataMiner startup \[ID_27658\]

When a DataMiner Agent with a Cassandra database had experienced two days of high alarm activity, in some cases, SLDataGateway and SLNet would start to use excessive amounts of memory after DataMiner startup.

A number of enhancements have now been made to the way in which the alarm history is retrieved during a DataMiner startup.

#### Interactive Automation scripts: Problem when a text box had its wantOnChange setting set to true and its value set to an empty string \[ID_27666\]

When a text box in an interactive Automation script had its wantOnChange setting set to true and its value set to an empty string, in some cases, an exception could be thrown.

#### Mobile apps: Problem with time range quick pick buttons \[ID_27676\]

In the Dashboards app and other DataMiner mobile apps, it could occur that the quick pick buttons of a time range selector did not function correctly.

#### DataMiner Cube - Visual Overview: Problem when clicking a connection line drawn based on table data \[ID_27692\]

In some cases, an exception could be thrown when you clicked a connection line that was drawn based on table data.

#### DataMiner Cube: Problem when connecting to DMS with many alarms and many stopped/paused elements \[ID_27707\]

In some cases, DataMiner Cube could have difficulty connecting to a DMS with a large number alarms and a large number of stopped or paused elements.

#### DataMiner Cube - Trending: Problem when exporting a trend graph to a CSV file \[ID_27708\]

When you select the *Line graph instead of block graph* option when exporting a trend graph to a CSV file, the timestamps of the average data points are put halfway between two points.

In some cases, when you exported a trend graph multiple times in a row using that line graph option, the timestamps would incorrectly keep shifting in the direction of the future.

#### When users logged in with domain administrator credentials, they would incorrectly log in with the local administrator account instead \[ID_27713\]

In some cases, when users logged in with domain administrator credentials, they would incorrectly log in with the local, built-in administrator account instead.

#### Problem with SLDataMiner when importing a CSV file created with a previous DataMiner version \[ID_27722\]

When you imported a CSV file that was created with a previous DataMiner version, in some cases, an error could occur in SLDataMiner.

#### Automatic incident tracking: Problem when removing the IDP location from elements with active alarms \[ID_27723\]

On a system using automatic incident tracking on which DataMiner Infrastructure Discovery Provisioning (IDP) was deployed, in some cases, when the IDP location of an element with active alarms was removed, that location would not be removed correctly. This would cause certain alarms to be grouped by an empty location.

> [!NOTE]
> From now on, IDP location grouping requires that the *Make this property available for alarm filtering* option is activated for the following element properties: IDP, Location Name, Location Building, Location Floor, Location Room, Location Aisle and Location Rack.

#### Service & Resource Management: Problem when rebinding a VirtualFunctionResource \[ID_27735\]

When a VirtualFunctionResource was unbound, in some cases, it would still be processing parameter sets from its bound element. This would cause the parameters of the unbound element to no longer be in an “uninitialized” state. Instead, they would incorrectly stay set to the last received value from the bound element.

#### Interactive Automation scripts: MinWidth, MaxWidth, MinHeight and MaxHeight properties of UIBlock components would not be parsed correctly \[ID_27736\]

In some cases, the MinWidth, MaxWidth, MinHeight and MaxHeight properties of UIBlock components would not be parsed correctly.

#### DataMiner Cube - Data Display: Trend icons would not be displayed until after a few minutes \[ID_27740\]

When you opened an element card, in some cases, trend icons in tables would not be displayed until after a few minutes.

#### DataMiner Cube - Protocols & Templates: An alarm template group would incorrectly not take into account the scheduling configured in the alarm templates in that group \[ID_27749\]

When an alarm template using scheduling was added to an alarm template group, in some cases, the alarm template group would not take into account the scheduling configured in that alarm template.

#### DataMiner - Router Control app: Newly selected input would be highlighted but not selected when the selected output was updated \[ID_27752\]

When, in the Router Control app, you had enabled the *Output first workflow* option, in some cases, when the selected output was updated by an external change, the newly selected input would be highlighted but incorrectly not selected.

Also, it will now be indicated more clearly that a highlighted IO button is selected.

#### Service & Resource Management: When a ReservationInstance was updated, the timeout scripts would incorrectly be executed instead of the expected event script \[ID_27757\]

When you updated an ongoing ReservationInstance, in some cases, all ongoing and future events (i.e. scripts) of that instance would incorrectly be canceled and the timeout scripts would be run on all DataMiner Agents instead.

#### DataMiner Cube: "Show all alarm updates" option not working with alarm for migrated element \[ID_27761\]

If several alarm updates for an element that had been migrated from one DMA to another were combined in a consolidated alarm event, it could occur that the *Show all alarm updates* option on the corresponding alarm card did not work.

#### Problem when updating a DVE table while data exported via a virtual function was being retrieved \[ID_27768\]

In some cases, an error could occur when a DVE table was updated while data exported via a virtual function was being retrieved.

#### Dashboards app: Parameter state component would not get updated when selecting another element in the linked element feed \[ID_27771\]

When a parameter state component was linked to an element feed, in some cases, the parameter state component would not get updated when you selected another element in the element feed.

#### Alarms with a virtual function impact would not be regenerated when a virtual function was linked or unlinked via the generic linked table \[ID_27775\]

When a virtual function was linked or unlinked via the generic linker table, in some cases, alarms with a virtual function impact would not be regenerated.

#### DataMiner Cube: Problem when opening a ListView component containing bookings \[ID_27780\]

In some cases, a KeyNotFound exception could be thrown when you opened a ListView component that contained a list of bookings.

#### Memory leak when using the Chromium browser engine in a browser version of DataMiner Cube \[ID_27789\]

When running a browser version of DataMiner Cube in Microsoft Internet Explorer, in some cases, a memory leak could occur when using the Chromium browser engine to e.g. visualize web pages in Visual Overview.

#### Problem with SLDataMiner at startup when no NICs could be found \[ID_27799\]

In some cases, an error could occur in SLDataMiner at startup when no NICs could be found.

#### Alarm missing from service alarm table after enhanced service was renamed \[ID_27800\]

When an enhanced service was renamed while there was an alarm on multiple services, it could occur that this alarm was cleared from the alarm table of the enhanced service element.

#### DataMiner Cube - Service & Resource Management: Certain text boxes would not allow you to enter a zero character \[ID_27809\]

In certain text boxes, in some cases, it would not be possible to enter a zero character.

#### Jobs app: Empty drop-down boxes when creating/editing job \[ID_27810\]

When a job was created or edited in the Jobs app, it could occur that no items were displayed in drop-down boxes.

#### DataMiner Cube - Alarm Console: Problem when performing actions in rapid succession \[ID_27814\]

In the Alarm Console, in some cases, an exception could be thrown when certain actions were performed in rapid succession.

#### Problem with Protocol.Groups.Group.Content.Session@Next attribute \[ID_27820\]

In a Protocol.Groups.Group.Content.Session@Next attribute, you can specify the number of milliseconds DataMiner has to wait to execute the next session after receiving the response of the last executed session. In some cases, this setting would incorrectly be disregarded.

#### SLAnalytics: Problem when opening a trend graph on a system using pattern matching \[ID_27829\]

On a system using pattern matching, in some cases, an error could occur in SLAnalytics when you opened a trend graph.

#### Alarm masked for a limited period of time would not be unmasked if the alarm template was updated while the alarm was masked \[ID_27838\]

When an alarm associated with a column parameter was masked for a limited period of time, in some cases, it would not be unmasked when that period of time elapsed if an alarm template update affecting the column parameter had occurred while it was masked.

#### Dashboards app - Line chart component: Problems when retrieving trend data \[ID_27853\]

In some cases, a trend graph legend would show an error when a trend data request was interrupted, e.g. by scrolling to another page before the current page was fully loaded.

Also, when multiple trend requests were required, in some cases, those requests would be ignored when a trend data request was already in progress.

#### Service & Resource Management: When an unbound Virtual Function Resource was deleted, the replication connection was incorrectly not removed \[ID_27857\]

When an unbound Virtual Function Resource was deleted, in some cases, the replication connection would incorrectly not be removed.

#### DataMiner Cube - Profiles app: Service profiles could not be deleted when linked to a profile instance \[ID_27860\]

In some cases, it would not be possible to delete a service profile, especially when a profile instance had a link to it. In the profile instance editor, the service profile selection box now contains a “\<None>” entry. This will allow the link to the service profile instance to be severed.

Also, in some cases, the Profiles app would not load service profile objects.

#### Dashboards app - Line chart component: Trend graph incorrectly showed primary key instead of display key \[ID_27879\]

When a table parameter had a display key that was different from the primary key, up to now, the trend graph would incorrectly show the primary key. From now on, it will show the display key instead.

#### Problem with automatic URI detection \[ID_27884\]

In some cases, an exception could be thrown during automatic URI detection.

#### Problem when editing a protocol while a cluster synchronization was in progress \[ID_27890\]

In some rare cases, an error could occur when a protocol was edited while a cluster synchronization was in progress.

#### DataMiner Cube - Trending: Problem with trend groups containing invalid data \[ID_27892\]

In some cases, an exception could be thrown when a trend group contained invalid data.

#### Dashboards app - Pivot table component: Problem with conditions \[ID_27897\]

When a pivot table component had conditions configured, in some cases, those conditions would incorrectly only work in conjunction with table column parameters, not with single-value parameters.

Also, a selection box problem could occur when multiple conditions were configured in the “Configure indices” section.

#### Automation: Problem when retrieving information events from all DMAs \[ID_27903\]

When, in a DataMiner System with multiple agents, information events were retrieved by an Automation script, in some cases, not all information events would be retrieved.

#### Dashboards app - Time range component: Default range would be used even after being overwritten afterwards \[ID_27941\]

If the default values of a time range component had been set to a custom range, in some cases, those values would incorrectly still be used after being overwritten afterwards (e.g. by means of URL arguments or another feed).

#### DataMiner Cube - Bookings app: Memory leak when opening the Signal Path tab \[ID_27952\]

In some cases, DataMiner Cube could leak memory each time you opened the Signal Path tab when configuring a booking in the Bookings app.

#### DataMiner Cube - Services app: Profile Instances would not be loaded and the Profile Instance selection box would not contain any items \[ID_27989\]

When, in the Services app, you loaded a Service Profile Instance, in some rare cases, the Profile Instance would stay empty and the Profile Instance selection box would not contain any items.

#### Cube launcher tool: Problem when checking the host name \[ID_27992\]

When you configured a new DataMiner Agent, in some cases, an error could occur when the DNS name could not be resolved while checking the host name.

#### DataMiner Cube - Visual Overview: Problem with SurveyorSearchText variable \[ID_27996\]

In some cases, making a shape display or set the Surveyor search text using the Surveyor-SearchText session variable would no longer work.

#### DataMiner Cube - Visual Overview: Save button no longer working in embedded Service Manager component \[ID_28003\]

In an embedded Service Manager component, in some cases, the Save button would no longer work.

#### Service & Resource Management: Capacities property and Capabilities property of a Resource could incorrectly be set to null \[ID_28005\]

In some rare cases, the Capabilities property and the Capacities property of a Resource could incorrectly be set to null.

#### DataMiner Cube - Profiles app: Incorrect error message when Name text box is empty \[ID_28007\]

When the name of a profile definition or a profile instance was empty, in some cases, an incorrect error message would appear.

#### DataMiner Cube: Problem when the single, dynamically included element in a service was briefly excluded \[ID_28013\]

When a service contained a single, dynamically included element, in some cases, an exception could be thrown when the element was briefly excluded from the service.

#### Display values of rate alarms would have an unnecessary level of precision after an element restart on systems with a MySQL database \[ID_28028\]

On a system with a MySQL database, in some cases, display values of rate alarms would have an unnecessary level of precision after an element restart.

#### Value rate alarm not displayed correctly \[ID_28039\]

In some cases, it could occur that the value of a rate alarm was not displayed correctly. this could for instance occur after an element restart, after an element was masked, etc.

#### DataMiner Cube - Alarm Console: Error alarms could get stuck when a process had multiple threads with run-time errors \[ID_28113\]

In some cases, error alarms could get stuck in the Alarm Console when a process had multiple threads with run-time errors.

#### Problem in SLLog after stopping and reopening log file \[ID_28122\]

If a log file was stopped and then reopened shortly afterwards, a problem could occur in the SLLog process.

#### Problem when restarting an agent in a DataMiner System \[ID_28152\]

When an agent was restarted in a DataMiner System, certain SLNet threads could get stuck for a period of time when the connection was severed on other agents in the same DataMiner System.

## Addendum CU1

### CU1 fixes

#### SLWatchDog2.txt: Total number of processes of which at least one thread has a run-time error was incorrectly replaced by total number of threads with a run-time error \[ID_28360\]

Each time a run-time error occurs, an entry is added to the SLWatchDog2.txt log file, showing the total number of processes of which at least one thread has a run-time error.

However, in some cases, that log entry would incorrectly show the total number of threads with a run-time error instead.

#### Failover: Configuration issues \[ID_28378\]

In a Failover setup, in some cases, an error could occur when no ElasticSearch database was found.

Also, in some cases, configuration updates would be ignored after a Failover switch.
