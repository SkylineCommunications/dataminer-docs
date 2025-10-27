---
uid: Editing_custom_apps
---

# Editing an app

You can begin editing a low-code app from within the app or from the DataMiner landing page. If you want to edit a draft app, make sure the draft applications are shown: click the cogwheel button on the landing page and activate *Show draft applications*.

From the DataMiner **landing page** (supported from DataMiner 10.3.0 [CU10]/10.4.0 onwards<!-- RN 37830 -->):

1. Click the ellipsis ("...") button next to the app you want to edit.

   > [!NOTE]
   > Prior to DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9<!--RN 43226-->, the ellipsis button only appears when you hover over the app icon.

1. Select *Edit*.

From **within an application**:

- From DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 onwards<!--RN 40077-->, click the pencil icon in the top-right corner.

- Prior to DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9, click the user icon in the top-right corner and select *Edit*.

Once you are in edit mode, you can [customize the app](xref:LowCodeApps_Layout#customizing-the-icon-and-color-of-an-app), or edit the [pages](xref:LowCodeApps_page_config), [panels](xref:LowCodeApps_panel_config), [header bar](xref:LowCodeApps_header_config), [events](xref:LowCodeApps_event_config), or [security](xref:LowCodeApps_security_config) as needed.

When the app is ready, click the ![Publish](~/dataminer/images/AppPublishIcon.png) icon in the header bar to save your changes and publish it.

If any users have the app open when an update is published, they will see the updated version as soon as they refresh the web page. Until then, they will be able to keep using the previous version. Only in case changes have been made to server-side objects such as Automation scripts or GQI data sources that an app makes use of, will this cause a problem for an older version of the app that remains open, as the app will no longer be able to use the server object it expects.

> [!IMPORTANT]
> Once an app has been published, it is not possible to revert it to a draft.

> [!NOTE]
>
> - To view, add, edit, delete, or publish low-code applications, you need to have the necessary user permissions under [Modules > User-definable apps](xref:DataMiner_user_permissions#modules--user-definable-apps) as well as the [DataMiner web apps](xref:DataMiner_user_permissions#general--dataminer-web-apps) user permission.
> - It is not possible to edit a low-code app on a mobile device.<!-- RN 39036 -->

> [!TIP]
> See also: [Tutorials - Editing an existing app](xref:Tutorial_Apps_Edit_Existing_App)
