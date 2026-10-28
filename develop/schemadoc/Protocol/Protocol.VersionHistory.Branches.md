---
uid: Protocol.VersionHistory.Branches
description: "Use the Branches element in a DataMiner protocol to list the branch-based release history for a protocol."
---

# Branches element

Contains the different branches of this protocol.

## Parent

[VersionHistory](xref:Protocol.VersionHistory)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Branch](xref:Protocol.VersionHistory.Branches.Branch)|[1, *]|Defines a branch of this protocol.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The branch IDs must be unique. |Branch |@id |
