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

### DataAggregator

See [Data Aggregator](xref:Data_Aggregator_DxM).

### Orchestrator

The Orchestrator module is responsible for management and upgrades of DxMs through the [Admin app](xref:Managing_cloud-connected_nodes).

### ArtifactDeployer

The ArtifactDeployer module is responsible for allowing users to deploy different DataMiner artifacts towards their system. An example of a feature that uses this module is the [deployment of connectors from within the Catalog](xref:Deploying_A_DataMiner_Connector_to_your_system).

### SupportAssistant

The SupportAssistant module is responsible for features allowing Skyline Communications to provide better and faster support.

### ModelHost

The ModelHost module is responsible for allowing users to retrieve parameter relationship data on DataMiner Agents that are connected to dataminer.services, and have been configured to [offload alarm and change point events to the cloud](xref:Controlling_cloudfeed_data_offloads).

The ModelHost module is not included in the Cloud Pack and must be deployed separately. Follow the steps in [deploying modules](#deploying-modules).

### UserDefinableApiEndpoint

The UserDefinableApiEndpoint module is responsible for handling API triggers for user-defined APIs. See [DataMiner UserDefinableApiEndpoint DxM](xref:UD_APIs_UserDefinableApiEndpoint).

### CommunicationGateway

This module enables connectors or scripts running in the DataMiner environment to communicate with devices that require a gRPC connection. Currently we support the [gNMI](xref:DSI_OpenConfig_Introduction#gnmi) service, but more services and RPC connections may be added.

The DxM exists in tandem with service-specific [middleware](xref:Nuget_Communication_Middleware) that facilitates the NATS communication to the DxM. However, not all middleware require the CommunicationGateway to establish a connection with the device. The DxM primarily exists to bridge the gap between different dotNet versions. Namely, gRPC requires dotNet 5 or higher for full functionality, while SLScripting still runs on dotNet 4.6.2.

#### Prerequisites

* The DxM needs to be installed on a Windows system running a DataMiner Agent.
* DataMiner version 10.3.3 or higher is required for connectors that rely on the DxM. The DataMinerMessageBroker.API.dll is shared with all processes, and version 1.4.2 is required for the NATS communication.

#### Getting started

1. Deploy the CommunicationGateway DxM by following the steps in [deploying modules](#deploying-modules).
1. After the installation, the DxM should run as a service. Logging will be written to `C:\ProgramData\Skyline Communications\DataMiner CommunicationGateway\Logs`.

## Deploying modules

1. Open the Admin app. See [Accessing the Admin app](xref:Accessing_the_Admin_app).

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

1. If a different organization should be selected, click the organization selector ![organization selector](~/user-guide/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. In the pane on the left, under *DataMiner Systems*, select your DataMiner System and select the *Nodes* page.

1. Next to your module of choice, e.g. *ModelHost*, click *Deploy* to start the automatic installation process.

