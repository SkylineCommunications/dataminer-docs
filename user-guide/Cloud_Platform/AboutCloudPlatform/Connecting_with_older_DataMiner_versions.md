---
uid: Connecting_with_older_DataMiner_versions
---

# Connecting with DataMiner versions between 10.1.1 and 10.1.12

> [!NOTE]
> If you are using a DataMiner version between DataMiner 10.1.1 and DataMiner 10.1.9, and your system is **already connected** to dataminer.services, we recommend **installing the DataMiner Cloud Pack** (see step 2 below) on at least one DMA that was already hosting the Cloud Gateway. After you have done so, clear the selection of the checkboxes in System Center as detailed in the note under step 4 below.

To connect your DMS to dataminer.services:

1. Verify that the following **requirements** are met:

   - All DataMiner Agents in the DataMiner System are running DataMiner version 10.1.1 or higher.

   - The *CloudConnectedAgents* soft-launch option is enabled on all DMAs in the cluster. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

   - Each DMA that will be connected to dataminer.services can reach the following endpoints:

     - ``https://*.dataminer.services/``

     - ``wss://tunnel.dataminer.services/``

     > [!NOTE]
     > At least one DMA in the DMS must be able to reach these endpoints. If you install the Cloud Pack on additional DMAs that **do not allow network traffic** towards `*.dataminer.services`, after the installation, **uninstall DataMiner CloudGateway** on those DMAs. See [uninstalling a program in Windows](https://support.microsoft.com/en-us/windows/uninstall-or-remove-apps-and-programs-in-windows-4b55f974-2cc6-2d2b-d092-5905080eaf98).

1. Download the appropriate DataMiner **Cloud Pack installer** from [DataMiner Dojo](https://community.dataminer.services/downloads/) and install it on one or more DMAs in the cluster. As .NET 5 is required to connect to the dataminer.services, you can choose an installer that includes or downloads .NET 5. If .NET 5 is already installed in your system, choose the installer that does not include .NET 5.

   > [!NOTE]
   > If your DataMiner System contains a Failover pair, and one of the Agents in the Failover pair is responsible for hosting the connection towards dataminer.services, install the DataMiner Cloud Pack on both Agents in the Failover pair.

1. In DataMiner Cube, go to System Center \> *Users / Groups* and make sure you have the following **user permissions**. If you need to make changes to the user permissions, reconnect to Cube afterwards to make sure your changes are applied in the UI.

   Prior to DataMiner 10.1.4:

   - [System configuration > Cloud sharing > Connect to cloud](xref:DataMiner_user_permissions#modules--system-configuration--cloud-sharinggateway--connect-to-clouddcp)

   - [System configuration > Cloud sharing > Disconnect from cloud](xref:DataMiner_user_permissions#modules--system-configuration--cloud-sharinggateway--disconnect-from-clouddcp)

   - [System configuration > Tools > Admin tools](xref:DataMiner_user_permissions#modules--system-configuration--tools--admin-tools)

   From DataMiner 10.1.4 onwards:

   - [System configuration > Cloud gateway > Connect to DCP](xref:DataMiner_user_permissions#modules--system-configuration--cloud-sharinggateway--connect-to-clouddcp)

   - [System configuration > Cloud gateway > Disconnect from DCP](xref:DataMiner_user_permissions#modules--system-configuration--cloud-sharinggateway--disconnect-from-clouddcp)

   - [System configuration > Tools > Admin tools](xref:DataMiner_user_permissions#modules--system-configuration--tools--admin-tools) (no longer required from DataMiner 10.1.9 onwards)

   > [!TIP]
   > See also: [User rights](xref:User_rights)

1. On the System Center \> *Cloud* page, click the *Connect* button. A pop-up browser window will open.

   > [!NOTE]
   >
   > - In DataMiner versions prior to DataMiner 10.1.9, checkboxes are available to select a DMA to connect to dataminer.services. However, these are no longer used and are unavailable in later DataMiner versions. If you are using an **older DataMiner version**, make sure **none of these checkboxes are selected**.
   > - Internet Explorer is not supported for this. If your default browser is Internet Explorer, we recommend that you change to a different browser in order to continue with this procedure.

1. Specify the following information in the pop-up window:

   - *Organization*: Specify your organization, either by selecting it in the drop-down box if it already exists in the system or by clicking *Create new* and specifying your name and DNS.

   - *DMS name*: Specify the name you want to use for your DMS.

   - *DMS URL*: Specify a URL-friendly version of the DMS name.

1. Select the checkbox to agree to the terms of service and click *Connect*.

1. On the System Center \> *Cloud* page, wait until the status under *Cloud info* changes to *Connected*. This can take up to half a minute.

1. To ensure that you can make optimal use of your connection to dataminer.services, get your connection verified. See [Getting your organization verified](xref:CloudConnectionVerification).

> [!NOTE]
> Make sure that all users that should be able to share data via dataminer.services have the necessary user permissions under [Modules > System configuration > Cloud sharing/gateway](xref:DataMiner_user_permissions#modules--system-configuration--cloud-sharinggateway).
