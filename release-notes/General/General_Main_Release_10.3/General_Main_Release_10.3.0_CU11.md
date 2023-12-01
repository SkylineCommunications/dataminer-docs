---
uid: General_Main_Release_10.3.0_CU11
---

# General Main Release 10.3.0 CU11 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

*No enhancements have been added to this release yet.*

### Fixes

#### SLDataGateway: Problem with casing when retrieving data from Elasticsearch/OpenSearch [ID_37835]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When SLDataGateway retrieved data from Elasticsearch/OpenSearch on behalf of a DataMiner app (e.g. Ticketing), in some cases, it would pass an incorrect result set to that app due to a casing issue.

#### Service & Resource Management: Timeout script in end event of booking would not get executed when DMA was stopped within the time range of the booking [ID_37911]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When the end event of a booking used a timeout script, in some cases, that script would not get executed when the DataMiner Agent was stopped within the time range of the booking.

#### DataMiner Taskbar Utility: Problem when making SLTaskbarUtility perform an action using the command prompt [ID_37952]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When you made the DataMiner Taskbar Utility perform some action using the command prompt, the arguments would not be parsed correctly when no instance of SLTaskbarUtility was running.

#### GQI: 'Could not find PK column' error after performing a query against an empty parameter table [ID_37978]

<!-- MR 10.3.0 [CU11] - FR 10.4.1 -->

Up to now, in some rare cases, performing a GQI query against an empty parameter table would result in a `Could not find PK column` error. From now on, GQI will return an empty result set instead.
