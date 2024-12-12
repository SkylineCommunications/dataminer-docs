---
uid: Protocol.Compliancies.MinimumRequiredVersion
---

# MinimumRequiredVersion element

<!-- RN 12958, RN 13008, RN 13202 -->

Indicates the minimum DataMiner version that the connector is compatible with.

## Type

[TypeDataMinerVersion](xref:Protocol-TypeDataMinerVersion)

## Parent

[Compliancies](xref:Protocol.Compliancies)

## Remarks

If the DataMiner software version is less recent than the indicated version, the protocol will not be uploaded.

> [!NOTE]
> In older DataMiner versions, the 4th digit indicated the week when the release was published. However, in recent versions this is no longer used, so the 4th digit is always 0.

## Example

9.0.3.7 - 5687
