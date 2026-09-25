---
metadata_version: 1
uid: Protocol.Pairs
description: "Learn how to use the Pairs element to list uniquely identified command and response pairs in a DataMiner connector protocol."
---

# Pairs element

Contains all the pairs defined in the protocol.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Pair](xref:Protocol.Pairs.Pair)|[0, *]|Defines a pair consisting of a command and optionally a response.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The ID of a pair must be unique. |Pair |@id |
