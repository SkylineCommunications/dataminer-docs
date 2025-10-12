---
uid: MaintenanceSettings.Network-bitRateTracking
---

# bitRateTracking attribute

Enables or disables the bitrate calculations performed by SLProtocol.

## Content Type

boolean

## Parents

[Network](xref:MaintenanceSettings.Network)

## Remarks

> [!NOTE]
> Disabling this setting will halt updates to the *Communication Info* table on the *General parameters* page. Bitrate-related notifies such as [NT_GET_BITRATE_DELTA](xref:NT_GET_BITRATE_DELTA) will not be usable by connectors.

## Examples

```xml
<Network bitRateTracking="true"/>
```
