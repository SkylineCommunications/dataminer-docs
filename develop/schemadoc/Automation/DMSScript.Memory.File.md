---
uid: DMSScript.Memory.File
---

# File element

Defines a memory file.

## Parent

[Memory](xref:DMSScript.Memory)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:DMSScript.Memory.File-id)|positiveInteger|Yes|Specifies the unique ID of the memory file.|
|[volatile](xref:DMSScript.Memory.File-volatile)|[EnumTrueFalseLowerCase](xref:Automation-EnumTrueFalseLowerCase)|Yes|Indicates whether the memory file is a memory file created within the script (true) or a permanent memory file (false).|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Description](xref:DMSScript.Memory.File.Description)||Specifies the memory file name.|
