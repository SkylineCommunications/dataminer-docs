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

## Accessing web pages remotely

If [remote access is enabled](xref:Controlling_remote_access) for a DMS, and you have been [granted access to dataminer.services features](xref:Giving_users_access_to_cloud_features), you can access each of the DataMiner web apps via the remote access URL:

- [Accessing the Monitoring app via dataminer.services](xref:Accessing_the_Monitoring_app#accessing-the-monitoring-app-via-dataminerservices)
- [Accessing the Dashboards app via dataminer.services](xref:Accessing_the_Dashboards_app#accessing-the-dashboards-app-via-dataminerservices)
- [Accessing the Low-Code Apps via dataminer.services](xref:Accessing_custom_apps#accessing-the-low-code-apps-via-dataminerservices)
- [Accessing the Jobs app via dataminer.services](xref:Accessing_the_jobs_app#accessing-the-jobs-app-via-dataminerservices)
- [Accessing the Ticketing app via dataminer.services](xref:Accessing_the_Ticketing_app#accessing-the-ticketing-app-via-dataminerservices)

> [!NOTE]
> To access the web apps, you will need to have the [General > DataMiner web apps](xref:DataMiner_user_permissions#general--dataminer-web-apps--dataminer-cube-mobile-access) user permission, as well as any other user permissions required to access specific apps.

## Accessing your DMS remotely with Cube

If [Remote Access is enabled](xref:Controlling_remote_access) for a DMS, and you have been [granted access to dataminer.services features](xref:Giving_users_access_to_cloud_features), you can access your DMS via the Remote Access URL. To be able to remotely access your system with Cube you need to have the Cube desktop application installed on your system. More information on how to install Cube can be found (here)[xref:Installing_configuring_the_DataMiner_Cube_software].

Remote Cube will use the same URL that is being used for remote access to the web pages, but without the protocol prefix "https://".

To access your system remotely with Cube their are a few options to start the Cube session:

### By using the Cube launcher

Open the Cube launcher and add a new DMS. Here you will be prompted to enter a "host" and an "alias". In the host field you need to fill in the Remote Access URL of your system, without the protocol prefix. This will look something like this: "ziine-skyline.on.dataminer.services". To be able to easily identify your system you can fill in a human readable and easy to remember name in the alias field.

![Remote Cube in the launcher](~/user-guide/images/RemoteCubeLauncher.png)

### By using the button on admin.dataminer.services

Open a browser and navigate to [admin.dataminer.services](https://admin.dataminer.services) and navigate to the overview of your system. Here you will find a button that is labeled "Open Desktop Application". Pressing this button will open up the Cube application with the correct URL in the host field. Simply click on "Connect" and Cube will start a session with your DMS.

![Remote Cube in the admin app](~/user-guide/images/RemoteCubeAdminApp.png)

### By using the button on dataminer.services

Open a browser and navigate to [dataminer.services](https://dataminer.services). Find your DMS in the list and click the "Open desktop application" button. Pressing this button will open up the Cube application with the correct URL in the host field. Simply click the "connect" button and cube will setup a session with your DMS.

![Remote cube in the home app](~/user-guide/images/RemoteCubeHomeApp.png)