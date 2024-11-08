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

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

It is now possible to configure *Set variable* actions.

This type of action will allow users to set the current value of any variable that is not read-only to either a static value or a value available elsewhere in the low-code app.

> [!NOTE]
> Variables of type *Table* can only be set to a static value.

## Changes

### Enhancements

#### Dashboards app: Enhanced performance [ID 41148]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

Because of a number of enhancements with regard to file operations, overall performance has increased when working with the Dashboards app.

#### Dashboards/Low-Code Apps: Pickers have been made more consistent [ID 41251]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When you create a variable of type *DOM instance*, you will now have to click *Apply* or *Cancel* after selecting a DOM instance.

In addition, the *Link to* data pickers have now been made more consistent. The *Apply* button has been renamed to *Link*, and will only be clickable when a valid link has been configured. Also, when you edit a link, an *Unlink* button will allow you to remove the link.

#### Web apps: Users will be redirected to the login screen when the connection cannot be restored [ID 41334]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

From now on, when the WebSocket is able to reconnect but the connection itself cannot be restored, users will be redirected to the login screen.

### Fixes

#### Dashboards/Low-Code Apps: Labels of lazy-loaded data would incorrectly not be displayed in edit mode [ID 41189]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When you were editing a dashboard or a page or a panel of a low-code app, the labels of lazy-loaded data would incorrectly not be displayed.

#### Legacy Reporter would leak memory when requesting history alarms [ID 41247]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

Up to now, the legacy Reporter (SLASPConnection) would leak memory on every DataMiner Agent in the DMS when requesting history alarms.

#### Dashboards/Low-Code Apps - Alarm table component: Time filter would be disregarded when fetching history alarms [ID 41249]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When an *Alarm table* component was configured to retrieve history alarms, it would incorrectly always retrieve all history alarms from the database, regardless of what was specified in the time filter.

#### Dashboards/Low-Code Apps: No chart data would be shown when a parameter value was fed to a Line & area chart component linked to a Time range component [ID 41252]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When the value of a parameter selected in another component (e.g. a *Gauge* or a *Ring* component) was fed to a *Line & area chart* component that was linked to a *Time range* component, in some cases, the *Line & area chart* component would not show any data.

#### Dashboards/Low-Code Apps: Line & area chart component would incorrectly remain empty until it was resized [ID 41278]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

In some cases, a *Line & area chart* component would incorrectly remain empty until it was resized.

#### Low-Code Apps: Problem when multiple users would continually refresh a page with a number of queries [ID 41316]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When multiple users would open a page containing a number of queries and then continually refreshed the page within a time frame of 5 minutes, in some cases, the following GQI exception could be thrown:

`Maximum amount of concurrent sessions`

To prevent this exception from being thrown, the above-mentioned time frame has now been reduced to 1 minute.

#### Dashboards app: Not possible to generate a PDF report based on a dashboard containing empty components [ID 41317]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

Up to now, it would incorrectly not be possible to generate a PDF report based on a dashboard that contained empty components.

#### Dashboards/Low-Code Apps - GQI components: No query session would be opened when no WebSocket connection had been established [ID 41349]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When a GQI component had its *Update data* setting enabled, no query session would be opened when no WebSocket connection had been established. As a result, no data would be fetched.
