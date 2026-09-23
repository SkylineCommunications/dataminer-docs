---
metadata_version: 1
uid: DMSScript.Script.Exe.Param
description: "Reference the DataMiner Automation script schema entry for Param element, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# Param element

Specifies a parameter.

## Type

string

## Parent

[Exe](xref:DMSScript.Script.Exe)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[protocol](xref:DMSScript.Script.Exe.Param-protocol)|positiveInteger||Specifies the ID of the dummy script variable that is referred to.|
|[type](xref:DMSScript.Script.Exe.Param-type)|string||Specifies the type of data this parameter holds.|

## Remarks

Used with script actions of type "assigndummy", "csharp", "get", "script", "set".
