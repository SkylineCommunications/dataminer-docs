---
uid: ConnectionsWebSocketsCommunication
---

# Communication

Once the WebSocket has been set up, data can be sent and received. Commands are implemented using Command constructs and Responses can be implemented using Response constructs, just as is the case with serial connections.

For traditional request/response communication, a command and response can be combined in a pair. Similar to HTTP, when a response is not received, the connection will time out.

However, the most common use case will be to send an initial request after which the WebSocket server will periodically send data to DataMiner. In this case, only define the command in a pair as is the case with smart-serial connections.

# Examples

In both the examples 3 things need to be defined:
1. Command
1. Response
1. Pair

## Traditional Request/Response

For a traditional request/response setup the pair needs to habe both a command and a response. In this example the command comes from parameter 11 and the response of this command will be saved in parameter 1.

```xml
<Commands>
	<Command id="1">
		<Name>Websocket Command #1</Name>
		<Description>Command to send over WebSocket for Instance 1</Description>
		<WebSocketMessageType>text</WebSocketMessageType>
		<Content>
			<Param>11</Param>
		</Content>
	</Command>
</Commands>

<Responses>
	<Response id="1" options="Connection:0">
		<Name>Websocket Response #1</Name>
		<Description>Response received over WebSocket for Instance 1</Description>
		<Content>
			<Param>1</Param>
		</Content>
	</Response>
</Responses>

<Pairs>
	<Pair id="1">
		<Name>Instance 1</Name>
		<Description>Instance 1</Description>
		<Content>
			<Command>1</Command>
			<Response>1</Response>
		</Content>
	</Pair>
</Pairs>
```

## Receive push messages

The big difference here is that the Pair can not have a response defined, otherwise this won't work. In this example the traditional request/response structure still works. The command is send out and every response coming from Connection:0 will be saved in parameter 1

```xml
<Commands>
	<Command id="1">
		<Name>Websocket Command #1</Name>
		<Description>Command to send over WebSocket for Instance 1</Description>
		<WebSocketMessageType>text</WebSocketMessageType>
		<Content>
			<Param>11</Param>
		</Content>
	</Command>
</Commands>

<Responses>
	<Response id="1" options="Connection:0">
		<Name>Websocket Response #1</Name>
		<Description>Response received over WebSocket for Instance 1</Description>
		<Content>
			<Param>1</Param>
		</Content>
	</Response>
</Responses>

<Pairs>
	<Pair id="1">
		<Name>Instance 1</Name>
		<Description>Instance 1</Description>
		<Content>
			<Command>1</Command>
		</Content>
	</Pair>
</Pairs>
```

## Multiple Websockets

In this example there are 2 websocket connections. The responses have an option defined to distinguish between the 2 connections. Messages coming from the first websocket will be saved in parameter 1, whilst messages coming from websocket 2 will be saved in parameter 2. If determining the source connection of the messages is important, you can adjust your logic according to the parameter to which the messages were stored.

```xml
<Commands>
	<Command id="1">
		<Name>Websocket Command #1</Name>
		<Description>Command to send over WebSocket for Instance 1</Description>
		<WebSocketMessageType>text</WebSocketMessageType>
		<Content>
			<Param>11</Param>
		</Content>
	</Command>
	<Command id="2">
		<Name>Websocket Command #2</Name>
		<Description>Command to send over WebSocket for Instance 2</Description>
		<WebSocketMessageType>text</WebSocketMessageType>
		<Content>
			<Param>12</Param>
		</Content>
	</Command>
</Commands>

<Responses>
	<Response id="1" options="Connection:0">
		<Name>Websocket Response #1</Name>
		<Description>Response received over WebSocket for Instance 1</Description>
		<Content>
			<Param>1</Param>
		</Content>
	</Response>
	<Response id="2" options="Connection:1">
		<Name>Websocket Response #2</Name>
		<Description>Response received over WebSocket for Instance 2</Description>
		<Content>
			<Param>2</Param>
		</Content>
	</Response>
</Responses>

<Pairs>
	<Pair id="1">
		<Name>Instance 1</Name>
		<Description>Instance 1</Description>
		<Content>
			<Command>1</Command>
			<Response>1</Response>
		</Content>
	</Pair>
	<Pair id="2">
		<Name>Instance 2</Name>
		<Description>Instance 2</Description>
		<Content>
			<Command>2</Command>
		</Content>
	</Pair>
</Pairs>
```
