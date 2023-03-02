---
uid: Web_apps_Feature_Release_10.3.4
---

# DataMiner web apps Feature Release 10.3.4 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.4](xref:General_Feature_Release_10.3.4).

## Highlights

*No highlights have been selected for this release yet*

## Other new features

#### Dashboards app & Low-code apps: 'Lazy load components' setting [ID_35469] [ID_35486]

<!-- MR 10.4.0 - FR 10.3.4 -->

In the configuration settings of a dashboard or a page/panel of a low-code app, you can now find the *Lazy load components* setting.

When this settings is enabled, the components on the dashboard or the page/panel of the low-code app will only be initialized the first time they appear on the screen. This will considerably shorten the initial load time and enhance overall performance of large dashboards and large pages/panels of low-code apps.

> [!NOTE]
>
> - This setting, which is enabled by default for all new dashboards and all new pages/panels of low-code apps, is only available if you add the `showAdvancedSettings=true` option to the dashboard URL.
> - Even when this setting is enabled, components will not be lazy loaded in edit mode.

#### Monitoring app - Trending: Switching between trend graph and histogram [ID_35501]

<!-- MR 10.4.0 - FR 10.3.4 -->

When viewing a trend graph in the Monitoring app, you can now easily switch between trend graph and histogram by clicking either the trend graph or histogram icon in the top-right corner.

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

### Fixes

#### Web apps - Interactive Automation scripts: Component of type 'Time' would not be displayed as a time span picker [ID_35435]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

In a web app, an interactive Automation script component of type `Time` with configuration options of type `AutomationTimeUpDownOptions` would incorrectly not be displayed as a time span picker.

Also, a number of enhancements have been made:

- In web app environments, configuration options of type `AutomationTimeUpDownOptions` now have a new `ShowTimeUnits`property. When this property is set to true, the component will display labels indicating the days, hours, minutes and seconds. Default setting: false

- The hours, minutes and seconds of the time span component will get leading zeros after focus is lost.

- In a web app environment, a calendar component will now always show the picker button (as in Cube).

- When an interactive Automation script run in a web app environment contains executable components, a message will now be displayed, saying that executable components are not supported in web apps.

#### Dashboards app & Low-code apps - GQI: Problem with 'Update data' option when using the 'Get parameter table by ID' data source [ID_35490]

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

<!-- MR 10.2.0 [CU13] - FR 10.3.4 -->

When a PDF report was generated via Automation or Scheduler, in some cases, its width would be set incorrectly.

Also, in some cases, the left and right padding of PDF reports generated via Automation, Scheduler and the Dashboards app itself would be missing.

#### Low-code apps: Sidebar would incorrectly be displayed when there was only one visible page [ID_35544]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Up to now, whether the sidebar was displayed or not would incorrectly depend on the number of pages. From now on, it will depend on the number of visible pages. In other words, the sidebar will only be displayed when there are at least two visible pages.

#### Low-code apps: Clock components in a published low-code app would incorrectly only update when you moved the mouse [ID_35554]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Clock components in a published low-code app would incorrectly only update when you moved the mouse.

#### Dashboards app: Submenu in subheader bar would incorrectly be displayed when it did not contain any visible items [ID_35570]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

The submenu in the subheader bar of a dashboard would incorrectly be displayed when it did not contain any visible items.

#### Web apps: Problem when retrieving spectrum element parameters [ID_35660]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

When the parameters of a spectrum element were retrieved in a web app, in some cases, an exception could be thrown, causing a `No parameters available` message to appear.

#### Dashboards app - Line & area chart component: Trend data could not be retrieved for spectrum parameters [ID_35676]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When, in a dashboard, you added a trended spectrum parameter to a line & area chart component, the component would not be able to retrieve the trend data of that parameter.

#### Dashboards app - Line & area chart component: Duplicate data in exported CSV file [ID_35688]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you exported the data shown in a line & area chart component to a CSV file, the file could incorrectly contain duplicate data.

#### Low-code apps: Feeds used in queries would incorrectly not get updated [ID_35689]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

In some cases, a feed used in a query would incorrectly not get updated when the data inside the feed was updated.

#### Dashboards app & low-code apps - State component: Changing the query order would incorrectly only be applied when the browser was refreshed [ID_35690]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you changed the order of the queries added to a State component, this change would incorrectly only be applied when you refreshed the browser. From now on, the change will be applied immediately.

#### Dashboards app - Line & area chart: Problem when selecting a new time range [ID_35691]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a line & area chart was filtered by means of a time range feed, in some cases, the dashboard would incorrectly keep on loading when a new time range was selected.

#### Dashboards app & Low-code apps: Not possible to filter a GQI table by a boolean column [ID_35692]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

Up to now, it would incorrectly not be possible to filter a GQI table by a boolean column.

#### Dashboards app & Low-code apps: Last nodes of a migrated query would incorrectly be cut off [ID_35693]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a GQI was migrated, in some cases, the last nodes of the migrated query would incorrectly be cut off.

#### Dashboards app & Low-code apps - Node edge component: An incorrect tooltip would appear when hovering over a segment of an edge [ID_35696]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you hovered over a segment of an edge, in some cases, an incorrect tooltip would appear.

#### Dashboards app & Low-code apps - Query builder: Problem when linking a data source argument of type string to a query column of type GUID [ID_35700]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

When configuring an ad hoc data source in a GQI query, you can link the arguments of that ad hoc data source to a feed. However, in some cases, it would incorrectly not be possible to link an argument of type string to a query column of type GUID.

Also, in the query builder, the `Link [argument name] to feed for [argument name]` command has been renamed to `Use feed for [argument name]`.

#### Dashboards app: 'Clear all' button would incorrectly also be displayed when the dashboard did not contain any feeds [ID_35709]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

When you selected a dashboard, the *Clear all* button would incorrectly also be displayed when the dashboard did not contain any feeds.

#### Dashboards app: 'Data used in dashboard' section would incorrectly not list DOM instances [ID_35717]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When editing a dashboard, DOM instances used by components on that dashboard would incorrectly not be listed in the *Data used in dashboard* section of the *DATA* tab.

#### Web apps: Node edge actions would incorrectly no longer work [ID_35723]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Node edge actions would incorrectly no longer work.

#### Web apps - Query builder: Query nodes that by default only had a single value would incorrectly not be displayed [ID_35735]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

In the query builder, query nodes that by default only had a single value would incorrectly not be displayed.

#### Dashboards app & Low-code apps - Query builder: Problem when trying to create a GQI query with an ad hoc data source that contained an optional DateTime argument [ID_35738]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

When you tried to create a GQI query with an ad hoc data source that contained an optional DateTime argument, in some cases, the following exception could be thrown:

```txt
Skyline.DataMiner.Web.Common.v1.Utilities.UTCToDateTimeUTC(long)' has some invalid arguments
```

#### GQI: Queries containing float or GUID values would not get migrated correctly [ID_35759]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

GQI queries containing float or GUID values would not get migrated correctly.
