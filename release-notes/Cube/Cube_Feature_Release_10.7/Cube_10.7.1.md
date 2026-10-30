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

### Security: Support for DataMiner Intelligence permissions [ID 46803]

<!-- MR 10.6.0 [CU10]/10.7.0 [CU0] - FR 10.7.1 -->

DataMiner Cube now displays the following permissions under *General* in the user group permissions configuration when the connected DataMiner Agent supports them:

- *Intelligence Usage*: Grants access to all features related to DataMiner Intelligence.
- *Intelligence App*: Grants access to the Intelligence app.

Both permissions are enabled by the limited administrator and full administrator presets. They are hidden when the connected DataMiner Agent does not support them.

> [!NOTE]
> These permissions will only be displayed when connected to a DataMiner Agent running DataMiner version 10.8.0/10.7.1 or higher. See [Security: New 'Intelligence Usage' user permission [ID 46765]](xref:General_Feature_Release_10.7.1#security-new-intelligence-usage-user-permission-id-46765) and [Security: New 'Intelligence App' user permission [ID 46817]](xref:General_Feature_Release_10.7.1#security-new-intelligence-app-user-permission-id-46817).

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### State icons: Subscription exceptions would be logged on the DMA when the state icons feature was disabled [ID 46862]

<!-- MR 10.5.0 [CU22] / 10.6.0 [CU10] - FR 10.7.1 -->

When state icons were disabled in the SLAnalytics configuration, DataMiner Cube would still subscribe to state icon changes for every trended parameter displayed on an element card. For partial or filtered tables, it renewed these subscriptions whenever a row was added or removed. Each subscription caused an exception to be logged on the DataMiner Agent to which DataMiner Cube was connected.

From now on, DataMiner Cube will only subscribe to state icon changes when the state icons feature is enabled.

#### Memory leaks in custom text block controls and workspace settings [ID 46871]

<!-- MR 10.6.0 [CU10] / 10.7.0 [CU0] - FR 10.7.1 -->

DataMiner Cube could retain certain custom text block controls and workspace setting views in memory after they were no longer in use, causing memory leaks.

From now on, Cube will stop timers and remove event subscriptions when these controls are unloaded, hidden, or their content changes. The workspace settings suggestion timer will only run while suggestions are being processed.
