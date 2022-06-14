---
uid: User_rights
---

# User rights

Users get access to the DataMiner System according to the rights that have been granted to their account.

Rights can be granted according to three concepts:

- **Permissions**: Users can be granted or denied permission to execute specific actions in the DMS (e.g. add elements, edit alarm templates, etc.), based on the configuration of the user group they are part of.

- **Views**: Users can be granted or denied access to specific items in DataMiner, based on the user group they are part of.

- **Access levels**: Access levels can be assigned both to users and to individual parameters.

    The lower the number of a user's access level, the more levels they can access, because they will be able to access all parameters for which a security level with a higher number is defined (see [level attribute](xref:Protocol.Params.Param-level)). For example, a user with access level 3 can update parameters with security level 3, 4, 5, etc.

    Access levels for regular users range from 1 (the level with most access) to 100 (the level with least access). The Administrator user has access level 0.

> [!NOTE]
> The user permissions and view access of a user are always inherited from the group the user is a member of. You can only change these by changing the group membership or by editing the group. See [Managing user groups](xref:Managing_user_groups).

> [!TIP]
> See also: [DataMiner user permissions](xref:DataMiner_user_permissions)
