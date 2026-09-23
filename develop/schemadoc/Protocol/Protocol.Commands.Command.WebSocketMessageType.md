---
metadata_version: 1
uid: Protocol.Commands.Command.WebSocketMessageType
description: "Learn how the WebSocketMessageType element selects binary or text format for a WebSocket command message in a DataMiner connector protocol."
---

# WebSocketMessageType element

<!-- RN 14177 -->

Specifies the format in which the message should be sent.

## Type

[EnumWebSocketMessageType](xref:Protocol-EnumWebSocketMessageType)

## Parent

[Command](xref:Protocol.Commands.Command)

## Remarks

By default, the message is sent in binary format.

## Examples

```xml
<Command id="1">
   <Name>Message</Name>
   <WebSocketMessageType>text</WebSocketMessageType>
   <Content>
      <Param>2</Param>
   </Content>
</Command>
```
