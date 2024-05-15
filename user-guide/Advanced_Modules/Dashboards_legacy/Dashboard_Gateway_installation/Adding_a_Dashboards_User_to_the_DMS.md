---
uid: Adding_a_Dashboards_User_to_the_DMS
---

# Adding a Dashboards User to the DMS

> [!IMPORTANT]
> This information is applicable to the DMS Dashboards module, which is being retired as of DataMiner version 10.4.x. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement). For more information on the Dashboards web app available from DataMiner 9.6.9 onwards, see [Dashboards app](xref:newR_D).

In order for a new customer to access dashboards with DMS Dashboard Gateway, the following steps are required:

1. Add the user to the DMS. See [Adding a user](xref:Adding_a_user).

2. Add the user to a group. See [Changing group membership of a user](xref:Changing_group_membership_of_a_user).

    > [!NOTE]
    > Make sure that the group you add the user to has at least the *Dashboards* > *View* right. The group also needs to have access rights for all the elements, services or views that are used in the dashboards that you intend to allow for this user. Additionally, the rights *Dashboards* > *Add*, *Dashboards* > *Delete* and *Dashboards* > *Edit* may be required. See [Configuring a user group](xref:Configuring_a_user_group).

3. Configure which dashboards the new user is allowed to access. See [Configuring dashboard access rights](xref:Configuring_dashboard_access_rights).

    > [!NOTE]
    > By default, new users in the DMS do not have access to any dashboards.
    >
