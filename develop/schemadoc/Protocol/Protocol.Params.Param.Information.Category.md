---
metadata_version: 1
uid: Protocol.Params.Param.Information.Category
description: "Reference the DataMiner connector protocol schema entry for Category element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Category element

Specifies a category.<!-- RN 4723 -->

## Type

string

## Parent

[Information](xref:Protocol.Params.Param.Information)

## Remarks

When an alarm for this parameter is generated, the value specified here will be shown in the Category field of the alarm.

> [!NOTE]
> The value specified here serves as a default and can be overridden in an information template.
