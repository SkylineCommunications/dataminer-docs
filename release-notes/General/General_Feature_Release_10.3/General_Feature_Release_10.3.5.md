---
uid: General_Feature_Release_10.3.5
---

# General Feature Release 10.3.5 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.5](xref:Cube_Feature_Release_10.3.5).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.3.5](xref:Web_apps_Feature_Release_10.3.5).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

## Other features

## Changes

### Enhancements

#### Alarms generated when a database goes in offload mode will now have severity 'Notice' instead of 'Critical' [ID_35749]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When a database went in offload mode, up to now, an alarm with severity *Critical* was generated. From now on, an alarm of severity *Notice* will be generated instead.

#### GQI: Raw datetime values retrieved from Elasticsearch will now be converted to UTC [ID_35784]

<!-- MR 10.4.0 - FR 10.3.5 -->

Up to now, after each step in a GQI query, raw datetime values were always converted to the time zone that was specified in the query options. From now on, raw datetime values retrieved from Elasticsearch will be converted to UTC instead. The time zone specified in the query options will now only be used when converting a raw datetime value to a display value.

> [!IMPORTANT]
> **BREAKING CHANGE**: When, in an ad hoc data source or a query operation, a datetime value is not in UTC format, an exception will now be thrown.

### Fixes

#### SLLogCollector: Problem when collecting multiple memory dumps with the 'Now and when memory increases with X Mb' option [ID_35617]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When the *SLLogCollector* tool had to collect memory dumps of multiple processes with the *Now and when memory increases with X Mb* option, it would incorrectly only collect the memory dump of the first process that reached the specified Mb limit.

From now on, it will collect at least the "now" dump for each of the selected processes.

#### SLProtocol would interpret signed numbers incorrectly [ID_35796]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

SLProtocol would interpret signed numbers incorrectly, causing parameters to display incorrect values.
