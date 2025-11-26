---
uid: MaintenanceSettings.HTTPS
---

# HTTPS element

Configures DataMiner to use HTTPS. For more information, refer to [Configuring HTTPS settings in DataMiner](xref:Setting_up_HTTPS_on_a_DMA#configuring-https-in-dataminer).

## Parents

[MaintenanceSettings](xref:MaintenanceSettings)

## Attributes

| Name&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; | Type | Required | Description |
| --- | --- | --- | --- |
| [enabled](xref:MaintenanceSettings.HTTPS-enabled) | boolean |  | Specifies whether HTTPS is enabled. |
| [name](xref:MaintenanceSettings.HTTPS-name) | string |  | Must be set to the name matching the Common Name (CN) or one of the Subject Alternative Names (SAN) of the certificate. This name can be a hostname, FQDN, or IP address (as long as it matches the certificate). |

## Examples

```xml
<MaintenanceSettings>
  ...
  <HTTPS enabled="true" name="foo.skyline.local"/>
  ...
</MaintenanceSettings>
```

## See also

- [Configuring HTTPS settings in DataMiner](xref:Setting_up_HTTPS_on_a_DMA#configuring-https-in-dataminer)
