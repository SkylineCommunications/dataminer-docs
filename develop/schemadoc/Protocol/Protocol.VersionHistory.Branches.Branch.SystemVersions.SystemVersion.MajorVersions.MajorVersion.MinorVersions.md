---
metadata_version: 1
uid: Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions
description: "Reference the DataMiner connector protocol schema entry for MinorVersions element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
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
