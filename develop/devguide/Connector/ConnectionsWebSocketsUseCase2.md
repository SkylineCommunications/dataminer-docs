---
uid: ConnectionsWebSocketsUseCase2
---

# WebSocket connection with dynamic IP

The WebSocket connection with dynamic IP is used when the connection URL/IP address is filled in during element creation, but the connector is configured to dynamically change the IP address. No configuration is needed in the element after startup. When the WebSocket connection is down, DataMiner will be able to connect again without an element restart.

On every change of the parameter, the previous connection will be gracefully closed and the new one will be set up. This can be done with a button to re-establish the connection.

For information about the dynamic IP configuration, see:

- [Dynamically changing the IP address and port number](xref:ConnectionsWebSocketsDynamicIp)
- [Dynamic polling](xref:ConnectionsSerialDynamicPolling)

> [!NOTE]
> This is the most used solution to implement a WebSocket. After a disconnection of the WebSocket, it is possible to reconnect with the WebSocket without an element restart.

> [!TIP]
> See also: [WebSocket use cases](xref:ConnectionsWebSocketsUseCases)
