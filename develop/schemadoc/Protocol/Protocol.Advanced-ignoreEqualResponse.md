---
metadata_version: 1
uid: Protocol.Advanced-ignoreEqualResponse
description: "Reference the DataMiner connector protocol schema entry for ignoreEqualResponse attribute, including its documented structure, attributes, values, and con."
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

# ignoreEqualResponse attribute

If you set this attribute to “true”, then a received response will be ignored if it is identical to the response received previously (for the same pair). In other words, the trigger associated with a response will not go off if that response is identical to the previous one.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Advanced](xref:Protocol.Advanced)

## Remarks

Applicable for connections of type "serial", "smart-serial" and "gpib".

> [!CAUTION]
> Use this option with extreme care, as it can have a profound impact on the general behavior of the protocol.
