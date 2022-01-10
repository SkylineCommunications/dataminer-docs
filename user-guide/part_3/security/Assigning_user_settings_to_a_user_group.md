# Assigning user settings to a user group

All users who have ever logged on to a DataMiner Agent using DataMiner Cube have their own personalized user settings on that DataMiner Agent.

However, it is also possible for the system administrators to configure the settings for an entire user group, so that all users in the group share the same default settings, or to lock certain default values, so that users will not be able to change certain settings.

To a user group, you can assign either a new set of user settings containing only factory defaults, or an existing set of user settings from another user or user group.

1. In DataMiner Cube, go to *Apps* > *Settings*.

2. In the lower left corner of the *Settings* card, click *Configure group.*

    > [!NOTE]
    > If you do not see the *Configure group* button, then you are not allowed to configure user group settings. In that case, ask your system administrator to grant you the necessary permissions.

3. In the *Group settings* dialog box, select the user group to which you want to assign a set of user settings, and click *Assign.*

4. In the *Create settings for group \[GroupName\]* dialog box, you can either:

    - Click *New settings*, if you want to assign a new set of user settings containing nothing but factory defaults.

    - Click *Copy settings from* and select a user group from the list, if you want to copy the set of user settings from that user group to the user group you selected in step 3.

5. Click *OK* to close the *Create settings for group \[GroupName\]* dialog box.
