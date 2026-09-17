---
metadata_version: 1
uid: Protocol.Commands
description: "Reference the DataMiner connector protocol schema entry for Commands element, including its documented structure, attributes, values, and constraints."
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

# Commands element

Contains all commands defined in the protocol.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Command](xref:Protocol.Commands.Command)|[0, *]|Defines a complete command.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The ID of a command must be unique. |Command |@id |
|Unique |The name of a command must be unique. |Command |dis:Name |

## Remarks

Commands are sent from DataMiner to the data source:

- to request information from the data source, or
- to change a setting of the data source.
