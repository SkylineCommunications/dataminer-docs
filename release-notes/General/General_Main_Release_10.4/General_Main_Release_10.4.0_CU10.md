---
uid: General_Main_Release_10.4.0_CU10
---

# General Main Release 10.4.0 CU10

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.4.0 CU10](xref:Cube_Main_Release_10.4.0_CU10).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.4.0 CU10](xref:Web_apps_Main_Release_10.4.0_CU10).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

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

#### Cassandra Cluster Migrator tool: Enhancements [ID 41099]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

A number of enhancements have been made to the Cassandra Cluster Migrator tool (*SLCCMigrator.exe*):

- The initialization of a single agent has been disabled in favor of the global initialization, unless not all agents could be initialized.
- Connection details will now only be requested once, unless not all agents could not be initialized.
- The migration can now only be started when all agents have successfully been initialized.

#### Web apps - Visual Overview: Multiple log levels [ID 41200]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

Up to now, all log entries regarding visual overviews shown in web apps would have a log level equal to 5.

From now on, these log entries will be assigned a log level that indicates their importance.

#### Service & Resource Management: Enhanced deletion of ReservationInstances in bulk [ID 41236]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 -->

When ReservationInstances were deleted in bulk, up to now, an individual delete request would be sent to the database for every instance.

From now on, when ReservationInstances are deleted in bulk, a single delete request will be sent to the database for every batch of 200 ReservationInstances.

This will significantly enhance overall performance when deleting large numbers of ReservationInstances.

#### gRPC connection reliability has been enhanced [ID 41261]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 -->

Up to now, in some cases, a gRPC call between two SLNet instances could get blocked indefinitely, causing runtime errors to occur in other processes.

GrpcConnection has now been updated. All gRPC calls will now have a deadline of 15 minutes instead of NO_TIMEOUT.

Also, a new SLNet option `HttpTcpKeepAliveInterval` can now be configured on DataMiner Agents that are known to have unstable network connectivity. See the example below.

```xml
<MaintenanceSettings>
    <SLNet>
        <HttpTcpKeepAliveInterval>60</HttpTcpKeepAliveInterval>
    </SLNet>
</MaintenanceSettings>
```

#### DxMs upgraded [ID 41297]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner ArtifactDeployer: version 1.8.1
- DataMiner CoreGateway: version 2.14.11
- DataMiner FieldControl: version 2.11.1
- DataMiner Orchestrator: version 1.7.1
- DataMiner SupportAssistant: version 1.7.1

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

#### SNMPv3 elements will now go into an error state when the user name is missing [ID 41312]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 -->

When an element of type SNMPv3 does not have its user name filled in, from now on, it will go into an error state and an alarm will be generated.

#### User-Defined APIs: UserDefinableApiEndpoint DxM has been updated [ID 41466]

<!-- MR 10.4.0 [CU10] - FR TBD -->

The UserDefinableApiEndpoint DxM has been upgraded to version 3.3.0. It requires .NET version 8.

#### Security enhancements [ID 41542]

<!-- 41542: MR 10.4.0 [CU10] - FR 10.5.1 [CU0] -->

A number of security enhancements have been made.

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

#### LDAP/ActiveDirectory domain users would no longer be able to log in [ID 41143]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

Since DataMiner 10.4.0 [CU4]/10.4.7, in some cases, LDAP/ActiveDirectory domain users would no longer be able to log in. When such a user tried to log in, the following entry would be added to the SLNet.txt log file:

`Authentication Step Failure: Not a DataMiner user: CONTOSA\user`

This issue would only occur on LDAP servers where `CN=CONTOSA,CN=Partitions,CN=Configuration,DC=contosa,DC=com` does not have a `nETBIOSName` attribute, for example when accessing the GlobalCatalog of a forest.

After having upgraded to a DataMiner version that contains this fix, you can do the following:

- Wait up to an hour for the next LDAP synchronization to occur, or
- Manually trigger the "Skyline DataMiner LDAP Resync" task in Windows Task Scheduler.

All users should then be able to log in again.

#### Elements with WebSocket connections: Excessive number of information events would be generated when specifying an incorrect IP address [ID 41167]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 -->

When, while adding an element, you specified an incorrect IP address in the WebSocket connection details, an excessive number of information events would be generated, each mentioning that the parameter defined in `<NotifyConnectionPIDs>` was set to "Closed".

From now on, SLPort will keep track of the parameter states that get forwarded to SLProtocol. This will make sure that only a change from "Open" to "Closed" or from "Closed" to "Open" will cause (a) a parameter state to get forwarded to SLProtocol and (b) an information event of type "set parameter" to be generated.

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

#### Files modified during an initial full synchronization could incorrectly be rechecked multiple times [ID 41368]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 -->

All files that are modified in the DataMiner System while SLDMS is performing the initial full synchronization of a newly added agent are added to a list of files to be re-checked.

Up to now, that list could incorrectly contain multiple entries for the same file, causing the file in question to be re-checked multiple times after the synchronization had finished. From now on, each modified file will only be added once.

#### Problem with 'Clean up unused' in DataMiner Cube when the user folder on the DMA contained a deprecated clientsettings.dat file [ID 41386]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 -->

When, in DataMiner Cube, you opened *System Center* and went to *Tools > Clean up unused*, no alarm filters would be loaded when the deprecated *clientsettings.dat* file was still present in your user folder on the DataMiner Agent (i.e. `C:\Skyline DataMiner\users\<UserName>`).

#### Failover: Offline Agent would not be able to synchronize with the online Agent [ID 41527]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 [CU0] -->

In a Failover setup, in some rare cases, the offline Agent would not be able to synchronize with the online Agent, and would throw an error with reason `Don't know version for remote agent [IP]`.
