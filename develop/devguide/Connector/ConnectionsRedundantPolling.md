---
uid: ConnectionsRedundantPolling
---

# Redundant polling

It is possible to create an element that is configured with a redundant connection. When the primary connection is no longer responding (i.e., a timeout occurs on this connection), DataMiner will automatically switch to the secondary connection (and vice versa).

In the protocol, you need to define the 2 connections and specify that redundant polling has to be used:

```xml
<Type communicationOptions="redundantPolling" relativeTimers="true" advanced="snmp:Secondary">snmp</Type>
```

The option [redundantPolling](xref:Protocol.Type-communicationOptions#redundantpolling) in the communicationOptions attribute is required to activate the redundant polling mechanism.

> [!NOTE]
> Redundant polling is supported with protocols that define exactly two connections of the same type. The following is supported: two SNMP, two serial, two smart-serial, or two HTTP connections.
>
> Note that for smart-serial connections, in order to get a timeout (enabling the redundant polling connections to switch) the pair must contain a response. Alternatively, you can implement logic to set the communication state using the <xref:NT_CHANGE_COMMUNICATION_STATE> Notify call.

## Scenarios that trigger redundant polling switching

This section describes when this feature will switch between polling interfaces during an element's runtime.

### On timeout after retries of a single group

When polling for a group goes into timeout, DataMiner will try to poll that group again on the same connection. The wait time for a timeout to be called and the number of retries are based on the configurations in the element settings. After all retries are exhausted, DataMiner will switch to the other interface and poll for the *next* group in the queue.

![Interface switching on 2 SNMP connections](~/develop/images/RedundantPolling_Switch.png)

> [!NOTE]
> During an interface switch, the element will **not** go into timeout. It will only do so when both interfaces are inaccessible and no data has been retrieved for an extended period of time as defined in the element settings.

### SNMP polling of invalid parameters

If the polled SNMP parameter returns an error such as *NO SUCH NAME*, DataMiner will switch between the polling interfaces and poll the next group in the queue. In such corner cases, DataMiner will switch back and forth between interfaces depending on how frequently these invalid parameters are polled.

## Other polling scenarios

This section describes how redundant polling will behave with other connection configurations that can be made in the protocol.

### SNMP polling of specific interfaces using the ipid attribute

Switching of interfaces is triggered on timeout after retries on that specific group/parameter. After this, DataMiner will proceed to poll for the next group in the queue.

See also: [ipid attribute](xref:Protocol.Params.Param.SNMP.OID-ipid)

### On SNMP Get through QActions

When *NT_SNMP_GET* or *NT_SNMP_RAW_GET* are used in a QAction, switching of interfaces is **not triggered**.

See also:

- [NT Notify Type 295](xref:NT_SNMP_GET)
- [NT Notify Type 424](xref:NT_SNMP_RAW_GET)

### SNMP polling of specific interfaces through the connection attribute in a Group

In this case, switching of interfaces is **not triggered**. When the group goes into timeout on a specific connection, DataMiner will try to poll the group again until all retries are exhausted. After this, DataMiner will proceed to poll for the next group in the queue.

See also: [connection attribute](xref:Protocol.Groups.Group-connection)
