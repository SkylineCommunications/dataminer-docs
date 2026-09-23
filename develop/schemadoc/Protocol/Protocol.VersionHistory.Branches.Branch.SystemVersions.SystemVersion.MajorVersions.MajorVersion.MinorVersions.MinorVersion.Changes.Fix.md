---
metadata_version: 1
uid: Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Changes.Fix
description: "Reference the DataMiner connector protocol schema entry for Fix element, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# Fix element

Describes a fix.

## Type

string

## Parent

[Changes](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Changes)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[introducedIn](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Changes.Fix-introducedIn)|[TypeProtocolVersion](xref:Protocol-TypeProtocolVersion)||Specifies the version in which the bug that is being fixed was originally introduced.|
|[suppressMajorChanges](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Changes.Fix-suppressMajorChanges)|[TypeSemicolonSeparatedValidatorIds](xref:Protocol-TypeSemicolonSeparatedValidatorIds)||Specifies the suppressed major changes.|
