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

#### Dashboards app & Low-Code Apps: Deleting components by pressing the DELETE button [ID_36753]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

You can now delete components by pressing the *DELETE* button on your keyboard.

1. In Edit mode, select the component(s) you want to delete.
1. Press the *DELETE* button.

### Fixes

#### Low-Code Apps: Incorrect error message would appear when you tried to edit an app that you were not allowed to edit [ID_36650]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

When you tried to open the edit mode of a low-code app that you were not allowed to edit, an incorrect error message would appear.

#### Monitoring app: Problem when receiving parameter table updates via polling [ID_36660]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.8 -->

When, in the *Monitoring* app, a parameter table received updates via polling, the table would display `There is no data to display`.

#### Referenced DomInstances would not get updated when a DomInstance was created or updated [ID_36734]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

When a DomInstance was created or updated, the DomInstances that were referenced by that DomInstance would incorrectly not get updated unless the browser window was refreshed.

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

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When you deleted a component from a dashboard, an `UpdateDashboard` call would incorrectly be sent twice.

#### Dashboards app: Problem when clicking 'Start with a blank dashboard' [ID_36798]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When you clicked *Start with a blank dashboard* twice in rapid succession, two pop-up windows would open.

#### Low-Code Apps: Not possible to feed a selected timeline item to a component on a panel [ID_36820]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

Up to now, it would incorrectly not be possible to feed a selected timeline item to a component on a panel of a low-code app.

#### Dashboards app & Low-Code Apps: User menu would not close when clicking the user icon [ID_36829]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When you had opened the user menu by clicking the user icon in the top-right corner, that menu would not close when you clicked the user icon a second time.

#### Problem when sharing a dashboard containing a Gauge component fed by a State component with indices [ID_36872]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

In some cases, an error could be thrown when you shared a dashboard that contained a *Gauge* component fed by a *State* component with indices.

#### Web services API: Problem when fetching the next page of a GQI query [ID_36903]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

When a table visualization fetched the next page of a GQI query, GQI would throw an exception saying that the session was already closed.

This was due to GQI incorrectly closing the session automatically after 5 minutes of inactivity.

#### Dashboards app & Low-Code Apps - GQI: Not possible to link empty feeds to ad hoc arguments [ID_36913]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

Up to now, when empty feeds had not yet been initialized with a value, it would not be possible to link those feeds to ad hoc arguments.

From now on, it will always be possible to link feeds to ad hoc arguments, regardless of their value.

#### Dashboards app & Monitoring app: Problem with parameter table component when switching from mobile view to desktop view [ID_36949]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

When the Dashboards app or the Monitoring app switched from mobile view to desktop view, the parameter table component would incorrectly continue to use the mobile UI.

#### Dashboards app: Problem when generating a PDF file with a custom paper size [ID_36968]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When a PDF file with a custom paper size was generated, the following error would be thrown:

`Cannot read properties of undefined (reading 'width')'.`

#### Dashboards app & Low-Code Apps: Problem when exporting a table with a query row feed to a CSV file [ID_36969]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

Up to now, an error would be thrown when you tried to export a table with a query row feed to a CSV file.

#### Low-Code Apps: Problem when a form component linked to a DOM instance feed was not fed an instance [ID_37000]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

When a form component linked to a DOM instance feed was not fed an instance, it would get stuck in a loading state.

#### Dashboards app & Low-Code Apps: Form component would not be cleared when it was no longer fed a DOM instance or a DOM definition [ID_37001]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

The *Form* component would not be cleared when it was no longer fed a DOM instance or a DOM definition.

#### Dashboards app: 'Loading...' indicator would appear when trying to save a nameless folder [ID_37002]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When, in the *Create folder* or *Create dashboard* window, you clicked inside the *Location* box, clicked "+" to add a new folder, entered a folder name, cleared that same folder name, and then clicked the checkmark button, a "Loading..." indicator would appear at the top of the window but nothing would happen.

#### Low-Code Apps: Header bar changes would not be shown in preview mode [ID_37005]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

When changes had been made to the header bar of a low-code app, those changes would incorrectly not be shown when you switched to preview mode.

#### Monitoring app: Problem when no view properties were shown in the Surveyor [ID_37010]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When you opened the *Monitoring* app, an error could occur when no view properties were shown in the Surveyor.

#### Monitoring app & Dashboards app: Cleared alarm groups would incorrectly still appear in alarm lists [ID_37045]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When you opened the Alarm Console in the *Monitoring* app or an alarm list in the *Dashboards* app, alarm groups that had already been cleared would incorrectly still appear in the list.
