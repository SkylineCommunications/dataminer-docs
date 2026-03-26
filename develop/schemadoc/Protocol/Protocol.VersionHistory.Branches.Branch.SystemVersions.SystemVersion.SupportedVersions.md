---
uid: Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.SupportedVersions
---

# SupportedVersions element

Specifies the system version support.

## Parent

[SystemVersion](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Version](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion.SupportedVersions.Version)|[1, *]||

## Remarks

This will contain all relevant version support information of systems this protocol interacts with (e.g., firmware information).



## Examples


```xml
<SupportedVersions>
                                                      <Version min="1.0" max="3.0">Firmware</Version>
                                                      <Version min="4b">Hardware</Version>
                                                      <Version min="4" max="7">SQL</Version>
                                                    </SupportedVersions>
```



