---
metadata_version: 1
uid: Protocol.Swarming.BypassChecks.Check
description: "Reference the DataMiner connector protocol schema entry for Check element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: 10.6.6
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# Check element

Contains the check that is disabled and will no longer prevent an element from being able to swarm.

Feature introduced in DataMiner 10.6.6/10.7.0<!-- RN 45173 -->.

## Type

[EnumSwarmingBypassCheck](xref:Protocol-EnumSwarmingBypassCheck)

## Parent

[BypassChecks](xref:Protocol.Swarming.BypassChecks)

## Remarks

Contains one of the predefined values detailed in the sections below.

### smartSerialAsServer

A smart-serial connection in server mode by default prevents an element from being able to swarm. This check can be ignored when the element is able to configure where the data source should send its data.
