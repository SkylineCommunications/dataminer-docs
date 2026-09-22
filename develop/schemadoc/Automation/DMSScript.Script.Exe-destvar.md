---
metadata_version: 1
uid: DMSScript.Script.Exe-destvar
description: "Reference the DataMiner Automation script schema entry for destvar attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaAutomationScript
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# destvar attribute

Specifies the destination variable.

## Content Type

string

## Parent

[Exe](xref:DMSScript.Script.Exe)

## Remarks

Used with script action of type "get" and "set".

## Examples

The following script action assigns value 10 to script parameter "param1".

```xml
<Exe id="2" type="assign" destvar="param1">
   <Value offset="0">10</Value>
</Exe>
```
