---
uid: KI_CheckClusterSLNetConnections_unsigned
---

# Check Cluster SLNet Connections BPA test does not have valid signature

## Affected versions

- DataMiner 10.3.0 [CU10]
- DataMiner 10.4.1 [CU0]

## Cause

An unsigned version of the Check Cluster SLNetConnections BPA was included in the release.

## Fix

Upgrade to DataMiner 10.3.0 [CU11] or DataMiner 10.4.2.

## Issue description

When you run the Check Cluster SLNetConnections BPA test, it fails with the message "Exception: BPA doesn't have valid signature".
