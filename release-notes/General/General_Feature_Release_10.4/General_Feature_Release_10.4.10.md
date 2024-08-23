---
uid: General_Feature_Release_10.4.10
---

# General Feature Release 10.4.10 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.10](xref:Cube_Feature_Release_10.4.10).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.10](xref:Web_apps_Feature_Release_10.4.10).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### Protocols: Newly installed connector will automatically be promoted to production version [ID_40291]

<!-- MR 10.5.0 - FR 10.4.10 -->

Up to now, after you had installed a connector for the first time, you typically had to promote it to "production version" afterwards. From now on, when you install a connector for the first time, DataMiner will automatically promote it to "production version" and add the following entry to the *SLNet.txt* log file:

``Initial upload of protocol '{protocolName}'. Version '{protocolVersion}' will be automatically set as production.``

For example, when I install *MyConnector 1.0.0.1* for the first time, it will automatically be promoted to "production version", but when I later deploy *MyConnector 1.0.0.2*, version 1.0.0.1 will remain the production version.

A connector will only be promoted to "production version" if its first version is installed/uploaded in one of the following ways:

- When it is published from within DataMiner Integration Studio (DIS).
- When it is deployed from the [DataMiner Catalog](https://catalog.dataminer.services/).
- When its *.dmprotocol* file is uploaded from the *Protocols & Templates* app in DataMiner Cube.

> [!NOTE]
> When you install the first version of a connector by uploading its *protocol.xml* file from the *Protocols & Templates* app in DataMiner Cube (instead of its *.dmprotocol* file), the connector will not be automatically promoted to "production version".

## Changes

### Enhancements

#### Improved performance when alarm filters containing operators are used [ID_39732]

<!-- MR 10.4.0 [CU7] - FR 10.4.10 -->

Alarm filters that contain the operators AND, OR, or NOT (without brackets) will now be translated to OpenSearch queries, which will improve the performance of these filters. This will for example lead to improved performance when filtering alarms on a specific element and on severity.

#### DataMiner upgrade: 'C:\\Skyline Dataminer\\Logging\\FormatterExceptions' folder will now be emptied during the upgrade process [ID_39894]

<!-- MR 10.5.0 - FR 10.4.10 -->

The *C:\\Skyline Dataminer\\Logging\\FormatterExceptions* folder will now be emptied each time a DataMiner upgrade is performed.

This folder is used by Skyline developers to keep track of serialization issues.

#### Correlation engine now supports separate alarm ID ranges per element [ID_40089]

<!-- MR 10.5.0 - FR 10.4.10 -->

The Correlation engine now supports separate alarm ID ranges per element.

Also, *GetAlarmDetailsMessage* and *GetAlarmTreeDetailsMessage* now support separate alarm ID ranges per element and take AlarmTreeID instances as input.

#### BPA tests will no longer be executed immediately after a DataMiner restart [ID_40201]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

Up to now, all BPA tests would be executed immediately after DataMiner had been started.

From now on, the *Report Active RTE* test will be executed for the first time exactly 8 minutes after DataMiner has been started, and all other BPA tests will be executed between 10 and 60 minutes after DataMiner has been started.

#### Service & Resource Management: Enhanced synchronization of resources and resource pools between the SRM master agent and the other agents in a DataMiner System [ID_40389]

<!-- MR 10.4.0 [CU7] - FR 10.4.10 -->

A number of enhancements have been made with regard to the synchronization of resources and resource pools between the SRM master agent and the other agents in a DataMiner System. This should improve performance when creating resources on non-master agents.

#### New 'IsCloudConnected' message to check whether the DataMiner System is connected to dataminer.services [ID_40395]

<!-- MR 10.5.0 - FR 10.4.10 -->

From now on, you can check whether the DataMiner System is connected to dataminer.services by sending either a *GetCCAGatewayGlobalStateRequest* message or an *IsCloudConnected* message.

- The *IsCloudConnected* message does not require any special user permissions.
- The *GetCCAGatewayGlobalStateRequest* message did no longer require the *Modules > System configuration > Cloud sharing/gateway > Connect to cloud/DCP* user permission as from DataMiner feature version 10.4.9. From now on, this message will again require said permission.

#### DxMs upgraded to versions requiring .NET 8 [ID_40445]

<!-- MR 10.4.0 [CU7] - FR 10.4.10 -->

All DxMs included in the DataMiner upgrade package have now been upgraded to versions requiring .NET 8.

### Fixes

#### Problem in SLDataMiner when redundancy groups were configured to switch based on connectivity [ID_40118]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

When redundancy groups were configured to switch based on connectivity, it could occur that the signals sent to SLDataMiner contained duplicates. In a system with a heavy load, this could cause too many of these to be sent, which would cause a memory leak in the SLDataMiner process and eventually caused the process to crash.

Performance improvements have now been implemented to avoid sending duplicate signals and to better process the signals. A throttling mechanism has also been implemented: in case SLDataMiner detects that too many signals are being sent, the DCF calculation will be slowed down to allow the system to catch up. In the logging, this will be mentioned in *SLConnectivity.txt* like in the example below:

```txt
07/04 09:13:32.713|SLNet.exe|Log|INF|0|174|Received throttle request to slowdown DCF path calculation current value: 5000 ms

2024/07/04 09:15:34.019|SLNet.exe|Log|INF|0|172|Received stop throttle request to resume normal DCF path calculation current value: 1000 ms

07/04 09:13:32.713|SLNet.exe|Log|INF|0|174|Received throttle request to slowdown DCF path calculation current value: 5000 ms

2024/07/04 09:16:29.462|SLNet.exe|Log|INF|0|175|Received throttle request to slowdown DCF path calculation current value: 25000 ms

2024/07/04 09:22:51.732|SLNet.exe|Log|INF|0|54|Received stop throttle request to resume normal DCF path calculation current value: 1000 ms
```

#### Changes implemented with parameter-specific template editors not saved correctly [ID_40125]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

When you changed the alarm or trend template for a table parameter (e.g. by going to the templates tab on the parameter card), it could occur that the wrong line from the template was edited. For example, if a template contained exactly one line for a column in a table, and that line was configured with the filter "SL*", the parameter template editor would show the configuration corresponding to the line in the template with the filter even if that line was not applicable for the current cell. Now, instead an empty template configuration will be shown, corresponding to the filter "\*". When you edit and save this configuration, a new line with filter "\*" will be added to the template.

In addition, when there were two or more lines in the trend template for a table parameter, but none were applicable for the current cell for which you edited the trend template, the parameter template editor would show and create a new line in the template corresponding to an empty filter, instead of to the filter "\*". This has now also been fixed.

Finally, if you changed the information template for a parameter, and the information template did not contain a line for the current parameter, the ID was not saved correctly. In addition, for table parameters, a line with an empty filter would be saved, instead of the filter "\*".

#### Problem in SLProtocol because virtual primary element behaved like regular element [ID_40321]

<!-- MR 10.4.0 [CU7] - FR 10.4.10 -->

Because of a race condition, it could occur that a virtual primary element in a redundancy group behaved as if it were a regular DataMiner element. This could cause a run-time error in the SLProtocol process and could eventually cause the process to crash.

#### DELT import failed if element name contained curly bracket [ID_40330]

<!-- MR 10.5.0 - FR 10.4.10 -->

When an element name contained a curly bracket ("{" or "}"), exporting the element to a .dmimport package or importing it from such a package failed.

#### Problem with SLProtocol when using a timer to perform 'SNMP Get' operations [ID_40402]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

When using a timer to perform *SNMP Get* operations on all rows in a table, you have two options:

- the thread pool option (which you activate by specifying the *threadPool* keyword), or
- the default logic (which you activate by not specifying the *threadPool* keyword).

When the default logic was used, up to now, when you stopped an element before the *SNMP Get* operations were completed, resources that were still required would incorrectly be cleaned up, leading to the SLProtocol process being stopped.

In order to remedy this behavior, the `DeInit` method of the `protocol` object has now been updated. It will now always wait for the *SNMP Get* operations to finish before proceeding.

Also, up to now, the thread that handles the *SNMP Get* operations would not correctly catch exceptions, which resulted in no crashdump files being automatically generated when exceptions occurred. This made it difficult to diagnose the issue, as it required setting up a procdump and waiting for the issue to occur again.

#### Protocols: Problem when a response with a 'next param' and a 'fixed length' parameter did not have a trailer defined [ID_40430]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

Up to now, when a response contained a parameter with a LengthType equal to "next param" and another parameter with a LengthType equal to "fixed" but no trailer, SLPort would incorrectly return the payload to SLProtocol as soon as it read at least the number of bytes that was configured in the fixed length parameter.

#### Cassandra Cluster Migrator: Problem when retrying an alarm migration [ID_40434]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

When, using the Cassandra Cluster Migrator tool (*SLCCMigrator.exe*), you retried an alarm migration, the migration would immediately fail and go into a *Cancelled* state.

#### SLAnalytics - Pattern matching: Problem when a pattern was deleted on one DMA while it was being edited on another DMA [ID_40471]

<!-- MR 10.4.0 [CU7] - FR 10.4.10 -->

In some rare cases, SLAnalytics could stop working when a pattern was deleted on one DMA while it was being edited on another DMA.

#### DataMiner Object Models: Not possible to create multiple DOM module subscriptions [ID_40508]

<!-- MR 10.5.0 - FR 10.4.10 -->

Up to now, when an attempt was made to create multiple DOM module subscriptions at a time, only the first subscription would be created.

From now on, it will be possible to create multiple DOM module subscriptions on one connection.

#### SLAnalytics - Alarm focus: Problem with time of arrival when clearing a focus event [ID_40509]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

When a focus event was cleared because an element had been deleted, up to now, the time of arrival of the new focus event (i.e. the time at which the focus event had been cleared) would incorrectly be identical to the time of arrival of the focus event that had been cleared.

From now on, the time of arrival of the new focus event will instead be the current time (i.e. the time at which the element was deleted).
