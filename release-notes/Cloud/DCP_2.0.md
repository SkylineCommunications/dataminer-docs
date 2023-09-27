---
uid: DCP_2.0
---

# DataMiner Cloud Pack 2.0

## Installing the DataMiner Cloud Pack

To use any dataminer.services features, from DataMiner 10.1.9 onwards, you must install the DataMiner Cloud Pack on at least one of the DMAs in your DMS. Installing it on a DMA does not cause any downtime.

If you are using a DataMiner version between DataMiner 10.1.1 and DataMiner 10.1.9, and your system is already connected to dataminer.services, we recommend installing the DataMiner Cloud Pack (see step 2 below) on at least one DMA that was already hosting the Cloud Gateway. After you have done so, clear the selection of the checkboxes in *System Center* as detailed in the note under step 4 below.

To install the DataMiner Cloud Pack and connect your DMS to dataminer.services:

1. Verify that the following requirements are met:

    - All DataMiner Agents in the DataMiner System are running DataMiner version 10.1.1 or higher.
    - Prior to DataMiner 10.1.9: The *CloudConnectedAgents* soft-launch option is enabled on all DMAs in the cluster. For more information, see [Soft-launch options](xref:SoftLaunchOptions).
    - Each DMA that will be connected to dataminer.services can reach the following endpoints:

        - `https://*.dataminer.services/`
        - `wss://tunnel.dataminer.services/`

1. Download the appropriate DataMiner Cloud Pack installer from the [Downloads](https://community.dataminer.services/downloads/) page and install it on one or more DMAs in the cluster. As .NET 5 is required to connect to dataminer.services, you can choose an installer that includes or downloads .NET 5. If .NET 5 is already installed in your system, choose the installer that does not include .NET 5.

1. In DataMiner Cube, go to *System Center > Users/Groups* and make sure you have the following user permissions.

    ### [From DataMiner 10.1.4 onwards](#tab/tabid-1)

    - *System configuration > Tools > Admin tools* (no longer required from DataMiner 10.1.9 onwards)
    - *System configuration > Cloud gateway > Connect to DCP*
    - *System configuration > Cloud gateway > Disconnect from DCP*

    ### [Prior to DataMiner 10.1.4](#tab/tabid-2)

    - *System configuration > Tools > Admin tools*
    - *System configuration > Cloud sharing > Connect to cloud*
    - *System configuration > Cloud sharing > Disconnect from cloud*

    ***

1. Click the *Register* button. A pop-up browser window will open.

    > [!NOTE]
    >
    > - In DataMiner versions prior to DataMiner 10.1.9, checkboxes are available to select a DMA to connect to dataminer.services. However, these will no longer be used, and they are no longer available from DataMiner 10.1.9 onwards. **If you are using an older DataMiner version, make sure none of these checkboxes are selected.**
    > - Internet Explorer is not supported for this. If your default browser is Internet Explorer, you may need to change this temporarily in order to continue with this procedure.

1. Specify the following information in the pop-up window:

    - *Organization*: Specify your organization, either by selecting it in the drop-down box if it already exists in the system, or by clicking *Create new* and specifying your name and DNS.
    - *DMS name*: Specify the name you want to use for your DMS.
    - *DMS URL*: Specify a URL-friendly version of the DMS name.

1. Select the checkbox to agree to the terms of service and click *Connect*.

1. On the *System Center > Cloud* page, wait until the status under *Cloud info* changes to "Registered". This can take up to half a minute.

> [!NOTE]
> Make sure that all users that should be able to share data via dataminer.services have the following user permissions:
>
> - *System configuration > Cloud sharing > Share item*
> - *System configuration > Cloud sharing > Account linking*

## Component versions

When you install the DataMiner Cloud Pack v2.0.0, the following components are installed. You will be able to find these in the Windows installed programs list.

- DataMiner FieldControl v2.0.0
- DataMiner CoreGateway v2.0.0
- DataMiner CloudGateway v2.0.0

## Features

### Live Sharing

Live sharing of dashboards has been possible as a soft-launch feature for some time now. While this feature is in soft launch at the time of this release, when you upgrade to DataMiner 10.1.9, you will need to install the DataMiner Cloud Pack to keep using it.

Once the DataMiner Cloud Pack has been installed, you will be able to continue sharing dashboards from the Dashboards web app. You can find an overview of the dashboards you have shared on <https://shares.dataminer.services>.

Moreover, from DataMiner 10.1.9 onwards, you will also be able to manage the users of a shared dashboard, via the *Manage Share* option in the Dashboards app. With this option, you can grant or take away users' access to a shared dashboard.

### Admin app

An Admin app is available that you can use to manage your organization and DataMiner Systems connected to dataminer.services. However, this app is currently still being developed. A number of important features are still missing in the current beta version.

You can find the app at <https://admin.dataminer.services/>.

The app supports the following actions:

- View an overview of the organizations you are part of.
- View an overview of the users of your organization.
- View and change the role of a user within your organization.
- Add users to your organization.
- View the DataMiner Systems connected to dataminer.services registered under your organization.
- Change the remote access and cloud feed settings of your registered DataMiner System.

### Remote access

When your DMS is connected to dataminer.services, you can use the URL created for you during registration (e.g. `https://ziine-skyline.on.dataminer.services/`) to access the DataMiner web apps from anywhere.

You can enable or disable this remote access feature using the Admin app:

1. Go to <https://admin.dataminer.services/>.
1. Click the icon next to the user icon in the top right corner to view the *Change Organization* menu, and select your organization.
1. In the sidebar on the left, click *DataMiner Systems*.
1. Select the relevant DataMiner System in the list.
1. Click *Edit* and change *Remote access* to "enabled" or "disabled".
1. Click *Save*.

> [!NOTE]
> You need to have the *Owner* or *Admin* role on dataminer.services to be able to do this procedure.

### Cloud feed

The cloud feed feature is used for the offloading of alarm and change point events to the cloud. These will be used to improve DataMiner Analytics features.

You can enable these offloads in the Admin app:

1. Go to <https://admin.dataminer.services/>.
1. Click the icon next to the user icon in the top right corner to view the *Change Organization* menu, and select your organization.
1. In the sidebar on the left, click *DataMiner Systems*.
1. Select the relevant DataMiner System in the list.
1. Click *Edit* and set *Allow CloudFeed Data offload* to "enabled" or "disabled".
1. Click *Save*.

> [!NOTE]
> You need to have the *Owner* or *Admin* role on dataminer.services to be able to do this procedure.
