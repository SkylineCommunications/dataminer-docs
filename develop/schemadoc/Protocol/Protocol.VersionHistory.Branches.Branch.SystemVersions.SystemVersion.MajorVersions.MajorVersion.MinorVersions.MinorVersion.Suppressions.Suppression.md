---
uid: Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Suppressions.Suppression
---

# Suppression element

A single suppression.

## Parent

[Suppressions](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Suppressions)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[type](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Suppressions.Suppression-type)|[EnumSuppressionType](xref:Protocol-EnumSuppressionType)|Yes|Type of the suppression.|
|[taskId](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Suppressions.Suppression-taskId)|unsignedInt||Task ID.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Reason](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Suppressions.Suppression.Reason)||Reason for the suppression.|
|&nbsp;&nbsp;[Location](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Suppressions.Suppression.Location)||Location of the suppression.|
|&nbsp;&nbsp;[ResultId](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.Suppressions.Suppression.ResultId)||ID of the result that is being suppressed.|
