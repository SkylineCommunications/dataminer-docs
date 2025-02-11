---
uid: Skyline.DataMiner.DataSources.OpenConfig.Gnmi_6.x
---

# Skyline.DataMiner.DataSources.OpenConfig.Gnmi Range 6.x

## 6.1.0

#### Prioritize connection to the local CommunicationGateway instance [ID 41784]

Previously, when multiple CommunicationGateway instances were available, the OpenConfig library would randomly select one to establish a connection. Now, the local CommunicationGateway instance will always be prioritized. If the local instance is unavailable, the library will fall back to the discovery process and randomly select another instance.

Minimum required version: [CommunicationGateway 5.1.0](xref:CommunicationGateway_change_log#28-january-2025---enhancement---communicationgateway-510---node-id-has-a-fixed-value-id-41784).

## 6.0.0

#### Update to latest Skyline.DataMiner.DataSources.CommunicationGatewayMiddleware.OpenConfig version [ID 41467]

The OpenConfig library has been updated to the latest *Skyline.DataMiner.DataSources.CommunicationGatewayMiddleware.OpenConfig* version (i.e. 4.0.0).

Minimum required version: [CommunicationGateway 4.0.0](xref:CommunicationGateway_change_log#25-november-2024---enhancement---communicationgateway-400---messagebroker-version-303-id-41467).
