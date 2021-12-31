## User rights

Users get access to the DataMiner System according to the rights that have been granted to their account.

Rights can be granted according to three concepts:

- **Permissions**: Users can be granted or denied permission to execute specific actions in the DMS (e.g. add elements, edit alarm templates, etc.), based on the configuration of the user group they are part of.

- **Views**: Users can be granted or denied access to specific items in DataMiner, based on the user group they are part of.

- **Access levels**: Access levels can be assigned both to users and to individual parameters.

    Users will only be able to set parameters of which the access level is equal or lower than the access level they have been granted. Example: A user with access level 3 can update parameters with access level 3, 4, 5, etc.     Access levels range from 1 (highest level) to 100 (lowest level).

> [!NOTE]
> The user permissions and view access of a user are always inherited from the group the user is a member of. Changing these is only possible by changing the group membership, or by editing the group. See [Managing user groups](Managing_user_groups.md).

> [!TIP]
> See also:
> [DataMiner user permissions](DataMiner_user_permissions.md)  
