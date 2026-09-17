---
metadata_version: 1
uid: Protocol.Actions.Action.On-id
description: "Reference the DataMiner connector protocol schema entry for id attribute, including its documented structure, attributes, values, and constraints."
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

# id attribute

Specifies the ID of the parameter, command, response, etc.

## Content Type

[TypeSemicolonSeparatedNumbers](xref:Protocol-TypeSemicolonSeparatedNumbers)

## Parent

[Action](xref:Protocol.Actions.Action.On)

## Remarks

In case the `id` attribute is not present and the action is executed from a [Trigger](xref:Protocol.Triggers.Trigger), and the trigger's [On](xref:Protocol.Triggers.Trigger.On) type matches the action's [On](xref:Protocol.Actions.Action.On) type, the action will apply to the specific item that triggered it.
