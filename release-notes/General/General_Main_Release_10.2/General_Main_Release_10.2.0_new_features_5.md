---
uid: General_Main_Release_10.2.0_new_features_5
---

# General Main Release 10.2.0 - New features (part 5)

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!NOTE]
> A DataMiner Installer v10.2 is available on [DataMiner Dojo](https://community.dataminer.services/download/dataminer-installer-v10-2/).
>
> - For 64-bit systems only.
> - No longer contains the necessary files to install MySQL.
> - Unattended cluster installation is not supported.
> - On Windows Server 2022, an “Internal server error” is thrown after installation. Workaround:
>   - Go to <https://www.iis.net/downloads/microsoft/url-rewrite>.
>   - Download and install the URL rewrite module.
>   - Go to <http://localhost/root> and verify whether the root page is shown.

### DMS Reports & Dashboards

#### Dashboards app: New 'view parameters' representing aggregation rules \[ID_28955\]

For the line chart, state, and ring visualizations, you can now use view parameters as a data source. These represent active aggregation rules on a specific view.

To select this new data source, in the drop-down box for the “parameter” data source, select “View”. The different available view parameters, corresponding with the aggregation rules configured in your system, will then be displayed.

You can combine these view parameters with other types of parameters in the same component. However, you can only group them together with other parameters using the "Group by" option "All together". If you group by element, parameter or index, the view parameters will be placed in a separate group. For view parameters, the view name is displayed instead of an element name, and the aggregation rule name is displayed instead of a regular parameter name.

#### Dashboards app - GQI: New 'DCF connections' data source \[ID_25827\] \[ID_26491\] \[ID_26744\] \[ID_29505\] \[ID_29703\]

In the Generic Query Interface, a new “DCF connections” data source is now available. It will return all DCF connections in the DMS.

> [!NOTE]
>
> - The “Is Internal” column indicates whether a connection has been marked internal (i.e. virtual) or external (i.e. physical).
> - External connections are configured both on the source element and the destination element. Hence, each external connection will be listed twice.
> - Connections of which both the source element and the destination element are stopped will not be listed.
> - Connections of which only the destination element is stopped will be listed once.

#### Dashboards app: Alarm table component \[ID_27790\] \[ID_28012\] \[ID_28142\] \[ID_28519\] \[ID_28718\] \[ID_28887\] \[ID_29131\] \[ID_29456\]

A new alarm table component is now available in the Dashboards app. It can be used to display a list of active alarms, masked alarms, history alarms, alarms in a sliding window, or information events.

Multiple component settings are available:

- Selection of type of alarm list.
- Filter configuration, including index filters using wildcards, and saved alarm filters.
- Default sorting column, default sorting order and number of alarms to load.
- Displayed columns and their order.
- Grouping by a specific column.
- “Expand on hover” layout option.

You can also add different data filters to the component, such as element or view data filters, or parameter feed or time range feed filters. If a parameter index data filter is used, a setting allows you to determine whether the index should match the filter or contain the filter.

#### Dashboards app: Trigger feed \[ID_28136\]

You can now add a trigger feed to a dashboard. This is a feed that allows you to trigger other components either manually or automatically.

Currently, the trigger feed can only be linked to components that can visualize a database query. In that case, when a trigger feed is triggered, the data displayed in the other component will be refreshed.

##### Settings

When, in the *Settings* tab, you enable the *Trigger timer* setting, a countdown bar will be displayed, and triggering will occur automatically when the counter reaches 0. The *Time* setting allows you to specify a counter interval (default: 60 seconds).

##### Layout

In the *Layout* tab, you find three additional sections:

- In the *Trigger label* section, you can specify a label and select an icon that will both be displayed on the trigger button.

- In the *Time label* section, select the *Show when the last trigger happened* option if you want the time of the last triggering displayed. When this option is selected, in the *Time description format* box, you can enter the message to be displayed. It can contain the following placeholders:

    | Placeholder | Description                                                                                                       |
    |---------------|-----------------------------------------------------------------------------------------------------------------|
    | {duration}    | An estimated indication of the time past since the last triggering. Example: “2 minutes ago”.                   |
    | {time}        | The exact textual representation of the time when the last triggering occurred. Example: “Nov 20, 2020, 12:33”. |

- In the *Layout* section, you can specify how you want the trigger label and time label to be aligned: left, center or right.

#### Dashboards app: Right-hand edit pane is now resizable \[ID_28137\]

It is now possible to change the width of the right-hand edit pane.

#### Dashboards app - Line chart component: New option to highlight parameters on graph and legend \[ID_28144\]

When configuring a line chart component, in the *Styling and Information* section of the *Layout* tab, you can now find the *Highlight lines on hover* option. This option enables users to highlight lines on a trend graph.

When you select the *Highlight lines on hover* option, which is cleared by default, you can also specify the thickness of the highlighted lines (default: 3 px).

There are two ways to highlight a trend line:

- Hovering over the trend graph.
- Expanding the legend and hovering over a parameter name.

#### Dashboards: Deleting components by pressing the DELETE key \[ID_28171\]

In the Dashboards app, up to now, it was possible to delete components in edit mode by selecting them and clicking the *Delete* button at the top of the page. Now, instead of clicking the Delete button, it is also possible to press the DELETE key on your keyboard.

> [!NOTE]
> After selecting the component to be deleted, make sure the focus is on the dashboard before you press the DELETE key. If the focus in on e.g. the header bar or the subheader bar, pressing the DELETE key will not work.

#### Dashboards app: Restricting access to dashboards \[ID_28345\]

From now on, when you create or import a new dashboard, you will be able to restrict access to it by specifying one of the following security levels:

| Security level | Description |
|----------------|-------------|
| Public         | Every user is allowed to view, edit and share the dashboard. |
| Protected      | Every user is allowed to view the dashboard, but only the user who created it is allowed to edit or share it. |
| Private        | Only the user who created the dashboard is allowed to view and edit it. Note: In the Automation app, it will not be possible to attach private dashboards to report emails. |

> [!NOTE]
>
> - When users with edit permission are editing a dashboard, they will now be able to indicate which users are allowed to view and/or edit that dashboard.
> - Users will not be able to rename or delete a dashboard folder when it contains dashboards they are not allowed to edit.
> - By default, the built-in Administrator account is allowed to view and edit all dashboards.
> - Existing dashboards created in earlier DataMiner versions will remain accessible to all.

#### Dashboards app: Parameter table filters \[ID_28539\]

In line chart components, it is now possible to configure a parameter table filter that will allow you to filter out specific rows.

Currently, two types of filters can be configured: VALUE and FULLFILTER. Built-in Intellisense will help you construct the filter.

Examples:

- value=PK == 1
- value=DK==Izegem
- value=518==5;value=522>=10
- fullfilter=(value=PK ==1 or value=PK ==2)
- fullfilter=((value=PK \> 36) and (value=518 in_range 1/5 )) or (VALUE=DK == Brus\*)

> [!NOTE]
>
> - Currently, only line chart components support the use of parameter table filters.
> - Parameter table filters can only be configured when you have started the Dashboards app with the *showAdvancedSettings* URL parameter set to true.
> - When you update a filter, you have to re-add it to the component.

#### Dashboards app - Table component: GQI query result can now be export to a CSV file \[ID_28637\]

When a table component displays the result of a GQI query, it is now possible to export that result to a CSV file.

To do so, click the ellipsis icon in the upper-right corner and select *Export to CSV*.

By default, the CSV file will be named “Query XXX” (XXX being the name of the query). If necessary, the name of the query can be changed in the *Queries* section in the table component’s data panel.

The first line of the CSV file will contain the names of the columns. The subsequent lines will contain the data, each line being a row of the query result. This data will contain the display values, not the raw values. This means that parameter values will contain units and that discrete values will be replaced by their corresponding display value.

By default, all rows of the query result will be exported. If you want to export only a subset, first select the rows to be exported and then click *Export to CSV*.

If you only want to export specific columns, you can drag those columns from the data panel onto the component before you export the data.

#### Dashboards app - Line chart component: Trend graph will now display the actual name of a profile parameter \[ID_28657\]

When, in the Dashboards app, you add a profile parameter to a line chart component, from now on, the label of its trend line will now display the actual name of the profile parameter instead of the name of the underlying parameter that is associated with it.

#### Dashboards app: State component now also supports protocol data and indices \[ID_28688\]

The state component now supports all possible data types, including protocol data and indices.

Also, the Layout pane of this component has been enhanced.

#### Dashboards app: New Views data source for generic query interface \[ID_28707\]\[ID_28877\]

The generic query interface now features a new *Views* data source, which can be used to retrieve all the views in the DataMiner System. For each view, the View ID and Name columns are retrieved by default. The following columns can also be retrieved by means of an additional column filter:

- Parent view ID
- Last modified
- Last modified by
- Enhanced element ID
- Custom view property columns

#### Dashboards app: Service Definition components now accept services as data sources \[ID_28746\]

In the Dashboards app, service definition components now accept services as data sources.

When you drag a service onto a service definition component, by default, the component will display the service definition and the bookings of that service.

If necessary, you can apply a filter by specifying a time range. If you do not specify a time range, the component will display the current booking.

> [!NOTE]
> From now on, it is no longer possible to filter a service definition component when its data source is either a booking or a service definition.

#### Dashboards app - GQI: Using a feed as a column filter \[ID_28770\]

When building a GQI query, it is now possible to use a feed as a column filter.

Instead of providing a fixed value to filter a specific column, you can now select the *From feed* option and configure a filter by specifying the following items:

| Filter item | Description                                                                                                                |
|-------------|----------------------------------------------------------------------------------------------------------------------------|
| Feed        | The name of the feed that will provide the data. If only one feed is available, it will automatically be selected.         |
| Type        | The type of data that needs to be selected. If the feed only provides one type of data, it will automatically be selected. |
| Property    | The property by which the column will be filtered (depending on the type of data).                                         |

Example: If the column in question has to be filtered using the element name found in the URL of the dashboard, then you can set *Feed* to “URL”, *Type* to “Elements” and *Property* to “Name”.

#### Dashboards app - GQI: New 'View relations' data source \[ID_28797\]\[ID_28877\]

In the Generic Query Interface, a new “View relations” data source is now available. It contains all DataMiner objects that are part of a view.

Each row in this data source has the following columns:

| Column   | Description                                                                 |
|----------|-----------------------------------------------------------------------------|
| View ID  | The ID of the view.                                                         |
| Child ID | The ID of the DataMiner object in the view.                                 |
| Depth    | The level of the DataMiner object in the view tree in relation to the root. |

When you set the *Recursive* option to true, the table will not only contain all direct relationships (i.e. between a parent item and a child item), but also all indirect relationships (e.g. between a grandparent item and a grandchild item).

#### Dashboards app: Existing GQI queries stored in Queries.json will now automatically be copied to the correct dashboard files during a DataMiner upgrade \[ID_28816\]

As from DataMiner main release version 10.1.0 and feature release version 10.1.3, GQI queries are stored in the dashboards instead of a separate *Queries.json* file, located in the *C:\\Skyline DataMiner\\Generic Interface\\* folder.

When you upgrade to DataMiner main release version 10.2.0 or feature release version 10.1.4, any existing GQI queries that are still stored in the Queries.json file will now automatically be copied to the correct dashboard files.

#### Dashboards app - GQI: Records in views, services and elements data sources now contain metadata that will allow views, services and elements to act as feeds \[ID_28891\]\[ID_28940\]

All records in the views, services and elements data sources will now contain metadata that will allow a view, a service or an element to act as a feed when a table row referring to that view, service or element is selected.

#### Dashboards app - State, Gauge and Ring components: Enhancements \[ID_28984\]

A number of enhancements have been made to the Gauge and Ring components:

- As to the Ring component, labels are now displayed underneath the ring.

- The Gauge and Ring components can now display the configured range (minimum and maximum value). Also, it is now possible to configure a custom range in each of those components.

- The Gauge and Ring components are now more in line with the State component. When configuring these components, it is now possible to select one of three designs (small, large and autosize) and to specify the alignment (left, center and right).

#### Dashboards app - GQI: Importing a query from another dashboard into the current dashboard \[ID_28907\]\[ID_29022\]

It is now possible to import queries from another dashboard into the current dashboards.

1. In the *Queries* section of the *Data* pane, click the *Import* button.

2. In the *Import Query* window,

    - select the dashboard containing the query,
    - select the query,
    - if necessary, change the name of the query, and
    - click *Import*.

> [!NOTE]
> If you import a query that uses other queries, all those queries will be merged into one single query that will then be imported into the current dashboard.

#### Dashboards app: Sharing dashboards with other users via the DataMiner Cloud \[ID_29047\] \[ID_31476\]

It is now possible to share dashboards with other users via the DataMiner Cloud.

##### Prerequisites

- The DataMiner Cloud Pack must be installed on the DataMiner Agent.
- The DataMiner Agent must be connected to the DataMiner Cloud.
- To be able to share items, users must have the following permissions:

  - Modules \> Reports & Dashboards \> Dashboards \> Edit
  - General \> Live sharing \> Share
  - General \> Live sharing \> Edit
  - General \> Live sharing \> Unshare

##### To share a dashboard

1. In the Dashboards app, go to the list of dashboards on the left, and select the dashboard you want to share.

1. Click the “...” button in the top-right corner of the dashboard, and select *Start sharing*.

1. If it is the first time you are sharing the dashboard, you may be asked to confirm that you want to link your account to the cloud. Select *I want to link the above users* and click *Link accounts*.

1. In the pop-up window, fill in the email address of the person you want to share the dashboard with.

1. Optionally, in the *Message* field, add a message you want to send to the person you are sharing the dashboard with, in order to provide additional information.

1. If you do not want the dashboard to remain permanently available, select the *Expires* option and specify the expiration date.

1. Click *Share*. An email will be sent to the person you are sharing the dashboard with, to inform them that they now have access to the dashboard.

> [!NOTE]
>
> - If access to a dashboard is limited to some users only, it will not be possible to share this dashboard.
> - You can stop sharing a dashboard by clicking the “...” button again and selecting *Manage share*. This will open a pop-up box where you can delete the share or update the message.
> - At present, sharing dashboards that use the following components is not supported: spectrum components, Maps, SRM components (service definition and resource usage line graph), queries using feeds and visualizations based on query feeds (e.g. node edge graph, table), trend components with subscription filters and pivot table components. If you attempt to share a dashboard with content that is not supported for sharing, a message will be displayed with more information.

##### To access the Sharing module that lists the dashboards that others have shared with you

1. Open an internet browser (other than Microsoft Internet Explorer), go to <https://dataminer.services/>, and sign in.

1. On the dataminer.services landing page, click *Sharing*.

   You will now see all data that others have shared with you.

> [!NOTE]
> When somebody has shared a dashboard with you, you will receive an email informing you of this. You can then click the link in the email to immediately access the dashboard, provided that you already have a dataminer.services account.

##### Security layers

- User authentication via Microsoft B2C login.

- For every shared dashboard, a dedicated “Cloud-connected Agent” user (CCA user) is created on the DataMiner Agent. This user only has permission to view the data shown on the dashboard and nothing else.

- The DataMiner Web Services API now has a Web Application Firewall. Each time a CCA user calls a particular web method, this firewall will check whether that CCA user is allowed to do so.

- Detailed logging is stored in *C:\\Skyline DataMiner\\logging\\Web* and Dashboards Sharing SPI metrics are published.

> [!NOTE]
> In the list of users and groups in System Center, there is a separate section for dataminer.services users and groups. These also have their own icon, so the distinction with regular users and groups is more clear.
>
> As dataminer.services users and groups are entirely managed by DataMiner, they cannot be modified.

#### Dashboards app - Service definition component: Node scaling \[ID_29142\]

In the service definition component, nodes will now have a fixed initial size and ratio. When the service definition does not fit inside the component, vertical and/or horizontal panning will be enabled depending on the direction that is clipped. For example, when a service definition is very wide and its nodes are clipped on the right-hand side, horizontal panning will be possible, but vertical panning will not. Also, zooming in and out will fully scale the nodes so that every-thing keeps its aspect ratio.

> [!NOTE]
> The zoom controls in the bottom-right corner have been removed.

#### Dashboards app - GQI: Linking a \[Get parameters for elements where\] 'Protocol' filter to a parameter feed \[ID_29335\]

After selecting a \[Get parameters for elements where\] “Protocol” filter, you can now link this filter to a parameter feed.

To do so, select the *Use feed* option, and select one of the available parameter feeds from the list. The parameters from that feed will then be added to the query.

#### Dashboards app - GQI: Linking a filter to an index feed \[ID_29338\]

After selecting a filter, you can now link this filter to an index feed.

To do so, select the *Use feed* option, and select one of the available index feeds from the list.

#### Dashboards app - GQI: Linking a \[Get parameter table by ID\] 'DataMiner ID' 'Element ID' filter to a parameter feed \[ID_29351\]

After selecting a \[Get parameter table by ID\] “DataMiner ID” “Element ID” filter, you can now link this filter to a parameter feed.

To do so, select the *Use feed* option, and select one of the available parameter feeds from the list. The first table parameter from that feed will then be added to the query.

#### Dashboards app - GQI: Linking a \[Get elements/services/views/view relations\] \> \[Select\] filter to a parameter feed \[ID_29360\]

After selecting a \[Get elements/services/views/view relations\] \> \[Select\] filter, you can now link this filter to a parameter feed.

To do so, select the *Use feed* option, and select one of the available parameter feeds from the list. The parameters from that feed will then be added to the query.

#### Dashboards app - GQI: Linking a time range filter to a time range feed \[ID_29367\]

Whenever you have to specify a time range when building a query, you can now link this time range filter to a time range feed.

To do so, select the *From feed* option, and select one of the available time range feeds from the list.

#### Dashboards app - GQI: Query filters configured to filter using a regular expression will now combine multiple feed values using 'OR' operators \[ID_29396\]

When a query filter using a feed is configured to filter using a regular expression, from now on, it will combine multiple feed values using “OR” operators.

#### Dashboards app: Node edge graph component \[ID_29425\]

The new node edge graph component allows you to visualize any type of objects (i.e. “nodes”) and the connections between them (i.e. “edges”). Moreover, by linking parameters and properties to those nodes and edges, you can turn a node edge graph into a full-fledged analytical tool that shows real-time alarm statuses and KPI data using dynamic coloring.

The data necessary to create a node edge graph can to be provided by means of GQI queries. Node queries provide data that will be visualized as nodes (i.e. objects), whereas edge queries provide data that will be visualized as edges (i.e. connections between objects).

For more detailed information, see [Node edge graph](xref:DashboardNodeEdgeGraph).

#### Dashboards app - GQI: Regular expressions in column filters will now be converted to standard table filters \[ID_29458\]

From now on, when regular expressions with the following structure are found in column filters, they will be converted to standard table filters.

| Regular expressions with the following structure ... | will be converted to ...                                 |
|------------------------------------------------------|----------------------------------------------------------|
| ^(Value01\|Value02\|Value03)$                        | (XXX == Value01) OR (XXX == Value02) OR (XXX == Value03) |

#### Dashboards app: Enhanced data source counters in edit panel \[ID_29495\]

In the edit panel, up to now, the counter next to each data source would indicate the total number of draggable items in that data source that matched the applied filters. From now on, each data source counter will instead indicate the amount of items in the next level only.

Imagine a DataMiner Agent with the following view tree:

Root

- child 1

  - child 3
  - child 4

- child 2

  - child 5

From now on...

- the counter of the views data source will show “(1)”, i.e. the root, and
- the counter of the root view data source will show “(2)”, i.e. child view 1 and 2.

> [!NOTE]
> The counter of the parameters data source will show the total amount of parameters.

#### Dashboards app - GQI: Aggregated and manipulated columns now have metadata \[ID_29494\] \[ID_29514\]

Metadata will now be added to columns created by an aggregation or manipulation operation within the GQI environment. This metadata will provide information regarding the operation (aggregation or manipulation) and the columns involved.

#### Dashboards app - Line chart component: New 'Fill graph' and 'Stack trend lines' options \[ID_29527\]

When configuring a line chart component, you will now find two new options in the *Styling and Information* section of the *Layout* tab:

- **Fill graph**: When you select this option, the space underneath the line will be filled with the line color.
- **Stack trend lines**: When you select this option, all lines in a graph will be stacked on top of each other.

  > [!NOTE]
  > This option is not compatible with the *Show min/max shading*, *Show minimum*, and *Show maximum* options. When you select the *Stack trend lines* option, those options will be disabled and hidden.

Also, the following chart components have been renamed:

| Old name   | New name           |
|------------|--------------------|
| Bar chart  | Column & bar chart |
| Line chart | Line & area chart  |
| Pie        | Pie & donut chart  |

#### Dashboards app - GQI: New filter node option 'Return no rows when feed is empty' \[ID_29557\]

When, in the Data tab, you add a filter node to a GQI query, a new option named “Return no rows when feed is empty” will allow you to specify what should be returned when the filter yields no rows.

- When you enable this option, an empty table will be returned when the filter yields no rows.
- When you disable this option, the entire table (i.e. all rows) will be returned when the filter yields no rows.

#### Dashboards app: State, Gauge and Ring components can now be used as feeds by other components \[ID_29570\] \[ID_29650\] \[ID_29657\] \[ID_29708\]

The State, Gauge and Ring components can now be used as feeds by other components.

In other words, components using a State, Gauge and Ring component as a feed will now be able to ingest data (element, redundancy group, service, view, protocol, index) selected in that State, Gauge or Ring component.

> [!NOTE]
>
> - When a State, Gauge or Ring component is used as a feed, the data selected will be highlighted.
> - A State component can even be used by other components as a GQI data feed.

#### Dashboards app: New Progress bar component \[ID_29773\]

A new *Progress bar* component is now available among the state components in the Dashboards app. It can be used to display the value of an analog parameter as a progress bar.

In the *Layout* tab for this component you can select to hide or display various labels, such as the parameter name and value. You can also select whether the minimum and/or maximum value of the parameter should be displayed. Similar to other state components, you can also select a small or large design and, in case the component is used to display multiple parameters, you can select whether the parameters should be displayed in rows or columns.

In the *Settings* tab, you can specify a custom minimum and/or maximum value.

#### Dashboards app - GQI: Fetching query results page by page \[29801\] \[29858\] \[29898\]

GQI query results can now be fetched page by page.

Before executing a query, the system will send a GenIfOpenSessionRequest message to open a session. That request will return a session ID that then has to be passed along with a series of GenIfNextPageRequest messages to fetch the next pages. Finally, a GenIfCloseSessionRequest message will be sent to close the session.

> [!NOTE]
>
> - A new session must be opened for each query that has to be executed.
> - When a session is opened/used, a timestamp will be added/updated. This timestamp will be used to check whether a session has expired. Sessions can be kept alive by sending a GenIfSessionHeartbeatRequest message.

##### Overview of the request messages

- **GenIfOpenSessionRequest**: Opens a session.

  Properties:

  - Query
  - QueryOptions

- **GenIfNextPageRequest**: Fetches the next page.

  Properties:

  - SessionID (Guid)
  - PageSize (int)

- **GenIfCloseSessionRequest**: Closes a session.

  Properties:

  - SessionIDs: Guid\[\]

- **GenIfSessionHeartbeatRequest**: Prevents a session from expiring.

  Properties:

  - SessionIDs: Guid\[\]

- **GenIfGetOpenSessionsRequest**: Returns a response containing a list of all open sessions, together with the following properties:

  - SessionID (Guid)
  - CreationTime
  - LastUpdated

##### Variables

| Variable                                                                               | Default value    |
|----------------------------------------------------------------------------------------|------------------|
| Maximum concurrent sessions                                                            | 500              |
| Time before a session is expired (without receiving heartbeat/update for that session) | 5 minutes        |
| Internal check cycle if a session is expired                                           | Every 30 seconds |
| Minimum pageSize (rows)                                                                | 1                |
| Maximum pageSize (rows)                                                                | 2000             |

#### Dashboards app - GQI: Linking columns with values of type double or datetime to feeds in query filters \[ID_29902\]

In GQI query filters, from now on, columns containing values of type datetime or double can be linked to feeds. This will allows you to e.g. filter a bookings list by linking the *End* column to a time range feed.

#### Dashboards app: Table visualizations now allow columns to be reordered \[ID_30091\]

In table visualizations, it is now possible to reorder columns.

To move a table column to another location, click its header and drag it to its new location.

#### Dashboards app: Column filter based on text in Node edge graph and Table component \[ID_30182\]

When you configure a column filter for a Node edge graph or Table dashboard component in order to highlight specific columns depending on the displayed value, you can now filter on specific text. Previously, it was only possible to apply a column filter on a selected range. Now, you can instead select the column you want to use for highlighting, and then specify text to filter on in a text box. You can then choose whether a positive or negative filter should be used, and whether the value should equal the filter, contain the filter or match a regular expression.

Multiple filters can be applied on the same value. In that case, the filters will be applied from the top of the list to the bottom. Positive filters will get priority over negative filters. You can also remove filters again by selecting No color.

#### Dashboards app - GQI: New 'Get alarms' data source \[ID_30320\] \[ID_30420\]

In the Generic Query Interface, a new “Get alarms” data source is now available. It will return all alarms in the DMS.

The following columns will be returned by default:

- Element name
- Parameter description
- Value
- Time
- Root time
- Severity
- Service impact
- RCA level
- Alarm type
- Owner

You can add the following columns using a column selector node:

- Alarm description
- Alarm ID
- Category
- Component info
- Corrective action
- Comments
- Creation time
- Element ID
- Element type
- Hosting agent ID
- Interface impact
- Key point
- Offline impact
- Parameter ID
- Root creation time
- Root alarm ID
- Status
- Source
- Table index display key
- Table index primary key
- User status
- Virtual function impact
- View impact
- A column for every custom alarm property

#### Dashboards app - State component: 'Show units' option \[ID_30322\]

In the *Settings* tab of a *State* component, it is now possible to select or clear the *Show units* option to show or hide the unit of the parameter.

#### Dashboards app - State component: Enhanced scrolling behavior when Layout flow is set to 'Columns' \[ID_30765\]

When the *Layout flow* setting of a State component is set to “Columns” and there is either a single group or no grouping at all, from now on, the states will always be displayed at full width.

#### Dashboards app - Node edge graph component: New 'Bidirectional configuration' option \[ID_30910\]

When configuring a node edge graph component, you can now use the *Bidirectional configuration* option to specify how you want multiple edges between two nodes to be mapped.

#### Dashboards app - Node edge graph component: 'Filtering & highlighting' section \[ID_31065\]

In the *Layout* pane of a node edge graph component, the *Column filters* section has been renamed to *Filtering & highlighting* and now contains the following options:

| Option | Description |
|--|--|
| Conditional coloring | Previously named *Column filters*, this option allows you to specify color filters for specific columns, so that these can be used for highlighting in case analytical coloring is used. |
| Highlight | When this option is enabled, the nodes that match the filter will be highlighted. Default: Enabled |
| Opacity | When the *Highlight* option is enabled, this option will allow you to set the level of transparency of the nodes and edges that do not match the filter. Note: When you disable the *Highlight* option, the nodes that do not match the filter will no longer be displayed and the remaining nodes will be reorganized. |
| Highlight/Show entire path | When this option is enabled, not only the nodes matching the filter will be highlighted, but also the entire tree structure of which they are a part (from root to leaves). |

> [!NOTE]
> The filtering options mentioned above require the *Query filter* component, which is currently still in [soft launch](xref:SoftLaunchOptions).

#### Dashboards app: New 'Preserve feed selections' option for dashboard folders \[ID_31380\]

A new setting is now available for dashboard folders: *Preserve feed selections*. When this option is selected, any feed selection you make in a dashboard in the folder is preserved when you navigate to another dashboard in the folder. Note that this only applies to the folder itself, not to any other folders it may contain.

To access this setting, right-click the dashboard folder in the navigation pane and select *Edit*. This *Edit* option also allows you to rename the dashboard folder and replaces the previous *Rename* option in the right-click menu.

#### Dashboards app - GQI: New 'Update data' option \[ID_31445\] \[ID_31450\]

When configuring a GQI query, you can now enable the “Update data” option if you want the component to automatically refresh the data when changes to that data are detected.

By default, the “Update data” option is disabled.

> [!NOTE]
> At present, this feature will only work for queries using a “Parameter table by ID” data source.

#### Dashboards app: Share button will now be disabled when you make a dashboard private \[ID_31667\]

As it is not possible to share private dashboards, the “Share” button will now be disabled when you make a dashboard private.

#### Dashboards app: GQI engine will now check the GQI version of a query \[ID_31698\] \[ID_31703\]

When you open a GQI query, the GQI engine will now check the GQI version of that query to determine whether it is capable of updating or running that query.

#### Dashboards app - Line chart component: New 'Trend points' setting \[ID_31751\]

When configuring a line chart component, you can now indicate how trend data points should be added to the graph by setting the *Trend points* option to one of the following values:

- Average (changes only) (default value)
- Average (fixed interval)
- Real-time

This setting will also be taken into account when you export a trend graph to a CSV file.

#### Dashboards app: 'Start sharing' button replaced by 'Share' button \[ID_31822\]

The “Start sharing” button has been replaced by a “Share” button. Clicking that button will open a popup that allows you

- to create a cloud share, or
- to copy the URL of the dashboard.

When you choose to copy the URL of a dashboard, you can select the following options:

- Select “Embed” to use a URL that will link to the dashboard in embedded mode (i.e. not showing headers and sidebars).
- Select “Use uncompressed URL parameters” to use a URL in which the data in the search parameters is not compressed. This will allow you to see and, if necessary, modify the plain JSON object.

#### Dashboards app: Passing JSON data in a dashboard URL \[ID_31833\] \[ID_31885\]

There are now two ways of passing data in the URL of a dashboard:

- As a dataset containing a number of items to be selected in all components (legacy method)
- As a JSON object containing a number of items to be selected in specific components (new method)

##### Dataset (legacy method)

Up to now, data could be passed to a dashboard using the following syntax:

```txt
url?<datatype1>=<datakeys1>&<datatype2>=<datakeys2>&...
```

Using this method, the dataset, which consists of a list of datatype/datakey(s) expressions, will provide data that will be selected in all relevant components of the dashboard.

##### JSON object (new method)

Next to the legacy method, it is now also possible to pass data to a dashboard in a JSON object.

```txt
url?data=<URL-encoded JSON object>
```

This JSON object has to have the following structure:

```json
{
    "version": 1,
    "feedAndSelect": <data>, (optional)
    "feed": <data>, (optional)
    "select": <data>, (optional)
    "components": <component-data>
}
```

- **\<data>** is a JSON object with a number of property keys (identical to the legacy datatypes) and property values (as an array of datakey strings). See the following example.

    ```json
    {
        "parameters": ["1/2/3", "1/4/6"],
        "elements": ["1/2", "1/8", "212/123"]
        ...
    }
    ```

- **\<component-data>** is an array of objects that allow you to specify data to be passed to one particular component. See the following example:

    ```json
    {
        cid: <component-id>,
        select: <data>
    }
    ```

- When you provide data in the (optional) **feedAndSelect** item, that data will be interpreted as if it would be passed using the legacy method described above.

- When you provide data in the (optional) **feed** item, that data will only be used in the URL feed. It will not be used to select items in selection boxes on the dashboard.

- When you provide data in the (optional) **select** item, that data will only be used to select items in selection boxes on the dashboard. It will not be used in the URL feed.

- In the **components** item, you can provide data to be selected in specific components referred to by their ID.

    > [!NOTE]
    > When you are editing a dashboard, each component will show its ID in the bottom-right corner (e.g. “State 1”).

> [!NOTE]
> When a dashboard updates its own URL, it will use the new format, but in a compressed way. In that compressed syntax, the query parameter “d” will be used instead of “data”.

### DMS Automation

#### Interactive Automation scripts will now take into account timeouts set in the engine.Timeout property of the executed script \[ID_28405\]

From now on, interactive Automation scripts will also take into account any timeout set in the engine.Timeout property of the executed script.

#### Interactive Automation scripts: Lazy loading of tree view items \[ID_28528\]\[ID_29295\]

It is now possible to configure that a tree view item in interactive Automation scripts will only be loaded when a user expands the item by clicking the arrow in front of it.

To activate this so-called lazy loading for a particular tree view item, set its SupportsLazy-Loading property to true. An arrow will appear in front of the tree view item (even if it does not have any child items).

> [!NOTE]
> You can use the GetExpanded method of the UIResults class to retrieve the keys of all expanded tree view items that have the SupportsLazyLoading property set to true.

#### Interactive Automation scripts: Enhanced file selector \[ID_28628\]

A number of enhancements have been made to the file selector used in interactive Automation scripts.

#### Interactive Automation scripts: New 'TreeViewItemCheckingBehavior' property of TreeViewItem \[ID_29993\]\[ID_30603\]

You can now configure what happens when you select a tree view item in an interactive Automation script, using the new *TreeViewItemCheckingBehavior* enum property of the *TreeViewItem* object.

This property can have the following values:

- *FullRecursion*: All child items will automatically be selected when this item is selected, and vice versa.

- *None*: Only this item will be selected. The selection state of child items will not change. In addition, if all child items are selected, this tree view item will not be automatically selected.

For example:

```csharp
UIBuilder uib = new UIBuilder();
   uib.Title = "Treeview - Regular";
   uib.RequireResponse = true;
   uib.RowDefs = "*";
   uib.ColumnDefs = "*";
   UIBlockDefinition tree = new UIBlockDefinition();
   tree.Type = UIBlockType.TreeView;
   tree.Row = 0;
   tree.Column = 0;
   tree.DestVar = "treevar";
   tree.TreeViewItems = new List<TreeViewItem>
   {
      new TreeViewItem("Slapp", "Slapp (Nexus)", false, new List<TreeViewItem>
      {
         new TreeViewItem("Nitro", "Nitro (Squad)", false, new List<TreeViewItem>
         {
            new TreeViewItem("Brian", "Brian (Member)", false) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Gilles", "Gilles (Member)", true) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("KevinM", "KevinM  (Member)", true) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("KevinV", "KevinV  (Member)", false) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Seba", "Seba  (Member)", false) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Ward", "Ward  (Member)", true) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
         }) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
         new TreeViewItem("Nitro", "Nitro (Squad)", true, new List<TreeViewItem>
         {
            new TreeViewItem("Jordy", "Jordy (Member)") { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Jorge", "Jorge (Member)") { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Ronald", "Ronald (Member)") { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Victor", "Victor (Member)") { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Wim", "Wim (Member)") { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Quinten", "Quinten (Member)") { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None }
         }) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None }
     }) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None }
   };
   uib.AppendBlock(tree);
   _treeResults = _engine.ShowUI(uib);
```

Regardless of which type of behavior you choose, if one or more child items of a tree view item are selected, the checkbox of the tree view item will be colored.

#### ProcessAutomationHelper \[ID_30108\]

A new ProcessAutomationHelper has been added to manipulate PaToken and PaProcess objects. See the following example.

```csharp
public class Script
{
    public void Run(Engine engine)
    {
        var paHelper = new ProcessAutomationHelper(engine.SendSLNetMessages);
        var token = new PaToken() { Id = Guid.NewGuid() };
        var createdToken = paHelper.PaTokens.Create(token);
        var readToken = paHelper.PaTokens.Read(createdToken.ToFilter<PaToken>());
        paHelper.PaTokens.Delete(createdToken);
        var process = new PaProcess() { Id = "id" };
        var createdProcess = paHelper.PaProcesses.Create(process);
        var readProcess = paHelper.PaProcesses.Read(createdProcess.ToFilter<PaProcess>());
        paHelper.PaProcesses.Delete(createdProcess);
    }
}
```

> [!NOTE]
>
> - Save operations will always be executed synchronously. In other words, the method will only return once the data has been written to the database.
> - At present, bulk operations are not yet supported.
> - Both PaProcess and PaToken now have a new LastModifiedAt property, filled in by SLNet. It will be used to compare cached versions with versions retrieved from the database.

#### Interactive Automation scripts: File selector allowing multiple selections + file selector enhancements \[ID_30196\]

In an interactive Automation script that is used in the DataMiner web apps, you can now configure a file selector component that allows the user to upload multiple files. To do so, set the property *AllowMultipleFiles* to true.

For example:

```csharp
UIBlockDefinition uibDef = new UIBlockDefinition();
uibDef.Type = UIBlockType.FileSelector;
uibDef.DestVar = destvar;
uibDef.InitialValue = initialValue;
uibDef.Row = (int)row;
uibDef.RowSpan = (int)rowSpan;
uibDef.Column = (int)column;
uibDef.ColumnSpan = (int)columnSpan;
uibDef.HorizontalAlignment = GetHorizontalAlignment(horizontalAlignment);
uibDef.VerticalAlignment = GetVerticalAlignment(verticalAlignment);
uibDef.AllowMultipleFiles = true;
```

With this configuration, users will be able to add files one by one, but they will not be able to add the same file twice. They will also be able to add a file by dragging it to the file selector.

There have also been a number of enhancements to the file selector control in general, including improved layout and a more intuitive UI. These affect all the web apps, including the Dashboards app, the Jobs app, etc.

#### Interactive Automation scripts: Input components now have a 'WantsOnFocusLost' property & other input component enhancements \[ID_30638\]

In an interactive Automation script that is used in the DataMiner web apps, the following components now have a *WantsOnFocusLost* property. If you set this property to true, then an *OnChange* event will be triggered when the component loses focus.

- Calendar
- Checkbox
- CheckboxList
- Dropdown
- Numeric
- Passwordbox
- RadioButtonList
- Textbox
- Time

Other enhancements:

- A Dropdown component will now keep the focus after an option was selected. This will enable users to still browse through the options using the arrow keys even when the options popup window is closed.
- In a Checkbox, a CheckboxList or a RadioButtonList component, users can now select or clear options using the spacebar.
- In a CheckboxList or a RadioButtonList component, users can now go from one checkbox or radio button to another using the TAB keys.

#### Automation scripts launched from web apps will now take into account the MaxFileSizeInBytes and AllowedFileNameExtensions properties of UIBlockDefinitions of type FileSelector \[ID_31212\]

In Automation scripts launched from web apps, the MaxFileSizeInBytes and AllowedFileName-Extensions properties of UIBlockDefinitions of type FileSelector will now also be taken into account.

An error will now be thrown when you try to add a file that is larger than the allowed file size or does not have an allowed file name extension. Also, the “Choose file” popup window will now only list files with an allowed extension and dragging an item other than a file or a folder onto the script’s drop zone will no longer be possible.

### DMS Maps

#### Filtering on alarm severity: \<Checkbox> tags now have a 'checked' attribute \[ID_30429\]

If you want a map to contain a filter box that allows users to filter map items based on their alarm severity level, then you add a \<FilterBox> tag that contains a checkbox for every alarm severity level. From now on, it is possible to indicate whether those checkboxes should be selected or cleared by default. To do so, add a “checked” attribute to each of the checkboxes, and set their value to either true or false.

See the following example:

```xml
<MapConfig ...>
  ...
  <FilterBox visible="true">
    <CheckBoxes>
      <CheckBox alarmLevel="Normal" name="connected" checked="true" />
      <CheckBox alarmLevel="Critical" name="not connected" checked="true" />
      <CheckBox alarmLevel="Undefined" name="unknown" checked="false" />
    </CheckBoxes>
  </FilterBox>
  ...
</MapConfig>
```

> [!NOTE]
> If, for a particular checkbox, you do not specify a “checked” attribute, then the checkbox will be selected by default.

### DMS Web Services

#### BREAKING CHANGE: Web Services API v0 now disabled by default \[ID_29453\]

The Web Services API v0 is now disabled by default. It is recommended to use the Web Services API v1 instead (SOAP or JSON).

> [!NOTE]
> If necessary, you can still enable the Web Services API v0 by adding the following key inside the \<appSettings> element of the *C:\\Skyline DataMiner\\Webpages\\API\\Web.config* file:
>
> *\<add key="enableLegacyV0Interface" value="true"/>*

#### Web Services API v1: CreateElement and EditElement methods now allow to create and edit replicated elements \[ID_30339\]

The CreateElement and EditElement methods now allow you to create and edit elements that replicate elements from a different DataMiner System.

In the configuration section, you will find a ReplicationInfo subsection that allows you to specify the necessary settings.

#### Web Services API v1: New methods to manage alarm templates \[ID_30383\] \[ID_31149\]

The following new methods now allow you to create, update, delete and assign alarm templates:

- CreateAlarmTemplate
- UpdateAlarmTemplate
- DeleteAlarmTemplate
- AssignAlarmTemplate

If no baseline configuration is provided in the request, the alarm information configured in the protocol for the chosen parameter will be passed along, and if no alarm information could be found, then a default baseline will be passed along instead.

The “average type” property will always be set to “median”.

### DMS web apps

#### Throttling will now be enabled on all SLNet connections \[ID_28442\]

All web applications\* will now connect to SLNet with the “AllowMessageThrottling” attribute.

*\*Monitoring, new Dashboards, legacy Dashboards, Maps, Web Services APIs, etc.*

#### HTML5 apps that require an Elasticsearch database will now redirect users to an error page when that database is unavailable \[ID_28767\]

When you log on to an app that requires an Elasticsearch database, you will now be redirected to an error page when that database is unavailable.

#### Ticketing app: Executing scripts when a ticket is created, updated or deleted \[ID_29191\]

The TicketFieldResolver now includes a TicketFieldResolverSettings object, which can contain a ExecuteScriptOnTicketActionSettings object.

In an ExecuteScriptOnTicketActionSettings object, you can specify the names of the scripts that should be executed each time a ticket is created, updated or deleted. See the following example.

```csharp
var settings = new TicketFieldResolverSettings()
{
    ScriptSettings = new ExecuteScriptOnTicketActionSettings()
    {
        OnCreate = onCreateScriptName,
        OnDelete = onDeleteScriptName,
        OnUpdate = onUpdateScriptName
    }
};
var fieldResolver = new TicketFieldResolver(Guid.NewGuid())
{
    Settings = settings,
    TicketStateFieldDescriptor = { IsRequired = false }
};
```

The scripts must have an OnTicketCrud entry point defined. See the following example. This way, you can indicate the action, ticket and TicketFieldResolver for which the script was triggered.

```csharp
[AutomationEntryPoint(AutomationEntryPointType.Types.OnTicketCrud)]
public void OnTicketCrud(Engine engine, TicketID ticketId, CrudType crudType)
{
    engine.GenerateInformation($"Script triggered for {crudType} action on Ticket with ID: {ticketId.TID}")
}
```

#### Jobs app: Added text and number filters for fields \[ID_29221\]

Users can now be allowed to filter on the following field types:

- Text
- Email
- Url

If you want to allow filtering on one of those fields, then select its *Allow filtering on this field* option.

> [!NOTE]
> Text-based filters will behave like case-sensitive “contains” filters.

#### Jobs app: Enhanced time filter \[ID_29328\]

In the Jobs app, the time filter in the sidebar has been improved. You can now indicate whether you want the list to show you the jobs that occurred, started or ended during a particular time frame.

> [!NOTE]
> This time filter will now be stored locally, in the web browser, per domain.

#### Web apps will now display a warning when you do not use an HTTPS connection \[ID_29389\]

From now on, when you access a web app (e.g. Monitoring, Dashboards, Jobs, Ticketing, etc.), a warning will be displayed when you do not use an HTTPS connection.

#### Dashboards/Monitoring: EPM components now fully aligned \[ID_29770\]

The EPM component of the Dashboards app and the Monitoring app are now fully aligned.

Also, the EPM component of the Dashboards app now allows the use of quick chains.

#### Visual Overview: Links starting with 'mailto:' now also work in web apps \[ID_30109\]

When, in shape data, you specify links starting with “mailto:”, those links will now also work in web apps.

#### Web app tooltips: Increased contrast to enhance readability \[ID_30283\]

In all web apps, tooltip contrast has been increased to enhance readability.

#### Web app tooltips: Cursor now changes from arrow to hand when hovering over a tooltip of an input component \[ID_30285\]

From now on, when you hover the mouse pointer over a tooltip of an input component, the arrow will change into a hand.

#### DataMiner landing page: Browser title changed to 'DataMiner' \[ID_31373\]

The browser title of the DataMiner landing page (e.g. `https://<MyDMA>/root/`) has been changed from “DataMiner Services” to “DataMiner”.

Also, the error message shown when you try to log in to a web application with a user account that has not been granted the “DataMiner Web Apps” user permission has now been changed to “You have no access to the DataMiner Web Apps”.

#### BREAKING CHANGE: End of Internet Explorer support for DataMiner web apps \[ID_31675\]

All DataMiner web apps have been upgraded to use Angular 12 instead of Angular 10, which means that the following DataMiner apps and functionality will no longer be available in Internet Explorer:

- The DataMiner landing page
- The Monitoring app
- The Dashboards app
- The Ticketing app
- The Jobs app
- The Monitoring app
- The Application Framework module (currently still in soft launch)
- Automation Script execution in embedded web browser (currently still in soft launch)

> [!NOTE]
> For now, we continue to support the use of DataMiner Cube in Internet Explorer, although it is highly recommended to use the DataMiner Cube desktop app instead. For more information, see DataMiner Dojo: <https://community.dataminer.services/documentation/internet-explorer-support/>
