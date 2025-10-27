---
uid: General_Feature_Release_10.3.11
---

# General Feature Release 10.3.11

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
>
> - When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).
> - As of DataMiner version 10.3.0[CU8]/10.3.11, Amazon Keyspaces Service, Azure Managed Instance for Apache Cassandra Service and Amazon OpenSearch Service will no longer be supported. We recommend moving to [Storage as a Service](xref:STaaS). Note that using a self-hosted OpenSearch database remains supported.

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.11](xref:Cube_Feature_Release_10.3.11).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.3.11](xref:Web_apps_Feature_Release_10.3.11).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

#### Proactive cap detection extended to absolute and relative alarm types [ID 37373]

<!-- MR 10.4.0 - FR 10.3.11 -->

The proactive cap detection feature has been extended to dynamic alarm thresholds.

As a result, proactive detection will now predict when a parameter will cross one of the following bounds:

- A high and/or low data range value specified in the protocol.
- A (by default) critical alarm limit of type normal specified in the alarm template.
- A (by default) critical alarm limit of type "absolute" or "relative" specified in the alarm template if either a fixed baseline value is set or a dynamically updated baseline value is configured in the alarm template to detect a continuos degradation.
- A data range indirectly derived from the protocol info. Currently this is limited to the values 0 and 100 for percentage data for which no historical values were encountered outside the [0,100] interval.

#### Smart-serial communication now supports dynamic polling [ID 37404]

<!-- MR 10.4.0 - FR 10.3.11 -->

Smart-serial connection will now support dynamic polling, i.e. the ability to change the IP address and IP port while the element is active.

To enable dynamic polling for a smart-serial connection, add a parameter that contains the following:

`<Type options="dynamic ip">read</Type>`

> [!IMPORTANT]
>
> - Dynamic polling is only supported when the connection acts as a client. When you create the element, do not assign an IP address like "127.0.0.1", "any", etc. to it. If you do, the element will act as a server, and there is no way to make the element act as a client without stopping it. Also, trying to assign a value like "127.0.0.1" to the dynamic IP parameter at runtime will cause an error to occur.
> - We strongly advise you to always set the connection type to "smart-serial single" so the connection is assigned a dedicated socket in SLPort. If two or more smart-serial elements hosted on the same DMA are assigned the same IP address and port via the element wizard, they will share the same connection in SLPort. This means that, if one of these elements changes the IP address dynamically, the other ones will also start using the new IP address.

## Changes

### Enhancements

#### Cassandra Cluster Migrator is now able to resume a migration that was in progress when a DMA was stopped [ID 35199]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

When a DataMiner Agent is deliberately stopped or stops working due to an error while a Cassandra Cluster migration is in progress, it will now be possible to resume that migration for certain storages instead of having to start it from scratch again.

For all types that are read in a partitioned way (currently alarms and trending), the migration progress will now be stored in *TokenRange.txt* files located in the `C:\Skyline DataMiner\Database` folder.

To resume a migration after restarting all DMAs in your DataMiner System, do the following:

1. Start *SLCCMigrator.exe* (which is located in the `C:\Skyline DataMiner\Tools\` folder).
1. Initialize all the DMAs in the list.
1. Click *Start Migration*.

> [!NOTE]
>
> - When a migration is resumed, the UI does not know how many rows were already migrated. Therefore, when a migration is resumed, it will erroneously display that 0 rows have been migrated so far.
> - When a DMA is initialized, a file named *SavedState.xml* will be created in the `C:\Skyline DataMiner\Database` folder. *SLCCMigrator.exe* will use this file to determine the point from which a migration has to be resumed.

#### Service & Resource Management: Enhanced performance when enabling and disabling function DVEs [ID 37030]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

Because of a number of enhancements, overall performance has increased when enabling and disabling function DVEs.

#### Cassandra Cluster: IP addresses will no longer be added and synchronized automatically [ID 37154]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

Up to now, for the *CassandraCluster* database type, the IP addresses of the Cassandra Cluster nodes would be added automatically to the *DB.xml* file's `<DBServer>` element. From now on, those addresses will no longer be added automatically.

Also, in case of a Failover setup, the above-mentioned list of IP addresses will no longer be automatically synchronized to prevent re-ordering.

#### DataMiner.xml: objectId attribute of AzureAD element will now be considered optional [ID 37162]

<!-- MR 10.4.0 - FR 10.3.11 -->

Up to now, a runtime error would be thrown when the `<AzureAD>` element in the *DataMiner.xml* file did not contain an `objectId` attribute.

This `objectId` attribute will now be considered optional. Hence, no runtime error will be thrown anymore when it has not been specified.

#### Security enhancements [ID 37267] [ID 37291] [ID 37335] [ID 37345]

<!-- RN 37267: MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.11 -->
<!-- RN 37345: MR 10.3.0 [CU14] - FR 10.3.11 -->
<!-- RN 37291: MR 10.3.0 [CU8] - FR 10.3.11 -->
<!-- RN 37335: 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

A number of security enhancements have been made.

#### NATSCustodian: Enhanced behavior when detecting unreachable NATS nodes [ID 37271]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

From now on, when *NATSCustodian* detects unreachable NATS nodes in the cluster, it will no longer generate any alarms, nor will it reset the NATS configuration. It will only add an entry to the *NATSCustodian.txt* log file for diagnostic purposes.

NATSCustodian will only reset the NATS configuration when it detects

- that NATS nodes have been added,
- that NATS nodes have been deleted, or
- when NATS is in an incorrect state.

#### SLLogCollector now collects information regarding the IIS configuration [ID 37273]

<!-- MR 10.4.0 - FR 10.3.11 -->

SLLogCollector packages now include information regarding the IIS configuration:

| Folder              | Information                                           |
|---------------------|-------------------------------------------------------|
| IIS                 | The IIS configuration                                 |
| Network Information | Information regarding the SSL certificate on port 443 |
| SSL Cert            | The SSL certificate for port 443                      |

#### Improved alarm grouping for DVE child elements [ID 37275]

<!-- MR 10.4.0 - FR 10.3.11 -->

Alarm grouping for DVE child elements has been improved. As change points are generated on DVE parent elements, previously these were not taken into account for the grouping of alarms for the DVE child elements. Now the change points of the DVE parent element will be taken into account for the DVE child elements as well.

However, note that cases where a main DVE element exports the same parameter to multiple DVE child elements are not supported for this.

#### SLAnalytics - Trend predictions: Enhanced trend prediction models [ID 37280]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

A number of enhancements have been made to the trend prediction models, especially with regard to detecting daily trend recurrences.

#### SLAnalytics: Enhanced processing of trended parameters of which the value remains constant [ID 37303]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

A number of enhancements have been made to the memory resources used for trended parameters of which the value remains constant.

#### SLNetClientTest: New 'Debug SAML' checkbox [ID 37370]

<!-- MR 10.4.0 - FR 10.3.11 -->

When, in the SLNetClientTest tool, you select the new *Debug SAML* checkbox before connecting to a DataMiner Agent that used external authentication via SAML, two additional pop-up windows will now appear, displaying the SAML requests and SAML responses respectively.

> [!CAUTION]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Old versions of NATS configuration files will now be kept when changes are made to those files [ID 37401]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

When changes are made to one of the following NATS configuration files, from now on, the old version of that file will be saved in the `C:\Skyline DataMiner\Recycle Bin` folder.

- `C:\Skyline DataMiner\SLCloud.xml`
- `C:\Skyline DataMiner\NATS\nats-streaming-server\nats-server.config`
- `C:\Skyline DataMiner\NATS\nats-account-server\nas.config`

This will allow you to trace changes made to these configuration files when issues arise.

#### Storage as a Service: DataMiner Agent will now communicate with the database via port 443 only [ID 37480]

<!-- MR 10.4.0 - FR 10.3.11 [CU0] -->

Up to now, a DataMiner using STaaS communicated with the database via TCP/IP ports 443, 5671 and 5672. From now on, it will communicate with the database via port 443 only.

### Fixes

#### Failover: Data can get lost when the backup agent is the online agent during a Cassandra Cluster migration [ID 34018]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When the backup agent is the online agent while a Failover pair is being migrated to Cassandra Cluster, data generated during the migration can get lost.

From now on, when you start a Cassandra Cluster migration, a warning message will appear if, for any of the Failover pairs in the cluster, the backup agent is the online agent. This warning message will advise you to make sure that, for all Failover pairs in the cluster, the main agent is the online agent.

#### Not all Protocol.Params.Param.Interprete.Others tags would be read out [ID 36797]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

Not all [Protocol.Params.Param.Interprete.Others](xref:Protocol.Params.Param.Interprete.Others) tags would be read out, which could lead to unexpected behavior.

#### DataMiner backup: Number of backups to be kept would be interpreted incorrectly [ID 37143] [ID 37509]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When configuring a DataMiner backup, you can specify the number of backups that should be kept.

Up to now, this setting would incorrectly be interpreted as the total number of backups to be kept in the system. This would cause problems on systems where the number of backups specified was smaller than the number of DataMiner Agents in the DMS.

From now on, the number of backups you specify will be the number of backups that will be kept per DMA or Failover setup. For example, when you set the number of backups to be kept to 3 on a DMS with 5 DMAs or Failover setups, 3 backups will now be kept on every DMA or Failover setup.

> [!NOTE]
>
> - A DataMiner Agent will now store its backups in a subfolder of the folder set as backup location. The name of that subfolder will be identical to the DMA ID of the DataMiner Agent in question.
> - When you upgrade to this DataMiner version, an upgrade action will automatically divide the number of backups to be kept by the number of DataMiner Agents in the DMS if the number of backups to be kept is set to more than 3 and if there are at least two DMAs in the DMS. Note that this upgrade action will do nothing if, in the backup settings, you specified that all DMAs in the DMS have to store their backups on the same network path.

#### Problem in different native processes when interacting with message broker calls [ID 37150]

<!-- MR 10.3.0 [CU9] - FR 10.3.11 -->

In some cases, an error could occur in different native processes when interacting with message broker calls.

#### SLNet would incorrectly return certain port information fields of type string as null values [ID 37165]

<!-- MR 10.4.0 - FR 10.3.11 -->
<!-- Not added to MR 10.4.0 - This RN is identical to RN 36524 -->

When element information was retrieved from SLNet, in some cases, certain port information fields of type string would incorrectly be returned as a null value instead of an empty string value. As a result, DataMiner Cube would no longer show the port information when you edited an element.

Affected port information fields:

- BusAddress
- Number
- PollingIPAddress
- PollingIPPort

#### Inventory & Asset Management: Problem when synchronizing between the DMA and the database [ID 37177]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

The Asset Manager would add NullReference exceptions to the SLNet log file when trying to synchronize between the DMA and the database.

When a view or an element was deleted on the DMA before a synchronization was performed from the database to the DMA, the deleted items would not get recreated unless the DMA had been restarted before the synchronization, and when a mediation configuration file was adapted and reloaded, the view configuration would not be reloaded.

#### SLElement could read and write to the same memory blocks on different threads [ID 37180]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

In some cases, SLElement could read and write to the same memory blocks on different threads, causing a serialized parameter update to get into a corrupt state.

#### DataMiner.xml: Entire LDAP section could get removed when settings were updated with values containing illegal XML characters [ID 37235]

<!-- MR 10.4.0 - FR 10.3.11 -->

When settings inside the `<LDAP>` element of the *DataMiner.xml* file were updated with values that contained illegal XML characters, the entire `<LDAP>` element would be removed from the file.

#### MessageHandler method in SLHelperTypes.SLHelper would incorrectly try to serialize exceptions that could not be serialize [ID 37238]

<!-- MR 10.4.0 - FR 10.3.11 -->

Up to now, the MessageHandler method in SLHelperTypes.SLHelper would incorrectly try to serialize exceptions that could not be serialized, causing other exceptions to be thrown.

#### Problem when masking a DVE child element or a virtual function [ID 37240]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

When you masked a DVE child element or a virtual function, not all alarms of all parameters would be masked.

#### Service & Resource Management: Resources that were still in use could be deactivated [ID 37244]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When a booking ends or when a booking is deleted, SLNet will try to deactivate any function DVEs that are no longer required.

In some cases, when function DVEs were being cleaned up while a resource swap occurred on another booking, DVEs required by that other booking would incorrectly also get deactivated.

#### SLLogCollector would not copy all memory dumps to the correct folder [ID 37255]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When SLLogCollector takes memory dumps, it stores them in a temporary folder before copying them to the correct location. In some cases, a parsing problem would cause some dumps to not get copied over to the correct location.

#### Problem with SLNet due to unhandled MessageBroker exceptions in SLHelper [ID 37258]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

An error could occur in SLNet due to unhandled MessageBroker exceptions in SLHelper.

#### SLAnalytics: Problem when trying to edit a multivariate pattern [ID 37270]

<!-- MR 10.4.0 - FR 10.3.11 -->

Due to a cache synchronization issue, problems could occur when trying to edit a multivariate pattern of which one of the elements is located on another DataMiner Agent.

#### Elements with multiple SSH connections would go into timeout after being restarted [ID 37294]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

When an element with multiple SSH connections was restarted, in some cases, it would no longer be able to communicate with the SSH server. As a result, it would immediately go into timeout.

#### DataMiner backup: DBConfiguration.xml file would not be included in backups [ID 37296]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When you took a DataMiner backup either via Cube or via the Taskbar Utility, the *DBConfiguration.xml* file would incorrectly not be included in the backup.

#### Service & Resource Management: Bookings could get stuck in the 'Confirmed' state [ID 37306]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

In some rare cases, a booking created with a start time in the past or equal to "Now" could incorrectly get stuck in the *Confirmed* state.

#### SLAnalytics: Problem due to some features not starting up correctly [ID 37321]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

An error could occur in the SLAnalytics process due to some features not starting up correctly.

#### SLAnalytics: Problem when stopping a feature [ID 37329]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

In some cases, an error could occur in SLAnalytics when a feature (e.g. automatic incident tracking) was stopped.

#### Protocols: Problem when using 'MultipleGetBulk' in combination with 'PartialSNMP' [ID 37336]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

When a protocol was configured to use `MultipleGetBulk` in combination with `PartialSNMP` (e.g. `<OID options="partialSNMP:10;multipleGetBulk:10">`), and the device would return less table cells than the configured `MultipleGetBulk` value, certain fields would not get filled in.

#### SLAnalytics: Problem when fetching protocol information while creating a multivariate pattern [ID 37366]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

In some cases, an error could occur in SLAnalytics when fetching protocol information while creating a multivariate pattern.

#### SLAnalytics: Problem when the SLNet connection got lost while resetting the data sources [ID 37402] [ID 37459]

<!-- RN 37402: MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->
<!-- RN 37459: MR 10.3.0 [CU8] - FR 10.3.11 -->

An error could occur in SLAnalytics when the SLNet connection got lost while resetting the data sources.

#### EPM: Problem when SLNet requested information from other DataMiner Agents in the DMS [ID 37462]

<!-- MR 10.4.0 - FR 10.3.11 -->

In EPM environments, an error could occur when SLNet requested information from other DataMiner Agents in the DMS.  

#### GQI: Problem when aggregating Elasticsearch table columns [ID 37472]

<!-- MR 10.4.0 - FR 10.3.11 -->
<!-- Not added to MR 10.4.0 -->

When Elasticsearch table columns were aggregated via GQI, the aggregation columns would all share the same incorrect column ID.
