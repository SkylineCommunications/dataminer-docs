---
metadata_version: 1
uid: Protocol.Chains.Chain.Display.Visibility
description: "Reference the DataMiner connector protocol schema entry for Visibility element, including its documented structure, attributes, values, and constraints."
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

# Visibility element



## Parent

[Display](xref:Protocol.Chains.Chain.Display)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[default](xref:Protocol.Chains.Chain.Display.Visibility-default)|||Specifies the default visibility when none of the conditions are met (Default: true).|

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Standalone](xref:Protocol.Chains.Chain.Display.Visibility.Standalone)|[1, *]|Specifies the values the specified parameter must have to toggle the visibility to the opposite setting of the one defined in the default attribute.|
