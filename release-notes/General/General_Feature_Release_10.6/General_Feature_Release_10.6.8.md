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

### Fixes

#### Cassandra Cluster / STaaS: 'Alarm events' graph on 'Reports' page of service card would incorrectly be empty [ID 45533]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

When, in a DataMiner Cube connected to a DataMiner System using Cassandra Cluster or STaaS, you opened the *Reports* page of a service card, the *Alarm events* graph would incorrectly be empty, showing "Alarm data not found in the current time range".

#### AssemblyResolveHelper now returns already loaded fallback assembly if it was already loaded [ID 45567]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

When the `AssemblyResolveHelper` in `SLCompilationEngine` cannot find the exact version of the assembly it has to load, by default, it will try to load an assembly with the same name but a different version.

Up to now, when the assembly with the different version was already loaded in the application domain, the `AssemblyResolveHelper` would incorrectly return null.

From now on, when the assembly with the different version is already loaded in the application domain, the `AssemblyResolveHelper` will again correctly return the already loaded assembly.
