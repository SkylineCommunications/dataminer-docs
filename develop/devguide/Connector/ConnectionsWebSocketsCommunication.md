---
uid: ConnectionsWebSocketsCommunication
---

# Communication

Once the WebSocket has been set up, data can be sent and received. Commands are implemented using Command constructs and Responses can be implemented using Response constructs, just as is the case with serial connections.

For traditional request/response communication, a command and response can be combined in a pair. Similar to HTTP, when a response is not received, the connection will time out.

However, the most common use case will be to send an initial request after which the WebSocket server will periodically send data to DataMiner. In this case, only define the command in a pair as is the case with smart-serial connections.
