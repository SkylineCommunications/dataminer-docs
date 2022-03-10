---
uid: Protocol-TypeObjectId
---

# TypeObjectId simple type

Defines the range of possible IDs for actions, groups, triggers, QActions and timers.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***Union***|||
|&nbsp;&nbsp;***unsignedInt restriction***|||
|&nbsp;&nbsp;&nbsp;&nbsp;Pattern|`[123456789]\d*`||
|&nbsp;&nbsp;&nbsp;&nbsp;Min inclusive|1||
|&nbsp;&nbsp;&nbsp;&nbsp;Max inclusive|64299||
|&nbsp;&nbsp;***unsignedInt restriction***|||
|&nbsp;&nbsp;&nbsp;&nbsp;Pattern|`[123456789]\d*`||
|&nbsp;&nbsp;&nbsp;&nbsp;Min inclusive|70000||
|&nbsp;&nbsp;&nbsp;&nbsp;Max inclusive|99999||
|&nbsp;&nbsp;***unsignedInt restriction***|||
|&nbsp;&nbsp;&nbsp;&nbsp;Pattern|`[123456789]\d*`||
|&nbsp;&nbsp;&nbsp;&nbsp;Min inclusive|1000000||
|&nbsp;&nbsp;&nbsp;&nbsp;Max inclusive|9999999||
