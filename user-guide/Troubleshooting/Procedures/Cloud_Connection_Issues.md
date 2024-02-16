---
uid: Cloud_Connection_Issues
---

# Investigating dataminer.services connection issues

If you encounter issues with [dataminer.services](xref:AboutCloudPlatform) features that may be caused by connection issues, follow the actions below in the specified order:

1. [Check the status of the DxMs](#check-the-status-of-the-dxms).
1. [Check the status of the DMS](#check-the-status-of-the-dms).
1. [Check the cloud session](#check-the-cloud-session)
1. [Make sure requirements are met](#make-sure-requirements-are-met)

## Check the status of the DxMs

A common cause for issues with dataminer.services features is a problem with the connection from the [DxMs](xref:DataMinerExtensionModules) towards dataminer.services.

You can resolve this as follows:

1. Make sure all installed [DxMs](xref:DataMinerExtensionModules) are running:

   1. On each DMA server, go to the Windows *Services* configuration window.

   1. Check whether the DxM services have the status *Running*.

      These services all start with "DataMiner". For example: *DataMiner ArtifactDeployer*, *DataMiner CoreGateway*, etc.

   1. If the status of any of these services is not *Running*, right-click the service and select *Start*.

1. Make sure the most recent versions of the DxMs are installed. See [Upgrading nodes to the latest DxM versions](xref:Managing_cloud-connected_nodes#upgrading-nodes-to-the-latest-dxm-versions).

   This way, you avoid dealing with issues that have already been fixed.

## Check the status of the DMS

For each DMA that should be connected, verify whether the DMA is operational and accessible:

1. In the `C:\Skyline DataMiner\` folder of a DMA that should be connected, open the file *MaintenanceSettings.xml*.

1. Copy the address specified in the *name* attribute of the *HTTPS* tag. For example:

   ```xml
   <MaintenanceSettings>
       ...
       <HTTPS enabled="true" name="foo.skyline.local"/>
       ...
   </MaintenanceSettings>
   ```

   > [!TIP]
   > See also: [Configuring HTTPS in DataMiner](xref:Setting_up_HTTPS_on_a_DMA#configuring-https-in-dataminer)

1. Open a browser and navigate to the address you have just copied.

   - If the page loads correctly, this indicates that the DMA host is locally accessible, but there may be an issue with the proxy or DMZ settings. Check the configuration described under [Connecting to dataminer.services via proxy server](xref:Connect_to_cloud_via_proxy) or [Connecting to dataminer.services with a DMZ setup](xref:Connect_to_cloud_with_DMZ) to resolve this.

   - If the page does not load correctly, this indicates a problem with the DMA host. Restart the DMA to resolve this. You can do so using the [DataMiner Taskbar Utility](xref:DataMiner_Taskbar_Utility).

## Check the cloud session

Manually renewing the cloud identity can be necessary if dataminer.services could not renew its tokens automatically for too long. This can for example happen if no internet access was available for an extended period (usually minimum 3 days).

1. In DataMiner Cube, go to *System Center* > *Cloud*

1. Check whether *Cloud identity* or *Cloud Session* is indicated as valid (the UI description depends on your DataMiner version<!-- RN 38715 -->).

1. If it is no longer valid, click the *Renew Session* button.

   > [!NOTE]
   > This button is only available if the cloud identity has expired. It is also only available for users who have the [*Owner* or *Admin* role](xref:Changing_the_role_of_a_DCP_user) in the DMS.

## Make sure requirements are met

If none of the previous steps solved the problem, make sure that all [requirements](xref:Accessing_DMS_remotely_with_Cube) for remote access are fulfilled.

If the issue still persists even though all requirements are met, contact [tech support](https://skyline.be/contact/tech-support).
