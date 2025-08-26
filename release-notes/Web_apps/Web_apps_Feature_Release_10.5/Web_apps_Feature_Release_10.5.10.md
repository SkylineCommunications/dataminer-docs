---
uid: Web_apps_Feature_Release_10.5.10
---

# DataMiner web apps Feature Release 10.5.10 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.4.0 [CU19] and 10.5.0 [CU7].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.10](xref:General_Feature_Release_10.5.10).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.10](xref:Cube_Feature_Release_10.5.10).

## Highlights

*No highlights have been selected yet.*

## New features

#### Low-Code Apps: 'On open' events can now also be configured on app level [ID 43550]

<!-- 10.4.0 [CU19] / MR 10.5.0 [CU7] - FR 10.5.10 -->

From now on, it is also possible to configure *on open* events that will take place when an app is opened.

These events will take place in the following cases:

- When the app is accessed via the DataMiner landing page.
- When the app is accessed via its URL.
- When a draft is published (and the app is opened).
- When a draft is previewed.
- ...

> [!NOTE]
>
>- Although it is possible to have this *on open* event run an interactive Automation script, the script window will always have a light gray background and will not inherit the background color of the page it is launched on.
>- Currently, linking is not supported. When configuring a link to a component value, the value will always remain empty as the component will not be loaded yet when the event takes place.
>- Current, passing URL data is not supported. A value passed through the URL will return as empty.

#### Dashboards/Low-Code Apps - Maps component: Interacting with lines on a map [ID 43562]

<!-- 10.4.0 [CU19] / MR 10.5.0 [CU7] - FR 10.5.10 -->

From now on, when you select a line on a map in a *Maps* component

- data about that line will be made available in the *Selected lines* category,
- its *Selected* state will automatically be set to true, and
- its border color will change.

Also, in low-code apps, *On line click* event can now be configured. Inside such an event, actions have access to the event data, including data regarding the line that was clicked.

> [!NOTE]
> When you reload a dashboard or switch pages, selected lines will not automatically be reselected. Also, lines cannot be selected using an URL argument.

## Changes

### Enhancements

#### Monitoring app: Navigation from Visual Overview now goes to Visual page instead of Data page [ID 43430]

<!-- 10.4.0 [CU19] / MR 10.5.0 [CU7] - FR 10.5.10 -->

When a shape linked to an element, service, or view was clicked in Visual Overview in the Monitoring app, it opened the Data page for the object instead of the Visual page. Now it will open the Visual page, so that the Monitoring app now has the same behavior as Cube.

#### GQI DxM: A more descriptive error will now be thrown after GQI has tried to retrieve a non-existing query node argument [ID 43476]

<!-- MR 10.5.0 [CU7] - FR 10.5.10 -->

Up to now, after GQI had tried to retrieve a non-existing query node argument, the following internal exception would be thrown:

`Error trapped: Sequence contains no matching element.`

From now on, after GQI has tries to retrieve a non-existing query node argument, the following, more descriptive error will be thrown instead:

`GQI error: Missing argument value for 'Value'.`

#### GQI DxM: Improved performance when handling extensions [ID 43479]

<!-- MR 10.5.0 [CU7] - FR 10.5.10 -->

An enhancement has been implemented to the way the GQI DxM deals with extensions. This will improve performance and also prevent possible performance issues in case a large number of active GQI extension libraries are used, for example when many extension libraries are activated by the Copilot DxM.

#### GQI DxM: A more descriptive error will now be thrown when a column required by a custom operator no longer exist [ID 43491]

<!-- MR 10.5.0 [CU7] - FR 10.5.10 -->

When a column required by a custom operator did no longer exist when a query was executed, up to now, a number of generic errors would be thrown.

From now on, when a column required by a custom operator no longer exist when a query is executed, the following, more descriptive error will be thrown instead:

`Column 'column name' does not exist.`

#### Low-Code Apps: 'Settings' option in '...' menu renamed to 'Permissions' [ID 43536]

<!-- 10.4.0 [CU19] / MR 10.5.0 [CU7] - FR 10.5.10 -->

Up to now, when you opened the "..." menu in the upper-right corner of a low-code app, you could select *Settings* to open the *Application settings* window.

As this window allows you to set the user permissions of the app in question, the menu option has now been renamed from *Settings* to *Permissions*.

#### Dashboards app: A notice will now appear when a PDF report is being generated in a browser tab [ID 43548]

<!-- 10.4.0 [CU19] / MR 10.5.0 [CU7] - FR 10.5.10 -->

When a PDF report is being generated in a particular browser tab, from now on, the following notice will appear:

`Please keep this tab active to ensure the PDF is generated correctly.`

### Fixes

#### GQI DxM: MessageBroker/SLNet not reconnected immediately after app settings change [ID 43386]

<!-- MR 10.5.0 [CU7] - FR 10.5.10 -->

When the app settings for the GQI DxM are modified, the MessageBroker and SLNet connection of the DxM will now be restored immediately. Previously, the reconnect only happened either after functionality attempted to access the connection or when the automatic reconnection was triggered, which happens once per minute. This will prevent the following possible issues that could previously occur:

- When GQI DxM functionality attempted to use the MessageBroker connection while it was disconnected, a deadlock situation could occur that blocked MessageBroker subscriptions.
- When you changed the GQI app settings while a reconnect was already progress, the connection could use a combination of old and new settings.

#### Dashboards app: PDFs would fail to get generated when a browser tab was closed [ID 43449] [ID 43475]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 - note that 43475 reverts the RN in 10.4.0 CU18/10.5.0 CU6/10.5.9, and it was then added again in the current versions without a separate record -->

Each open browser tab has its own WebSocket channel. When such a channel is closed, the Web API checks whether certain resources need to be cleaned up.

Up to now, when a single channel was closed, all temporary PDF files would incorrectly be removed for all connections. As a result, if any PDF was being generated when a channel was closed, that generation would fail.

#### Dashboards/Low-Code Apps: Components sharing GQI sessions could interrupt each other [ID 43470]

<!-- 10.4.0 [CU19] / MR 10.5.0 [CU7] - FR 10.5.10 -->

When different components in a dashboard or low-code-app used the same query, one component could interrupt the data retrieval for the other component, leading to GQI visualizations that were stuck in a loading state.

#### Dashboards app: PDF generation stuck because line chart received unexpected data points [ID 43472]

<!-- 10.4.0 [CU19] / MR 10.5.0 [CU7] - FR 10.5.10 -->

In some cases, it could occur that a line chart in a PDF received unexpected data points from the server, which caused the chart to never be marked as finished. When a PDF was generated of such a chart, the PDF creation process never completed, never resulting in a finished PDF.

#### Dashboards/Low-Code Apps - Table component: Problem when rows were deleted in a real-time update [ID 43478]

<!-- 10.4.0 [CU19] / MR 10.5.0 [CU7] - FR 10.5.10 -->

When a *Table* component with the *Update data* option enabled received an update that deleted a number of rows, up to now, the keys of the rows that were selected at the time of the update would incorrectly not be cleaned up.

As a result, any row that was selected at the time of the update would incorrectly still be selected, and when that selection was re-applied, the row would again be selected.

#### Dashboards app: Dashboard components rendered twice when generating PDF [ID 43490]

<!-- 10.4.0 [CU19] / MR 10.5.0 [CU7] - FR 10.5.10 -->

When a PDF was generated based on a dashboard, it could occur that some components were rendered twice, because they were interpreted both as a feed and as a regular component, which caused the generation time to take much longer than necessary. Now if a component is in the regular components group, it will not also be added in the feed components group, reducing the time it takes to generate the PDF.

#### DataMiner landing page: Certain letters in the DMS name would be cut off when using Firefox [ID 43563]

<!-- 10.4.0 [CU19] / MR 10.5.0 [CU7] - FR 10.5.10 -->

When you opened the DataMiner landing page (by default accessible via `https://<DMA IP or hostname>/root`) in Mozilla Firefox, up to now, certain letters in the DMS name would be cut off, especially letters with descenders like g, j, q, p, or y.
