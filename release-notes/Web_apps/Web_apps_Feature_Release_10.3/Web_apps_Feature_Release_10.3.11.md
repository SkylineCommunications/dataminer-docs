---
uid: Web_apps_Feature_Release_10.3.11
---

# DataMiner web apps Feature Release 10.3.11

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.3.11](xref:General_Feature_Release_10.3.11).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.11](xref:Cube_Feature_Release_10.3.11).

## New features

#### Dashboards app & Low-Code Apps - GQI components: New setting 'Empty result message' [ID 37173]

<!-- MR 10.4.0 - FR 10.3.11 -->

All GQI components now have a new *Empty result message* setting that allows you to personalize the message that will be displayed when the GQI query returns an empty result set. Default message: "Nothing to show." Note that this setting cannot be left empty.

Also, the error/warning/info visual will now only appear when the component's size exceeds about half the screen dimensions, both in width and in height.

As to the *Table* component, when you applied a column filter that resulted in 0 rows, up to now, an empty window replacing the component would allow you to adjust the filter. From now on, even when a column filter yields 0 rows, the column headers will stay visible and a message will appear (i.e. either the above-mentioned *Empty result message* or a message saying that the column/search filter resulted in no rows).

#### Low-Code Apps: Dynamic feed values in URL actions [ID 37229]

<!-- MR 10.4.0 - FR 10.3.11 -->

When configuring an event to navigate to a URL, you can now insert dynamic references to feed values into the URL using the following syntax:

`{FEED.Source name.Feed name.Category name.Data type.Property name}`

- **FEED**: A fixed keyword to indicate that the variable represents a feed link.
- **Source name**: The name of the page or panel of the low-code app. Example: "Page 1"
- **Feed name**: The name of the feed. Example: "Table 3"
- **Category name**: The part of the feed that will contain the data. Example: "Selected rows"
- **Data type**: The type of data. Example: "Elements"
- **Property name**: The property of the fed data that should be used. Example: "Protocol Name"

The following example would result in something like "*My element Localhost is from protocol Microsoft Platform*".

*My element `{FEED."Page 1"."Dropdown 3"."Selected item".Elements.Name}` is from protocol `{FEED."Page 1"."Dropdown 3"."Selected item".Elements."Protocol Name"}`.*

> [!NOTE]
>
> - Any part that contain spaces should be enclosed by double quotes.
> - The name of each part can be found in the *FEEDS* data source of the edit panel's *DATA* tab.

#### Dashboards app & Low-Code Apps: A backup of all existing dashboards and low-code apps will now be made when performing a DataMiner upgrade  [ID 37413]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

When you install a DataMiner upgrade (either a full upgrade or a web-only upgrade), a backup of all existing dashboards and low-code apps on the system will now be made.

After a DataMiner upgrade, all dashboards and low-code apps will, if necessary, be migrated in order to make them compatible with the newer software versions. If an error occurs during this migration, or if you need to perform a DataMiner downgrade, you will now be able to restore the dashboards and low-code apps stored in the backup. However, note that restoring these items will have to be done manually.

All backups of dashboards and low-code apps will be stored in `C:\Skyline DataMiner\System Cache\Web\Backups`.

## Changes

### Enhancements

#### DataMiner Object Models: Auto-increment fields will no longer be visualized using input boxes [ID 37181]

<!-- MR 10.4.0 - FR 10.3.11 -->

An `AutoIncrementField` contains a unique value that is automatically incremented each time a DOM instance is created.

Up to now, on web forms used to create or edit a DOM instance, auto-increment fields were incorrectly visualized using an input box. From now on, on web forms used to create a DOM instance, these fields will no longer be visualized, and on web form used to edit a DOM instance, these fields will be visualized as read-only fields.

#### DataMiner Object Models: Enhanced performance when processing GQI count aggregation queries [ID 37187]

<!-- MR 10.4.0 - FR 10.3.11 -->

In GQI, up to now, when you applied an aggregation node of type *count* to a query starting from *Object manager instances* (DOM instances), all objects would be retrieved from the database. From now on, count operations will be sent to the database. This will significantly improve the performance of this kind of GQI queries.

The optimization applies when the following conditions are met:

- The GQI query starts with *Object manager instances*.
- Only one aggregation node is applied to column *ID* with method *COUNT*.

In all other cases (e.g. multiple aggregation nodes, grouping, different columns), all objects will still be retrieved from the database.

#### Dashboards app/Low-Code Apps - Stepper component: DOM instances without history will now default to the happy path [ID 37233]

<!-- MR 10.4.0 - FR 10.3.11 -->
<!-- Not added to MR 10.4.0 -->

A DOM instance without history will now default to the happy path, i.e. the path that illustrates the states an instance would undergo following the standard workflow.

#### Dashboards app: Components will now only show skeleton loading during the initial load [ID 37274]

<!-- MR 10.4.0 - FR 10.3.11 -->

Up to now, some components would show skeleton loading until after the data had been loaded. From now on, those components will only show skeleton loading during the initial load.

#### Dashboards app/Low-Code Apps - Visual Overview component: Initial visual overview data will now be retrieved asynchronously [ID 37341]

<!-- MR 10.4.0 - FR 10.3.11 -->

Up to now, a dashboard containing Visual Overview components would retrieve the initial visual overview data synchronously. From now on, the initial visual overview data will be retrieved asynchronously.

#### Web Services API: ConvertQueryToProtoJson web method now supports node keys [ID 37360]

<!-- MR 10.4.0 - FR 10.3.11 -->

Before you can add a GQI query to the Data Aggregator configuration file, you have to convert it first by means of the *ConvertQueryToProtoJson* web method. This method now supports node keys.

#### Security enhancements [ID 37421] [ID 37426]

<!-- RN 37421/37426: MR 10.4.0 - FR 10.3.11 -->

A number of security enhancements have been made.

### Fixes

#### Low-Code Apps: Page configuration would not be copied along when duplicating a page [ID 37120]

<!-- MR 10.4.0 - FR 10.3.11 -->

When a page was duplicated, up to now, the page configuration would not be copied along. As a result, certain page settings would be missing.

#### Dashboards app - Web component: Embedded website would not function correctly [ID 37207]

<!-- MR 10.4.0 - FR 10.3.11 -->

When, on a dashboard, a website was embedded using a Web component, in some cases, the embedded website would not function correctly.

#### Low-Code Apps: Size of sidebar icon was different when editing an app [ID 37223]

<!-- MR 10.4.0 - FR 10.3.11 -->

When an app was edited, the size of the sidebar icon was different than when that same app was viewed in either preview mode or published mode.

#### Dashboards app/Low-Code Apps: Initial selection of a component would not be applied when the query was replaced [ID 37230]

<!-- MR 10.4.0 - FR 10.3.11 -->

The initial selection of a table, state or timeline component would incorrectly not be applied when the query of the component was replaced by another one.

#### Dashboards app/Low-Code Apps: Query builder would display incorrect date/time values when a custom time zone had been configured [ID 37234]

<!-- MR 10.4.0 - FR 10.3.11 -->

Up to now, when you had configured a custom time zone, date/time values displayed in the query builder (fed through a time range component) would be incorrect.

#### Dashboards app/Low-Code Apps - Stepper component: Long stepper state names would be cut off [ID 37242]

<!-- MR 10.4.0 - FR 10.3.11 -->
<!-- Not added to MR 10.4.0 -->

Up to now, long stepper state names would be cut off. From now on, stepper state names will be able to wrap.

The text will take up as much horizontal and vertical space as possible, and any overflow will be ellipsed.

#### GQI: Problem when retrieving logger table data from an Elasticsearch database [ID 37251]

<!-- MR 10.4.0 - FR 10.3.11 -->

When a GQI query retrieved logger table data from an Elasticsearch database, the row keys would be filled in incorrectly. As a result, not all rows would have a unique key.

#### Dashboards app/Low-Code Apps: Stepper component would be unable to handle asynchronous saving of DOM instance history records [ID 37252]

<!-- MR 10.4.0 - FR 10.3.11 -->
<!-- Not added to MR 10.4.0 -->

Up to now, the *Stepper* component was not able to handle asynchronous saving of DOM instance history records. While saving, in some cases, it would retrieve the history records of the DOM instance before the latest records had been added.

#### Dashboards app/Low-Code Apps: Stepper component would apply an incorrect theme color [ID 37263]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

In some cases, the *Stepper* component would not apply the correct theme color.

#### Dashboards app/Low-Code Apps: Problem with custom time zones [ID 37278]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When a custom time zone was used, in some cases, that time zone would not be processed correctly.

For example, when you set a custom time zone in a *Clock* component, the current time of that custom time zone would not be identical to the current time of the local time zone.

> [!NOTE]
> This problem would mostly occur when using a time zone that no longer observed daylight saving time (e.g. Altai Standard Time).

#### Monitoring app: Casing problem when using NavigatePage [ID 37279]

<!-- MR 10.4.0 - FR 10.3.11 -->

When, in the *Monitoring* app, a visual overview page was opened using a shape data field of type *NavigatePage*, the value of this field was case sensitive. When the casing of the value was different from the casing of the page name, the page would not open. From now on, the casing of the value and that of the page name will be disregarded.

#### Problem with the IIS web server when redirecting the user to the login page [ID 37288]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

In some cases, an error could occur in the IIS web server when redirecting the user to the login page.

#### Monitoring app: Problem when opening another visual overview page using 'NavigatePage' [ID 37338]

<!-- MR 10.4.0 - FR 10.3.11 -->

When, in the *Monitoring* app, another visual overview page was opened using a shape data field of type *NavigatePage*, the rest of the application would incorrectly not reflect this.

#### Dashboards app/Low-Code Apps - Parameter table: Problem with Copy command in right-click menu [ID 37357]

<!-- MR 10.4.0 - FR 10.3.11 -->

When, in a *Parameter table* component, it would not be possible to copy a cell, a row, a column or the entire table using the *Copy* command in the right-click menu.

#### Low-Code Apps: First column of table with multiple queries could be empty [ID 37363]

<!-- MR 10.4.0 - FR 10.3.11 -->

When actions had been configured on a table visualization with multiple queries, in some cases, the first column would be empty.

#### Low-Code Apps: Problem with 'Execute component' action [ID 37364]

<!-- MR 10.4.0 - FR 10.3.11 -->

When you edited an existing action, in some cases, the *Execute component* action would not be able to properly restore the form.

#### Dashboards app/Low-Code Apps: Feed linker would no longer select the feed type when there was only a single option [ID 37396]

<!-- MR 10.4.0 - FR 10.3.11 -->

The feed linker would no longer automatically select the feed type when there was only a single option. Moreover, as it was not possible to open the dropdown box, no feed could be selected manually either.

#### Monitoring app: Problem when navigating to another visual overview page [ID 37415]

<!-- MR 10.4.0 - FR 10.3.11 -->

When, in the *Monitoring* app, you selected an element or a service, and navigated to another visual overview page, a `Cannot convert null to a value type` error would be thrown.

#### Low-Code Apps: No longer possible to edit a newly created app after refreshing one of its pages [ID 37425]

<!-- MR 10.4.0 - FR 10.3.11 -->

When you had created and published an app with at least one component, it would no longer be possible to edit it after refreshing one of its pages.

#### Dashboards app - Query builder: Problem with 'Row by row' option [ID 37463]

<!-- MR TBD - FR 10.3.11 -->

Due to a compatibility issue, a `Cannot read properties of undefined (reading IsHidden)` error could be thrown when, in the query builder, you joined queries on a DataMiner Agent that did not (yet) supported the *Row by row* option.

#### Low-Code Apps: Problem when accessing apps of which page and/or panel names contained special characters [ID 37474]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 [CU0] -->

After an upgrade to version 10.3.10, it would no longer be possible to access existing apps of which page and/or panel names contained special characters. Also, when adding a page or a panel, it would no longer be possible to enter a page or panel name that contained special characters.
