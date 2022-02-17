---
uid: Protocol-EnumProtocolTypeRelativeTimers
---

# EnumProtocolTypeRelativeTimers simple type

Specifies tye relative timer setting.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|true|If the interval is changed in the middle of the current interval, the timer will only be executed when the interval is completely finished.|
|&nbsp;&nbsp;Enumeration|true with reset|Each time the interval is changed the timer is executed instantly.|
