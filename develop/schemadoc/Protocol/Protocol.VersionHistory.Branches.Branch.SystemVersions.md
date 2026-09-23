---
metadata_version: 1
uid: Protocol.VersionHistory.Branches.Branch.SystemVersions
description: "Consult the DataMiner connector protocol schema reference for the SystemVersions element, which lists unique system version entries for a protocol branch."
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
