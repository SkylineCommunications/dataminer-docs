---
uid: Web_apps_Feature_Release_10.3.4
---

# DataMiner web apps Feature Release 10.3.4

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.4](xref:General_Feature_Release_10.3.4).

## New features

#### Dashboards app & Low-Code Apps: 'Lazy load components' setting [ID_35469] [ID_35486]

<!-- MR 10.4.0 - FR 10.3.4 -->

In the configuration settings of a dashboard or a page/panel of a low-code app, you can now find the *Lazy load components* setting.

When this setting is enabled, the components on the dashboard or the page/panel of the low-code app will only be initialized the first time they appear on the screen. This will considerably shorten the initial load time and enhance overall performance of large dashboards and large pages/panels of low-code apps.

> [!NOTE]
>
> - This setting, which is enabled by default for all new dashboards and all new pages/panels of low-code apps, is only available if you add the `showAdvancedSettings=true` option to the dashboard URL.
> - Even when this setting is enabled, components will not be lazy loaded in edit mode.

#### Monitoring app - Trending: Switching between trend graph and histogram [ID_35501]

<!-- MR 10.4.0 - FR 10.3.4 -->

When viewing a trend graph in the Monitoring app, you can now easily switch between trend graph and histogram by clicking either the trend graph or histogram icon in the top-right corner.

#### Monitoring app & Dashboards app - Line & area chart: Time range buttons [ID_35595]

<!-- MR 10.4.0 - FR 10.3.4 -->

A line & area chart component now has a number of time range buttons that allow you to quickly select one of the following preset time ranges:

- 1d (last 24 hours)
- 1w (last 7 days)
- 1m (last 30 days)
- 1y (last year)
- 5y (last 5 years)

> [!NOTE]
> In the *Dashboards* app, these time range buttons are disabled by default. When configuring the component, you can enable them by selecting the *Show time range buttons* option in the *Component > Layout > Styling and Information* tab.

#### Web apps: New action 'Open monitoring card' [ID_35661]

<!-- MR 10.4.0 - FR 10.3.4 -->

In a low-code app, you can now configure a new type of action: *Open monitoring card*. When triggered, this action will open the card of a specific element, service or view in the *Monitoring* app.

> [!NOTE]
> When a low-code app is embedded in Cube (e.g. in a visual overview), an *Open monitoring card* action will open the specified card in Cube.

#### GQI - Ad hoc data source: Sending and receiving DMS messages [ID_35701]

<!-- MR 10.4.0 - FR 10.3.4 -->

Ad hoc data sources can now retrieve data by means of DMS messages.

To do so, the `IGQIDataSource` must implement the `IGQIOnInit` interface, of which the `OnInit` method can also be used to initialize a data source:

```csharp
OnInitOutputArgs OnInit(OnInitInputArgs args)
```

When passed to the `OnInit` method, `OnInitInputArgs` can now contain the following new property:

```csharp
GQIDMS DMS
```

The `GQIDMS` class contains the following methods, which can be used to request information in the form of `DMSMessage` objects:

| Method | Function |
|--------|----------|
| `DMSMessage SendMessage(DMSMessage message)` | Sends a request that expects a single response. |
| `DMSMessage[] SendMessages(params DMSMessage[] messages)` | Sends multiple requests at once, or sends a request that expects multiple responses. |

The `GQIDMS` object is only generated when the property is used.

Generally, an ad hoc data source implementation will want to add a private field where it can store the `GQIDMS` object to be used later in other callbacks when columns and rows are created.

> [!IMPORTANT]
> DMS messages are subject to change without notice. If you can implement an alternative using the DataMiner UI or the automation options provided in DataMiner Automation, we highly recommend that you do so instead.

## Changes

### Enhancements

#### GQI - Parameter table: Timestamps will now be displayed using the time zone configured in ClientSettings.json [ID_35515]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

GQI queries against the following data sources will now return all parameter values of type date/time in the timezone configured in the *ClientSettings.json* file.

- Get parameters for element where
- Get parameter table by alias
- Get parameter table by ID

Up to now, these values were always displayed in UTC.

> [!TIP]
> See also: [Setting the default time zone for DataMiner web apps](xref:ClientSettings_json#setting-the-default-time-zone-for-dataminer-web-apps)

#### Dashboards app: Feeds listing parameters of EPM objects will now also list the parameters of the enhanced elements linked to those EPM objects [ID_35562]

<!-- MR 10.4.0 - FR 10.3.4 -->

When an EPM feed is used to feed EPM identifiers to a parameter feed, it will now also list the parameters of the enhanced elements that are linked to the EPM objects.

#### Dashboards app - GQI: Improvements to 'Get parameter relations' data source [ID_35589] [ID_35602]

<!-- MR 10.4.0 - FR 10.3.4 -->
<!-- Not added to MR 10.4.0 -->

When you retrieve the parameter relationships by means of the *Get parameter relations* data source, you will notice the following improvements:

- In the *Confidence* column, the values are now displayed as percentages.
- In the *Generated by* column, the value "CpSymmetric" has been renamed to "Behavioral AI model".

Also, when you filter by the *Generated by* column, you will no longer be able to select "All".

> [!NOTE]
> This data source is only available when the *ModelHost* DxM is running.

#### GQI: Raw datetime values will now be converted to UTC [ID_35640]

<!-- MR 10.4.0 - FR 10.3.4 -->

Up to now, after each step in a GQI query, raw datetime values were always converted to the time zone that was specified in the query options. From now on, raw datetime values will be converted to UTC instead. The time zone specified in the query options will now only be used when converting a raw datetime value to a display value.

> [!IMPORTANT]
> **BREAKING CHANGE**: When, in an ad hoc data source or a query operation, a datetime value is not in UTC format, an exception will now be thrown.

#### Web Services API v1: Updated descriptions of GetAlarmHistory and GetAlarmDetails methods [ID_35651]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

In the following interface files, the descriptions of the *GetAlarmHistory* and *GetAlarmDetails* methods have been updated:

```txt
http://DmaNameOrIpAddress/API/v1/soap.asmx
http://DmaNameOrIpAddress/API/v1/json.asmx
```

New description of the *GetAlarmHistory* method:

> Get the alarm history for the specified alarm (optional full tree request). Use root alarm ID with requestFullTree for the details of a cleared non-root alarm.

New description of the *GetAlarmDetails* method:

> Get the alarm details for the specified alarm (use GetAlarmHistory for the details of a cleared non-root alarm).

#### Monitoring app: Trending page of a parameter no longer has a sidebar [ID_35705]

<!-- MR 10.4.0 - FR 10.3.4 -->

In the *Monitoring* app, the *Trending* page of a parameter no longer has a sidebar.

#### GQI: Clearer error message when querying a logger table without `RTDisplay=true` settings [ID_35706]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

A clearer error message will now be returned when you are building a query against a logger table without `RTDisplay=true` settings, neither on table level nor on column level.

#### Web apps: Enhanced feedback after a failed login attempt [ID_35724]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

When a login attempt fails, a clearer error message will now appear.

#### Dashboards app & Low-Code Apps - Line & area chart component: Enhanced performance when exporting trend data to CSV [ID_35727]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Because of a number of enhancements, overall performance has increased when exporting trend data to a CSV file.

### Fixes

#### Web apps - Interactive Automation scripts: Component of type 'Time' would not be displayed as a time span picker [ID_35435]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

In a web app, an interactive Automation script component of type `Time` with configuration options of type `AutomationTimeUpDownOptions` would incorrectly not be displayed as a time span picker.

Also, a number of enhancements have been made:

- In web app environments, configuration options of type `AutomationTimeUpDownOptions` now have a new `ShowTimeUnits`property. When this property is set to true, the component will display labels indicating the days, hours, minutes and seconds. Default setting: false

- The hours, minutes and seconds of the time span component will get leading zeros after focus is lost.

- In a web app environment, a calendar component will now always show the picker button (as in Cube).

- When an interactive Automation script run in a web app environment contains executable components, a message will now be displayed, saying that executable components are not supported in web apps.

#### Dashboards app & Low-Code Apps - GQI: Problem with 'Update data' option when using the 'Get parameter table by ID' data source [ID_35490]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a query using the *Get parameter table by ID* data source had the *Update data* option enabled, the component would incorrectly no longer automatically refresh the data when changes were detected.

#### Web apps - Interactive Automation scripts: Components in a row following a component with a row span greater than 1 would not be positioned correctly [ID_35504]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

In an interactive Automation script executed in a web app, components positioned in a row following a row that contained a component with a row span greater than 1 would not be positioned correctly.

> [!NOTE]
> If, in an interactive Automation script executed in a web app, a component is positioned on a cell that is overlapped by a component with a row span greater than 1, it will not be displayed.

> [!IMPORTANT]
> **BREAKING CHANGE**: If, in an interactive Automation script designed to be executed in a web app, the column property was altered to position a component at a specific spot, because of this fix, the component in question will no longer be displayed. It will be hidden by the component of which the row span is greater than 1. The component can be made visible again by changing the column property.

#### Dashboards app: Visualization picker would incorrectly resize when you hovered over it [ID_35516]

<!-- MR 10.4.0 - FR 10.3.4 -->

When you tried to select a visualization for a newly added component that did not yet have one, the visualization picker would incorrectly resize the first time you hovered over it.

#### Dashboards app: Problem with width of PDF reports [ID_35531]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU3] - FR 10.3.4 -->

When a PDF report was generated via Automation or Scheduler, in some cases, its width would be set incorrectly.

Also, in some cases, the left and right padding of PDF reports generated via Automation, Scheduler and the Dashboards app itself would be missing.

#### Low-Code Apps: Sidebar would incorrectly be displayed when there was only one visible page [ID_35544]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Up to now, whether the sidebar was displayed or not would incorrectly depend on the number of pages. From now on, it will depend on the number of visible pages. In other words, the sidebar will only be displayed when there are at least two visible pages.

#### Low-Code Apps: Clock components in a published low-code app would incorrectly only update when you moved the mouse [ID_35554]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Clock components in a published low-code app would incorrectly only update when you moved the mouse.

#### Dashboards app: Submenu in subheader bar would incorrectly be displayed when it did not contain any visible items [ID_35570]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

The submenu in the subheader bar of a dashboard would incorrectly be displayed when it did not contain any visible items.

#### GQI: Problem when applying an 'aggregation' or 'group by' operation on a datetime column of an Elasticsearch table [ID_35609]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

When an *aggregation* or *group by* operation was applied on a datetime column of an Elasticsearch table, the datetime values in that column would be parsed incorrectly.

#### Web apps: Color picker would not be positioned correctly [ID_35649]

<!-- MR 10.4.0 - FR 10.3.4 -->

The color picker would not be positioned correctly.

#### Web apps: Problem when retrieving spectrum element parameters [ID_35660]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

When the parameters of a spectrum element were retrieved in a web app, in some cases, an exception could be thrown, causing a `No parameters available` message to appear.

#### Dashboards app - Line & area chart component: Trend data could not be retrieved for spectrum parameters [ID_35676]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When, in a dashboard, you added a trended spectrum parameter to a line & area chart component, the component would not be able to retrieve the trend data of that parameter.

#### Low-Code Apps: Problem when opening a low-code app on a mobile device or when resizing the screen to a mobile size [ID_35683]

<!-- MR 10.4.0 - FR 10.3.4 -->

When you opened a low-code app on a mobile device or when you resized the screen to a mobile size, a console error would be thrown.

#### Dashboards app - Line & area chart component: Duplicate data in exported CSV file [ID_35688]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you exported the data shown in a line & area chart component to a CSV file, the file could incorrectly contain duplicate data.

#### Low-Code Apps: Feeds used in queries would incorrectly not get updated [ID_35689]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

In some cases, a feed used in a query would incorrectly not get updated when the data inside the feed was updated.

#### Dashboards app & Low-Code Apps - State component: Changing the query order would incorrectly only be applied when the browser was refreshed [ID_35690]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you changed the order of the queries added to a State component, this change would incorrectly only be applied when you refreshed the browser. From now on, the change will be applied immediately.

#### Dashboards app - Line & area chart: Problem when selecting a new time range [ID_35691]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a line & area chart was filtered by means of a time range feed, in some cases, the dashboard would incorrectly keep on loading when a new time range was selected.

#### Dashboards app & Low-Code Apps: Not possible to filter a GQI table by a boolean column [ID_35692]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

Up to now, it would incorrectly not be possible to filter a GQI table by a boolean column.

#### Dashboards app & Low-Code Apps: Last nodes of a migrated query would incorrectly be cut off [ID_35693]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a GQI was migrated, in some cases, the last nodes of the migrated query would incorrectly be cut off.

#### Dashboards app & Low-Code Apps - Node edge component: An incorrect tooltip would appear when hovering over a segment of an edge [ID_35696]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you hovered over a segment of an edge, in some cases, an incorrect tooltip would appear.

#### GQI: "Loading" indicator of a table would not disappear when that table was fed data from another table  [ID_35698]

<!-- MR 10.4.0 - FR 10.3.4 -->

When data from one table was fed to another table, in some cases, the "loading" indicator of the table to which data was fed would incorrectly not disappear.

#### Dashboards app & Low-Code Apps - Query builder: Problem when linking a data source argument of type string to a query column of type GUID [ID_35700]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

When configuring an ad hoc data source in a GQI query, you can link the arguments of that ad hoc data source to a feed. However, in some cases, it would incorrectly not be possible to link an argument of type string to a query column of type GUID.

Also, in the query builder, the `Link [argument name] to feed for [argument name]` command has been renamed to `Use feed for [argument name]`.

#### Dashboards app: Sticky component menus would no longer be fully visible after you had changed the number of dashboard columns [ID_35702]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.4 -->

Sticky component menus would no longer be fully visible after you had changed the number of dashboard columns.

#### Dashboards app: 'Clear all' button would incorrectly also be displayed when the dashboard did not contain any feeds [ID_35709]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

When you selected a dashboard, the *Clear all* button would incorrectly also be displayed when the dashboard did not contain any feeds.

#### Dashboards app: 'Data used in dashboard' section would incorrectly not list DOM instances [ID_35717]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When editing a dashboard, DOM instances used by components on that dashboard would incorrectly not be listed in the *Data used in dashboard* section of the *DATA* tab.

#### GQI: Display value of an empty cell of type 'double' would incorrectly be set to a "0" string [ID_35718]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

The display value of an empty cell of type *double* would incorrectly be set to a "0" string. From now on, it will be set to an empty string instead.

#### Web apps: Node edge actions would incorrectly no longer work [ID_35723]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Node edge actions would incorrectly no longer work.

#### Web apps - Query builder: Query nodes that by default only had a single value would incorrectly not be displayed [ID_35735]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

In the query builder, query nodes that by default only had a single value would incorrectly not be displayed.

#### Dashboards app & Low-Code Apps - Query builder: Problem when trying to create a GQI query with an ad hoc data source that contained an optional DateTime argument [ID_35738]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

When you tried to create a GQI query with an ad hoc data source that contained an optional DateTime argument, in some cases, the following exception could be thrown:

```txt
Skyline.DataMiner.Web.Common.v1.Utilities.UTCToDateTimeUTC(long)' has some invalid arguments
```

#### GQI: Queries containing float or GUID values would not get migrated correctly [ID_35759]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

GQI queries containing float or GUID values would not get migrated correctly.

#### Dashboards app & Low-Code Apps: GQI components would incorrectly not clear their query row feed when refetching data [ID_35767]

<!-- MR 10.3.0 [CU2] - FR 10.3.4 -->

GQI components would incorrectly not clear their query row feed when refetching data.

#### Dashboards app & Low-Code Apps - Query builder: Problem when linking a feed component to an argument of an ad hoc data source [ID_35808]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 [CU0] -->

When a feed component was linked to an argument of an ad hoc data source, in some cases, the feed would not work correctly.

#### Dashboards app & Low-Code Apps - GQI: Queries linked to feeds would not always apply feed changes [ID_35903]

<!-- MR 10.3.0 [CU2] - FR 10.3.4 [CU0] -->

In some cases, a query that was linked to feeds would not apply the feed changes in the visualizations unless it was opened in edit mode.

#### GQI - Parameter table component: Display values of discrete and exception values for DateTime columns would be rendered incorrectly [ID_35910]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 [CU0] -->

When discrete values and exception values for DateTime parameters were requested via GQI, their display values would be rendered incorrectly.
