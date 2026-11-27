---
uid: LCA_UI
---

# Overview of the Low-Code Apps UI

Low-code apps can vary greatly in appearance depending on their configuration, for example in terms of the number of pages, app name, color, and whether a page header bar is enabled. However, the Low-Code Apps module generally consists of the following main components:

- [Header bar](#the-low-code-apps-header-bar) (1)

- [Sidebar](#the-low-code-apps-sidebar) (2)

- [Details pane](#the-low-code-apps-details-pane) (3)

Note that the sidebar may be absent if the app consists of only one page.

![Low-Code Apps UI](~/dataminer/images/LCA_UI.png)<br>*Low-Code Apps module in DataMiner 10.6.4*

## The Low-Code Apps header bar

![Low-Code Apps header bar](~/dataminer/images/LCA_Header_Bar.png)<br>*Low-Code Apps header bar in DataMiner 10.6.4*

The look and functionality of the Low-Code Apps header bar are aligned with the [standard web app header bar](xref:Accessing_the_web_apps#web-app-header-bar).

Specific to low-code apps, the header bar contains the following items:

- Pencil icon: Click this button to access the app's edit mode. See [Editing an app](xref:Editing_custom_apps).

- Ellipsis button: Click this button to open a context menu that provides access to the following options:

  - *History*: Allows you to [retrieve an earlier app version](xref:LowCodeApps_earlier_version). Prior to DataMiner 10.6.0 [CU10]/10.7.1<!--RN 46917-->, this option is named *Versions*.

  - *Permissions* / *Settings*: Allows you to [configure app security](xref:LowCodeApps_security_config), determining which users and groups are allowed to view and/or edit the app.

  - *Duplicate app*: Allows you to create a copy of the currently opened low-code app. After clicking this option, the newly created app will automatically be opened in a new browser tab.

## The Low-Code Apps sidebar

The sidebar allows you to **navigate between the pages in a low-code app**. It is only shown when the app contains more than one page.

The sidebar contains a button for each app page, identified by the custom icon configured for that page. See [Customizing the icon and color of an app](xref:LowCodeApps_Layout#customizing-the-icon-and-color-of-an-app).

At the top of the sidebar, a hamburger button allows you to expand or collapse the sidebar. When expanded, the names of the app pages are shown next to the icons.

![A hamburger button allows you to expand or collapse the Low-Code Apps sidebar](~/dataminer/images/LCA_Sidebar.gif)<br>*Low-Code Apps sidebar in DataMiner 10.6.4*

## The Low-Code Apps details pane

The details pane is the **main content area** of a low-code app. It displays all components configured for the currently selected page.

Depending on how the app has been set up, this area can contain a wide range of components, such as tables, charts, forms, graphs, and images. As a result, the exact appearance and functionality of the details pane can differ from one app to another.

If a [page header bar has been enabled](xref:LowCodeApps_header_config), it is shown at the top of the details pane, directly below the main Low-Code Apps header bar. This page header bar can contain buttons that provide quick access to page-specific actions, such as running an automation script, opening a panel, or navigating to a hidden page. Some buttons may execute an action directly, while others may open a dropdown menu with additional actions.

In the example below, the page header bar has been enabled.

![An example of the Low-Code Apps details pane](~/dataminer/images/LCA_Details_Pane.png)<br>*Low-Code Apps details pane in DataMiner 10.6.4*

> [!TIP]
> See also:
>
> - [Configuring an app page](xref:LowCodeApps_page_config)
> - [Configuring an app panel](xref:LowCodeApps_panel_config)
