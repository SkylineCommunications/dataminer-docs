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

#### DataMiner Cube - Visual Overview: Automatically generated shapes representing bookings can now be sorted by custom property [ID_34572] [ID_34864]

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

#### DataMiner Cube - Visual Overview: Enhanced performance when updating automatically generated shapes that represent bookings [ID_34695]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

Because of a number of enhancements, overall performance has increased when updating automatically generated shapes that represent bookings.

#### DataMiner Cube: Stream Viewer enhancements [ID_34837] [ID_34838]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU10] - FR 10.3.1 -->

The Stream Viewer tree view now supports more levels. This will allow you to display more detailed information.

For example, in case of HTTP communication, there will now be extra levels for sessions, connections, requests/responses, parameters*, and even status codes and error codes.

**only in case of a response*

### Fixes

#### DataMiner Cube - Visual Overview: Tooltip of an element in a service chain would incorrectly not show values of node properties [ID_34664]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

When, in a service chain within a service context, an element shape was linked to a node property via a shape data field of type *Tooltip*, then the tooltip of that shape would incorrectly not show the value of that node property when using either a `[Service definition properties]` or a `[Service definition property:<property name>]` placeholder.

#### DataMiner Cube - Visual Overview: Preset specified in a Spectrum Analysis component would incorrectly not be loaded [ID_34833]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU10] - Feature Release Version 10.3.1 -->

When you had specified a preset in a shape that contained a Spectrum Analysis component, the preset would incorrectly not be loaded when you opened the visual overview in Cube.

#### DataMiner Cube - EPM: Problem with topology filter [ID_34931]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU10] - Feature Release Version 10.3.1 -->

When you opened a topology chain and selected a field in the topology filter, in some cases, the fields above the one you selected would incorrectly not get selected automatically.
