---
metadata_version: 1
uid: DMSScript.Script.Exe.Message
description: "Reference the DataMiner Automation script schema entry for Message element, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# Message element

Specifies the message.

## Type

string

## Parent

[Exe](xref:DMSScript.Script.Exe)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[ref](xref:DMSScript.Script.Exe.Message-ref)|string||Used with script actions of type "logmessage". Specifies the name of the parameter of which the value should be logged.|

## Remarks

Used with script actions of type "csharp", "comment", "notification", "exit", "findinteractiveclient", "information", "logmessage", "report".
