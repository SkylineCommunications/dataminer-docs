---
uid: General_Feature_Release_10.4.8
---

# General Feature Release 10.4.8 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.8](xref:Cube_Feature_Release_10.4.8).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.8](xref:Web_apps_Feature_Release_10.4.8).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### Correlation log file will now include correlation rule statistics [ID_39301]

<!-- MR 10.5.0 - FR 10.4.8 -->

For every correlation rule that is executed, a number of statistics will now be stored in the *SLCorrelation.txt* log file on a daily basis.

Example of a log entry containing correlation rule statistics:

```txt
2024/05/28 00:00:00.011|SLNet.exe|Log|INF|0|32|CorrelationRuleActionStatistics => [Rule => My_Correlation_Rule; NumberOfTimesExecuted => 6; TotalExecutionDuration => 00:31:41.5222024; MinimumExecutionDuration => 00:01:40.0854200; MaximumExecutionDuration => 00:10:00.4677544; FirstExecutionDuration => 00:10:00.4677544; LastExecutionDuration => 00:05:00.0185738; FirstExecutionTime => 05/27/2024 20:15:03; LastExecutionTime => 05/27/2024 20:48:02;]
```

#### Service & Resource Management: New function resource setting 'SkipDcfLinks' [ID_39446]

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

#### SLAnalytics - Behavioral anomaly detection: Enhanced detection of anomalous flatline change points [ID_39720]

<!-- MR 10.4.0 [CU5] - FR 10.4.8 -->

A number of enhancements have been made to the process that determines whether a flatline change point is considered to be anomalous or not.

#### 'Security Advisory' BPA test will no longer report an issue when NATS does not have TLS enabled on a single DMA [ID_39792]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When the [Security Advisory](xref:BPA_Security_Advisory) BPA test was run on a single DataMiner Agent of which firewall port 4222 and 6222 were closed, up to now, it would report an issue saying that NATS did not have TLS enabled.

As NATS does not need TLS enabled on single DataMiner Agents, from now on, the [Security Advisory](xref:BPA_Security_Advisory) BPA test will only report an issue regarding NATS TLS when, on a single DataMiner Agent, firewall ports 4222 and 6222 are open.

#### DxMs upgraded [ID_39802]

<!-- RN 39802: MR 10.5.0 - FR 10.4.8 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner ArtifactDeployer: version 1.7.1
- DataMiner FieldControl: version 2.10.6
- DataMiner Orchestrator: version 1.6.0
- DataMiner SupportAssistant: version 1.6.9

For detailed information about the changes included in those versions, refer to the [dataminer.services change log](xref:DCP_change_log).

#### SLAnalytics - Behavioral anomaly detection: Enhanced trend change detection accuracy [ID_39805]

<!-- MR 10.5.0 - FR 10.4.8 -->

The trend change detection accuracy has been improved, especially after a restart of the SLAnalytics process.

#### 'Security Advisory' BPA test: Enhanced testing of HTTP and HTTPS connections [ID_39813]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

A number of enhancements have been made to the [Security Advisory](xref:BPA_Security_Advisory) BPA test with regard to the testing of HTTP and HTTPS connections.

#### 'Security Advisory' BPA test will now take into account that the SNMP agent port can be a custom port [ID_39852]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When performing the firewall port test, the [Security Advisory](xref:BPA_Security_Advisory) BPA test will now take into account that the SNMP agent port can be a custom port.

### Fixes

#### SLLogCollector: 'Access is denied' errors [ID_39364]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

In some cases, SLLogCollector would not have the required permissions to access process objects or execute certain WMI queries. As a result, `Access is denied` errors would be added to the *SLLogCollector.txt* log file.

#### Problem during Profile Manager initialization [ID_39565]

<!-- MR 10.4.0 [CU5] - FR 10.4.8 -->

In some cases, an exception could be thrown while the Profile Manager was being initialized.

#### Table row discrepancy between SLElement and SLProtocol [ID_39645]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

Due to a locking issue, in some cases, SLProtocol and SLElement could end up with different sets of table rows stored in memory.

#### Services and DCF interfaces would indicate an incorrect severity when a table had multiple columns that were being monitored [ID_39650]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When a table was fully included in a service or when a table exposed a DCF interface and had multiple columns that were being monitored, up to now, the severity that would bubble up to the service or interface level would incorrectly be the severity of the value that was last modified instead of the highest severity found in the table.

#### TraceData generated during NATSCustodian startup would re-appear later linked to another thread [ID_39731]

<!-- MR 10.5.0 - FR 10.4.8 -->

In some rare cases, TraceData generated during NATSCustodian startup would re-appear later linked to another thread.

#### Service & Resource Management: Booking events would be executed in incorrect order [ID_39748]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

In some cases, SLNet would execute booking events in incorrect order.

#### Problem with SLASPConnection when an email message could not be delivered [ID_39759]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

In some cases, a fatal error could occur in SLASPConnection when an email message could not be delivered.

#### Problem with SLProtocol when invalid optional parameters were defined on a response [ID_39830]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When invalid optional parameters were defined on a response (see [optional attribute](xref:Protocol.Responses.Response.Content-optional)), SLProtocol would stop working.

#### GQI: Problem when performing a join operation [ID_39844]

<!-- MR 10.5.0 - FR 10.4.8 -->

When a join operation was performed with two of the following data sources, in some cases, the GQI query would fail and return a `Cannot add custom table to the registry as the registry is already built.` error.

- *Get alarms*
- *Get behavioral change events*
- *Get trend data pattern events*
- *Get trend data patterns*
