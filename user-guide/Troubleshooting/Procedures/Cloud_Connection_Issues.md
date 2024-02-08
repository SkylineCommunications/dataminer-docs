---
uid: Cloud_Connection_Issues
---

# Cloud Connection Issues
This page provides solutions for issues that may arise from connectivity problems with cloud services.

## Remote Access Issues
Follow the guide below when you are encountering connection issues with dataminer.services features and your DataMiner System.

### Check Status of DxMs
A common cause for issues with [dataminer.services](xref:AboutCloudPlatform) features and your DMS is due to the connection from the [DxMs](xref:DataMinerExtensionModules) towards dataminer.services being unavailable. 
Resolve this by taking the following steps:
1. Verify whether the installed [DxMs](xref:DataMinerExtensionModules) are running, otherwise start them.
1. Make sure to have the most [recent versions](xref:DCP_change_log) of the DxMs installed to avoid dealing with issues that might have been fixed. Info about upgrading DxMs can be found [here](https://community.dataminer.services/dataminer-cloud-pack/).
1. Verify the accessibility of the DMA host by opening a browser and navigating to the address specified in the [MaintenanceSettings.xml](xref:MaintenanceSettings_xml). This address corresponds to the value that has been set as the *name* parameter in the [HTTPS setting](xref:Setting_up_HTTPS_on_a_DMA) of MaintenanceSettings.xml. If the page manages to load, it indicates that the DMA host is locally accessible but there is a possible issue with the [proxy](xref:Connect_to_cloud_via_proxy) or [DMZ](xref:Connect_to_cloud_with_DMZ) settings.

### Check DMS Status
Verify the status of the DMS and ensure that the system is operational, if not, start the DMS. 

### Check Cloud Session
Verify in DataMiner Cube if the cloud identity is still valid, otherwise please [renew the cloud identity](#renew-cloud-identity).

### Undetermined Problem
When the previous solutions did not solve the problem, ensure that all [requirements](xref:Accessing_DMS_remotely_with_Cube) for remote access are fulfilled.

## Renew Cloud Identity
If the cloud identity expires, it must be renewed. To do this, access the DataMiner Cube and select *Cloud* under *System Center*. If the cloud identity is expired, a ```Renew Session``` button should be available. Manually renewing the identity can be necessary if the cloud could not renew its tokens automatically for too long (no internet access for extended periods for example, usually minimum 3 days). 

>[!NOTE]
>The ```Renew Session``` button is only available for users with the Owner role of the DMS.


If the issues persist, please contact [support](https://skyline.be/contact/tech-support).