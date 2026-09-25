---
metadata_version: 1
uid: DMSScript.Script.Exe.Message
description: "Use the Message element to supply text for C# code, comments, notifications, exits, information events, log messages, or reports."
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
