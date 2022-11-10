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

#### Visual Overview: Automatically generated shapes representing bookings can now be sorted by custom property [ID_34572]

<!-- MR 10.2.0 [CU10] - FR 10.3.1 -->

When specifying that a shape should be created automatically for each booking in a particular set of bookings, it is now possible to have the automatically generated shapes sorted by a custom booking property.

For example, in an SRM environment, you can have a booking time range that includes pre-roll and post-roll, and timings that contain the custom properties *Start* and *End*. From now on, it is possible to have the automatically generated shapes sorted by one of those custom properties. To do so, you can specify a shape data field of type *ChildrenSort* to the group-level shape and set its value to `Property|<CustomProperty>,<asc/desc>`.

Examples:

```txt
ChildrenSort="Property|Start,asc"
ChildrenSort="Property|End,desc"
```

## Changes

### Enhancements

#### DataMiner Cube: Stream Viewer enhancements [ID_34837] [ID_34838]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.3.1 -->

The Stream Viewer tree view now supports more levels. This will allow you to display more detailed information.

For example, in case of HTTP communication, there will now be extra levels for IP addresses, groups, sessions, connections, requests/responses, parameters*, and even status codes and error codes.

**only in case of a response*

### Fixes

#### DataMiner Cube - Visual Overview: Tooltip of an element in a service chain would incorrectly not show values of node properties [ID_34664]

<!-- MR 10.2.0 [CU9] - FR 10.3.1 -->

When, in a service chain within a service context, an element shape was linked to a node property via a shape data field of type *Tooltip*, then the tooltip of that shape would incorrectly not show the value of that node property when using either a `[Service definition properties]` or a `[Service definition property:<property name>]` placeholder.
