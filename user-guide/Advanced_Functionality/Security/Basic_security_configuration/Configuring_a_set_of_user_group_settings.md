---
uid: Configuring_a_set_of_user_group_settings
---

# Configuring a set of user group settings

> [!TIP]
> See also:
> [How To Video
DataMiner Cube – Creating group settings](https://community.dataminer.services/video/dataminer-cube-creating-group-settings/) ![Video](~/user-guide/images/video_Duo.png)

If a set of user settings has been assigned to a user group, you can open that set and specify a default value for every setting in it.

1. In DataMiner Cube, go to *Apps* > *Settings*.

2. In the lower left corner of the *Settings* card, click *Configure group.*

    > [!NOTE]
    > If the *Configure group* button is not displayed, you are not allowed to configure user group settings. In that case, ask your system administrator to grant you the necessary permissions.

3. In the *Group settings* dialog box, select the user group of which you want to configure the user settings, and click *Open*.

    > [!NOTE]
    > If the *Open* button is unavailable, no user settings have been assigned to the group yet. You must assign the settings to the group first in order to configure them. See [Assigning user settings to a user group](xref:Assigning_user_settings_to_a_user_group).

4. Using the table of contents on the left, go through all pages of the *Settings* card and check each user setting. The settings in this window are the same as in the regular user settings window. However, there are some additional features:

    - Click the lock icon next to a setting to make sure users will not be able to change it themselves.

    - Click the eye icon next to a setting to hide the setting from the users. When the icon shows a line across the eye, the setting is hidden.

    - For the Alarm Console, you can select to *Enforce Alarm Console pages*. When you do so, users will not be able to remove the enforced tab pages or change any filters that are applied to them, but they will be able to change settings via the hamburger menu. If you do not want them to be able to change these settings either, also select the checkbox *Enforce Alarm Console tab page settings*.

    > [!TIP]
    > See also:
    > [User settings](xref:User_settings)

5. Click *OK* to close the *Settings* card.
