---
uid: Web_apps_Main_Release_10.3.0_changes
---

# DataMiner web apps Main Release 10.3.0 – Changes

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

## Changes

### Enhancements

#### Web apps: Enhancements with regard to the rendering of GQI tables [ID_33463]

<!-- MR 10.3.0 - FR 10.2.7 -->

A number of enhancements have been made with regard to the rendering of GQI tables.

#### Dashboards app / Low-Code Apps: Support for feed categories in components [ID_33719]

<!-- MR 10.3.0 - FR 10.2.9 -->

Up to now, components could only produce one feed for each data type. Now support has been added for different categories within a data type, so that components will be able to produce several feeds for the same data type. This will for example make it possible for a component to produce a query row feed with the categories "timeline item" and "timeline band".

#### GQI: Improved performance of column filter [ID_34014]

<!-- MR 10.3.0 - FR 10.2.9 -->

Instead of a client-side filter, a more efficient server-side filter is now used to filter columns of a table component showing GQI data in a dashboard or low-code app. This will greatly improve the filter performance. However, because this server-side filter does not support "OR" filters, it will no longer be possible to combine multiple conditions within the same filter.

#### Dashboards / Low-Code Apps: Table filter improvements [ID_34022]

<!-- MR 10.3.0 - FR 10.2.9 -->

If you used the search box below a table displaying GQI data to filter this data, up to now, this could cause a serious load on the server in case a large number of rows had to be retrieved. To prevent this, the following conditions will now be applied to determine if more data should be retrieved:

- If the table already has enough rows to fill the next page, no further data will be retrieved.
- If the condition above is not met, at least 250 rows will retrieved initially.
- If at least one record is found that matches the search filter, no more rows will be retrieved. You will then need to click a "Load more" button to retrieve more data.
- If 2000 additional records have been retrieved after you click "Load more", no more data will be retrieved until you click the button again.
- If you scroll through the results, additional data will be fetched until there are enough rows to fill the next page.

#### Dashboards app / Low-Code Apps: No more statistics and suggestions for conditional coloring of Table and Node edge component [ID_34037]

<!-- MR 10.3.0 - FR 10.2.9 -->
<!-- Part of this RN is still in soft launch and consequently has not been documented yet -->

To improve performance, in the *Layout* pane for a Table or Node edge component, no more statistics and suggestions will be shown for conditional coloring.

#### GQI: Initial support for nested tables [ID_34144]

<!-- MR 10.3.0 - FR 10.2.9 -->

Initial support has been added for GQI results with cells containing nested records. However, at present this is only used for the *Resources* data source, which still requires the *GenericInterface* [soft-launch option](xref:SoftLaunchOptions).

The following functionality is now available for nested tables:

- Checking the number of records in nested tables. If a column with nested tables is retrieved, you cannot inspect the nested tables themselves yet, but a display value will show the number of records they contain.
- Aggregation on a single nested table column. There is no support for grouping yet. The aggregated value of the nested cell will be shown in the parent record as an ordinary cell.
- Filtering of nested tables.
- Selecting columns from nested tables. These will be shown in the same list box as regular columns, but their name will be prefixed by the parent column name. For example, if the parent column is named "Capabilities" and the nested table column is named "Name", the column will be listed as "Capabilities.Name".

#### Dashboards app / Low-Code Apps: Conditional coloring layout configuration now uses numeric filter instead of numeric slider [ID_34174]

<!-- MR 10.3.0 - FR 10.2.10 -->
<!-- Part of this RN is still in soft launch and consequently has not been documented yet -->

In the conditional coloring layout setting for Table and Node edge components, the numeric slider control has been replaced with a numeric filter. This has the following advantages:

- Full control over the boundaries. You can indicate whether the start and end should be in- or excluded.
- Possibility to not have a start or end boundary.
- More consistent with the free text filter.
- Easier to define a precise filter.

#### Dashboards app / Low-Code Apps: Conditional coloring layout filter configuration now shows discrete column values [ID_34182]

<!-- MR 10.3.0 - FR 10.2.10 -->
<!-- Part of this RN is still in soft launch and consequently has not been documented yet -->

In the conditional coloring layout setting for Table and Node edge components, discrete column values will now be displayed to make it easier to configure a filter.

#### GQI table column names will no longer include table names [ID_34302]

<!-- MR 10.3.0 - FR 10.2.10 -->

When a GQI table column inherits its name from a parameter of which the name includes the table name (between brackets), that table name will now be trimmed from the column name.

#### GQI: Enhanced performance of the ProfileInstance data source [ID_34320]

<!-- MR 10.3.0 - FR 10.2.11 -->

Because of a number of enhancements, overall performance has increased when running a GQI query using the ProfileInstance data source.

#### GQI: Enhanced performance when retrieving table data [ID_34441]

<!-- MR 10.3.0 - FR 10.2.12 -->

Because of a number of enhancements, overall performance has increased when retrieving table data by means of a GQI query.

#### Dashboards app - Line & area chart: Non-trended parameters will now automatically be removed when the component is linked to a parameter feed [ID_34499]

<!-- MR 10.3.0 - FR 10.2.12 -->

When a parameter feed is linked to a *Line & area chart" component, from now on, non-trended parameters will now automatically be removed from the chart.

#### Dashboards app - Parameter feed: 'Auto-select all' setting no longer available when using an EPM identifier feed as source [ID_34501]

<!-- MR 10.3.0 - FR 10.2.11 -->

When a parameter feed has an EPM identifier feed as source, from now on, the *Auto-select all* setting will no longer be available.

#### Dashboards app / Low-Code Apps - Line & area chart: Group label will no longer be displayed when grouping is set to 'All together' [ID_34544]

<!-- MR 10.3.0 - FR 10.2.12 -->

In case a *Line & area chart* component displays trending for multiple parameters, the *Group by* setting allows you to specify how the graphs should be grouped. From now on, group titles will no longer be displayed when you set *Group by* to "All together".

#### Dashboards app / Low-Code Apps: Enhanced performance of selection boxes [ID_34577]

<!-- MR 10.3.0 - FR 10.2.12 -->

Because of a number of enhancements, overall performance has increased when opening selection boxes, especially when they contain a large number of items.

#### Dashboards app: Upload size of PDF files will now be validated [ID_34620]

<!-- MR 10.3.0 - FR 10.2.12 -->

When PDF files are uploaded via the WebAPI (e.g. when a PDF report is generated), an error will now be thrown when the batch size exceeds 10 MB or the total file size exceeds 1 GB.

#### Dashboards app / Low-Code Apps - Visual Overview component: Enhancements with regard to WebSocket/polling settings and user access to visual overviews [ID_34624]

<!-- MR 10.3.0 - FR 10.2.12 -->

A number of enhancements have been made to the visual overview component, especially with regard to the WebSocket/polling settings and the algorithm that checks whether users have access to the visual overviews retrieved by the component.

#### GQI: Enhanced performance when retrieving DomInstances that have a DomBehaviorDefinition [ID_34853]

<!-- MR 10.3.0 - FR 10.3.1 -->

Because of a number of enhancements, overall performance has increased when retrieving DomInstances that have a DomBehaviorDefinition.

#### Chart components will now display GQI and configuration errors [ID_35445]

<!-- MR 10.3.0 - FR 10.3.3 -->

From now on, a chart component will display an error when the GQI query that retrieves data for that chart component throws an error, or when the chart component is not configured correctly.

### Fixes

#### Dashboards app: Dashboard names would incorrectly be allowed to contain backslash characters [ID_31735]

<!-- MR 10.3.0 - FR 10.2.1 -->

Up to now, it would incorrectly be allowed to enter a name containing backslash characters when creating or renaming a dashboard. From now on, this will no longer be allowed.

#### Mobile apps: Clients would not immediately receive updates when items were added [ID_32042]

<!-- MR 10.3.0 - FR 10.2.2 -->

When new items were added in one client, in some cases, those items would not immediately appear in other clients. For example, when a user created a ticket for a particular domain, other users viewing the list of tickets for that same domain would not immediately have their ticket list updated.

#### Jobs app: No 'loading' indication when job sections were being loaded [ID_32616]

<!-- MR 10.3.0 - FR 10.2.4 -->

When configuring jobs, no “loading” indication would appear when job sections were being loaded.

#### Web services API: Problem with GetServiceTemplate [ID_32625]

<!-- MR 10.3.0 - FR 10.2.4 -->

The GetServiceTemplate method would throw an exception when requesting a service template with Text inputs that had neither of the following options:

- Require a valid element name
- Allow 'N/A' to indicate empty value

#### Web Services API: Problem when opening the soap.asmx page [ID_32939]

<!-- MR 10.3.0 - FR 10.2.5 -->

In some cases, an exception could be thrown when you tried to open the following page: `http://DmaNameOrIpAddress/API/v1/soap.asmx`

#### Dashboards app: Selection in parameter feed would incorrectly be cleared whenever the linked EPM feed was updated [ID_33153]

<!-- MR 10.3.0 - FR 10.2.6 -->

When an EPM feed was linked to a parameter feed, in some cases, the current selection in the parameter feed would incorrectly be cleared whenever the EPM feed was updated.

#### Web apps: Only part of the value would be selected when moving the mouse pointer over a selection box that had the focus [ID_33379]

<!-- MR 10.3.0 - FR 10.2.7 -->

When you moved the mouse pointer over a selection box that had the focus, in some cases, only part of the value would be selected.

#### Dashboards app - GQI: Values of profile parameters without decimals defined would incorrectly be replaced by the maximum integer value [ID_33418]

<!-- MR 10.3.0 - FR 10.2.7 -->

When a profile parameter of type “number” had no decimals defined, its value would incorrectly be displayed as the maximum value that can be assigned to a parameter of type integer. From now on, when a profile parameter has no decimals defined, its value will be displayed as is, without decimals.

#### Ticketing app: Problem when trying to add a value to the State field of a ticket domain [ID_33537]

<!-- MR 10.3.0 - FR 10.2.7 -->

When you tried to add a new value to the State field of a ticket domain, the following error would be thrown when the change was saved:

```txt
Error trapped: Unable to cast object of type 'Skyline.DataMiner.Web.Common.v1.DMATicketFieldPossibleValue' to type 'Skyline.DataMiner.Web.Common.v1.DMATicketStateFieldPossibleState'.
```

#### Dashboards app: Dashboard would incorrectly scroll up when you selected a field in an EPM feed [ID_33650]

<!-- MR 10.3.0 - FR 10.2.8 -->

When, on a dashboard, an EPM feed was surrounded by other components, in some cases, the dashboard would incorrectly scroll up when you selected a field in the EPM feed.

#### GQI - Elasticsearch: Aggregated data did not have the number of decimals specified in the parameter info [ID_33712]

<!-- MR 10.3.0 - FR 10.2.11 -->

Aggregated data retrieved from an Elasticsearch database did not have the number of decimals specified in the parameter info.

#### Dashboards app / Low-Code Apps: Changes to the feed could incorrectly influence the time window of a state timeline component [ID_34148]

<!-- MR 10.3.0 - FR 10.2.10 -->

In some cases, changes to the feed linked to a state timeline component could reset the time window. From now on, linking a query filter to the timeline will no longer influence the time window. The filter will be applied and the current time window will be preserved.

Also, because of a number of enhancements, overall performance has increased when linking a query filter to a state timeline component.

#### Dashboards app / Low-Code Apps: Column filters in generic filter component incorrectly marked as incapable [ID_34273]

<!-- MR 10.3.0 - FR 10.2.10 -->

In the generic filter component, in some cases, column filters would be incorrectly marked as incapable when the filter assistance option was enabled.

#### Dashboards app / Low-Code Apps: Query column filters would not be applied correctly to table components [ID_34305]

<!-- MR 10.3.0 - FR 10.2.10 -->

when a dashboard, a low-code app page or low-code app panel was initialized, in some cases, query column filters would not be applied correctly to table components on that dashboard, page or panel.

#### Web apps - Interactive Automation scripts: Not possible to clear a selection box by selecting an empty option [ID_34315]

<!-- MR 10.3.0 - FR 10.2.11 -->

When an interactive Automation script was executed in a web app, it would incorrectly not be possible to clear a selection box by selecting an empty option.

#### Web Services API - CreateServiceTemplate: DataMinerID and ElementID incorrectly set to 0 instead of -1 [ID_34440]

<!-- MR 10.3.0 - FR 10.2.11 -->

When a service template was created using the *CreateServiceTemplate* method, the DataMinerID and ElementID of the newly created service template would incorrectly be set to 0 instead of -1.

#### Dashboards / Low-Code Apps: Changing a GQI query would not cause a table to get updated when column filters were applied [ID_34520]

<!-- MR 10.3.0 - FR 10.2.11 -->

When the GQI query linked to a table component was changed, the table would incorrectly not get updated when column filters were applied. The table would only get updated when you changed the column filters.

#### Mobile apps: Problem when trying to select an item in a drop-down box [ID_34742]

<!-- MR 10.3.0 - FR 10.2.12 [CU0] -->

In some cases, it would incorrectly not be possible to select an item in a drop-down box when the items were grouped or when their actual value was not identical to the value that was displayed.

#### Dashboards app: Empty groups would incorrectly not be removed from parameter feeds listing EPM parameters [ID_34884]

<!-- MR 10.3.0 - FR 10.3.1 -->

When, in a parameter feed listing EPM parameters, the parameters were grouped, empty groups would incorrectly not be removed after switching to another EPM object.

#### Low-Code Apps: Problem with 'Close a panel' action [ID_34892]

<!-- MR 10.3.0 - FR 10.3.1 -->

When a *Close a panel* action was configured as a post action on a button component, in some cases, it would incorrectly not cause the panel to close.

#### Dashboards & Low-Code Apps: Decimal values would incorrectly not be allowed in range filters [ID_34897]

<!-- MR 10.3.0 - FR 10.3.1 -->

In some cases, a range filter in a query filter or a table column filter would incorrectly not allow decimal values.

> [!NOTE]
> When using a query filter with filter assistance enabled, the statistics will determine the number of decimals that can be used.

#### Dashboards & Low-Code Apps: Feed component selections would incorrectly be lost after applying a built-in theme [ID_34908]

<!-- MR 10.3.0 - FR 10.3.1 -->

When you applied a built-in theme, feed component selections would incorrectly be lost after refetching the data.

#### Dashboards & Low-Code Apps: Not possible to group the data in a timeline populated using a query with a query filter [ID_34932]

<!-- MR 10.3.0 - FR 10.3.1 -->

When a timeline was populated using a query with a query filter, it would incorrectly not be possible to group the data.

#### Low-Code Apps: Drop-down box containing an 'execute component' action would incorrectly be empty [ID_34953]

<!-- MR 10.3.0 - FR 10.2.12 [CU1] -->

When an *execute component* action had been configured, in some cases, when you tried to update that action, the drop-down box containing the action would incorrectly be empty.

#### Dashboards app & Low-Code Apps: Manually sorted GQI table would no longer feed row values [ID_34969]

<!-- MR 10.3.0 - FR 10.2.12 [CU1] -->

When you had manually changed the sorting order of a GQI table by clicking a column header, in some cases, the table would no longer feed the selected row values.

#### Dashboards app: Tables would lose their conditional coloring after being sorted or filtered [ID_34979]

<!-- MR 10.3.0 - FR 10.3.1 -->

When you sorted or filtered a table fed by e.g. a query filter, the table would incorrectly lose its conditional coloring.

#### Web apps: Problem when a trend graph displaying multiple parameters showed data that was partly in the future [ID_34982]

<!-- MR 10.3.0 - FR 10.3.1 -->

When a trend graph displaying multiple parameters showed data that was partly in the future, in some cases, an error could occur.

#### Dashboards app: Button to restore the initial view would incorrectly appear on all tables after sorting or filtering a table [ID_35003]

<!-- MR 10.3.0 - FR 10.3.2 -->

When, on a dashboard, you sorted or filtered a table, a button to restore the initial view would incorrectly appear on all tables on that dashboard. Also, when you clicked one of those buttons, they would all disappear. From now on, when you sort or filter a table on a dashboard, a button to restore the initial view will only appear on that particular table.

#### Monitoring app: Problem when opening the histogram page of a view [ID_35081]

<!-- MR 10.3.0 - FR 10.3.2 -->

When, in the *Monitoring* app, you selected a view and opened the histogram page, in some cases, a `Maximum call stack size exceeded` error would appear.

#### Dashboards app: Visual Overview component would not show any content when linked to a feed [ID_35130]

<!-- MR 10.3.0 - FR 10.3.2 -->

When a Visual Overview component was linked to a feed, in some cases, it would not show any content.

#### Dashboards app & Low-Code Apps: Loading indicator would not appear when sorting, filtering or refreshing a table [ID_35238]

<!-- MR 10.3.0 - FR 10.3.2 -->

When you sorted or filtered a table by clicking a table header, or when an action triggered a refresh of the table data, in some cases, no loading indicator would appear.

#### GQI: Problem when fetching two queries using an external data source with a custom argument of which the ID was set to "Type" [ID_35242]

<!-- MR 10.3.0 - FR 10.3.3 -->

When two queries using an external data source with a custom argument of which the ID was set to "Type" had to be fetched, only one of the two queries would get fetched when the only difference between them was the value of the custom argument.

#### GQI: Metadata would incorrectly be removed when a custom operator was applied [ID_35283]

<!-- MR 10.3.0 - FR 10.3.2 -->

When, in a GQI query, a custom operator was applied, all metadata available on the rows would incorrectly be removed, causing feeds to no longer work as expected.

Also, when a column was renamed via a custom operator, the metadata available on that column would incorrectly be removed.

#### Dashboards app: Problem with line & area chart component when dashboard was shared [ID_35422]

<!-- MR 10.3.0 - FR 10.3.3 -->

When, in a dashboard, a line & area chart component had its *Hide non-trended parameters* option selected, errors could start to appear inside that component when the dashboard was shared.

#### Dashboards app: Problem with 'Preserve feed selections' option [ID_35438]

<!-- MR 10.3.0 - FR 10.3.3 -->

When you select the *Preserve feed selections* option for a particular dashboard folder, any feed selection you make in a dashboard in that folder is preserved when you navigate to another dashboard in that same folder.

Up to now, in some cases, one folder would incorrectly take over feed selections from another folder.

#### Web apps: Problem when executing a GQI query [ID_35539]

<!-- MR 10.3.0 [CU0] - FR 10.3.2 [CU1] -->

When a web app (e.g. Dashboards) tried to execute a GQI query, in some cases, a `Node: 'X' is not supported by the current server version.` error could be thrown (`'X'` being the node that caused the error).

#### Low-Code Apps: Panels of which the 'Fit to view' option was selected would incorrectly switch to mobile mode [ID_35542]

<!-- MR 10.3.0 - FR 10.3.3 -->

Panels of which the *Fit to view* option was selected would incorrectly switch to mobile mode when their width got too small. From now on, panels of which the *Fit to view* option is selected will never switch to mobile mode.
