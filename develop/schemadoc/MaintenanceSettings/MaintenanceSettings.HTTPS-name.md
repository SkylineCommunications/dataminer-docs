---
uid: MaintenanceSettings.HTTPS-name
---

# name attribute

Must be set to a name matching the Common Name (CN) or one of the Subject Alternative Names (SAN) of the certificate. If it is a wildcard certificate, the name must match the mask defined in the certificate (e.g., "*.skyline.local"). For example, "dma01.skyline.be" matches the wildcard certificate for "*.skyline.be".

## Content Type

anySimpleType

## Parents

[HTTPS](xref:MaintenanceSettings.HTTPS)

## Remarks

This name **also has to be configured in the DNS server** pointing to the IP address of the DMA, so that the DMA can be reached using the configured name.

> [!IMPORTANT]
> Do not use wildcard certificates if you want to use your DataMiner Agent to connect your system to dataminer.services, as this is not supported. In that case, the certificate should be for the FQDN (e.g., "dma01.skyline.be").
