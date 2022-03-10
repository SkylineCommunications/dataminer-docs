---
uid: Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.Changes.Change
---

# Change element

Describes a change.

## Parent

[Changes](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.Changes)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[coversMajorChanges](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.Changes.Change-coversMajorChanges)|[TypeSemicolonSeparatedValidatorIds](xref:Protocol-TypeSemicolonSeparatedValidatorIds)||Specifies the major changes this major change covers.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Impact](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.Changes.Change.Impact)||Describes the impact of this change.|
|&nbsp;&nbsp;[ActionsToTake](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.Changes.Change.ActionsToTake)|[0, 1]|Lists the actions to take.|

## Examples

```xml
<Change>
  <Impact>Replaced serial connection by an HTTP connection. DataMiner element might get corrupted.</Impact>
  <ActionsToTake>
    <ActionToTake>Delete current element.</ActionToTake>
    <ActionToTake>Create a new element.</ActionToTake>
  </ActionsToTake>
</Change>
```
