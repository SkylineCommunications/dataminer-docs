---
metadata_version: 1
uid: Protocol.VersionHistory.Branches.Branch.SystemVersions
description: "Reference the DataMiner connector protocol schema entry for SystemVersions element, including its documented structure, attributes, values, and constraint."
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

# SystemVersions element

Contains the different SystemVersion entries.

## Parent

[Branch](xref:Protocol.VersionHistory.Branches.Branch)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[SystemVersion](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion)||Defines a SystemVersion entry.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The ID of the system versions for a specific branch must be unique. |SystemVersion |@id |
