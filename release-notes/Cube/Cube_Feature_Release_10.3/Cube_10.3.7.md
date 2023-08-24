---
uid: Cube_Feature_Release_10.3.7
---

# DataMiner Cube Feature Release 10.3.7

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.7](xref:General_Feature_Release_10.3.7).

## New features

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

#### Alarm Console - Proactive cap detection: Enhanced suggestion event value for predicted minimum or maximum values [ID_36440]

<!-- MR 10.4.0 - FR 10.3.7 -->

The proactive cap detection feature generates suggestion events for predicted data range violations. The value of these suggestion events has now been changed

- from  `Predicted above range violation between ... and ...` or `Predicted below range violation between ... and ...`
- to `Predicted maximum value [x] [unit] between ... and ...` or `Predicted minimum value [x] [unit] between ... and ...`

\*[x] being the value of the maximum or minimum value of the data range for the parameter as specified in the protocol, and [unit] being the unit of the parameter as specified in the protocol.

The value of the suggestion events generated for predicted (critical) alarm threshold breaches has not been changed.

### Fixes

#### System Center - Database: Problem when saving a trend data offload configuration with frequency set to 'permanently' [ID_35679]

<!-- MR 10.4.0 - FR 10.3.7 -->

When, while configuring trend data offloads, you selected *Trend data* and *Enable data offload* in the *Offloads* section, and then set the offload frequency to "permanently", this would be saved incorrectly, causing the offload process to not work properly.

#### Resources app: Problem when opening the element list in the 'device' tab [ID_36239]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When, in the *Resources* app, you created a resource and then opened the element list in the *device* tab in order to link a device to that newly created resource, in some cases, DataMiner Cube could become unresponsive, especially when the element list contained a large number of elements.

#### Automation app: C# editor would incorrectly jump to the first line of code when saving a script [ID_36321]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When, in the *Automation* app, you saved an Automation script after making changes to a C# code block, the C# editor would incorrectly jump to the first line of that code block. From now on, when you save an Automation script, the C# editor will jump to the last line of code that was changed.

#### Visual Overview: Problem when opening an EPM card [ID_36323]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you opened an EPM card by clicking a shape that was linked to the EPM object via the *SystemName* and *SystemType* properties, in some cases, the card would be missing certain pages.

#### Visual Overview: Dynamically positioned top-level shapes would lose their connections when a child shape had 'DisableConnectivity' set [ID_36340]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

When dynamically positioned shapes contained subshapes that disabled the connectivity, in some cases, no connections would be drawn.

From now on, connections will be drawn when a dynamically positioned shape has at least one subshape with connectivity.

When all subshapes have the `DisableConnectivity` option set, then no connections will be drawn.

#### Spectrum analysis: Trace would no longer be updated when you restarted a spectrum element while its card was open [ID_36347]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you restarted a spectrum element while its card was open, the trace would no longer be updated. For the trace to get updated, you had to close the card and open it again. From now on, the trace will be updated as soon as the element has finished restarting.

#### Visual Overview: Blinking shapes would affect other components [ID_36357]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

Up to now, setting a shape to blink in Visual Overview could unintentionally affect other components. For example, when the parameter table contained monitored parameters, the monitored cells would incorrectly blink along with the shape.

From now on, when a shape is set to blink, other components will no longer be affected.

#### Problem with 'Use credentials' selection box when creating or editing an element [ID_36362]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you selected the *Use credentials* option for an SNMPv1 or SNMPv2 connection while creating or updating an element, you would incorrectly not be required to select any predefined credentials. As a result, an error would occur when the element was created or the update was applied. From now on, when you select this option, the label will turn red and the *Create* or *Apply* button will be disabled as long as no credentials have been selected.

Also, when you edited an element for which credentials had been selected, the *Use credentials* selection box would be disabled and the *Get community string* and *Set community string* boxes would be enabled until you toggled the *Use credentials* option off and on again.

#### Reports and heatline of a monitored parameter of a DVE child element would incorrectly show "No monitoring" [ID_36384]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you opened the card of a DVE child element, drilled down to a monitored parameter and opened the *Details* tab, the reports would incorrectly show "No monitoring". Also, "No monitoring" would be shown when you viewed the heatline of the parameter in question.

#### Problem when opening the alarm template of a large matrix parameter [ID_36444]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In some cases, Cube could become unresponsive when you tried to open the alarm template of a large matrix parameter.

#### Problem when trying to export all elements to a CSV file [ID_36512]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In some cases, the following exception could be thrown when you tried to export all elements to a CSV file:

`Export failed: Object reference not set to an instance of an object`

#### Trending: Only one related parameter shown when clicking the light bulb icon [ID_36518]

<!-- MR 10.4.0 - FR 10.3.7 -->
<!-- Not added to 10.4.0 -->

When you clicked the light bulb icon in the top-right corner of a trend graph, Cube would incorrectly only list one related parameter. From now on, it will again list the ten most important ones.
