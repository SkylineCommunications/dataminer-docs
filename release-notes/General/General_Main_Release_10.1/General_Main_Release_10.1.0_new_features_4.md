---
uid: General_Main_Release_10.1.0_new_features_4
---

# General Main Release 10.1.0 - New features (part 4)

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!NOTE]
> **Internet Explorer Support**
>
> Though DataMiner Cube is available as a desktop application, many users still like to use the DataMiner browser application that requires Internet Explorer. However, Microsoft no longer recommends using Internet Explorer, and support for Internet Explorer is expected to cease in 2025, though currently the program is still maintained as part of the support policy for the versions of Windows it is included in. For more information, see <https://docs.microsoft.com/en-us/lifecycle/faq/internet-explorer-microsoft-edge>.
>
> The preferred way to use DataMiner Cube is as a desktop application, which can be downloaded from each DMA’s landing page in any other browser than Internet Explorer. From DataMiner 10.0.9 onwards, this application also comes with a new start window for increased ease of use.
>
> However, if you do wish to use DataMiner Cube in a browser, this remains possible:
>
> - Microsoft Edge can be configured to open specific URLs in IE compatibility mode. If you configure Edge to open the DataMiner Cube URLs of DMAs in this mode, you will be able to access the DMAs with DataMiner Cube in Edge. However, make sure you only do this for the exact URLs of DataMiner Cube, as other DataMiner apps will not function optimally in IE compatibility mode. For more information see, <https://docs.microsoft.com/en-us/DeployEdge/edge-ie-mode-policies>.
> - You can still continue to use Internet Explorer to access DataMiner Cube as long as Microsoft support continues. However, in this case we highly recommend to use a different browser to access any other websites on the internet.

### DMS Reports & Dashboards

#### Dashboards app: Quick-pick buttons added to time range feed \[ID_23133\]

The time range feed can now be configured to show a list of quick-pick buttons that will allow users to enter a preset time range by clicking a single button.

To configure the list of quick-pick buttons to be shown when users click a time range feed, go to edit mode, select the time range feed, open the *Layout* tab, select *Use quick picks*, and select the buttons to be shown.

#### Dashboards app: Enhanced theme configuration \[ID_23258\]

In the dashboard settings page, which is now named “*Dashboards settings*”, the dashboard theme configuration has been enhanced. On this page, you can create, copy and delete themes. When editing a theme, you can now also mark it as the default theme.

Also, there are now two system themes: “Light” and “Dark”. These are fixed themes that cannot be edited or deleted.

Per dashboard, a theme can be selected in the *Layout* tab, which has now also been restyled. From now on, this tab will only allow you to change the layout of a dashboard after selecting the *Override* option.

> [!NOTE]
> When you save a customized dashboard layout as a new theme, you will be asked to confirm this save operation as this will undo all changes you made to the layout of the dashboard you are editing.

#### Dashboards app: Line chart component can now visualize resource capacity \[ID_23901\]

When you add a line chart component to a dashboard and drag resources onto it, it will display the resource capacity parameters as a stacked trend chart.

If you then click the chart and select a point in time, the legend will list all bookings for that specific point in time. To clear the list, right-click the chart or close the legend.

The resource capacity parameters displayed in the chart can be grouped by parameter or by resource.

#### Dashboards app: Generic Query Interface \[ID_24048\]\[ID_24548\]\[ID_25898\]\[ID_25921\]\[ID_26050\] \[ID_26153\]\[ID_26448\]\[ID_26477\]\[ID_26793\]\[ID_27616\]\[ID_27678\]\[ID_27949\]\[ID_27987\]\[ID_28010\] \[ID_28071\]\[ID_28158\]\[ID_28761\]\[ID_28791\]\[ID_28831\]

The Generic Query Interface allows you to efficiently tap into the wealth of data available in your DataMiner System. In this release, the interface is available via the *Queries* data input for Bar chart and State visualizations, as well as in the new Table and Pie Chart visualizations, which were especially created for this feature. In future releases, additional functionality using the Generic Query Interface will become available. Note that this feature is only available if DataMiner uses a Cassandra database. For some queries, an Elasticsearch database is also required.

##### Using the Queries data input

You can construct a query to use as data input for a component by following these steps:

1. In edit mode, select the dashboard component for which you want to use a query as a data input. At present, this is support for Bar chart, State and Table components.

2. In the data pane, select *Queries* and click the + icon to add a new query.

3. Specify a name for the query.

4. In the drop-down box below this, select the data source you want to use. At present, the following options are available:

    - *Get elements*: The elements in the DataMiner System.

    - *Get parameter table by alias*: The parameter table using the specified alias in the Elasticsearch database.

    - *Get parameter table by ID*: The selected parameter table from the element with the specified DataMiner ID and element ID.

    - *Get parameters for elements where*: The selected parameters for the specified protocol or the parameters linked to the specified profile definition. Note that if parameters are displayed based on a specific protocol, it is not possible to combine a table parameter with other parameters, and only column parameters from the same table can be displayed in the same query.

    - *Get services*: The services in the DataMiner System.

5. Select an operator. This step is optional; if you do not select an operator, the entire data set will be used. The following operators are available:

    - *Aggregate*: Allows you to aggregate data from the data source. After you have selected this option, first select the aggregation column, and the method that should be used. Depending on the type of data available in the selected column, different methods are available, e.g. Average, Count, Distinct Count, Maximum, Median, Minimum, Percentile 90/95/98 or Standard deviation.

        You can then further filter the result by applying another operator. An additional *Group by* operator is available for this, which will display the result of the aggregation operation for each different item in the column selected in the *Group by column* box.

    - *Column manipulations*: Creates a new column based on existing columns. When you select this option, you also need to select a manipulation method.

        If you choose the *Concatenate* method, you will need to select several columns and then specify the format that should be used to concatenate the content of those columns, using placeholders in the format {0}, {1}, etc. to refer to those columns.

        If you choose the *Regexmatch* method, you will need to select a column and specify a regular expression, so that the new column will only contain the items from the selected column that match the regular expression.

        For both manipulation methods, you will also need to specify the name for the new column. When the column manipulation operation is fully configured, you can further fine-tune the result by applying another operator.

    - *Filter*: Filters the data set. When you select this option, select the column to filter, specify the filter method (e.g. equals, greater than, etc.) and the value to use as a filter. The available filter methods depend on the type of data in the selected column. Once the filter has been fully configured, you can refine the results by applying another operator, e.g. an additional filter.

    - *Join*: Joins two tables together. When you select this option, in the *Type* drop-down box, you will first need to select how the tables should be joined. Then you will need to select another data source (optionally refined with one or more operators) in order to specify the table you want the first table to be joined with. Optionally, you can also specify a condition to determine when rows should be joined. For instance, if one table contains elements with a custom property that details a booking ID and the other lists bookings, you could add the condition that the property in the first table must match the ID in the second table.

        The *Inner* type of join only includes rows if they match the condition. *Left* displays all rows from the first table (i.e. the table on the left) and only the matching rows from the other table. *Right* does the opposite. *Outer* displays first the non-matching rows from the left table, then the matching rows from both tables, then the non-matching rows from the right table.

    - *Select*: Displays the selected columns only. When you have selected the columns to display, you can apply another operator to refine the query.

    - *Top X*: Displays the top or bottom items of a specific column, with X being the number of items to display. When you select this option, you will need to specify the column from which items should be displayed and the number of items that should be displayed. By default, the top items are displayed. To display the bottom items instead, select the *Ascending* checkbox.

6. Drag the configured query to the component in order to use it.

> [!NOTE]
>
> - It is possible to refer to a query in the dashboard URL, using the following format: *?queries=\[***alias***\]\\x1F\[***queryJsonString***\]*
>
>   In this format, \[alias\] is the name of the query and \[queryJsonString\] is the query in the format of a JSON string, for example: *?queries=Get Elements/{"ID": "Elements"}*
>
> - When a query has been created, the columns from the table that results from the query are available as individual data items in the data pane, so that you can use them to filter or group a component.
> - It is not possible to retrieve data from a stopped element.
> - When retrieving profile parameter values, configured converters (i.e. mediation snippets) will be taken into account.
> - A GQI query is not saved in a separate file but in the dashboard itself.
> - A GQI query based on the *Get parameter table by ID* or *Get parameters for elements where* data sources will, by default, inherit the dashboard’s *Use dynamic units* setting. If necessary, you can override this automatic inheritance by selecting the component’s *Override dynamic units* setting.
>
>    When a GQI query does not use dynamic units, by default, parameter values will be displayed using a thin space as thousand separator.

##### Table visualization

This new visualization was especially designed to be able to display the results of queries in a table format. It only supports query data input. It displays the different data sources as follows:

- Elements are represented with a row for each element, with each column detailing different information for that element.

- Services are displayed in the same way as elements.

- Table parameters are displayed as they are, as determined by the applied operators.

- If parameters are retrieved by protocol or profile definition, each row will represent a matching element, and for each parameter a column will show the corresponding values.

You can resize the columns of the table by dragging the column edges. Clicking on a column header will sort the table by that column. To toggle between ascending and descending order, click the column header again. To sort by multiple columns, keep the Ctrl key pressed while clicking the column headers. The first column will then be used for the initial sorting, the next one to sort equal values of the first column, and so on.

In the *Layout* tab for this component, the *Column filters* option is available, which allows you to highlight cells based on a condition. To do so, select the parameter you want to use for highlighting, indicate a range to be highlighted, select the range and then click the color icon on the right to specify a highlight color. Multiple ranges can be indicated for one parameter, each with a color of its own.

##### Pie Chart visualization

This new visualization was designed to display the results of queries in a chart shaped like a pie or donut. It only supports query data input.

The following layout options are available for this visualization:

- *Chart shape*: Can be set to *Pie* or *Donut*.

- *Legend*: The legend can be hidden. If it is set to be displayed, you can select whether it should be displayed on the left, on the right, at the top or at the bottom of the visualization.

- *Tooltips*: Tooltips can be hidden. If they are set to be displayed, you can select whether these should include the label, dimension, value and/or percentage.

In addition, the following settings are available for this visualization:

- *Label*: Allows you to select which data should be used as a label.

- *Segment size*: Allows you to select which data should determine the size of segments in the chart.

##### Bar chart visualization changes

A number of changes have been implement to the bar chart visualization, in order to optimize this visualization to display queries.

If the visualization displays a query, in the *Settings* tab, the following options are available instead of the usual options for a bar chart:

- *Label*: Allows you to select which data should be used as a label.

- *Bars*: Allows you to select which data should determine the size of bars.

In addition, the following layout options can now be configured for this visualization:

- *Chart layout*: Can be set to *Relative* or *Absolute*. *Relative* means that the dimension of each bar is shown as a relative percentage. *Absolute* means that the dimension of each bar is shown as an absolute numeric value.

- *Chart orientation*: Determines how the chart is displayed, i.e. from left to right, from right to left, from top to bottom or from bottom to top.

- *Legend*: The legend can be hidden. If it is set to be displayed, you can select whether it should be displayed on the left, on the right, at the top or at the bottom of the visualization.

- *Tooltips*: Tooltips can be hidden. If they are set to be displayed, you can select whether these should include the label, dimension and/or value.

#### Dashboards app: New 'Clear all' action + settings to pin actions \[ID_24356\]

In the dashboard settings, you can now "pin" actions to the header bar. When they are pinned, actions will be displayed as full buttons in the dashboard header bar, e.g. the *Start editing* button. When they are not pinned, the actions can be accessed via an arrow button in the top-right corner of the dashboard.

If a dashboard contains at least one feed, a new *Clear all* action is now available in the dashboard header, which can be used to clear the selection of the feeds in the dashboard.

It is possible to view this new action even when the dashboard is embedded, if "subheader=true" is added to the URL. However, not that this is only the case for the *Clear all* action.

For example: *http://**\[DMA IP\]**/dashboard/#/MyDashboards/dashboard.dmadb?embed=true&subheader=true*

#### Dashboards app: Parameter feed now has a 'Selected only' toggle button \[ID_24446\]

The parameter feed allows you to select multiple parameters from a predefined list. At the top of the list, a box allows you to select or deselect all items in the list at once and, from now on, a “Selected only” toggle button will also allow you to show or hide items that are not selected.

#### Dashboards app: New Auto-expand parameters setting for parameter feed \[ID_24682\]

A new setting, *Auto-expand parameters*, is now available for the parameter feed component. If this setting is selected, all tables and groups in the component will by default be expanded.

#### Legacy Reporter app will now also use the CSV separator specified in Cube’s CSV separator setting \[ID_24855\]

Similar to the new Dashboards app, the legacy Reporter app will now also use the CSV separator specified in Cube’s “CSV separator” setting when generating CSV reports.

If this setting cannot be retrieved, the system will fall back to the Windows regional settings on the DataMiner Agent.

#### Dashboards app: Service definition visualization and SRM data feeds \[ID_24433\]\[ID_24480\] \[ID_25056\]\[ID_25151\]\[ID_25169\]\[ID_25178\]

A new *Service definition* visualization is now available in the *Other* category in the Dashboards app. This visualization can be used to display a service definition as a node edge graph.

To support this new visualization, two new data sets are available:

- A bookings data set: This data set can be filtered on a specific time range. It can be used as the data feed for a *Service definition* component or to add booking data to a *Drop-down*, *List* or *Tree* feed component. If the entire booking data set is added, a time range feed should also be added as a filter. To specify a booking data feed in a URL, specify *bookings=bookingsID*

- A service definition data set: This data set can be used as the data feed for a *Service definition* component. Alternatively, in case a feed component is used to provide a booking feed to the *Service definition* component, it is possible to use a service definition filter feed on this feed component, so that a booking is only included in the feed if it is based on one the service definitions in the filter. To specify a service definition data feed in a URL, use the argument “service definitions”, and specify the service definition ID(s), for example: *service definitions=serviceDefinitionID1%2FserviceDefinitionID2*

Note that if you add a data feed directly instead of via feed component, the *Service definition* component can be used either with a bookings data feed or with a service definition data feed, but not with a combination of both.

Several options are available to fine-tune the layout of the component. You can select whether node IDs and/or interfaces should be displayed, whether zooming is enabled, and which edge style is used.

When the service definition component displays nodes that are linked to particular resources, alarm and element info will now be displayed for these nodes in the graph. The alarm state will be displayed with a colored border at the top of the node, and in the node icon in case the default icon is shown. In addition, a link icon in the node will open the corresponding element card in the Monitoring app when clicked.

In the settings for the *Service definition* component, one or more actions can be defined. For each action, an Automation script and an icon need to be defined, and you need to specify to which node or nodes the action must be added. The icon will then be displayed on the specified node or nodes. When the icon is clicked, the script is launched. The booking ID or service definition ID used in the component and the node ID of the node for which the icon was clicked will be passed to the script as parameter ID 1 and parameter ID 2, respectively. The order of the specified actions can be modified in the *Settings* pane. In case there are too many actions on a node to display them all, clicking the action bar at the bottom of the node will expand the bar to display all the actions.

#### BREAKING CHANGE - Dashboards app: CPE feed component now uses element data feed \[ID_25216\]

To configure the data input of the *CPE feed* component in the Dashboards app, you now have to use a regular element data feed instead of specifying the element in the component settings. This change makes it possible to provide the data input of the *CPE feed* component dynamically using another feed component.

#### Dashboards app: CPE feed will only pass along the deepest selected field \[ID_25304\]

From now on, a CPE feed will no longer pass along all selected fields. Instead, it will only pass along the deepest selected field.

#### Dashboards app: Image component now supports more image formats \[ID_25488\]

From now on, the image component supports the following image formats:

- apng
- gif
- jpeg
- png
- svg
- webp

> [!NOTE]
> As images in bmp format should be avoided in web content, this format is not supported.

#### Dashboards app: Component themes \[ID_25634\]

Within a particular dashboard theme, you can now define specific themes per component.

In a component theme, you can currently configure the following properties:

- Component title text styles
- Component background and font color
- Component margin and padding
- Component border styles
- Component shadows

You can change a component’s theme in the following ways:

- Select one of the existing component themes defined in the current dashboard theme.
- Customize the component’s current theme.

You can create new component themes in the following ways:

- Define a new component theme when creating or editing a dashboard theme.
- Save a component’s theme after having customized it.

> [!NOTE]
>
> - By default, a component will use the read-only default theme from the dashboard on which it is placed.
> - For backwards compatibility, components that previously inherited their styles from the dashboard theme will now use the default component theme instead.

#### Dashboards app: Linking a component to URL data without using a feed \[ID_25705\]

In the Dashboards app, it is now possible to link a component to data in the URL without using any feeds on the dashboard.

To do so, after selecting the component, open the *Data* tab, go to *Feeds \> URL*, and drag the necessary data onto the component.

> [!NOTE]
> When the dashboard has a feed that contains the same data as the URL, the feed will overwrite the data found in the URL.

#### Dashboards app - Service definition component: Options to show/hide nodes \[ID_25763\]

On the *Layout* tab of the service definition component, two new options now allow you to specify which nodes you want the component to show or hide:

- **Visible nodes**

    In this tree, which lists all available nodes grouped per parent system function and function definition, you can select the nodes to be displayed. The nodes that are not selected will be hidden.

- **Show nodes without a resource assigned**

    When you select this checkbox, the component will also show the nodes that have no resource assigned. By default, this checkbox will not be selected.

> [!NOTE]
>
> - When the service definition component does not show any node, an animation will indicate the reason why none are shown.
> - When actions are defined on a certain node, the group labels will now be moved to the top of that node.

#### Dashboards app: Embedding a single component into Visual Overview or a web page \[ID_25804\]

It is now possible to embed an individual Dashboards app component into Visual Overview or a web page.

Do the following:

1. In the Dashboards app, open the dashboard that contains the component you want to embed.

2. Right-click the component and select *Copy embed URL*.

3. Use the URL of the component in either a Visio page (e.g. in a shape with a data field of type “Link”) or a web page (e.g. in an \<img> tag).

A component URL has the following syntax:

```txt
http://<DMA>/embed?component=<SERIALIZED-COMPONENT>
```

> [!NOTE]
>
> - “SERIALIZED-COMPONENT” is a serialized representation of the component in JSON format.
> - If the component contains data, that data will automatically be included into the URL.

#### Dashboards app: Minimum and maximum values shown on line chart component \[ID_26063\]

When you hover the mouse pointer over a line chart component in the new Dashboards app, now the minimum and maximum values will be shown in addition to the average value that was already shown previously.

#### Dashboards app - Parameter feed: New option to automatically select a specified number of indices \[ID_26080\]

In the *Settings* tab of the parameter feed component, next to the *Auto-select all indices* option, there is now a new *Auto-select number of indices* option.

This new option will allow you to specify the number of indices that should be selected by default.

If the number of indices specified is greater than the number of indices that are being displayed, they will not be shown but selected in memory.

#### Dashboards app - Line chart component: New 'Hide parameters without trend data in the legend' option \[ID_26133\]

The line chart component has a new setting: Layout \> Styling and information \> Hide parameters without trend data in the legend.

When you enable this setting, the legend of the line chart component will no longer show items for which no trend data is available.

Default: enabled

#### Dashboards app - Parameter feed: Index filter separator \[ID_26136\]

The parameter feed component has a new (optional) setting: Index filter separator.

This setting allows you to specify the separator to be used when retrieving a filtered list of indices.

For example, if only the indices with a primary key equal to “X” have to be retrieved, and the index filter separator is set to “Y”, then the indices will be retrieved using the following filter: PK == X OR PK == \*YXY\*.

#### Dashboards app - Parameter page: New data/filter feed combinations \[ID_26143\]

The parameter page component can now be configured to use the following data feeds and filters:

| Data feeds                  | Possible data filter feeds                                                                                                                                                                                                                                       |
|-----------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Element                     | \- Data page based on element (legacy option - if possible, use a data page based on protocol)<br> - Data page based on protocol |
| Data page based on element  | \<No additional data filter feeds required>                                                                                                                                                                                                                      |
| Data page based on protocol | Element feed                                                                                                                                                                                                                                                     |

#### Dashboards app - Pivot table component: Enhancements \[ID_26316\]

A number of enhancements have been made to the pivot table component, including the following:

- Elements are now ordered by element name.
- When using mediation protocol parameters, the data will now be shown per mediation parameter.
- Server-side exceptions will now be handled more gracefully.

#### Dashboards app: Enhanced border configuration \[ID_26346\]

When configuring a dashboard theme or a component layout, up to now, it was only possible to specify whether borders had to be displayed or hidden. From now on, it is possible to specify on which of the four sides a border has to be displayed or hidden: top, right, bottom and/or left.

#### Dashboards app: New style layout options for State components \[ID_26454\]\[ID_26498\]

In the Dashboards app, the layout options for the State component have been adjusted. The options that were previously available in the *Style* section are replaced with the following options:

- *Design*: Allows you to choose one of the following options:

  - *Small:* The component displays a single line containing a label and value.
  - *Large*: The component displays multiple lines with one value and up to three labels.
  - *Auto size*: Similar to the *Large* option, but automatically adjusts the content to fill the entire component.

- *Alarm state coloring*: Allows you to select one of the following options to determine how alarm coloring is displayed:

  - *LED*: The alarm color is displayed by a circular LED to the left of the first label.
  - *Line*: The alarm color is displayed by a bar along the left side of the component.
  - *Text*: The text color of the value matches the alarm color.
  - *Background*: The background of the component displays the alarm color. If this option is selected, an additional option, *Automatically adjust text color to alarm color*, can be selected to make sure the text color is adapted if necessary.
  - *None*: No alarm color is displayed.

#### Dashboard app: New setting to configure number of dashboard columns \[ID_26530\]

It is now possible to configure in how many columns components can be displayed in a dashboard. You can do so via the new *Number of columns* option in the settings of a dashboard. The maximum number of columns is 50. If you change the number of columns to a lower number and the columns currently contain components, a warning will be displayed, saying that components may be relocated.

In addition, when a dashboard is being edited, a new button is now available in the dashboard header bar that allows you to show or hide the grid lines in the dashboard while you are in edit mode.

#### Dashboards app: New Spectrum Analyzer component \[ID_26606\]\[ID_26675\]\[ID_26734\]\[ID_26820\] \[ID_26927\]\[ID_26970\]\[ID_27031\]\[ID_27150\]

When you create or update a dashboard, you can now add Spectrum Analyzer components.

A Spectrum Analyzer component, linked to a Spectrum Analyzer element, will open a new session based on the last session that was closed by the user in DataMiner Cube.

Also, in the DATA pane, you can select a spectrum preset and, for example, have it act as a filter. It is even possible to link a drop-down feed component to a Spectrum Analyzer component and use it to select the preset to be used in the latter.

> [!NOTE]
> Spectrum parameters dynamically added by spectrum monitors will automatically be available in the Dashboards app.

The Spectrum Analyzer component can also be used to visualize and toggle measurement points.

To visualize all measurement points for a particular spectrum session, do the following:

1. Add a Spectrum Analyzer component to the dashboard and, in the Data pane of the component, select a Spectrum Analyzer element (and, optionally, a Spectrum preset).

2. Add a List feed to the dashboard and, in the Data pane of the feed, select the Spectrum session feed of the Spectrum Analyzer component.

    > [!NOTE]
    > A Spectrum Analyzer component can be used as a feed for a Spectrum session. The session created by a Spectrum Analyzer component can be used as input for other components.

By selecting and unselecting measurement points in this measurement point visualization, you can control which measurement points will be used by the Spectrum Analyzer component.

> [!NOTE]
>
> - The Dashboards app and the Monitoring app also support combining measurement points. In DataMiner Cube, you can create spectrum presets in which you combine measurement points to have them shown together.
> - Measurement point traces will inherit their colors from the dashboard theme.

#### Dashboards app: Advanced settings \[ID_26659\]

Component settings can now be marked as advanced. When marked as such, they will only be displayed when you opened the Dashboards app with the following URL argument:

- “showAdvancedSettings=true”

#### Dashboards app: Optimization of component visualizations \[ID_26751\]

After adding a component to a dashboard, you can apply a specific visualization. The list of available visualizations has now been optimized.

Up to now, the list of available visualizations depended on the type of component. From now on, that list will instead depend on the type of data linked to the component. In other words, the list will contain all visualizations that are capable of visualizing the type of data currently linked to the component.

The order of the listed visualization has also been optimized. First in the list will be the most obvious ones to visualize the data in question, followed by all other available visualizations sorted alphabetically by name.

Hovering over a visualization will preview the component.

#### Dashboards app: State timeline component \[ID_26772\]

The state timeline component visualizes the alarm state changes over time of a parameter, element or service. By default, it shows a timeline for the last 24 hours, but a time range feed can be added to set the component to a different time range.

To configure the component:

1. Apply an element, service, or protocol/element parameter data feed.

2. Add a filter if necessary:

    - If the component uses a protocol parameter data feed, add an element filter feed.

    - If the component uses a table or column parameter data feed, add an index filter feed.

3. Optionally, add a Time range component to the dashboard and configure the state timeline component to use it as a filter feed.

#### State/Gauge/Ring components now able to show multiple items for several types of feeds \[ID_26780\]

In the Dashboards app, it is now possible to show multiple states with the same *State*, *Ring* or *Gauge* component, even if elements, services, views or redundancy groups are used as the data feed. Previously, this was only supported for parameter feeds.

For the *State* component, the *Layout flow* options in the *Layout* panel allow you to select whether the different states should be displayed in rows or columns. If they are displayed in rows, they will displayed next to each other until there is no more space and a new row is started. If they are displayed as columns, they will be displayed below each other until there is no more space and a new column is started.

For the *Ring* and *Gauge* component, if parameter feeds are used, additional options in the layout panel allow you to configure whether the different parameters are displayed next to each other or below each other, and how many rows and columns of parameters can be displayed at the same time. These options are not available for other types of feeds; for those only one item is displayed at the same time and you need to scroll to see the next item.

#### Dashboards app: Dashboards created by users will now be included in DataMiner backup packages \[ID_26836\]

When, in DataMiner Cube, you take a backup, all dashboards created by users (i.e. all files stored in C:\\Skyline DataMiner\\Dashboards) will now be included in the backup package if you selected either “full backup” or “full backup without database”.

#### Dashboards app: New Image size option for Image component \[ID_27040\]

In the Dashboards app, a new *Image size* option is now available for *Image* components. This option allows you to determine how the image is scaled, with the following three possibilities:

- *Fit*: Scales the image to the maximum possible size without stretching or cropping.

- *Fill*: Scales the image to the maximum possible size without stretching.

- *Stretch*: Scales the image to the maximum possible size without preserving the aspect ratio.

#### Dashboards app: State component now supports dynamic units \[ID_27066\]

The State component in the Dashboards app now supports dynamic units, i.e. units that can be converted to other units according to rules configured in the protocol.

For this purpose, 2 new methods have been added to the web services API v1: *GetParameterWithDynamicUnits* and *GetParameterForServiceWithDynamicUnits*, which are similar to the *GetParameter* and *GetParameterForService* methods, respectively.

#### Dashboards app: Spectrum buffer feeds \[ID_27092\]\[ID_27154\]

It is now possible to use spectrum buffers as input for a Spectrum Analyzer visualization. These are available in the new *Spectrum Buffers* section in the *Data* pane. To select a spectrum buffer, first specify the name of a spectrum element in the box at the top if this section. The buffers are then listed in the format *MonitorName: TraceName \[MeasptName\] \[PresetName\]*.

You can link a Spectrum Analyzer visualization to spectrum buffer input directly, or use feed components (e.g. drop-down or list), by adding an individual spectrum buffer to a feed component or by adding the spectrum buffers as a collection and then adding a spectrum element as a filter.

#### Dashboards app: Line chart component now exposes timespan feed \[ID_27128\]

If a line chart component is used in a dashboard, a timespan feed now becomes available in the data pane, which can be used to apply the timespan of the line chart to other components as a feed. This timespan feed is updated whenever the timespan displayed by the trend graph is adjusted, e.g. because you zoom in on a specific timespan.

#### Dashboards app: Threshold state visualization in spectrum analyzer components \[ID_27169\]\[ID_27273\]

If a spectrum analyzer component in the Dashboards app uses a spectrum buffer feed, it is now possible to color the threshold lines from the preset based on the state of a spectrum monitor parameter. Threshold lines are now also displayed as distinct line segments, and can be hidden or shown depending on the preset.

To be able to link a threshold line to a spectrum monitor parameter, the spectrum script used by the monitor must contain variables referring to the thresholds. Each threshold line has a threshold ID, which is an index ranging from 1 to the total number of thresholds in the preset. To refer to the first threshold, the script variable should be *$threshold1*, for the second threshold, it should be *$threshold2*, etc. This format is case-sensitive. When you configure the spectrum monitor in DataMiner Cube, you can then select these variables to create a parameter with alarm monitoring.

Note that it does not matter in which preset the threshold is defined. For example, each threshold in a preset with index 3 will be linked to the state of script variable *$threshold3* in a monitor.

> [!NOTE]
>
> - Similar to DataMiner Cube, threshold lines will appear in front of the spectrum trace.
> - In case of a buffered trace, a time stamp will be shown in the top-right corner, indicating when the buffer was last updated.
> - When the background color is changed, the marker labels and the time stamp will be updated accordingly.
> - Changing the spectrum buffer or switching to normal mode will reset any threshold line that was linked to a monitor parameter state to its default width. Linked threshold lines are slightly thicker.

#### Dashboards app: New 'Enable pinning as quick pick' option + support for timespans as input for time range feed \[ID_27357\]

In the Dashboards app, if the layout option *Use quick picks* is selected for a time range component, you can now enable the additional option *Enable pinning as quick pick*. When you do so, a pin icon is displayed next to the time summary in the component. Clicking the icon will add the current time selection as a custom quick pick button. If the current time selection matches the custom quick pick button, clicking the pin icon again will remove the button. You can also remove the button using the garbage can icon on the button itself.

The custom quick pick button is saved on component level, which means it will remain displayed when the dashboard is refreshed, until it is manually removed.

As an additional change, the time range feed has been updated to also accept timespans as input data now. Adding a timespan as input will set the active time range in the feed.

#### Dashboards app: Selecting an empty folder will now cause a 'Create dashboard' button and an 'Import dashboard' button to appear \[ID_27362\]\[ID_27579\]\[ID_27844\]

When, in the sidebar of the Dashboards app, you select an empty folder, two large buttons will now appear in the large pane on the right.

| Click...         | to...                                                           |
|------------------|-----------------------------------------------------------------|
| Create dashboard | create a new dashboard from scratch in the folder you selected. |
| Import dashboard | import an example dashboard in the folder you selected.         |

> [!NOTE]
> The two above-mentioned options will also be available in the context menu when you right-click a folder in the navigation pane.

#### Dashboards app: Support for table column parameter as input for State component \[ID_27463\]

When you use a table column parameter as input for a State component in the Dashboards app, it will now display the state for all indices of the column. Optionally, you can add an indices filter in order to display specific indices only.

#### Ordering of data entries used in a dashboard component \[ID_27486\]

For dashboard components that can display multiple data entries and for which it makes sense to modify the order in which these entries are displayed (e.g. State components, Parameter table components, etc.), in the *Data* pane, a new *Data used in component* section is available. This section lists the different data entries used by the selected component, with arrow icons on the right that can be used to change the order in which the entries are displayed.

#### Dashboards app: Support for quick filters of tables in visual overview components \[ID_27517\]

Quick filters are now supported for tables within a visual overview component of a dashboard. The following (case-insensitive) syntax is supported for the filters:

- {column name}{operator}{value}
- {column name}{operator}regex{operator}{regex value}
- {column name}{operator}severity{operator}{alarmstate}
- regex{operator}{regex value}
- severity{operator}{alarmstate}

The following operators are supported in this syntax:

- : (contains)
- !:
- =
- !=
- ==
- !==
- \<=
- \>=
- \>
- \<

#### Dashboard theme configuration improvements \[ID_27553\]

The following improvements have been implemented to dashboard themes:

- It is now possible to customize the colors for the lines displayed in a trend graph. You can do so on dashboard level, by customizing the theme, or on component level, by customizing the component theme. In either case, the colors can be configured under *Color* > *Color palette*.

- While previously, customizing the dashboard theme within a dashboard only provided limited options compared to the theme configuration in the settings of the Dashboards app, now a *New theme* button is available in the dashboard *Layout* pane, which will open a pop-up window where you can fully configure a new theme.

#### Dashboard Gateway \[ID_27558\]

A new Dashboard Gateway now gives users access to the Dashboards app as well as to all other DataMiner web applications (Monitoring, Ticketing, Jobs, etc.) even if they do not have access to DataMiner.

There are two main reasons to consider a Dashboard Gateway setup:

- Security

  Users are allowed to connect to the Dashboard Gateway, but not to the DataMiner Agents directly. Also, it is possible to install only the web applications on the Dashboard Gateway web server(s) to which you want users to have access. If you only install the Dashboards and the Monitoring app, users will not be able to access the Jobs app, the Ticketing or any other app.

- Performance

  Allowing multiple users to connect to the web applications increases the overall load on the DataMiner Agents. When using a Dashboard Gateway, the direct load of the web applications and the HTTP requests shifts to a separate web server, leaving more resources available on the DataMiner Agents. Also, if more performance is needed, multiple Dashboard Gateway web servers can be used in combination with a load balancer.

Requirements:

- At least one web server (running Windows Server)
- A valid SSL certificate signed by a public certificate authority for the FQDN of the Dashboard Gateway (e.g. “gateway.mycompany.com”)
- A DataMiner user account with

  - access to all views, elements and alarms,
  - permission to access the Alarm Console and Data Display, and
  - permission to create, edit and delete dashboards.

- The Dashboard Gateway web server(s) should be able to communicate with a DMA using both a .NET Remoting connection and an HTTP(S) connection (using port 80 or 443, depending on the HTTP(S) configuration of the DataMiner Agent)

Configuration:

1. On the Dashboard Gateway web server(s), install IIS and the URL Rewrite module.

   For IIS, make sure to install Classic ASP, ASP.NET 4.6+, and the WebSocket protocol.

1. In IIS Manager, import the certificate, and update the site binding to use HTTPS with this certificate.

1. Configure URL Rewrite to forward all HTTP traffic to HTTPS

1. From a DataMiner Agent, copy the C:\\Skyline DataMiner\\Webpages\\API folder to the web root folder of the Dashboard Gateway web server (default: C:\\inetpub\\wwwroot) and, in IIS Manager, convert the API into an application.

1. From a DataMiner Agent, copy over the web application(s) (e.g. C:\\Skyline DataMiner\\Webpages\\Dashboard, C:\\Skyline DataMiner\\Webpages\\Monitoring, C:\\Skyline DataMiner\\Webpages\\Jobs, C:\\Skyline DataMiner\\Webpages\\Ticketing, etc.) to the web root folder of the Dashboard Gateway web server.

1. On the Dashboard Gateway web server, edit the web.config in the API folder, and specify the following settings:

   | Setting          | Description                                                                                                              |
   |--------------------|--------------------------------------------------------------------------------------------------------------------------|
   | connectionString   | Host name or IP address of the DataMiner Agent to which the Dashboard Gateway has to connect.                            |
   | connectionUser     | DataMiner user account that the Dashboard Gateway has to use to connect to the DataMiner Agent (user name and password). |
   | connectionPassword |                                                                                                                          |

Known limitations:

- The URL folder structure of the web applications should remain the same as on a DataMiner Agent. The applications have to be accessed using the following URL:

  - <https://gateway.somecompany.com/dashboard>
  - <https://gateway.somecompany.com/monitoring>
  - <https://gateway.somecompany.com/ticketing>
  - <https://gateway.somecompany.com/jobs>

- The DataMiner user account used by the Dashboard Gateway web server should not have multi-factor authentication enabled.

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

#### Dashboards app - Parameter feed: 'Auto-select all' option \[ID_27816\]\[ID_28033\]

When configuring the Parameter feed, up to now, it was possible to either have a specific number of indices selected automatically or have all indices selected automatically.

- Auto-select number of indices

- Auto-select all indices

Now, the above-mentioned options have been replaced by the “Auto-select all” option. When this option is selected, all items will be selected according to the "Select all behavior" settings below it:

- If you select the “Select all items” option, "Select all" will select all items. For a partial table, only the items from the first page will be selected.

- If you select the “Select specific number of items” option, a box is displayed below it. In this box, you should specify how many items "Select all" should select. For a partial table, these items will be selected across different pages.

#### Dashboards app - Line chart component: New 'Chart limit behavior' setting \[ID_27841\]

When configuring a line chart component, you can now use the *Chart limit behavior* setting to indicate what needs to happen when the number of parameters in the chart exceeds the defined chart limit:

| Option                       | Behavior                                                                                                                                                                             |
|------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Disable parameters in legend | The excess parameters are disabled in the chart but remain available in the chart legend, so that they can be enabled again manually. This option is selected by default.       |
| Create additional charts     | Additional charts are displayed that include the parameters that exceed the limit. If necessary, multiple additional charts will be displayed, each respecting the configured limit. |

#### Dashboards app - Pivot table component: Sort ascending/descending \[ID_27862\]

When configuring a pivot table component, you can now find the following settings in the Sort section of the Settings tab:

| Setting        | Description                                                                                                                           |
|----------------|---------------------------------------------------------------------------------------------------------------------------------------|
| Sort           | Allows you to select a protocol (if the pivot table contains multiple protocols) and a parameter by which the table should be sorted. |
| Sort ascending | Determines the order in which the pivot table is sorted. If you clear this checkbox, it is sorted in descending order.           |

> [!NOTE]
> Using these sort settings in conjunction with the *Limit* setting in the *Configure indices* section, you can produce a top X or bottom X list.

#### Dashboards app - GQI: Queries will now be saved in a separate JSON file and will be referred to using a GUID \[ID_28088\]

From now on, queries will no longer be saved in a dashboard, but in a separate file named Queries.json, located in C:\\Skyline DataMiner\\Generic Interface. Dashboards using a query will then link to it using a GUID.

#### Dashboards app - GQI: Existing queries can now be reused \[ID_28102\]

When building a query, instead of having to start a new query from scratch, it is now possible to select an existing query in the *Start from* box, and then start building a query based on the one you selected.

Current limitations:

- Changing a query will not trigger a revalidation of the queries that are using the updated query. A component will only re-fetch a query when the dashboard is refreshed or when the final query is changed.

- If queries are running in a loop, a circular dependency error will be displayed.

#### Dashboards app - GQI: Data sources now have a default column set \[ID_28103\]

Each of the different data sources now has a default column set, which, if necessary, can be extended with every possible column in that data source by adding column selector nodes to the query.

| Data source        | Default column set                                                 |
|--------------------|--------------------------------------------------------------------|
| Alarms             | Visible columns in the Alarm Console of the Monitoring app.        |
| Parameter tables   | Visible columns of the table definition in the protocol (max. 10). |
| Profile definition | Parameters in the profile definition (max. 10).                    |
| Ticketing          | Fields displayed in the Ticketing app’s list view (max. 10).       |

> [!NOTE]
> All columns, even those that are not visible in the current data table, can be used by the operators. For example, you can filter data by a column that is not visible in the data table.

#### Dashboards app - Bar chart component: Enhancements \[ID_28461\]

A number of enhancements have been made to the bar chart component.

##### Two additional chart layouts

There are now four chart layouts to choose from:

| Chart layout                                             | Description                                                                |
|----------------------------------------------------------|----------------------------------------------------------------------------|
| Absolute                                                 | Shows the absolute value.                                                  |
| Relative per category (new)                          | Shows the value as a percentage of all the variables within that category. |
| Relative per variable (previously called “Relative”) | Shows the value as a percentage of the variable across all categories.     |
| Relative total                                           | Shows the value as a percentage of the total sum of all values.            |

##### Stacked bars

If you select the *Stack bars* option, the bars in the graph will be displayed one on top of the other instead of one next to the other.

> [!NOTE]
> This option will be especially useful in combination with the “Relative per category” chart layout.

##### Additional highlighting possibilities

Apart from highlighting all bars belonging to a specific variable, you can now also highlight a single category by hovering over the label of the category or by hovering over empty space in a stacked bar chart.

#### Dashboards app - GQI: Exception values will now be processed as discrete values \[ID_28570\]

In GQI operators, up to now, exception values were processed as regular values. From now on, they will be processed as discrete values. As a result, the TopX operator and the following aggregation methods will no longer take them into account:

- Average
- Max
- Min
- Percentile
- Standard deviation
- Sum

> [!NOTE]
>
> - The *Count* and *Distinct count* aggregation methods will take exception values into account.
> - Exception values will not be taken into account when calculating the minimum and maximum value for columns using GenIfColumnFetch-Requests.

#### Dashboards app - Bar chart component: Negative values & Dynamic axis labels \[ID_28617\]

The bar chart component now supports negative values.

Also, the number of axis labels displayed will now depend on the size of the chart. Up to now, a fixed number of axis labels would be displayed.

#### Dashboards app - State component: Alignment setting \[ID_28633\]

The layout pane of a State component now has an additional setting that allows you to align its contents (left/center/right).

Also, in the components pane on the left, the *States* section has now been renamed to *States and values*.

#### Dashboards app - GQI: Availability of the database will first be checked before querying an Elasticsearch database \[ID_28742\]

From now on, when GQI queries are about to fetch data from an Elasticsearch database, the availability of that database will first be checked.
