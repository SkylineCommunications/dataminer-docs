---
uid: Manifest.VersionHistory.Branches.Branch.MajorVersions.MajorVersion.MinorVersions.MinorVersion.CUVersions
---

# CUVersions element

Contains the different Cumulative Upgrade versions of this package within this minor version of this package.

## Parent

[MinorVersion](xref:Manifest.VersionHistory.Branches.Branch.MajorVersions.MajorVersion.MinorVersions.MinorVersion)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[CU](xref:Manifest.VersionHistory.Branches.Branch.MajorVersions.MajorVersion.MinorVersions.MinorVersion.CUVersions.CU)||Defines a cumulative upgrade version of this package.|

## Constraints

|Type|Description|Selector|Fields
|--- |--- |--- |--- |
|Unique |The ID of the CU versions for a specific minor version must be unique. |CU |@id |
