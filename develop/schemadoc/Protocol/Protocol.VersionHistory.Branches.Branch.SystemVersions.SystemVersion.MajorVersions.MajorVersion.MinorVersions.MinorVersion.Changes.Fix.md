---
metadata_version: 1
uid: Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Changes.Fix
description: "Consult the DataMiner connector protocol schema reference for the Fix element, which documents a minor-version fix and the bug version it addresses."
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
