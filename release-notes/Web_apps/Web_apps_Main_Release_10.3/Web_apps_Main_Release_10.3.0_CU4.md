---
uid: Web_apps_Main_Release_10.3.0_CU4
---

# DataMiner web apps Main Release 10.3.0 CU4 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Main Release 10.3.0 CU4](xref:General_Main_Release_10.3.0_CU4).

### Enhancements

#### Legacy reports and dashboards will no longer be prefetched if the soft-launch option 'LegacyReportsAndDashboards' is set to false [ID_35881]

<!-- MR 10.3.0 [CU4] - FR 10.3.6 -->

From now on, legacy reports and dashboards will no longer be prefetched if the soft-launch option *LegacyReportsAndDashboards* is set to false.

#### Security enhancements [ID_36217]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

A number of security enhancements have been made.

### Fixes

#### Dashboards app & Low-Code Apps - Line chart: X and Y axis labels would not show the correct text [ID_35943]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

The X and Y axis labels of a line chart would not show the correct text when the data was grouped.

#### Dashboards app & Low-Code Apps: Components would prematurely consider themselves loaded [ID_36142]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

In some cases, components would incorrectly consider themselves loaded while they were still loading. As a result, it would already be possible to execute actions on those components before those actions could be properly processed.

#### Low-Code Apps: Action buttons could have an incorrect background color [ID_36258]

<!-- MR 10.3.0 [CU4] - FR 10.3.6 -->

In some cases, action buttons could have an incorrect background color.

#### Dashboards app & Low-Code Apps: State component would incorrectly not be cleared when its input feed was cleared [ID_36261]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In some cases, a *State* component would incorrectly not be cleared when its input feed was cleared.

#### Low-Code Apps: Table actions would incorrectly be executed before the rows were fed [ID_36263]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In some cases, table actions would be executed before the rows were fed. As a result, the feed would get lost when you navigated away from the page via an action. From now on, a row will always be fed before row actions are executed.

#### Low-Code Apps: Custom icon of a low-code app without a draft version would not be displayed on the DataMiner landing page [ID_36277]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When a low-code app with a custom icon did not have a draft version, the DataMiner landing page would incorrectly not display the icon of that app.

#### Dashboards app: Height of 'DATA USED IN DASHBOARD' section would incorrectly change after collapsing and expanding it [ID_36282]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you collapsed and expanded the *DATA USED IN DASHBOARD* section of the *DATA* tab, in some cases, the height of that section would incorrectly change.

#### Dashboards app & Low-Code Apps: Updating a query would incorrectly not update the query filter component [ID_36283]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

When a query was updated, the query filter component would incorrectly only get updated after a refresh.

#### Monitoring app: Surveyor items would be sorted incorrectly [ID_36303]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In the Surveyor of the Monitoring app, items of which the name contained a number would be sorted incorrectly. For example, *Element 2* would appear below *Element 11*. From now on, the items in the Surveyor of the Monitoring app will be sorted in the same way as those in the Surveyor of DataMiner Cube.

#### Dashboards app & Low-Code Apps - Table component: Columns with an action applied would not show a loading indication [ID_36376]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

Table columns that had an action applied would incorrectly not show a loading indication. Instead, they would remain empty until the data was loaded.

#### Dashboards app & Low-Code Apps - Line & area chart: Legend would incorrectly show the primary key of a parameter [ID_36381]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

The chart legend would incorrectly show the primary key of a parameter instead of the display key.
