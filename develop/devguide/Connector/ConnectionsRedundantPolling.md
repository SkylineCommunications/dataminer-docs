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
> Redundant polling is supported with protocols that define exactly two connections of the same type. The following is supported: two SNMP, two serial, two smart-serial, or two HTTP connections.
>
> Note that for smart-serial connections, in order to get a timeout (enabling the redundant polling connections to switch) the pair must contain a response. Alternatively, you can implement logic to set the communication state using the <xref:NT_CHANGE_COMMUNICATION_STATE> Notify call.

## Switching implementation

This section describes the situations which would trigger Dataminer to switch between polling interfaces during an element's runtime.

### On timeout after retries

When polling for a group goes into timeout, DataMiner will try to poll that group again on the same connection. The wait time for a timeout to be called and the number of retries are based on the configurations in the element settings. After all retries are exhausted, DataMiner will switch to the other interface and poll for the *next* group in the queue.

![Interface switching on 2 SNMP connections](~/develop/images/RedundantPolling_Switch.png)

### On polling invalid parameters

#### SNMP

If the SNMP parameter polled returns an error such as *NO SUCH NAME*, Dataminer will switch between the polling interfaces and poll the next group in the queue. In such corner cases, DataMiner will switch back and forth between interfaces depending on how frequently these invalid parameters are being polled.

## See also

DataMiner Protocol Markup Language:

- [Protocol.Type@communicationOptions: redundantPolling](xref:Protocol.Type-communicationOptions#redundantpolling)
