---
uid: DataMiner_Apps
description: Learn what DataMiner Apps are, which types of apps you can use, how to open an app, and which settings apply to all Low-Code Apps and New Apps.
---

# DataMiner Apps

DataMiner Apps are the apps that you can open from the DataMiner landing page, from DataMiner Cube, and from within the DataMiner web apps. DataMiner Apps are available in two types:

- [Low-Code Apps](xref:Application_framework): Apps that you create and edit directly in DataMiner, in the low-code editor.

- [New Apps](xref:New_apps): Apps that are built outside DataMiner, for example with AI-assisted tooling, and then uploaded to your DataMiner System. Available from DataMiner 10.6.0 [CU10]/10.7.0 [CU0]/10.7.1 onwards<!-- RN 45878 -->.

Individual apps of both types look and behave in the same way. They share the same header bar and the same sign-in, so you do not need to log in again when you open an app. This page describes what applies to all DataMiner Apps.

> [!NOTE]
> Dashboards are not DataMiner Apps. They are created and managed in the [Dashboards app](xref:newR_D).

To decide which type of app best suits your needs, see [Choosing between New Apps and Low-Code Apps](xref:Dashboards_and_Low_Code_Apps#choosing-between-new-apps-and-low-code-apps).

## Opening an app

To open a DataMiner app, do any of the following:

- On the DataMiner landing page, click the app.

  Draft apps are not shown by default. To show them, click the cogwheel button and activate *Show draft applications*.

- In DataMiner Cube, open the [*Apps* pane](xref:DataMiner_Cube_sidebar#apps-pane) in the sidebar and select the app.

- In a DataMiner web app, such as the Dashboards app, the Monitoring app, or a low-code app:

  1. Click the icon in the upper-left corner of the app.

     The icon depends on the app you have opened. For example, in the Dashboards app, this is a waffle icon, while in a low-code app, this is the icon that was selected for that app.

     A compact overview of all available web apps and DataMiner Apps will be displayed.

  1. Select the app.

     You can use the quick filter box in this overview to narrow down the list.

## Header bar, theme, and embedding

All DataMiner Apps show the DataMiner header bar.

- For apps created in the low-code editor, the header bar uses the accent color of the app.

- For new apps, the theme you select in your user settings (*Light*, *Dark*, or *System*) is applied to the header bar and to any app content that supports both a light and a dark color scheme.

If an app manages its own theme, the user settings will show the message "Theme setting is managed by the app.", and your selected theme will not affect that app.

> [!TIP]
> If you add `?embed` to the URL of an app, the header bar is hidden. This is useful when you want to embed the app in another page.

## Managing DataMiner Apps

The following topics apply to all DataMiner Apps:

- [Configuring app security](xref:LowCodeApps_security_config): Specify which users can view or edit an app.

- [Organizing the apps on the landing page in sections](xref:LowCodeApps_organizing_landing_page): Group apps in sections on the DataMiner landing page.

To view, add, edit, delete, or publish apps, users also need the necessary [User-definable apps permissions](xref:DataMiner_user_permissions#modules--user-definable-apps) as well as the [DataMiner web apps](xref:DataMiner_user_permissions#general--dataminer-web-apps) user permission.
