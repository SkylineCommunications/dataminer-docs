---
uid: General_Main_Release_10.6.0_CU5
---

# General Main Release 10.6.0 CU5 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.6.0 CU5](xref:Cube_Main_Release_10.6.0_CU5).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.6.0 CU5](xref:Web_apps_Main_Release_10.6.0_CU5).
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

#### Exception.Source field will now be added to ErrorLog.txt when a managed process stops unexpectedly [ID 44722]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

When a managed process stops unexpectedly, from now on, the contents of the exception's *Source* field will now be added to the *ErrorLog.txt* log file. This should provide more debug information.

#### GQI will now throw an exception when data is requested from a mediated table parameter [ID 45539]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

Currently, because of server limitations, GQI is unable to retrieve parameter table data from DataMiner when that table is a mediated parameter. As a result, when you select a table of a mediated protocol in a client UI, that table will not contain any data, and will also not provide any details on why it does not do so.

From now on, when a query using the *Parameters for elements where* data source attempts to retrieve data from a mediated table parameter, GQI will throw an error. That error will indicate that the request is not valid because mediated tables are not supported, and will also mention the table or table columns involved.

#### SLElementInProtocol.txt log file entries will now be added by SLLog instead of SLProtocol [ID 45578]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

Up to now, the *SLElementInProtocol.txt* log file entries were added by SLProtocol.

From now on, these log file entries will be added by SLLog instead.

#### DataMiner Agents will now translate the primary key to the display key when receiving timeline data requests from a client [ID 45579]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

When a client requests timeline data using a `GetReportTimeLineDataMessage`, it sends the primary key when referencing display column tables. However, for this type of table, the DataMiner Agent has to retrieve the data from the database using the display key.

From now on, when a DataMiner Agent receives a timeline data request, it will first translate the primary key to the display key before returning the requested data.

#### SLLogCollector will now retrieve the value of the Windows security policy 'System cryptography: Use FIPS compliant algorithms for encryption, hashing, and signing' is enabled [ID 45592]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

From now on, SLLogCollector will also retrieve the value of the Windows security policy *System cryptography: Use FIPS compliant algorithms for encryption, hashing, and signing*.

DataMiner does not support having this policy enabled. Having this option enabled will prevent DataMiner from starting up properly.

### Fixes

#### History set trending would show gaps where no gaps were expected [ID 44705]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.4 -->

Up to now, history set trending would show gaps where no gaps were expected.

From now on, trend records with the following *iStatus* values will no longer cause gaps in trend graphs:

| Value | Description |
|-------|-------------|
| -1  | Element is starting up. |
| -2  | Element is being paused. |
| -3  | Element is being activated. |
| -4  | Element is going into a timeout state. |
| -5  | Element is coming out of a timeout state. |
| -6  | Element is being stopped. |
| -9  | Trending was started for the specified parameter. |
| -10 | Trending was stopped for the specified parameter. |

#### Visual Overview in web apps: Problem when creating a new window [ID 45517]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

Because of the way Cube sessions are loaded in the SLHelper process when creating visual overviews, up to now, Windows could throw an exception creating a new window. This would cause the SLHelper process to crash, affecting all active Cube sessions.

From now on, the system will attempt to recreate the Cube session when the initial creation fails, and will handle any failures gracefully to ensure other sessions remain unaffected.

#### Cassandra Cluster / STaaS: 'Alarm events' graph on 'Reports' page of service card would incorrectly be empty [ID 45533]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

When, in a DataMiner Cube connected to a DataMiner System using Cassandra Cluster or STaaS, you opened the *Reports* page of a service card, the *Alarm events* graph would incorrectly be empty, showing "Alarm data not found in the current time range".

#### SLWatchDog: Problem when restarting DataMiner after SLDataMiner had stopped working [ID 45543]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

When SLDataMiner had stopped working, up to now, any attempt made by SLWatchdog to restart the DataMiner Agent would fail.

From now on, when SLDataMiner or any other critical DataMiner process stops working, SLWatchdog will be able to correctly restart the DataMiner Agent.

#### AssemblyResolveHelper now returns already loaded fallback assembly if it was already loaded [ID 45567]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

When the `AssemblyResolveHelper` in `SLCompilationEngine` cannot find the exact version of the assembly it has to load, by default, it will try to load an assembly with the same name but a different version.

Up to now, when the assembly with the different version was already loaded in the application domain, the `AssemblyResolveHelper` would incorrectly return null.

From now on, when the assembly with the different version is already loaded in the application domain, the `AssemblyResolveHelper` will again correctly return the already loaded assembly.

#### Failover: Advanced Failover options could incorrectly not be changed when BrokerGateway was being used [ID 45613]

<!-- MR 10.6.0 [CU5] - FR 10.6.8 -->

Up to now, when a Failover setup was using BrokerGateway, it would incorrectly not be possible to change any of the advanced Failover options.

#### SLWatchDog: Log entry describing a process restart would incorrectly not include the names of the restarted processes [ID 45614]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

When SLWatchDog had queued a process restart after having detected that one or more non-critical processes had stop working, up to now, the associated log entry would incorrectly not include the names of the affected processes: `Queueing Process Restarts in 1 minute ()`

From now on, this log entry will correctly include the names of the processes being restarted. For example: `Queueing Process Restarts in 1 minute (SLProtocol.exe)`

#### NATSRepair.exe would incorrectly no longer work on new DMAs installed using DataMiner Installer v10.6 [ID 45636]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

The *NATSRepair.exe* tool would incorrectly no longer work on new DataMiner Agents that had been installed using a DataMiner Installer v10.6.

#### Problem when logging in to a DaaS system using external authentication [ID 45637]

<!-- MR 10.6.0 [CU5] - FR 10.6.8 -->

Up to now, when you logged in to a DaaS system using external authentication, in some cases, the DaaS system would incorrectly not be flagged as such. As a result, you would be allowed to access functionality that is restricted to non-DaaS systems.

#### MessageBroker would not be able to connect to the NATS bus of a DMA when the server name of the DMA was an invalid DNS name [ID 45640]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

Up to now, MessageBroker would not be able to connect to the NATS bus of a DataMiner Agent when the server name of that Agent was an invalid DNS name.

From now on, *NATSRepair.exe* and *NATSMigration.exe* will now make sure the default *MessageBrokerConfig.json* file points to localhost instead of the server name.

#### SLASPConnection could stop working when it failed to retrieve the local IP address [ID 45656]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

In some cases, the SLASPConnection process could stop working when it failed to retrieve the local IP address.

#### Problem when forwarding SNMPv3 traps [ID 45660]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

When, within a DataMiner System, a DataMiner Agent receives an SNMPv3 trap for an element hosted by another DataMiner Agent, it will forward that trap to the other Agent. However, in some cases, the element would incorrectly not receive the trap when it did not have the correct credentials needed to decrypt the trap.
