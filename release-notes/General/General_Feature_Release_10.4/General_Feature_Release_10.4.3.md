---
uid: General_Feature_Release_10.4.3
---

# General Feature Release 10.4.3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.3](xref:Cube_Feature_Release_10.4.3).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.3](xref:Web_apps_Feature_Release_10.4.3).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### SLAnalytics - Alarm focus: Alarm occurrences will now be identified using a combination of element ID, parameter ID and primary key  [ID_38184]

<!-- MR 10.5.0 - FR 10.4.3 -->

When calculating alarm likelihood (i.e. focus score), up to now, the alarm focus feature used a combination of element ID, parameter ID and display key (if applicable) to identify previous occurrences of the same alarm. From now on, previous alarm occurrences will be identified using a combination of element ID, parameter ID and primary key.

### Fixes

#### Correlation: Alarm buckets would not get cleaned up when alarms were cleared before the end of the fixed time frame [ID_38292]

<!-- MR 10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

Up to now, when correlation alarms were cleared before the end of the fixed time frame, the alarm buckets would not get cleaned up after the actions had been executed.

From now on, when using a fixed time frame, all alarm buckets will be properly cleaned up after the actions have been executed, unless there are actions that need to be executed either when the base alarms are updated or when alarms are cleared.
