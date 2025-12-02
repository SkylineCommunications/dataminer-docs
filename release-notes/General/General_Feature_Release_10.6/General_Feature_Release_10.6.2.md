---
uid: General_Feature_Release_10.6.2
---

# General Feature Release 10.6.2 – Preview

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
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.2](xref:Cube_Feature_Release_10.6.2).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.2](xref:Web_apps_Feature_Release_10.6.2).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Security enhancements [ID 43789]

<!-- 43789: MR 10.5.0 [CU11] - FR 10.6.2 -->

A number of security enhancements have been made.

#### OpenSearch: Enhanced health monitoring [ID 43951]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

A number of enhancements have been made with regard to health monitoring of OpenSearch databases.

Also, all logging with regard to OpenSearch health monitoring can now be found in *SLSearchHealth.txt*. Up to now, that logging was added to *SLCassandraHealth.txt*.

Note that, from now on, if not all nodes of the OpenSearch cluster are listed in the *Db.xml* file, a notice will be generated to warn operators.

#### dataminer.services: Restrictions when adding a DMA to a DMS [ID 44171]

<!-- MR 10.7.0 - FR 10.6.1 -->

From now on, when you try to add a DataMiner Agent to a DataMiner System, the operation will fail in the following cases:

- The DataMiner Agent is cloud-connected, but the DataMiner System is not.
- The DataMiner Agent and the DataMiner System are cloud-connected, but they do not have the same identity, i.e. they are not part of the same cloud-connected system.

If the DataMiner System is a STaaS system, adding a DataMiner Agent will also fail if the DataMiner Agent is not cloud-connected.  

### Fixes

#### Not possible to export elements with logger tables on systems with Cassandra Cluster and OpenSearch [ID 44105]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

On a system with Cassandra Cluster and OpenSearch, up to now, it would incorrectly not be possible to export elements with logger tables.

A `Cassandra.InvalidQuery` exception with message "No keyspace has been specified" would be thrown and logged.

> [!NOTE]
> On a system with Cassandra Cluster and OpenSearch, it is currently not yet possible to export SLAs.

#### Problem when generating a default MessageBrokerConfig.json file [ID 44155]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

When neither an *SLCloud.xml* file nor a *MessageBrokerConfig.json* file could not be found on a DataMiner Agent, up to now, any process using MessageBroker would fail to generate a default *MessageBrokerConfig.json* file. As a result, it would not be possible to connect to NATS.

From now on, when neither a *SLCloud.xml* file nor a *MessageBrokerConfig.json* file can be found, a default *MessageBrokerConfig.json* file will be generated.

#### Problem with SLElement when loading elements that included matrix parameters [ID 44188]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

In some cases, SLElement could stop working when loading elements that included matrix parameters.
