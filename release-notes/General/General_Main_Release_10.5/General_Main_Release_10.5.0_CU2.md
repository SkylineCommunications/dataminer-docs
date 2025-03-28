---
uid: General_Main_Release_10.5.0_CU2
---

# General Main Release 10.5.0 CU2 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU2](xref:Cube_Main_Release_10.5.0_CU2).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU2](xref:Web_apps_Main_Release_10.5.0_CU2).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SNMP forwarding: New option to prevent an SNMP manager from resending SNMP Inform messages [ID 41884]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

Up to now, when you stopped and restarted an SNMP manager, all open alarms would be resent. From now on, when you configure an SNMP manager, you will be able to prevent this by selecting the *Enable tracking to avoid duplicate Inform Acknowledgments (ACKs)* option. If you select this option, DataMiner will track which Inform messages have been sent, and will not resend those that have already been acknowledged.

> [!NOTE]
> This new *Enable tracking to avoid duplicate Inform Acknowledgments (ACKs)* option is not selected by default and is not compatible with the existing *Resend all active alarms every:* option. It is also not compatible with the *Resend...* command, which in DataMiner Cube can be selected after right-clicking an SNMP manager in the *SNMP forwarding* section of *System Center*.

#### Security enhancements [ID 42307]

<!-- 42307: MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

A number of security enhancements have been made.

#### Reduced memory usage when updating a large number of parameter in bulk [ID 42385]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

When a large number of parameters are updated in bulk, from now on, SLProtocol will send the parameter changes to SLElement in chunks of 1000 rows. This will considerably reduce overall memory usage during serialization, especially when a large number of row are updated due to e.g. aggregation or merge actions.

#### GQI DxM will now shut down faster [ID 42428]

<!-- MR 10.5.0 [CU2] - FR 10.5.5 -->

Because of a number of enhancements, the GQI DxM will now shut down faster, especially in situations where NATS is not running.

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

#### GQI DxM will now look for missing dependencies in the Automation script libraries folder [ID 42468]

<!-- MR 10.5.0 [CU2] - FR 10.5.5 -->

GQI extensions use the Automation engine to create DLL libraries that are then loaded by GQI to add ad hoc data sources, custom operators, etc.

GQI will now look for missing dependencies in the *C:\\Skyline DataMiner\\Scripts\\Libraries* folder. This will allow GQI extension scripts to find the Automation script library at runtime.

> [!IMPORTANT]
> If the referenced Automation script library has dependencies of its own, these will also need to be added as dependencies in the GQI extension scripts.

#### GQI recording removed from GQI DxM [ID 42470]

<!-- MR 10.5.0 [CU2] - FR 10.5.5 -->

GQI recording, a debugging feature that allowed you to save GQI communication and replay it in a lab environment, has now been removed from the GQI DxM.

#### GQI DxM: Record limit of Sort operator has been increased to 100,000 records [ID 42492]

<!-- MR 10.5.0 [CU2] - FR 10.5.5 -->

When the GQI DxM is being used, the record limit of the *Sort* operator will now be 100,000 instead of 10,000.

#### SLNetClientTest - DataMiner Object Model: Enabling debug logging [ID 42504]

<!-- MR 10.5.0 [CU2] - FR 10.5.5 -->

In the *DataMiner Object Model* window, which allows you to see all details of a particular DOM module, a new *Debug Logging* section has now been added to the *Maintenance* tab. In this section, you can find the following buttons:

| Button | Description |
|--------|-------------|
| Enable | Adds or updates an override for the log file of the current DOM manager, setting all log levels to 6. |
| Reset  | Removes the override for the log file of the current DOM manager is removed, regardless of the tool that added it. |

Also, a status label will now indicate whether debug logging is enabled or disabled.

> [!NOTE]
>
> - The above-mentioned status label will show "Enabled" when a level-6 override is present. If all log files have level 6 by default, the status label will show "Disabled" until you add an override.
> - Enabling debug logging may significantly increase the amount of logging that is written to disk.

#### GQI DxM: New life cycle method allows ad hoc data sources to optimize sort operators [ID 42528]

<!-- MR 10.5.0 [CU2] - FR 10.5.5 -->

A new optional life cycle method has been introduced for ad hoc data sources running in the GQI DxM. It will allow to optimize or modify sort operators added to the query.

You can use this life cycle by implementing the `Skyline.DataMiner.Analytics.GenericInterface.IGQIOptimizeableDataSource` interface, which has one method:

```csharp
IGQIQueryNode Optimize(IGQIDataSourceNode currentNode, IGQICoreOperator nextOperator)
```

- `currentNode` is the query node that represents the current ad hoc data source.
- `nextOperator` represents the next operator appended to the query.

This method should return the query node that represents the result of applying the next operator to the current ad hoc data source node. Similar to the custom operator implementation, the ad hoc data source implementation can decide to do the following:

- Append the `nextOperator` to the `currentNode` (i.e. the default behavior when this life cycle method is not implemented).
- Remove/ignore the `nextOperator`, usually taking responsibility of the operation internally.
- Modify/add operators.

> [!NOTE]
>
> - This life cycle method will only be called when the `nextOperator` is a filter or a sort operator.
> - This life cycle method can be called multiple times if there is a new `nextOperator`.

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

As DataMiner IDP no longer requires nor a separate license nor an Indexing Engine, from now on, this notice will no longer appear.

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

#### GQI DxM: Ad hoc data source or custom operators would not receive SLNet events when using subscription sets [ID 42454]

<!-- MR 10.5.0 [CU2] - FR 10.5.5 -->

When the GQI DxM was being used, ad hoc data sources and custom operators would not receive any SLNet events if they added or updated a subscription for a specific subscription set.

#### Problem when creating the ClusterEndpoints.json file [ID 42481]

<!-- MR 10.5.0 [CU2] - FR 10.5.5 -->

In some cases, an error could be thrown when the *ClusterEndpoints.json* file was created in the *C:\\Skyline DataMiner\\Configurations\\* folder.

#### DVE settings could get out of sync with the element data when DataMiner or an element was restarted [ID 42515]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

When DataMiner or an element was stopped while there were still DVE parameter sets in the queue, up to now, the DVE settings would be out of sync with the element data when DataMiner or the element was restarted. From now on, the DVE settings will be re-applied in the element data.

> [!NOTE]
> Always make sure element names are unique, especially when using the `noelementprefix` option.

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

#### GQI DxM would leak memory when an SLNet connection was disconnected [ID 42592]

<!-- MR 10.5.0 [CU2] - FR 10.5.5 -->

When an SLNet connection created by the GQI DxM was disconnected, up to now, the associated compatibility manager would not be cleaned up correctly, causing the GQI DxM to leak memory.

#### Information events would incorrectly not get flushed to the database when an element was stopped [ID 42604]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

When an element was stopped, contrary to alarm events, information events would incorrectly not get flushed to the database.

On systems with Swarming enabled, this could cause problems when a hosting agent tried to retrieve the highest alarm ID from the database.
