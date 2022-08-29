---
uid: Manifest.VersionHistory.Branches.Branch.MajorVersions.MajorVersion.MinorVersions.MinorVersion.CUVersions.CU
---

# CU element

Defines a cumulative upgrade version of this package.

## Parent

[CUVersions](xref:Manifest.VersionHistory.Branches.Branch.MajorVersions.MajorVersion.MinorVersions.MinorVersion.CUVersions)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Manifest.VersionHistory.Branches.Branch.MajorVersions.MajorVersion.MinorVersions.MinorVersion.CUVersions.CU-id)|unsignedInt|Yes|The unique ID of the CU version component.|
|[basedOn](xref:Manifest.VersionHistory.Branches.Branch.MajorVersions.MajorVersion.MinorVersions.MinorVersion.CUVersions.CU-basedOn)|[TypePackageVersion](xref:Manifest-TypePackageVersion)||Specifies the version of the package on which this package is based.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Changes](xref:Manifest.VersionHistory.Branches.Branch.MajorVersions.MajorVersion.MinorVersions.MinorVersion.CUVersions.CU.Changes)||Contains information about the changes implemented in this CU version of this package.|
|&nbsp;&nbsp;[Date](xref:Manifest.VersionHistory.Branches.Branch.MajorVersions.MajorVersion.MinorVersions.MinorVersion.CUVersions.CU.Date)||Specifies the date on which this version of this package was released (format: YYYY-MM-DD).|
|&nbsp;&nbsp;[Provider](xref:Manifest.VersionHistory.Branches.Branch.MajorVersions.MajorVersion.MinorVersions.MinorVersion.CUVersions.CU.Provider)||Contains information about the provider of this version of this package.|
|&nbsp;&nbsp;[References](xref:Manifest.VersionHistory.Branches.Branch.MajorVersions.MajorVersion.MinorVersions.MinorVersion.CUVersions.CU.References)|[0, 1]|Provides references to e.g. registration systems.|
