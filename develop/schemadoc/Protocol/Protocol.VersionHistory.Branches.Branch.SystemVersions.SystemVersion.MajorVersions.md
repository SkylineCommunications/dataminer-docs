---
metadata_version: 1
uid: Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions
description: "Reference the DataMiner connector protocol schema entry for MajorVersions element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# MajorVersions element

Contains the different major versions within this branch of this protocol.

## Parent

[SystemVersion](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[MajorVersion](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion)||Defines a major version of this protocol.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The ID of the major versions for a specific system version must be unique. |MajorVersion |@id |
