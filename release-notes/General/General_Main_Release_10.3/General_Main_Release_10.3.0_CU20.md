---
uid: General_Main_Release_10.3.0_CU20
---

# General Main Release 10.3.0 CU20

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.3.0 CU20](xref:Cube_Main_Release_10.3.0_CU20).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.3.0 CU20](xref:Web_apps_Main_Release_10.3.0_CU20).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Failover: Virtual IP address check will now use both a ping and an arp command to check whether an IP address is free [ID 40516]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

Up to now, on systems that do not allow ping commands to be executed, in some cases, the virtual IP address check would incorrectly conclude that the IP address was free and decide to claim it, causing the network interface card to malfunction due to IP addresses not being unique.

From now on, when the virtual IP address check has concluded that the IP address is free after having executed the required number of ping commands, it will double-check by executing an arp command.

#### Visual Overview: Enhanced image quality when zooming [ID 40537]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

Because of a number of enhancements, the image quality of visual overviews during zoom operations in web applications has improved.

Limitations:

- In visual overviews shown on mobile devices, unlike in DataMiner Cube, grouped shapes will not ungroup when zooming.
- Scrolling on *Children* shapes that extend their boundaries will cause the visual overview to zoom instead of scroll. If you want the visual overview to scroll, you will have to use the scrollbar.

#### Cassandra Cluster Migrator tool: Enhanced migration of Failover systems [ID 40576]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

Up to now, when the Cassandra Cluster Migrator tool (*SLCCMigrator.exe*) was used to migrate a DataMiner System that included at least one Failover system, the following actions still had to be performed manually:

- Checking whether all agents are stopped.
- Updating the *DB.xml* file on all agents to make sure the database type is set to "CassandraCluster".
- Starting all agents.

Because of a number of enhancements, from now on, no manual intervention whatsoever will be needed when the Cassandra Cluster Migrator tool is used to migrate a DataMiner System that includes at least one Failover system.

#### Automation: Enhanced locking when calling 'SetParameter' and 'GetParameter' on an element [ID 40682]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

A number of enhancements have been made to the locking behavior in the SLAutomation process in order to prevent unnecessary holdups when interacting with the `Engine` and related `Element` objects in automation scripts.

The following calls have been improved:

- `element.SetParameter` and associated methods:

  - `ConnectMatrixCrosspoint`
  - `DisconnectMatrixCrosspoint`
  - `SetParameterByPrimaryKey`

- `element.GetParameter` and associated methods:

  - `GetMatrixInputForOutput`
  - `GetParameterByPrimaryKey`
  - `GetParameterDisplay`
  - `GetParameterDisplayByPrimaryKey`
  - `IsMatrixCrosspointConnected`

#### SLAnalytics will now wait longer for a message from SLNet announcing that it has finished loading the configuration [ID 40729]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

When starting up, up to now, SLAnalytics would wait up to 400 seconds for a message from SLNet announcing that it has finished loading the configuration. From now on, it will wait up to 20 minutes.

#### Protocols: Smart-serial connections now also support non-abbreviated IPv6 loopback addresses [ID 40758]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

Up to now, smart-serial connections would support IPv6 loopback addresses only if they were abbreviated (e.g. `::1`).

From now on, smart-serial connections will also support non-abbreviated IPv6 loopback addresses (e.g. `0:0:0:0:0:0:0:1` or similar).

#### SLLogCollector: Deprecated tool used to archive collected files replaced [ID 40815]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

The tool used by SLLogCollector to archive the files it collects is deprecated and has now been replaced.

> [!IMPORTANT]
> The archives produced by the new tool can no longer be opened by the built-in Windows file archiver. To open these archives, users will now have to use third-party tools like e.g. 7-Zip.

#### Element replication: Replicated elements will fall back to their default buffer settings when created with an unlimited buffer [ID 40822]

<!-- MR 10.3.0 [CU20] - FR TBD -->

When a new replicated element is created, its replication buffer settings (`maxMessagesToBuffer` and `maxMinutesToBuffer`) should by default be set to 10000 and 60, respectively. See the following example:

```xml
<Replication active="True" options="" remoteElement="162/43" externalDMPEngine="False" maxMessagesToBuffer="10000" maxMinutesToBuffer="60">
```

However, up to now, new replicated elements would incorrectly be created with `maxMessagesToBuffer` and `maxMinutesToBuffer` both set to 0. As a result, the buffer was allowed to grow indefinitely as long as the replication connection was not active.

From now on, whenever a replicated element is created with `maxMessagesToBuffer` and `maxMinutesToBuffer` both set to 0, these settings will automatically be changed to 10000 and 60, respectively.

If, for any reason, you want the buffer of a replication element to not have any limits, you can set both `maxMessagesToBuffer` and `maxMinutesToBuffer` to -1. See the example below:

```xml
<Replication active="True" options="" remoteElement="162/43" externalDMPEngine="False" maxMessagesToBuffer="-1" maxMinutesToBuffer="-1">
```

#### SLDataGateway: Enhanced logging [ID 40846]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR TBD -->

A number of enhancements have been made with regard to the logging of the SLDataGateway process.

The *SLDBConnection.txt* and *SLCloudStorage.txt* log files will now contain cleaner entries, and entries of type "Error" will also be added to the *SLError.txt* file.

Also, runtime log level updates will now be applied at runtime without requiring a DataMiner restart.

### Fixes

#### ReIndexElasticSearchIndexes tool would incorrectly overwrite the existing mapping by the default mappings [ID 40073]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

When the *ReIndexElasticSearchIndexes* tool was run, the existing mappings (which define how types should be handled) would incorrectly be overwritten by the default mappings. From now on, the existing mappings will be correctly passed from source database to destination database.

#### Logger tables and slatable data would not be deleted from the Cassandra Cluster database when the associated element was deleted [ID 40523]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

If an element had logger tables that were stored in a database of type *CassandraCluster*, up to now, those logger tables would not be deleted from the database when the element was deleted.

Similarly, when an SLA element was deleted, the data in the slatable associated with that element would not be deleted.

#### SLAnalytics would get blocked for too long when it failed to perform a database operation [ID 40603]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

When SLAnalytics fails to perform a database operation, it will retry the same operation several times before eventually giving up. While SLAnalytics is performing those retries, the cache will get blocked, causing all SLAnalytics functionality that relies on that cache to also get blocked.

In order to prevent SLAnalytics from getting blocked for too long and from taking up too much memory, from now on, SLAnalytics will perform less retries if the previous database operation it performed in the last hour also failed.

#### Service & Resource Management: Problem when retrieving resource pools with a property filter [ID 40642]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

When resource pools were retrieved with a property filter, and one of the resource pools had "null" properties, a `NullReferenceException` would be thrown and no resource pools would be returned.

> [!NOTE]
> The above-mentioned exception would only be thrown when, instead of `FilterElements`, (deprecated) object filters were being used.

#### Maps: Filter would incorrectly be altered when the filter pane was collapsed [ID 40660]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

When you collapsed the filter pane, in that filter pane, the text box would be cleared and all alarm severity checkboxes would automatically be selected. From now on, when you expand or collapse the filter pane, the text box will no longer be cleared and the checkboxes will no longer be automatically selected.

Also, when you collapse the filter pane, the looking glass icon will now blink blue if a non-default filter is set.

#### Word "asynchronous" would be spelled incorrectly in element log file entries [ID 40856]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

In element log file, up to now, the word "asynchronous" would be spelled incorrectly as "ascynchronous" in entries notifying that an asynchronous QAction had failed. In those log entries, this word will now be spelled correctly.

#### Problem with SLProtocol when processing actions that occurred when an element was stopped or deleted [ID 40859]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

When an unhandled exception was thrown by a QAction after an element had been stopped or deleted or when a *force group* action was executed while an element was being stopped or deleted, in some cases, SLProtocol could stop working.
