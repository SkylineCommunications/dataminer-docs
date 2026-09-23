---
metadata_version: 1
uid: Protocol.VersionHistory.Branches
description: "Reference the DataMiner connector protocol schema entry for Branches element, including its documented structure, attributes, values, and constraints."
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
