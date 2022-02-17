---
uid: Protocol.VersionHistory.Branches.Branch
---

# Branch element

Defines a branch of this protocol.

## Parent

[Branches](xref:Protocol.VersionHistory.Branches)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.VersionHistory.Branches.Branch-id)||Yes|The unique ID of the branch version component.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Comment](xref:Protocol.VersionHistory.Branches.Branch.Comment)||Provides information about this branch.|
|&nbsp;&nbsp;[Features](xref:Protocol.VersionHistory.Branches.Branch.Features)|[0, 1]|Provides information about the features this branch supports.|
|&nbsp;&nbsp;[SystemVersions](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions)||Contains the different SystemVersion entries.|
