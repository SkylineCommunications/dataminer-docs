---
uid: General_Feature_Release_10.4.11
---

# General Feature Release 10.4.11

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.11](xref:Cube_Feature_Release_10.4.11).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.11](xref:Web_apps_Feature_Release_10.4.11).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

#### Alarms - Behavioral anomaly detection: User feedback [ID 38707] [ID 38980] [ID 39944]

<!-- RN 38707: MR TBD - FR TBD -->
<!-- RN 38980: MR 10.5.0 - FR 10.4.4 -->
<!-- RN 39944: MR 10.5.0 - FR 10.4.11 -->

From now on, users will be allowed to give feedback (positive or negative) on behavioral anomalies.

Up to now, the labeling of behavioral anomalies was purely based on the change point history of a parameter. From now on, user feedback on previous anomalies of the same type will also be taken into account.

> [!NOTE]
>
> - For this user feedback feature to work, the DataMiner System has to include an indexing database.
> - For more information on how to provide feedback on behavioral anomalies in DataMiner Cube, see [Alarm Console - Behavioral anomaly detection: User feedback [ID 39480] [ID 39640] [ID 39666] [ID 39729] [ID 39809] [ID 39945]](xref:Cube_Feature_Release_10.4.11#alarm-console---behavioral-anomaly-detection-user-feedback-id-39480-id-39640-id-39666-id-39729-id-39809-id-39945)

#### Automation: Basic script execution metrics [ID 40687]

<!-- MR 10.5.0 - FR 10.4.11 -->

The SLAutomation process will now generate the following script execution metrics:

- Total number of executed scripts (including scripts that could not be started)
- Total number of failed scripts
- Duration of each script
- Time at which each script was started
- Users who started the scripts
- Result of each script (success of failure)

To view these metrics, open the *SLNetClientTest* tool, go to *Advanced > Automation...*, and open one of the following tabs:

| Tab | Information |
|-----|-------------|
| Scripts Statistics    | Information about each script execution.     |
| Automation Statistics | General information about script executions. |

## Changes

### Breaking changes

#### GQI - 'Get alarms' data source: Updated 'Alarm ID' and 'Root Alarm ID' columns [ID 40372]

<!-- MR 10.5.0 - FR 10.4.11 -->

In the *Get alarms* data source, the following columns have been updated:

| Column | Former contents | New contents |
|--------|-----------------|--------------|
| Alarm ID      | HostingDMAID/AlarmID     | DMAID/EID/RootAlarmID/AlarmID |
| Root Alarm ID | HostingDMAID/RootAlarmID | DMAID/EID/RootAlarmID         |

> [!NOTE]
> "DMAID" refers to the DataMiner ID of the DataMiner Agent where the element was originally created. "HostingDMAID" refers to the DataMiner ID of the DataMiner Agent currently hosting the element and managing its alarms. Most of the time, these two values will be the same, but they may differ, for example, when an element is exported from one Agent and imported onto another Agent. In this case, the element retains the original DMAID, but the HostingDMAID will reflect the new Agent's ID.

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

#### Visual Overview: All dynamic text in the KPI stencil will now automatically be truncated [ID 40545]

<!-- MR 10.4.0 [CU8] - FR 10.4.11 -->

All dynamic text in the KPI stencil will now automatically be truncated with "..." to prevent it from exceeded the dimensions of a shape.

#### Cassandra Cluster Migrator tool: Enhanced migration of Failover systems [ID 40576]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

Up to now, when the Cassandra Cluster Migrator tool (*SLCCMigrator.exe*) was used to migrate a DataMiner System that included at least one Failover system, the following actions still had to be performed manually:

- Checking whether all agents are stopped.
- Updating the *DB.xml* file on all agents to make sure the database type is set to "CassandraCluster".
- Starting all agents.

Because of a number of enhancements, from now on, no manual intervention whatsoever will be needed when the Cassandra Cluster Migrator tool is used to migrate a DataMiner System that includes at least one Failover system.

#### SLAnalytics - Behavioral anomaly detection: Enhanced variance increase detection [ID 40580]

<!-- MR 10.5.0 - FR 10.4.11 -->

Because of a number of enhancements, variance increase detection has been improved.

#### Trimmed log entries will now get an '(x bytes omitted)' suffix [ID 40629]

<!-- MR 10.5.0 - FR 10.4.11 -->

In log files generated by SLLog, all messages longer than 5120 characters are trimmed by default.

From now on, all messages that have been trimmed will get a `(x bytes omitted)` suffix. That way, users will immediately notice which messages have been trimmed.

#### GQI: DOMHelper can now retrieve DOM instances in the background using a custom page size [ID 40654]

<!-- MR 10.5.0 - FR 10.4.11 -->

Up to now, when the DOM GQI adapter retrieved DOM instances in the background, it would do so page by page using a default page size of 500, even if a different page size was specified in the request. From now on, the GQI adapter will force the DomHelper to use the provided page size when it retrieves DOM instances in the background.

The page size must be set to a value between 10 and 500. When a page size value below 10 or above 500 is passed, the DomHelper will retrieve DOM instances using a page size of 10 or 500, respectively.

#### Trending - Relation learning: Light bulb will now also propose time-scoped related parameters from other elements within the same service [ID 40658]

<!-- MR 10.5.0 - FR 10.4.11 -->

In e.g. DataMiner Cube, a light bulb icon will be displayed when you select a time range on the trend graph of a parameter. If you want to know which other parameters are related to this parameter, based purely on the behavior during the selected time range, then you can click this icon to add or view related parameters. Even if multiple curves are displayed on the same trend graph, the light bulb always shows relations with one specific parameter, whose name is mentioned in the light bulb tooltip.

Up to now, this feature only proposed parameters from the same DataMiner element. From now on, it will also propose parameters from other elements within the same service.

#### Correlation: Only the most recent information about correlation alarm tree entries will now be cached [ID 40661]

<!-- MR 10.5.0 - FR 10.4.11 -->

Up to now, SLNet would cache all information about all entries in a correlation alarm (group) tree. In order to reduce the amount of data in this cache, from now on, only the most recent information about these entries will be kept in memory.

#### Automation: Enhanced locking when calling 'SetParameter' and 'GetParameter' on an element [ID 40682]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

A number of enhancements have been made to the locking behavior in the SLAutomation process in order to prevent unnecessary holdups when interacting with the `Engine` and related `Element` objects in Automation scripts.

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

#### Failover: Both agents will now keep a copy of the C:\\Skyline DataMiner\\Configurations\\ClusterEndpoints.json file [ID 40702]

<!-- MR 10.5.0 - FR 10.4.11 -->

When, in a Failover setup, a DataMiner Agent went offline, up to now, its `C:\Skyline DataMiner\Configurations\ClusterEndpoints.json` file would by default be cleared.

From now on, both DMAs in a Failover setup will keep a copy of the `C:\Skyline DataMiner\Configurations\ClusterEndpoints.json` file, and the online agent will push all changes made to that file toward the offline agent in order to keep both files in sync.

#### Service & Resource Management: Switching master agents [ID 40712]

<!-- MR 10.5.0 - FR 10.4.11 -->

From now on, when you have been granted the *Modules > System configuration > Tools > Admin tools* permission, you can indicate that a DataMiner Agent is "not eligible to be promoted to master" by sending a `ResourceManagerConfigInfoMessage` in which the `IsMasterEligible` property is set to false.

When the DataMiner Agent that is currently the master agent is marked "not eligible to be promoted to master", the other DataMiner Agents in the DMS will elect a new master from the pool of DataMiner Agents that have been marked "eligible to be promoted to master".

The `IsMasterEligible` property of a DataMiner Agent is stored in the ResourceManager configuration. If the property is not filled in, the agent will be considered "eligible to be promoted to master".

> [!NOTE]
> If the current master agent is marked "not eligible to be promoted to master", it will continue to process all ongoing and queued requests as if it were still master agent. However, all new requests will be forwarded to the new master agent. As a result, it is currently only possible to switch master agents when there are no ongoing master-synced requests.

#### SLAnalytics will now wait longer for a message from SLNet announcing that it has finished loading the configuration [ID 40729]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

When starting up, up to now, SLAnalytics would wait up to 400 seconds for a message from SLNet announcing that it has finished loading the configuration. From now on, it will wait up to 20 minutes.

#### SLAnalytics: Maximum number of parameter changes processed by SLAnalytics will no longer be limited to 5000 per second [ID 40730]

<!-- MR 10.4.0 [CU8] - FR 10.4.11 -->

From now on, the maximum number of parameter changes processed by SLAnalytics will no longer be limited to 5000 per second.

#### Protocols: Smart-serial connections now also support non-abbreviated IPv6 loopback addresses [ID 40758]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

Up to now, smart-serial connections would support IPv6 loopback addresses only if they were abbreviated (e.g. `::1`).

From now on, smart-serial connections will also support non-abbreviated IPv6 loopback addresses (e.g. `0:0:0:0:0:0:0:1` or similar).

#### Enhanced performance when loading newly created elements into SLDataMiner [ID 40762]

<!-- MR 10.5.0 - FR 10.4.11 -->

Because of a number of enhancements, overall performance has increased when loading newly created elements into SLDataMiner.

#### Automation: Engine methods will now use alarm IDs with the syntax DMAID/ELEMENTID/ROOTID [ID 40773]

<!-- MR 10.5.0 - FR 10.4.11 -->

From now on, the following Engine methods will use alarm IDs with the syntax DMAID/ELEMENTID/ROOTID. Up to now, they used alarm IDs with the syntax DMAID/AlarmID.

- GetAlarmProperty
- SetAlarmProperty
- SetAlarmProperties
- AcknowledgeAlarm

#### DataMiner backup: nats-server.config file by default added to backup packages [ID 40812]

<!-- MR 10.5.0 - FR 10.4.11 -->

From now on, the *nats-server.config* file, located in the `C:\Skyline DataMiner\NATS\nats-streaming-server\` folder, will by default be added to all backup packages (except the predefined backup type *Visual Configuration Backup*).

#### SLLogCollector: Deprecated tool used to archive collected files replaced [ID 40815]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

The tool used by SLLogCollector to archive the files it collects is deprecated and has now been replaced.

> [!IMPORTANT]
> The archives produced by the new tool can no longer be opened by the built-in Windows file archiver. To open these archives, users will now have to use third-party tools like e.g. 7-Zip.

### Fixes

#### ReIndexElasticSearchIndexes tool would incorrectly overwrite the existing mapping by the default mappings [ID 40073]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

When the *ReIndexElasticSearchIndexes* tool was run, the existing mappings (which define how types should be handled) would incorrectly be overwritten by the default mappings. From now on, the existing mappings will be correctly passed from source database to destination database.

#### SLDataGateway would not send the correct error to the client application when there was a database problem [ID 40488]

<!-- MR 10.5.0 - FR 10.4.11 -->

When SLDataGateway detected a database problem, up to now, it would incorrectly send a message mentioning a Cassandra error to the client (e.g. DataMiner Cube) whatever the type of database that was being used. From now on, the message sent to the client will mention the database that is actually being used.

Also, on systems using a Cassandra Cluster database, when the indexing engine could not be reached, up to now, DataMiner would keep on restarting. From now on, as soon as a required database cannot be reached, DataMiner will stop without trying to restart.

#### Logger tables and slatable data would not be deleted from the Cassandra Cluster database when the associated element was deleted [ID 40523]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

If an element had logger tables that were stored in a database of type *CassandraCluster*, up to now, those logger tables would not be deleted from the database when the element was deleted.

Similarly, when an SLA element was deleted, the data in the slatable associated with that element would not be deleted.

#### SLAnalytics would get blocked for too long when it failed to perform a database operation [ID 40603]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

When SLAnalytics fails to perform a database operation, it will retry the same operation several times before eventually giving up. While SLAnalytics is performing those retries, the cache will get blocked, causing all SLAnalytics functionality that relies on that cache to also get blocked.

In order to prevent SLAnalytics from getting blocked for too long and from taking up too much memory, from now on, SLAnalytics will perform less retries if the previous database operation it performed in the last hour also failed.

#### Storage as a Service: Problem when attempting to upgrade alarm masking data [ID 40625]

<!-- MR 10.4.0 [CU8] - FR 10.4.11 -->

When a DataMiner Agent using STaaS started up, up to now, an error would be thrown when the DataMiner Agent attempted to upgrade alarm masking data to the new masking data format used since DataMiner version 10.0.0. As STaaS has only been supported since DataMiner version 10.4.0, upgrading alarm masking data is not necessary. Therefore, from now on, a DataMiner Agent using STaaS will no longer attempt to do so.

#### Service & Resource Management: Problem when retrieving resource pools with a property filter [ID 40642]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

When resource pools were retrieved with a property filter, and one of the resource pools had "null" properties, a `NullReferenceException` would be thrown and no resource pools would be returned.

> [!NOTE]
> The above-mentioned exception would only be thrown when, instead of `FilterElements`, (deprecated) object filters were being used.

#### Maps: Filter would incorrectly be altered when the filter pane was collapsed [ID 40660]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

When you collapsed the filter pane, in that filter pane, the text box would be cleared and all alarm severity checkboxes would automatically be selected. From now on, when you expand or collapse the filter pane, the text box will no longer be cleared and the checkboxes will no longer be automatically selected.

Also, when you collapse the filter pane, the looking glass icon will now blink blue if a non-default filter is set.

#### DataMiner Cube - Scheduler app: No error would be shown when trying to send an email with a non-existing dashboard in attachment [ID 40705]

<!-- MR 10.5.0 - FR 10.4.11 -->

When, in e.g. Cube's Scheduler app, an action would send an email with in attachment a dashboard that no longer existed, the email would not be sent, but no error would be shown.

From now on, when an action tries to send an email with a non-existing dashboard in attachment, the task will fail and an exception will be thrown.

#### Problem when masking or unmasking DELT elements [ID 40723]

<!-- MR 10.5.0 - FR 10.4.11 -->

When a DELT element was masked or unmasked, when no hosting agent ID was passed along in the SetAlarmStateMessage, the message would be sent to the DataMiner Agent referred to by the DataMiner ID of the element. In some rare cases, this DataMiner ID could refer to a non-existing DataMiner Agent, causing an exception to be thrown.

#### Decreased performance when either deleting rows from large tables or clearing large tables [ID 40748]

<!-- MR 10.5.0 - FR 10.4.11 -->
<!-- Not added to MR 10.5.0 - Introduced by RN 37617 -->

As from feature release 10.4.3, overall performance had decreased when either deleting rows from large tables or clearing large tables.

#### SLAnalytics: Problem when fetching data at startup on STaaS/DaaS systems hosting more than 950 elements [ID 40790]

<!-- MR 10.4.0 [CU8] - FR 10.4.11 -->

When, in a DataMiner System, a DataMiner Agent using STaaS/DaaS was hosting more than 950 elements, in some cases, SLAnalytics could throw errors when fetching data from the database at startup.

#### Word "asynchronous" would be spelled incorrectly in element log file entries [ID 40856]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

In element log file, up to now, the word "asynchronous" would be spelled incorrectly as "ascynchronous" in entries notifying that an asynchronous QAction had failed. In those log entries, this word will now be spelled correctly.

#### Problem with SLProtocol when processing actions that occurred when an element was stopped or deleted [ID 40859]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

When an unhandled exception was thrown by a QAction after an element had been stopped or deleted or when a *force group* action was executed while an element was being stopped or deleted, in some cases, SLProtocol could stop working.

#### GetAlarmDetailsMessage: Version compatibility problem [ID 40895]

<!-- MR 10.5.0 - FR 10.4.11 [CU0] -->
<!-- Not added to MR 10.5.0 - Introduced by RN 40089 -->

Since DataMiner feature version 10.4.10, *GetAlarmDetailsMessage* could no longer be sent from clients running feature version 10.4.10 to DataMiner Agents running feature version 10.4.1 or older.

#### DataMiner as a Service: Incorrect 'This DataMiner Agent is not licensed' message [ID 41130]

<!-- MR 10.4.0 [CU9] - FR 10.4.11 [CU0] -->

On DaaS systems, in some cases, the online license check could fail, causing client apps (e.g. DataMiner Cube) to incorrectly show a "This DataMiner Agent is not licensed" message.
