---
metadata_version: 1
uid: Protocol.Type-options
description: "Reference the DataMiner connector protocol schema entry for options attribute, including its documented structure, attributes, values, and constraints."
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

# options attribute

Specifies a number of options.

## Content Type

string

## Parent

[Type](xref:Protocol.Type)

## Remarks

The following options are available:

| Option | Description |
|--|--|
| unicode | Specify this option if the protocol is a Unicode protocol. Protocols of this type support Unicode languages like Chinese, Arabic, etc. If a MySQL database is used, and you turn an existing protocol of type "ascii" into a protocol of type "unicode", then all existing data will be lost. To have a better understanding of the inner workings of Unicode, refer to [Code pages](xref:AdvancedCodePages). |
| disableViewRefresh | Use this option to disable updates of view tables and partial subscriptions.<!-- RN 5137 --> |
| exportProtocol | [name of protocol to be created]:[table parameter ID] <br>If you want to define multiple protocols, use the exportProtocol option multiple times (separated by semicolons). Add `:noElementPrefix` to leave out the parent element name in the virtual element name.<br>For example: `exportProtocol:Workflow Server:100:noElementPrefix` |
