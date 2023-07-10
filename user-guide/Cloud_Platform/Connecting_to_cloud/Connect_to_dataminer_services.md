---
uid: Connect_to_dataminer_services
---

# Connecting to dataminer.services

Below you can find detailed information on how to connect your DataMiner System to dataminer.services, also known as connecting to the cloud or making a DMS cloud-connected.

> [!TIP]
> For more information about cloud connectivity and security, see [Cloud connectivity and security](xref:Cloud_connectivity_and_security#connecting-to-dataminerservices).

## Before you connect

Before you connect your DMS to dataminer.services (unless you [connect with a DMZ setup](xref:Connect_to_cloud_with_DMZ)):

1. Verify that your DataMiner System meets all [requirements](xref:Connect_to_cloud_requirements).

1. Download the latest DataMiner **Cloud Pack installer** from [DataMiner Dojo](https://community.dataminer.services/dataminer-cloud-pack/) and install it on **one or more DMAs** in the cluster.

   If you are on the Feature Release track, .NET 5 is already included in DataMiner from version 10.1.12 onwards, so select the package without .NET 5. If you are on the Main Release track, .NET 5 is included from version 10.2.0 \[CU4] onwards, so for earlier 10.2.0 versions, you will need to select the package with .NET 5.

   > [!NOTE]
   >
   > - If your DataMiner System contains a Failover pair, and one of the Agents in the Failover pair is responsible for hosting the connection towards dataminer.services, install the DataMiner Cloud Pack on both Agents in the Failover pair.
   > - Installing the Cloud Pack on more than one DMA has [several advantages](xref:FAQ_DCP#do-all-agents-in-a-dms-have-to-be-connected-to-dataminerservices). However, at this time we recommend running only 1 to 3 Cloud Gateway nodes in a cluster. Running more Cloud Gateway nodes than that in a cluster would only add an unnecessary extra load on dataminer.services.

   > [!TIP]
   > For more information on the Cloud Pack contents, see [DataMiner Cloud Pack](xref:CloudPackages).

## Connecting to dataminer.services in System Center

1. In DataMiner Cube, go to System Center \> *Users / Groups* and make sure you have the following **user permissions**:

   - [System configuration > Cloud gateway > Connect to DCP](xref:DataMiner_user_permissions#modules--system-configuration--cloud-sharinggateway--connect-to-clouddcp)

   - [System configuration > Cloud gateway > Disconnect from DCP](xref:DataMiner_user_permissions#modules--system-configuration--cloud-sharinggateway--disconnect-from-clouddcp)

   If you need to make changes to the user permissions, reconnect to Cube afterwards to make sure your changes are applied in the UI.
   
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
