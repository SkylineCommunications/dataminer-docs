---
uid: Web_apps_Main_Release_10.3.0_CU4
---

# DataMiner web apps Main Release 10.3.0 CU4

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Main Release 10.3.0 CU4](xref:General_Main_Release_10.3.0_CU4).

### Enhancements

#### Legacy reports and dashboards will no longer be prefetched if the soft-launch option 'LegacyReportsAndDashboards' is set to false [ID_35881]

<!-- MR 10.3.0 [CU4] - FR 10.3.6 -->

From now on, legacy reports and dashboards will no longer be prefetched if the soft-launch option *LegacyReportsAndDashboards* is set to false.

#### Security enhancements [ID_36217]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

A number of security enhancements have been made.

#### Dashboards app & Low-Code Apps: No visual replacement will be displayed anymore when a State component feeds empty query rows [ID_36460]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU4] - FR 10.3.7 -->

Up to now, when a *State* component fed empty query rows, a visual replacement would be displayed. From now on, this will no longer be the case.

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

#### Dashboards app: Problem with trend components in PDF reports [ID_36331]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

In a PDF report of a dashboard, in some cases, trend components would collide with other components.

#### GQI: Table unable to feed data when its query included a column manipulation [ID_36350]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

When a query that retrieved object manager instances followed by a column manipulation and a select operator was added to a table component, the table would incorrectly not be able to feed object manager instances to other components.

#### Dashboards app & Low-Code Apps - Table component: Columns with an action applied would not show a loading indication [ID_36376]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

Table columns that had an action applied would incorrectly not show a loading indication. Instead, they would remain empty until the data was loaded.

#### Dashboards app & Low-Code Apps - Line & area chart: Legend would incorrectly show the primary key of a parameter [ID_36381]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

The chart legend would incorrectly show the primary key of a parameter instead of the display key.

#### GQI: Exception thrown when grouping an empty aggregation result [ID_36392]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

An exception would be thrown when executing a query that first applied an aggregation on an Elasticsearch table, which produced an empty result set, and then grouped that empty result set by operation.

Exception that was thrown:

```txt
(*) Error trapped: Unable to cast object of type '<CastIterator>d__97`1[Skyline.DataMiner.Net.SLSearch.Messages.ValueAggregation]' to type 'Skyline.DataMiner.Net.SLSearch.Messages.AggregationContainer'.
```

Example of a query that would cause the above-mentioned exception to be thrown:

```txt
1. Get parameter table by ID (fetches the data from the Elasticsearch table)
2. Filter "column 1" on value "A" (in this particular example, a filter will cause no rows to be returned)
3. Aggregate "column 1"
4. Group by "column 2"
```

#### Dashboards app & Low-Code Apps: A message would no longer be displayed when a component was being migrated [ID_36410]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

A message would incorrectly no longer be displayed when a component was being migrated to the most recent version. From now on, when a component is being migrated, a message showing the component icon and the text *Migrating...* will again be displayed.

#### Dashboards app: Problem when updating a query linked to a feed [ID_36414]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When a dashboard contained a query component that was linked to a feed, the app could become unresponsive when the feed would send updates faster than the time it took to resolve the query.

#### Web API: Problem when migrating queries [ID_36442]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

The web API would no longer be able to correctly migrate queries in which ad hoc data source arguments contained null values.

Also, when those queries were linked to feeds, the migration would break those links.

#### Low-Code Apps: Action to open an already open panel would not resolve [ID_36457]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

Up to now, when an action to open an already open panel was triggered, it would incorrectly not resolve. As a result, all actions configured to be executed upon completion of that *Open* action would not be executed.
