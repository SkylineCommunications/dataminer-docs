---
uid: Connecting_your_DataMiner_System_to_the_cloud
---

# Connecting your DataMiner System to the cloud

> [!NOTE]
> - This feature is in [soft launch](https://community.dataminer.services/documentation/soft-launch-options/) up to DataMiner 10.1.8. From DataMiner 10.1.9 onwards, it is fully available and no longer subject to change without notice. However, note that the Live Sharing feature remains in soft launch up to DataMiner 10.1.11.
> - If you are using a DataMiner version between DataMiner 10.1.1 and DataMiner 10.1.9, and your system is **already connected** to the cloud, we recommend **installing the DataMiner Cloud Pack** (see step 2 below) on at least one DMA that was already hosting the cloud gateway. After you have done so, clear the selection of the checkboxes in System Center as detailed in the note under step 4 below.

To connect your DMS to the cloud:

1. Verify that the following requirements are met:

    - All DataMiner Agents in the DataMiner System are running DataMiner version 10.1.1 or higher.

    - Prior to DataMiner 10.1.9: The *CloudConnectedAgents* soft-launch option is enabled on all DMAs in the cluster. For more information, see <https://community.dataminer.services/documentation/soft-launch-options/>.

    - Each DMA that will be connected to the cloud can reach the following endpoints:

        - *https://\*.dataminer.services/*

        - *wss://tunnel.dataminer.services/*

1. Download the appropriate DataMiner Cloud Pack installer from [DataMiner Dojo](https://community.dataminer.services/downloads/) and install it on one or more DMAs in the cluster. As .NET 5 is required to connect to the DataMiner Cloud, you can choose an installer that includes or downloads .NET 5. If .NET 5 is already installed in your system, choose the installer that does not include .NET 5.

1. For Cloud Pack versions prior to 2.2.0: If your system has been configured to use HTTPS, and the localhost HTTP endpoint has been disabled, carry out the following additional steps:

    1. Add an *appsettings.custom.json* file to installation directory of DataMiner Cloud Gateway. By default, this directory is *C:\\Program Files\\Skyline Communications\\DataMiner CloudGateway*.

    1. Add the following content to the file, replacing \[your domain\] by your actual domain name, e.g. *my.domain.be*.

        ```json
        {
         "GeneralCloudGatewayOptions": {
         "DataMinerWebApiHttpUrl": "https://[your domain]/",
         "DataMinerWebApiWebsocketUrl": "wss://[your domain]/ws"
         }
        }
        ```

    1. Save the file and restart the *DataMiner CloudGateway* Windows service.

    > [!NOTE]
    > As of DataMiner Cloud Pack 2.2.0, an HTTPS setup is automatically detected, so that you no longer need to configure this manually. However, you can still change the format of the secure URLs as described above if necessary. Make sure the HTTPS settings are configured in MaintenanceSettings.xml as described in the section [Configuring HTTPS settings in MaintenanceSettings.xml](xref:Setting_up_HTTPS_on_a_DMA#configuring-https-settings-in-maintenancesettingsxml).

1. In DataMiner Cube, go to System Center \> *Users / Groups* and make sure you have the following user permissions. If you need to make changes to the user permissions, reconnect to Cube afterwards to make sure your changes are applied in the UI.

    From DataMiner 10.1.4 onwards:

    - *System configuration* > *Tools* > *Admin tools* (no longer required from DataMiner 10.1.9 onwards)

    - *System configuration* > *Cloud gateway* > *Connect to DCP*

    - *System configuration* > *Cloud gateway* > *Disconnect from DCP*

    Prior to DataMiner 10.1.4:

    - *System configuration* > *Tools* > *Admin tools*

    - *System configuration* > *Cloud sharing* > *Connect to cloud*

    - *System configuration* > *Cloud sharing* > *Disconnect from cloud*

    > [!TIP]
    > See also:
    > [User rights](xref:User_rights)

1. On the System Center \> *Cloud* page, click the *Connect* button. A pop-up browser window will open.

    > [!NOTE]
    > - In DataMiner versions prior to DataMiner 10.1.9, checkboxes are available to select a DMA to connect to the cloud. However, these will no longer be used, and they are no longer available from DataMiner 10.1.9 onwards. If you are using an **older DataMiner version**, make sure **none of these checkboxes are selected**.
    > - Internet Explorer is not supported for this. If your default browser is Internet Explorer, you may need to change this temporarily in order to continue with this procedure.

1. Specify the following information in the pop-up window:

    - *Organization*: Specify your organization, either by selecting it in the drop-down box if it already exists in the system, or by clicking *Create new* and specifying your name and DNS.

    - DMS name: Specify the name you want to use for your DMS.

    - DMS URL: Specify a URL-friendly version of the DMS name.

1. Select the checkbox to agree to the terms of service and click *Connect*.

1. On the System Center \> *Cloud* page, wait until the status under *Cloud info* changes to *Registered*. This can take up to half a minute.

> [!NOTE]
> Make sure that all users that should be able to share data with the cloud have the necessary user permissions under [Modules > System configuration > Cloud sharing/gateway](xref:DataMiner_user_permissions#modules--system-configuration--cloud-sharinggateway).
