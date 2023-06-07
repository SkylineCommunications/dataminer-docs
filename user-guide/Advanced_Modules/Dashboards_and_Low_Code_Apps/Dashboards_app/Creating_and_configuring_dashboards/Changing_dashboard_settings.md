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

     - *Allow WebSocket communication*: Web socket communication is enabled by default, but can be disabled, e.g. in case this is not allowed by the firewalls in your network.

   - **Dashboard updates**

       > [!NOTE]
       > Web socket communication is not supported on DMAs using operating systems prior to Windows Server 2012 or Windows 8.

     - *Fast polling timer*: The polling interval (in s) for components that display real-time information.

     - *Slow polling timer*: The polling interval (in s) for components that do not display real-time information.

1. Click the pencil icon again to leave edit mode.

> [!NOTE]
> The settings for a page or panel of a custom low-code app can be configured in the same way as those for a dashboard. See [Configuring a page of a low-code app](xref:LowCodeApps_page_config) or [Configuring a panel of a low-code app](xref:LowCodeApps_panel_config).
