---
uid: Manifest.MinimumRequiredVersions.MinimumRequiredVersion
---

# MinimumRequiredVersion element

This field can be used to define a minimum required version.

## Parent

[MinimumRequiredVersions](xref:Manifest.MinimumRequiredVersions)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[key](xref:Manifest.MinimumRequiredVersions.MinimumRequiredVersion-key)|[TypeMinimumRequiredVersionKeys](xref:Manifest-TypeMinimumRequiredVersionKeys)|true|Specifies what the minimum required version is for.|
|[value](xref:Manifest.MinimumRequiredVersions.MinimumRequiredVersion-value)|[TypeNonEmptyString](xref:Manifest-TypeNonEmptyString)|true|Specifies what the minimum required version is.|

> [!NOTE]
> Only the following key is suppored for now: DataMiner. The value should represent the minimum required DataMiner for the package to work. The format should look like: 10.4.5.0-14225.
