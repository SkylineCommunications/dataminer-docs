---
uid: Connecting_your_DataMiner_System_to_the_cloud
---

# Connecting your DataMiner System to the cloud

To connect your DMS to the cloud:

1. Verify that the following **requirements** are met:

   - All DataMiner Agents in the DataMiner System are running DataMiner version 10.1.12 or higher.

     > [!Note]
     >
     > - We recommend that you upgrade to version 10.2 to optimally benefit from all the new features and capabilities. You can find the installer on [DataMiner Dojo](https://community.dataminer.services/downloads/).
     > - While this is not recommended, it is possible to [connect to the cloud with DataMiner versions between 10.1.1 and 10.1.12](xref:Connecting_with_older_DataMiner_versions).

   - Each DMA that will be connected to the cloud can reach the following endpoints:

     - ``https://*.dataminer.services/``

     - ``wss://tunnel.dataminer.services/``

1. Download the latest DataMiner **Cloud Pack installer** from [DataMiner Dojo](https://community.dataminer.services/downloads/) and install it on one or more DMAs in the cluster. As .NET 5 is already included in DataMiner from version 10.1.12 onwards, select the package without .NET 5.

1. In DataMiner Cube, go to System Center \> *Users / Groups* and make sure you have the following **user permissions**. If you need to make changes to the user permissions, reconnect to Cube afterwards to make sure your changes are applied in the UI.

   - [System configuration > Cloud gateway > Connect to DCP](xref:DataMiner_user_permissions#modules--system-configuration--cloud-sharinggateway--connect-to-clouddcp)

   - [System configuration > Cloud gateway > Disconnect from DCP](xref:DataMiner_user_permissions#modules--system-configuration--cloud-sharinggateway--disconnect-from-clouddcp)

   > [!TIP]
   > See also: [User rights](xref:User_rights)

1. On the System Center \> *Cloud* page, click the *Connect* button. A pop-up browser window will open.

   > [!NOTE]
   > Internet Explorer is not supported for this. If your default browser is Internet Explorer, you may need to change this temporarily in order to continue with this procedure.

1. Specify the following information in the pop-up window:

   - *Organization*: Specify your organization, either by selecting it in the drop-down box if it already exists in the system or by clicking *Create new* and specifying your name and DNS.

   - *DMS name*: Specify the name you want to use for your DMS.

   - *DMS URL*: Specify a URL-friendly version of the DMS name.

1. Select the checkbox to agree to the terms of service and click *Connect*.

1. On the System Center \> *Cloud* page, wait until the status under *Cloud info* changes to *Connected*. This can take up to half a minute.

1. To ensure that you can make optimal use of your cloud connection, get your cloud connection verified. See [Getting your organization verified](xref:CloudConnectionVerification).

> [!NOTE]
> Make sure that all users that should be able to share data with the cloud have the necessary user permissions under [Modules > System configuration > Cloud sharing/gateway](xref:DataMiner_user_permissions#modules--system-configuration--cloud-sharinggateway).
