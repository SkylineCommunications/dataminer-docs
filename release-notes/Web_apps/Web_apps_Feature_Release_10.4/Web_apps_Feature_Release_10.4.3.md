---
uid: Web_apps_Feature_Release_10.4.3
---

# DataMiner web apps Feature Release 10.4.3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.3](xref:General_Feature_Release_10.4.3).

## Highlights

*No highlights have been selected yet.*

## New features

#### Low-Code Apps: 'Show a notification' action [ID_38548]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When editing a low-code app, it is now possible to configure *Show a notification* actions. These will allow you to show a notification in the bottom-right corner of the app.

When configuring a *Show a notification* action, the following properties should be specified:

- **Title** (mandatory): The title of the notification.
- **Message** (optional): The text of the notification.
- **Duration** (optional): The amount of seconds the notification will be displayed.

  When you do not specify a duration, the notification will stay visible until the user closes it manually.

> [!NOTE]
>
> - The maximum number of open notifications is 100. When a new notification appears when 100 notifications are open, the oldest one will automatically be removed.
> - Only the first 80 characters of a title will be displayed.
> - Only the first 400 characters of a message will be displayed.

## Changes

### Enhancements

#### DataMiner Object Models: Enhanced performance of DomInstanceFieldDescriptor and DomInstanceValueFieldDescriptor in web forms [ID_37546]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

The overall performance of `DomInstanceFieldDescriptor` and `DomInstanceValueFieldDescriptor` has increased.

Up to now, all options were loaded in the field on the web form. This had a negative impact on performance, especially on large setups. From now on, the fields will only load the first 100 instances and show a warning that not all fields have been loaded.

When a `DomInstanceValueFieldDescriptor` refers to a FieldDescriptor that is part of a SectionDefinition that allows multiple sections, the web form field will only show the first value it finds. If a DomInstance does not contain a value for that FieldDescriptor, only the DomInstance name will be shown.

The display value of the `DomInstanceValueFieldDescriptor` will now be one of the following:

- `<DomInstanceName>: <FieldValue>` (for instances that have a FieldValue)
- `<DomInstanceName>: <FieldValue1>, <FieldValue2>, ...` (for instances that have a FieldValue list)
- `<DomInstanceName>` (for instances that have no FieldValue)
- The ID of the DomInstance (if there is no DomInstanceName)

In a web form, values in a `DomInstanceValueFieldDescriptor` or `DomInstanceFieldDescriptor` selection box will now be alphabetically sorted based on DomInstance name.

> [!NOTE]
>
> - A `DomInstanceValueFieldDescriptor` cannot refer to a `StaticTextFieldDescriptor`, a `DomInstanceFieldDescriptor` or another `DomInstanceValueFieldDescriptor`.
> - A `DomInstanceValueFieldDescriptor` that refers to another `DomInstance(Value)FieldDescriptor` will only display the name (or the ID if there is no name) of the DomInstance to avoid performance degradation when fetching instances.
> - DisplayValue is limited to 70 characters to avoid performance degradation.

#### Dashboards app & Low-Code Apps: Redesigned popup windows [ID_38278]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

In the Dashboards app and the low-code apps, the popup windows have been redesigned.

#### Dashboards app & Low-Code Apps - Template editor: All overrides now have a reset button [ID_38368]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

Up to now, when working with the template editor, only text overrides could be reset. From now on, all overrides have a dedicate reset button.

#### DataMiner web apps updated to Angular 17 [ID_38468]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

The DataMiner mobile apps that use Angular (e.g. Low-Code Apps, Dashboards, Monitoring, Ticketing, Jobs, Automation, etc.) now all use Angular 17.

### Fixes

#### Dashboards app: Problem when an error occurred while creating a dashboard [ID_38310]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

Up to now, when an error occurred while creating a new dashboard, the items already created before the error occurred (e.g. the folder) would incorrectly not get cleaned up.

#### Dashboards app & Low-Code Apps: List of visualizations would not contain data-related visualizations [ID_38319]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When you wanted to change the visualization of a component, up to now, the list of visualizations to choose from would only contain component-related visualizations. Data-related visualizations would not be shown.

From now on, when you want to change the visualization of a component, the list of visualizations will contain data-related visualizations only.

#### Dashboards app & Low-Code Apps - GQI: Queries would be fetched twice [ID_38335]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

In some cases, a query would be fetched twice: once with old feed values filled in and once with new feed values filled in.

As the component was still in a loading state, users would only notice that it took longer for the data to appear.

#### Dashboards app & Low-Code Apps - GQI: Problem when multiple column manipulations had been configured on the same column [ID_38338]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

In some cases, a query would throw an error when multiple column manipulations had been configured on the same column.

#### Low-Code Apps: Template editor would close when you pressed ESCAPE in the event editor [ID_38353]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When, in the template editor, you pressed ESCAPE while the event editor window was open, both the event editor window and the template editor window would incorrectly be closed.

#### Dashboards app & Low-Code Apps - Template editor: Problems with enum columns [ID_38369]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

A number of enum column issues have been fixed in the template editor.

#### Dashboards app & Low-Code Apps - Line & area chart component: Trend data would not always be loaded in the same order [ID_38385]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

Up to now, a *Line & area chart* component would not always load the data in the same order.

#### Dashboards app & Low-Code Apps - Generic map component: No longer possible to select a map configuration file [ID_38394]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When configuring a *Generic map* component, it would incorrectly no longer be possible to select a map configuration file.

#### Web apps - Interactive Automation scripts: Problem when entering decimal numbers [ID_38396]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

In interactive Automation scripts launched from a web app, it would no longer be possible to enter a decimal number of which the first digit after the separator was a zero.

When you entered a decimal number of which the first digit after the separator was a zero (e.g. 4.02), both the separator and the zero would incorrectly be dropped.

#### Dashboards app - Table component: Sorting would not always be applied [ID_38413]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When you sorted a table component by a particular column and then refreshed the dashboard, in some cases, the column would be marked as sorted although no sorting was applied.

#### Dashboards app - GQI: Problem when fetching a GQI result [ID_38420]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When a GQI result was being fetched, in some cases, the following error could be thrown:

```txt
Error: Uncaught (in promise): TypeError: Cannot read properties of undefined (reading 'then')
TypeError: Cannot read properties of undefined (reading 'then')
```

#### Dashboards app: Problems with tables when generating PDF reports [ID_38428]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When a PDF report was generated, the custom height of a table cell template would not be applied. As a result, certain tables in the PDF file would not be identical to their counterpart on the dashboard.

Also, selected table rows would not be visible in a PDF file when the table had a dark background.

#### Dashboards app: PDF report showed a 'There are no open sessions' error while the dashboard did not [ID_38446]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When a PDF report had been generated, in some cases, that report showed a `There are no open sessions` error while the dashboard did not.

#### Low-Code Apps - Table component: Problem with component action 'Select an item' [ID_38462]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

In some cases, the table component action *Select an item* would not work.

#### Dashboards app & Low-Code Apps - Grid component: Loader bar would incorrectly appear behind any selected items [ID_38466]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When you had selected an item at the top of a grid component, the loader bar would incorrectly appear behind the selected item.

From now on, when the loader bar appears while an item is selected, it will always appear in front of the selected item.

#### Monitoring app: Incorrect alignment of element parameters [ID_38482]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

In the Monitoring app, parameter values displayed on element pages would not be aligned correctly.

Also, values of analog range parameters would be displayed twice.

#### Dashboards app: Parameter data set filters would no longer be applied after adding a parameter to a dashboard [ID_38503]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

After you had added a parameter to a dashboard, the checkbox filters on the parameter data set would incorrectly no longer be applied.

#### Low-Code Apps: 'Show context menu' action would incorrectly also be available outside the template editor [ID_38526]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

The *Show context menu* action, which should only be available in the template editor, would incorrectly also be available in button components, page events, header actions, etc.

#### Dashboards app: Problem when web API cache re-initialized itself [ID_38531]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When a large number of dashboard files were updated or deleted, the cache of the web APIs could re-initialize itself. In some cases, this would lead to the web APIs to become unresponsive, causing operations like retrieving a list of dashboards or updating a dashboard to fail.

#### Dashboards app: Problem when trying to cancel the deletion of a query [ID_38540]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When you tried to cancel the deletion of a query used in a component, an error could be thrown.

#### Dashboards app - Table component: Problem with CSV exports including text fields that contained double quotes [ID_38550]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When you exported table data with text fields that contained double quotes (") to a CSV file, and then tried to import that file into e.g. Microsoft Excel, the data in the file would not get imported correctly.
