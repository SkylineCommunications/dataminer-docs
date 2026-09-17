---
metadata_version: 1
uid: DMSScript.Script.Exe.Condition-type
description: "Reference the DataMiner Automation script schema entry for type attribute, including its documented structure, attributes, values, and constraints."
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

# type attribute

Specifies whether the left hand operand of the Boolean expression is a script variable or a parameter value.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|param|Parameter|
|&nbsp;&nbsp;Enumeration|variable|Variable|

## Parent

[Condition](xref:DMSScript.Script.Exe.Condition)
