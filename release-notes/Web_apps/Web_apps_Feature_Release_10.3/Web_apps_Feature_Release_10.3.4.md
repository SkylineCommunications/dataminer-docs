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
