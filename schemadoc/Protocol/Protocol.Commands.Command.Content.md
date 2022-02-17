---
uid: Protocol.Commands.Command.Content
---

# Content element

Specifies the consecutive parameters that together form the command to be sent to the data source.

## Parent

[Command](xref:Protocol.Commands.Command)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Param](xref:Protocol.Commands.Command.Content.Param)|[0, *]|Specifies the ID of the parameter to include in the command.|

## Remarks

Quite often, commands have a header parameter and a trailer parameter that demarcate the beginning and the end of the command.
