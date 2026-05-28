---
uid: KI_SLSNMPAgent_RTE_SNMP_manager_not_responding
---

# SLSNMPAgent RTEs when SNMP manager is not responding

## Affected versions

- 10.5.0 Main Release versions starting from DataMiner 10.5.0 [CU8].

## Cause

When an SNMP manager is not responding and there is a locking issue between the polling thread and the sending thread, the latter does not release the lock, causing SLSNMPAgent runtime errors (RTEs).

## Fix

No fix is available yet.<!-- RN 45586 -->

## Issue description

In setups where SNMP forwarding is used but an SNMP manager is not responding, the SLSNMPAgent process throws RTEs.

In the SLWatchdog2.txt log file, this results in errors similar to the following:

```txt
2026-05-28 13:37:37         180728|OPEN RTE: Thread problem in SLSNMPAgent.exe: Polling thread for element: MyDMA [+ 1 pending] on agent MyDMA in Process: SLSNMPAgent.exe for Thread: Polling thread for element: MyDMA with notificationID: 3334
```

In the SLSNMPAgent.txt log file, errors similar to the following repeatedly occur:

```txt
2026/05/12 13:200:05.885|SLSNMPAgent|669228|467852|CSNMPWrapper::CallbackSnmpReceive_Wrapper_Manager|ERR|-1|Received unexpected SNMP Inform request ID value for SNMP Manager MySNMPManager and request id 1071
```
