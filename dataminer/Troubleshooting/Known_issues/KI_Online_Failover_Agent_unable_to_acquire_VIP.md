---
uid: KI_Online_Failover_Agent_unable_to_acquire_VIP
---

# Online Failover Agent unable to acquire VIP

## Affected versions

- Main release versions from DataMiner 10.3.0 [CU20]/10.4.0 [CU8] up to 10.4.0 [CU11]
- Feature release versions from DataMiner 10.4.11 up to 10.5.2.

## Cause

In certain Failover configurations, especially those with more than the usual 2 VIP addresses or multiple NICS, the online Agent may fail to acquire a VIP, getting stuck in the "Acquiring Virtual IP Address xxx.xxx.xxx.xxx" state (in FailoverStatus.txt). This makes it impossible for users to log in to the DMA.

## Fix

Install DataMiner 10.4.0 [CU12], 10.5.0 [CU0], or 10.5.3.<!--RN 42280-->

## Description

Users are unable to log in to a DMA in a Failover setup.

The SLFailover logging contains multiple instances of messages similar to the following:

```txt
2025/06/04 13:38:36.310|SLNet.exe|Legacy_DoSwitch_WaitForVIP|INF|0|33|NOT switching state: Cannot claim DataMiner Failover IP 192.168.185.4/10.0.8.89/10.0.21.120 (still reachable; not local)
```
