---
uid: ConnectionsPingGroup
---

# Ping group

When an element goes into timeout and slow poll is enabled, only the so-called ping group is executed until the device responds again.

> [!NOTE]
> Slow poll behavior is currently only supported for the main connection.

DataMiner will search for a group with ID "-1" and use that one as the ping group.

If the main connection is an SNMP connection, and there was no group with ID "-1", DataMiner will use the first parameter from the first group that is defined in the protocol as the "ping group". This parameter will be used to check if the element is active again. Make sure that this first group is in fact a polling group and not for instance a poll action or poll trigger group, otherwise RTEs can occur.

If the main connection is a serial connection, and there was no group with ID "-1", DataMiner will use the pair that has been specified with the "ping" attribute. In case there is no pair with the ping attribute, the pair with the lowest ID that contains a response will be used as ping pair.

> [!NOTE]
>
> - It is not the group with the lowest ID value but the first group defined in the protocol that is used as the ping group for an SNMP connection. The logging will indicate the ping group as group "-1".
> - For SNMP connections, instead of using a group with ID "-1", it is advised to make sure the first group defined in the protocol can be used as a ping group.
> - For serial connections, instead of using a group with ID "-1", it is advised to use the ping attribute to define a ping pair.

## See also

- [SNMP Ping Groups](xref:ConnectionsSnmpPingGroups)
- [HTTP Ping Group](xref:ConnectionsHttpPingGroup)
