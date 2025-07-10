---
uid: Accessing_the_web_apps
---

# Accessing the web apps

You can access all DataMiner web apps via the **DataMiner landing page**.

1. In a browser, go to:

   ```txt
   https://[DMA]/root/
   ```

   Replace `[DMA]` with the IP address or hostname of the DataMiner Agent you want to connect to.

   > [!NOTE]
   >
   > - If you are trying to use the remote access URL (e.g. `https://ziine-skyline.on.dataminer.services/root/`) to access the web apps, make sure you have been granted [remote access](xref:About_Remote_Access).
   > - System Administrators can [configure whether the landing page is displayed](xref:Configuring_the_landing_page#configuring-whether-the-landing-page-is-displayed) or whether the Monitoring app opens directly when a user browses to a DMA. If the Monitoring app opens directly, you can access the other web apps by clicking the icon in the top-left corner.

1. Sign in using your DataMiner credentials.

1. On the landing page, click the icon of the app you want to open.

   ![Landing page](~/user-guide/images/DataMiner_Landing_Page.png)<br>*DataMiner landing page in DataMiner 10.5.8*

   Available web apps:

   - (1) [Dashboards app](xref:newR_D): Use this app to create, manage, and view dashboards that provide insights into your monitored system.

     > [!NOTE]
     > We recommend using Google Chrome to access the Dashboards app. Microsoft Edge, Mozilla Firefox, and Safari are also supported.

   - (2) [Monitoring app](xref:Working_with_the_Monitoring_app): Access a web-based interface similar to DataMiner Cube, with more limited functionality but broader accessibility.

   - (3) [Low-Code Apps](xref:Application_framework): Build and use custom apps to interact with data from a DMS or from external sources.

     - You can access any of the available low-code apps by clicking the relevant app icon, or [create a new low-code app](xref:Creating_custom_apps).

     - Draft apps are not shown by default. To view them, click the cogwheel button and activate *Show draft applications*.

To access a **compact overview of all available web apps**:

- On the landing page: Click the DataMiner icon or waffle icon (depending on your DataMiner version<!--RN 43024-->) in the top-left corner of the landing page.

- From within a web app: Click the waffle icon in the top-left corner of the app.

This allows you to switch easily between web apps.

<div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
  <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
    <b>💡 TIPS TO TAKE FLIGHT</b><br>
    Did you know that, depending on the configuration and version of your DMS, you can access certain web apps from the <a href="xref:DataMiner_Cube_sidebar#apps-pane" style="color: #657AB7;"><i>Apps</i> pane</a> in DataMiner Cube as well?
  </div>
  <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
</div>

## Installing a web app as a standalone app

In many browsers, it is possible to install a web app as a standalone app on your computer.

To do so:

1. Open the web app.

1. Click the install button on the right side of the browser address bar.

   > [!NOTE]
   > The install button will not appear in the browser address bar if you used the remote access link to open the web app.

1. Select *Install*.

1. Optionally, you can pin the app to your taskbar or add a desktop shortcut to quickly open it.

   ![Standalone app](~/user-guide/images/Standalone_App.png)<br>*Low-Code Apps module in DataMiner 10.5.8*
