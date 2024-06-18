---
uid: General_Main_Release_10.3.0_CU17
---

# General Main Release 10.3.0 CU17 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### 'Security Advisory' BPA test will no longer report an issue when NATS does not have TLS enabled on a single DMA [ID_39792]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When the [Security Advisory](xref:BPA_Security_Advisory) BPA test was run on a single DataMiner Agent of which firewall port 4222 and 6222 were closed, up to now, it would report an issue saying that NATS did not have TLS enabled.

As NATS does not need TLS enabled on single DataMiner Agents, from now on, the [Security Advisory](xref:BPA_Security_Advisory) BPA test will only report an issue regarding NATS TLS when, on a single DataMiner Agent, firewall ports 4222 and 6222 are open.

#### 'Security Advisory' BPA test: Enhanced testing of HTTP and HTTPS connections [ID_39813]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

A number of enhancements have been made to the [Security Advisory](xref:BPA_Security_Advisory) BPA test with regard to the testing of HTTP and HTTPS connections.

#### 'Security Advisory' BPA test will now take into account that the SNMP agent port can be a custom port [ID_39852]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When performing the firewall port test, the [Security Advisory](xref:BPA_Security_Advisory) BPA test will now take into account that the SNMP agent port can be a custom port.

### Fixes

#### Failover configuration would incorrectly be ended when SLNet failed to parse DMS.xml [ID_39157]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When, on an offline Failover agent, SLNet failed to parse the *DMS.xml* file, up to now, the Failover setup would be ended.

From now on, when SLNet fails to parse the *DMS.xml* file on an offline Failover agent, it will use the last-known Failover configuration it has stored in memory.

#### Problem with SLLog while iterating over the log file buffers [ID_39321]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

SLLog has a thread that iterates over the different log file buffers and that copies a number of lines from the buffers to the log files. Due to a problem in this iteration mechanism, in some cases, SLLog could start to leak memory.

#### SLLogCollector: 'Access is denied' errors [ID_39364]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

In some cases, SLLogCollector would not have the required permissions to access process objects or execute certain WMI queries. As a result, `Access is denied` errors would be added to the *SLLogCollector.txt* log file.

#### Service & Resource Management: SLNet handle leak when messages were sent directly to the master agent [ID_39622]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When SRM messages were sent directly to the master agent, SLNet could experience a handle leak.

#### Problem when restarting a DMA either manually or automatically [ID_39642]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When a DataMiner Agent was restarted either manually or automatically, in some rare cases, it would not restart properly.

#### SLAutomation would leak a small amount of memory each time an Automation script was run [ID_39644]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

In some cases, SLAutomation would leak a small amount of memory each time an Automation script was run.

#### Table row discrepancy between SLElement and SLProtocol [ID_39645]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

Due to a locking issue, in some cases, SLProtocol and SLElement could end up with different sets of table rows stored in memory.

#### Services and DCF interfaces would indicate an incorrect severity when a table had multiple columns that were being monitored [ID_39650]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When a table was fully included in a service or when a table exposed a DCF interface and had multiple columns that were being monitored, up to now, the severity that would bubble up to the service or interface level would incorrectly be the severity of the value that was last modified instead of the highest severity found in the table.

#### Problem with SLProtocol while processing a FillArray request [ID_39657]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

In some cases, SLProtocol could stop working while processing a FillArray request.

#### SLNet would not process errors correctly when using FileInfoHelper [ID_39676]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When SLNet was using FileInfoHelper, in some cases, it would not process errors correctly.

#### Service & Resource Management: Booking events would be executed in incorrect order [ID_39748]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

In some cases, SLNet would execute booking events in incorrect order.

#### Problem with SLASPConnection when an email message could not be delivered [ID_39759]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

In some cases, a fatal error could occur in SLASPConnection when an email message could not be delivered.

#### Problem with SLProtocol when invalid optional parameters were defined on a response [ID_39830]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

When invalid optional parameters were defined on a response (see [optional attribute](xref:Protocol.Responses.Response.Content-optional)), SLProtocol would stop working.

#### Problem with SLElement when assigning an alarm template to an element included in a service [ID_39886]

<!-- MR 10.3.0 [CU17]/10.4.0 [CU5] - FR 10.4.8 -->

In some cases, SLElement could stop working when you assigned an alarm template to an element that was included in a service.
