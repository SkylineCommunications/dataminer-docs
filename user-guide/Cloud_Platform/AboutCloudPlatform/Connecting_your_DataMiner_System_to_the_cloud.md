---
uid: Connecting_your_DataMiner_System_to_the_cloud
---

# Connecting your DataMiner System to dataminer.services

To connect your DMS to dataminer.services:

1. Verify that the following **requirements** are met:

   - All DataMiner Agents in the DataMiner System are running DataMiner version 10.1.12 or higher.

     > [!Note]
     >
     > - We recommend that you upgrade to **DataMiner 10.2.0 or higher** to optimally benefit from all dataminer.services features and capabilities. You can find the installer on [DataMiner Dojo](https://community.dataminer.services/downloads/).
     > - While this is not recommended, it is possible to [connect to dataminer.services with DataMiner versions between 10.1.1 and 10.1.12](xref:Connecting_with_older_DataMiner_versions).

   - Each DMA that will be connected to dataminer.services can reach the following endpoints:

     - ``https://*.dataminer.services/``

     - ``wss://tunnel.dataminer.services/``

     > [!NOTE]
     > At least one DMA in the DMS must be able to reach these endpoints. If you install the Cloud Pack on additional DMAs that **do not allow network traffic** towards `*.dataminer.services`, after the installation, **uninstall DataMiner CloudGateway** on those DMAs. See [uninstalling a program in Windows](https://support.microsoft.com/en-us/windows/uninstall-or-remove-apps-and-programs-in-windows-4b55f974-2cc6-2d2b-d092-5905080eaf98).

   - From [DataMiner CloudGateway](xref:DataMinerExtensionModules#cloudgateway) version 2.10.0 onwards, the internal network must allow [HTTP(S) traffic via port TCP 5100](xref:Configuring_the_IP_network_ports#overview-of-ip-ports-used-in-a-dms). For more information about configuring this endpoint, see [Custom dataminer.services endpoint configuration](xref:Custom_cloud_endpoint_configuration).

   > [!NOTE]
   >
   > - From Cloud Pack version 2.7.0 onwards, [connecting using a DMZ](xref:Connect_to_cloud_with_DMZ) and [connecting via proxy server](xref:Connect_to_cloud_via_proxy) are supported.
   > - If [DataMiner CloudGateway](xref:DataMinerExtensionModules#cloudgateway) 2.9.4 or higher is installed, you can check whether your network complies with the requirements for dataminer.services using the *ConnectionTester.exe* tool from the folder `Program files\Skyline Communications\Dataminer CloudGateway\`.

   > [!TIP]
   > For more information about cloud connectivity and security, see [Cloud connectivity and security](xref:Cloud_connectivity_and_security#connecting-to-dataminerservices).

1. Download the latest DataMiner **Cloud Pack installer** from [DataMiner Dojo](https://community.dataminer.services/downloads/) and install it on one or more DMAs in the cluster. If you are on the Feature Release track, .NET 5 is already included in DataMiner from version 10.1.12 onwards, so select the package without .NET 5. If you are on the Main Release track, .NET 5 is only included from version 10.2.0 \[CU4] onwards, so for earlier 10.2.0 versions, you will need to select the package with .NET 5.

   > [!NOTE]
   > If your DataMiner System contains a Failover pair, and one of the Agents in the Failover pair is responsible for hosting the connection towards dataminer.services, install the DataMiner Cloud Pack on both Agents in the Failover pair.

   > [!TIP]
   > For more information on the Cloud Pack contents, see [DataMiner Cloud Pack](xref:CloudPackages).

1. In DataMiner Cube, go to System Center \> *Users / Groups* and make sure you have the following **user permissions**. If you need to make changes to the user permissions, reconnect to Cube afterwards to make sure your changes are applied in the UI.

   - [System configuration > Cloud gateway > Connect to DCP](xref:DataMiner_user_permissions#modules--system-configuration--cloud-sharinggateway--connect-to-clouddcp)

   - [System configuration > Cloud gateway > Disconnect from DCP](xref:DataMiner_user_permissions#modules--system-configuration--cloud-sharinggateway--disconnect-from-clouddcp)

   > [!TIP]
   > See also: [User rights](xref:User_rights)

1. On the System Center \> *Cloud* page, click the *Connect* button. A pop-up browser window will open.

   > [!NOTE]
   > Internet Explorer is not supported for this. If your default browser is Internet Explorer, we recommend that you change to a different browser in order to continue with this procedure.

1. Specify the following information in the pop-up window:

   - *Organization*: Specify your organization, either by selecting it in the drop-down box if it already exists in the system or by clicking *Create new* and specifying your name and DNS.

     > [!NOTE]
     > To be able to select an existing organization, you must be a [member of that organization on dataminer.services](xref:Giving_users_access_to_cloud_features).

   - *DMS name*: Specify the name you want to use for your DMS.

   - *DMS URL*: Specify a URL-friendly version of the DMS name.

1. Select the checkbox to agree to the terms of service and click *Connect*.

1. On the System Center \> *Cloud* page, wait until the status under *Cloud info* changes to *Connected*. This can take up to half a minute.

1. To ensure that you can make optimal use of your dataminer.services connection, get your dataminer.services connection verified. See [Getting your organization verified](xref:CloudConnectionVerification).

> [!NOTE]
>
> - Make sure that all users that should be able to share data via dataminer.services have the necessary user permissions under [Modules > System configuration > Cloud sharing/gateway](xref:DataMiner_user_permissions#modules--system-configuration--cloud-sharinggateway).
> - To make sure users can make use of dataminer.services features, you will need to manually add them to your organization and DMS in the Admin app. See [Giving users access to dataminer.services features](xref:Giving_users_access_to_cloud_features).
