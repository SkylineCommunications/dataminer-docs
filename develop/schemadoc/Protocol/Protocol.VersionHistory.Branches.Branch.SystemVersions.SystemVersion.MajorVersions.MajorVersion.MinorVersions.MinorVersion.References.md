---
uid: Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.References
---

# References element

Provides references to e.g., registration systems.

## Parent

[MinorVersion](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***Choice***|||
|&nbsp;&nbsp;[TaskId](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.References.TaskId)|[1, *]|Provides a reference to a corresponding task.|
|&nbsp;&nbsp;[Reference](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.MajorVersions.MajorVersion.MinorVersions.MinorVersion.References.Reference)|[1, *]|Provides a reference to e.g., a registration system.|

## Examples

```xml
<References>
   <TaskId>12345</TaskId>
   <TaskId>45678</TaskId>
   <Reference>Ticket12598</Reference>
   <Reference type="Jira">15895</Reference>
</References>
```
