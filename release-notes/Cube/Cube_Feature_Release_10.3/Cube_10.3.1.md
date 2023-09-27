---
uid: Cube_Feature_Release_10.3.1
---

# DataMiner Cube Feature Release 10.3.1

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.1](xref:General_Feature_Release_10.3.1).

## Highlights

#### System Center - Analytics config: New Pattern Matching setting 'Maximum memory usage' [ID_34803]

<!-- MR 10.4.0 - FR 10.3.1 -->

In the *System settings > Analytics config* section of *System Center*, you can now find a new setting under *Pattern Matching*: *Maximum memory usage*.

This setting allows you to specify the maximum amount of memory that SLAnalytics will use to cache recurring patterns in trend data (in GB).

Default value: 2.00 GB

#### Visual Overview: New placeholders can now be added to a 'ShapeGrouping' shape [ID_34974]

<!-- MR 10.4.0 - FR 10.3.1 -->

Up to now, when you enabled grouping of dynamically positioned shapes, you were able to display the number of shapes that were grouped into a single group shape by adding an asterisk ("\*") in the *ShapeGrouping* shape.

From now on, you can also add the following placeholders in the *ShapeGrouping* shape:

- Add `[GroupValue]` to make the shape display the value that is specified in the *GroupBy* shape data field of the first child shape in the group.

  If this *GroupBy* value contains multiple column parameters and/or properties, they will be separated by commas.

- Add `[Count]` to make the shape display the number of child shapes in the group (similar to adding an asterisk).

The placeholders `[GroupValue]` and `[Count]` can be added simultaneously as well.

## Other features

#### Visual Overview: Session variable YAxisResources now supports filters to pass exposers [ID_34857]

<!-- MR 10.4.0 - FR 10.3.1 -->

From now on, you can pass resource exposers as a filter to the *YAxisResources* session variable in order to show the corresponding resource bands.

Using a filter that results in less than 100 resources is recommended to avoid delay while loading the bands.

A converter has also been created in the client that will convert a profile parameter name to the ID of the found object. For this, the format [ProfileParameter:xxx,ID] should be used, replacing "xxx" with the name of the capacity/capability profile parameter.

> [!NOTE]
> For examples, refer to [YAxisResource session variable examples](xref:YAxisResource_Shape_Data_Examples) in the user guide.

> [!TIP]
> See also: [Service & Resource Management: Exposers for resource capacities and capabilities](xref:General_Feature_Release_10.3.1#service--resource-management-exposers-for-resource-capacities-and-capabilities-id_34841)

#### Visual Overview: Automatically generated shapes representing bookings can now be sorted by custom property [ID_34572] [ID_34864]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

When specifying that a shape should be created automatically for each booking in a particular set of bookings, it is now possible to have the automatically generated shapes sorted by a custom booking property.

For example, in an SRM environment, you can have a booking time range that includes pre-roll and post-roll, and timings that contain the custom properties *Start* and *End*. From now on, it is possible to have the automatically generated shapes sorted by one of those custom properties. To do so, you can specify a shape data field of type *ChildrenSort* to the group-level shape and set its value to `Property|property=<CustomProperty>,<asc/desc>`.

Examples:

```txt
ChildrenSort="Property|property=Start,asc"
ChildrenSort="Property|property=End,desc"
```

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

#### Bookings module: Navigation panel has been improved and renamed to 'settings' panel [ID_34840]

<!-- MR 10.3.0 - FR 10.3.1 Also see Fixes for bug fix section-->

The *Navigation* panel has been improved and renamed to *Settings* panel.

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

#### Trending - Parameter relationships: Enhancements [ID_34832] [ID_34846] [ID_34863] [ID_34938]

<!-- MR 10.4.0 - FR 10.3.1 -->

A number of enhancements have been made to the parameter relationship feature. When you hover over a light bulb icon in the top-right corner of a trend graph, a tooltip will now appear. This tooltip will suggest you add a number of related parameters. Also, when you open a histogram, no light bulb icon will be displayed anymore as parameter relationships are not really relevant when viewing histograms.

#### DataMiner Cube - Visual Overview: Preset specified in a Spectrum Analysis component would incorrectly not be loaded [ID_34833]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU10] - Feature Release Version 10.3.1 -->

When you had specified a preset in a shape that contained a Spectrum Analysis component, the preset would incorrectly not be loaded when you opened the visual overview in Cube.

#### Bookings module: Columns of type 'Date' would not get updated when you changed the time zone [ID_34840]

<!-- MR 10.3.0 - FR 10.3.1 Also see enhancements-->

When, in the *Navigation* panel of the *Bookings* app, you selected another time zone, columns of type `Date` would incorrectly not get updated.

#### Trending - Pattern matching: Trend graph would no longer show the matches for the displayed parameter after editing a tag [ID_34870]

<!-- MR 10.3.0 - FR 10.3.1 -->

When you edited the properties of a tag (e.g. name, description, etc.), the trend graph would no longer show the pattern matches for the parameter that is currently displayed in the graph. Instead, it would incorrectly show the pattern matches for the parameter for which the tag was defined.

#### DataMiner Cube - EPM: Problem with topology filter [ID_34931]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU10] - Feature Release Version 10.3.1 -->

When you opened a topology chain and selected a field in the topology filter, in some cases, the fields above the one you selected would incorrectly not get selected automatically.

#### DataMiner Cube - Visual Overview: Trend graph would incorrectly show 'No data' [ID_34955]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU10] - Feature Release Version 10.3.1 -->

When a visual overview on an EPM card contained a trend graph, in some cases, that graph would incorrectly show *No data* while its legend would show the correct data.
