---
uid: General_Feature_Release_10.6.3
---

# General Feature Release 10.6.3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version:
>
> - Make sure **version 14.40.33816** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation. The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
>   - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
>   - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)
>
> - Make sure all DataMiner Agents in the cluster have been migrated to the BrokerGateway-managed NATS solution. For detailed information, see [Migrating to BrokerGateway](xref:BrokerGateway_Migration).
>
>   See also: [DataMiner Systems will now use the BrokerGateway-managed NATS solution by default [ID 43856] [ID 43861] [ID 44035] [ID 44050] [ID 44062]](xref:General_Feature_Release_10.6.1#dataminer-systems-will-now-use-the-brokergateway-managed-nats-solution-by-default-id-43856-id-43861-id-44035-id-44050-id-44062)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.3](xref:Cube_Feature_Release_10.6.3).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.3](xref:Web_apps_Feature_Release_10.6.3).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Enhanced visibility on SLNet connection issues [ID 44069]

<!-- MR 10.7.0 - FR 10.6.3 -->

Visibility on SLNet connection issues has been enhanced:

- When a dashboard cannot be loaded because a DataMiner Agent is offline, an appropriate error message will now appear in that dashboard.

- A new log file named *SLNetConnectionsMonitor.txt* will now keep a historic record of all SLNet connection states.

#### An error will now be logged if the response to an SNMP Get request cannot be mapped [ID 44329]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

If the response to an *SNMP Get* request cannot be mapped, from now on, an error will be logged in the log file of the element in question and in the *SLErrorsInProtocol.txt* file.

#### DataMiner backup: 'Ticketing Gateway Configuration' removed from the list of backup options [ID 44401]

<!-- MR 10.7.0 - FR 10.6.3 -->

As the Ticketing app is End of Life as of DataMiner 10.6.x, *Ticketing Gateway Configuration* has now been removed from the list of backup options.

##### Security Advisory BPA test: Enhancements [ID 44444]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

A number of enhancements have been made to the Security Advisory BPA test:

- Up to now, the *Local admin hygiene* test would verify whether the local admin account was disabled and whether there were not too many local administrator accounts. From now on, this test will no longer be performed as the recommendations in the [hardening guide](https://aka.dataminer.services/HardeningGuide) have been updated.

- The *gRPC* test will now properly take the default configuration into account. Up to now, this test would assume gRPC was disabled when not configured. From DataMiner feature release 10.5.10, gRPC is enabled by default, causing the test to report a false positive.

### Fixes

#### Delay of DataMiner startup routine caused by SLDataMiner starting up faster than SLNet [ID 44438]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

During DataMiner startup, in some rare cases, SLDataMiner would start up faster than SLNet. This would cause a delay of about 2 minutes in the entire startup routine.

#### DaaS: Short-lived alarms without operational impact would appear immediately after the 'My DataMiner Agent' element had been created [ID 44440]

<!-- MR 10.6.0 - FR 10.6.3 -->

On a newly created DaaS system, up to now, short-lived alarms without operational impact could appear immediately after the *My DataMiner Agent* element had been created.

In the alarm template of the *My DataMiner Agent* element, hysteresis has now been tweaked to prevent such alarms from appearing on newly created DaaS systems.
