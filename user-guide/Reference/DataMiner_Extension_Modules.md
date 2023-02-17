---
uid: DataMinerExtensionModules
---

# DataMiner Extension Modules (DxMs)

A DataMiner Extension Module (DxM) is a service that can be installed, upgraded and uninstalled without the need to reboot the DataMiner Agent. These modules will expand the core DataMiner software with additional features and capabilities.

## Packs

For ease of installation, DxMs may be packaged together in a pack, such as the [Cloud Pack](xref:CloudPackages). These packs allow users to install several DxMs at once.

## Available DxMs

### CloudGateway

The CloudGateway module is responsible for connecting a DataMiner System to dataminer.services. It manages the identity towards dataminer.services and ensures a secure connection.

### FieldControl

The FieldControl module is responsible for handling incoming requests from dataminer.services. For example, such a request could come from the [DataMiner Teams Bot](xref:DataMiner_Teams_bot) when a user asks it to retrieve the alarms from the system.

### CoreGateway

The CoreGateway module is responsible for translating requests from other modules into requests towards the DataMiner System. This ensures backwards compatibility with different DataMiner versions.

### CloudFeed

The CloudFeed module is responsible for offloading data towards dataminer.services. This setting can be controlled in the [Admin app](xref:Controlling_cloudfeed_data_offloads). Among the data that is offloaded are SPI events and alarm events.

### Orchestrator

The Orchestrator module is responsible for management and upgrades of DxMs through the [Admin app](xref:Managing_cloud-connected_nodes).

### ArtifactDeployer

The ArtifactDeployer module is responsible for allowing users to deploy different DataMiner artifacts towards their system. An example of a feature that uses this module is the [deployment of connectors from within the Catalog](xref:Deploying_A_DataMiner_Connector_to_your_system).

### SupportAssistant

The SupportAssistant module is responsible for features allowing Skyline Communications to provide better and faster support.

### Modelhost

The Modelhost module is responsible for allowing users to retrieve parameter relationship data on DataMiner Agents that are connected to dataminer.services, and have been configured to [offload alarm and change point events to the cloud](xref:Controlling_cloudfeed_data_offloads).
