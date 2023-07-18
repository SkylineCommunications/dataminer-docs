---
uid: LowCodeApps_page_config
---

# Configuring a page of a low-code app

Low-code apps can consist of one or more pages that display the content of the application. These are similar to [DataMiner dashboards](xref:newR_D), though they include extra features and components that allow interaction with the displayed data. Data from a component on a page can be fed to components on the same page or on another page or panel, so that different pages and panels can influence each other.

Each page can be configured with its own label and icon so users will easily be able to spot the purpose of the page. You can also hide pages from the app sidebar, for instance because you only want them to be displayed if a user clicks a specific button.

To configure a page:

1. Make sure the page is selected in the leftmost pane of the app editor. This will open the page configuration pane to the right.

1. At the top of the page configuration pane, specify a name for the page.

1. In the *icon* section, select an icon for the page.

1. To configure a header bar for the page, see [Configuring the header bar of a low-code app page](xref:LowCodeApps_header_config).

1. Click the pencil icon to configure the components on the page. Configuring these components is done in a very similar same way as configuring components in the Dashboards app. See [Configuring dashboard components](xref:Configuring_dashboard_components) and [Changing dashboard settings](xref:Changing_dashboard_settings). For a list of the available components, refer to [Available visualizations](xref:Available_visualizations).

1. If one or more actions should be triggered when the page is loaded, in the page configuration pane, open the *Events* section and click the configuration button next to *On page load*. Then configure the action(s) that should be triggered. See [Configuring low-code app events](xref:LowCodeApps_event_config)

1. If you want to hide the page from the sidebar:

   1. Make sure the sidebar is fully expanded. In case it is collapsed, you can expand it with the hamburger button at the top.

   1. From DataMiner 10.3.6/10.4.0 onwards, click the ellipsis button next to the page name, and select *Hide from sidebar*.<!-- RN 36097 --> Prior to DataMiner 10.3.6/10.4.0, hover over the page name until a crossed-out eye icon is displayed and click the icon.

   When a page is hidden in an app, its icon is grayed out in the sidebar in edit mode. To show the page again, follow the same steps as detailed above. From DataMiner 10.3.6/10.4.0 onwards, instead of *Hide from sidebar*, select *Show in sidebar*.<!-- RN 36097 --> Prior to DataMiner 10.3.6/10.4.0, instead of a crossed-out eye icon, you will need to click a full eye icon.

> [!NOTE]
>
> - From DataMiner 10.3.6/10.4.0 onwards, to delete a page, click the ellipsis button next to the page name in the pane on the left, select *Delete*, and click the confirmation icon.<!-- RN 36097 --> Prior to DataMiner 10.3.6/10.4.0, to delete a page, click the garbage can icon next to the page name in the pane on the left, and then click the confirmation icon.
> - From DataMiner 10.3.6/10.4.0 onwards, to duplicate a page, click the ellipsis button next to the page name in the pane on the left, and select *Duplicate*. <!-- RN 36097 -->

> [!TIP]
> See also: [Tutorials - Managing the pages of an app](xref:Tutorial_Apps_Managing_Pages)
