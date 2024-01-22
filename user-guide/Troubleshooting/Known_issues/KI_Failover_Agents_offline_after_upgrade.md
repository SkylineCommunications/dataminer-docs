---
uid: KI_Failover_Agents_offline_after_upgrade
---

# Failover Agents remain offline after upgrade

## Affected versions

From DataMiner 10.3.0 [CU9]/10.3.12 onwards.

## Cause

A race condition in NatsCustodian may trigger Failover Agents to remain offline after an upgrade, reboot, or restart.

When the Failover pair attempts to come online, both DataMiner Agents continuously request Failover information from each other. This may lead to a limitation of 10 blocking calls per connection being reached, causing the System to become blocked until one of the Agents is stopped.

## Workaround

- Stop one of the Failover Agents.

- Send your [*Log Collector* packages](xref:SLLogCollector) to [support.data-core](mailto:support.data-core@skyline.be), including SLNet memory dumps for both machines.

## Fix

No fix is available yet.

## Description

After upgrading a DataMiner System with a Failover pair to DataMiner 10.3.0 [CU9]/10.3.12 or higher, the Failover Agents remain offline.

The *SLFailover.txt* logging (*C:\Skyline DataMiner\SLFailover.txt*) contains a mention that all heartbeat paths have failed.
