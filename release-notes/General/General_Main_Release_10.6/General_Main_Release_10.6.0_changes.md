---
uid: General_Main_Release_10.6.0_changes
---

# General Main Release 10.6.0 – Changes (preview)

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Changes

### Enhancements

#### DataMiner installer has been updated [ID 40409] [ID 41299]

<!-- MR 10.6.0 - FR 10.5.1 -->

The DataMiner installer has been updated.

When the configuration window appears, it will now be possible to either continue with the configuration or cancel the entire installation.

For more information on the installer, see [Installing DataMiner using the DataMiner Installer](xref:Installing_DM_using_the_DM_installer).

#### DataMiner recycle bin enhancements [ID 40565]

<!-- MR 10.6.0 - FR 10.5.5 -->

The *C:\\Skyline DataMiner\\Recycle Bin\\* folder contains backup copies of modified configuration files and folders, stored as zip files. Each zip file includes the modified file or folder along with a *Cause.txt* file, which details the reason for the change and its timestamp. These backup copies help you restore previous configurations if needed.

Up to now, a separate zip file would be created for each configuration change that had been implemented in the system.

From now on, the contents of the *C:\\Skyline DataMiner\\System Cache\\Recyclable\\* folder will be zipped and moved to the *C:\\Skyline DataMiner\\Recycle Bin\\* folder every 11 minutes. This process will first occur 3 minutes after DataMiner startup.

When a configuration change occurs, two scenarios are possible:

- If the file or folder has not been modified after the most recent move to the *Recycle Bin* folder (which happens every 11 minutes), a new entry is created in the *C:\\Skyline DataMiner\\System Cache\\Recyclable\\* folder with the name of the changed file or folder.

- If the file or folder has been modified after the most recent move to the *Recycle Bin* folder, the existing entry in the *C:\\Skyline DataMiner\\System Cache\\Recyclable\\* folder is not replaced. Instead, the *Cause.txt* file is updated with the new change description and corresponding timestamp.

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
   > From now on, there is an 11-minute period during which a modified file is not updated. This means the restored file may not reflect the most recent change.

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

Up to now, when you had made changes to a *C:\\Skyline DataMiner\\Analytics\\configuration.xml* file on the leader Agent, you had to manually replace the file on all Agents in the cluster. From now on, you can force the synchronization of this file via Cube.

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

#### DataMiner upgrade: '.dmapp' and '.dmprotocol' will now by default be added to the list of MIME types in 'C:\\Skyline DataMiner\\Webpages\\web.config' [ID 41469]

<!-- MR 10.6.0 - FR 10.5.2 -->

During a DataMiner upgrade, the ".dmapp" and ".dmprotocol" file extensions will now by default be added to the list of MIME types in the *C:\\Skyline DataMiner\\Webpages\\web.config* file.

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

Up to now, the BAP test named *Check Deprecated MySQL DLL* would check whether the *MySql.Data.dll* was not outdated.

Now, this BPA test has been renamed to *Check Deprecated DLL Usage*. Depending on the DataMiner version, it will checks for the following DLL files, in the specified folders:

| Deprecated DLL | Deprecated since DataMiner version | Minimum safe DLL version | Folder |
|----------------|------------------------------------|--------------------------|--------|
| MySql.Data.dll | 10.4.6/10.5.0<!--RN 39370--> | 8.0.0.0 | *C:\Skyline DataMiner\ProtocolScripts* |
| SLDatabase.dll | 10.5.5/10.6.0<!--RN 42057--> | N/A     | *C:\Skyline DataMiner\ProtocolScripts* or *C:\Skyline DataMiner\Files* |

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

#### SLAnalytics - Pattern matching: Multivariate pattern suggestion events will now be grouped into a single incident [ID 42274]

<!-- MR 10.6.0 - FR 10.5.4 -->

When a multivariate pattern is detected in new trend data, suggestion events are generated for every instance in the linked pattern.

From now on, those suggestion events will be grouped into a single incident, which will be shown as a single line in the Alarm Console.

#### DataMiner Object Model: An error will now be returned when a FieldValue was added for a non-existing FieldDescriptor [ID 42358]

<!-- MR 10.6.0 - FR 10.5.5 -->

When, while a DOM instance was created or updated, a `FieldValue` was added for a non-existing `FieldDescriptor`, up to now, no error would be returned.

From now on, the trace data will indicate that a `DomInstanceError` was thrown with error reason `FieldValueUsedInDomInstanceLinksToNonExistingFieldDescriptor`.

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

#### SLAnalytics: Problem when starting behavioral anomaly detection due to caching issue [ID 42422]

<!-- MR 10.6.0 - FR 10.5.5 -->

Up to now, in some cases, behavioral anomaly detection would not be able to start up correctly due to the maximum cache size having been reached when the internal caches were being fetched after SLAnalytics had been started.

From now on, if the maximum cache size is reached, old model information might get discarded to allow behavioral anomaly detection to start up correctly. If this happens, the following error will be logged:

`Max cache size reached during prefetch of the cache, potential data loss`

#### SLNet memory leak related to indexing logic for Cube search bar [ID 42544]

<!-- MR 10.6.0 - FR 10.5.4 [CU0] -->

In systems with many trended parameters, an SLNet memory leak could occur whenever an ElementInfoMessage was sent (e.g. when an element was restarted or edited, or when an element property was changed). This was caused by the SLNet indexing of trended parameters for the Cube search bar not being cleaned up correctly, which lead to duplicate entries being kept in the SearchManager in SLNet, consuming more and more memory.
