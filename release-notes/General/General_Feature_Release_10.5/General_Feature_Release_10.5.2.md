---
uid: General_Feature_Release_10.5.2
---

# General Feature Release 10.5.2 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.2](xref:Cube_Feature_Release_10.5.2).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.2](xref:Web_apps_Feature_Release_10.5.2).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

## Changes

### Enhancements

#### DataMiner upgrade packages now include the latest Visual C++ Redistributable [ID 41173]

<!-- MR 10.6.0 - FR 10.5.2 -->

All DataMiner upgrade packages now include the latest Visual C++ Redistributable.

> [!NOTE]
> From now on, after having upgraded a DataMiner Agent, the *C:\\Skyline DataMiner\\Files* and *C:\\Skyline DataMiner\\Files\\x64* folders will no longer contain any individual Visual C++ Redistributable DLL files.

### Fixes

#### Problem with SLDataMiner when deleting a connector [ID 41520]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In some rare cases, SLDataMiner could stop working when a connector was deleted immediately after an element using that connector had been deleted.

#### DataMiner Maps: Markers that did not match the alarm level filter would become visible for a split second [ID 41555]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When you zoomed to a different layer while an alarm level filter was active, in some cases, markers that did not match the filter would become visible for a split second before disappearing again.
