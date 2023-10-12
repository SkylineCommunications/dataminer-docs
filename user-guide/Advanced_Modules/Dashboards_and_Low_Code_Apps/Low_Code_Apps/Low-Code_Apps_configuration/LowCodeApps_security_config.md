---
uid: LowCodeApps_security_config
---

# Configuring security for a low-code app

To configure which users can access and/or edit a low-code application:

1. In the app editor, click the user icon in the top-right corner and select *Settings*.

1. In the *Allowed to view the application* box, specify the names of the users and/or groups that should be allowed to view the app.

1. In the *Allowed to edit the application* box, specify the names of the users and/or groups that should be allowed to edit the app.

1. Close the *Settings* window with the X in the top-right corner.

Keep this in mind when you configure security for the Low-Code Apps module:

- Security also needs to be configured on DataMiner level. To view, add, edit, delete, or publish low-code applications, users need to have the necessary user permissions under [Modules > User-definable apps](xref:DataMiner_user_permissions#modules--user-definable-apps) as well as the [DataMiner web apps](xref:DataMiner_user_permissions#general--dataminer-web-apps--dataminer-cube-mobile-access) user permission.

- If you do not configure security on app level, everyone with the necessary permissions on DataMiner level will be able to view and edit the app.

- If you restrict the view access for an app but do not restrict edit access, everyone with view access and the necessary permissions on DataMiner level will be able to edit the app. If you restrict both the view and edit access, only users with edit access wil be able to edit the app.

> [!TIP]
> See also: [Managing user access for DataMiner apps](https://community.dataminer.services/video/managing-user-access-for-dataminer-apps/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)
