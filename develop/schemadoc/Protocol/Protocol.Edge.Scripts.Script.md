---
uid: Protocol.Edge.Scripts.Script
---

# Script element

Specifies a script related to Edge functionality.

## Parent

[Scripts](xref:Protocol.Edge.Scripts)

## Children

|Name|Occurrences|Description
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Arguments](xref:Protocol.Edge.Scripts.Script.Arguments)|[0, 1]|Describes the input arguments that the scripts will receive when started.|
|&nbsp;&nbsp;[Schedule](xref:Protocol.Edge.Scripts.Script.Schedule)||Specifies when and how often the script has to be executed.|

## Attributes

|Name|Type|Required|Description
|--- |--- |--- |--- |
|[id](xref:Protocol.Edge.Scripts.Script-id)|string|Yes|Specifies the unique ID for this script.|
|[displayName](xref:Protocol.Edge.Scripts.Script-displayName)|string|Yes|Specifies name of the script that will be shown to the user.|
|[guid](xref:Protocol.Edge.Scripts.Script-guid)|[TypeGuid](xref:TypeGuid)|Yes|Specifies the GUID specified in the manifest.json of the dmscript. This links the script tag with the correct dmscript.|
