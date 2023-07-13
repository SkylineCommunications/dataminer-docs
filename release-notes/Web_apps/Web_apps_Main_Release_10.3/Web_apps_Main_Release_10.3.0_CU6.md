---
uid: Web_apps_Main_Release_10.3.0_CU6
---

# DataMiner web apps Main Release 10.3.0 CU6 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Main Release 10.3.0 CU6](xref:General_Main_Release_10.3.0_CU6).

### Enhancements

#### GQI: Enhanced behavior of aggregations applied on empty Elasticsearch tables [ID_36490]

<!-- MR 10.3.0 [CU6] - FR 10.3.8 -->

Up to now, when an aggregation (min, max, average) was applied on an empty Elasticsearch table, the following exception would be thrown:

`Error trapped: Elastic returned unexpected value ''.`

From now on, when an aggregation (min, max, average) is applied on an empty Elasticsearch table, an empty cell will be returned instead.

Because of this change, the behavior of aggregations applied on all types of empty tables becomes more consistent:

| Type | RawValue | DisplayValue |
|------|----------|--------------|
| Avg/Min/Max/Median | null | "Not applicable" |
| (Distinct) Count   | 0    | 0                |
| Std dev/Percentile | null | "Not applicable" |
| Sum                | 0    | 0                |

### Fixes

#### Dashboards app: Black boxes on top of first or last field of selection boxes on small screens [ID_36738]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When you reduced the screen size to the point at which the navigation pane got hidden, a black box would incorrectly appear on top of the first or last field of a selection box.

#### Dashboards app & Low-Code Apps: Table component would show skeleton loading when refetching data with external column filters applied [ID_36743]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

A table component would show skeleton loading when it refetched data with external column filters applied. From now on, a table component will only show skeleton loading during the initial fetch.

#### Low-Code Apps: Creating an app with an existing name would incorrectly be possible [ID_36744]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

Up to now, it would incorrectly be possible to create a low-code app with a name that was identical to that of an existing app.

From now on, when you try to create an app with a name that is identical to that of an existing app, an error will be thrown.

#### Dashboards app: Problems with shared dashboards [ID_36752]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

When you viewed a shared dashboard that you were not allowed to edit, in some cases, the dashboard would incorrectly be updated in the background, causing an error to be thrown.

Also, when you refreshed a shared dashboard while it was in edit mode, edit mode would incorrectly be closed.

#### Dashboards app: 'UpdateDashboard' call was sent twice when deleting a component [ID_36766]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

When you deleted a component from a dashboard, an `UpdateDashboard` call would incorrectly be sent twice.

#### Dashboards app: Problem when clicking 'Start with a blank dashboard' [ID_36798]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When you clicked *Start with a blank dashboard* twice in rapid succession, two pop-up windows would open.

#### Low-Code Apps: Not possible to feed a selected timeline item to a component on a panel [ID_36820]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

Up to now, it would incorrectly not be possible to feed a selected timeline item to a component on a panel of a low-code app.
