---
uid: General_Feature_Release_10.6.1
---

# General Feature Release 10.6.1 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version, make sure **version 14.40.33816** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation.
>
> The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
> - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
> - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.1](xref:Cube_Feature_Release_10.6.1).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.1](xref:Web_apps_Feature_Release_10.6.1).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### DataMiner Systems will now use the BrokerGateway-managed NATS solution by default [ID 43856]

<!-- MR 10.6.0 - FR 10.6.1 -->

DataMiner Systems will now use the BrokerGateway-managed NATS solution by default. Also, it will no longer be possible to migrate from the BrokerGateway-managed NATS solution (nats-server service) back to the legacy SLNet-managed NATS solution (NAS and NATS services).

- DataMiner upgrades will no longer automatically install NAS and NATS.

- SLReset will now consider the BrokerGateway-managed NATS solution as the default solution, and will remove the `C:\Skyline DataMiner\NATS` folder (if present).

- SLLogCollector will no longer collect any data from the `C:\Skyline DataMiner\NATS` folder.

- In the *MaintenanceSettings.xml* file, the following tags will now be considered obsolete:

  - BrokerGateway
  - NATSDisasterCheck
  - NATSLogFileAmountToKeep
  - NATSLogFileCleanupMs
  - NATSResetWindow
  - NATSRestartTimeout

#### DataMiner upgrade: Prerequisite check 'VerifyBrokerGatewayMigration' will verify whether all DMS in the cluster are using the BrokerGateway-managed NATS solution [ID 43861]

<!-- MR 10.6.0 - FR 10.6.1 -->

During a DataMiner upgrade, the *VerifyBrokerGatewayMigration* prerequisite check will verify whether all DataMiner Agents in the cluster are using the BrokerGateway-managed NATS solution. If not, the check will fail, and the upgrade will not be able to continue.

### Fixes

#### SLNet: Information messages triggered in a QAction would incorrectly only be forwarded to the DMA hosting the element in question [ID 43958]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

When a QAction triggered an information message with regard to a particular element, SLNet would incorrectly only forward that message to the DataMiner Agent that hosted that element. As a result, that information message would not appear in client applications connected to any of the other DataMiner Agents in the system.

#### Failover: 'C:\\Skyline DataMiner\\Elements' folder on offline Agents could unexpectedly be cleared [ID 44005]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

In Failover clusters, in some rare cases where specific conditions related to DVE element handling and naming conflicts were met, the `C:\Skyline DataMiner\Elements` folder on offline Agents could unexpectedly be cleared, sometimes leaving no elements behind.

To detect whether this has occurred:

- Compare the number of elements on the online and offline Agents.
- Check the offline Agent's Recycle Bin for entries named "Element   deleted", indicating a deletion occurred without a known element name.
