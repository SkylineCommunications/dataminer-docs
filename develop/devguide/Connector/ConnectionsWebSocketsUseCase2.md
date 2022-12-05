---
uid: ConnectionsWebSocketsUseCase2
---

# WebSocket Connection with Dynamic IP

The WebSocket connection with dynamic IP is used when the connection url/ip address is filled in at the creation of the element. No configuration is needed in the element after startup. When the WebSocket connection is down, it is possible to connect again with the WebSocket without a restart of the element.

## Dynamic IP

- <xref:ConnectionsWebSocketsDynamicIp>
- <xref:ConnectionsSerialDynamicPolling>

On every change of the parameter, the previous connection will be gracefully closed and the new one will be set up. This can be done with a button to re-establish the connection.

> [!NOTE]
> This is the most used solution to implement a WebSocket!!
>
> After a disconnection of the WebSocket, it is possible to reconnect with the WebSocket without an element restart.
