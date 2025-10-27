---
uid: Functions
---

# Functions element

Root element.

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***Sequence***|||
|&nbsp;&nbsp;[Version](xref:Functions.Version)||Specifies the version number of the functions file.|
|&nbsp;&nbsp;[Protocol](xref:Functions.Protocol)||Specifies the name of the protocol that the functions file depends on.|
|&nbsp;&nbsp;[OverrideTimeoutVF](xref:Functions.OverrideTimeoutVF)|[0, 1]|When set to "true", this tag allows the timeout override for a virtual function. Available from DataMiner 10.5.3/10.6.0 onwards.<!-- RN 41388 -->|
|&nbsp;&nbsp;[Function](xref:Functions.Function)|[1, *]|Defines a function for the protocol.|
