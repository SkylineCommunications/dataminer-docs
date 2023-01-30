---
uid: KI_SLNet_deadlock_on_startup
---

# SLNet deadlock on DMA startup

## Affected versions

- DataMiner Main Release versions from 10.1.0 onwards
- DataMiner Feature Release versions from 10.1.2 onwards

## Cause

In a DMS using a Cassandra cluster setup, when multiple DataMiner Agents are started at the same time, a deadlock can occur in the SLNet process.

## Fix

No fix is available yet.

## Workaround

Stop any DMAs that do not fully start up and start them up one by one.

## Issue description

In systems with a [Cassandra cluster](xref:Supported_system_data_storage_architectures#cassandra-cluster-setup-with-elasticsearch) setup, one or more DataMiner Agents do not fully start up.

In *SLNet.txt* or *SLHangingCalls.txt*, you can find the entry `Hanging call: Skyline.DataMiner.Net.SLDataGateway.Messages.Maintenance.DeleteMaintenanceTaskRequest`.
