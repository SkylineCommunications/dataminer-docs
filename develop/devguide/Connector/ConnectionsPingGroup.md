---
uid: ConnectionsPingGroup
---

# Slow poll mode ping group

When an element is in a timeout state, the DataMiner Agent can force it to go into so-called slow poll mode. While the element is in slow poll mode, the Agent will not send any commands to the element, except for a protocol-dependent ping command at regular intervals. As soon as the element receives a response for this ping command, the Agent goes out of slow poll mode and will start polling the element the normal way again.

For more info on how to configure slow poll mode on an element, refer to the slow poll settings section under [Adding elements](xref:Adding_elements).

> [!NOTE]
> Slow poll behavior is currently only supported for the main connection.

DataMiner will search for a group with ID "-1" and use that one as the ping group. For serial and SNMP connections, if no group with ID "-1" is found, some additional steps are performed as discussed in the subsections below.

## Serial connection

If the main connection is a serial connection, and there is no group with ID "-1", DataMiner will use the pair that has been specified with the [ping](xref:Protocol.Pairs.Pair-ping) attribute set to ´true´.

In case there is no pair with the [ping](xref:Protocol.Pairs.Pair-ping) attribute set to ´true´, the pair with the lowest ID that contains a response will be used as ping pair.

> [!NOTE]
>
> - For serial connections, instead of using a group with ID "-1", it is advised to use the ping attribute to define a ping pair.

## SNMP connection

If the main connection is an SNMP connection, and there is no group with ID "-1", DataMiner will use the first parameter from the first group that is defined in the protocol to create the "ping group". This parameter will be used to check if the element is active again. Make sure that this first group is in fact a polling group and not for instance a poll action or poll trigger group. Otherwise, RTEs can occur.

> [!NOTE]
>
> - It is not the group with the lowest ID value but the first group defined in the protocol that is used as the ping group for an SNMP connection. The logging will indicate the ping group as group "-1".
> - For SNMP connections, instead of using a group with ID "-1", we recommend that you make sure the first group defined in the protocol can be used as a ping group.
