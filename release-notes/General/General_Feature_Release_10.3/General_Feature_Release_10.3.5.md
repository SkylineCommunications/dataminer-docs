---
uid: General_Feature_Release_10.3.5
---

# General Feature Release 10.3.5

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.5](xref:Cube_Feature_Release_10.3.5).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.3.5](xref:Web_apps_Feature_Release_10.3.5).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

#### SLNetClientTest: New DOM-related features [ID_35550]

<!-- MR 10.4.0 - FR 10.3.5 -->

In the *SLNetClientTest* tool, the following new DOM-related features have been made available:

- Viewing a JSON representation of a selected ModuleSettings configuration.

- Completely remove a DOM Manager from the system.

  > [!NOTE]
  >
  > - When you instruct the *SLNetClientTest* tool to delete a DOM Manager, it will count the number of DOM instances. If the DOM Manager in question contains more than 10,000 DOM instances, an error message will appear, saying that deleting the DOM Manager would take too long.

  > - When you instruct the *SLNetClientTest* tool to delete a DOM Manager, it will not remove the indices from the Elasticsearch database. These indices have to be deleted manually. If you do not delete them manually, we recommend to not re-use the module ID as this could cause configuration conflicts.

> [!CAUTION]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Support for Azure Managed Instance for Apache Cassandra [ID_35830]

<!-- MR 10.4.0 - FR 10.3.5 -->

It is possible to use an Azure Managed Instance for Apache Cassandra as an alternative to a Cassandra cluster hosted on premises.

You will first need to [create your Azure Managed Instance for Apache Cassandra](#creating-your-azure-managed-instance-for-apache-cassandra), and then [connect your DataMiner System to the created instance](#connecting-your-dataminer-system-to-the-azure-managed-instance).

> [!TIP]
> For detailed information on Azure Managed Instance for Apache Cassandra, refer to the [Microsoft documentation](https://learn.microsoft.com/en-us/azure/managed-instance-apache-cassandra/).

##### Creating your Azure Managed Instance for Apache Cassandra

1. Go to [Azure Portal](https://portal.azure.com) and log in.

1. Search for *Azure Managed Instance for Apache Cassandra*.

1. At the top of the window, click *Create*.

1. On the *Basics* page, specify the required information.

   To have low latency, you should select a region near your own or the region where your Azure VMs are running. The password that you configure is for the *Cassandra* user in the system.

1. Click *Next: Data center* and configure the kind of servers you want to use for your Cassandra cluster.

   The *Sku Size* defines which VM will be used (the more resources, the more expensive). You can then also select the number of disks and nodes that you want. The minimum number of nodes is 3.

1. If you want to configure a client certificate, click *Advanced* at the top.

   If you do not need to do this, you can add some tags to the setup so you can easily find it again, or go to the next step.

1. Go to the *Review + Create* page.

   Here, Azure will do some checks to see if everything has been configured correctly.

1. If everything is valid, click *Create*. Otherwise, adjust your configuration until Azure indicates that it is valid, and then click *Create*.

A pop-up window on the Azure website will now indicate that your cluster is being created. This can take a while.

Once the creation is finished, you will see your newly created cluster on the *Azure Managed Instance for Apache Cassandra* page.

##### Connecting your DataMiner System to the Azure Managed Instance

1. Retrieve the necessary information from the Azure portal:

   1. Go to [Azure Portal](https://portal.azure.com) and log in.

   1. Go to *Azure Managed Instance for Apache Cassandra*.

   1. Select the cluster you want to connect your DataMiner System to.

   1. In the *Settings* menu, select *Data Center*.

   1. Click the arrow to open the data center, and copy the IP addresses DataMiner will need to connect to.

   > [!NOTE]
   > We recommend configuring all of the nodes in DataMiner. If a node should go down, DataMiner can then still connect to the other nodes.

1. Using the copied IP addresses, configure the [Cassandra cluster database in System Center](xref:Configuring_the_database_settings_in_Cube).

1. Stop DataMiner.

1. Open the [DB.xml](xref:DB_xml) configuration file.

1. Set the *TLSEnabled* tag to true in the file and save your changes:

   ```xml
   <TLSEnabled>True</TLSEnabled>
   ```

1. Restart DataMiner.

## Changes

### Enhancements

#### Security enhancements [ID_35668] [ID_35997]

<!-- 35668: MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->
<!-- 35997: MR 10.4.0 - FR 10.3.5 -->

A number of security enhancements have been made.

#### SLAnalytics: A message will be added to the SLAnalytics.txt log file when no Cassandra database is present [ID_35748]

<!-- MR 10.4.0 - FR 10.3.5 -->

Up to now, SLAnalytics would stop working without giving any notice whatsoever when it was started on a system without a Cassandra database.

From now on, when no Cassandra database is present, SLAnalytics will be stopped gracefully and a message will be added to the *SLAnalytics.txt* log file.

#### Alarms generated when a database goes in offload mode will now have severity 'Notice' instead of 'Critical' [ID_35749]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When a database went in offload mode, up to now, an alarm with severity *Critical* was generated. From now on, an alarm of severity *Notice* will be generated instead.

#### SLNetClientTest: More user-friendly pop-up window will now appear when connecting to a DMA that uses external authentication via SAML [ID_35755]

<!-- MR 10.4.0 - FR 10.3.5 -->

When, in the SLNetClientTest tool, you connected to a DataMiner Agent that used external authentication via SAML, up to now, a pop-up window showing the authentication URL would prompt you to enter the SAML response string. From now on, a pop-up window similar to the one used in Cube will appear instead.

> [!CAUTION]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### SLAnalytics will no longer disregard first-time alarm template assignments [ID_35794]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

Up to now, SLAnalytics only took into account changes to alarm templates that were already assigned to elements and disregarded first-time alarm template assignments.

From now on, SLAnalytics will also take into account first-time alarm template assignments.

#### Business Intelligence: Enhancements with regard to the retrieval of data from logger tables and to general error handling [ID_35820]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

A number of enhancements have been made to the Business Intelligence module, especially with regard to the retrieval of data from logger tables and to general error handling.

#### DataMiner Storage Module: Installer enhancements [ID_35842]

<!-- MR 10.4.0 - FR 10.3.5 -->
<!-- Not added to MR 10.4.0 -->

A number of enhancements have been made to the DataMiner Storage Module installer.

#### SLAnalytics: Enhanced performance [ID_35871]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

Overall performance of SLAnalytics has increased because of a number of enhancements made to its caching mechanism.

#### SLAnalytics - Behavioral anomaly detection: Events associated with a DVE child element will no longer be linked to the DVE parent element [ID_35901]

<!-- MR 10.4.0 - FR 10.3.5 -->

Up to now, when an event associated with a DVE child element was generated, internally, that event would be linked to the DVE parent element. From now on, it will be linked to the child element instead.

### Fixes

#### SLLogCollector: Problem when collecting multiple memory dumps with the 'Now and when memory increases with X Mb' option [ID_35617]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When the *SLLogCollector* tool had to collect memory dumps of multiple processes with the *Now and when memory increases with X Mb* option, it would incorrectly only collect the memory dump of the first process that reached the specified Mb limit.

From now on, it will collect at least the "now" dump for each of the selected processes.

#### NATS would incorrectly be re-installed when a WMI query error occurred while the NATS installer was being run at DMA startup [ID_35647]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When the NATS installer was being run at DMA startup, in some cases, due to an issue with a WMI query, NATS could incorrectly be re-installed, even though NATS and NAS were already running.

From now on, the execution of the NATS installer at DMA startup will be skipped when NATS is already running. Also, if an error occurs when running a WMI query during the execution of the NATS installer, a message saying that the re-installation has failed will be added to the *SLUMSEndpointManager.txt* log file.

> [!NOTE]
> When an error occurs while running a WMI query, and no NATS/NAS service is running, NATS will not be installed automatically. A manual installation of NATS will be needed.

#### Existing masked alarms would incorrectly affect the overall alarm severity of an element [ID_35678]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Existing masked alarms would incorrectly affect the overall alarm severity of an element.

#### Failover: Offline agent would incorrectly try to take a backup of the Elasticsearch database [ID_35721]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When, in Failover setups, you configure a DataMiner backup on the online agent, the same backup will also be scheduled on the offline agent, and if these setups have a clustered Elasticsearch database, a backup of that database cluster will be included in the DataMiner backup.

In Failover setups where both agents included a local Elasticsearch database that was part of an Elasticsearch cluster, the online agent would fail to take a backup of the Elasticsearch databases due to a backup in progress, triggered earlier by the offline agent.

From now on, only the online agent will be allowed to take a backup of the Elasticsearch database, and the offline agent will log the following entry:

```txt
Elastic backup will not be taken - Only active agents from a failover pair can take the backup.
```

#### DateTime instances would not get serialized correctly when an SLNet connection supported protocol buffer serialization [ID_35777]

<!-- MR 10.4.0 - FR 10.3.5 -->

When an SLNet connection supported protocol buffer serialization, DateTime instances would not get serialized correctly.

#### SLProtocol would interpret signed numbers incorrectly [ID_35796]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

SLProtocol would interpret signed numbers incorrectly, causing parameters to display incorrect values.

#### Problem with SLNet when serializing a ModelHost error [ID_35802]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

An SLNet error could occur when serializing a ModelHost error.

> [!IMPORTANT]
> BREAKING CHANGE: To fix this issue, the `Exception` field had to be removed from the `ManagerStoreError` class.

#### SLAnalytics: Flatline events on child DVE elements would incorrectly be cleared automatically [ID_35818]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

Events generated after detecting change points of type "flatline" in trend data of child DVE elements would incorrectly be cleared automatically.

#### SLAnalytics - Behavioral anomaly detection: Every parameter included in an alarm template would incorrectly be considered a monitored parameter [ID_35832]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

SLAnalytics would incorrectly consider every parameter included in an alarm template to be a monitored parameter, even it is was not being monitored.

#### DataMiner Maps: Markers could disappear when a layer was enabled or disabled [ID_35838]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

In some cases, markers could disappear when a layer was enabled or disabled.

#### SLAnalytics could keep on waiting indefinitely for large delete operations to finish [ID_35848]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

In some cases, SLAnalytics could keep on waiting indefinitely for large delete operations to finish.

#### Business Intelligence: At SLA startup, the active alarms would no longer be in sync with the actual alarms affecting the SLA [ID_35862]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

At SLA startup, in some cases, the active alarms would no longer be in sync with the actual alarms affecting the SLA.

Also, a number of other minor fixes with regard to SLA management have been implemented.

#### Problem when processing BPA test output [ID_35891]

<!-- MR 10.4.0 - FR 10.3.5 -->
<!-- Not added to MR 10.4.0 -->

Each time the *SLLogCollector* tool is run, since DataMiner version 10.3.3, it orders the *Standalone BPA Executor* tool to execute all BPA tests available in the system and store the results in the `C:\Skyline DataMiner\Logging\WatchDog\Reports\Pending Reports` folder.

In some cases, it would not be possible to process the output of some of those tests due to formatting issues.

#### Problem when an SLA element was stopped or deleted while a parameter that triggered a QAction of the SLA in question was being updated [ID_35892]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

An error could occur when an SLA element was stopped or deleted while a parameter that triggered a QAction of the SLA in question was being updated.

#### DataMinerException thrown the first time an InfoData message was deserialized [ID_35897]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

The first time a message with an object of a type that inherited from `InfoData` was sent from SLNet to a client, the following DataMinerException was thrown when the message was deserialized:

```txt
Skyline.DataMiner.Net.Exceptions.DataMinerException: Failed to deserialize message (ProtoBuf). Possible version incompatibility between client and server.  ---&gt; System.InvalidOperationException: It was not possible to prepare a serializer for: Skyline.DataMiner.Net.InfoData ---&gt; System.InvalidOperationException: Unable to resolve a suitable Add method for System.Collections.Generic.IReadOnlyList`1[[System.Guid, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]&#xD;
```

#### Problem with SLElement when a timed action was stopped [ID_35928]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

In some rare cases, an error could occur in SLElement when a timed action was stopped.

#### Business Intelligence: Outage correction would incorrectly be increased when a history alarm affected the outage [ID_35942]

<!-- MR 10.4.0 - FR 10.3.5 -->

When a history alarm affected a closed outage to which a correction had been applied, the correction would incorrectly be increased. From now on, the correction will be left untouched.

#### SNMP: OIDs with a leading dot would incorrectly no longer be allowed [ID_35954]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

OIDs with a leading dot would incorrectly no longer be allowed. From now on, OIDs with a leading dot are allowed again.

#### NT Notify type NT_GET_BITRATE_DELTA would not return a valid value for a table with a single row [ID_35967]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

In some rare cases, NT Notify type NT_GET_BITRATE_DELTA (269), which retrieves the time between two consecutive executions of the specified SNMP group (in ms), would not return a valid value for a table with a single row.

#### 'SLA Affecting' property of cleared or re-opened alarm would incorrectly contain 'Y' instead of 'Yes' [ID_35987]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When an alarm was cleared and re-opened for the same parameter or parameter key combination, its *SLA Affecting* property would incorrectly contain "Y" instead of "Yes".
