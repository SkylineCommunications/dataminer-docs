---
uid: Manifest.VersionHistory.Branches.Branch.MajorVersions.MajorVersion
---

# MajorVersion element

Defines a major version of this package.

## Parent

[MajorVersions](xref:Manifest.VersionHistory.Branches.Branch.MajorVersions)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Manifest.VersionHistory.Branches.Branch.MajorVersions.MajorVersion-id)|unsignedInt|Yes|The unique ID of the major version component.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Changes](xref:Manifest.VersionHistory.Branches.Branch.MajorVersions.MajorVersion.Changes)|[0, 1]|Contains information about the changes.|
|&nbsp;&nbsp;[MinorVersions](xref:Manifest.VersionHistory.Branches.Branch.MajorVersions.MajorVersion.MinorVersions)||Contains the different minor versions within this major range of this package.|
