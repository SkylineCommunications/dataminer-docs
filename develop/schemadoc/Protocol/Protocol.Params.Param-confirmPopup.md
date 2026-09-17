---
metadata_version: 1
uid: Protocol.Params.Param-confirmPopup
description: "Reference the DataMiner connector protocol schema entry for confirmPopup attribute, including its documented structure, attributes, values, and constraint."
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

# confirmPopup attribute

<!-- RN 11133 -->

Overrides the *Never ask for confirmation after setting parameter value* setting in DataMiner Cube. (See [Cube settings](xref:User_settings#cube-settings).)

## Content Type

[EnumParamConfirmPopup](xref:Protocol-EnumParamConfirmPopup)

## Parent

[Param](xref:Protocol.Params.Param)

## Examples

```xml
<Param id="1" confirmPopup="always">
```
