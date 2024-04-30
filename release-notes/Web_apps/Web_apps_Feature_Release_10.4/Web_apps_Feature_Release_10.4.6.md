---
uid: Web_apps_Feature_Release_10.4.6
---

# DataMiner web apps Feature Release 10.4.6 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.6](xref:General_Feature_Release_10.4.6).

## Highlights

*No highlights have been selected yet.*

## Breaking changes

#### Low-Code Apps: Selection of DOM instances will now be passed to a script as an array [ID_39391]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

Up to now, when you selected multiple DOM instances in a table (while holding the SHIFT button pressed) and then executed a script that used the feeds of those DOM instances as input parameters, only the first DOM instance you selected would be passed to the script. From now on, an array containing all selected DOM instances will be passed to the script.

## New features

#### Low-Code Apps: Parameter table filter feeds are now also supported [ID_39335]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

Low-code apps now also support parameter table filter feeds if the URL option `showAdvancedSettings=true` is used.

This type of filter supports both VALUE and FULLFILTER syntax. For more information on this syntax, see [Dynamic table filter syntax](xref:Dynamic_table_filter_syntax).

> [!NOTE]
> You can use feeds found either on the same page or on another page.

#### Dashboards app & Low-Code Apps - Node edge graph component: New configuration options [ID_39417]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When configuring the nodes and edges of a *Node edge graph* component, you now have a number of additional options.

##### Nodes

When configuring the nodes of a *Node edge graph* component, you can now configure the X and Y positions of those nodes. When, in the *Layout* tab, *Node positions* is set to "Linked as data", you can now set the following additional options:

- *X*: The query column containing the X positions of the nodes.
- *Y*: The query column containing the Y positions of the nodes.

Also, apart from an icon, you can now make node shapes show a particular custom image.

##### Nodes and/or edges

When configuring the nodes and/or the edges of a *Node edge graph* component, you can now enable or disable the following options:

- *Enable tooltip*: When the URL option *showAdvancedSettings=true* is used, you can use this option to specify whether or not a tooltip should appear when you hover over a node/edge.

- *Show metric*: When the URL option *showAdvancedSettings=true* is used, you can use this option to specify whether the nodes/edges should be highlighted with their conditional color.

#### Dashboards app & Low-Code Apps - Line & area chart component: Showing multiple lines on multiple Y axes [ID_39509]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When a *Line & area chart* component visualizes GQI data, it is now able to show multiple lines on multiple Y axes.

In the *Layout* tab, you can find the following settings to configure this:

- *X axis*: Allows you to rename the default X axis.

  This name will be used as the X label in the tooltips.

- *Y axis*: Allows you to add and rename Y axes.

  - You can add up to 10 Y axes to a single chart.
  - The axis names will only be used to allow you to choose the correct axis.
  - By reordering the axes, you can determine the order in which they are added to the chart.

- *Lines*: Allows you to add lines that will be displayed on the chart.

  - You can add up to 20 lines to a single chart.
  - By reordering the lines, you can determine the order in which they are displayed on the chart and in the tooltip.
  - The lines inherit the colors specified in the color palette of the component or theme. When all colors are used, the first ones will be assigned again.

  For each line, the following settings can be configured:

  - *X axis column*: The numeric column that contains the X values of the line. The column can be taken from any query specified in the component.
  - *Y axis column*: the numeric column that contains the Y values of the line. The column can be taken from any query specified in the component.
  - *Y axis*: The Y axis that is used to plot the line.

- *Tooltips*: Allows you to enable/disable the tooltip and to configure what it will display.

  The tooltip is displayed when you hover over the chart. It shows the Y value(s) for the closest X value of any line on the chart. If multiple lines share an X value at the same pixel, both will be shown. The values shown in the tooltip will also be indicated on the chart with colored dots.

  Tooltip settings:

  - *Include X labels*: Include/exclude the X-axis labels (i.e. the X-axis names).
  - *Include Y labels*: Include/exclude the Y-axis labels (i.e. the Y-axis names).
  - *Include color*: Show a small indicator in front of the tooltip that indicates the color of the line.

It is now also possible to pan and zoom inside a *Line & area chart* component:

- To zoom, scroll while keep the CTRL key pressed (maximum 10,000 times).
- To pan, drag while keeping the right mouse button pressed (Only works when zoomed in since the default viewport shows all the data).

## Changes

### Enhancements

#### Web apps: Improved startup performance because of waffle menu enhancements [ID_39208]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

Because of a number of enhancements made to the waffle menu, overall performance has increased when opening a web app.

#### Dashboards app & Low-Code Apps - GQI: Requests that contain a query will now include the query name [ID_39324]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

If the following GQI requests contain a query, the Dashboards app and the low-code apps will now include the query name in those requests. This query name will be used in metrics and logging, and can be used to indicate the origin of the query.

- GenIfColumnFetchRequest
- GenIfDataFetchRequest
- GenIfOpenSessionRequest

The query name will be constructed as follows:

- `db/<dashboard name>/<queryGUID>`, or
- `app/<appGUID>/<queryGUID>`

#### Low-Code Apps - DOM: Booking field enhancements [ID_39333]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

Up to now, booking fields that do not support multiple values would only display the first 100 values, without any indication that not all values were shown. Similarly, booking fields that support multiple values would only display the first 500 values without any indication that not all values were shown.

From now on, when there are more than 100 values, a booking field will display the first 100 and will always indicate that not all values are shown, regardless of whether this field allows multiple values or not.

#### Dashboards app & Low-Code Apps - Spectrum analyzer component: Clearer indication that the component is busy loading [ID_39427]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

From now on, a *Spectrum analyzer* component will indicate in a clearer way that it is busy loading.

#### Dashboards app & Low-Code Apps - Alarm table component: Sliding window limits [ID_39484]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When an *Alarm table* component is configured to show alarms in a sliding window, from now on, you will be able to specify the following limits:

- Initial number of alarms (default: 10,000)
- Maximum number of alarms (from 1 to 100,000)
- Size of sliding window (from 1 minute to 1 day)
- Refresh rate of sliding window (from 1 minute to 1 day)

> [!NOTE]
> When setting the size or the refresh rate of the sliding window, it will no longer be possible to specify a value in seconds or milliseconds.

### Fixes

#### Dashboards app: 'DATA USED IN DASHBOARD' section would not be hidden when empty [ID_39274]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

Up to now, when a dashboard did not contain any components that used data, the *DATA* tab would incorrectly still contain a *DATA USED IN DASHBOARD* section.

From now on, when empty, the *DATA USED IN DASHBOARD* section will no longer be displayed.

#### Web app - Interactive Automation scripts: Options of a UI control would incorrectly overlap other dialog box items [ID_39289]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When, in a dialog box of an interactive Automation script, a UI control had a large number of options, in some cases, those options would overlap other items on the dialog box.

From now on, UI controls options will be listed in a scrollable region. As a result, they will no longer overlap other dialog box items.

#### Dashboards app & Low-Code Apps - Template editor: Save button would not become available when you enabled a setting in an override [ID_39290]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When, after adding an override, you saved and re-opened the template editor, the *Save* button would not become available when you enabled one of the settings in the override. The *Save* button would incorrectly only become available after you had changed the value of the setting you enabled.

#### Dashboards app & Low-Code Apps - Template editor: Save button would incorrectly be available when opening the template editor [ID_39297]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When you made a change in the template editor, saved the template, and opened the editor again, up to now, the *Save* button would incorrectly be available. When you then closed the template editor without making any changes, a popup window would appear, saying that there were unsaved changes.

From now on, when you open the template editor, the *Save* button will be unavailable by default. Only after have made a change will this button become available.

#### Dashboards app - Time range component: Custom quick pick buttons would no longer be visible after you had refreshed the dashboard [ID_39298]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When a *Time range* component had custom quick pick buttons configured, up to now, those buttons would no longer be visible after you had refreshed the dashboard using the *Refresh* button in the dashboard subheader.

#### Dashboards app & Low-Code Apps - Node edge graph component: Data would incorrectly get fetched multiple times [ID_39299]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When a *Node edge graph* component contained multiple queries, including one that was linked to a feed, in some rare cases, the data would incorrectly get fetched multiple times.

Also, when a *Node edge graph* component was rendered for the first time, the edge arrows would incorrectly not appear.

#### Dashboards app & Low-Code Apps - Line & area chart component: Problem when displaying trend data of aggregation parameters [ID_39300]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

In some cases, trend charts would not display trend data of aggregation parameters correctly. The labels would be incorrect and all trend lines would have the same color.

Also, a minor legend issue has now been fixed.

#### Dashboards app: Problem with web APIs when adding or removing multiple dashboards simultaneously [ID_39304]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When multiple dashboards were added or removed simultaneously, in some cases, the web APIs could become unresponsive.

#### Dashboards app: Not all data sets would show a counter [ID_39311]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

In the *All available data* section of the *Data* tab, not all data sets would show a counter.

#### Dashboards app & Low-Code Apps - Column & bar chart and Pie & donut chart components: Problem when refetching data that was being fetched [ID_39312]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

In some cases, a `Request was aborted` error could appear when a *Column & bar chart* component or a *Pie & donut chart* component refetched data while that same data was being fetched.

#### Dashboards app & Low-Code Apps: Component settings would not be updated correctly [ID_39322]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When you were editing a component, in some cases, the *Layout* and *Settings* panes would not get updated correctly when, for example, you removed data.

From now on, both panels will be updated correctly, and will only show settings that are available.

#### Dashboards app & Low-Code Apps - Time picker: 'Now' button would round off time values incorrectly [ID_39323]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When, in the time picker, you clicked the *Now* button, in some cases, the time value would be rounded off incorrectly. When the current time was e.g. 10:58, the time would be rounded off to 10:00 instead of 11:00.

#### Low-Code Apps: 'View published app' button would no longer be displayed when editing an app that had been published previously [ID_39339]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When you were editing an app that had already been published previously, the *View published app* button would incorrectly no longer be displayed.

#### Dashboards app & Low-Code Apps - Table component: A 'No results for applied filter' message would appear when you applied a filter while the data was still loading [ID_39340]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When, in a *Table* component, you applied a filter while the data was still loading, a `No results for applied filter` message would appear.

#### Dashboards app - Gauge component: Icon would have an incorrect background color [ID_39375]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

In some cases, the dashboard theme would not be applied correctly to the icon inside a *Gauge* component. The icon would have an incorrect background color.

#### Dashboards app & Low-Code Apps: Errors mentioning caching problems could occur when you created a dashboard or a low-code app [ID_39437]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

In some cases, a large number of errors mentioning caching problems could occur when you created a dashboard or a low-code app.

#### Dashboards app & Low-Code Apps - Time range component: Minor issues [ID_39458]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

The following minor issues regarding the *Time range* component have been fixed:

- The option *Layout > Advanced> Layout & Alignment > Align current time position* would no longer be visible.

  From now on, the option *Layout > Advanced> Layout & Alignment > Align current time position* will be visible when the option *Layout > Advanced > Show current range* is enabled.

- The option *Layout > Advanced > Layout & Alignment > Show refresh timer* would always be visible, but would have no effect when the option *Settings > General > Allow refresh* was disabled.

  From now on, the option *Layout > Advanced > Layout & Alignment > Show refresh timer* wil only be visible when *Settings > General > Allow refresh* is enabled.

- When, in the *Layout > Advanced* section, you had only selected quick picks from the *Starting from now*, **Near future* and *Distant future* categories, the *Time range* component would incorrectly show `No quick picks have been selected`.

#### Dashboards app & Low-Code Apps: Page would incorrectly scroll when you clicked a Grid, Service definition or Node edge graph components [ID_39463]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When you clicked a *Grid*, a *Service definition* or a *Node edge graph* component, in some cases, the page would incorrectly scroll until the component was at the top of the window.

#### Dashboards app: Problem when sharing a dashboard in which certain query nodes had been linked to feeds [ID_39465]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

In some cases, an error could occur when you shared a dashboard in which e.g. a *Get Parameters for element where* query node had been linked to a feed.

#### Dashboards app & Low-Code Apps: GUIDs would incorrectly be visible in the query builder [ID_39467]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

In some cases, GUIDs would incorrectly be visible in the query builder, even when properly resolved.

#### Dashboards app & Low-Code Apps - Table component: Random cell values would incorrectly be displayed when data was being loaded [ID_39476]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When data was being loading into a *Table* component, in some cases, random cell values would incorrectly be displayed inside the table. From now on, a *Table* component will only show data when it has finished loading all data.

#### Low-Code Apps: Deleting a context menu action would incorrectly not be saved [ID_39488]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

When you opened the edit mode, deleted a context menu action, and immediately exited the edit mode, up to now, this deletion would incorrectly not be saved.
