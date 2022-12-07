---
uid: ConnectionsWebSocketsUseCase1
---

# Normal WebSocket connection

A normal WebSocket connection is used when the connection URL/IP address is filled in during element creation. No configuration is needed in the element after startup.

If this WebSocket connection is used, it is not possible to reconnect after a disconnect.

> [!IMPORTANT]
> Avoid this use case. After a disconnection of the WebSocket, an element restart will be needed to be able to reconnect.

> [!TIP]
> See also: [WebSocket use cases](xref:ConnectionsWebSocketsUseCases)
