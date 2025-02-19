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

#### Disabling an SLAnalytics feature will now clear all open alarms and suggestion events associated with that feature [ID 42096]

<!-- MR 10.6.0 - FR 10.5.4 -->

When, in DataMiner Cube, you go to *System Center > System settings > Analytics config*, and you explicitly disable one of the following SLAnalytics features, all open alarms and suggestion events associated with that feature will now automatically be cleared:

- Behavioral anomaly detection
- Pattern matching
- Proactive cap detection
- Relational anomaly detection

### Fixes

#### DataMiner Object Models: No longer possible to query DOM after initializing a Cassandra Cluster migration [ID 40993]

<!-- MR 10.6.0 - FR 10.5.4 -->

After a Cassandra Cluster migration had been initialized, it would no longer be possible to query DOM.

#### Mobile Visual Overview: Problem when the same mobile visual overview was requested by multiple users of the same user group [ID 41881]

<!-- MR 10.6.0 - FR 10.5.4 -->

When multiple users of the same user group requested the same mobile visual overview, in some rare cases, a separate DataMiner Cube instance would incorrectly be created on the DataMiner Agent for each of those users, potentially causing the creation of one Cube instance to block the creation of another Cube instance.

#### Mobile Visual Overview: Problem with user context [ID 42061]

<!-- MR 10.6.0 [CU0] - FR 10.5.4 -->

Up to now, when no user context was needed in mobile visual overviews, an attempt would be made to reuse server-side cards among users. However, in some cases, this could cause problems, especially when handling popups or embedded visual overviews.

To make sure the user context is always correct and that it get passed correctly to popups, from now on, mobile visual overviews will always use a separate card for each user and create a new card whenever a user requests a new visual overview in a web app.

#### Mobile Visual Overview: Child shapes would incorrectly remain clickable when hidden [ID 42090]

<!-- MR 10.6.0 [CU0] - FR 10.5.4 -->

When a parent shape with a conditional show/hide setting was hidden, up to now, the clickable regions of its hidden child shapes would incorrectly remain active. In other words, users would incorrectly be able to still click child shapes after they had been hidden.
