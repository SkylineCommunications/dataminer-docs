---
uid: Protocol-TimerTime
---

# TimerTime simple type

Specifies the timer time.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***Union***|||
|&nbsp;&nbsp;***string restriction***|||
|&nbsp;&nbsp;&nbsp;&nbsp;Enumeration|loop|Executes in a loop.|
|&nbsp;&nbsp;***unsignedInt restriction***|||
|&nbsp;&nbsp;&nbsp;&nbsp;Pattern|`[123456789]\d*`||
|&nbsp;&nbsp;&nbsp;&nbsp;Min inclusive|1||
|&nbsp;&nbsp;&nbsp;&nbsp;Max inclusive|2073600000||
