---
uid: Giving_users_access_to_cloud_features
---

# Controlling user access to cloud features

If users have a DataMiner Cloud Platform account (i.e. users who are registered on <https://dataminer.services>), you can control whether they have access to cloud features. This includes remote access to a DataMiner System via web apps such as the DataMiner Monitoring app, the use of the [Teams bot](xref:DataMiner_Teams_bot), etc. For this purpose, you must add their DataMiner Cloud Platform account to your organization and to the DataMiner System.

## Giving a user access to cloud features

1. As the owner or administrator of your organization, open the Admin app.

   > [!NOTE]
   > When a DataMiner System is connected to the DataMiner Cloud Platform, the user configuring the connection selects or creates an organization. The DataMiner System is then considered part of the specified organization. If a new organization is created, the person creating it is automatically considered to be its owner.

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

   > [!TIP]
   > See also: [Accessing the Admin app](xref:Accessing_the_Admin_app)

1. If a different organization should be selected, click the organization selector in the top-right corner and select the organization in the list.

   ![Organization selector](~/user-guide/images/CloudAdmin_Selector.png)

1. In the sidebar on the left, navigate to *Organization* > *Users*.

1. At the top of the window, click *Add user*.

1. Specify the email address that is used for the user on the DataMiner Cloud Platform, and click *Add*.

1. In the sidebar on the left, under *DataMiner Systems*, select the DataMiner System you want to add the user to.

1. Select the *Users* page for the DataMiner System.

1. At the top of the page, click *Add user*.

1. Specify the email address that is used for the user on the DataMiner Cloud Platform, and click *Add*.

> [!NOTE]
> If users need to have remote access to the DataMiner System via web apps, make sure remote access is enabled. See [Controlling remote access with the Admin app](xref:Controlling_remote_access).

## Revoking access to cloud features

1. As the owner or administrator of your organization, open the Admin app.

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

1. If a different organization should be selected, click the organization selector in the top-right corner and select the organization in the list.

   ![Organization selector](~/user-guide/images/CloudAdmin_Selector.png)

1. In the sidebar on the left, navigate to *Organization* > *Users*.

1. In the list of users, on the right, click the user icon with an x in the lower right corner to revoke access for a specific user.

1. Click *Remove* to confirm that the user should be removed from the organization in the cloud, so that they will no longer have access to the DMS.
