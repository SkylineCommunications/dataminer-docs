---
uid: Cube_Feature_Release_10.6.1
---

# DataMiner Cube Feature Release 10.6.1 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.4.0 [CU22] and 10.5.0 [CU10].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.1](xref:General_Feature_Release_10.6.1).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.1](xref:Web_apps_Feature_Release_10.6.1).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Trending: Double-clicking the alarm group of a multi-variate trend pattern will now open a trend graph showing all parameters involved in the multi-variate trend pattern [ID 43994]

<!-- MR 10.4.0 [CU22] / 10.5.0 [CU10] / 10.6.0 [CU0] - FR 10.6.1 -->

When, in the Alarm Console, you double-click the alarm group of a multi-variate trend pattern, from now on, a trend graph will open, showing all parameters involved in the pattern alarm group (up to a maximum of 10).

#### Alarm Console: Alarm count enhancements [ID 44011]

<!-- MR 10.4.0 [CU22] / 10.5.0 [CU10] / 10.6.0 [CU0] - FR 10.6.1 -->

Up to now, when DataMiner Cube sent an alarm count request to the DataMiner System to which it was connected, it would always send the request to each of the DataMiner Agents in that DMS. As a result, it would receive an incorrect number of alarms when the DataMiner System included a STaaS database, a Cassandra Cluster database, or an indexing engine (Elasticsearch or OpenSearch) with the *Enable indexing on alarms* option enabled.

From now on, when the DMS includes a STaaS database, a Cassandra Cluster database, or an indexing engine (Elasticsearch or OpenSearch) with the *Enable indexing on alarms* option enabled, Cube will only send alarm count requests to the DMA to which it is connected. If the DMS includes a database other than those listed above, it will still send alarm count requests to each of the DMAs in the DMS.

#### SPI log entries containing the duration of an SRM server call will now include either the number of objects or the requested object ID [ID 44014]

<!-- MR 10.4.0 [CU22] / 10.5.0 [CU10] / 10.6.0 [CU0] - FR 10.6.1 -->

From now on, SPI log entries containing the duration of an SRM server call will now include either the number of objects or the requested object ID.

#### System Center: Query executor and indexing engine settings will no longer be available when the DMS is using STaaS [ID 44018]

<!-- MR 10.4.0 [CU22] / 10.5.0 [CU10] / 10.6.0 [CU0] - FR 10.6.1 -->

When Cube is connected to a DataMiner System using STaaS:

- In the *Tools* section of *System Center*, the query executor will no longer be available.
- In the *Search & indexing* section of *System Center*, the indexing engine settings will no longer be available.

Also, when an exception is thrown when Cube tries to use the MigrationManagerHelper, an error will now be logged in the Cube logging.

### Fixes

*No fixes have been added yet.*
