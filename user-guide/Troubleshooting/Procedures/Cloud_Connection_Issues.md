---
uid: Cloud_Connection_Issues
---

# Investigating dataminer.services connection issues

If you encounter issues with [dataminer.services](xref:AboutCloudPlatform) features that may be caused by connection issues, follow the actions below in the specified order:

1. [Check the connection status on dataminer.services](#check-the-status-on-dataminerservices)
1. [Check the status of the DMS](#check-the-status-of-the-dms)
1. [Check the status of the CloudGateway DxM](#check-the-status-of-the-cloudgateway-dxm)
1. [Check the cloud session](#check-the-cloud-session)
1. [Contact support](#contact-support)

## Check the status on dataminer.services

When you navigate to [dataminer.services](https://dataminer.services/), you can check the connection status per DMS in your organization:

- An **orange** status indicates that the Cloud Gateway cannot reach the DataMiner System, but the dataminer.services connection is valid.

  If the status is orange, verify whether the DataMiner Agents are up and running and have the proper configuration. See [Check the status of the DMS](#check-the-status-of-the-dms).

- A **red** status indicates that there is no valid connection to dataminer.services.

  If the status is red, [check the status of the CloudGateway DxM](#check-the-status-of-the-cloudgateway-dxm).

- A **green** status indicates that the dataminer.services connection is valid.

  If the status is green, but you are still encountering issues with [dataminer.services](xref:AboutCloudPlatform) features, refer to [Investigating dataminer.services feature issues](xref:Investigating_Dataminerservices_Feature_Issues).

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

## Check the status of the CloudGateway DxM

If the connection status is shown as red on [dataminer.services](https://dataminer.services/), validate that at least one CloudGateway instance is running in the cluster and that it can establish a connection towards dataminer.services:

1. On the DMA servers, go to the Windows *Services* configuration window.

1. Check whether the *DataMiner CloudGateway* service has the status *Running*.

1. If the status is not *Running*, right-click the service and select *Start*.

If there is a CloudGateway instance running, but the dataminer.services connection is still not valid, validate whether your network complies with the requirements for connecting to dataminer.services using the *ConnectionTester.exe* tool from the folder `Program files\Skyline Communications\Dataminer CloudGateway\`. More information on the requirements can be found 

If results indicate that the network and firewall configuration are OK, [check the cloud session](#check-the-cloud-session).

## Check the cloud session

Manually renewing the cloud identity can be necessary if dataminer.services could not renew its tokens automatically for too long. This can for example happen if no internet access was available for an extended period (usually minimum 3 days).

1. In DataMiner Cube, go to *System Center* > *Cloud*.

1. Check whether *Cloud identity* or *Cloud Session* is indicated as valid (the UI description depends on your DataMiner version<!-- RN 38715 -->).

1. If it is no longer valid, click the *Renew Session* button.

   > [!NOTE]
   > This button is only available if the cloud identity has expired. It is also only available for users who have the [*Owner* or *Admin* role](xref:Changing_the_role_of_a_DCP_user) in the DMS.

## Contact support

If the connection issues still persist, contact [tech support](https://skyline.be/contact/tech-support).
