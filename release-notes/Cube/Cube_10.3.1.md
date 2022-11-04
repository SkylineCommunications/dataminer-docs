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

*No enhancements have been added to this release yet*

### Fixes

*No fixes have been added to this release yet*
