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

   Alternatively, instead of selecting the different separate rights, you can [use a preset](#using-presets-to-assign-rights).

   From DataMiner 10.4.0 [CU12]/10.5.0/10.5.3 onwards<!-- RN 40803 -->, you can also copy the configured rights for a specific group directly to one or more other groups. To do so, make sure any changes have been applied, then click the *Apply rights to other groups* button at the bottom, and select the groups to which these rights should be applied.

1. To configure notifications for the group, go to the *Alerts* tab and follow the same procedure as for alerts for a single user. See [Configuring user notifications](xref:Configuring_user_notifications).

   > [!NOTE]
   > In contrast to alerts for a single user, alerts for a group cannot be sent with Alerter.

1. Click *Apply*.

## Using presets to assign rights

When you are configuring the rights for a group in the *Users / Groups* section in System Center, instead of selecting the different separate rights, you can select one of the available presets. From DataMiner 10.4.0 [CU12]/10.5.0 [CU1]/10.5.3 onwards<!-- RN 41656 -->, the presets are available in a separate section on the right. In earlier DataMiner versions, you can select them in a dropdown box at the top of the card.

The following presets are available by default:

- **No rights**: Deselects all rights.

- **Operators**: Provides access to basic DataMiner functionality, without any permission to edit or delete elements, services, Automation scripts, documents, etc.

- **Power users**: Provides full access to the DMS, without any permission to change the DMS configuration.

- **Administrators (read-only access to security)**: Selects all rights, except security configuration rights.

- **Administrators**: Selects all rights.

In addition to these default presets, from DataMiner 10.4.0 [CU12]/10.5.0 [CU1]/10.5.3 onwards, custom presets are also supported. You can manage these with the buttons at the top of the pane on the right:

| Button | Description |
|--|--|
| ![Reset button](~/dataminer/images/Security_preset_reset.png) | Reverts all changes made to the rights of the currently selected user group. |
| ![Export button](~/dataminer/images/Security_preset_export.png) | Exports the currently selected rights/preset to a preset file (in JSON format). |
| ![Import button](~/dataminer/images/Security_preset_import.png) | Imports a preset file. The imported preset is added to the list of presets and immediately applied to the currently selected group. |
| ![Delete button](~/dataminer/images/Security_preset_delete.png) | Deletes the currently selected custom preset. |

To **add a new preset**, first configure the rights you want to add to the preset, then click the *Save rights as preset* button and specify the name for the preset.

**Updating** an existing custom preset can be done as follows:

- To rename a preset, select the preset, delete it, and then save it with another name.
- To change the rights configured for a preset, save it as a new preset using the same name.

To **save changes** to the selected rights that you have applied using presets, remember to always click the **Apply** button at the bottom of the page.

> [!NOTE]
> If you make changes to an existing preset, these are only applied to the currently selected group (after you click *Apply*). Other groups using that preset will only be updated if a manual change is applied to them. In addition, other users who are looking at the presets at the same time will only be able to see the updated preset if they close and reopen the System Center card so that the updated preset is retrieved from the server.

> [!TIP]
> See also:
>
> - [DataMiner user permissions](xref:DataMiner_user_permissions)
> - [Which user permissions are included in which security preset?](xref:Frequently_asked_questions_about_user_group_settings#which-user-permissions-are-included-in-which-security-preset)
