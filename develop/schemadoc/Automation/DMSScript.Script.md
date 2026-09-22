---
metadata_version: 1
uid: DMSScript.Script
description: "Reference the DataMiner Automation script schema entry for Script element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaAutomationScript
applies_to:
  - DataMiner
version: unknown
owner: unknown
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
