---
uid: NuGetStages.Configurations.Configuration
---

# Configuration element

A configuration for NuGet stages.

## Parent

[Configurations](xref:NuGetStages.Configurations)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[scope](xref:NuGetStages.Configurations.Configuration-scope)|[EnumScope](xref:NuGetStages-EnumScope)|Yes|Specifies the scope.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[PackageCreation](xref:NuGetStages.Configurations.Configuration.PackageCreation)||Contains settings related to NuGet package creation.|
|&nbsp;&nbsp;[PackagePublishing](xref:NuGetStages.Configurations.Configuration.PackagePublishing)||Contains settings related to NuGet package publishing.|
|&nbsp;&nbsp;[PackageSigning](xref:NuGetStages.Configurations.Configuration.PackageSigning)||Contains settings related to NuGet package signing.|
