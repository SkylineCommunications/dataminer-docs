---
uid: Changing_the_role_of_a_DCP_user
---

# Changing the role of a dataminer.services user

Each user that has been added in the Admin app can have the role *Member*, *Admin*, or *Owner*, and this both on the level of the organization and of the DataMiner System. This role determines which permissions the user has on dataminer.services. Several users can have the *Admin* or *Owner* role, and users can have a different role on organization and DMS level.

- The **Owner** role has the most permissions, and there is always at least one owner per organization. When a DataMiner System is connected to dataminer.services and a new organization is created containing that DataMiner System, the person creating it is automatically considered to be its owner and given the *Owner* role.

- On organizational level, the **Admin** role is not allowed to delete organizations. On DMS level, they cannot request a token to keep a DMS connected to dataminer.services in case the connection has expired. Aside from that, they have all the permissions the *Owner* role has.

- On organizational level, the **Member** role is only allowed to view users and connect a DMS to dataminer.services. On DMS level, they can share data, view users, view information about the dataminer.services configuration, deployments and shares, and unlink their own DataMiner account.

If you have the *Owner* or *Admin* role, you can change the role of a user as follows:

1. Open the Admin app.

1. Check whether the correct organization is mentioned in the header bar.

   > [!TIP]
   > See also: [Accessing the Admin app](xref:Accessing_the_Admin_app)

1. If a different organization should be selected, click the organization selector ![Organization selector](~/user-guide/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. Change the role on organizational level if necessary:

   1. In the sidebar on the left, navigate to *Organization* > *Users*.

   1. In the *Role* column, select the role you want the user to have.

1. Change the role on DMS level if necessary:

   1. Select the *Users* page for the DataMiner System.

   1. In the *Role* column, select the role you want the user to have.
