---
metadata_version: 1
uid: Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Changes.NewFeature
description: "Reference the DataMiner connector protocol schema entry for NewFeature element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# NewFeature element

Describes a new feature.

## Type

string

## Parent

[Changes](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Changes)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[suppressMajorChanges](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Changes.NewFeature-suppressMajorChanges)|[TypeSemicolonSeparatedValidatorIds](xref:Protocol-TypeSemicolonSeparatedValidatorIds)||Specifies the suppressed major changes.|
