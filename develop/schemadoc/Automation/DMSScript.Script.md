---
metadata_version: 1
uid: DMSScript.Script
description: "Use the Script element to contain an automation script's ordered Exe actions and ensure that every action ID is unique."
---

# Script element

Contains the script actions.

## Parent

[DMSScript](xref:DMSScript)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Exe](xref:DMSScript.Script.Exe)|[0, *]|Defines a script action.|

## Constraints

|Type|Description|Selector|Fields
|--- |--- |--- |--- |
|Unique |The ID must be unique. |Script |@id |
