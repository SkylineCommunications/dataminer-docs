---
uid: Protocol.Commands.Command.WebSocketMessageType
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
