---
uid: Creating_custom_apps
---

# Creating apps

To learn how to create a low-code app, you can follow the steps below or watch this short video:

<div style="width: 100%; max-width: 800px;">
  <video style="width: 100%; aspect-ratio: 16 / 9; height: auto;" controls>
    <source src="~/dataminer/images/Creating_a_low-code_app.mp4" type="video/mp4">
  </video>
</div>

*Watch first: [Creating your first dashboard](xref:Creating_a_completely_new_dashboard)*

## Prerequisites

To view, add, edit, delete, or publish low-code applications, you need to have the following user permissions:

- [*Modules* > *User-definable apps*](xref:DataMiner_user_permissions#modules--user-definable-apps)

- [*General* > *DataMiner web apps*](xref:DataMiner_user_permissions#general--dataminer-web-apps)

## Creating a new low-code app

1. Go to the [DataMiner landing page](xref:Accessing_the_web_apps#dataminer-landing-page).

1. To add a new app:

   - From DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 onwards<!--RN 43226-->:

     - If no apps exist yet, click *Create your first app*.

     - Otherwise, select the tab where you want the app to appear, and click *Create app*. To add the app without assigning it to a specific section, open the *All apps* tab or the *Other apps* tab before creating the app.

   - Prior to DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9:

     - If no apps exist yet, click *Create a new app*.

     - Otherwise, hover the mouse pointer over the *Other apps* section and click the "+" button next to *Other apps*.

   > [!NOTE]
   > To organize your app in a newly created section, see [Organizing the apps on the landing page in sections](xref:LowCodeApps_organizing_landing_page).

1. Specify the name of your new app in the header bar, instead of the default name "New application".

   Note that from DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4 onwards<!--RN 42220-->, app names are limited to 150 characters.

1. To customize the color and icon for the app, see [Customizing the icon and color of an app](xref:LowCodeApps_Layout#customizing-the-icon-and-color-of-an-app).

1. Add and configure the necessary [pages](xref:LowCodeApps_page_config), [panels](xref:LowCodeApps_panel_config), and [events](xref:LowCodeApps_event_config) for the app.

   > [!TIP]
   > To configure the settings for pages and panels in a low-code app, see [Changing app settings](xref:Changing_low-code_app_settings).

1. To customize who can access or edit the application, see [Configuring app security](xref:LowCodeApps_security_config).

1. When your app is ready, click the ![Publish](~/dataminer/images/AppPublishIcon.png) icon in the header bar to save your changes and publish it.

> [!IMPORTANT]
> Once an app has been published, it is not possible to revert it to a draft.

> [!NOTE]
> When you close a draft app you have been working on, it is saved automatically. As such, if you do not want to publish your app immediately, you can just close it to save it as a draft. However, draft apps are not shown by default on the landing page. To view them, enable the *Show drafts* toggle next to the search bar. Prior to DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12<!--RN 43966-->,click the cogwheel button and activate *Show draft applications*.

> [!TIP]
> See also: [Tutorials - Creating and publishing an app](xref:Tutorial_Apps_Creating_And_Publishing)

## Duplicating an existing low-code app

From DataMiner 10.3.0 [CU10]/10.4.1 onwards<!-- RN 37698+37724 -->, it is possible to duplicate an existing low-code app. You can do so [from the DataMiner landing page](#duplicating-an-app-from-the-dataminer-landing-page) or [from the page of the app itself](#duplicating-an-app-from-the-app-page-itself).

### Duplicating an app from the DataMiner landing page

1. Go to the [DataMiner landing page](xref:Accessing_the_web_apps#dataminer-landing-page).

1. Click the ellipsis ("...") button next to the app you want to duplicate and select *Duplicate*.

   > [!NOTE]
   > Prior to DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9<!--RN 43226-->, the ellipsis button only appears when you hover over the app icon.

The most recently published app version will now be duplicated. If the app has not yet been published, its draft version will be duplicated instead.

The newly created duplicate will be assigned a unique name and will automatically be opened in a new browser tab. On the root page, this landing app will be added to the list if the *Show drafts* or *Show draft applications* option (depending on your DataMiner version<!--RN 43966-->) is enabled.

### Duplicating an app from the app page itself

#### [From DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 onwards<!--RN 40077-->](#tab/tabid-1)

1. Open the version you want to duplicate:

   - To duplicate the most recently published version of the app, open the app.

   - To duplicate the current draft version of an app, open the app and go to edit mode.

   - To duplicate a different version:

     1. In the top-right corner, click the ellipsis button ("...") and select *Versions*.

     1. Select the desired version.

     > [!NOTE]
     > You can only duplicate an older version of an app if you have permission to edit the app in question.

1. In the top-right corner, click the ellipsis button ("..."), and select *Duplicate app*.

   The low-code app will be copied and the newly created app will automatically be opened in a new browser tab.

#### [Prior to DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9](#tab/tabid-2)

1. Open the version you want to duplicate:

   - To duplicate the most recently published version of the app, open the app.

   - To duplicate the current draft version of an app, open the app and go to edit mode.

   - To duplicate a different version:

     1. In the top-right corner, click the user icon and select *Versions*.

     1. Select the desired version.

     > [!NOTE]
     > You can only duplicate an older version of an app if you have permission to edit the app in question.

1. In the top-right corner, click the user icon, and select *Duplicate* in the user menu.

   The current draft version will be copied and the newly created app will automatically be opened in a new browser tab.

***
