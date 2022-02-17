---
uid: ConnectionsSnmpPingGroups
---

# Ping groups

When an element goes into timeout and slow poll settings are configured, only the so-called "ping group" is executed until the device responds again. In SNMP-based protocols, the first parameter from the first group that is defined in the protocol will be used as the "ping group". This parameter will be used to check if the element is active again.

> [!NOTE]
> This is not the group with the lowest ID number but the first group defined in the protocol. The logging will indicate the ping group as group "-1".

Make sure that this first group is in fact a polling group and not for instance a poll action or poll trigger group, otherwise RTEs can occur.

## See also

- [Ping Group](xref:ConnectionsPingGroup)
