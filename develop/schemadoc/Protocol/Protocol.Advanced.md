---
uid: Protocol.Advanced
---

# Advanced element

Specifies a number of advanced settings with regard to the protocol’s commands and responses.

## Parent

[Protocol](xref:Protocol)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Required|Description|
|--- |--- |--- |--- |
|[ignoreEqualResponse](xref:Protocol.Advanced-ignoreEqualResponse)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||If you set this attribute to “true”, then a received response will be ignored if it is identical to the response received previously (for the same pair). In other words, the trigger associated with a response will not go off if that response is identical to the previous one.|
|[stuffing](xref:Protocol.Advanced-stuffing)|string||This attribute can contain one or more of the following settings, separated by semicolons.|
