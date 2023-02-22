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

#### Low-code apps: Feeds used in queries would incorrectly not get updated [ID_35689]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

In some cases, a feed used in a query would incorrectly not get updated when the data inside the feed was updated.

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
