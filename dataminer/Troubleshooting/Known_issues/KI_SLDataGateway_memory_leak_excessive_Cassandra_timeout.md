---
uid: KI_SLDataGateway_memory_leak_excessive_Cassandra_timeout
---

# SLDataGateway memory leak caused by excessive Cassandra query timeout

## Affected versions

- Main Release versions from DataMiner 10.3.0 [CU6] onwards
- Feature Release versions from DataMiner 10.3.6 onwards

## Cause

The Cassandra query timeout was implemented in seconds instead of milliseconds during a code change, causing an excessively long timeout time, which can in turn cause an SLDataGateway memory leak.

This especially occurs in large systems that generate a lot of element data and trend data in a very short timespan, and especially in case of brief problems or connection issues (of at most a couple of seconds) with the Cassandra database.

## Fix

Install DataMiner 10.4.0 [CU21], 10.5.0 [CU9], or 10.5.12.<!-- RN 43912 -->

## Description

The SLDataGateway process keeps using more memory. This is usually accompanied by increasing element data or trend data queues that never decrease. The latter can be spotted by looking at the *SLDBConnection.txt* log file, which will contain the following type of log line:

```txt
Queue for Cassandra.ElementData (elementdata) has 2942328 items; increased by 1048 (Write: 558, Delete: 490) and decreased by 0
```
