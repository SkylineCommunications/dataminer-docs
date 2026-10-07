---
uid: General_Main_Release_10.6.0_CU9
description: "Release notes for General Main Release 10.6.0 CU9, including prerequisites, enhancements, and fixes planned for this preview release."
---

# General Main Release 10.6.0 CU9 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.6.0 CU9](xref:Cube_Main_Release_10.6.0_CU9).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.6.0 CU9](xref:Web_apps_Main_Release_10.6.0_CU9).
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

#### SNMP GET results could be matched to the wrong polling group [ID 46507]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When multiple polling groups were executed concurrently, results from SNMP GET requests could be matched to the wrong group, potentially causing runtime errors.

The group ID is now passed along with each SNMP GET request so that the result is matched to the correct group.

#### VerifyNatsCluster could skip NATS checks when NATSForceManualConfig was enabled [ID 46547]

<!-- MR 10.6.0 [CU9] - FR 10.6.12 -->

On systems where DataMiner BrokerGateway manages NATS, the `VerifyNatsCluster` BPA could skip its checks when the `NATSForceManualConfig` flag was enabled, even if NATS was not manually configured. The BPA now checks `appsettings.runtime.json` for the BrokerGateway configuration instead of relying on the obsolete flag.

#### DataMiner memory usage could keep increasing during frequent GQI queries [ID 46560]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

Up to now, every time a connection to the DataMiner storage layer was opened, SLNet would register handlers for logging configuration changes and incoming messages. These handlers were not removed when the connection closed, leaving their associated objects in memory for the lifetime of the process.

On systems where GQI queries repeatedly opened connections, for example through dashboards or low-code apps that refresh automatically, memory usage could keep increasing, potentially degrading performance or causing out-of-memory errors.

From now on, the handlers will be removed when the connection closes.
