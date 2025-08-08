---
uid: investigating_dataminer_services_feature_issues
description: Check the cloud connection, check if all DxMs are OK, check if requirements are met, and validate the internal network configuration.
keywords: cloud issues, cloud connection, connect to the cloud, connecting to the cloud
---

# Investigating issues with dataminer.services features

## Check the connection to dataminer.services

If you encounter issues with [dataminer.services](xref:about_dataminer_services) features, first validate that your connection to dataminer.services is working as expected.

To do so, navigate to [dataminer.services](https://dataminer.services/) and select the correct organization. If the status of the DMS is not valid and green, follow the troubleshooting procedures under [Investigating dataminer.services connection issues](xref:Cloud_Connection_Issues).

## Check if all DxMs are running and up to date

Many features of dataminer.services rely on [DxMs](xref:DataMinerExtensionModules) that have to be running on the DataMiner Agents.

You can validate this as follows:

1. On each DMA server, go to the Windows *Services* configuration window.

1. Check whether the DxM services have the status *Running*.

   These services all start with "DataMiner". For example: *DataMiner CloudGateway*, *DataMiner CoreGateway*, etc.

1. If the status of any of these services is not *Running*, right-click the service and select *Start*.

1. Open the Admin app and [make sure the most recent versions of the DxMs are installed](xref:Managing_cloud-connected_nodes#upgrading-nodes-to-the-latest-dxm-versions).

   This way, you avoid dealing with issues that have already been fixed.

> [!NOTE]
> If any of the DxMs are missing that are required for the upgrade from the Admin app to work, download and install the [latest Cloud Pack](https://aka.dataminer.services/cloud-pack-download) to install these manually.

## Make sure the requirements to access the DMS remotely are met

If your connection to dataminer.services is valid, but you are still unable to access your DMS remotely with DataMiner Cube, check whether all requirements are met, as detailed under [Accessing your DMS remotely with DataMiner Cube](xref:Accessing_DMS_remotely_with_Cube).

If the issues still persist, [contact DataMiner Support](xref:Contacting_tech_support).

## Validate the internal network configuration

To deploy items from the Catalog or deploy DxMs from the Admin app, there must be at least one DMA in the cluster where the ArtifactDeployer is deployed and able to reach a correctly functioning CloudGateway DxM in the cluster.

Similarly, for the Remote Log Collection feature, the SupportAssistant DxM must be able to reach a correctly functioning CloudGateway DxM in the cluster.

By default, the **internal** communication within the DMS uses TCP port 5100; however, this [can be customized per CloudGateway instance](xref:Custom_cloud_endpoint_configuration). Make sure the network configuration allows for internal access between nodes on the configured port.

> [!NOTE]
> If the button to deploy is not disabled in the Admin app or Catalog in spite of configuration issues, [make sure your DxMs are upgraded](xref:Managing_cloud-connected_nodes#upgrading-nodes-to-the-latest-dxm-versions) to the latest version to support this functionality and prevent installation failures.

## Contact support

If you have tried the procedures above, but the issues still persist, [contact DataMiner Support](xref:Contacting_tech_support).
