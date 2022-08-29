---
uid: Controlling_remote_access
---

# Controlling remote access with the Admin app

Users with a DataMiner Cloud Platform account (i.e. users who are registered on <https://dataminer.services>) can be given remote access to a DataMiner System via the DataMiner Monitoring app, the Dashboards app, the [Teams bot](xref:DataMiner_Teams_bot), etc. For this purpose, you must add their DataMiner Cloud Platform account to your organization and to the DataMiner System. In addition, remote access must be enabled for the DataMiner System.

## Giving a user access to cloud features

1. As the owner or administrator of your organization, open the Admin app.

   > [!NOTE]
   > When a DataMiner System is connected to the DataMiner Cloud Platform, the user configuring the connection selects or creates an organization. The DataMiner System is then considered part of the specified organization. If a new organization is created, the person creating it is automatically considered to be its owner.

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

   > [!TIP]
   > See also: [Accessing the Admin app](xref:Accessing_the_Admin_app)

1. If a different organization should be selected, click the organization selector in the top-right corner and select the organization in the list.

   ![Organization selector](~/user-guide/images/CloudAdmin_Selector.png)

1. In the sidebar on the left, under *DataMiner Systems*, select your DataMiner System and select the *Overview* page.

1. Click the *Edit* button at the top of the page.

1. Set the *Remote Access* setting to *On* or *Off*, depending on whether you want this to be enabled or not.

1. In the sidebar on the left, navigate to *Organization* > *Users*.

1. At the top of the window, click *Add user*.

1. Specify the email address that is used for the user on the DataMiner Cloud Platform, and click *Add*.

1. In the sidebar on the left, under *DataMiner Systems*, select the DataMiner System you want to add the user to.

1. Select the *Users* page for the DataMiner System.

1. At the top of the page, click *Add user*.

1. Specify the email address that is used for the user on the DataMiner Cloud Platform, and click *Add*.

> [!NOTE]
> If users have been given cloud access to a DMS, to access the DataMiner web apps (e.g. the Monitoring app), they need to go to the public address of the cloud-connected DMS, in the format `https://[dms_name]-[company_name].on.dataminer.services`. This URL can be found on the *Overview* page for the DataMiner System in the Cloud Admin app. You can also directly navigate to the URL from this section.
>
> ![Remote access URL in the Cloud Admin app](~/user-guide/images/CloudRemoteAccessUrl.png)
>
> See also: [Accessing the Monitoring app via the DataMiner Cloud Platform](xref:Accessing_the_Monitoring_app#accessing-the-monitoring-app-via-the-dataminer-cloud-platform).

## Revoking access to cloud features

1. As the owner or administrator of your organization, open the Admin app.

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

1. If a different organization should be selected, click the organization selector in the top-right corner and select the organization in the list.

   ![Organization selector](~/user-guide/images/CloudAdmin_Selector.png)

1. In the sidebar on the left, navigate to *Organization* > *Users*.

1. In the list of users, on the right, click the user icon with an x in the lower right corner to revoke access for a specific user.

1. Click *Remove* to confirm that the user should be removed from the organization in the cloud, so that they will no longer have access to the DMS.
