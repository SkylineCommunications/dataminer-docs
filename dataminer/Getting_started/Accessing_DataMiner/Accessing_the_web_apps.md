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
   > - System Administrators can [configure whether the landing page is displayed](xref:Configuring_the_landing_page#configuring-whether-the-landing-page-is-displayed) or whether the Monitoring app opens directly when a user browses to a DMA. If the Monitoring app opens directly, you can access the other web apps by clicking the icon in the top-left corner.

1. Sign in using your DataMiner credentials.

1. On the landing page, select the app you want to open. See [Available web apps](#available-web-apps).

   ![Landing page](~/dataminer/images/DataMiner_Landing_Page2.png)<br>*DataMiner landing page in DataMiner 10.5.11*

### The landing page header bar

![Landing page header bar](~/dataminer/images/Landing_page_header_bar.png)<br>*Landing page header bar in DataMiner 10.5.12*

The landing page header bar contains the following items, from left to right:

- DataMiner icon or waffle icon (depending on your DataMiner version<!--RN 43024-->): Opens a compact overview of the available web apps.

- DataMiner System name: Available from DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 onwards<!--RN 43226-->. The name of the DMS is displayed. In the case of a standalone DMA, the DMA name is shown instead. Click this name to refresh the landing page.

- ![Help](~/dataminer/images/Landing_page_help_icon.png) icon: Provides access to several handy pages (from DataMiner web 10.4.0 [CU20]/10.5.0 [CU8]/10.5.11 onwards<!-- 43583 -->):

  - *Community*: Links to the DataMiner Dojo blog, a page where you can suggest new DataMiner features, and our Q&A forum.

  - *Documentation*: Links to the main page of the DataMiner documentation.

  - *Status*: Displays the current status of the various DataMiner services.

  - *Feedback*: Allows you to provide direct feedback on DataMiner.

  - *Support*: Displays contact information for DataMiner Support.

- User button: A button with the initials or an image of the current user. Click this button to open a menu that provides access to the following options:

  - *About*: Displays information about DataMiner and your installed versions, e.g., web version and server version.

  - *User settings*: Allows you to configure user-specific settings such as [customizing the landing page theme](#customizing-the-landing-page-theme) or changing your password. The user settings will only be available if at least one of the following conditions is met:

    - The `?showAdvancedSettings=true` argument has been added to the landing page URL.

    - You are able to change your password:

      - In *System Center* > *Users*, the setting *User cannot change password* is disabled for your account.

      - You have the [*Modules* > *System configuration* > *Security* > *Specific* > *Limited administrator* permission](xref:DataMiner_user_permissions#modules--system-configuration--security--specific--limited-administrator).

      - You are not logged in with external or delegated authentication.

  - *Sign out*: Logs you out and returns you to the logon screen.

### Available web apps

The landing page provides access to the following web apps:

![Landing page](~/dataminer/images/DataMiner_Landing_Page.png)<br>*DataMiner landing page in DataMiner 10.5.11*

- (1) [Dashboards app](xref:newR_D): Use this app to create, manage, and view dashboards that provide insights into your monitored system.

- (2) [Monitoring app](xref:Working_with_the_Monitoring_app): Access a web-based interface similar to DataMiner Cube, with more limited functionality but broader accessibility.

- (3) [Low-Code Apps](xref:Application_framework): Build and use custom apps to interact with data from a DMS or from external sources.

  - You can access any of the available low-code apps by clicking the relevant app icon, or [create a new low-code app](xref:Creating_custom_apps).

  - Draft apps are not shown by default. To view them, click the cogwheel button and activate *Show draft applications*.

  - From DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 onwards<!--RN 43226-->, you can use the quick filter box in the top-left corner of the Low-Code Apps section to quickly search for apps by name.

To access a **compact overview of all available web apps**:

- On the landing page: Click the DataMiner icon or waffle icon (depending on your DataMiner version<!--RN 43024-->) in the top-left corner of the landing page.

- From within a web app: Click the waffle icon in the top-left corner of the app.

This overview allows you to easily switch between web apps. Additionally, from DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 onwards<!--RN 43226-->, a quick filter box is available to help you narrow down the apps, and a *dataminer.services* button provides direct access to the dataminer.services home page.

### Customizing the landing page theme

From DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 onwards<!--RN 43226-->, you can customize the DataMiner landing page theme:

1. Add the argument `?showAdvancedSettings=true` to the landing page URL.

1. Click the user button in the top-right corner of the page and select *User settings*. Prior to DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12<!--RN 43966-->, click the cogwheel button in the top-right corner of the page.

1. Select one of the available themes:

   - *Light* (Default)

   - *Dark*

   - *System*

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
