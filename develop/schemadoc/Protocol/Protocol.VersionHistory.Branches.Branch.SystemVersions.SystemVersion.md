---
metadata_version: 1
uid: Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion
description: "Consult the DataMiner connector protocol schema reference for the SystemVersion element, which defines a system version entry and its major versions."
---

# SystemVersion element

Defines a SystemVersion entry.

## Parent

[SystemVersions](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion-id)|unsignedInt|Yes|The unique ID of the system version component.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Comment](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.Comment)|[0, 1]|Provides information about this entry.|
|&nbsp;&nbsp;[MajorVersions](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions)||Contains the different major versions within this branch of this protocol.|
|&nbsp;&nbsp;[SupportedVersions](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.SupportedVersions)|[0, 1]|Specifies the system version support.|
