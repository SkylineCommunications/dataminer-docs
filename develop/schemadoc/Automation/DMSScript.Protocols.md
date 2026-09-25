---
metadata_version: 1
uid: DMSScript.Protocols
description: "Use the Protocols element to contain an automation script's dummy variables and ensure that each Protocol ID is unique."
---

# Protocols element

Contains the dummy script variables defined in the script.

## Parent

[DMSScript](xref:DMSScript)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Protocol](xref:DMSScript.Protocols.Protocol)|[0, *]|Defines a dummy script variable. When the script is run, an actual element will be linked to each dummy.|

## Constraints

|Type|Description|Selector|Fields
|--- |--- |--- |--- |
|Unique |The ID must be unique. |Protocol |@id |
