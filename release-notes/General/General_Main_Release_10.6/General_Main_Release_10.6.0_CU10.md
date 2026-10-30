---
uid: General_Main_Release_10.6.0_CU10
description: "Release notes for General Main Release 10.6.0 CU10, including prerequisites, enhancements, and fixes planned for this preview release."
---

# General Main Release 10.6.0 CU10 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.6.0 CU10](xref:Cube_Main_Release_10.6.0_CU10).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.6.0 CU10](xref:Web_apps_Main_Release_10.6.0_CU10).
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

#### DataMiner upgrade: Improved performance of the ValidateConnectors prerequisite [ID 46743]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

The `ValidateConnectors` upgrade prerequisite checks for installed connector versions that are incompatible with the target DataMiner version. Previously, it recursively scanned the entire `C:\Skyline DataMiner\Protocols` folder, which could slow down upgrade prerequisite checks on DataMiner Agents with many connectors or large connector version folders.

From now on, it will only scan folders for connectors on the incompatibility list, and only at the level where *protocol.xml* is expected. This makes the check faster and less sensitive to unrelated content in the *Protocols* folder.

The incompatible connector versions reported, the message shown, and the requirement to remove those versions before upgrading remain unchanged. No configuration is required.

### Fixes

#### SLNet: Array index errors when retrieving alarm filter, trend filter, or redundancy group information [ID 46607]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

SLNet could throw an `IndexOutOfRangeException` when retrieving available alarm filter, trend filter, or redundancy group information if an SLXML query returned an array with unexpected dimensions.

SLNet will now retry failed redundancy group queries once after a short delay. Array index errors will also be logged in *SLNet.txt* with the variable name, the exact array index, and the complete query response array in compressed form to help diagnose the issue.

#### STaaS: Incomplete state-change history after migrating from Cassandra [ID 46769]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

After migrating from Cassandra to STaaS, state-change history could be incomplete for parameters in index-only tables or tables with a display column when the parameter instance contained uppercase characters. This could affect dashboards and heatlines in DataMiner Cube.

This issue occurred when history was stored under both the original-case and lowercase instances. State-change retrieval now reads both instances and merges the results by timestamp, giving precedence to the lowercase instance when timestamps match.

#### Standalone BPA executor: BPA tests requiring SLNet could fail to run [ID 46809]

<!-- MR 10.5.0 [CU22]/10.6.0 [CU10] - FR 10.7.1 -->

The standalone BPA executor would throw a `NullReferenceException` when running a manually loaded BPA DLL file with the `RequireSLNet` flag, preventing the BPA test from executing.
