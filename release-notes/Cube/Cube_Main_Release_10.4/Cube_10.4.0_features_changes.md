---
uid: Cube_Main_Release_10.4.0_other_features_changes
---

# DataMiner Cube Main Release 10.4.0 – Other new features & changes - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Other new features

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

## Changes

### Enhancements

#### Alarm Console: Automatic incident tracking will now make use of the parameter relationship data that is stored in a model managed by the ModelHost DxM [ID_34684]

<!-- MR 10.4.0 - FR 10.3.1 -->

The *automatic incident tracking* feature groups active alarms that are related to the same incident, so that the Alarm Console provides a better overview of the current issues in the system. From now on, on cloud-connected DataMiner Agents that have the DataMiner Extension Module *ModelHost* installed and that have been configured to [offload alarm and change point events to the cloud](xref:Controlling_cloudfeed_data_offloads), this feature will also make use of the parameter relationship data that is stored in a model managed by the *ModelHost* DxM.

### Fixes

*No fixes have been added yet.*
