---
uid: Cloud_Remote_Access
---

# Remote access

When a DMS is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud), you can use the remote access URL (e.g. ``https://ziine-skyline.on.dataminer.services/``) to access the DataMiner web apps from anywhere.

## Finding the remote access URL

1. Open the [Admin app](xref:Accessing_the_Admin_app).

1. Go to the *Overview* page for the DataMiner System.

   The URL is displayed right underneath the name of the connected DataMiner System. You can copy it or navigate to the URL directly.

![Remote access URL in the Admin app](~/user-guide/images/CloudRemoteAccessUrl.png)

> [!TIP]
> The URL usually has the format `https://[dms_name]-[company_name].on.dataminer.services`, although this depends on what was configured when the DMS was connected to dataminer.services.

## Accessing DataMiner web apps remotely

If [remote access is enabled](xref:Controlling_remote_access) for a DMS, and you have been [granted access to dataminer.services features](xref:Giving_users_access_to_cloud_features), you can access each of the DataMiner web apps via the remote access URL:

- [Accessing the Monitoring app via dataminer.services](xref:Accessing_the_Monitoring_app#accessing-the-monitoring-app-via-dataminerservices)
- [Accessing the Dashboards app via dataminer.services](xref:Accessing_the_Dashboards_app#accessing-the-dashboards-app-via-dataminerservices)
- [Accessing the Low-Code Apps via dataminer.services](xref:Accessing_custom_apps#accessing-the-low-code-apps-via-dataminerservices)
- [Accessing the Jobs app via dataminer.services](xref:Accessing_the_jobs_app#accessing-the-jobs-app-via-dataminerservices)
- [Accessing the Ticketing app via dataminer.services](xref:Accessing_the_Ticketing_app#accessing-the-ticketing-app-via-dataminerservices)

> [!NOTE]
> To access the web apps, you will need to have the [General > DataMiner web apps](xref:DataMiner_user_permissions#general--dataminer-web-apps--dataminer-cube-mobile-access) user permission, as well as any other user permissions required to access specific apps.

## Accessing your DMS remotely with DataMiner Cube

<!-- RN 37841 -->

If [remote access is enabled](xref:Controlling_remote_access) for a DMS, and you have been [granted access to dataminer.services features](xref:Giving_users_access_to_cloud_features), you can use DataMiner Cube to access your DMS via the remote access URL. To do so, you need to [have the DataMiner Cube desktop application installed](xref:Installing_configuring_the_DataMiner_Cube_software).

To access the DMS remotely via Cube, use the same URL as for remote access to the web pages, but without the protocol prefix `https://`.

You can start the Cube session in different ways:

- **Via the desktop app on a client PC**: [Open the Cube desktop app](xref:Opening_the_desktop_app) and add a new DMS. In the *host* field, fill in the remote access URL of your system, without the protocol prefix, e.g. `ziine-skyline.on.dataminer.services`. In the *alias* field, you can fill in a more user-friendly name to make it easy to identify the system.

  ![Remote Cube in the launcher](~/user-guide/images/RemoteCubeLauncher.png)

- **With the button on dataminer.services**: Open a browser and navigate to [dataminer.services](https://dataminer.services). Find your DMS in the list and click the *Open in desktop app* button. This will open Cube with the correct remote access URL filled in in the host field. Then click *Connect* to connect to your DMS.

  ![Remote Cube in the home app](~/user-guide/images/RemoteCubeHomeApp.png)

  > [!NOTE]
  > If your DMS is not listed, check if the correct organization is selected in the top-right corner.

- **With the button on admin.dataminer.services**: Open a browser, navigate to [admin.dataminer.services](https://admin.dataminer.services), and go to the overview of your system. Here you will find the button *Open Desktop Application*. This works in the same way as the button on dataminer.services.

  ![Remote Cube in the admin app](~/user-guide/images/RemoteCubeAdminApp.png)

> [!IMPORTANT]
>
> At present, the following **limitations** apply:
>
> - If the DMS has **SAML** authentication configured, users will not be able to access the DMS remotely with Cube.
> - If the DMS has **multiple CloudGateway instances**, remote access using DataMiner Cube will not function correctly, because Cube needs a session with a specific DMA, while with such a setup requests are distributed across the available CloudGateway instances.
