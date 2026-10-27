---
uid: Cube_Feature_Release_10.7.1
description: "Release notes for DataMiner Cube Feature Release 10.7.1, with new features, enhancements, and fixes planned for this preview release."
---

# DataMiner Cube Feature Release 10.7.1 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.6.0 [CU10].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.7.1](xref:General_Feature_Release_10.7.1).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.7.1](xref:Web_apps_Feature_Release_10.7.1).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### State icons: Subscription exceptions would be logged on the DMA when the state icons feature was disabled [ID 46862]

<!-- MR 10.5.0 [CU22] / 10.6.0 [CU10] - FR 10.7.1 -->

When state icons were disabled in the SLAnalytics configuration, DataMiner Cube would still subscribe to state icon changes for every trended parameter displayed on an element card. For partial or filtered tables, it renewed these subscriptions whenever a row was added or removed. Each subscription caused an exception to be logged on the DataMiner Agent to which DataMiner Cube was connected.

From now on, DataMiner Cube will only subscribe to state icon changes when the state icons feature is enabled.
