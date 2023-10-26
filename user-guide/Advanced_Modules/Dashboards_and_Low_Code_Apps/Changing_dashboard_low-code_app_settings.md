---
uid: Changing_dashboard_settings
---

# Changing dashboard settings

1. Select the dashboard in the list pane.

1. In the dashboard header bar, click the pencil icon to start editing.

1. Without selecting any of the dashboard components, go to the settings tab on the right.

   If a component is selected, this tab will instead show the settings for that component. In that case, click an empty area of the dashboard first.

1. Configure the following settings as required:

   - **Dashboard configuration**

     - *Use dynamic units*: Available from DataMiner 10.0.11 onwards. This option determines whether parameter units will change dynamically based on their value and protocol definition, in components where this is supported.

     - *Allow components to shift*: This option determines whether components will move to make room for a component that is dragged across the dashboard. If the option is not selected, the position of the components becomes fixed.

     - *Lazy load components*: Available from DataMiner 10.3.4/10.4.0 onwards. Select this option to make sure components are only initialized when they first appear on the screen. This will shorten the load time considerably and improve the performance of the dashboard. <!-- RN 35469 -->

       > [!NOTE]
       >
       > - This option is only available if you add the `showAdvancedSettings=true` option to the dashboard URL.
       > - Even when this option is enabled, components will not be lazy loaded in edit mode.

     - *Fit to view*: Available from DataMiner 10.2.7/10.3.0 onwards. Select this option to make sure all components are automatically adjusted to always be fully visible, so the user does not need to scroll.

     - *Number of columns*: Available from DataMiner 10.0.10 onwards. Allows you to configure in how many columns components can be displayed in the dashboard (maximum: 50). If you change the number of columns to a lower number and the columns currently contain components, these components will be automatically relocated when necessary.

   - **User access/Dashboard security**

     - *Allowed to view the dashboard*: Available from DataMiner 10.2.0/10.1.1 onwards. Allows you to restrict access to the dashboard to specific users only. From DataMiner 10.2.4/10.3.0 onwards, you can also select entire user groups.

     - *Allowed to edit the dashboard*: Available from DataMiner 10.2.0/10.1.1 onwards. Allows you to assign edit permission for the dashboard to specific users only. From DataMiner 10.2.4/10.3.0 onwards, you can also select entire user groups.

       > [!NOTE]
       > The built-in Administrator account always has full access to all dashboards.

   - **Dashboard updates**

     - *Allow WebSocket communication*: Web socket communication is enabled by default, but can be disabled, e.g. in case this is not allowed by the firewalls in your network.

     - *Fast polling timer*: The polling interval (in s) for components that display real-time information.

     - *Slow polling timer*: The polling interval (in s) for components that do not display real-time information.

1. Click the pencil icon again to leave edit mode.

> [!NOTE]
> The settings for a page or panel of a custom low-code app can be configured in the same way as those for a dashboard. See [Configuring a page of a low-code app](xref:LowCodeApps_page_config) or [Configuring a panel of a low-code app](xref:LowCodeApps_panel_config).

## [Changing low-code app settings](#tab/tabid-2)

Low-code apps can consist of one or more pages that display the content of the application. While the [user access](xref:LowCodeApps_security_config) is set at the application level, other settings such as page and panel configuration and updates should be configured for each specific low-code app page or panel.

To change the settings of a low-code app page/panel:

1. Make sure the low-code app is in edit mode. See [Editing a low-code application](xref:Editing_custom_apps).

1. Select a page in the leftmost pane of the app editor. If you want to edit the panel settings, open the *panels* section in the page configuration pane.

1. Without selecting any of the low-code app components, in the configuration pane to the right, go to the settings tab.

   If a component is selected, this tab will instead show the settings for that component. In that case, click an empty area of the low-code app first.

1. Configure the following settings as required:

   - **Page/Panel configuration**

     - *Use dynamic units*: Available from DataMiner 10.0.11 onwards. This option determines whether parameter units will change dynamically based on their value and protocol definition, in components where this is supported.

     - *Allow components to shift*: This option determines whether components will move to make room for a component that is dragged across the low-code app page. If the option is not selected, the position of the components becomes fixed.

     - *Lazy load components*: Available from DataMiner 10.3.4/10.4.0 onwards. Select this option to make sure components are only initialized when they first appear on the screen. This will shorten the load time considerably and improve the performance of the low-code app. <!-- RN 35469 -->

       > [!NOTE]
       >
       > - This option is only available if you add the `showAdvancedSettings=true` option to the dashboard URL.
       > - Even when this option is enabled, components will not be lazy loaded in edit mode.

     - *Fit to view*: Available from DataMiner 10.2.7/10.3.0 onwards. Select this option to make sure all components are automatically adjusted to always be fully visible, so the user does not need to scroll.

     - *Number of columns*: Available from DataMiner 10.0.10 onwards. Allows you to configure in how many columns components can be displayed in the low-code app (maximum: 50). If you change the number of columns to a lower number and the columns currently contain components, these components will be automatically relocated when necessary.

   - **Page/Panel updates**

     - *Allow WebSocket communication*: Web socket communication is enabled by default, but can be disabled, e.g. in case this is not allowed by the firewalls in your network.

     - *Fast polling timer*: The polling interval (in s) for components that display real-time information.

     - *Slow polling timer*: The polling interval (in s) for components that do not display real-time information.

1. Click the pencil icon again to leave edit mode.

1. To save your changes and publish it, click the ![Publish](~/user-guide/images/AppPublishIcon.png) icon in the header bar.

   > [!NOTE]
   > When you close a draft app you have been working on, it is saved automatically. As such, if you do not want to publish your app immediately, you can just close it to save it as a draft. However, draft apps are not shown by default on the landing page. To view them, click the cogwheel button and activate *Show draft applications*.

***
