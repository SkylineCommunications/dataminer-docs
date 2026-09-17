---
metadata_version: 1
uid: Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.References
description: "Reference the DataMiner connector protocol schema entry for References element, including its documented structure, attributes, values, and constraints."
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

# References element

Provides references to, for example, registration systems.

## Parent

[MinorVersion](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***Choice***|||
|&nbsp;&nbsp;[TaskId](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.References.TaskId)|[1, *]|Provides a reference to a corresponding task.|
|&nbsp;&nbsp;[Reference](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.References.Reference)|[1, *]|Provides a reference to, for example, a registration system.|

## Examples

```xml
<References>
   <TaskId>12345</TaskId>
   <TaskId>45678</TaskId>
   <Reference>Ticket12598</Reference>
   <Reference type="Jira">15895</Reference>
</References>
```
