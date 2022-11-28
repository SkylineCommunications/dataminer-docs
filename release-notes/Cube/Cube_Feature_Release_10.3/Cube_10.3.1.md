---
uid: Cube_Feature_Release_10.3.1
---

# DataMiner Cube Feature Release 10.3.1 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.1](xref:General_Feature_Release_10.3.1).

## Highlights

*No highlights have been selected for this release yet*

## Other features

#### System Center - Analytics config: New Pattern Matching setting 'Maximum memory usage' [ID_34803]

<!-- MR 10.4.0 - FR 10.3.1 -->

In the *System settings > Analytics config* section of *System Center*, you can now find a new setting under *Pattern Matching*: *Maximum memory usage*.

This setting allows you to specify the maximum amount of memory that SLAnalytics will use to cache recurring patterns in trend data (in GB).

Default value: 2.00 GB

#### DataMiner Cube - Visual Overview: Automatically generated shapes representing bookings can now be sorted by custom property [ID_34572] [ID_34864]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

When specifying that a shape should be created automatically for each booking in a particular set of bookings, it is now possible to have the automatically generated shapes sorted by a custom booking property.

For example, in an SRM environment, you can have a booking time range that includes pre-roll and post-roll, and timings that contain the custom properties *Start* and *End*. From now on, it is possible to have the automatically generated shapes sorted by one of those custom properties. To do so, you can specify a shape data field of type *ChildrenSort* to the group-level shape and set its value to `Property|property=<CustomProperty>,<asc/desc>`.

Examples:

```txt
ChildrenSort="Property|property=Start,asc"
ChildrenSort="Property|property=End,desc"
```

#### Visio - "[GroupValue]" and "[Count]" can now be used as placeholders to adjust the value inside of dynamically grouped shapes [ID_34974]

<!-- MR 10.4.0 - FR 10.3.1 -->

In Visio, users can now enter the placeholder "[GroupValue]" in the *ShapeGrouping* shape to display the parameter value of the shape data *GroupBy* of the first child of the group. If the *GroupBy* value has multiple column parameters or properties, the group names will be separated by a comma.

Users can also use the placeholder "[Count]" from now onwards, to display the number of children in a group of dynamically positioned shapes.

Up to now, the only available placeholder that could be added in the *ShapeGrouping* shape was an asterisk ("\*").

## Changes

### Enhancements

#### Alarm Console: Automatic incident tracking will now make use of the parameter relationship data that is stored in a model managed by the ModelHost DxM [ID_34684]

<!-- MR 10.4.0 - FR 10.3.1 -->

The *automatic incident tracking* feature groups active alarms that are related to the same incident, so that the Alarm Console provides a better overview of the current issues in the system. From now on, on cloud-connected DataMiner Agents that have the DataMiner Extension Module *ModelHost* installed and that have been configured to [offload alarm and change point events to the cloud](xref:Controlling_cloudfeed_data_offloads), this feature will also make use of the parameter relationship data that is stored in a model managed by the *ModelHost* DxM.

#### DataMiner Cube - Visual Overview: Enhanced performance when updating automatically generated shapes that represent bookings [ID_34695]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

Because of a number of enhancements, overall performance has increased when updating automatically generated shapes that represent bookings.

#### DataMiner Cube: Stream Viewer enhancements [ID_34837] [ID_34838]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU10] - FR 10.3.1 -->

The Stream Viewer tree view now supports more levels. This will allow you to display more detailed information.

For example, in case of HTTP communication, there will now be extra levels for sessions, connections, requests/responses, parameters*, and even status codes and error codes.

**only in case of a response*

#### Alarm Console: A notice will now appear when resources are being migrated from XML to Elasticsearch [ID_34845]

<!-- MR 10.3.0 - FR 10.3.1 -->

When resources are being migrated from XML to Elasticsearch, a `Busy migrating resources to the Elasticsearch database.` notice will now be displayed in the Alarm console. Also, information events will be generated when a migration was started, was canceled or finished. In the latter case, the information event will indicate whether the migration finished with or without errors.

When you start a resource migration in the *SLNetClientTest* tool (by selecting *Advanced > Migration > Resources XML to Elastic > Start Migration*), all ongoing bookings and bookings that are scheduled to start or stop in the next hour will be listed in a table (which can be sorted by clicking the table headers). As the Resource Manager is stopped while a migration is in progress, it is possible that bookings will not be started or stopped during a migration.

> [!CAUTION]
> Always be extremely careful when using the *SLNetClientTest* tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### DataMiner Cube - Visual Overview: Enhanced performance when loading a visual overview that contains a large number of shapes linked to EPM objects [ID_34874]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU10] - FR 10.3.1 -->

Because of a number of enhancements, overall performance has increased when loading a visual overview that contains a large number of shapes linked to EPM objects.

#### DataMiner Cube - Settings: 'Show the DataMiner TV section' setting has been removed [ID_34877]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU10] - FR 10.3.1 -->

The *Show the DataMiner TV section* setting has been removed from the *User > Cube* section of the *Settings* window.

### Fixes

#### DataMiner Cube - Visual Overview: Tooltip of an element in a service chain would incorrectly not show values of node properties [ID_34664]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

When, in a service chain within a service context, an element shape was linked to a node property via a shape data field of type *Tooltip*, then the tooltip of that shape would incorrectly not show the value of that node property when using either a `[Service definition properties]` or a `[Service definition property:<property name>]` placeholder.

#### DataMiner Cube - Visual Overview: Preset specified in a Spectrum Analysis component would incorrectly not be loaded [ID_34833]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU10] - Feature Release Version 10.3.1 -->

When you had specified a preset in a shape that contained a Spectrum Analysis component, the preset would incorrectly not be loaded when you opened the visual overview in Cube.

#### Bookings app: Columns of type 'Date' would not get updated when you changed the time zone [ID_34840]

<!-- MR 10.3.0 - FR 10.3.1 -->

When, in the *Navigation* panel of the *Bookings* app, you selected another time zone, columns of type `Date` would incorrectly not get updated.

Also, the *Navigation* panel has been improved and renamed to *Settings* panel.

#### Trending - Pattern matching: Trend graph would no longer show the matches for the displayed parameter after editing a tag [ID_34870]

<!-- MR 10.3.0 - FR 10.3.1 -->

When you edited the properties of a tag (e.g. name, description, etc.), the trend graph would no longer show the pattern matches for the parameter that is currently displayed in the graph. Instead, it would incorrectly show the pattern matches for the parameter for which the tag was defined.

#### DataMiner Cube - EPM: Problem with topology filter [ID_34931]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU10] - Feature Release Version 10.3.1 -->

When you opened a topology chain and selected a field in the topology filter, in some cases, the fields above the one you selected would incorrectly not get selected automatically.

#### DataMiner Cube - Visual Overview: Trend graph would incorrectly show 'No data' [ID_34955]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU10] - Feature Release Version 10.3.1 -->

When a visual overview on an EPM card contained a trend graph, in some cases, that graph would incorrectly show *No data* while its legend would show the correct data.
