---
uid: Controlling_remote_access
---

# Controlling remote access settings of your organization with the Admin app

If you have the Owner or Admin role on dataminer.services for an organization, you can enable or disable the [remote access](xref:Cloud_Remote_Access) features.

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

   > [!TIP]
   > See also: [Accessing the Admin app](xref:Accessing_the_Admin_app)

1. If a different organization should be selected, click the organization selector ![Organization selector](~/user-guide/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. In the pane on the left, under *Organization*, select the *Settings* page.

1. Toggle the *Remote Access* settings to *On* or *Off*, depending on whether you want this to be allowed or disabled on all of your DataMiner Systems owned by this organization.

> [!NOTE]
>
> - If a setting is disabled on the organization, it will not be possible to enable it on the DataMiner Systems owned by this organization.
> - When you change a *Remote Access* setting from *On* to *Off*, it might take a minute before the change applies to the actual features.
> - Users will only be able to use the remote access features if they have been given access to the DMS on dataminer.services. See [Controlling user access to dataminer.services features](xref:Giving_users_access_to_cloud_features). They also need to have the [General > DataMiner web apps](xref:DataMiner_user_permissions#general--dataminer-web-apps--dataminer-cube-mobile-access) user permission, as well as any other user permissions required to access specific apps.
> - The Remote Access feature can also be disabled locally on a specific server. See [Disabling Remote Access and Live Sharing locally](xref:Disabling_Remote_Access_and_Live_Sharing).

# Controlling remote access settings of your DMS with the Admin app

If you have the Owner or Admin role on dataminer.services for a DMS, you can enable or disable the [remote access](xref:Cloud_Remote_Access) features.

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

   > [!TIP]
   > See also: [Accessing the Admin app](xref:Accessing_the_Admin_app)

1. If a different organization should be selected, click the organization selector ![Organization selector](~/user-guide/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. In the pane on the left, under *DataMiner Systems*, select your DataMiner System and select the *Settings* page.

1. Toggle the *Remote Access* settings to *On* or *Off*, depending on whether you want this to be enabled or not.

> [!NOTE]
> 
> - If a setting is disabled on the organization that owns this DataMiner System, it will not be possible to enable it on the DataMiner System.
> - When you change a *Remote Access* setting from *On* to *Off*, it might take a minute before the change applies to the actual features.
> - Users will only be able to use the remote access features if they have been given access to the DMS on dataminer.services. See [Controlling user access to dataminer.services features](xref:Giving_users_access_to_cloud_features). They also need to have the [General > DataMiner web apps](xref:DataMiner_user_permissions#general--dataminer-web-apps--dataminer-cube-mobile-access) user permission, as well as any other user permissions required to access specific apps.
> - The Remote Access feature can also be disabled locally on a specific server. See [Disabling Remote Access and Live Sharing locally](xref:Disabling_Remote_Access_and_Live_Sharing).
