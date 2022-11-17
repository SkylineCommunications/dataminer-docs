---
uid: CloudPackages
---

# DataMiner Cloud Packs

DataMiner Cloud Packs are packages that include the necessary DataMiner Extension Modules to enable DataMiner Cloud Platform capabilities.
At the moment there are two different Cloud Packs available; one for DMAs with internet access and one for DMAs that do not have connectivity towards the internet. The type of pack will determine which DataMiner Extension Modules will be installed on the DMA.

## Types of Cloud Packs

### For DMAs with internet connectivity

This is the standard DataMiner Cloud Pack that can be downloaded from [DataMiner Dojo](https://community.dataminer.services/downloads/). This pack will include all of the DataMiner extension modules that are necessary to use the DataMiner Cloud services. After installing this pack on one of your DMAs that has internet connectivity you will already be able to benefit from the services offered by the DataMiner Cloud Platform.

### For DMAs without internet connectivity

> [!WARNING]
> This pack has not yet been released.

This Pack will hold the DataMiner Extension Modules that do not need internet functionality to operate.

Included modules:

* CoreGateway
* FieldControl
* Orchestrator
* SupportAssistant

> [!NOTE]
> You will always need to install the standard DataMiner Cloud Pack on at least one DMA with internet connectivity before you can use the services offered by the DataMiner Cloud Platform.

## DataMiner Extension Modules

More information on DataMiner Extension Modules can be found [here](xref:DataMinerExtensionModules).

### CloudGateway

The CloudGateway is the module that will connect the DataMiner System with the DataMiner Cloud Platform (DCP). It manages the identity towards the DCP and ensures a secure connection.

### FieldControl

The FieldControl is responsible for handling incoming requests from the DCP. One of those requests could be coming from the Teams bot where a user wants to get the alarms from the system.

### CoreGateway

The CoreGateway is the module that translates requests coming from other modules into requests towards the DataMiner System. This allows us to ensure backwards compatibility with different DataMiner versions.

### CloudFeed

The CloudFeed takes care of the data offload towards the DCP. This setting can be controlled in the [DCP Admin app](xref:Controlling_cloudfeed_data_offloads). Among the data that is being offloaded are SPI events and Alarm events.

### Orchestrator

The Orchestrator enables management and upgrades of the DxMs through the [DCP Admin app](xref:Managing_cloud-connected_nodes).

### ArtifactDeployer

The ArtifactDeployer enables users to deploy different DataMiner artifacts towards their system. An example of a feature that uses this module is the [deployment of Connectors from within the Catalog](xref:Deploying_A_DataMiner_Connector_to_your_system).

### SupportAssistant

The SupportAssistant contains features to allow Skyline Communications to provide better and faster support.
