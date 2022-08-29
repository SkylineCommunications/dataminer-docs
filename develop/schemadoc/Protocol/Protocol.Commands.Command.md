---
uid: Protocol.Commands.Command
---

# Command element

Defines a complete command.

## Parent

[Commands](xref:Protocol.Commands)

## Attributes

|Name|Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.Commands.Command-id)|[TypeNonLeadingZeroUnsignedInt](xref:Protocol-TypeNonLeadingZeroUnsignedInt)|Yes|Specifies the command ID.|
|[ascii](xref:Protocol.Commands.Command-ascii)|[TypeTrueOrSemicolonSeparatedNumbers](xref:Protocol-TypeTrueOrSemicolonSeparatedNumbers)||Allows to specify that parameters should be sent as ASCII even if the protocol is in Unicode.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Content](xref:Protocol.Commands.Command.Content)||Specifies the consecutive parameters that together form the command to be sent to the device.|
|&nbsp;&nbsp;[Description](xref:Protocol.Commands.Command.Description)|[0, 1]|Specifies the command description.|
|&nbsp;&nbsp;[Name](xref:Protocol.Commands.Command.Name)|[0, 1]|Specifies the command name.|
|&nbsp;&nbsp;[WebSocketMessageType](xref:Protocol.Commands.Command.WebSocketMessageType)|[0, 1]|Specifies the format in which the message should be sent.|

## Remarks

DataMiner sends a command to a data source:

- to request information, or
- to change a setting.

In both cases, DataMiner will expect a response from the data source. If it requests information, it will expect a response that contains that information, and if it changes a setting, it will expect a confirmation (although, in some cases, none is returned).
