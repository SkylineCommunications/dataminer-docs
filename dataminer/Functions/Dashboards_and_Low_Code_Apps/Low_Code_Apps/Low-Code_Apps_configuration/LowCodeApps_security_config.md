---
uid: LowCodeApps_security_config
---

# Configuring security for a low-code app

When you configure a low-code app, you can specify which users can access and/or edit the app. Unlike other app settings, this is a setting that is not version-specific, which means that if you configure it for one version of the app, it will apply for all versions.

## [From DataMiner 10.3.0 [CU19]/10.4.0 [CU7]/10.4.10 onwards](#tab/tabid-1)

<!--RN 40501-->

1. Click the ellipsis button ("...")<!--RN 40077--> in the top-right corner and select *Permissions* or *Settings*, depending on your DataMiner version.<!-- RN 43536 -->

1. In the *Permissions* window, determine which users and groups are allowed to view and/or edit the app. You can configure permissions for specific users, groups, and everyone. Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41079-->, this section of the settings is called "Access" instead.

   - The *Everyone* field is always available. This determines the access level for all users who have the [General > DataMiner web apps](xref:DataMiner_user_permissions#general--dataminer-web-apps) user permission as well as any other user permissions required to access specific apps.

   - Click *Add user/group*, and enter the names of specific users and/or groups to give them permission to view or edit the app. Then, assign them an appropriate access level.

   - When you have added a user or group, you can always remove them again with the garbage can icon.

   The available access levels are:

   - *No access*: Users cannot view or edit the low-code app. The app will be hidden from the DataMiner landing page and will be inaccessible even with a direct link. This option is only available in the dropdown menu next to *Everyone*.

   - *Viewer*: Users can view the low-code app. They can interact with the app components, but they cannot make any modifications.

   - *Editor*: Users can view and edit the low-code app. They can modify the app, including renaming and deleting it.

   > [!NOTE]
   >
   > - If you set *Everyone* to *No access*, you must assign at least one user or group as an editor to keep the app functional. If you do not add your own user account as an editor, you will lose the ability to make further changes to the application.
   > - If a user has been given an access level both as an individual and as part of a group, the level with the most privileges is the one that counts.
   > - The built-in Administrator account always has full access to all apps.

1. Click *Apply* in the lower-right corner.

   ![Application settings](~/dataminer/images/Application_Settings.png)<br>*Low-Code Apps settings in DataMiner 10.4.10*

## [Older DataMiner versions](#tab/tabid-2)

1. Click the user icon in the top-right corner and select *Settings*.

1. In the *Allowed to view the application* box, specify the names of the users and/or groups that should be allowed to view the app.

1. In the *Allowed to edit the application* box, specify the names of the users and/or groups that should be allowed to edit the app.

1. Close the *Settings* window with the X in the top-right corner.

***

Keep this in mind when you configure security for the Low-Code Apps module:

- Security also needs to be configured on DataMiner level. To view, add, edit, delete, or publish low-code applications, users need to have the necessary user permissions under [Modules > User-definable apps](xref:DataMiner_user_permissions#modules--user-definable-apps) as well as the [DataMiner web apps](xref:DataMiner_user_permissions#general--dataminer-web-apps) user permission.

- If you do not configure security on app level, everyone with the necessary permissions on DataMiner level will be able to view and edit the app.

- If you restrict the view access for an app but do not restrict edit access, everyone with view access and the necessary permissions on DataMiner level will be able to edit the app. If you restrict both the view and edit access, only users with edit access will be able to edit the app.

> [!TIP]
> See also: [Managing user access for DataMiner apps](https://www.youtube.com/watch?v=j83krLYXnmQ) ![Video](~/dataminer/images/video_Duo.png)
