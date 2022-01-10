## Adding a Dashboards User to the DMS

In order for a new customer to access dashboards with DMS Dashboard Gateway, the following steps are required:

1. Add the user to the DMS. See [Adding a user](../../part_3/security/Adding_a_user.md).

2. Add the user to a group. See [Changing group membership of a user](../../part_3/security/Changing_group_membership_of_a_user.md).

    > [!NOTE]
    > Make sure that the group you add the user to has at least the *Dashboards* > *View* right. The group also needs to have access rights for all the elements, services or views that are used in the dashboards that you intend to allow for this user. Additionally, the rights *Dashboards* > *Add*, *Dashboards* > *Delete* and *Dashboards* > *Edit* may be required. See [Configuring a user group](../../part_3/security/Configuring_a_user_group.md).

3. Configure which dashboards the new user is allowed to access. See [Configuring dashboard access rights](Configuring_dashboard_access_rights.md).

    > [!NOTE]
    > By default, new users in the DMS do not have access to any dashboards.
    >
