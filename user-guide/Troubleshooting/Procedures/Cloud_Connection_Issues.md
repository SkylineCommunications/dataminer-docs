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

### Check DMS Status
Verify the status of the DMS and ensure that the system is operational, if not, start the DMS. 

### Check Cloud Session
Verify in DataMiner Cube if the cloud session is still available and not expired, otherwise [renew the cloud connection](#renew-cloud-connection).

### Undetermined Problem
When the previous solutions did not solve the problem, ensure that all [requirements](xref:Accessing_DMS_remotely_with_Cube) for remote access are fulfilled. Please contact [support](https://skyline.be/contact/tech-support) if none of the above solved the problem.

## Renew Cloud Connection
If the cloud connection expires, a new token must be requested to renew it. To do this, access the DataMiner Cube and select *Cloud* under *System Center*. If the cloud connection is expired, a ```Renew Session``` button should be available. Manually renewing the connection can be necessary if the cloud could not renew its tokens automatically for too long (no internet access for extended periods for example, usually minimum 3 days). 

>[!NOTE]
>The ```Renew Session``` button is only available for users with the Owner role of the DMS.