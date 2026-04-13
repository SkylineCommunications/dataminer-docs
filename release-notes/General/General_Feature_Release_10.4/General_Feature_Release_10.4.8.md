---
uid: General_Feature_Release_10.4.8
---

# General Feature Release 10.4.8

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.8](xref:Cube_Feature_Release_10.4.8).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.8](xref:Web_apps_Feature_Release_10.4.8).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

#### Correlation log file will now include correlation rule statistics [ID 39301]

<!-- MR 10.5.0 - FR 10.4.8 -->

For every correlation rule that is executed, a number of statistics will now be stored in the *SLCorrelation.txt* log file on a daily basis.

Example of a log entry containing correlation rule statistics:

```txt
2024/05/28 00:00:00.011|SLNet.exe|Log|INF|0|32|CorrelationRuleActionStatistics => [Rule => My_Correlation_Rule; NumberOfTimesExecuted => 6; TotalExecutionDuration => 00:31:41.5222024; MinimumExecutionDuration => 00:01:40.0854200; MaximumExecutionDuration => 00:10:00.4677544; FirstExecutionDuration => 00:10:00.4677544; LastExecutionDuration => 00:05:00.0185738; FirstExecutionTime => 05/27/2024 20:15:03; LastExecutionTime => 05/27/2024 20:48:02;]
```

#### Service & Resource Management: New function resource setting 'SkipDcfLinks' [ID 39446]

<!-- MR 10.5.0 - FR 10.4.8 -->

When a booking starts, DCF connections are created between the function DVEs of the assigned resources. They get deleted again when the booking finishes. From now on, the `SkipDcfLinks` setting can be used to disable this start and end action.

Default value: false.

Example of a function manager *config.xml* file containing this new setting:

```xml
<ProtocolFunctionManagerConfigInfo>
  <ActiveFunctionResourcesThreshold>100</ActiveFunctionResourcesThreshold>
  <FunctionHysteresis>PT1H</FunctionHysteresis>
  <FunctionActivationTimeout>PT1M</FunctionActivationTimeout>
  <SkipDcfLinks>true</SkipDcfLinks>
</ProtocolFunctionManagerConfigInfo>
```

For more information, see [Function resource settings](xref:Function_resource_settings)

## Changes

### Enhancements

#### SLElement: Enhanced performance when processing service impact updates [ID 39003]

<!-- MR 10.4.0 [CU5] - FR 10.4.8 -->

Because of a number of enhancements, overall performance of SLElement has increased when processing service impact updates.

#### Elasticsearch/OpenSearch: Limit set on queries retrieving DOM instances will now be applied to the result set [ID 39686]

<!-- MR 10.5.0 - FR 10.4.8 -->

Up to now, when a limit was set on the result set of queries that retrieve DOM instances from an Elasticsearch or OpenSearch database, that limit would only be applied in memory, causing the entire result set to be returned. From now on, a limited result set will be returned instead. This will enhance overall performance of this type of queries.

#### DataMiner Object Models: Enhanced performance when using Equals or NotEquals operators in DOM state filters [ID 39712] [ID 40107]

<!-- MR 10.4.0 [CU5] - FR 10.4.8 [CU0] -->

Previously, when a count query of DOM instances was executed, and that query contained a filter for a particular DOM state, the GQI query would return all the DOM instances in the database and make a post-filter to count them. In case there were a lot of DOM instances in the database, the query could take a long time to resolve. A performance improvement has therefore been introduced by sending the filter by state to the database, resulting in a much faster response from the GQI query.

If you use a filter with a *contains*, *not contains*, *regex*, or *not regex* operator, a post-filter will still be used. When you filter on a DOM state field, we therefore recommend using the *equals* or *not equals* operators.

#### SLAnalytics - Behavioral anomaly detection: Enhanced detection of anomalous flatline change points [ID 39720]

<!-- MR 10.4.0 [CU5] - FR 10.4.8 -->

A number of enhancements have been made to the process that determines whether a flatline change point is considered to be anomalous or not.

#### Unhandled exceptions thrown by QActions will now be logged in SLManagedScripting.txt [ID 39779]

<!-- MR 10.5.0 - FR 10.4.8 -->

From now on, when a QAction throws an unhandled exception, an attempt will be made to log that exception in *SLManagedScripting.txt* as an error before the crash dump is created.

#### 'Security Advisory' BPA test will no longer report an issue when NATS does not have TLS enabled on a single DMA [ID 39792]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When the [Security Advisory](xref:BPA_Security_Advisory) BPA test was run on a single DataMiner Agent of which firewall port 4222 and 6222 were closed, up to now, it would report an issue saying that NATS did not have TLS enabled.

As NATS does not need TLS enabled on single DataMiner Agents, from now on, the [Security Advisory](xref:BPA_Security_Advisory) BPA test will only report an issue regarding NATS TLS when, on a single DataMiner Agent, firewall ports 4222 and 6222 are open.

#### DxMs upgraded [ID 39802] [ID 39991]

<!-- RN 39802: MR 10.5.0 - FR 10.4.8 -->
<!-- RN 39991: MR 10.4.0 [CU5] - FR 10.4.8 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner ArtifactDeployer: version 1.7.1
- DataMiner CoreGateway: version 2.14.8
- DataMiner FieldControl: version 2.10.6
- DataMiner Orchestrator: version 1.6.0
- DataMiner SupportAssistant: version 1.6.9

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

#### SLAnalytics - Behavioral anomaly detection: Enhanced trend change detection accuracy [ID 39805]

<!-- MR 10.5.0 - FR 10.4.8 -->

The trend change detection accuracy has been improved, especially after a restart of the SLAnalytics process.

#### 'Security Advisory' BPA test: Enhanced testing of HTTP and HTTPS connections [ID 39813]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

A number of enhancements have been made to the [Security Advisory](xref:BPA_Security_Advisory) BPA test with regard to the testing of HTTP and HTTPS connections.

#### 'Security Advisory' BPA test will now take into account that the SNMP agent port can be a custom port [ID 39852]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When performing the firewall port test, the [Security Advisory](xref:BPA_Security_Advisory) BPA test will now take into account that the SNMP agent port can be a custom port.

#### NATS configuration can now be reset by calling an endpoint of SLEndpointTool.dll [ID 39871]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.8 -->

From now on, the NATS configuration can be reset by calling the following endpoint in e.g., an automation script:

`SLEndpointTool.Config.NATSConfigManager.ResetNATSConfiguration()`

#### STaaS: Result set of queries against custom data types can now be limited [ID 39902]

<!-- MR 10.5.0 - FR 10.4.8 -->

From now on, when using STaaS, it is possible to limit the result set of queries against custom data types (e.g., DOM, SRM, etc.). This will enhance overall performance of this type of queries.

#### DaaS: BPA tests that cannot be run on a DaaS system will now be flagged as "Not applicable" [ID 39910]

<!-- MR 10.5.0 - FR 10.4.8 -->

On a DaaS system, BPA tests than cannot be run on a DaaS system will now be flagged as "Not applicable".

#### DataMiner upgrade: 'VerifyNoLegacyReportsDashboards' prerequisite will no longer be run on DMAs with version 10.4.0 or higher [ID 39964]

<!-- MR 10.5.0 - FR 10.4.8 -->

When you upgrade DataMiner from a version older than 10.4.0 to a version from 10.4.0 onwards, the *VerifyNoLegacyReportsDashboards* prerequisite verifies that no legacy reports and legacy dashboards still exist on your DataMiner System before upgrading, as these will no longer work after the upgrade.

Up to now, this prerequisite would also be run on DMAs with version 10.4.0 or higher. From now on, this will no longer be the case.

See also: [Verify No Legacy Reports Dashboards](xref:Verify_No_Legacy_Reports_Dashboards)

#### SLASPConnection is now a 64-bit process [ID 39978]

<!-- MR 10.4.0 [CU7] - FR 10.4.8 -->

*SLASPConnection.exe* is now a 64-bit process.

This will prevent out of memory exceptions from being thrown, especially on larger DataMiner Systems.

#### DataMiner backup: 'RemoteServices' folder by default added to backup packages that contain services [ID 39993]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

From now on, the `C:\Skyline DataMiner\RemoteServices` folder will by default be added to all backup packages that contain services.

#### Storage as a Service: Enhanced storage of non-indexed logger tables [ID 40066]

<!-- MR 10.4.0 [CU5] - FR 10.4.8 -->

A number of enhancements have been made with regard to the storage of non-indexed logger tables on STaaS systems.

### Fixes

#### Documents: Issues fixed [ID 39076]

<!-- MR 10.4.0 [CU5] - FR 10.4.8 -->

With regard to document management, the following issues have been fixed:

- In some cases, element documents hosted on a Failover system could incorrectly get deleted when a Failover switch occurred.
- When you renamed an element, in some cases, its documents would incorrectly no longer be linked to it.
- When you renamed a document folder with subfolders containing files, in some cases, that folder would not be synchronized correctly among the agent in the cluster.

#### Failover configuration would incorrectly be ended when SLNet failed to parse DMS.xml [ID 39157]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When, on an offline Failover agent, SLNet failed to parse the *DMS.xml* file, up to now, the Failover setup would be ended.

From now on, when SLNet fails to parse the *DMS.xml* file on an offline Failover agent, it will use the last-known Failover configuration it has stored in memory.

#### Problem with SLLog while iterating over the log file buffers [ID 39321]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

SLLog has a thread that iterates over the different log file buffers and that copies a number of lines from the buffers to the log files. Due to a problem in this iteration mechanism, in some cases, SLLog could start to leak memory.

#### SLLogCollector: 'Access is denied' errors [ID 39364]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

In some cases, SLLogCollector would not have the required permissions to access process objects or execute certain WMI queries. As a result, `Access is denied` errors would be added to the *SLLogCollector.txt* log file.

#### Problem during Profile Manager initialization [ID 39565]

<!-- MR 10.4.0 [CU5] - FR 10.4.8 -->

In some cases, an exception could be thrown while the Profile Manager was being initialized.

#### Service & Resource Management: SLNet handle leak when messages were sent directly to the master agent [ID 39622]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When SRM messages were sent directly to the master agent, SLNet could experience a handle leak.

#### Problem when restarting a DMA either manually or automatically [ID 39642]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When a DataMiner Agent was restarted either manually or automatically, in some rare cases, it would not restart properly.

#### SLAutomation would leak a small amount of memory each time an automation script was run [ID 39644]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

In some cases, SLAutomation would leak a small amount of memory each time an automation script was run.

#### Table row discrepancy between SLElement and SLProtocol [ID 39645]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

Due to a locking issue, in some cases, SLProtocol and SLElement could end up with different sets of table rows stored in memory.

#### Services and DCF interfaces would indicate an incorrect severity when a table had multiple columns that were being monitored [ID 39650]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When a table was fully included in a service or when a table exposed a DCF interface and had multiple columns that were being monitored, up to now, the severity that would bubble up to the service or interface level would incorrectly be the severity of the value that was last modified instead of the highest severity found in the table.

#### Problem with SLProtocol while processing a FillArray request [ID 39657]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

In some cases, SLProtocol could stop working while processing a FillArray request.

#### SLNet would not process errors correctly when using FileInfoHelper [ID 39676]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When SLNet was using FileInfoHelper, in some cases, it would not process errors correctly.

#### TraceData generated during NATSCustodian startup would re-appear later linked to another thread [ID 39731]

<!-- MR 10.5.0 - FR 10.4.8 -->

In some rare cases, TraceData generated during NATSCustodian startup would re-appear later linked to another thread.

#### Service & Resource Management: Error occurring when the Service Manager fails to delete a service was incorrectly logged as 'information' instead of 'error' [ID 39738]

<!-- MR 10.5.0 - FR 10.4.8 -->

Up to now, the error thrown when the Service Manager fails to delete a service was incorrectly logged as "information" instead of "error". From now on, this error will be logged as error with log level 0.

Also, when the above-mentioned error is thrown, the *SLResourceManagerAutomation.txt* log file will no longer log "Done deleting service". Instead, it will log that an error occurred and that more information can be found in the *SLServiceManager.txt* log file.

#### Service & Resource Management: Booking events would be executed in incorrect order [ID 39748]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

In some cases, SLNet would execute booking events in incorrect order.

#### Problem with SLASPConnection when an email message could not be delivered [ID 39759]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

In some cases, a fatal error could occur in SLASPConnection when an email message could not be delivered.

#### SLAnalytics - Alarm template monitoring: Problem when processing template removals [ID 39819]

<!-- MR 10.5.0 - FR 10.4.8 -->

When all elements were removed from an alarm template, SLAnalytics would correctly remove the template from its cache. However, when that entire alarm template was removed later on, SLAnalytics would incorrectly add an incorrect version of that template to its cache.

Also, when a user created a template and then removed it without assigning elements to it, SLAnalytics would add it to its cache, but would never remove it from its cache.

#### Problem with SLProtocol when invalid optional parameters were defined on a response [ID 39830]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When invalid optional parameters were defined on a response (see [optional attribute](xref:Protocol.Responses.Response.Content-optional)), SLProtocol would stop working.

#### GQI: Problem when performing a join operation [ID 39844]

<!-- MR 10.5.0 - FR 10.4.8 -->

When a join operation was performed with two of the following data sources, in some cases, the GQI query would fail and return a `Cannot add custom table to the registry as the registry is already built.` error.

- *Get alarms*
- *Get behavioral change events*
- *Get trend data pattern events*
- *Get trend data patterns*

#### Protocols: SNMP groups with a condition could get stuck [ID 39885]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

If a protocol contained an SNMP group with a condition, and that group was first executed with the condition being false and then with the condition being true, the group could get stuck depending on how quickly the device responded.

See also: [SLProtocol RTE caused by SNMP group with condition](xref:KI_SLProtocol_RTE_SNMP_group_condition)

#### Problem with SLElement when assigning an alarm template to an element included in a service [ID 39886]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

In some cases, SLElement could stop working when you assigned an alarm template to an element that was included in a service.

#### Problem while setting up serial connections when starting an element [ID 39943]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When an element was started, up to now, its serial connections were set up too early, which would cause issues when credentials were required. From now on, serial connections will be set up after the parameters have been loaded, especially SSH connections that require credentials stored in parameters.

Also, an SSH connect request that receives a bad credentials response will no longer try to connect indefinitely. Instead, after the initial fail, it will only try as often as the configured retry attempts.

#### Problem with SLAnalytics while starting up [ID 39955]

<!-- MR 10.5.0 - FR 10.4.8 [CU0] -->

In some rare cases, while starting up, SLAnalytics appeared to leak memory and could stop working.

#### Cassandra Cluster Migrator: Problem when initializing a data migration to a Cassandra cluster [ID 39974]

<!-- MR 10.4.0 [CU5] - FR 10.4.8 -->

When initializing a data migration to a Cassandra cluster, in some cases, the Cassandra Cluster Migrator tool (*SLCCMigrator.exe*) would throw a KeyNotFoundException, causing the initialization to fail.
