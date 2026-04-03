---
uid: Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Changes.Fix
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
|[introducedBy](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Changes.Fix-introducedBy)|[TypeProtocolVersion](xref:Protocol-TypeProtocolVersion)|True|Specifies the version in which the bug being fixed was originally introduced.|
|[suppressMajorChanges](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Changes.Fix-suppressMajorChanges)|[TypeSemicolonSeparatedValidatorIds](xref:Protocol-TypeSemicolonSeparatedValidatorIds)|False|Specifies the suppressed major changes.|
