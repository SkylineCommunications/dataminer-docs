---
metadata_version: 1
uid: Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion
description: "Consult the DataMiner connector protocol schema reference for the MajorVersion element, which defines a major version with its changes and minor versions."
---

# MajorVersion element

Defines a major version of this protocol.

## Parent

[MajorVersions](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion-id)|unsignedInt|Yes|The unique ID of the major version component.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Changes](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.Changes)|[0, 1]|Contains information about the changes.|
|&nbsp;&nbsp;[MinorVersions](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions)||Contains the different minor versions of this protocol within this major version of this protocol.|
