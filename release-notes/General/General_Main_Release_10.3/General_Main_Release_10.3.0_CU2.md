---
uid: General_Main_Release_10.3.0_CU2
---

# General Main Release 10.3.0 CU2 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Alarms generated when a database goes in offload mode will now have severity 'Notice' instead of 'Critical' [ID_35749]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When a database went in offload mode, up to now, an alarm with severity *Critical* was generated. From now on, an alarm of severity *Notice* will be generated instead.

#### SLAnalytics will no longer disregard first-time alarm template assignments [ID_35794]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

Up to now, SLAnalytics only took into account changes to alarm templates that were already assigned to elements and disregarded first-time alarm template assignments.

From now on, SLAnalytics will also take into account first-time alarm template assignments.

### Fixes

#### SLLogCollector: Problem when collecting multiple memory dumps with the 'Now and when memory increases with X Mb' option [ID_35617]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When the *SLLogCollector* tool had to collect memory dumps of multiple processes with the *Now and when memory increases with X Mb* option, it would incorrectly only collect the memory dump of the first process that reached the specified Mb limit.

From now on, it will collect at least the "now" dump for each of the selected processes.

#### NATS would incorrectly be re-installed when a WMI query error occurred while the NATS installer was being run at DMA startup [ID_35647]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When the NATS installer was being run at DMA startup, in some cases, due to an issue with a WMI query, NATS could incorrectly be re-installed, even though NATS and NAS were already running.

From now on, the execution of the NATS installer at DMA startup will be skipped when NATS is already running. Also, if an error occurs when running a WMI query during the execution of the NATS installer, a message saying that the re-installation has failed will be added to the *SLUMSEndpointManager.txt* log file.

> [!NOTE]
> When an error occurs while running a WMI query, and no NATS/NAS service is running, NATS will not be installed automatically. A manual installation of NATS will be needed.

#### SLElement could leak memory when updating alarm templates containing conditions [ID_35728]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.4 -->

In some cases, SLElement could leak memory when updating alarm templates containing conditions.

#### SLProtocol would interpret signed numbers incorrectly [ID_35796]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

SLProtocol would interpret signed numbers incorrectly, causing parameters to display incorrect values.
