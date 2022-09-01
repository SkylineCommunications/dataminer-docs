---
uid: Cube_Feature_Release_10.2.10
---

# DataMiner Cube Feature Release 10.2.10 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Highlights

*No highlights have been selected for this release yet*

## Other features

*No new features have been added to this release yet*

## Changes

### Enhancements

#### DataMiner Cube: Enhanced editing of profile parameters [ID_34189]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

A number of enhancements have been made to the profile parameter edit boxes, especially with regard to the validation of discrete values.

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

### Fixes

#### Alarm Console: Alarms would incorrectly be grouped when the 'Automatically group according to arrangement' was not selected [ID_34153]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

When, in the hamburger button in the top-left corner of the Alarm Console, the *Automatically group according to arrangement* setting was not selected, upon reconnecting DataMiner Cube, the alarms would incorrectly be grouped anyway.

#### DataMiner Cube - Profiles app: Data from a profile instance parameter entry could no longer be retrieved after updating the entry [ID_34192]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

When a parameter entry was updated in a profile instance, it would no longer be possible to retrieve the data from the updated entry. As a result, the UI was not able to reflect the changes made to the parameter entry in question.

#### DataMiner Cube - Services app: No services would be loaded the first time you opened the Services app [ID_34211]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

When you opened the *Services* app for the first time after opening DataMiner Cube, in some cases, no services would be loaded. The services would only be loaded when you closed the *Services* app and opened it again.

#### DataMiner Cube - Resources app: Problem when updating a resource that was added to multiple pools [ID_34225]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->
<!-- Enhancement with same ID -->

Since DataMiner version 10.1.5/10.2.0, when you updated a resource that was added to multiple pools, after the update, it would incorrectly only be added anymore to the pool you had selected. It would no longer be added to the other pools.
