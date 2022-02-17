---
uid: ConnectionsRedundantPolling
---

# Redundant polling

It is possible to create an element that is configured with a redundant connection. When the primary connection is no longer responding (i.e. a timeout occurs on this connection), DataMiner will automatically switch to the secondary connection (and vice versa).

In the protocol, you need to define the 2 connections and specify that redundant polling has to be used:

```xml
<Type communicationOptions="redundantPolling" relativeTimers="true" advanced="snmp:Secondary">snmp</Type>
```

The option "redundantPolling" in the communicationOptions attribute is required to activate the redundant polling mechanism.

> [!NOTE]
> Redundant polling is supported with protocols that define exactly two connections of the same type. The following is supported: two SNMP, two serial, two smart-serial or two HTTP connections.
>
> Note that for smart-serial connections, in order to get a timeout (enabling the redundant polling connections to switch) the pair must contain a response. Alternatively, you can implement logic to set the communication state using the <xref:NT_CHANGE_COMMUNICATION_STATE> Notify call.

## See also

DataMiner Protocol Markup Language:

- [Protocol.Type@communicationOptions: redundantPolling](xref:Protocol.Type-communicationOptions#redundantpolling)
