---
uid: Protocol-EnumTrendingType
---

# EnumTrendingType simple type

Specifies the trending type.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|average|Average value in the time span (default when no trending tag is present).|
|&nbsp;&nbsp;Enumeration|max|Maximum value in the time span.|
|&nbsp;&nbsp;Enumeration|min|Minimum value in the time span.|
|&nbsp;&nbsp;Enumeration|last|Last value in the time span.|
|&nbsp;&nbsp;Enumeration|sum|Sum of all the values in the time span. This cannot be used for discreet parameters.|
