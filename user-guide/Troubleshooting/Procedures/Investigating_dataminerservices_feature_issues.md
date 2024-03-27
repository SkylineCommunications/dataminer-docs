---
uid: Investigating_Dataminerservices_Feature_Issues
---

# Investigating issues with dataminer.services features

If you encounter issues with [dataminer.services](xref:AboutCloudPlatform) features, please validate that your cloud connection is working as expected by navigating to [dataminer.services](https://dataminer.services/) and selecting the correct organization. If your status is not valid and green, proceed with [troubleshooting your cloud connection](xref:Cloud_Connection_Issues) first.

## Check if all DxMs are running

Many features of dataminer.services rely on DxMs to be running.

You can validate this as follows:

1. Make sure all installed [DxMs](xref:DataMinerExtensionModules) are running:

   1. On each DMA server, go to the Windows *Services* configuration window.

   1. Check whether the DxM services have the status *Running*.

      These services all start with "DataMiner". For example: *DataMiner CloudGateway*, *DataMiner CoreGateway*, etc.

   1. If the status of any of these services is not *Running*, right-click the service and select *Start*.

1. Make sure the most recent versions of the DxMs are installed. See [Upgrading nodes to the latest DxM versions](xref:Managing_cloud-connected_nodes#upgrading-nodes-to-the-latest-dxm-versions).

   This way, you avoid dealing with issues that have already been fixed.

## Validate requirements for Remote Cube

If access to your DMS over Remote Cube is not working in spite of a valid cloud connection, check that all requirements are met as described [in the documentation here](xref:Accessing_DMS_remotely_with_Cube).

If the connection issues still persist, please contact [tech support](https://skyline.be/contact/tech-support).

## Validate internal network configuration

For catalog or DxM deployments from the catalog or admin app to your DataMiner System, there must be at least one ArtifactDeployer in the cluster that can reach a healthy CloudGateway. The same holds true for Remote Log Collection, where a SupportAssistant must be able to reach a healthy CloudGateway in the cluster.
By default, this is configured to be <em>**internally**</em> on TCP port 5100, however this [can be customized per CloudGateway](xref:Custom_cloud_endpoint_configuration). Please make sure the network configuration allows for internal access between nodes on this port.

> [!NOTE]
   > If the button to deploy was not disabled on the Admin app or Catalog in spite of configuration issues, please consider upgrading your DxMs to the latest version to support this functionality and prevent installation failures.

## Contact support

If the connection issues still persist, please contact [tech support](https://skyline.be/contact/tech-support).
