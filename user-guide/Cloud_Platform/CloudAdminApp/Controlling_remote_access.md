---
uid: Controlling_remote_access
---

# Controlling remote access with the Admin app

When a DMS is cloud-connected, you can use the URL created for you during registration (e.g. ``https://ziine-skyline.on.dataminer.services/``) to access the DataMiner web apps from anywhere. See for example [Accessing the Monitoring app via the DataMiner Cloud Platform](xref:Accessing_the_Monitoring_app#accessing-the-monitoring-app-via-the-dataminer-cloud-platform).

## Finding the remote access URL

After you have registered, you can find the URL on the *Overview* page for the DataMiner System in the Cloud Admin app. The URL is displayed right underneath the name of the connected DataMiner System. You can also directly navigate to the URL from this section.

![Remote access URL in the Cloud Admin app](~/user-guide/images/CloudRemoteAccessUrl.png)

> [!TIP]
> The URL will always have the format `https://[dms_name]-[company_name].on.dataminer.services`.

## Enabling or disabling remote access

If you have the Owner or Admin role on DCP, you can enable or disable the remote access feature.

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

   > [!TIP]
   > See also: [Accessing the Admin app](xref:Accessing_the_Admin_app)
1. If a different organization should be selected, click the organization selector in the top-right corner and select the organization in the list.

   ![Organization selector](~/user-guide/images/CloudAdmin_Selector.png)

1. In the pane on the left, under *DataMiner Systems*, select your DataMiner System and select the *Overview* page.

1. Click the *Edit* button at the top of the page.

1. Set the *Remote Access* setting to *On* or *Off*, depending on whether you want this to be enabled or not.

> [!NOTE]
> Users will only be able to use the remote access feature if they have been given access to cloud features. See [Controlling user access to cloud features](xref:Giving_users_access_to_cloud_features). They will also need to have the [General > DataMiner web apps](xref:DataMiner_user_permissions#general--dataminer-web-apps--dataminer-cube-mobile-access) user permission, as well as any other user permissions required to access specific apps, e.g. [Modules > User-definable apps > View apps](xref:DataMiner_user_permissions#modules--user-definable-apps--view-apps) for the Low-Code Apps.
