---
uid: KI_SLElement_CPU_high_during_CC_migration
---

# Excessive SLElement CPU usage during Cassandra Cluster migration

## Affected versions

DataMiner 10.1.0/10.1.2 up to 10.2.0 [CU9]/10.3.0.

## Cause

During the live migration to a Cassandra Cluster setup, calls to SLElement are used to retrieve info on alarms that are being processed. However, such a call was done for each alarm tree, causing unnecessarily high CPU usage, especially in setups with a large number of alarm trees.

## Fix

Install DataMiner 10.2.0 [CU10]/10.3.1<!--RN 34668-->.

## Issue description

During migration to a Cassandra Cluster setup, SLElement CPU usage rises to the point where it uses one core completely. For example, in case of 8 CPU cores, it rises to a constant level of 12.5 % CPU usage.
