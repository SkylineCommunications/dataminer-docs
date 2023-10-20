---
uid: General_Feature_Release_10.3.10
---

# General Feature Release 10.3.10

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.10](xref:Cube_Feature_Release_10.3.10).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.3.10](xref:Web_apps_Feature_Release_10.3.10).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

- [DataMiner Object Models: 'Full CRUD meta' scripts [ID_37004]](#dataminer-object-models-full-crud-meta-scripts-id_37004)
- [Support for real-time GQI row updates](#support-for-real-time-gqi-row-updates-id_37060)
- [Storage as a Service](#storage-as-a-service-staas-id_34616-id_37256-id_37257-id_37283)

## New features

#### DataMiner Object Models: 'Full CRUD meta' scripts [ID_37004]

<!-- MR 10.4.0 - FR 10.3.10 -->

Apart from **ID only** scripts, which use the `OnDomInstanceCrud` entry point method and give you access to the CRUD type and the ID of the `DomInstance` in the script, it is now also possible to configure **Full CRUD meta** scripts. These use the `OnDomInstanceCrudWithFullMeta` entry point method and give you access to the CRUD type and the full `DomInstance` object(s).

For more detailed information, see [ExecuteScriptOnDomInstanceActionSettings](xref:ExecuteScriptOnDomInstanceActionSettings).

#### Support for real-time GQI row updates [ID_37060]

<!-- MR 10.4.0 - FR 10.3.10 -->

Real-time row updates are now supported for GQI session results for specific data sources and operators. This means that, when this is supported in the client, real-time updates can be displayed for row additions, modification, or deletions.

At present, this is supported for the following GQI data sources:

- Parameter table (except partial and view tables)
- Views

It is supported for the *Select* operator, but it can also be supported for other operators if they are combined with specific data sources, for instance for a filter on a parameter table.

#### DataMiner Object Models: GenericEnumEntry objects can now be soft-deleted [ID_37121]

<!-- MR 10.4.0 - FR 10.3.10 -->
<!-- Additional fix added under WebApps/Fixes -->

It is now possible to soft-delete *GenericEnumEntry* objects.

Soft-deleting a *GenericEnumEntry* object will have the following consequences:

- The *GenericEnumEntry* will not be displayed on UI forms used to create an instance.
- The *GenericEnumEntry* will be displayed on a UI form used to update an instance of which the value is set to the soft-deleted *GenericEnumEntry* in question.
- It will not be possible to create an instance of which the value is set to the soft-deleted *GenericEnumEntry*.
- It will not be possible to update the value of an instance to the soft-deleted *GenericEnumEntry*.
- It is allowed to have instances of which the value is set to the soft-deleted *GenericEnumEntry*.

#### Storage as a Service (STaaS) [ID_34616] [ID_37256] [ID_37257] [ID_37283]

<!-- MR 10.4.0 - FR 10.3.10 -->

DataMiner now supports Storage as a Service (STaaS), a scalable and user-friendly cloud-native storage platform that provides a fully fletched alternative to on-premises databases.

For detailed information, see [Storage as a Service (STaaS)](xref:STaaS).

## Changes

### Enhancements

#### Service & Resource Management: ProfileInstances with 'IsValueCopy' set to true will be assigned a TTL of 1 year [ID_31189]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

For each ProfileInstance, an `isValueCopy` property can be set:

- When set to false, the ProfileInstance will be added to a primary index.
- When set to true, the ProfileInstance will be added to a secondary index and will be assigned a TTL of 1 year (see note below).

From now on, it will no longer be allowed to change the `IsValueCopy` property of a ProfileInstance from true to false or vice versa. If such an attempt is made, a *ProfileManagerError* will be returned in the trace data with reason *ProfileInstanceChangedType*.

Also, in DataMiner Cube, the *By value/By reference* toggle button has now been removed from the *Profiles* App. Profile instances created using Cube will now always be created *by reference*.

> [!NOTE]
> When the `isValueCopy` property of a ProfileInstance is set to true, it will only be assigned a TTL of 1 year when that ProfileInstance is stored in Elasticsearch.

#### Service & Resource Management: A series of checks will now be performed when you add or upload a functions file [ID_36732]

<!-- MR 10.4.0 - FR 10.3.10 -->

When a functions file is added or uploaded, the following checks will now be performed:

1. Can the content of the file (in XML format) be parsed?
1. Does the file contain the name of the protocol?
1. Does the protocol name in the file correspond to the protocol name in the request?
1. Does the file contain a version number?
1. Does the DataMiner System not contain a functions file with the same version for the protocol in question?

When you try to upload a functions file using DataMiner Cube, the log entry (in Cube logging) and the information event (in the Alarm Console) created when the upload fails will indicate the checks that did not return true.

#### Updated bookings now only set to Confirmed when necessary [ID_36818]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

Up to now, bookings were always set to Confirmed again when they were updated, even though this is not always necessary. As such, bookings will now only be set to Confirmed again when this is actually needed, i.e.:

- When the new status of the booking is not the same as the old status.
- When the start or end time is no longer the same.
- When the resources in the booking have changed.
- when the enhanced service profile ID has changed.

#### Service & Resource Management: Improved ResourceManager logging [ID_36989]

<!-- MR 10.4.0 - FR 10.3.10 -->

The ResourceManager logging (*SLResourceManager.txt*) has been improved to make debugging easier.

Some log entries have been rewritten to make them clearer, have been assigned another log level or have been removed entirely.

#### Improved handling of smart baseline parameter sets [ID_36997]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

The handling of smart baseline parameter sets in SLNet has improved in cases where a protocol is configured to receive a nominal value for a column parameter (using the Protocol.Params.Param.Alarm type attribute), and the column value to be set is of the "retrieved" type, as configured in the ColumnOption type of the parameter to be set (i.e. the alarm tag `<Alarm Type="absolute:2,3">` is defined for the column parameter, and the ColumnOption type of the parameter is "retrieved"). In those cases, the parameter sets are now done in sets of at most 5000 at once, which will greatly improve performance when setting smart baselines for large tables.

In addition, a write parameter is no longer needed in this scenario. Previously, if there was no write parameter, it was not possible to update the stored baseline value. Now if a write parameter is present, it will be used to set the values in case of single parameter sets.

#### DataMiner Object Models: Bulk deletion of history records when deleting a DOM instance [ID_37012]

<!-- MR 10.4.0 - FR 10.3.10 -->

Up to now, when a DOM instance was deleted, the associated HistoryChange records were removed one by one. From now on, when a DOM instance is deleted, its HistoryChange records will be deleted in bulk. This will greatly improve overall performance when deleting DOM instances, especially when they are deleted synchronously.

#### Automatic clean-up of C:\\Skyline DataMiner\\Upgrades\\Packages folder [ID_37033]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

After each DataMiner upgrade, up to now, the DataMiner upgrade package would be kept indefinitely in the `C:\Skyline DataMiner\Upgrades\Packages` folder.

From now on, after each DataMiner upgrade or DataMiner start-up, this folder will be cleaned up.

- When a DataMiner upgrade was successful, only the `progress.log` file for that particular upgrade will be kept.
- When a DataMiner upgrade failed, apart from the `progress.log` file, the [prerequisites](xref:Preparing_to_upgrade_a_DataMiner_Agent#prerequisites) will also be kept for debugging purposes.

#### Security enhancements [ID_37064] [ID_37094]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

A number of security enhancements have been made.

#### SLReset: Generation of NATS credentials will now also be logged in SLFactoryReset.txt [ID_37071]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When the factory reset tool *SLReset.exe* was run, up to now, the generation of the NATS credentials would only be logged to the console. From now on, an entry will also be added to the *SLFactoryReset.txt* log file.

#### 'No Notifications might be sent' notice will now be logged in the SLSNMPAgent.txt log file [ID_37188]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When you connected to a DataMiner Agent, up to now, the Alarm Console would often show the following notice:

`No Notifications might be sent (Email or Sms). Init Notifications: No e-mail address found to use as sender. Defaulting to notifications@example.com`

This notice will now be logged in the *SLSNMPAgent.txt* log file instead.

#### SLAnalytics: Enhanced performance when using automatic incident tracking based on properties [ID_37198]

<!-- MR 10.4.0 - FR 10.3.10 -->

Because of a number of enhancements, overall performance has increased when using automatic incident tracking based on service, view or element properties.

> [!IMPORTANT]
> For the properties that should be taken into account, the option *Update alarms on value changed* must be selected. For more information, see [Configuration of incident tracking based on properties](xref:Automatic_incident_tracking#configuration-of-incident-tracking-based-on-properties).

### Fixes

#### Cassandra Cluster: Problem when retrieving all active alarm events for an element from Elasticsearch [ID_36674]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

When, on a system with a Cassandra Cluster database, an element had more than 10000 alarm events, not all of those events would get retrieved from the Elasticsearch database. This would cause (a) SLElement to generate additional alarm events when the element was restarted and (b) alarm trees to be incorrect.

#### DataMiner upgrade failed because prerequisites check incorrectly marked Agent as failed [ID_36776]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

In some cases, it could occur that the prerequisites check that is performed at the start of a DataMiner upgrade incorrectly marked an Agent as failed, which caused the upgrade to fail.

#### Connection timed out while waiting for upgrade package upload to all DMAs [ID_36866]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

At the start of a DataMiner upgrade in a cluster, first the upload of the upgrade package cascades through the cluster: the package is uploaded to the DMA the client is connected to, then it is forwarded to the other DMAs in the cluster, and if one of these is a Failover pair, the online DMA in turn forwards the package to the offline DMA. The upload is only considered complete when the first DMA has uploaded the package and received confirmation from all other DMAs.

However, when the upload happened too slowly, it could occur that the connection timed out. Now, as long as the upgrade is progressing, the upload will not time out.

#### Issues related to NT_FILL_ARRAY_WITH_COLUMN_ONLY_UPDATES (336) notifications sent to SLDataMiner [ID_36973]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

A number of issues related to NT_FILL_ARRAY_WITH_COLUMN_ONLY_UPDATES (336) notifications sent to SLDataMiner have been resolved:

- Up to now, these notifications were only able to handle one column at a time. Now they can handle multiple columns.
- A small memory leak could occur when a NT_FILL_ARRAY_WITH_COLUMN_ONLY_UPDATES notification was sent to SLDataMiner with invalid data.
- If the user sending such a notification did not have sufficient rights on the element, or if the element was locked by another user, this did not cause this notification to fail. Now it will fail. This same issue has also been resolved for the NT_DELETE_ROW (156), NT_ADD_ROW (149), and NT_ADD_ROW_RETURN_KEY (240) notifications.

#### SLReset: Problem due to NATS being re-installed before cleaning up the 'C:\\Skyline DataMiner' folder [ID_37072]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When you perform a factory reset by running *SLReset.exe*, NATS will automatically be re-installed.

Up to now, SLReset would re-install NATS **before** it cleaned up the `C:\Skyline DataMiner` folder. As, in some cases, this could cause unexpected behavior, SLReset will now re-install NATS **after** the file clean-up.

#### Cassandra Cluster Migrator tool would incorrectly not migrate any logger tables [ID_37083]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

The Cassandra Cluster Migrator tool would incorrectly not migrate any logger tables.

#### Problem when restarting DataMiner [ID_37112]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU8] - FR 10.3.10 -->

When DataMiner was restarted, in some rare cases, it would not start up again.

#### Cassandra Cluster: Incorrect calculation of replication factors [ID_37117]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

In setups including a Cassandra Cluster database, the *NetworkTopologyStrategy* would incorrectly not be taken into account when calculating the data replication factors. Only the *SimpleStrategy* would be taken into account.

As a result, when only one node went down, DataMiner would erroneously go into data offload mode even though enough Cassandra Cluster nodes were online.

#### Problem when running queries against Elasticsearch [ID_37138]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

In some rare cases, queries run against an Elasticsearch database would get stuck, causing SLDataGateway to throw exceptions and Elasticsearch to not return any results.

#### Custom timeouts would not be passed to HandleMessage methods on a GRPCConnection/gRPC connection [ID_37166]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

When a custom timeout was passed to a `HandleMessage` method on a GRPCConnection/gRPC connection, that method would not receive the custom timeout and would therefore use the default 15-minute timeout instead.

From now on, when a custom timeout is passed to a `HandleMessage` method on a GRPCConnection/gRPC connection, that method will correctly use the custom timeout that was passed.

#### Protocols: Length parameter in a response would not be set to the correct value [ID_37172]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

In some cases, the length parameter in a response would not be set to the the correct value.

#### Service & Resource Management: Booking status would be set to 'Ended' too soon [ID_37176]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

In some cases, events scheduled to run at the end of a booking would not be run because the status of the booking was set to "Ended" too soon.

From now on, the status of a booking will only be set to "Ended" once all events have been run.

#### SLAnalytics: Problem when creating or editing a multivariate pattern [ID_37212]

<!-- MR 10.4.0 - FR 10.3.10 -->

When you created or edited a linked pattern with subpatterns from elements on different agents, and the first subpattern was from an element on an agent other than the one from which the CreateLinkedPatternMessage or EditLinkedPatternMessage was originally sent, SLNet would throw an exception.

#### Problem when importing an existing element [ID_37214]

<!-- MR 10.4.0 - FR 10.3.10 -->

When you imported an element that already existed in the system, in some cases, an error could occur in SLDataMiner.

#### SLAnalytics: Problem when deleting trend pattern while connected to a DMA running an old DataMiner version [ID_37225]

<!-- MR 10.4.0 - FR 10.3.10 -->

When you deleted a trend pattern when connected to a DataMiner Agent running an old DataMiner version (e.g. 10.3.0), the pattern itself was deleted but the occurrences/matches would remain visible until you closed the trend graph and opened it again.

#### Problem when updating the NATS server [ID_37305]

<!-- 10.2.0 [CU19]/MR 10.3.0 [CU7] - FR 10.3.10 [CU0] -->

In some cases, when updating the NATS server, an error could occur while replacing the *nats-streaming-server.exe* file.
