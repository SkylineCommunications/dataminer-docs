---
uid: DataMinerExtensionModules
---

# DataMiner Extension Modules (DxMs)

A DataMiner Extension Module (DxM) is a service that can be installed, upgraded, and uninstalled without the need to reboot the DataMiner Agent. These modules will expand the core DataMiner software with additional features and capabilities. In most cases, DxMs will be backwards-compatible with all supported core DataMiner versions. However, this may not be possible in some cases, and then a minimum core DataMiner version will be indicated. 

## Packs

For ease of installation, DxMs may be packaged together in a pack, such as the [Cloud Pack](xref:CloudPackages). These packs allow users to install several DxMs at once.

## Available DxMs

### CloudGateway

The CloudGateway module is responsible for connecting a DataMiner System to dataminer.services. It manages the identity towards dataminer.services and ensures a secure connection.

### FieldControl

The FieldControl module is responsible for handling incoming requests from dataminer.services. For example, such a request could come from the [DataMiner Teams Bot](xref:DataMiner_Teams_bot) when a user asks it to retrieve the alarms from the system.

This DxM is included in DataMiner upgrade packages from DataMiner 10.3.7/10.4.0 onwards.<!-- RN 36085 -->

### CoreGateway

The CoreGateway module is responsible for translating requests from other modules into requests towards the DataMiner System. This ensures backwards compatibility with different DataMiner versions.

This DxM is included in DataMiner upgrade packages from DataMiner 10.3.7/10.4.0 onwards.<!-- RN 36085 -->

### CloudFeed

The CloudFeed module is responsible for offloading data towards dataminer.services. This setting can be controlled in the [Admin app](xref:Controlling_cloudfeed_data_offloads). Among the data that is offloaded are SPI events and alarm events.

### DataAggregator

See [Data Aggregator](xref:Data_Aggregator_DxM).

### Orchestrator

The Orchestrator module is responsible for management and upgrades of DxMs through the [Admin app](xref:Managing_cloud-connected_nodes).

This DxM is included in DataMiner upgrade packages from DataMiner 10.3.7/10.4.0 onwards.<!-- RN 36085 -->

### ArtifactDeployer

The ArtifactDeployer module is responsible for allowing users to deploy different DataMiner artifacts towards their system. An example of a feature that uses this module is the [deployment of connectors from within the Catalog](xref:Deploying_A_DataMiner_Connector_to_your_system).

This DxM is included in DataMiner upgrade packages from DataMiner 10.3.7/10.4.0 onwards.<!-- RN 36085 -->

### SupportAssistant

The SupportAssistant module is responsible for features allowing Skyline Communications to provide better and faster support.

This DxM is included in DataMiner upgrade packages from DataMiner 10.3.7/10.4.0 onwards.<!-- RN 36085 -->

### ModelHost

The ModelHost module is responsible for allowing users to retrieve parameter relationship data on DataMiner Agents that are connected to dataminer.services and have been configured to [offload alarm and change point events to the cloud](xref:Controlling_cloudfeed_data_offloads).

The ModelHost DxM is not included in the Cloud Pack and [must be deployed separately](xref:Managing_cloud-connected_nodes#deploying-a-dxm-on-a-node).

### UserDefinableApiEndpoint

The UserDefinableApiEndpoint module is responsible for handling API triggers for DataMiner User-Defined APIs. See [DataMiner UserDefinableApiEndpoint DxM](xref:UD_APIs_UserDefinableApiEndpoint).

### CommunicationGateway

The CommunicationGateway module makes it possible for connectors or scripts running in the DataMiner environment to communicate with devices that require a gRPC connection.

At present, we support the [gNMI](xref:DSI_OpenConfig_Introduction#gnmi) service, but more services and RPC connections may be added.

This DxM exists in tandem with service-specific [middleware](xref:Nuget_Communication_Middleware) that facilitates the NATS communication to the DxM. However, not all middleware require the CommunicationGateway to establish a connection with the device. The DxM is primarily used to bridge the gap between different .NET versions. This is because gRPC requires .NET 5 or higher for full functionality, while SLScripting still runs on .NET 4.6.2.

> [!TIP]
> See also: [OpenConfig Middleware](xref:DSI_OpenConfig_Middleware)
