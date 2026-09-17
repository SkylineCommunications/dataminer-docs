---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.Exceptions.Exception.Display-state
description: "Reference the DataMiner connector protocol schema entry for state attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
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

# state attribute

Displays the parameter displayed in gray when set to "disabled".

The default state is "enabled".

## Content Type

[EnumDisplayState](xref:Protocol-EnumDisplayState)

## Parent

[Display](xref:Protocol.Params.Param.Interprete.Exceptions.Exception.Display)

## Remarks

To emphasize the rare condition of the parameter, you can set the state attribute to “disabled” to have the parameter displayed in gray.

## Examples

```xml
<Display state="disabled">Default Sweep Width</Display>
```
