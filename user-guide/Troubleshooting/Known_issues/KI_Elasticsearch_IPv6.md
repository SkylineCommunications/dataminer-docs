---
uid: KI_Elasticsearch_IPv6
---

# Data from Elasticsearch cluster with IPv6 addresses offloaded to files

## Affected versions

Any version prior to DataMiner 10.2.0 [CU11]/10.3.2 using an Elasticsearch cluster that runs on IPv6 addresses.

## Cause

Because IPV6 addresses were parsed incorrectly, DataMiner believed that the Elasticsearch cluster was down. As a result, data was offloaded to files instead of to the database.

## Fix

Install DataMiner 10.2.0 [CU11] or 10.3.2. <!-- RN 34744 -->

## Issue description

The following errors are displayed in the Alarm Console:

- `Database: "All nodes in the Indexing cluster are down."`
- `Database: "x storages are in file offload mode:"`

In the *SLCassandraHealth.txt* log file, errors such as the following can be found:

```txt
2022/10/17 00:34:11.916|SLDBConnection|ElasticConnection.UpdateHealthNodes()|INF|0|211|System.FormatException: An invalid IP address was specified.
   at System.Net.IPAddress.InternalParse(String ipString, Boolean tryParse)
   at SLSearch.Elastic.ElasticHealthMonitor.UpdateState(IHealthContext context)
```
