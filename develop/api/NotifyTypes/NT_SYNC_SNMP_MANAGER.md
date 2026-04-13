---
uid: NT_SYNC_SNMP_MANAGER
---

# NT_SYNC_SNMP_MANAGER (317)

Triggers the resend mechanism for a particular SNMP manager (SNMPv1 traps, SNMPv2 traps and inform messages).

```csharp
int snmpManagerID = 1;
bool onlySendLocalActiveAlarms = false;

object result = protocol.NotifyDataMiner(317/*NT_SYNC_SNMP_MANAGER*/ , snmpManagerID, onlySendLocalActiveAlarms);
```

## Parameters

- snmpManagerID (int): ID of the SNMP manager.
- onlySendLocalActiveAlarms (bool): Indicates whether to only send local active alarms of the DMA hosting the protocol or not (default: False, i.e., all active Alarms in the DMS).

## Return Value

- result (int)
