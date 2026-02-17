---
uid: Adding_a_user_group
---

# Adding a user group

There are two ways to add a new user group to a DMS, depending on whether it is a local group or a domain group.

To add a **local group**:

1. In the *Users / Groups* section of the System Center module, go to the *groups* tab.

1. Click *Add new group*.

   The new group will be added to the list of *Local* groups.

> [!NOTE]
> In complex systems, instead of creating a separate group for each possible set of required rights and permissions, it can be more useful to combine different groups. This way you can for example add users to an “Operator” group with basic permissions and access to the views that every operator should be able to see, and then add them to additional groups depending on the additional views and functionality they need to have access to.

To add an existing **domain group**:

1. In the *Users / Groups* section of the System Center module, go to the *groups* tab.

1. Click *Add existing group*.

1. In the *Add existing group* window, select the group(s) you want to add and click *OK*.

   The new groups will be added to the list of *Domain* groups.

When you add a domain group to DataMiner, keep the following in mind:

- All members of the domain group are automatically added to DataMiner.

- If changes are made to the domain group outside of DataMiner (e.g., users are added or deleted), DataMiner will automatically update its security settings.

- If you add a domain group that contains subgroups, the users from the subgroups will also automatically be added as if they are in the parent group. For example, if you add a group with 2 subgroups containing 5 users each, in DataMiner you will only see the parent group, containing the 10 users that were in the subgroups.

- Some properties of domain users (e.g., name, password) cannot be changed in DataMiner. To indicate that domain users are read-only, these users are marked by a gray user icon in the user list.
