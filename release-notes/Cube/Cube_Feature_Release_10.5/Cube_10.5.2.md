---
uid: Cube_Feature_Release_10.5.2
---

# DataMiner Cube Feature Release 10.5.2 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.2](xref:General_Feature_Release_10.5.2).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.2](xref:Web_apps_Feature_Release_10.5.2).

## Highlights

*No highlights have been selected yet.*

## New features

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Alarm Console: Problem when an alarm tab and an AlarmSummary shape were being loaded simultaneously [ID 41484]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

When, in the Alarm Console, an alarm tab was being loaded while, at the same time, a Visio shape containing a data field of type *AlarmSummary* was being loaded, in some cases, an exception could be thrown.

#### Protocols & templates: Problem when an update was received from the DMA while you were navigating through the app [ID 41494]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

When, in the *Protocols & templates* app, you had selected a protocol, a protocol version and a template in order to check the list of assigned elements, up to now, other items could incorrectly get selected when an update unrelated to any of the items you selected was received from the DataMiner Agent to which you were connected.
