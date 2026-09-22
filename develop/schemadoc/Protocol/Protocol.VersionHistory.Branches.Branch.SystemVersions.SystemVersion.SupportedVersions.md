---
metadata_version: 1
uid: Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.SupportedVersions
description: "Reference the DataMiner connector protocol schema entry for SupportedVersions element, including its documented structure, attributes, values, and constra."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# SupportedVersions element

Specifies the system version support.

## Parent

[SystemVersion](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion)

## Children

|Name|Occurrences|Description|
|--- |---------- |---------- |
|&nbsp;&nbsp;[Version](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.SupportedVersions.Version)|[1, *]||

## Remarks

This will contain all relevant version support information of systems this protocol interacts with (e.g., firmware information).

## Examples

```xml
<SupportedVersions>
    <Version min="10.4.0.0">DataMiner</Version>
    <Version min="1.0" max="3.0">Firmware</Version>
    <Version min="4b">Hardware</Version>
    <Version min="4" max="7">SQL</Version>
</SupportedVersions>
```
