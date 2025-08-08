---
uid: Cloud_Connection_Issues
description: In the specified order, check the connection status on dataminer.services, the status of the DMS, the CloudGateway status, and the cloud session.
keywords: cloud connection, connect to the cloud, connecting to the cloud
---

# Investigating dataminer.services connection issues

If you encounter issues with [dataminer.services](xref:about_dataminer_services) features that may be caused by connection issues, follow the actions below in the specified order:

1. [Make sure the installed DxMs are up to date](#make-sure-the-installed-dxms-are-up-to-date)
1. [Check the status on dataminer.services](#check-the-status-on-dataminerservices)
1. [Check the status of the DMS](#check-the-status-of-the-dms)
1. [Check the status of the CloudGateway DxM](#check-the-status-of-the-cloudgateway-dxm)
1. [Check the cloud session](#check-the-cloud-session)
1. [Contact support](#contact-support)

## Make sure the installed DxMs are up to date

Often when issues are encountered, these have already been fixed in the latest versions of the DataMiner DxMs, so updating the DxMs may be enough to resolve the issues.

If you are unable to connect to dataminer.services to [deploy the DxM updates](xref:Managing_cloud-connected_nodes#upgrading-nodes-to-the-latest-dxm-versions) from the Admin app, download and install the latest version of the [DataMiner Cloud Pack](https://community.dataminer.services/dataminer-cloud-pack/) on the DMAs with connection issues.

## Check the status on dataminer.services

When you navigate to [dataminer.services](https://dataminer.services/), you can check the connection status for each DMS in your organization, if you are a member of this DMS:

- An **orange** status indicates that the Cloud Gateway cannot reach the DataMiner System, but the dataminer.services connection is valid.

  If the status is orange, verify whether the DataMiner Agents are up and running and have the proper configuration. See [Check the status of the DMS](#check-the-status-of-the-dms).

- A **red** status indicates that there is no valid connection to dataminer.services.

  If the status is red, [check the status of the CloudGateway DxM](#check-the-status-of-the-cloudgateway-dxm).

- A **green** status indicates that the dataminer.services connection is valid.

  If the status is green, but you are still encountering issues with [dataminer.services](xref:about_dataminer_services) features, refer to [Investigating dataminer.services feature issues](xref:investigating_dataminer_services_feature_issues).

> [!IMPORTANT]
> If your system is not listed here, make sure that you are in the correct organization and that you are a member of this DMS. See [Check the status of the DMS](#check-the-status-of-the-dms).

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

If there is a CloudGateway instance running, but the dataminer.services connection is still not valid, validate whether your network complies with the [requirements for connecting to dataminer.services](xref:Connect_to_cloud_requirements) by using the *ConnectionTester.exe* tool from the folder `Program files\Skyline Communications\DataMiner CloudGateway\` on the DMA server.

If the results indicate that the network and firewall configuration are OK, [check the cloud session](#check-the-cloud-session).

## Check the cloud session

Manually renewing the cloud identity can be necessary if dataminer.services could not renew its tokens automatically for too long. This can for example happen if no internet access was available for an extended period (more than 6 consecutive days).

1. In DataMiner Cube, go to *System Center* > *Cloud*.

1. Check whether *Cloud identity* or *Cloud Session* is indicated as valid (the UI description depends on your DataMiner version<!-- RN 38715 -->).

1. If it is no longer valid, click the *Renew Session* button.

   > [!NOTE]
   > This button is only available if the cloud identity has expired. It is also only available for users who have the [*Owner* or *Admin* role](xref:Changing_the_role_of_a_dataminer_services_user) in the DMS.

### Handling 'Renew session' failures

If the *Renew session* action fails with the `The DataMiner System could not be found` error, it indicates that the cloud identity has been removed without unregistering the linked DataMiner System.

To resolve this issue, follow the steps in [Permanently disconnecting from dataminer.services](xref:Disconnecting_from_dataminer.services#permanently-disconnecting-from-dataminerservices) to remove the link between the DataMiner System and the removed cloud identity.

When this is done, you can reconnect the system to dataminer.services in Cube under a new identity. For more information on registering a system to dataminer.services, refer to [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Contact support

If the connection issues still persist, [contact DataMiner Support](xref:Contacting_tech_support).
