---
uid: General_Feature_Release_10.5.1
---

# General Feature Release 10.5.1 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.1](xref:Cube_Feature_Release_10.5.1).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.1](xref:Web_apps_Feature_Release_10.5.1).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### Retrieving additional logging from a DataMiner System [ID 40766]

<!-- MR 10.6.0 - FR 10.5.1 -->

From now on, the `GetAdditionalLoggingMessage` can be used to retrieve additional logging from a DataMiner System. It will return a `GetAdditionalLoggingResponseMessage` with the following information:

- *Log Name*: The name of the log.
- *Log Type*: The type of the log. Currently, only the log type "DxM" is supported.

Example:

```csharp
// Send a request to collect additional logging info 
var additionalLoggingMessage = new GetAdditionalLoggingMessage();
var response = engine.SendSLNetMessages(additionalLoggingMessage);
var loggingInfo = response.AdditionalLoggingInfo;
foreach (var logEntry in loggingInfo)
{
    engine.GenerateInformationEvent($"Log Name: {logEntry.Name}, Log Type: {logEntry.Type}");
}
```

Also, the existing messages `GetLogTextFileStringContentRequestMessage` and `GetLogTextFileBinaryContentRequestMessage` now have two new properties that will allow them to retrieve additional logging:

- *AdditionalLogName*: The name of the additional log to be retrieved.
- *LogType*: The type of the log. Example: `LogFileType.DxM`

Example:

```csharp
// Create a request to retrieve a specific additional log in a string format
var logRequest = new GetLogTextFileStringContentRequestMessage
{ 
    AdditionalLogName = "DataMiner UserDefinableApiEndpoint", 
    LogType = LogFileType.DxM
};
```

#### SLNet 'GetInfo' messages for the PropertyConfiguration' and 'ViewInfo' types now support retrieving information for a specific item [ID 41169]

<!-- MR 10.6.0 - FR 10.5.1 -->

SLNet `GetInfo` messages for the `PropertyConfiguration` and `ViewInfo` types now support retrieving information for a specific item. This will enhance the performance of the `Skyline.DataMiner.Core.DataMinerSystem.Common` NuGet package used in protocols or Automation scripts.

##### Type PropertyConfiguration

In the `ExtraData` property you can now specify ";type=\<propertyType\>" or ";type=\<propertyType\>;", where \<propertyType\> is either ELEMENT, SERVICE or VIEW.

If another value is specified, then all property configurations will be returned.

##### Type ViewInfo

In the `ExtraData` property you can now specify ";viewId=\<ID\>" or ";viewId=\<ID\>;", where \<ID\> is the ID of the view for which you want to retrieve more information.

#### New SLNet call GetProtocolQActionsStateRequestMessage to retrieve QAction compilation warnings and errors [ID 41218]

<!-- MR 10.6.0 - FR 10.5.1 -->

A new SLNet call `GetProtocolQActionsStateRequestMessage` can now be used to retrieve the compilation warnings and errors of a given protocol and version. The response, `GetProtocolQActionsStateResponseMessage`, will then contains all faulty QActions and their respective warnings and errors.

In future versions, this call will be used to verify whether DataMiner Swarming can be enabled on a DataMiner System.

## Changes

### Breaking changes

#### Automation: Locking behavior of Automation script actions has been enhanced [ID 41195]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 -->

A number of enhancements have been made with regard to the locking behavior of certain Automation script actions. This should significantly reduce the chances of scripts influencing each other and slowing each other down.

Breaking changes:

| <div style="width: 150px;">Actions</div> | Breaking change |
|---|---|
| Generate Information<br>Log<br>Send Notification<br>Send Report | Text that supports the `[dummy<id>]` placeholder will display the old element name if it was updated during the execution of a script or it will still display the element name even if the element was deleted in the meantime. |
| Set State | The action will fail with a different error. Previously, when an element would be removed during the execution of a script, it would state "No valid protocol mapping found". Now, it will depend on the state, but should be "Failed to change element state...". |
| Set Template | The action will fail with a different error. Previously, when an element would be removed during the execution of a script, it would state "No valid protocol mapping found". Now, it will depend on the state, but should be "Failed to set template...". |

### Enhancements

#### DataMiner installer has been updated [ID 40409] [ID 41299]

<!-- MR 10.6.0 - FR 10.5.1 -->

The DataMiner installer has been updated.

When the configuration window appears, it will now be possible to either continue with the configuration or cancel the entire installation.

For more information on the installer, see [Installing DataMiner using the DataMiner Installer](xref:Installing_DM_using_the_DM_installer).

#### Legacy correlation engine is now deprecated [ID 40834]

<!-- MR 10.6.0 - FR 10.5.1 -->

The legacy correlation engine is now deprecated. As of this version, DataMiner will no longer support legacy correlation rules.

#### Clustering compatibility check enhancements [ID 41046]

<!-- MR 10.6.0 - FR 10.5.1 -->

When, in e.g. DataMiner Cube, you try to add a DataMiner Agent to the DataMiner System, a number of checks will be performed to determine whether the new Agent is compatible to be added.

The checks with regard to database compatibility have now been enhanced.

See also: [System Center - Agents: Clustering compatibility checks will now be performed by the DMA to which Cube is connected [ID 41049]](xref:Cube_Feature_Release_10.5.1#system-center---agents-clustering-compatibility-checks-will-now-be-performed-by-the-dma-to-which-cube-is-connected-id-41049)

#### Service & Resource Management: Ongoing and queued requests sent to the old master agent will now be resent to the new master agent [ID 41089]

<!-- MR 10.5.0 - FR 10.5.1 -->

Since DataMiner feature release 10.4.11, it is possible to switch to another master agent.

Up to now, if the current master agent had been marked "not eligible to be promoted to master", it would continue to process all ongoing and queued requests as if it were still master agent. This behavior has now changed. From now on, all ongoing and queued requests sent to the current master agent that has been marked "not eligible to be promoted to master" will fail with a `NotAMasterAgentException`, and the agents that sent those messages will resend them to the new master agent.

> [!NOTE]
> Currently, property updates will still be processed by the agent that was marked "not eligible to be promoted to master" (i.e. the old master).

#### Cassandra Cluster Migrator tool: Enhancements [ID 41099]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

A number of enhancements have been made to the Cassandra Cluster Migrator tool (*SLCCMigrator.exe*):

- The initialization of a single agent has been disabled in favor of the global initialization, unless not all agents could be initialized.
- Connection details will now only be requested once, unless not all agents could not be initialized.
- The migration can now only be started when all agents have successfully been initialized.

#### Service & Resource Management: Starting bookings with elements that are not active [ID 41129]

<!-- MR 10.5.0 - FR 10.5.1 -->

It is now possible to start bookings with elements that are not active.

To do so, in the Resource Manager configuration file, set the *AllowNotActiveElements* option to true.

#### Deprecated NT Notify type 'NT_PING' can no longer be used [ID 41152]

<!-- MR 10.5.0 - FR 10.5.1 -->

From now on, the deprecated NT Notify type *NT_PING* can no longer be used.

#### Service & Resource Management: Process of starting blocking tasks has now been optimized [ID 41175]

<!-- MR 10.6.0 - FR 10.5.1 -->

Up to now, when blocking tasks with the same start time needed to be scheduled for several bookings, in some cases, bookings with limited start actions could get blocked by bookings with longer start actions.

Because of a number of enhancements, the process of starting blocking tasks has now been optimized.

#### Web apps - Visual Overview: Multiple log levels [ID 41200]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

Up to now, all log entries regarding visual overviews shown in web apps would have a log level equal to 5.

From now on, these log entries will be assigned a log level that indicates their importance.

#### Service & Resource Management: Enhanced deletion of ReservationInstances in bulk [ID 41236]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 -->

When ReservationInstances were deleted in bulk, up to now, an individual delete request would be sent to the database for every instance.

From now on, when ReservationInstances are deleted in bulk, a single delete request will be sent to the database for every batch of 200 ReservationInstances.

This will significantly enhance overall performance when deleting large numbers of ReservationInstances.

#### VerifyNatsIsRunning prerequisite will no longer fail when IgnitionValue is not found in ClusterEndpoints.json [ID 41248]

<!-- MR 10.5.0 - FR 10.5.1 -->

Up to now, the *VerifyNatsIsRunning* prerequisite would fail when it did not find `IgnitionValue` in the *C:\\Skyline DataMiner\\Configurations\\ClusterEndpoints.json* file. From now on, it will no longer check whether `IgnitionValue` is present in that file.

#### gRPC connection reliability has been enhanced [ID 41261]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 -->

Up to now, in some cases, a gRPC call between two SLNet instances could get blocked indefinitely, causing run-time errors to occur in other processes.

GrpcConnection has now been updated. All gRPC calls will now have a deadline of 15 minutes instead of NO_TIMEOUT.

Also, a new SLNet option `HttpTcpKeepAliveInterval` can now be configured on DataMiner Agents that are known to have unstable network connectivity. See the example below.

```xml
<MaintenanceSettings>
    <SLNet>
        <HttpTcpKeepAliveInterval>60</HttpTcpKeepAliveInterval>
    </SLNet>
</MaintenanceSettings>
```

#### VerifyClusterPorts: Endpoints to be tested will be retrieved from the Single Source of Truth [ID 41262]

<!-- MR 10.5.0 - FR 10.5.1 -->

The *VerifyClusterPorts* prerequisite and the *VerifyClusterPorts.dmupgrade* package will now use the Single Source of Truth (*C:\\Skyline DataMiner\\Configurations\\ClusterEndpoints.json*) to determine which endpoints should be tested.

If this JSON file cannot be found, the endpoint to be tested will be retrieved from the *DMS.xml* and *SLCloud.xml* files.

#### SLAnalytics: Synchronization of the configuration.xml file can now be forced via Cube [ID 41270]

<!-- MR 10.6.0 - FR 10.5.1 -->

Up to now, when you had made changes to a *C:\\Skyline DataMiner\\Analytics\\configuration.xml* file on the leader Agent, you had to manually replace the file on all Agents in the cluster. From now on, you can force the synchronization of this file via Cube.

See also [Synchronizing data between DataMiner Agents](xref:Synchronizing_data_between_DataMiner_Agents)

#### DxMs upgraded [ID 41297]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner ArtifactDeployer: version 1.8.1
- DataMiner CoreGateway: version 2.14.11
- DataMiner FieldControl: version 2.11.1
- DataMiner Orchestrator: version 1.7.1
- DataMiner SupportAssistant: version 1.7.1

For detailed information about the changes included in those versions, refer to the [dataminer.services change log](xref:DCP_change_log).

#### SNMPv3 elements will now go into an error state when the user name is missing [ID 41312]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 -->

When an element of type SNMPv3 does not have its user name filled in, from now on, it will go into an error state and an alarm will be generated.

#### DataMiner upgrade packages will now include the most recent version of the CloudFeed DxM [ID 41357]

<!-- MR 10.5.0 - FR 10.5.1 -->

From now on, DataMiner upgrade packages will include the most recent version of the *CloudFeed* DxM.

> [!NOTE]
> It will still be possible to install newer versions via the [dataminer.services admin app](https://admin.dataminer.services/).

#### Data Display in DataMiner Cube and the Monitoring app now support dynamic units by default [ID 41436]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

From now on, dynamic units can be used by default in Data Display, both in DataMiner Cube and the Monitoring app.

If you want this feature to be disabled system-wide, then explicitly set the *DynamicUnits* option to false in the *SoftLaunchOptions.xml* file.

### Fixes

#### Memory leaks when an element that was used in an alarm level link configuration was restarted [ID 40997]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

When an element that was used in an alarm level link configuration was restarted, in some cases, both SLElement and SLProtocol could leak memory, as would SLDataMiner when the alarm level links were pushed to locked elements.

For more information on the `<AlarmLevelLinks>` element, see [How to aggregate alarm severities](xref:How_to_aggregate_alarm_severities)

#### SLElement: Incorrect alarm linking [ID 41057]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

In some cases, new alarm events could incorrectly get linked to previously closed external events or information events on the same element.

#### SLElement would leak memory when filtering a recursive table or a directview/view table that had to be sorted [ID 41058]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

When SLElement had to process a table filter request, it would leak memory in the following cases:

- When the table had a foreign key to itself.
- When a directview or view table with a number of non-initialized columns had to be sorted.

#### SLElement would leak memory when SLNet needed to be notified of baseline changes [ID 41088]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

When a baseline changed and SLNet needed to be notified of the new values, SLElement would leak memory.

#### Failover: Problem when an element.xml file was updated while StorageModule was synchronizing its cache [ID 41133]

<!-- MR 10.5.0 [CU0] - FR 10.5.1 -->

When, in a Failover setup, SLDMS was synchronizing an updated *element.xml* file while the StorageModule DcM was synchronizing its cache to an XML file, in some rare cases, an exception could be thrown in the StorageModule DcM, causing the *element.xml* update to fail.

#### LDAP/ActiveDirectory domain users would no longer be able to log in [ID 41143]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

Since DataMiner 10.4.0 [CU4]/10.4.7, in some cases, LDAP/ActiveDirectory domain users would no longer be able to log in. When such a user tried to log in, the following entry would be added to the SLNet.txt log file:

`Authentication Step Failure: Not a DataMiner user: CONTOSA\user`

This issue would only occur on LDAP servers where `CN=CONTOSA,CN=Partitions,CN=Configuration,DC=contosa,DC=com` does not have a `nETBIOSName` attribute, for example when accessing the GlobalCatalog of a forest.

After having upgraded to a DataMiner version that contains this fix, you can do the following:

- Wait up to an hour for the next LDAP synchronization to occur, or
- Manually trigger the "Skyline DataMiner LDAP Resync" task in Windows Task Scheduler.

All users should then be able to log in again.

#### STaaS: Excessive number of duplicate entries added to the SLErrors.txt log file in case of connection problems [ID 41192]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

On STaaS systems, in case of connection problems, a large number of the following errors would be added to the *SLErrors.txt* log file:

- *The remote name could not be resolved.*
- *Unable to connect to the remote server.*

From now on, in case of connection problems, the generation of *SLErrors.txt* log file entries will be throttled in order to reduce the number of duplicate entries.

#### SLPort would leak memory when a smart-serial UDP element was stopped [ID 41216]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 -->

When a smart-serial UDP element was stopped, the client connections would incorrectly stay open, causing SLPort to leak memory.

#### Protocols: Problems when polling SNMP tables using GetNext [ID 41235]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

A number of problems that occurred when polling SNMP tables using *GetNext* have been fixed:

- When an entire SNMP table was polled using *GetNext* messages, and not all rows had values with the same syntax (e.g. 1.2.3 vs 4.5.6.7), in some cases, cells would be empty or would be shifted to another row. The SLSNMPManager process could even disappear. From now on, all table cell values will be displayed correctly.

- Up to now, an SNMP table would be polled until the returned OID result went out of scope. For example, when only 3 columns were defined in the table parameter, and the SNMP table contained 20 columns, all 20 columns would be polled, even though the data in the remaining 17 columns was not needed. From now on, as soon as the columns defined in the table parameter are polled, polling will stop and the result will be filled in.

- Up to now, only the rows with a value in the first column would be added to the table. From now on, when the table parameter has the `instance` option defined, rows of which the first column on the right of the instance column is empty will also be added to the table.

#### Conditional monitoring: Conditions of standalone parameters would incorrectly not be taken into account when the alarm template was reapplied [ID 41292]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 -->

When, in an alarm template, multiple conditions had been defined for a standalone parameter, in some cases, those conditions would incorrectly not be taken into account when the alarm template was reapplied either manually in DataMiner Cube or automatically due to baseline changes.

#### GetInfoMessage(Type.DataMinerInfo) request sent to retrieve the connection state of a disconnected agent would incorrectly return 'Normal' [ID 41338]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 -->

When a particular agent had disconnected from the rest of the agents in the DMS, a `GetInfoMessage(Type.DataMinerInfo)` request sent to another agent to retrieve the connection state of the disconnected agent would incorrectly return "Normal".

#### No longer possible to clear certain DVE alarm events [ID 41343]

<!-- MR 10.5.0 - FR 10.5.1 -->
<!-- Not added to MR 10.5.0 - Introduced by RN 39626 -->

Since DataMiner feature version 10.4.8, it would incorrectly no longer be possible to clear DVE alarm events generated by DataMiner modules like Correlation, Automation, SLAnalytics, etc.

#### Files modified during an initial full synchronization could incorrectly be rechecked multiple times [ID 41368]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 -->

All files that are modified in the DataMiner System while SLDMS is performing the initial full synchronization of a newly added agent are added to a list of files to be re-checked.

Up to now, that list could incorrectly contain multiple entries for the same file, causing the file in question to be re-checked multiple times after the synchronization had finished. From now on, each modified file will only be added once.

#### Issues when synchronizing files among agents in a DMS [ID 41382]

<!-- MR 10.5.0 - FR 10.5.1 -->

A number of issues that occurred while synchronizing files among agents in a DMS have been fixed.

#### Problem with 'Clean up unused' in DataMiner Cube when the user folder on the DMA contained a deprecated clientsettings.dat file [ID 41386]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 -->

When, in DataMiner Cube, you opened *System Center* and went to *Tools > Clean up unused*, no alarm filters would be loaded when the deprecated *clientsettings.dat* file was still present in your user folder on the DataMiner Agent (i.e. *C:\Skyline DataMiner\users\\<UserName\>*).

#### DataMiner upgrade: Folder to which the contents of the upgrade package had been extracted would not be removed [ID 41393]

<!-- MR 10.5.0 - FR 10.5.1 -->

When a DataMiner Agent had been upgraded, in some cases, the folder to which the contents of the upgrade package had been extracted would incorrectly not be removed.
