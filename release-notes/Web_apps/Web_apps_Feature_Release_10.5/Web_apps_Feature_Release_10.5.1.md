---
uid: Web_apps_Feature_Release_10.5.1
---

# DataMiner web apps Feature Release 10.5.1 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.5.1](xref:General_Feature_Release_10.5.1).

## Highlights

*No highlights have been selected yet.*

## New features

#### Low-Code Apps: New 'Set variable' action [ID 41253]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU1] - FR 10.5.1 -->

It is now possible to configure *Set variable* actions.

This type of action will allow users to set the current value of any variable that is not read-only to either a static value or a value available elsewhere in the low-code app.

> [!NOTE]
> Variables of type *Table* can only be set to a static value.

## Changes

### Enhancements

#### Dashboards app: Enhanced performance [ID 41148]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU1] - FR 10.5.1 -->

Because of a number of enhancements with regard to file operations, overall performance has increased when working with the Dashboards app.

### Fixes

#### Dashboards/Low-Code Apps: Labels of lazy-loaded data would incorrectly not be displayed in edit mode [ID 41189]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU1] - FR 10.5.1 -->

When you were editing a dashboard or a page or a panel of a low-code app, the labels of lazy-loaded data would incorrectly not be displayed.

#### Legacy Reporter would leak memory when requesting history alarms [ID 41247]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU1] - FR 10.5.1 -->

Up to now, the legacy Reporter (SLASPConnection) would leak memory on every DataMiner Agent in the DMS when requesting history alarms.

#### Dashboards/Low-Code Apps - Alarm table component: Time filter would be disregarded when fetching history alarms [ID 41249]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU1] - FR 10.5.1 -->

When an *Alarm table* component was configured to retrieve history alarms, it would incorrectly always retrieve all history alarms from the database, regardless of what was specified in the time filter.

#### Dashboards/Low-Code Apps: No chart data would be shown when a parameter value was fed to a Line & area chart component linked to a Time range component [ID 41252]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU1] - FR 10.5.1 -->

When the value of a parameter selected in another component (e.g. a *Gauge* or a *Ring* component) was fed to a *Line & area chart* component that was linked to a *Time range* component, in some cases, the *Line & area chart* component would not show any data.
