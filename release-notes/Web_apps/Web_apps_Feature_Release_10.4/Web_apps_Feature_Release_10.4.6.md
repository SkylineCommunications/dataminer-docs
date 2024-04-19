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

## New features

#### Low-Code Apps: Parameter table filter feeds are now also supported [ID_39335]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

Low-code apps now also support parameter table filter feeds if the URL option `showAdvancedSettings=true` is used.

This type of filter supports both VALUE and FULLFILTER syntax. For more information on this syntax, see [Dynamic table filter syntax](xref:Dynamic_table_filter_syntax).

> [!NOTE]
> You can use feeds found either on the same page or on another page.

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

#### Dashboards app & Low-Code Apps - Spectrum analyzer component: Clearer indication that the component is busy loading [ID_39427]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

From now on, a *Spectrum analyzer* component will indicate in a clearer way that it is busy loading.

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

#### Low-Code Apps: Problem when multiple DOM instances had to be passed to a script [ID_39391]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

Up to now, when you selected multiple DOM instances in a table (while holding the SHIFT button pressed) and then executed a script that used the feeds of those DOM instances as input parameters, only the first DOM instance you selected would be passed to the script. From now on, an array containing all selected DOM instances will be passed to the script.
