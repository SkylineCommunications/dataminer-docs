---
uid: General_Main_Release_10.6.0_changes
---

# General Main Release 10.6.0 – Changes (preview)

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Changes

### Enhancements

#### DataMiner installer has been updated [ID 40409] [ID 41299] [ID 43030]

<!-- RN 40409: MR 10.6.0 - FR 10.5.1 -->
<!-- RN 41299: MR 10.6.0 - FR 10.5.1 -->
<!-- RN 43030: MR 10.6.0 - FR 10.5.8 -->

The DataMiner installer has been updated.

- When the configuration window appears, it will now be possible to either continue with the configuration or cancel the entire installation.

- When, while installing DataMiner using the DataMiner installer, you have selected to use STaaS for data storage, at some point, you will have to select the STaaS region. Up to now, you were only able to select one of two hard-coded regions. From now on, the available STaaS regions will be retrieved from dataminer.services by means of an API call.

> [!TIP]
> For more information on the installer, see [Installing DataMiner using the DataMiner Installer](xref:Installing_DM_using_the_DM_installer).

#### DataMiner recycle bin enhancements [ID 40565]

<!-- MR 10.6.0 - FR 10.5.5 -->

The `C:\Skyline DataMiner\Recycle Bin\` folder contains backup copies of modified configuration files and folders, stored as zip files. Each zip file includes the modified file or folder along with a *Cause.txt* file, which details the reason for the change and its timestamp. These backup copies help you restore previous configurations if needed.

Up to now, a separate zip file would be created for each configuration change that had been implemented in the system.

From now on, the contents of the `C:\Skyline DataMiner\System Cache\Recyclable\` folder will be zipped and moved to the `C:\Skyline DataMiner\Recycle Bin\` folder every 11 minutes. This process will first occur 3 minutes after DataMiner startup.

When a configuration change occurs, two scenarios are possible:

- If the file or folder has not been modified after the most recent move to the *Recycle Bin* folder (which happens every 11 minutes), a new entry is created in the `C:\Skyline DataMiner\System Cache\Recyclable\` folder with the name of the changed file or folder.

- If the file or folder has been modified after the most recent move to the *Recycle Bin* folder, the existing entry in the `C:\Skyline DataMiner\System Cache\Recyclable\` folder is not replaced. Instead, the *Cause.txt* file is updated with the new change description and corresponding timestamp.

##### RecycleBinSize setting in MaintenanceSettings.xml

In the *MaintenanceSettings.xml* file, you can specify the maximum size (in MB) of the DataMiner recycle bin in the *RecycleBinSize* tag.

From now on, the system will check every 7 minutes whether storage limits have been exceeded. If the system detects a breach, it will perform a cleanup on the recycle bin to restore the storage within acceptable limits:

- If the number of files exceeds the limit, the system will clean up the recycle bin until it holds 80% of the lowest value between the maximum allowed number of files (default: 1000) and the current number of files.

- If the folder size exceeds the limit, the system will clean up until the folder size is no longer over the configured size limit.

This cleanup will occur for the first time 2 minutes after DataMiner startup. Up to now, the recycle bin was cleaned to the maximum size and number of files every hour.

> [!NOTE]
>
> - Whatever the maximum size specified in the *RecycleBinSize* tag, the maximum number of files in the recycle bin is limited to 5000.
> - The default recycle bin size is 100 MB.
> - From now on, if the recycle bin size is set to 0 MB or an invalid size, it will revert to the default value of 100 MB.

##### Restoring a previous configuration

If an incorrect configuration change is implemented in the system, in some cases, it is possible to use the recycle bin to restore the original configuration.

For example, if a view is renamed or moved in the Surveyor, a zip file will be created containing the *Views.xml* file and a cause file, which details why the change occurred. It is then possible to restore the *Views.xml* file as follows:

1. Copy the file from the *Recycle Bin* folder back to its original location.

   > [!NOTE]
   > From now on, the files in the *Recycle Bin* folder are only updated every 11 minutes. This means that when you restore the files, they may not contain recent changes.

1. Restart the DMA.

1. Force a synchronization of the file in the DMS.

> [!CAUTION]
> Always be extremely careful when using this functionality, as it can have far-reaching consequences on your DataMiner System.

#### Security enhancements [ID 41425] [ID 41475]

<!-- 41425: MR 10.6.0 - FR 10.5.4 -->
<!-- 41475: MR 10.6.0 - FR 10.5.2 -->

A number of security enhancements have been made.

#### Legacy correlation engine is now deprecated [ID 40834]

<!-- MR 10.6.0 - FR 10.5.1 -->

The legacy correlation engine is now deprecated. As of this version, DataMiner will no longer support legacy correlation rules.

#### Clustering compatibility check enhancements [ID 41046]

<!-- MR 10.6.0 - FR 10.5.1 -->

When, in e.g. DataMiner Cube, you try to add a DataMiner Agent to the DataMiner System, a number of checks will be performed to determine whether the new Agent is compatible to be added.

The checks with regard to database compatibility have now been enhanced.

#### SLAnalytics: Synchronization of the configuration.xml file can now be forced via Cube [ID 41270]

<!-- MR 10.6.0 - FR 10.5.1 -->

Up to now, when you had made changes to a `C:\Skyline DataMiner\Analytics\configuration.xml` file on the leader Agent, you had to manually replace the file on all Agents in the cluster. From now on, you can force the synchronization of this file via Cube.

See also [Synchronizing data between DataMiner Agents](xref:Synchronizing_data_between_DataMiner_Agents)

#### DataMiner Taskbar Utility: 'Launch > Download DataMiner Cube' command will now download the DataMiner Cube desktop app [ID 41308]

<!-- MR 10.6.0 - FR 10.5.2 -->

When you right-clicked the *DataMiner Taskbar Utility* icon in the system tray, and then clicked *Launch > DataMiner Cube*, up to now, the DataMiner Taskbar Utility would incorrectly still try to launch the deprecated XBAP version of DataMiner Cube.

From now on, when you click *Launch > Download DataMiner Cube*, the DataMiner Cube desktop app will be downloaded. When you then double-click the downloaded file, the following will happen:

- When the DataMiner Cube desktop app is installed, the DataMiner Cube desktop app will open and a tile representing the local DMA will be added to it (if no such tile already exists).

  If you then want to open a Cube session connected to the local DMA, click the tile representing the local DMA.

- When the DataMiner Cube desktop app has not yet been installed, you will be asked whether it should be installed or not. If you choose to install it, it will be installed and immediately opened to host a Cube session connected to the local DMA.

#### Business intelligence: SLAs will now use alarm IDs with the syntax DMAID/ELEMENTID/ROOTID [ID 41328]

<!-- MR 10.6.0 - FR 10.5.1 -->

From now on, SLAs will use alarm IDs with the syntax DMAID/ELEMENTID/ROOTID. Up to now, they used alarm IDs with the syntax DMAID/AlarmID.

#### Protocols: New 'overrideTimeoutVF' option to override the timeout for a virtual function [ID 41388]

<!-- MR 10.6.0 - FR 10.5.3 -->

Up to now, when the `overrideTimeoutDVE` option was enabled in a *protocol.xml* file, the timeout would apply to DVE elements as well as virtual functions. From now on, this option will only apply to DVE elements.

In order to override the timeout for a virtual function, you will now be able to specify the new *overrideTimeoutVF* option in a *Functions.xml* file.

#### DataMiner upgrade: No longer possible to perform a 10.5.x web-only upgrade on DMAs running a version older than 10.4.x [ID 41395]

<!-- MR 10.6.0 - FR 10.5.1 -->

From now on, it will no longer be allowed to perform a 10.5.x web-only upgrade on DMAs running a DataMiner version older than 10.4.x.

If you want to perform a 10.5.x web-only upgrade on a DMA running e.g. version 10.3.x, you will first have to upgrade that DMA to 10.4.0.

#### Service & Resource Management: More detailed trace data will now be returned when a quarantine conflict occurs [ID 41399]

<!-- MR 10.6.0 - FR 10.5.2 -->

The trace data that is returned when a booking is moved to quarantine will now include more detailed information.

The `QuarantineTrigger` object will now contain a `ReservationConflictType` property, which will contain one of the following reasons why bookings were moved to quarantine following a booking update:

- ConcurrencyOverflow: A resource does not have enough concurrency to support all bookings.
- CapacityOverflow: A resource does not have enough capacity to support all bookings.
- UnavailableCapability: The booking tries to book a capability that is not available on the resource.
- UnavailableTimeDependentCapability: The booking tries to book a time-dependent capability that is not available on the resource because another overlapping booking has already booked a different value.

The string representation of the trace data has also been adjusted to provide more details. This string is logged in *SLResourceManager.txt* when a request has trace data in the response as well as in the booking log file of the SRM solution.

#### SLAnalytics: Infinite parameter values will now be considered missing values [ID 41417]

<!-- MR 10.6.0 - FR 10.5.1 -->

When a parameter is set to an infinite value, SLAnalytics will now consider this infinite value as a missing value. This will prevent parameter changes of this type from disrupting analytical models.

#### SLLogCollector packages will now include the log files of the ModelHost and Copilot DxMs [ID 41464]

<!-- MR 10.6.0 - FR 10.5.1 -->

From now on, SLLogCollector packages will also include the log files of the *ModelHost* and *Copilot*\* DxMs.

*\*The Copilot feature is currently still being developed. It is not yet available for non-Skyline users*

#### DataMiner upgrade: '.dmapp' and '.dmprotocol' will now by default be added to the list of MIME types in 'C:\Skyline DataMiner\Webpages\web.config' [ID 41469]

<!-- MR 10.6.0 - FR 10.5.2 -->

During a DataMiner upgrade, the ".dmapp" and ".dmprotocol" file extensions will now by default be added to the list of MIME types in the `C:\Skyline DataMiner\Webpages\web.config` file.

#### DataMiner Object Models: Number of DomInstanceIds in SectionDefinitionErrors now limited to 100 [ID 41572]

<!-- MR 10.6.0 - FR 10.5.2 -->

When, in a `SectionDefinition`, an enum entry is removed from a `FieldDescriptor`, a check is performed to make sure that entry is not being used by a `DomInstance`. This check reads all DomInstances that use that entry and places the IDs in the error data. However, as this check verifies all existing DomInstances, this could cause memory issues in SLNet when a large number of DomInstances were using the removed enum entry.

From now on, a maximum of 100 DomInstances will be included in the error data. For example, when an enum entry is removed from a `FieldDescriptor`, and 150 DomInstances are using the entry, the error message will only contain the IDs of the first 100 DomInstances.

#### Service & Resource Management: Enhanced performance when processing history entries for booking instances and resources [ID 41842]

<!-- MR 10.6.0 - FR 10.5.3 -->

Up to now, history entries for booking instances and resources would be processed individually. From now on, they will be processed in batches of 100 entries. This will considerably enhance overall performance when processing these history entries.

#### Credentials library is now fully aware of all supported SNMPv3 authentication and encryption algorithms [ID 41923]

<!-- MR 10.6.0 - FR 10.5.4 -->
<!-- Reverted by RN 42136 and reinstated by RN 42153 -->

Up to now, the credentials library would only be aware of a subset of all SNMPv3 authentication and encryption algorithms.

Because of a number of enhancements, it will now be fully aware of all supported algorithms.

#### BPA test 'Check Deprecated MySQL DLL' renamed to 'Check Deprecated DLL Usage' [ID 42057]

<!-- MR 10.6.0 - FR 10.5.5 -->

Up to now, the BPA test named *Check Deprecated MySQL DLL* would check whether the *MySql.Data.dll* was not outdated.

Now, this BPA test has been renamed to *Check Deprecated DLL Usage*. Depending on the DataMiner version, it will checks for the following DLL files, in the specified folders:

| Deprecated DLL | Deprecated since DataMiner version | Minimum safe DLL version | Folder |
|----------------|------------------------------------|--------------------------|--------|
| MySql.Data.dll | 10.4.6/10.5.0<!--RN 39370--> | 8.0.0.0 | `C:\Skyline DataMiner\ProtocolScripts` |
| SLDatabase.dll | 10.5.5/10.6.0<!--RN 42057--> | N/A     | `C:\Skyline DataMiner\ProtocolScripts` or `C:\Skyline DataMiner\Files` |

Any version lower than the specified minimum version will be considered outdated, as older versions are known to pose security risks.

#### Disabling an SLAnalytics feature will now clear all open alarms and suggestion events associated with that feature [ID 42096]

<!-- MR 10.6.0 - FR 10.5.4 -->

When, in DataMiner Cube, you go to *System Center > System settings > Analytics config*, and you explicitly disable one of the following SLAnalytics features, all open alarms and suggestion events associated with that feature will now automatically be cleared:

- Behavioral anomaly detection
- Pattern matching
- Proactive cap detection
- Relational anomaly detection

#### Service & Resource Management: UpdateReservationInstanceEventHasRun method will now first clone the reservation object before updating it [ID 42124]

<!-- MR 10.6.0 - FR 10.5.5 -->

Up to now, the `UpdateReservationInstanceEventHasRun` method would directly update the cached reservation object and then save it.

From now on, it will clone the reservation object in the cache, make the change, and then update the cached object.

#### STaaS: Enhanced granularity when migrating custom data to STaaS [ID 42219]

<!-- MR 10.6.0 - FR 10.5.4 -->

When you migrate data of data type *CustomData* from either Cassandra Single or Cassandra Cluster to STaaS (using e.g. the [STaaS Migration Script package](https://catalog.dataminer.services/details/46046c45-e44c-4bff-ba6e-3d0441a96f02)), you can now indicate exactly which data you want to have migrated.

For example, if you want to migrate only the SLAnalytics data, you can now specify the *CustomData* data type as well as the *Analytics* data type.

#### Failover: NATS cluster state will now be visible in DataMiner Cube's Failover Status window [ID 42250] [ID 43169]

<!-- MR 10.6.0 - FR 10.5.9 -->

In DataMiner Cube, the NATS cluster state will now be visible in the *Failover Status* window. This state will indicate whether NATS communication between main agent and backup agent is up and running and whether the *clusterEndpoints.json* file is synchronized between the two agents.

#### SLAnalytics - Pattern matching: Multivariate pattern suggestion events will now be grouped into a single incident [ID 42274]

<!-- MR 10.6.0 - FR 10.5.4 -->

When a multivariate pattern is detected in new trend data, suggestion events are generated for every instance in the linked pattern.

From now on, those suggestion events will be grouped into a single incident, which will be shown as a single line in the Alarm Console.

#### DataMiner Object Model: An error will now be returned when a FieldValue was added for a non-existing FieldDescriptor [ID 42358]

<!-- MR 10.6.0 - FR 10.5.5 -->

When, while a DOM instance was created or updated, a `FieldValue` was added for a non-existing `FieldDescriptor`, up to now, no error would be returned.

From now on, the trace data will indicate that a `DomInstanceError` was thrown with error reason `FieldValueUsedInDomInstanceLinksToNonExistingFieldDescriptor`.

#### Service & Resource Management: Enhanced locking mechanism in ID cache and Time range cache [ID 42463]

<!-- MR 10.6.0 - FR 10.5.6 -->

Because of a number of enhancements, the locking mechanism in the following Resource Manager caches has been improved.

| Cache | Description |
|---|---|
| ID cache | When a specific ReservationInstance is requested by ID, the result is cached in this ID cache. When an internal request is made for a specific ID, the cached ReservationInstance will be returned. Used when adding or editing ReservationInstances and when executing start/stop actions and ReservationEvents. |
| Time range cache | When ReservationInstances within a specific time range are requested, all instances in that time range will be cached in this cache. Used when new bookings are created or when eligible resources are requested. |

#### Executing Automation scripts using a Run method or a custom entry point containing the async keyword is no longer supported [ID 42534]

<!-- MR 10.6.0 - FR 10.5.6 -->

From now on, when an Automation script is executed asynchronously using either a `Run` method or a custom entry point containing the `async` keyword, an error message will appear, mentioning that this is not supported.

In that error message, users will also be directed to the [documentation](https://aka.dataminer.services/AsyncAutomation) for more information on handling async code.

#### NotifyMail.html: Updated report footer [ID 42567]

<!-- MR 10.6.0 - FR 10.5.6 -->

In the `C:\Skyline DataMiner\NotifyMail.html` file, i.e. the email report template, the report footer has been updated to `Generated by DataMiner`.

#### DxMs upgraded [ID 42688] [ID 43202] [ID 43205] [ID 43240] [ID 43298] [ID 43334] [ID 43557] [ID 43644]

<!-- RN 42688: MR 10.6.0 - FR 10.5.6 -->
<!-- RN 43202: MR 10.6.0 - FR 10.5.8 -->
<!-- RN 43205: MR 10.6.0 - FR 10.5.9 -->
<!-- RN 43240: MR 10.6.0 - FR 10.5.8 [CU0] -->
<!-- RN 43298: MR 10.5.0 [CU6] - FR 10.5.9 -->
<!-- RN 43334: MR 10.6.0 - FR 10.5.9 -->
<!-- RN 43557: MR 10.6.0 - FR 10.5.10 -->
<!-- RN 43644: MR 10.6.0 - FR 10.5.11 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner ArtifactDeployer 1.8.6
- DataMiner CoreGateway 2.14.14
- DataMiner CloudGateway 2.17.12
- DataMiner DataAggregator 3.2.0
- DataMiner FieldControl 2.11.4
- DataMiner Orchestrator 1.7.8
- DataMiner SupportAssistant 1.7.5

<!-- RN 43205 / RN 43334 -->As from now, the CloudGateway and DataAggregator DxMs will also be included in DataMiner upgrade packages. However, these DxMs will only be upgraded when an older version is found on the DataMiner Agent. If no older version is found, they will not be installed.

For detailed information about the changes included in the above-mentioned versions, refer to the [DxM release notes](xref:DxM_RNs_index).

#### SLNetClientTest tool - DataMiner Object Model: Enhancements made to the ModuleSettings window [ID 42788]

<!-- MR 10.6.0 - FR 10.5.6 -->

A number of enhancements have been made to the *ModuleSettings* window.

- When, in the *ModuleSettings* window, you delete an entire DOM module, the DOM instances in that module will now be deleted in bulk, and the maximum number of DOM instances that can be deleted in one go has been increased from 10,000 to 100,000. Also, the estimation of the cleanup time will now be more accurate, and the cleanup message will now refer to the [Removing DOM indices in Elasticsearch or OpenSearch](xref:DOM_data_storage#removing-dom-indices-in-elasticsearch-or-opensearch) section in docs.dataminer.services.

- When, in the *ModuleSettings* window, you click *Open* to see the details of a DOM module, and then go to the *Statistics* tab, it is now possible to sort the statistics by a particular column. Also, a number of enhancements have been made to have the data on the tab displayed more clearly.

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Service & Resource Management: Enhanced retrieval of service definitions [ID 42810]

<!-- MR 10.6.0 - FR 10.5.7 -->

Because of a number of enhancements, overall performance has increased when retrieving service definitions.

Also, SLNet and SLDataGateway will now exchange data faster thanks to the use of protobuf serialization.

#### DataMiner upgrade packages will now automatically upgrade the ModelHost and Copilot DxMs [ID 42896] [ID 43182]

<!-- RN 42896: MR 10.6.0 - FR 10.5.7 -->
<!-- RN 43182: MR 10.6.0 - FR 10.5.8 -->

From now on, when a DataMiner upgrade is performed on a system containing a ModelHost and/or a Copilot DxM, these modules will automatically be upgraded if the version in the upgrade package is newer than the installed version.

#### SLNet will now pass updated company information to client applications [ID 43168]

<!-- MR 10.6.0 - FR 10.5.8 -->

By default, SLNet will now pass the following updated company information to client applications:

- Company website: <https://www.skyline.be>
- TechSupport web page: [Contacting DataMiner Support](https://aka.dataminer.services/contacting-tech-support)
- TechSupport email address: <support@dataminer.services>

#### OpenSearch: auto_expand_replicas with minimum 0 and maximum 2 [ID 43179]

<!-- MR 10.6.0 - FR 10.5.9 -->

In OpenSearch, indexing will now use the `auto_expand_replicas` setting.

If the database consists of a single node at the time of index creation, an index will be made that has no replicas (minimum number of replicas is set to 0). If, at a later stage, nodes are then added to or removed from the cluster, replicas will automatically be assigned up to a maximum of 2 (maximum number of replicas is set to 2).

#### Service & Resource Management: Enhanced performance when creating or editing bookings [ID 43254]

<!-- MR 10.6.0 - FR 10.5.9 -->

Because of a number of enhancements, overall performance has increased when creating or editing bookings, especially on systems with a large number of resources.

#### Proactive cap detection: Enhanced detection of predicted data range breaches [ID 43338]

<!-- MR 10.6.0 - FR 10.5.9 -->

The decision when to trigger a proactive detection suggestion event for a future data range breach (e.g. predicted 100% between ... and ...) has been fine-tuned. This will prevent suggestion events from being generated for parameters with values near or on the data range that should not be considered problematic.

#### APIGateway: Kernel response buffering will now be enabled by default [ID 43346]

<!-- MR 10.6.0 - FR 10.5.10 -->

In the APIGateway settings, the `EnableKernelResponseBuffering` setting will now be enabled by default.

If you wish to disable it, do the following:

1. In the `C:\Program Files\Skyline Communications\DataMiner APIGateway\` folder of the DataMiner Agent, create a JSON file named *appsettings.custom.json*.
1. Open this JSON file, and add the following content:

   ```json
   { "HostingOptions": { "EnableKernelResponseBuffering": false } }
   ```

#### Migration from ElasticSearch to OpenSearch: is_write_index flag of the aliases will no longer be reset [ID 43369]

<!-- MR 10.6.0 - FR 10.5.9 -->

When migrating data from Elasticsearch to OpenSearch, at some point, the *ReIndexElasticSearchIndexes* tool needs to be used to re-index the data.

This tool has now been adapted to make sure the `is_write_index` flag of the aliases is not reset during the migration process.

#### Trend predictions with prediction intervals spanning the full data range will no longer be shown [ID 43399]

<!-- MR 10.6.0 - FR 10.5.9 -->

From now on, trend predictions with prediction intervals spanning the full data range (i.e. based on `RangeLow` and `RangeHigh`) will no longer be shown.

Such intervals indicate highly unpredictable data behavior, offering little to no meaningful forecasting value.

#### DataMiner Object Models: Updating the display value of an enum is now allowed [ID 43452]

<!-- MR 10.6.0 - FR 10.5.9 -->

Up to now, it was not possible to change the display name of an enum entry when the enum was being used by a DOM instance, despite it having no effect on the underlying enum value or DOM behavior.

This limitation has now been removed. From now on, it will be allowed to update the display name of an enum entry, even if the enum is being used by DOM instances.

#### 'Webpages\Public' folder now synced between DataMiner Agents [ID 43458]

<!-- MR 10.6.0 - FR 10.5.10 -->

The folder `C:\Skyline DataMiner\Webpages\Public\` will now be synced between DataMiner Agents in a cluster. As a consequence, files that are installed in this folder can now also be included in the companion files of a DataMiner app package.

#### Exception when RAD (sub)group is added with anomaly threshold of 0 [ID 43459]

<!-- MR 10.6.0 - FR 10.5.9 -->

When a relational anomaly group or subgroup is added with the AddRADParameterGroupMessage or AddRADSubgroupMessage with anomaly threshold set to 0, an exception will now be thrown. Previously, the exception for this invalid configuration was silently ignored and the anomaly threshold was set to the default value of 3.0.

#### SLNet-managed NATS solution: Credentials of the local agent will now be compared against the credentials of the primary NAS node [ID 43514]

<!-- MR 10.6.0 - FR 10.5.10 -->

In the *ResetNATSCheck* timer of the SLNet-managed NATS solution, the credentials of the local agent will now be compared against the credentials of the primary NAS node. If these do not match, the NATS configuration of the local agent will be reset, and the correct credentials of the primary node will be used instead.

### Fixes

#### Mobile Visual Overview: Problem with user context [ID 42061]

<!-- MR 10.6.0 [CU0] - FR 10.5.4 -->

Up to now, when no user context was needed in mobile visual overviews, an attempt would be made to reuse server-side cards among users. However, in some cases, this could cause problems, especially when handling popups or embedded visual overviews.

To make sure the user context is always correct and that it get passed correctly to popups, from now on, mobile visual overviews will always use a separate card for each user and create a new card whenever a user requests a new visual overview in a web app.

#### Mobile Visual Overview: Child shapes would incorrectly remain clickable when hidden [ID 42090]

<!-- MR 10.6.0 [CU0] - FR 10.5.4 -->

When a parent shape with a conditional show/hide setting was hidden, up to now, the clickable regions of its hidden child shapes would incorrectly remain active. In other words, users would incorrectly be able to still click child shapes after they had been hidden.

#### Scheduler: Dashboard exported via an email action would incorrectly be displayed as plain text instead of HTML [ID 42117]

<!-- MR 10.6.0 - FR 10.5.4 -->

When, in the *Scheduler* app, a dashboard was exported via an email action, up to now, HTML-formatted text in the email body would incorrectly be sent as plain text, even when the *Plain text* option was not selected. From now on, when the *Plain text* option is not selected, the text in the email body will be marked as HTML, and will be parsed and displayed correctly.

#### SLAnalytics - Behavioral anomaly detection: Change points could incorrectly be labeled as a level shift [ID 42119]

<!-- MR 10.6.0 - FR 10.5.4 -->

When a trend graph seemed to increase or decrease, in some cases, change points could incorrectly be labeled as a level shift.

#### Credentials Library: Problem when the same group was added more than once in the UpdateLibraryCredentialMessage [ID 42248]

<!-- MR 10.6.0 - FR 10.5.7 -->

Because of an issue in SLNet, up to now, if the same group would be added more than once in the `UpdateLibraryCredentialMessage` (i.e. the SLNet message used to add or update credentials), duplicated `Group` tags would end up in the *Library.xml* file. As a result, in DataMiner Cube, the updated credential would get stuck, showing a "[modified]" tag.

#### Problem with SLAutomation when a Notify method was called shortly after an Automation script had finished [ID 42465]

<!-- MR 10.6.0 - FR 10.5.6 -->

When a Notify method was called from a thread created within an Automation script shortly after that Automation script had finished, in some cases, the SLAutomation process could stop working.

#### SLNet memory leak related to indexing logic for Cube search bar [ID 42544]

<!-- MR 10.6.0 - FR 10.5.4 [CU0] -->

In systems with many trended parameters, an SLNet memory leak could occur whenever an ElementInfoMessage was sent (e.g. when an element was restarted or edited, or when an element property was changed). This was caused by the SLNet indexing of trended parameters for the Cube search bar not being cleaned up correctly, which lead to duplicate entries being kept in the SearchManager in SLNet, consuming more and more memory.

#### ModelHost DxM would stop working when it failed to retrieve a proxy endpoint [ID 42651]

<!-- MR 10.6.0 - FR 10.5.6 -->

At startup, up to now, the ModelHost DxM would stop working when it failed to retrieve a proxy endpoint. From now on, when it fails to retrieve a proxy endpoint, it will retry until it succeeds.

#### Alarm with a source other than 'DataMiner' could incorrectly impact the alarm severity of a service [ID 42724]

<!-- MR 10.6.0 - FR 10.5.7 -->

In some cases, an alarm with a source other than "DataMiner" could incorrectly impact the alarm severity of a service, even though the alarm was already cleared or no longer had any of its service impact fields filled in.

#### Slow handling of concurrent requests to retrieve or update bookings [ID 43450]

<!-- MR 10.6.0 - FR 10.5.10 -->

When a lot of concurrent requests had to be processed by the Repository API in the background, e.g. to retrieve or update bookings, this could cause thread starvation in SLDataGateway, causing these requests to be handled much more slowly than usual.
