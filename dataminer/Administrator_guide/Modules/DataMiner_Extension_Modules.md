---
uid: DataMinerExtensionModules
description: DxMs are modules that expand the core DataMiner software with additional capabilities. They do not require a DMA reboot for (un)installation/upgrades.
---

# DataMiner Extension Modules (DxMs)

## About DxMs

A DataMiner Extension Module (DxM) is an independently versioned service that can be installed, upgraded, and uninstalled without rebooting the DataMiner Agent. DxMs extend the core DataMiner software with additional features and capabilities. DxMs can be [added through the Admin app](xref:Managing_cloud-connected_nodes#deploying-a-dxm-on-a-dms-node) and through DataMiner upgrade packages. In most cases, DxMs are backward-compatible with all supported core DataMiner versions. In cases where this is not possible, a minimum required core DataMiner version is indicated.

When you trigger a DxM update via the Admin app, any dependencies (typically the required .NET version) are indicated.

> [!TIP]
> If you are looking for information on DataMiner modules included in the core upgrades, refer to [DataMiner Core Modules (DcMs)](xref:DataMinerCoreModules).

## Packs

For ease of installation, DxMs may be packaged together in a pack, such as the [Cloud Pack](xref:DataMiner_Cloud_Pack). These packs allow users to install several DxMs at once.

## Available DxMs

### CloudGateway

The CloudGateway module is responsible for connecting a DataMiner System to dataminer.services. It manages the identity towards dataminer.services and ensures a secure connection.

This DxM is included in DataMiner upgrade packages from DataMiner 10.5.9/10.6.0 onwards<!--RN 43205-->. However, the DxM will only be upgraded if an older version is found on the DMA. If no older version is found, it will not be installed.

### CloudFeed

The CloudFeed module is responsible for offloading data towards dataminer.services. This setting can be controlled in the [Admin app](xref:Controlling_cloudfeed_data_offloads). Among the data that is offloaded are alarm events, change point events, SRM events, element configuration events, and feedback events.

From CloudFeed version 1.4.0 onwards, the minimum required DataMiner version is DataMiner 10.4.10.<!-- RN 40413 -->

From DataMiner 10.5.0/10.5.1 onwards<!--RN 41357-->, DataMiner upgrade packages by default include the latest version of the CloudFeed module. If a newer version of the CloudFeed module is available but you prefer not to install an upgrade package, you can install a newer version separately via the Admin app.

### CommunicationGateway

The CommunicationGateway module makes it possible for connectors or scripts running in the DataMiner environment to communicate with devices that require a gRPC connection.

At present, we support the [gNMI](xref:DSI_OpenConfig_Introduction#gnmi) service, but more services and RPC connections may be added.

This DxM exists in tandem with service-specific [middleware](xref:Nuget_Communication_Middleware) that facilitates the NATS communication to the DxM. However, not all middleware require the CommunicationGateway to establish a connection with the device. The DxM is primarily used to bridge the gap between different .NET versions. This is because gRPC requires .NET 5 or higher for full functionality, while SLScripting still runs on .NET 4.6.2.

> [!TIP]
> See also: [OpenConfig Middleware](xref:DSI_OpenConfig_Middleware)

### DataMiner Assistant

The DataMiner Assistant module extends DataMiner with conversational AI. For more information, see [DataMiner Assistant DxM](xref:Assistant_DxM).

> [!NOTE]
> Prior to version 2.0.0, this DxM is called "Copilot".

### DataAggregator

See [Data Aggregator](xref:Data_Aggregator_DxM).

### DataAPI

The DataAPI module provides an HTTP interface that accepts requests with a JSON-formatted body. When required, it creates an element to store values extracted from the JSON payload.

In combination with the DataAggregator DxM, the DataAPI DxM is required for the [Data Sources](xref:Data_Sources) module.

This DxM is included in DataMiner upgrade packages from DataMiner 10.5.11/10.6.0 onwards. However, the DxM will only be upgraded if an older version is found on the DMA. If no older version is found, it will not be installed.<!-- RN 43677 -->

### ModelHost

The ModelHost module is responsible for allowing users to retrieve parameter relationship data on DataMiner Agents that are connected to dataminer.services and have been configured to [offload alarm and change point events to the cloud](xref:Controlling_cloudfeed_data_offloads).

The ModelHost DxM is not included in the Cloud Pack and [must be deployed separately](xref:Managing_cloud-connected_nodes#deploying-a-dxm-on-a-dms-node). However, once it has been deployed, it gets upgraded when you install DataMiner upgrades from DataMiner 10.5.7/10.6.0 onwards.<!-- RN 42896 -->

### SiteManager

The SiteManager module is used to set up secure communication tunnels enabling access to on-premises data sources from a DaaS system. It is supported from DataMiner 10.5.10/10.5.0 onwards and is included in the 10.5.10 DaaS image.

For more information, refer to [Edge Manager](xref:EdgeManagerOverview).

## Logging

If you encounter any issues with a DxM, consult the log files for errors and warnings. By default, you can find these in the following folder: `C:\ProgramData\Skyline Communications\<DxM>\Logs`.
