---
uid: Protocol.Pairs.Pair
---

# Pair element

Defines a pair consisting of a command and optionally a response.

## Parent

[Pairs](xref:Protocol.Pairs)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.Pairs.Pair-id)|[TypeNonLeadingZeroUnsignedInt](xref:Protocol-TypeNonLeadingZeroUnsignedInt)|Yes|Specifies the unique ID of the pair.|
|[options](xref:Protocol.Pairs.Pair-options)|string||Specifies a number of options, separated by semicolons (”;”).|
|[ping](xref:Protocol.Pairs.Pair-ping)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||If set to true, the pair will be executed when the device is in timeout and slow polling is activated.|
|[timeout](xref:Protocol.Pairs.Pair-timeout)|unsignedInt||Specifies the timeout value to use for this pair instead of the default value when executing the pair.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Condition](xref:Protocol.Pairs.Pair.Condition)|[0, 1]|Specifies a condition that must be met in order for the pair to execute.|
|&nbsp;&nbsp;[Content](xref:Protocol.Pairs.Pair.Content)||Associates a command with its expected response(s), if any.|
|&nbsp;&nbsp;[Description](xref:Protocol.Pairs.Pair.Description)|[0, 1]|Contains a textual description of the pair.|
|&nbsp;&nbsp;[Name](xref:Protocol.Pairs.Pair.Name)||Specifies the name of the pair.|
