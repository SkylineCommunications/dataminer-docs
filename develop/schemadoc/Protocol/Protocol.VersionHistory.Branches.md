---
metadata_version: 1
uid: Protocol.VersionHistory.Branches
description: "Consult the DataMiner connector protocol schema reference for the Branches element, which lists uniquely identified branches in a protocol version history."
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
