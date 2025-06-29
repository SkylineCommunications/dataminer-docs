---
uid: DataMiner.SnmpTrapDistribution
---

# SnmpTrapDistribution element

When set to `false`, SNMP trap distribution is disabled within the DMS.

## Content Type

boolean

## Parents

[DataMiner](xref:DataMiner)

## Remarks

SNMP trap distribution is a process where SNMP traps or inform messages are shared across DataMiner Agents in the cluster. When a trap arrives at one Agent, it is processed there first. If other Agents in the cluster have elements that listen for traps, the trap will be distributed to those Agents. However, Agents without interested elements will not receive it.

If this is set to false, SNMP trap distribution will be disabled within the DMS.

Example:

```xml
<DataMiner>
  ...
  <SnmpTrapDistribution>false</SnmpTrapDistribution>
  ...
</DataMiner>
```

> [!NOTE]
> From DataMiner 10.2.0 [CU10]/10.3.1 onwards, the number of distribution traps is limited to 250,000. When the processing queue of distribution traps contains 250,000 traps, new traps will be rejected until the number of traps in the queue has dropped to 100,000. These limits are fixed and cannot be configured.

<!--- RN34525 --->
