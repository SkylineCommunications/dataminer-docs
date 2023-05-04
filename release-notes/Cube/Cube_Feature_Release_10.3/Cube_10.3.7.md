---
uid: Cube_Feature_Release_10.3.7
---

# DataMiner Cube Feature Release 10.3.7 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.7](xref:General_Feature_Release_10.3.7).

## Highlights

*No highlights have been selected for this release yet*

## Other features

*No other features have been added to this release yet*

## Changes

### Enhancements

#### Visual Overview - ListView component: Columns and options removed [ID_35530]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

The following columns can no longer be added to a ListView component:

| Source   | Columns |
|----------|---------|
| Elements | Contributing Service<br>ElementID<br>ReservationInstances<br>Service properties |
| Services | Booking properties<br>ReservationInstance<br>Resource state<br>UsedResources    |

Also, the following component options can no longer be used:

- DisableInUseItems
- EditMode
- Recursive

### Fixes

#### DataMiner Cube - Resources app: Problem when opening the element list in the 'device' tab [ID_36239]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When, in the *Resources* app, you created a resource and then opened the element list in the *device* tab in order to link a device to that newly created resource, in some cases, DataMiner Cube could become unresponsive, especially when the element list contained a large number of elements.
