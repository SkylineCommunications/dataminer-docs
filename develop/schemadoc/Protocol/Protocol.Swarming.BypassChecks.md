---
metadata_version: 1
uid: Protocol.Swarming.BypassChecks
description: "Reference the DataMiner connector protocol schema entry for BypassChecks element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: 10.6.6
owner: unknown
---

# BypassChecks element

Contains all disabled checks that will no longer prevent an element from being able to swarm.

Feature introduced in DataMiner 10.6.6/10.7.0<!-- RN 45173 -->.

## Parent

[Swarming](xref:Protocol.Swarming)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Check](xref:Protocol.Swarming.BypassChecks.Check)|[1, *]|Check that is disabled and will no longer prevent an element from being able to swarm.|
