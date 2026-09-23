---
metadata_version: 1
uid: DMSScript.Script.Exe.Template
description: "Reference the DataMiner Automation script schema entry for Template element, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# Template element

Specifies the name of the template.

## Type

[NonEmptyStringType](xref:Automation-NonEmptyStringType)

## Parent

[Exe](xref:DMSScript.Script.Exe)

## Remarks

Used in script actions of type "report".

## Examples

```xml
<Exe id="3" type="report">
   <Template>test</Template>
   <Destination type="email" title="q" cc="" bcc="">dest@comp.com;</Destination>
   <Message></Message>
</Exe>
```
