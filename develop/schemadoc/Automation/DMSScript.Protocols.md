---
metadata_version: 1
uid: DMSScript.Protocols
description: "Reference the DataMiner Automation script schema entry for Protocols element, including its documented structure, attributes, values, and constraints."
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
