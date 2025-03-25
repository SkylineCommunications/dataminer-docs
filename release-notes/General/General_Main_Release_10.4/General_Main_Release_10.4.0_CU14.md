---
uid: General_Main_Release_10.4.0_CU14
---

# General Main Release 10.4.0 CU14 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.4.0 CU14](xref:Cube_Main_Release_10.4.0_CU14).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.4.0 CU14](xref:Web_apps_Main_Release_10.4.0_CU14).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID 42307]

<!-- 42307: MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

A number of security enhancements have been made.

#### Reduced memory usage when updating a large number of parameter in bulk [ID 42385]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

When a large number of parameters are updated in bulk, from now on, SLProtocol will send the parameter changes to SLElement in chunks of 1000 rows. This will considerably reduce overall memory usage during serialization, especially when a large number of row are updated due to e.g. aggregation or merge actions.

#### Protocols: HTTP status code will only be logged when debug logging level 4 is enabled [ID 42447]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

Up to now, each time you opened Stream Viewer while HTTP communication was in progress, the response code would be logged to the element log.

From now on, the response code will only be logged to the element log if debug logging level 4 is enabled (regardless of whether Stream Viewer is open).

#### SLLogCollector now collects the output of the 'dotnet --list-runtimes' command [ID 42448]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

SLLogCollector packages will now include the output of the `dotnet --list-runtimes` command.

The output will be stored in the following file:

*\\Logs\\Windows\\.NET runtimes\\cmd.exe _c dotnet --list-runtimes.txt*

### Fixes

#### Mobile Visual Overview: Problem when the same mobile visual overview was requested by multiple users of the same user group [ID 41881]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.4 -->

When multiple users of the same user group requested the same mobile visual overview, in some rare cases, a separate DataMiner Cube instance would incorrectly be created on the DataMiner Agent for each of those users, potentially causing the creation of one Cube instance to block the creation of another Cube instance.

#### Problem with aggregation alarms on Cassandra Cluster and STaaS [ID 42095]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

Up to now, aggregation alarms would not work as intended on DataMiner Systems using a Cassandra Cluster database or Storage as a Service (STaaS).

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

#### Connection issue between SLSNMPManager and SLNet [ID 42547]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.5 -->

When multiple SLSNMPManager processes tried to simultaneously connect to SLNet, or when an element with multiple SNMP connections tried to connect to SLNet, in some cases, the following error would be logged in the Windows log *Application*:

```txt
(SLNetCOM SLSNMPManager.exe) Failed to connect to SLNet: (Code: 0x800402CD) Skyline.DataMiner.Net.Exceptions.DataMinerCommunicationException: Connection was closed at 15:37 (There's a new connection for this module/agent.)
```
