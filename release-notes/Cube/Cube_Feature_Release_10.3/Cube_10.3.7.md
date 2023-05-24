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

#### Resources app: Duplicating a resource [ID_36308]

<!-- MR 10.4.0 - FR 10.3.7 -->

In the *Resources* app, it is now possible to duplicate a resource.

To do so, right-click a resource in the list, and select *Duplicate*.

- The name of the newly created duplicate resource will be the name of the original resource with the suffix `- copy` added to it.

- All general information, properties and device data will be copied from the original resource to the duplicate resource.

- The duplicate resource will be added to all resource pools that contain the original resource.

- If you make a duplicate of a function resource, the instance dropdown will be left empty and the name of the function instance will be the name of the original function instance with the suffix `- copy`.

## Changes

### Enhancements

#### Visual Overview - ListView component: Columns and options removed [ID_35530]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

The following columns have become obsolete. They can no longer be added to a ListView component:

| Source   | Columns |
|----------|---------|
| Elements | Contributing Service<br>ElementID<br>ReservationInstances<br>Service properties |
| Services | Booking properties<br>ReservationInstance<br>Resource state<br>UsedResources    |

Also, the following component options can no longer be used:

- DisableInUseItems
- EditMode
- Recursive

#### Services app - Profiles tab: Profile instance selection box now sorted by name [ID_36332]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

When, in the *Services* app, you configure a service profile instance in the *Profiles* tab, you can link the different nodes of the service profile to existing profile instances using a profile instance selection box. Up to now, the profile instances listed in this selection box were sorted the creation date. From now on, they will be sorted by name. Also, this selection box can now be filtered.

#### Resources app: Saving a resource property with an empty value [ID_36345]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

In the *Resources* app, it is now possible to save a resource property with an empty value.

### Fixes

#### Resources app: Problem when opening the element list in the 'device' tab [ID_36239]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When, in the *Resources* app, you created a resource and then opened the element list in the *device* tab in order to link a device to that newly created resource, in some cases, DataMiner Cube could become unresponsive, especially when the element list contained a large number of elements.

#### Automation app: C# editor would incorrectly jump to the first line of code when saving a script [ID_36321]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When, in the *Automation* app, you saved an Automation script after making changes to a C# code block, the C# editor would incorrectly jump to the first line of that code block. From now on, when you save an Automation script, the C# editor will jump to the last line of code that was changed.

#### Visual Overview: Problem when opening an EPM card [ID_36323]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you opened an EPM card by clicking a shape that was linked to the EPM object via the *SystemName* and *SystemType* properties, in some cases, the card would be missing certain pages.

#### Spectrum analysis: Trace would no longer be updated when you restarted a spectrum element while its card was open [ID_36347]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you restarted a spectrum element while its card was open, the trace would no longer be updated. For the trace to get updated, you had to close the card and open it again. From now on, the trace will be updated as soon as the element has finished restarting.

#### Problem with 'Use credentials' selection box when creating or editing an element [ID_36362]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you selected the *Use credentials* option for an SNMPv1 or SNMPv2 connection while creating or updated an element, you would incorrectly not be required to select any predefined credentials. As a result, an error would occur when the element was created or the update was applied. From now on, when you select this option, the label will turn red and the *Create* or *Apply* button will be disabled as long as no credentials have been selected.

Also, when you edited an element for which credentials had been selected, the *Use credentials* selection box would be disabled and the *Get community string* and *Set community string* boxes would be enabled until you toggled the *Use credentials* option off and on again.
