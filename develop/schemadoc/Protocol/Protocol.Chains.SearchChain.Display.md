---
metadata_version: 1
uid: Protocol.Chains.SearchChain.Display
description: "Reference the DataMiner connector protocol schema entry for Display element, including its documented structure, attributes, values, and constraints."
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

# Display element

<!-- RN 29640, RN 29656 -->

Configures search chain display settings.

## Parent

[SearchChain](xref:Protocol.Chains.SearchChain)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Visibility](xref:Protocol.Chains.SearchChain.Display.Visibility)|||

## Examples

```xml
<Chain>
   <Display>
      <Visibility default="false">
         <Standalone pid="8">
            <Value>1</Value>
            <Value>2</Value>
         </Standalone>
      </Visibility>
   </Display>
</Chain>
```
