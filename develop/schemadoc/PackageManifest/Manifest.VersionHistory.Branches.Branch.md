---
uid: Manifest.VersionHistory.Branches.Branch
---

# Branch element

Defines a branch of this package.

## Parent

[Branches](xref:Manifest.VersionHistory.Branches)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Manifest.VersionHistory.Branches.Branch-id)||Yes|The unique ID of the branch version component.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Comment](xref:Manifest.VersionHistory.Branches.Branch.Comment)|[0, 1]|Provides information about this branch.|
|&nbsp;&nbsp;[Features](xref:Manifest.VersionHistory.Branches.Branch.Features)|[0, 1]|Provides information about the features this branch supports.|
|&nbsp;&nbsp;[MajorVersions](xref:Manifest.VersionHistory.Branches.Branch.MajorVersions)||Contains the different major versions within this branch of this package.|
