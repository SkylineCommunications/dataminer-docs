---
uid: General_Main_Release_10.3.0_CU12
---

# General Main Release 10.3.0 CU12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Correlation: Alarm buckets would not get cleaned up when alarms were cleared before the end of the fixed time frame [ID_38292]

<!-- MR 10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

Up to now, when correlation alarms were cleared before the end of the fixed time frame, the alarm buckets would not get cleaned up after the actions had been executed.

From now on, when using a fixed time frame, all alarm buckets will be properly cleaned up after the actions have been executed, unless there are actions that need to be executed either when the base alarms are updated or when alarms are cleared.
