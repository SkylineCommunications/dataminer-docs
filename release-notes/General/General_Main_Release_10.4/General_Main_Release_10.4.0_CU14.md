---
uid: General_Main_Release_10.4.0_CU14
---

# General Main Release 10.4.0 CU14

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.4.0 CU14](xref:Cube_Main_Release_10.4.0_CU14).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.4.0 CU14](xref:Web_apps_Main_Release_10.4.0_CU14).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SNMP forwarding: New option to prevent an SNMP manager from resending SNMP inform messages [ID 41884]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

Up to now, when you stopped and restarted an SNMP manager, all open alarms would be resent. From now on, when you configure an SNMP manager, you will be able to prevent this by selecting the *Enable tracking to avoid duplicate inform acknowledgments (ACKs)* option. If you select this option, DataMiner will track which inform messages have been sent and will not resend those that have already been acknowledged.

> [!NOTE]
> This new *Enable tracking to avoid duplicate inform acknowledgments (ACKs)* option is not selected by default and is not compatible with the existing *Resend all active alarms every:* option. It is also not compatible with the *Resend...* command, which in DataMiner Cube can be selected after right-clicking an SNMP manager in the *SNMP forwarding* section of *System Center*.

#### Security enhancements [ID 42307]

<!-- 42307: MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

A number of security enhancements have been made.

#### Reduced memory usage when updating a large number of parameters in bulk [ID 42385]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

When a large number of parameters are updated in bulk, from now on, SLProtocol will send the parameter changes to SLElement in chunks of 1000 rows. This will considerably reduce overall memory usage during serialization, especially when a large number of rows are updated due to, for example, aggregation or merge actions.

#### STaaS: An alarm will now be generated when a data type is being throttled [ID 42387]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

If your system is pushing too much load for a specific data type, that data type will be throttled. This could for example happen when you have an element that is continuously saving parameter updates.

From now on, when this happens, an alarm will be generated with information about the data type or types that are being throttled.

#### Enhanced performance when restarting HTTP elements in a timeout state [ID 42443]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

Because of a number of enhancements, overall performance has increased when restarting HTTP elements in a timeout state.

#### Protocols: HTTP status code will only be logged when debug logging level 4 is enabled [ID 42447]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

Up to now, each time you opened Stream Viewer while HTTP communication was in progress, the response code would be logged to the element log.

From now on, the response code will only be logged to the element log if debug logging level 4 is enabled (regardless of whether Stream Viewer is open).

#### SLLogCollector now collects the output of the 'dotnet --list-runtimes' command [ID 42448]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

SLLogCollector packages will now include the output of the `dotnet --list-runtimes` command.

The output will be stored in the following file:

*\\Logs\\Windows\\.NET runtimes\\cmd.exe _c dotnet --list-runtimes.txt*

#### New log viewer web page [ID 42533]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

Up to now, client applications like DataMiner Cube used the *ViewLog.asp* web page to display server-side log files. This web page has now been replaced by the *ViewLog.aspx* web page.

This new log viewer page has improved compatibility with Failover setups and better error handling for HTTPS certificates.

#### DataMiner IDP license notice will no longer appear [ID 42574]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

Since DataMiner version 10.1.0/1.0.0.8, the following notice would appear when a DataMiner Agent that was not using Indexing Engine had an IDP license but no ServiceManager license:

```txt
DataMiner IDP is licensed, but no Elasticsearch database is active on the system. Therefore, scheduled workflows are not available.
```

As DataMiner IDP no longer requires neither a separate license nor an Indexing Engine, from now on, this notice will no longer appear.

#### SLAnalytics: An anomaly alarm event will now be generated when a change point with a type that is not monitored is changed to a change point with a type that is monitored [ID 42596]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

From now on, an anomaly alarm event will be generated when a change point with a change point type for which no anomaly monitoring was configured, is updated to a change point with a change point type for which anomaly monitoring is configured.

### Fixes

#### Mobile Visual Overview: Problem when the same mobile visual overview was requested by multiple users of the same user group [ID 41881]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.4 -->

When multiple users of the same user group requested the same mobile visual overview, in some rare cases, a separate DataMiner Cube instance would incorrectly be created on the DataMiner Agent for each of those users, potentially causing the creation of one Cube instance to block the creation of another Cube instance.

#### Problem with aggregation alarms on Cassandra Cluster and STaaS [ID 42095]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

Up to now, aggregation alarms would not work as intended on DataMiner Systems using a Cassandra Cluster database or Storage as a Service (STaaS).

#### DataMiner upgrade: No progress updates when DataMiner Cube was connected to the local DataMiner Agent [ID 42114]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

When you either uploaded a DataMiner upgrade package or executed a DataMiner upgrade on a DataMiner Cube that was connected to the local DataMiner Agent via localhost, up to now, you would not get any progress updates regarding the upload or upgrade process.

#### Problem with SLElement when a DVE child element is deleted while the DVE main element is in a timeout state [ID 42137]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

In some rare cases, an error could occur in SLElement when a DVE child element was deleted while the DVE main element was in a timeout state.

#### Web visual overviews: Incorrect load balancing when users were a member of the same groups [ID 42291]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

When load balancing is implemented among DataMiner Agents in a DMS for visual overviews shown in web apps, DataMiner checks the group memberships of users to determine where to send requests to balance the load. However, when multiple connected users were a member of the same groups, updates for these users were not consistently handled by the same Agent, which could cause the load balancing to be less effective and more memory to be used.

#### Mobile Visual Overview: Problem with SLHelper when removing mobile visual overview sessions [ID 42296]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.4 [CU0] -->

When mobile visual overview sessions were removed from a DataMiner Agent, in some cases, the SLHelper process could temporarily block other requests.

#### GQI DxM: Problem when executing a query using ad hoc data sources with real-time updates enabled [ID 42310]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU1] - FR 10.5.4 -->

When a query using ad hoc data sources was executed with real-time updates enabled, up to now, the following message could incorrectly appear:

```txt
Operations that change non-concurrent collections must have exclusive access. A concurrent update was performed on this collection and corrupted its state. The collection's state is no longer correct.
```

#### SLDataGateway: Problem when some of the Cassandra nodes are marked as down [ID 42384]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

In some cases, SLDataGateway could incorrectly get stuck in a state where some of the Cassandra nodes are marked as down.

Additional polling has now been introduced that will kick in when Cassandra nodes have been marked as down for a longer period. When those nodes prove to be up and running, they will forcefully be marked as up.

#### Element card of a DVE or Virtual Function could show incorrect alarm colors [ID 42402]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

In some cases, the `ParameterChangeEvent` or `ParameterTableUpdateEventMessage` for a primary key cell would contain an invalid `InstanceAlarmlevel` or `CellBubbleUpLevel`. As a result, when you opened an element card of a DVE or a Virtual Function, the card pages would show incorrect alarm colors.

#### STaaS: Problem with logger table queries incorrectly not yielding any results [ID 42408]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

When a logger table was queried, in some cases, the query would incorrectly not yield any results due to a filter conversion issue.

#### Problem when deleting an element or service property [ID 42434]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

When an element property or a service property was deleted, in some cases, a `KeyNotFoundException` exception could be thrown, especially when one of the elements that had a value for that property was a migrated or a swarmed element.

The property would be deleted from the *PropertyConfiguration.xml* file, but not from the elements or services that had a value for the property in question.

#### 'Unable to set the destination IP' errors would be logged in SLErrors.txt when setting up an SNMPv3 connection [ID 42453]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

When an SNMPv3 connection was set up, log entries similar to the example below would be added to the *SLErrors.txt* file:

`RT_QACTIONS_SNMP_v3: Unable to set the destination IP: polling IP=::1; resolved IP=::1; or=APPLY SECURITY FAILED: EMPTY USER NAME`

#### DVE settings could get out of sync with the element data when DataMiner or an element was restarted [ID 42515]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

When DataMiner or an element was stopped while there were still DVE parameter sets in the queue, up to now, the DVE settings would be out of sync with the element data when DataMiner or the element was restarted. From now on, the DVE settings will be re-applied in the element data.

> [!NOTE]
> Always make sure element names are unique, especially when using the `noelementprefix` option.

#### Problem with Annotations module [ID 42538]

<!-- MR 10.4.0 [CU14] - FR TBD -->

In some cases, the *Annotations* module would not work correctly, especially on systems with multiple DataMiner Agents or on Failover setups.

#### Incorrect 'Detected duplicate DVE' notice would appear due to a caching issue [ID 42546]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

Due to a caching issue, in some cases, the following notice could incorrectly appear in the Alarm Console:

`Detected duplicate DVE, did not create DVE for {DVE name}`

#### Connection issue between SLSNMPManager and SLNet [ID 42547]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

When multiple SLSNMPManager processes tried to simultaneously connect to SLNet, or when an element with multiple SNMP connections tried to connect to SLNet, in some cases, the following error would be logged in the Windows log *Application*:

```txt
(SLNetCOM SLSNMPManager.exe) Failed to connect to SLNet: (Code: 0x800402CD) Skyline.DataMiner.Net.Exceptions.DataMinerCommunicationException: Connection was closed at 15:37 (There's a new connection for this module/agent.)
```

#### Information events would incorrectly not get flushed to the database when an element was stopped [ID 42604]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

When an element was stopped, contrary to alarm events, information events would incorrectly not get flushed to the database.

On systems with Swarming enabled, this could cause problems when a hosting agent tried to retrieve the highest alarm ID from the database.
