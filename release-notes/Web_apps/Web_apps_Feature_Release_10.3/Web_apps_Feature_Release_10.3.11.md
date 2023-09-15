---
uid: Web_apps_Feature_Release_10.3.11
---

# DataMiner web apps Feature Release 10.3.11 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.11](xref:General_Feature_Release_10.3.11).

## Highlights

*No highlights have been selected yet.*

## New features

#### GQI: Resources data source now allows filtering by resource pool ID or booking ID [ID_36970]

<!-- MR 10.4.0 - FR 10.3.11 -->

The *Resources* data source now allows you to filter resources by resource pool ID or booking ID.

> [!NOTE]
>
> - The *Resources* data source is only available on systems with a *ResourceManager* license and/or an *IDP* license.
> - Currently, the *Resources* data source still requires the *GenericInterface* [soft-launch option](xref:SoftLaunchOptions).

#### Dashboards app & Low-Code Apps - GQI components: New setting 'Empty result message' [ID_37173]

<!-- MR 10.4.0 - FR 10.3.11 -->

All GQI components now have a new *Empty result message* setting that allows you to personalize the message that will be displayed when the GQI query returns an empty result set. Default message: "Nothing to show." Note that this setting cannot be left empty.

Also, the error/warning/info visual will now only appear when the component's size exceeds about half the screen dimensions, both in width and in height.

As to the *Table* component, when you applied a column filter that resulted in 0 rows, up to now, an empty window replacing the component would allow you to adjust the filter. From now on, even when a column filter yields 0 rows, the column headers will stay visible and a message will appear (i.e. either the above-mentioned *Empty result message* or a message saying that the column/search filter resulted in no rows).

## Changes

### Enhancements

#### DataMiner Object Models: Auto-increment fields will no longer be visualized using input boxes [ID_37181]

<!-- MR 10.4.0 - FR 10.3.11 -->

An `AutoIncrementField` contains a unique value that is automatically incremented each time a DOM instance is created.

Up to now, on web forms used to create or edit a DOM instance, auto-increment fields were incorrectly visualized using an input box. From now on, on web forms used to create a DOM instance, these fields will no longer be visualized, and on web form used to edit a DOM instance, these fields will be visualized as read-only fields.

#### DataMiner Object Models: Enhanced performance when processing GQI count aggregation queries [ID_37187]

<!-- MR 10.4.0 - FR 10.3.11 -->

In GQI, up to now, when you applied an aggregation node of type *count* to a query starting from *Object manager instances* (DOM instances), all objects would be retrieved from the database. From now on, count operations will be sent to the database. This will significantly improve the performance of this kind of GQI queries.

The optimization applies when the following conditions are met:

- The GQI query starts with *Object manager instances*.
- Only one aggregation node is applied to column *ID* with method *COUNT*.

In all other cases (e.g. multiple aggregation nodes, grouping, different columns), all objects will still be retrieved from the database.

#### Dashboards app/Low-Code Apps - Visual Overview component: Initial visual overview data will now be retrieved asynchronously [ID_37341]

<!-- MR 10.4.0 - FR 10.3.11 -->

Up to now, a dashboard containing Visual Overview components would retrieve the initial visual overview data synchronously. From now on, the initial visual overview data will be retrieved asynchronously.

### Fixes

#### Dashboards app - Web component: Embedded website would not function correctly [ID_37207]

<!-- MR 10.4.0 - FR 10.3.11 -->

When, on a dashboard, a website was embedded using a Web component, in some cases, the embedded website would not function correctly.

#### Dashboards app/Low-Code Apps: Initial selection of a component would not be applied when the query was replaced [ID_37230]

<!-- MR 10.4.0 - FR 10.3.11 -->

The initial selection of a table, state or timeline component would incorrectly not be applied when the query of the component was replaced by another one.

#### Dashboards app/Low-Code Apps: Query builder would display incorrect date/time values when a custom time zone had been configured [ID_37234]

<!-- MR 10.4.0 - FR 10.3.11 -->

Up to now, when you had configured a custom time zone, date/time values displayed in the query builder (fed through a time range component) would be incorrect.

#### Dashboards app/Low-Code Apps - Stepper component: Long stepper state names would be cut off [ID_37242]

<!-- MR 10.4.0 - FR 10.3.11 -->
<!-- Not added to MR 10.4.0 -->

Up to now, long stepper state names would be cut off. From now on, stepper state names will be able to wrap.

The text will take up as much horizontal and vertical space as possible, and any overflow will be ellipsed.

#### GQI: Problem when retrieving logger table data from an Elasticsearch database [ID_37251]

<!-- MR 10.4.0 - FR 10.3.11 -->

When a GQI query retrieved logger table data from an Elasticsearch database, the row keys would be filled in incorrectly. As a result, not all rows would have a unique key.

#### Dashboards app/Low-Code Apps: Stepper component would be unable to handle asynchronous saving of DOM instance history records [ID_37252]

<!-- MR 10.4.0 - FR 10.3.11 -->
<!-- Not added to MR 10.4.0 -->

Up to now, the *Stepper* component was not able to handle asynchronous saving of DOM instance history records. While saving, in some cases, it would retrieve the history records of the DOM instance before the latest records had been added.

#### Dashboards app/Low-Code Apps: Stepper component would apply an incorrect theme color [ID_37263]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

In some cases, the *Stepper* component would not apply the correct theme color.

#### Dashboards app/Low-Code Apps: Problem with custom time zones [ID_37278]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When a custom time zone was used, in some cases, that time zone would not be processed correctly.

For example, when you set a custom time zone in a *Clock* component, the current time of that custom time zone would not be identical to the current time of the local time zone.

> [!NOTE]
> This problem would mostly occur when using a time zone that no longer observed daylight saving time (e.g. Altai Standard Time).

#### Monitoring app: Casing problem when using NavigatePage [ID_37279]

<!-- MR 10.4.0 - FR 10.3.11 -->

When, in the *Monitoring* app, a visual overview page was opened using a shape data field of type *NavigatePage*, the value of this field was case sensitive. When the casing of the value was different from the casing of the page name, the page would not open. From now on, the casing of the value and that of the page name will be disregarded.

#### Problem with the IIS web server when redirecting the user to the login page [ID_37288]

<!-- MR 10.4.0 - FR 10.3.11 -->

In some cases, an error could occur in the IIS web server when redirecting the user to the login page.
