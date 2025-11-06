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
> Disabling this setting will halt updates to the *Communication Info* table on the *General parameters* page. Connectors will not be able to use bitrate-related notifies such as [NT_GET_BITRATE_DELTA](xref:NT_GET_BITRATE_DELTA).

## Examples

```xml
<Network bitRateTracking="true"/>
```
