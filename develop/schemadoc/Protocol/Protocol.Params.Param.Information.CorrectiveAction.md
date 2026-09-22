---
metadata_version: 1
uid: Protocol.Params.Param.Information.CorrectiveAction
description: "Reference the DataMiner connector protocol schema entry for CorrectiveAction element, including its documented structure, attributes, values, and constrai."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# CorrectiveAction element

Specifies a corrective action.<!-- RN 4723 -->

## Type

string

## Parent

[Information](xref:Protocol.Params.Param.Information)

## Remarks

When an alarm for this parameter is generated, the value specified here will be shown in the Corrective Action field of the alarm.

> [!NOTE]
> The value specified here serves as a default and can be overridden in an information template.
