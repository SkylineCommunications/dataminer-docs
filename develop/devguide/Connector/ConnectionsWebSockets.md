---
uid: ConnectionsWebSockets
---

# WebSockets

The WebSocket protocol enables two-way (full-duplex) communication over a single TCP connection.

The goal of this technology is to provide a mechanism for browser-based applications that need two-way communication with servers that does not rely on opening multiple HTTP connections (e.g. using XMLHttpRequest).The protocol consists of an opening handshake followed by basic message framing, layered over TCP (IETF, 2011).

To initiate a WebSocket connection, the WebSocket client sends an HTTP Upgrade request (opening handshake):

```
GET /chat HTTP/1.1
Host: server.example.com
Upgrade: websocket
Connection: Upgrade
Sec-WebSocket-Key: x3JJHMbDL1EzLkh9GBhXDw==
Sec-WebSocket-Protocol: chat
Sec-WebSocket-Version: 13
```

The reason this is an HTTP Upgrade request is that this allows a single port to be used by both HTTP clients and WebSocket clients.

> [!NOTE]
> The header fields in the handshake may be sent in any order.

If this succeeds, the server responds:

```
HTTP/1.1 101 Switching Protocols
Upgrade: websocket
Connection: Upgrade
Sec-WebSocket-Accept: HSmrc0sMlYUkAGmm5OPpG2HaGWk=
Sec-WebSocket-Protocol: chat
```

For more information about WebSockets, refer to RFC6455.
