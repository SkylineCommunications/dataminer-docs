---
uid: General_Main_Release_10.3.0_CU17
---

# General Main Release 10.3.0 CU17

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.3.0 CU17](xref:Cube_Main_Release_10.3.0_CU17).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.3.0 CU17](xref:Web_apps_Main_Release_10.3.0_CU17).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### 'Security Advisory' BPA test will no longer report an issue when NATS does not have TLS enabled on a single DMA [ID 39792]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When the [Security Advisory](xref:BPA_Security_Advisory) BPA test was run on a single DataMiner Agent of which firewall port 4222 and 6222 were closed, up to now, it would report an issue saying that NATS did not have TLS enabled.

As NATS does not need TLS enabled on single DataMiner Agents, from now on, the [Security Advisory](xref:BPA_Security_Advisory) BPA test will only report an issue regarding NATS TLS when, on a single DataMiner Agent, firewall ports 4222 and 6222 are open.

#### 'Security Advisory' BPA test: Enhanced testing of HTTP and HTTPS connections [ID 39813]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

A number of enhancements have been made to the [Security Advisory](xref:BPA_Security_Advisory) BPA test with regard to the testing of HTTP and HTTPS connections.

#### 'Security Advisory' BPA test will now take into account that the SNMP agent port can be a custom port [ID 39852]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When performing the firewall port test, the [Security Advisory](xref:BPA_Security_Advisory) BPA test will now take into account that the SNMP agent port can be a custom port.

#### DataMiner backup: 'RemoteServices' folder by default added to backup packages that contain services [ID 39993]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

From now on, the `C:\Skyline DataMiner\RemoteServices` folder will by default be added to all backup packages that contain services.

### Fixes

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

#### Service & Resource Management: Booking events would be executed in incorrect order [ID 39748]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

In some cases, SLNet would execute booking events in incorrect order.

#### Problem with SLASPConnection when an email message could not be delivered [ID 39759]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

In some cases, a fatal error could occur in SLASPConnection when an email message could not be delivered.

#### Problem with SLProtocol when invalid optional parameters were defined on a response [ID 39830]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When invalid optional parameters were defined on a response (see [optional attribute](xref:Protocol.Responses.Response.Content-optional)), SLProtocol would stop working.

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
