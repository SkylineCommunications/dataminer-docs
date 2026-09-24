---
metadata_version: 1
uid: Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions
description: "Consult the DataMiner connector protocol schema reference for the MinorVersions element, which lists minor versions within a major protocol version."
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
