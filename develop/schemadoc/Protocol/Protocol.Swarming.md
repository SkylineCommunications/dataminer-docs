---
metadata_version: 1
uid: Protocol.Swarming
description: "Learn how the Swarming element overrides default swarming eligibility by grouping checks that DataMiner should ignore."
---

# Swarming element

Contains the functionality to override the default swarming behavior.

Feature introduced in DataMiner 10.6.6/10.7.0<!-- RN 45173 -->.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[BypassChecks](xref:Protocol.Swarming.BypassChecks)|[0, 1]|Contains all disabled checks that will no longer prevent an element from being able to swarm.|
