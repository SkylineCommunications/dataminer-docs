---
uid: General_Main_Release_10.2.0_CU14
---

# General Main Release 10.2.0 CU14 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner Cube: Database TTL settings will now be limited to 10 years [ID_35533]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.4 -->

From now on, DataMiner Cube will no longer accept database TTL settings that exceed 10 years.

#### Alarms generated when a database goes in offload mode will now have severity 'Notice' instead of 'Critical' [ID_35749]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When a database went in offload mode, up to now, an alarm with severity *Critical* was generated. From now on, an alarm of severity *Notice* will be generated instead.

#### Monitoring app: Elements, services and views opened by clicking a Visio shape will open in the same tab instead of a new tab [ID_35781]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

In the *Monitoring* app, from now on, elements, services and views opened by clicking a Visio shape will open in the same tab instead of a new tab.

### Fixes

#### SLLogCollector: Problem when collecting multiple memory dumps with the 'Now and when memory increases with X Mb' option [ID_35617]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When the *SLLogCollector* tool had to collect memory dumps of multiple processes with the *Now and when memory increases with X Mb* option, it would incorrectly only collect the memory dump of the first process that reached the specified Mb limit.

From now on, it will collect at least the "now" dump for each of the selected processes.

#### Dashboards app: Sticky component menus would no longer be fully visible after you had changed the number of dashboard columns [ID_35702]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.4 -->

Sticky component menus would no longer be fully visible after you had changed the number of dashboard columns.

#### SLElement could leak memory when updating alarm templates containing conditions [ID_35728]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.4 -->

In some cases, SLElement could leak memory when updating alarm templates containing conditions.

#### Memory leak in SLAnalytics [ID_35758]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU1] - FR 10.3.4 -->

In some cases, SLAnalytics kept on waiting on a database call, which eventually led to the process leaking memory.

#### SLProtocol would interpret signed numbers incorrectly [ID_35796]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

SLProtocol would interpret signed numbers incorrectly, causing parameters to display incorrect values.
