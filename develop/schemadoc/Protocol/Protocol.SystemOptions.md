---
metadata_version: 1
uid: Protocol.SystemOptions
description: "Learn how the SystemOptions element groups system-level connector settings, including process isolation for memory-intensive protocols."
---

# SystemOptions element

Specifies system-related options.

## Parent

[Protocol](xref:Protocol)

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|[RunInSeparateInstance](xref:Protocol.SystemOptions.RunInSeparateInstance)|[0, 1]|Allows you to flag a protocol as requiring a separate SLProtocol and SLScripting instance because of memory load.|
