---
uid: General_Main_Release_10.6.0_CU11
description: "Release notes for General Main Release 10.6.0 CU11, including prerequisites, enhancements, and fixes planned for this release."
---

# General Main Release 10.6.0 CU11 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.6.0 CU11](xref:Cube_Main_Release_10.6.0_CU11).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.6.0 CU11](xref:Web_apps_Main_Release_10.6.0_CU11).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Prerequisites

Before you upgrade to this DataMiner version:

- Make sure **version 14.44.35211.0** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation.

  The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):

  - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
  - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

- Make sure all DataMiner Agents in the cluster have been migrated to the BrokerGateway-managed NATS solution.

  For detailed information, see [Migrating to BrokerGateway](xref:BrokerGateway_Migration).

  See also: [DataMiner Systems will now use the BrokerGateway-managed NATS solution by default [ID 43526] [ID 43856] [ID 43861] [ID 44035] [ID 44050] [ID 44062]](xref:General_Main_Release_10.6.0_changes#dataminer-systems-will-now-use-the-brokergateway-managed-nats-solution-by-default-id-43526-id-43856-id-43861-id-44035-id-44050-id-44062)

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### BrokerGateway: Applying a manual configuration could time out [ID 46939]

<!-- MR 10.7.0 [CU0] / 10.6.0 [CU11] - FR 10.7.2 -->

Applying a manual BrokerGateway configuration using `applymanualconfig` could time out because too many `ForceRemoveNode` calls were sent. Each call notified all known nodes that the calling node should be removed.

From now on, only added, removed, or inconsistent nodes will call `ForceRemoveNode`. These actions will also be logged.

#### SLGlobal: Process crash when stopping an asynchronous notification queue [ID 47131]

<!-- MR 10.6.0 [CU11] - FR 10.7.2 -->

When SLDMS, SLDataMiner, or SLElement stopped the queue for asynchronous notifications to SLDataMiner, for example during process shutdown, the thread processing that queue could continue running after the queue had been removed. This could cause the process to crash.

From now on, stopping the queue will also stop its processing thread. DataMiner will wait up to 10 seconds for the thread to stop and discard any notifications still in the queue.

#### Factory reset tool: Web version information was deleted [ID 47226]

<!-- MR 10.6.0 [CU11] - FR 10.7.2 -->

When you ran the factory reset tool *SLReset.exe* using the default reset settings, the `C:\Skyline DataMiner\Upgrades\VersionInfoWeb.json` file containing the web version information was incorrectly deleted.

The default whitelist now preserves this file. Existing *ResetConfig.txt* files are not updated automatically.
