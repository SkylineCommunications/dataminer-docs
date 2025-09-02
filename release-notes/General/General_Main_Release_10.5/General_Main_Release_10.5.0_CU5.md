---
uid: General_Main_Release_10.5.0_CU5
---

# General Main Release 10.5.0 CU5

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU5](xref:Cube_Main_Release_10.5.0_CU5).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU5](xref:Web_apps_Main_Release_10.5.0_CU5).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner upgrade: All TXF files will now be removed each time a DataMiner upgrade is performed [ID 43058]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 -->

From now on, each time a DataMiner upgrade is performed, all TXF files will be automatically removed from the `C:\Skyline DataMiner\Scripts\` folder.

When you create an Automation script, apart from an XML file containing the actual script, a number of TXF files will be created. These will contain cached query information to speed up XML querying.

### Fixes

#### SLAnalytics: Problem when starting behavioral anomaly detection due to caching issue [ID 42422]

<!-- MR 10.5.0 [CU5] - FR 10.5.5 -->

Up to now, in some cases, behavioral anomaly detection would not be able to start up correctly because the maximum cache size had been reached when the internal caches were being fetched after SLAnalytics had been started.

From now on, if the maximum cache size is reached, old model information might get discarded to allow behavioral anomaly detection to start up correctly. If this happens, the following error will be logged:

`Max cache size reached during prefetch of the cache, potential data loss`

#### Problem when combining conditional monitoring templates into an alarm template group [ID 42839]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 -->

When multiple conditional alarm templates had been combined into an alarm template group, up to now, the resulting group template could fail to properly apply its conditions.

#### Error 'The object exporter specified was not found' would get logged upon DMA startup [ID 42927]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 -->

In some cases, a DataMiner Agent would not start up properly, and the following error would get logged in the *SLDataMiner.txt* log file:

`The object exporter specified was not found`

#### Problem with conditional alarm monitoring based on a condition made up of multiple AND/OR clauses [ID 42942]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 -->

When, in an alarm template, you had configured conditional monitoring based on a condition made up of multiple AND/OR clauses, up to now, some of those AND/OR clauses could incorrectly get disabled when the alarm template was refreshed in SLElement following e.g. a template update.

#### Problem with SLPort when stopping an element with a GPIB connection in an error state [ID 42949]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 -->

When you stopped an element with a GPIB connection in an error state, in some cases, the SLPort process could stop working and disappear.

#### Visual Overview in web apps: Incomplete images could be returned [ID 42968]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 -->

When a user requested a mobile visual overview, in some cases, an incomplete image could be returned.

#### Automation: Problem when trying to publish an Automation script with an invalid name via DIS [ID 42974]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 -->

When, in DataMiner Integration Studio (DIS), you tried to publish an Automation script of which the name contained leading and/or trailing spaces, up to now, the script would initially be added, but it would immediately be removed from the system. Also, the following error message would be added to the SLAutomation log file:

`Failed to load info for script 'XXX'`

From now on, when you publish an Automation script via DIS, its name will be validated. If the name is invalid, the publish action will be aborted.

#### GQI: GQI DxM and SLHelper could leak memory [ID 43028]

<!-- MR 10.5.0 [CU5] - FR 10.5.8 -->

In some cases, both GQI DxM and SLHelper could leak memory, especially when executing GQI queries with GQI extensions (i.e. ad hoc data source or custom operators) that throw exceptions from their life cycle methods.

See also: [GQI DxM - Life cycle: OnDestroy method would incorrectly be called when an error occurred in the OnInit method [ID 43186]](xref:Web_apps_Feature_Release_10.5.8#gqi-dxm---life-cycle-ondestroy-method-would-incorrectly-be-called-when-an-error-occurred-in-the-oninit-method-id-43186)

#### Protocols: Problem when polling an SNMP table using the partialSnmp option in combination with the multipleGetBulk option [ID 43034]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 -->

When both the `partialSnmp` option and the `multipleGetBulk` option were used when polling an SNMP table, up to now, too many `GetBulk` requests would be sent.

From now on, the maximum number of repetitions defined for `multipleGetBulk` will also be taken into account. For example, in case of `partialSnmp:8;multipleGetBulk:3`, the first 3 rows will be requested, then the next 3 rows will be requested, and finally the next 2 rows will be requested. A total of 8 rows will then be returned to SLProtocol. 3 plus 3 plus 2 makes 8, i.e. the value defined for `partialSnmp`.

> [!NOTE]
>
> - We recommend defining a partialSnmp row option that is equal to or a multiple of the maximum number of repetitions in order to avoid having to request a single row in the final request.
> - When both the `partialSnmp` option and the `GetNext` option were used when polling an SNMP table, up to now, this would result in an infinite loop. From now on, although combining `partialSnmp` with `GetNext` is still not supported, this will no longer cause any issues.

#### GQI: SLHelper could leak memory because SLNet connections used by GQI extensions were not properly cleaned up [ID 43065]

<!-- MR 10.5.0 [CU5] - FR 10.5.8 -->

In some cases, SLHelper could leak memory because SLNet connections used by GQI extensions were not properly cleaned up.

#### Failover: Problem when synchronizing the ClusterEndpoints.json files [ID 43079]

<!-- MR 10.5.0 [CU5] - FR 10.5.8 -->

In large DataMiner Systems, in some cases, an issue could occur when the *ClusterEndpoints.json* files were being synchronized, causing the DataMiner Agents to keep on synchronizing indefinitely.

#### Problem with masked alarms when the alarm template was removed or when the parameters were no longer monitored [ID 43098]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 -->

When an element had masked alarms, the alarm status of the parameters in question would incorrectly remain masked when the alarm template was removed from the element or when conditional alarm monitoring would cause the parameters to no longer be monitored.

#### DataMiner upgrade: VerifyClusterPorts and VerifyNatsCluster prerequisites would fail when upgrading from DataMiner 10.4.0-10.4.4 to 10.5.0 CU3, 10.5.6, or 10.5.7 [ID 43099]

<!-- MR 10.5.0 [CU5] - FR 10.5.8 -->

When you upgraded directly from DataMiner 10.4.0, 10.4.1, 10.4.2, 10.4.3 or 10.4.4 to 10.5.0 CU3, 10.5.6, or 10.5.7, the upgrade process would fail, and the following lines would be added to the update log:

```txt
DataMiner Agent: 4 error(s) and 0 notice(s)
    - Prerequisite VerifyClusterPorts.dll failed: Exception: Exception has been thrown by the target of an invocation.
    - Prerequisite VerifyNatsCluster.dll failed: Could not load file or assembly 'System.Text.Json, Version=9.0.0.1, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51' or one of its dependencies. The located assembly's manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)
    - Prerequisite VerifyNATSMigrationPrerequisites.dll failed: Exception: This BPA cannot run on 10.4.0-CU4
- One or more prerequisites failed
```

Some prerequisite checks included in the upgrade to 10.5.0 [CU3], 10.5.6, and 10.5.7 rely on a version of the `System.Text.Json` library that is not present in 10.4.0. This caused the VerifyClusterPorts and VerifyNatsCluster prerequisites to fail during the upgrade process.

#### DataMiner upgrade: Problem with incorrectly set file path in VerifyClusterPorts prerequisite [ID 43101]

<!-- MR 10.5.0 [CU5] - FR 10.5.8 [CU0] -->

Up to now, the VerifyClusterPorts prerequisite would have its file path incorrectly set to null. This would cause the system to always check the configuration file of the SLNet-managed NATS solution, even in situation where it had to check the configuration file of the BrokerGateway-managed NATS solution.

#### Problem when deleting or renaming services [ID 43109]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 -->

When a service was deleted, in some cases, it would only be fully deleted on the DataMiner Agent that hosted it.

Also, when a service was renamed, in some cases, all DataMiner Agents except the one hosting it could start to experience issues because the old service had not been properly deleted.

#### Web.config file could contain an outdated configuration [ID 43159]

<!-- MR 10.5.0 [CU5] - FR 10.5.8 -->

In some cases, the `C:\Skyline DataMiner\Webpages\API\Web.config` file could contain an outdated configuration, causing the Web Services API to not start up, and the web apps to throw the following error:

`The type initializer for 'Skyline.DataMiner.Web.Common.v1.TransportAgnosticInterface' threw an exception.`

#### Service & Resource Management: Problem while scheduling resources [ID 43295]

<!-- MR 10.5.0 [CU5] - FR 10.5.8 [CU0] -->

In DataMiner 10.5.6, improvements had been made to the Resource Manager caching, introducing throttling to reduce latency. However, under specific conditions, this throttling could cause the SRM scheduler to become unresponsive. This happened when asynchronous and synchronous booking tasks competed for limited cache access slots, exhausting the available thread pool and preventing progress.

#### No history alarms shown when data was being migrated or replicated from separate Cassandra setup to STaaS [ID 43325]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 [CU0] -->

While a DataMiner storage setup was migrated or replicated where each DMA had its own Cassandra database, no history alarms were shown.

#### SLNet memory leak and Agent disconnects caused by ClusterEndpointsManager issue [ID 43370] [ID 43384]

<!-- MR 10.5.0 [CU5] - FR 10.5.8 [CU0] -->

A problem in ClusterEndpointsManager could cause a memory leak in the SLNet process and could cause DataMiner Agents to disconnect. To prevent this, it is now possible to disable the ClusterEndpointsManager by disabling the *ClusterEndpointsManager* soft-launch option on each DataMiner Agent in the cluster. However, note that it is not possible to migrate to BrokerGateway while this option is disabled.

### Fixes in build 16243

#### SLNet memory leak caused by ClusterEndpoint.json sync [ID 43407]

<!-- MR 10.5.0 [CU4] (but also 10.5.0 [CU5] and 10.5.0 [CU6]) - FR 10.5.7 [CU1] (but also 10.5.9) -->

In large DataMiner Systems, especially in clusters with Failover Agents, an issue could occur when the *ClusterEndpoints.json* files were being synchronized, causing the DataMiner Agents to keep on synchronizing those files indefinitely. This could lead to a serious memory leak in SLNet, causing DataMiner Agents to disconnect frequently.
