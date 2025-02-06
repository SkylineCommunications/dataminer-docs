---
uid: Configuring_a_user_group
---

# Configuring a user group

To configure a user group:

1. In the *Users / Groups* section in System Center, go to the *Groups* tab and select the group in question.

1. To change the group name, fill in the new name in the *Name* field of the *Details* tab.

1. To change the group’s security level, enter a new level in the *Group level* field on the *Details* tab.

   Access levels range from 1 (highest level) to 100 (lowest level). This level affects access to specific parameters on element cards (defined with a *level* attribute in the protocol), as well as access to specific pages or shapes in Visual Overview (see [Making a shape or page visible only for a particular access level](xref:Making_a_shape_or_page_visible_only_for_a_particular_access_level)).

   > [!NOTE]
   > It is possible that after changing the access level, this change will not take effect until you have closed DataMiner Cube and opened it again.

1. To change what users are a member of the group, go to the *Users* tab and move users to and from the *Available users* and *Included users* columns using the *ADD \>\>* and *\<\< REMOVE* buttons.

   > [!NOTE]
   > Changes of group membership are also possible on user level. See [Changing group membership of a user](xref:Changing_group_membership_of_a_user).

1. To determine the views, elements and services a user has access to, go to the *Permissions* tab, select the *Views* subtab and select the appropriate checkboxes:

   - To grant the group members access to a view, element or service, select the checkbox to the left of the relevant item.

   - If you want to grant the group members permission to change parameters in the selected view, element or service, select the checkbox in the *Write* column.

   - If you want to grant the group members permission to edit the selected view, element or service, select the checkbox in the *Config* column.

   > [!NOTE]
   > For EPM elements, it is also possible to configure access for objects on the lower topology levels.

1. To change the user permissions for a group, go to the *Permissions* tab, select the *Rights* subtab and select the appropriate checkboxes.

   Alternatively, instead of selecting the different separate permissions, you can select a preset at the right of the card. The following presets are available:

   - **No rights**: Deselects all rights.

   - **Operators**: Provides access to basic DataMiner functionality, without any permission to edit or delete elements, services, Automation scripts, documents, etc.

   - **Power users**: Provides full access to the DMS, without any permission to change the DMS configuration.

   - **Administrators (read-only access to security)**: Selects all rights, except security configuration rights.

   - **Administrators**: Selects all rights.
  
   > [!TIP]
   > See also:
   >
   > - [DataMiner user permissions](xref:DataMiner_user_permissions)
   > - [Which user permissions are included in which security preset?](xref:Frequently_asked_questions_about_user_group_settings#which-user-permissions-are-included-in-which-security-preset)

   Next to these standard presets, there is the possibility to maintain custom presets.

   - **Save rights as preset...**: Save the currently selected rights to a preset if it is not yet saved as a preset.

   - **Reset**: Revert all changes made to the rights of the currently selected user group.

   - **Export preset**: Export the currently selected rights/preset to a preset file (in JSON format).

   - **Import preset**: Import a preset file.

   - **Delete preset**: Delete the currently selected custom preset.
  
   Updating presets can be done as follows:
   
   - Renaming a preset can be done by selecting the preset, deleting it, and then saving it with another name.
   
   - To override a certain preset, save it as a new preset using the same name.
   
   > [!NOTE]
   > Any changes to the presets will not automatically be reflected in other places.

1. To configure notifications for the group, go to the *Alerts* tab and follow the same procedure as for alerts for a single user. See [Configuring user notifications](xref:Configuring_user_notifications).

   > [!NOTE]
   > In contrast to alerts for a single user, alerts for a group cannot be sent with Alerter.

1. Click *Apply*.
