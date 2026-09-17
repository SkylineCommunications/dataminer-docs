---
metadata_version: 1
uid: LogicActionRead
description: "Describe the DataMiner connector development topic read, including its purpose, behavior, implementation guidance, and relevant constraints."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
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

# read

Can be executed on parameters and responses.

## On parameter

This action will read the specified parameter.

> [!NOTE]
> This action has to be triggered from a Trigger that triggers on response.

## On response

This action will read the specified response.

Use this command if the response contains parameters of which the length is set to "next param".

### Attributes

#### On@id

Specifies the ID(s) of the responses to read.

## Examples

```xml
<Action id="608">
   <Name>Read Response 508</Name>
   <On id="508">response</On>
   <Type>read</Type>
</Action>
```
