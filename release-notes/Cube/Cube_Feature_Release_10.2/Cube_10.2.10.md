---
uid: Cube_Feature_Release_10.2.10
---

# DataMiner Cube Feature Release 10.2.10

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.2.10](xref:General_Feature_Release_10.2.10).

## Highlights

#### DataMiner Cube - Resources app: Enhanced resource pool management [ID_34225]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->
<!-- Fix with same ID -->

A number of enhancements have been made with regard to managing resource pools.

- Moving or copying a resource from one pool to another is only supported for existing, valid resources, and you need to have permission to edit resources to do this. It is also not possible to copy a resource to or from the "(uncategorized)" pool, as this pool is reserved for resources that are not in any other pool.

- It is now also possible to remove a resource from a pool.

    > [!NOTE]
    >
    > - Removing a resource from a pool does not delete the resource from the system. It only removes it from the selected pool. If the resource is not present in any other resource pool, it will be moved to the "(uncategorized)" pool.
    > - You can only remove valid, unmodified existing resources that are not in the "(uncategorized)" pool. You also need permission to edit resources to be able to do this.

- The *SelectedPool* session variable of the ReservationManager component will contain the GUIDs of all pools of the selected resource(s), separated by commas.

## Changes

### Enhancements

#### Trending - Behavioral anomaly detection: No more intermediate change point update events of type 'flatline' [ID_33957]

<!-- MR 10.3.0 - FR 10.2.10 -->

Up to now, when a trend behaved as a flatline for a long time, a change point update event would be generated every 15 minutes. From now on, in case of a flatline trend, only two change point events will be generated: one at the start of the flatline and another at the end of the flatline.

> [!NOTE]
> Flatline events will be cleared as soon as the flatline ends.

#### Trending: Enhanced performance when requesting real-time trend data [ID_34171]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.10 -->

On systems that store real-time trend data for more than a week, from now on, DataMiner Cube will no longer request all available real-time trend data at once. Instead, it will request data for the past week and only request more data when needed.

#### DataMiner Cube: Enhanced editing of profile parameters [ID_34189]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

A number of enhancements have been made to the profile parameter edit boxes, especially with regard to the validation of discrete values.

### Fixes

#### Alarm Console: Alarms would incorrectly be grouped when the 'Automatically group according to arrangement' was not selected [ID_34153]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

When, in the hamburger button in the top-left corner of the Alarm Console, the *Automatically group according to arrangement* setting was not selected, upon reconnecting DataMiner Cube, the alarms would incorrectly be grouped anyway.

#### Resources app: Incorrectly no longer possible to delete a function resource that was used by a past booking [ID_34159] [ID_34186]

<!-- MR 10.3.0 - FR 10.2.10 -->

Since DataMiner feature release 10.2.7, it was incorrectly no longer possible to delete a function resource that was used by a past booking. From now on, it will again be possible to delete a function resource that was used by a past booking.

It will now also be possible to delete a function resource that was used by a canceled booking.

#### Clicking the 'Close' button of one of multiple open error message boxes would incorrectly always close the last box that had been opened [ID_34173]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.10 -->

When multiple error messages boxes were being displayed, clicking the *Close* button on any of those boxes would incorrectly always close the last box that had been opened. All other boxes would stay open and could only be closed by clicking the X in the top-right corner.

#### DataMiner Cube - Profiles app: Data from a profile instance parameter entry could no longer be retrieved after updating the entry [ID_34192]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

When a parameter entry was updated in a profile instance, it would no longer be possible to retrieve the data from the updated entry. As a result, the UI was not able to reflect the changes made to the parameter entry in question.

#### Alarm Console: Problem when clearing alarm groups [ID_34196]

<!-- MR 10.3.0 - FR 10.2.10 -->

Alarm groups would not get cleared automatically when the *AutoClear* option was set to false.

Also, in some cases, after clearing an alarm group, a clearable version of that alarm group would incorrectly remain visible in the Alarm Console, even when the *AutoClear* option was set to true.

#### DataMiner Cube - Services app: No services would be loaded the first time you opened the Services app [ID_34211]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

When you opened the *Services* app for the first time after opening DataMiner Cube, in some cases, no services would be loaded. The services would only be loaded when you closed the *Services* app and opened it again.

#### DataMiner Cube - Resources app: Problem when updating a resource that was added to multiple pools [ID_34225]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->
<!-- Enhancement with same ID -->

Since DataMiner version 10.1.5/10.2.0, when you updated a resource that was added to multiple pools, after the update, it would incorrectly only be added anymore to the pool you had selected. It would no longer be added to the other pools.
