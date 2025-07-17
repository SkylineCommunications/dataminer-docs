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

- Stop and restart one of the Failover Agents.

- Send your [*Log Collector* packages](xref:SLLogCollector) to [support.data-core](mailto:support.data-core@skyline.be), including SLNet memory dumps for both machines.

## Fix

Install DataMiner 10.3.0 [CU11], 10.4.0, or 10.4.2<!--RN 38349-->.

## Description

After upgrading a DataMiner System with a Failover pair to DataMiner 10.3.0 [CU9]/10.3.12 or higher, the Failover Agents remain offline.

In *SLFailover.txt*, there are errors mentioning that all heartbeat paths have failed. For example:

```txt
2023/12/22 14:49:56.886|SLNet.exe|UpdateFailoverSwitchStatus|CRU|0|67|Failover Status => Offline
2023/12/22 14:49:56.886|SLNet.exe|UpdateFailoverSwitchStatus|CRU|0|67|Failover Status => Preparing to go online
2023/12/22 14:49:56.887|SLNet.exe|ForceOtherAgentsToOffline|INF|0|67|Notifying buddy agent to go offline (dma-srv-01-m (172.18.206.131) wants to go online) ...
2023/12/22 14:49:56.887|SLNet.exe|ForceOtherAgentsToOffline|INF|0|67|Trying to notify other agent to go offline via one of 172.18.206.132 (agent appears to be missing)
2023/12/22 14:54:56.834|SLNet.exe|ForceOtherAgentsToOffline|INF|0|67|Failed setting state for '172.18.206.132' to Offline: 172.18.206.132 ignored request: All heartbeat paths are failing. Preventing ping-pong.
```

> [!NOTE]
> The Failover pair is affected only if this error appears for both the main and the backup servers.
