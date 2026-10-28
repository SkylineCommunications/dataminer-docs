---
uid: Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions
description: "Use the MinorVersions element under MajorVersion in a DataMiner protocol to list minor versions within a major version."
---

# MinorVersions element

Contains the different minor versions of this protocol within this major version of this protocol.

## Parent

[MajorVersion](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[MinorVersion](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion)||Defines a minor version of this protocol.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The ID of the minor versions for a specific major version must be unique. |MinorVersion |@id |
