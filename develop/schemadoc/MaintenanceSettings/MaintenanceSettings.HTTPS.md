---
uid: MaintenanceSettings.HTTPS
---

# HTTPS element

Configures DataMiner to use HTTPS. For more information, refer to [Configuring HTTPS settings in DataMiner](xref:Setting_up_HTTPS_on_a_DMA#configuring-https-in-dataminer)

## Parents

[MaintenanceSettings](xref:MaintenanceSettings)

## Attributes

| Name&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; | Type | Required | Description |
| --- | --- | --- | --- |
| [enabled](xref:MaintenanceSettings.HTTPS-enabled) | boolean |  | Specifies whether HTTPS is enabled. |
| [name](xref:MaintenanceSettings.HTTPS-name) | anySimpleType |  | Must be set to a name matching the Common Name (CN) or one of the Subject Alternative Names (SAN) of the certificate. If it is a wildcard certificate, the name must match the mask defined in the certificate (e.g. "*.skyline.local"). For example, "dma01.skyline.be" matches the wildcard certificate for "*.skyline.be". |

## Examples

```xml
<MaintenanceSettings>
  ...
  <HTTPS enabled="true" name="foo.skyline.local"/>
  ...
</MaintenanceSettings>
```

## Remarks

See [Configuring HTTPS settings in DataMiner](xref:Setting_up_HTTPS_on_a_DMA#configuring-https-in-dataminer).
