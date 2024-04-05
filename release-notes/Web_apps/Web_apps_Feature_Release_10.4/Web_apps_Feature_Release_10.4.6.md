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

*No new features have been added yet.*

## Changes

### Enhancements

#### Web apps: Improved startup performance because of waffle menu enhancements [ID_39208]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

Because of a number of enhancements made to the waffle menu, overall performance has increased when opening a web app.

### Fixes

#### Dashboards app: 'DATA USED IN DASHBOARD' section would not be hidden when empty [ID_39274]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

Up to now, when a dashboard did not contain any components that used data, the *DATA* tab would incorrectly still contain a *DATA USED IN DASHBOARD* section.

From now on, when empty, the *DATA USED IN DASHBOARD* section will no longer be displayed.

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

#### Dashboards app & Low-Code Apps - Column & bar chart and Pie & donut chart components: Problem when refetching data that was being fetched [ID_39312]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

In some cases, a `Request was aborted` error could appear when a *Column & bar chart* component or a *Pie & donut chart* component refetched data while that same data was being fetched.
