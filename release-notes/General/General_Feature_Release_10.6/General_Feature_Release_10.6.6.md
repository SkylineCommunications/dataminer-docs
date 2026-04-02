---
uid: General_Feature_Release_10.6.6
---

# General Feature Release 10.6.6 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.6](xref:Cube_Feature_Release_10.6.6).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.6](xref:Web_apps_Feature_Release_10.6.6).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Prerequisites

Before you upgrade to this DataMiner version:

- Make sure **version 14.44.35211.0** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation.

  The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):

  - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
  - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

- Make sure all DataMiner Agents in the cluster have been migrated to the BrokerGateway-managed NATS solution.

  For detailed information, see [Migrating to BrokerGateway](xref:BrokerGateway_Migration).

  See also: [DataMiner Systems will now use the BrokerGateway-managed NATS solution by default [ID 43856] [ID 43861] [ID 44035] [ID 44050] [ID 44062]](xref:General_Feature_Release_10.6.1#dataminer-systems-will-now-use-the-brokergateway-managed-nats-solution-by-default-id-43856-id-43861-id-44035-id-44050-id-44062)

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### BrokerGateway installer will now give a clear indication when .NET is missing [ID 45169]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When you install the BrokerGateway DxM on a server that does not have the Microsoft .NET hosting bundle installed yet, from now on, a message will appear, saying that .NET has to be installed first.

### Fixes

#### Alarm squashing: Alarm would incorrectly not show up in the Alarm Console when the element had been restarted and the AlarmsPerParameter limit was exceeded [ID 45063]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When, on a system with alarm squashing enabled, the `AlarmsPerParameter` limit in the `AlarmSettings` section of the *MaintenanceSettings.xml* file was exceeded, an alarm of which all alarms in the alarm tree were squashable would incorrectly not show up in the Alarm Console after the element associated with the alarm had been restarted.

#### SLWatchdog to incorrectly interpret processes being stopped during a DataMiner shutdown as a crash [ID 45115]

<!-- MR 10.7.0 - FR 10.6.6 -->

When DataMiner is shutting down, processes are expected to be stopped. However, up to now, the tracking in SLWatchdog would not be cleaned correctly, causing certain processes to still be monitored. When these processes eventually stopped, SLWatchdog would incorrectly interpret this as a crash, which would then trigger a number of crash detection features, such as notifying CDMR or attempting to perform a full restart.

#### SLAnalytics: Problem due to a large number of state icon events being added to the SLNet queue simultaneously [ID 45145]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

In some cases, timeouts could occur due to a large number of state icon events being added to the SLNet queue simultaneously.

From now on, the number of state icon events sent by SLAnalytics instances will be reduced to a maximum of 10,000 events per minute. Also, they will be sent in batches of maximum 1000 events.

Additionally, state icon events, alarm focus events and RAD parameter aggregation events will now all have a smaller weight, meaning that more of them will be allowed in the queue.
