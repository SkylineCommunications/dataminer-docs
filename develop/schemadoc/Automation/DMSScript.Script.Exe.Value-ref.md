---
metadata_version: 1
uid: DMSScript.Script.Exe.Value-ref
description: "Reference the DataMiner Automation script schema entry for ref attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaAutomationScript
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# ref attribute

Refers to an item. The item that is referred to depends on the type of script action.

## Content Type

string

When used with script actions of type "assigndummy",  "settemplate" or "set", the value specifies a script variable.

When used with script action of type "clearmemory", the value specifies the ID of the memory.

## Parent

[Value](xref:DMSScript.Script.Exe.Value)

## Remarks

Used with script actions of type "assigndummy",  "csharp", "settemplate", "clearmemory", "get", "goto", "label", "set", "ui".
