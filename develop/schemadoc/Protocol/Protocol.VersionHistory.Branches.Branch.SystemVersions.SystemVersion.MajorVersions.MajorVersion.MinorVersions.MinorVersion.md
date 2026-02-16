---
uid: Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion
---

# MinorVersion element

Defines a minor version of this protocol.

## Parent

[MinorVersions](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion-id)||Yes|The unique ID of the minor version component.|
|[basedOn](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion-basedOn)|[TypeProtocolVersion](xref:Protocol-TypeProtocolVersion)||The version of the protocol on which this protocol is based.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Changes](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Changes)||Contains information about the changes implemented in this minor version of this protocol.|
|&nbsp;&nbsp;[Date](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Date)||Specifies the date on which this version of this protocol has been released. (Format: YYYY-MM-DD)|
|&nbsp;&nbsp;[Provider](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Provider)||Contains information about the provider of this version of this protocol.|
|&nbsp;&nbsp;[References](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.References)|[0, 1]|Provides references to e.g., registration systems.|
|&nbsp;&nbsp;[Suppressions](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Suppressions)|[0, 1]|List of all the suppressions for this version.|
