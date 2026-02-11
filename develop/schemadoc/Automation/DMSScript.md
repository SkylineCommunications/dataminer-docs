---
uid: DMSScript
---

# DMSScript element

The root element of a DataMiner Automation script.

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[options](xref:DMSScript-options)|positiveInteger|Yes|Specifies different options.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Name](xref:DMSScript.Name)||Specifies the name of the automation script.|
|&nbsp;&nbsp;[Description](xref:DMSScript.Description)||Specifies the description of the automation script.|
|&nbsp;&nbsp;[Type](xref:DMSScript.Type)||Specifies the type of script. For automation scripts, the value is "Automation".|
|&nbsp;&nbsp;[Author](xref:DMSScript.Author)||Specifies the author of the script.|
|&nbsp;&nbsp;[CheckSets](xref:DMSScript.CheckSets)||Specifies whether to check sets.|
|&nbsp;&nbsp;[Interactivity](xref:DMSScript.Interactivity)||Specifies if the script requires user interaction.|
|&nbsp;&nbsp;[Folder](xref:DMSScript.Folder)||Specifies the folder in which this automation script is saved.|
|&nbsp;&nbsp;[Protocols](xref:DMSScript.Protocols)||Contains the dummy script variables defined in the script.|
|&nbsp;&nbsp;[Memory](xref:DMSScript.Memory)||Contains the memory files.|
|&nbsp;&nbsp;[Parameters](xref:DMSScript.Parameters)||Contains the parameter script variables defined in the script.|
|&nbsp;&nbsp;[Script](xref:DMSScript.Script)||Contains the script actions.|

## Constraints

|Type|Description|Selector|Fields
|--- |--- |--- |--- |
|Unique |IDs must be unique. |.//* |@id |
