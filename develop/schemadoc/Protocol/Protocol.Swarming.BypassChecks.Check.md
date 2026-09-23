---
metadata_version: 1
uid: Protocol.Swarming.BypassChecks.Check
description: "Reference the DataMiner connector protocol schema entry for Check element, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
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
