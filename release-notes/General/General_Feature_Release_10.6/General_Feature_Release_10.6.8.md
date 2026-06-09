---
uid: General_Feature_Release_10.6.8
---

# General Feature Release 10.6.8 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.8](xref:Cube_Feature_Release_10.6.8).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.8](xref:Web_apps_Feature_Release_10.6.8).
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

#### Exception.Source field will now be added to ErrorLog.txt when a managed process stops unexpectedly [ID 44722]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

When a managed process stops unexpectedly, from now on, the contents of the exception's *Source* field will now be added to the *ErrorLog.txt* log file. This should provide more debug information.

#### DataMiner Object Models: SLDataGateway will now try to read only the selected fields from a STaaS database [ID 45503]

<!-- MR 10.7.0 - FR 10.6.8 -->

When SLDataGateway is retrieving DOM data from a STaaS database, from now on, it will attempt to retrieve only the selected fields using the native field projection capabilities of these databases. This will considerably enhance data transfer efficiency and overall performance.

This optimization will leverage the indexed field values to avoid transferring complete objects when only specific fields are needed.

If selected field retrieval is not supported by the database, the system will automatically fall back to retrieving the full object and extracting the required values.

By default, the value type will be the field type defined by the exposer. When a field value is explicitly requested, the type defined in the field descriptor will be used instead.

> [!IMPORTANT]
> To ensure correct type resolution, field descriptor IDs must be unique across all section definitions within a DOM module. Non-unique IDs may result in incorrect type mapping and unexpected behavior.

#### Database migration from Cassandra Cluster to STaaS is now allowed on systems with Swarming enabled [ID 45507]

<!-- MR 10.7.0 - FR 10.6.8 -->

From now on, it is possible to migrate the database of a Swarming-enabled system from Cassandra Cluster to STaaS.

> [!NOTE]
>
> - This migration will be a snapshot migration, not a live migration.
> - Migrating the database will only be possible if the system is online, cloud-connected, and has an active Cassandra Cluster database.

#### Visual Overview in web apps: Problem when creating a new window [ID 45517]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

Because of the way Cube sessions are loaded in the SLHelper process when creating visual overviews, up to now, Windows could throw an exception creating a new window. This would cause the SLHelper process to crash, affecting all active Cube sessions.

From now on, the system will attempt to recreate the Cube session when the initial creation fails, and will handle any failures gracefully to ensure other sessions remain unaffected.

#### GQI will now throw an exception when data is requested from a mediated table parameter [ID 45539]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

Currently, because of server limitations, GQI is unable to retrieve parameter table data from DataMiner when that table is a mediated parameter. As a result, when you select a table of a mediated protocol in a client UI, that table will not contain any data, and will also not provide any details on why it does not do so.

From now on, when a query using the *Parameters for elements where* data source attempts to retrieve data from a mediated table parameter, GQI will throw an error. That error will indicate that the request is not valid because mediated tables are not supported, and will also mention the table or table columns involved.

#### User-Defined APIs can now also be triggered by sending a PATCH request method [ID 45542]

<!-- MR 10.7.0 - FR 10.6.8 -->

To trigger a user-defined API, up to now, you had to send a GET, PUT, POST, or DELETE request method to the UserDefinableApiEndpoint DxM.

From now on, it will also be possible to trigger a user-defined API by sending a PATCH request method.

#### SLManagedScripting: AssemblyLoad event handler will also log the location of the loaded assembly [ID 45547]

<!-- MR 10.7.0 - FR 10.6.8 -->

From now on, the `AssemblyLoad` event handler in SLManagedScripting will also log the location of the loaded assembly (if available).

#### Automation: Script library hint paths will only be sent to the script compilation engine the first time they are required [ID 45560]

<!-- MR 10.7.0 - FR 10.6.8 -->

Previously, when a script library was added to a DataMiner System, its hint paths were automatically sent to the automation script compilation engine, even when the library was not used by any automation script.

From now on, script library hint paths will only be sent to the automation script compilation engine the first time they are required, i.e., when a script referencing the library in question (either directly or via another library) is executed for the first time.

#### SLElementInProtocol.txt log file entries will now be added by SLLog instead of SLProtocol [ID 45578]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

Up to now, the *SLElementInProtocol.txt* log file entries were added by SLProtocol.

From now on, these log file entries will be added by SLLog instead.

#### DataMiner Agents will now translate the primary key to the display key when receiving timeline data requests from DataMiner Cube [ID 45579]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

When DataMiner Cube requests timeline data using a `GetReportTimeLineDataMessage`, it sends the primary key when referencing display column tables. However, for this type of table, the DataMiner Agent has to retrieve the data from the database using the display key.

From now on, when a DataMiner Agent receives a timeline data request, it will first translate the primary key to the display key before returning the requested data.

#### SLLogCollector will now retrieve the value of the Windows security policy 'System cryptography: Use FIPS compliant algorithms for encryption, hashing, and signing' is enabled [ID 45592]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

From now on, SLLogCollector will also retrieve the value of the Windows security policy *System cryptography: Use FIPS compliant algorithms for encryption, hashing, and signing*.

DataMiner does not support having this policy enabled. Having this option enabled will prevent DataMiner from starting up properly.

#### SLNetClientTest tool: Enum field dropdown boxes in 'Build Message' tab will now be sorted alphabetically [ID 45610]

<!-- MR 10.7.0 - FR 10.6.8 -->

Up to now, each enum field dropdown box in the *Build Message* tab would show the enum values in the order in which they are defined in the enum.

In order to make it easier to look up values when, for example, building a message, from now on, the enum field dropdown boxes in the *Build Message* tab will show the enum values in alphabetical order.

> [!CAUTION]
> Always be extremely careful when using the *SLNetClientTest* tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### 'Check Time Server' BPA test has now been merged with the 'DataMiner Agent Minimum Requirements' BPA test [ID 45631]

<!-- MR 10.7.0 - FR 10.6.8 -->

In order to combine all system requirements specified in [DataMiner Compute Requirements](https://aka.dataminer.services/DataMiner_compute_requirements), the *Check Time Server* BPA test has now been merged with the *DataMiner Agent Minimum Requirements* BPA test.

> [!NOTE]
> From now on, the *DataMiner Agent Minimum Requirements* BPA test will be executed only once across the entire DataMiner System. The test results from the individual Agents in the cluster will be aggregated.

### Fixes

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

<!-- MR 10.6.0 [CU5] - FR 10.6.8 -->

The *NATSRepair.exe* tool would incorrectly no longer work on new DataMiner Agents that had been installed using a DataMiner Installer v10.6.
