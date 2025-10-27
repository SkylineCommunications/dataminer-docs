---
uid: Controlling_remote_access
keywords: cloud access, access to the cloud
reviewer: Alexander Verkest
---

# Controlling remote access with the Admin app

Remote access can be controlled both on organization level and on DMS level. If remote access is disabled for an organization, it is automatically also disabled for all DataMiner Systems within that organization.

## Controlling the remote access settings of your organization

If you have the Owner or Admin role on dataminer.services for an organization, you can enable or disable the [remote access](xref:About_Remote_Access) features.

1. In the [Admin app](xref:Accessing_the_Admin_app), check whether the correct organization is mentioned in the header bar.

1. If a different organization should be selected, click the organization selector ![Organization selector](~/dataminer/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. In the sidebar on the left, under *Organization*, select the *Settings* page.

1. Toggle the *Remote Access* settings to *On* or *Off*, depending on whether you want this to be allowed or disabled for all the DataMiner Systems in this organization.

> [!NOTE]
>
> - If a setting is disabled on organization level, it will not be possible to enable it for the DataMiner Systems in this organization.
> - When you change a *Remote Access* setting from *On* to *Off*, it can take a minute before the change is applied.
> - Users will only be able to use the remote access features if they have been given access to the DMS on dataminer.services. See [Controlling user access to dataminer.services features](xref:Giving_users_access_to_cloud_features). They also need to have the [General > DataMiner web apps](xref:DataMiner_user_permissions#general--dataminer-web-apps) user permission, as well as any other user permissions required to access specific apps.
> - The Remote Access feature can also be disabled locally on a specific server. See [Disabling Remote Access and Live Sharing locally](xref:Disabling_Remote_Access_and_Live_Sharing).

## Controlling the remote access settings of a DMS in your organization

If you have the Owner or Admin role on dataminer.services for a DMS, you can enable or disable the [remote access](xref:About_Remote_Access) features.

1. In the [Admin app](xref:Accessing_the_Admin_app), check whether the correct organization is mentioned in the header bar.

1. If a different organization should be selected, click the organization selector ![Organization selector](~/dataminer/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. In the pane on the left, under *DataMiner Systems*, expand the DataMiner System, and select the *Settings* page.

1. Select how remote access should be limited:

   - If you want remote access to be disabled completely, switch off the main *Remote Access* toggle button.

   - If you want remote access to be enabled, switch on the main *Remote Access* setting. If it should only be enabled for specific DataMiner features, below this setting, switch off the features for which remote access should be disabled:

     - *DataMiner Cube (desktop app)*: Enable or disable remote access to the DataMiner System(s) via the desktop app.

     - *Web apps*: Enable or disable remote access to the DataMiner System(s) via the web apps.

     - *User-Defined APIs*: Enable or disable remote access to the DataMiner System(s) via User-Defined APIs.

   - If you want remote access to be restricted based on IP address for a specific DataMiner features, when you have enabled a feature as detailed above, also switch on the *Restrict by IP address* option, click *Manage*, and specify the public IP addresses for which remote access should be allowed.

     ![Managing IP addresses](~/dataminer/images/Managing_IP_Addresses.png)

     > [!NOTE]
     >
     > - Only public IP addresses can be added to the list of trusted IP addresses. Private IP addresses, which are hidden behind public IP addresses, cannot be used for communication outside of their local network.
     > - To find your public IP address:
     >
     >   1. Open a command prompt as Administrator.
     >   1. Execute the `curl ifconfig.me` command.
     >
     >   Note that if you are using a VPN, the IP address displayed will be the public IP address assigned by the VPN, not your actual public IP address. Add this VPN-assigned IP address to the list.
     > - Make sure you have a static IP address. If you are using a VPN, confirm it is configured with a static IP address. If you are not using a VPN, contact your Internet Service Provider (ISP) to verify or obtain a static IP address. A dynamic IP address can change periodically, which may result in losing remote access to the DMS if it changes. Additionally, someone else might be assigned your previous public IP address, allowing them remote access to the DMS (though they would still need to log in).

> [!NOTE]
>
> - If a setting is disabled on organization level, it will not be possible to enable it for a DataMiner System in that organization.
> - When you change a *Remote Access* setting from *On* to *Off*, it can take a minute before the change is applied.
> - Users will only be able to use the remote access features if they have been given access to the DMS on dataminer.services. See [Controlling user access to dataminer.services features](xref:Giving_users_access_to_cloud_features). They also need to have the [General > DataMiner web apps](xref:DataMiner_user_permissions#general--dataminer-web-apps) user permission, as well as any other user permissions required to access specific apps.
> - The Remote Access feature can also be disabled locally on a specific server. See [Disabling Remote Access and Live Sharing locally](xref:Disabling_Remote_Access_and_Live_Sharing).
