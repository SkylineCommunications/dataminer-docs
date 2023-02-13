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

## Accessing a DMS remotely

If [remote access is enabled](xref:Controlling_remote_access) for a DMS, and you have been [granted access to dataminer.services features](xref:Giving_users_access_to_cloud_features), you can access each of the DataMiner web apps via the remote access URL:

- [Accessing the Monitoring app via dataminer.services](xref:Accessing_the_Monitoring_app#accessing-the-monitoring-app-via-dataminerservices)
- [Accessing the Dashboards app via dataminer.services](xref:Accessing_the_Dashboards_app#accessing-the-dashboards-app-via-dataminerservices)
- [Accessing the Low-Code Apps via dataminer.services](xref:Accessing_custom_apps#accessing-the-low-code-apps-via-dataminerservices)
- [Accessing the Jobs app via dataminer.services](xref:Accessing_the_jobs_app#accessing-the-jobs-app-via-dataminerservices)
- [Accessing the Ticketing app via dataminer.services](xref:Accessing_the_Ticketing_app#accessing-the-ticketing-app-via-dataminerservices)

> [!NOTE]
> To access the web apps, you will need to have the [General > DataMiner web apps](xref:DataMiner_user_permissions#general--dataminer-web-apps--dataminer-cube-mobile-access) user permission, as well as any other user permissions required to access specific apps.
