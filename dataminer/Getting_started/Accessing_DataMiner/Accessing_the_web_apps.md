---
uid: Accessing_the_web_apps
---

# Accessing the web apps

You can access [all DataMiner web apps](#available-web-apps) via the DataMiner landing page.

<div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
  <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
    <b>💡 TIPS TO TAKE FLIGHT</b><br>
    Did you know that, depending on the configuration and version of your DMS, you can access certain web apps from the <a href="xref:DataMiner_Cube_sidebar#apps-pane" style="color: #657AB7;"><i>Apps</i> pane</a> in DataMiner Cube as well?
  </div>
  <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
</div>

## DataMiner landing page

To access the DataMiner landing page:

1. In a supported web browser (Google Chrome, Microsoft Edge, Mozilla Firefox, or Safari), navigate to:

   ```txt
   https://[DMA]/root/
   ```

   Replace `[DMA]` with the IP address or hostname of the DataMiner Agent you want to connect to.

   > [!NOTE]
   >
   > - If you are trying to use the remote access URL (e.g., `https://ziine-skyline.on.dataminer.services/root/`) to access the web apps, make sure you have been granted [remote access](xref:About_Remote_Access).
   > - System Administrators can [configure whether the landing page is displayed](xref:Configuring_the_landing_page#configuring-whether-the-landing-page-is-displayed) or whether the Monitoring app opens directly when a user browses to a DMA. If the Monitoring app opens directly, you can access the other web apps by clicking the icon in the upper-left corner.

1. Sign in using your DataMiner credentials.

1. On the landing page, select the app you want to open. See [Available web apps](#available-web-apps).

   ![Landing page](~/dataminer/images/DataMiner_Landing_Page2.png)<br>*DataMiner landing page in DataMiner 10.5.11*

The landing page shows the standard [web app header bar](#web-app-header-bar).

### Available web apps

The landing page provides access to the following web apps:

![Landing page](~/dataminer/images/DataMiner_Landing_Page.png)<br>*DataMiner landing page in DataMiner 10.5.11*

- (1) [Dashboards app](xref:newR_D): Use this app to create, manage, and view dashboards that provide insights into your monitored system.

- (2) [Monitoring app](xref:Working_with_the_Monitoring_app): Access a web-based interface similar to DataMiner Cube, with more limited functionality but broader accessibility.

- (3) [Low-Code Apps](xref:Application_framework): Build and use custom apps to interact with data from a DMS or from external sources.

  - You can access any of the available low-code apps by clicking the relevant app icon, or [create a new low-code app](xref:Creating_custom_apps).

  - Draft apps are not shown by default. To view them, enable the *Show drafts* toggle next to the search bar. Prior to DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12<!--RN 43966-->, click the cogwheel button and activate *Show draft applications*.

  - From DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 onwards<!--RN 43226-->, you can use the quick filter box in the upper-left corner of the Low-Code Apps section to quickly search for apps by name.

  - From DataMiner 10.6.0 [CU10]/10.7.0 [CU0]/10.7.1 onwards<!--RN 45878-->, apps created in the low-code editor and apps added through the [New DataMiner Apps experience](xref:New_apps) are both shown here and are both part of DataMiner Apps. To add an app, click the arrow next to the *Add* button. The menu allows you to [upload a new app](xref:Uploading_a_new_app), browse the Catalog, or create an app in the low-code editor. Clicking the *Add* button itself will create a low-code app.

## Web app header bar

The DataMiner landing page and the DataMiner web apps all show the same header bar at the top of the page. This header bar gives you access to the same general functionality everywhere, in addition to any buttons or menus that are specific to the app you have opened.

![Landing page header bar](~/dataminer/images/Landing_page_header_bar.png)<br>*Landing page header bar in DataMiner 10.5.12*

The header bar contains the following items, from left to right:

- **App overview icon**: Opens a [compact overview of all available web apps and DataMiner Apps](#switching-between-apps).

  Depending on the app you have opened and your DataMiner version<!--RN 43024-->, this icon is displayed as a DataMiner icon, a waffle icon, or the icon of the app itself. It always has the same function.

- **DataMiner System name**: Available from DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 onwards<!--RN 43226-->. The name of the DMS is displayed. In the case of a standalone DMA, the DMA name is shown instead.

  Click this name to go to the [DataMiner landing page](#dataminer-landing-page). If you are already on the landing page, the page will be refreshed.

- **App-specific items**: Depending on the app, the header bar can contain additional buttons and menus, for example to edit or publish the app, or a search box.  A [new app](xref:New_apps) can also add its own buttons and menus.

- ![Help](~/dataminer/images/Landing_page_help_icon.png) **Help icon**: Provides access to several handy pages (from DataMiner web 10.4.0 [CU20]/10.5.0 [CU8]/10.5.11 onwards<!-- 43583 -->):

  - *Community*: Links to the DataMiner Dojo blog, a page where you can suggest new DataMiner features, and our Q&A forum.

  - *Documentation*: Links to the main page of the DataMiner documentation.

  - *Status*: Displays the current status of the various DataMiner services.

  - *Feedback*: Allows you to provide direct feedback on your experience with DataMiner. From DataMiner 10.5.0 [CU18]/10.6.0 [CU6]/10.6.9 onwards<!--RN 45853-->, this option can also be used to report an issue.

  - *Support*: Displays contact information for DataMiner Support.

- **User button**: A button with the initials or an image of the current user. Click this button to open a menu that provides access to the following options:

  - *About*: Displays information about DataMiner and your installed versions, e.g., web version and server version. In an app, this option displays information about the app instead.

  - *Help*: Available up to DataMiner 10.4.0 [CU19]/10.5.0 [CU7]/10.5.10. Opens the DataMiner documentation.

  - *(User) Settings*: Available from DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43803-->. Provides access to [user-specific configuration options](#user-settings).

  - *Sign out*: Logs you out and returns you to the logon screen.

  Some apps add their own entries to this menu, for example an app-specific settings option.

### Switching between apps

To open a compact overview of all available web apps, click the app overview icon in the upper-left corner of the header bar.

This overview allows you to easily switch between apps. Additionally, from DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 onwards<!--RN 43226-->, a quick filter box is available to help you narrow down the apps, and a *dataminer.services* button provides direct access to the dataminer.services home page.

### User settings

The *(User) Settings* option in the user menu provides access to the following options:

- *Theme*: Select one of the available themes:

  - *Light* (Default)

  - *Dark*

  - *System*

  Prior to DataMiner 10.6.0 [CU10]/10.7.1<!--RN 46917-->, this option is only available when the *showAdvancedSettings=true* argument has been added to the URL.

  If an app manages its own theme, the message "Theme setting is managed by the app." is displayed above this setting, and your selected theme will not affect that app.

- *Time zone*: Available from DataMiner 10.5.0 [CU15]/10.6.0 [CU3]/10.6.6 onwards<!--RN 45170-->. This option is only configurable when no [default time zone](xref:ClientSettings_json#setting-the-default-time-zone-for-dataminer-web-apps) has been configured for the DataMiner web apps.

  The following options are available:

  - *From client OS*: Use the time zone configured in the client operating system.

  - *Custom*: Select a custom time zone from the dropdown list.

- *Password*: Allows users to change their password without needing to access Cube.

  > [!NOTE]
  > This setting is only available if the following conditions are met:
  >
  > - In *System Center* > *Users*, the user's *User cannot change password* setting must be disabled.
  > - The user must have the [*Modules* > *System configuration* > *Security* > *Specific* > *Limited administrator* permission](xref:DataMiner_user_permissions#modules--system-configuration--security--specific--limited-administrator).
  > - The user must not be logged in with external or delegated authentication.

Prior to DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12<!--RN 43966-->, the user settings are accessible via the cogwheel button in the upper-right corner of the page instead.

### Hiding the header bar

If you add `?embed` to the URL of a [DataMiner App](xref:DataMiner_Apps), the header bar is hidden. This is useful when you want to embed the app in another page.

## Installing a web app as a standalone app

In many browsers, it is possible to install a web app as a standalone app on your computer.

To do so:

1. Open the web app.

1. Click the install button on the right side of the browser address bar.

   > [!NOTE]
   > The install button will not appear in the browser address bar if you used a [remote access](xref:About_Remote_Access) URL to open the web app.

1. Select *Install*.

1. Optionally, you can pin the app to your taskbar or add a desktop shortcut to quickly open it.

   ![Standalone app](~/dataminer/images/Standalone_App.png)<br>*Low-Code Apps module in DataMiner 10.5.8*
