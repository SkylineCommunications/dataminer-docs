---
uid: Overview_of_the_Dashboards_app_UI
---

# Overview of the Dashboards app UI

In DataMiner 10.0.0/10.0.2, the UI of the app has been redesigned. Below, you can find more information:

## [From DataMiner 10.0.0/10.0.2 onwards](#tab/tabid-1)

The main page of the app consists of a header bar, a sidebar, and a details pane.

- The header bar contains the following items, from left to right:

  - Apps button: The button in the top-left corner provides quick access to other DataMiner web apps.

  - *Dashboards* button: Click this button to return to the main page of the app at any time.

  - Search box: The box in the middle of the header bar allows you to search the app. As soon as you activate the box, a list of suggestions is displayed below it. The list gets updated with new suggestions as you type. Select a suggestion in the list to open the corresponding dashboard or dashboard folder.

  - User button: A button with the initials or an image of the current user is displayed in the top-right corner. Click this button to open a menu that provides access to the following options:

    - *Settings*: Allows you to manage any available [dashboard theme](xref:Configuring_the_dashboard_layout) and configure whether specific actions are pinned to the dashboard header bar.

    - *About*: Displays information about the app.

    - *Help*: Opens the DataMiner User Guide.

    - *Sign out*: Logs you out of the app and returns you to the logon screen.

- The sidebar on the left contains icons that can be used to expand different panes:

  | Icon | Description |
  |------|-------------|
  | ![Navigation pane icon](~/user-guide/images/DashboardsX_navigation.png) | Opens the navigation pane, which allows you to navigate through the different dashboard folders in the app. Click a folder or dashboard to view it in the details pane on the right. |
  | ![Recent items icon](~/user-guide/images/DashboardsX_recent.png) | Displays a list of recent items. |
  | ![Private dashboards icon](~/user-guide/images/DashboardsX_private.png) | Displays a list of private dashboards. These are dashboards that can only be accessed by specific users (configured in the [dashboard settings](xref:Changing_dashboard_settings)). This icon is displayed from DataMiner 10.2.7/10.3.0 onwards if there are private dashboards available. |
  | ![Shared dashboards icon](~/user-guide/images/DashboardsX_shared.png) | Displays a list of dashboards that have been shared via dataminer.services. This icon is displayed from DataMiner 10.2.7/10.3.0 onwards if there are shared dashboards available. |

  Right-click in either of the panes or click the ... button to open a menu with the following options:

  - *Open in new tab*: Opens the selected dashboard in a new browser tab.

  - *Create folder* or *New folder*: Adds a new folder in the selected folder.

  - *Create dashboard* or *New dashboard*: Adds a new dashboard. By default, it will be added in the selected folder, but a different folder can be specified. See [Creating a completely new dashboard](xref:Creating_a_completely_new_dashboard).

  - *Import dashboard*: Allows you to import an example dashboard. By default, it will be added in the selected folder, but a different folder can be specified. See [Creating a dashboard based on an example](xref:Creating_a_dashboard_based_on_an_example).

  - *Edit*: Available from DataMiner 10.2.0/10.1.12 onwards, if a dashboard folder is selected. Opens a pop-up window where you can rename the folder.

    The pop-up window also contains the option *Preserve feed selections*. When this option is selected, any feed selection you make in a dashboard in the folder is preserved when you navigate to another dashboard in the folder. Note that this only applies to the folder itself, not to any other folders it may contain.

  - *Rename*: Only available if a non-shared dashboard is selected, or if a folder is selected prior to DataMiner 10.2.0/10.1.12. Allows you to rename the dashboard or folder.

  - *Duplicate* or *Copy*: Only available if a dashboard is selected. See [Duplicating a dashboard](xref:Duplicating_a_dashboard)

  - *Move*: Only available if a dashboard or folder is selected. See [Managing dashboard folders](xref:Managing_dashboard_folders).

  - *Delete*: Only available if a dashboard or folder is selected. See [Deleting a dashboard](xref:Deleting_a_dashboard).

- The large pane on the right shows any folder or dashboard selected in the navigation pane.

  If no dashboard is selected, buttons are available that allow you to create a new blank dashboard, to create a dashboard based on an example or to navigate to a recently used dashboard.

  If an empty folder is selected, from DataMiner 10.0.13 onwards, buttons are available that allow you to create or import a dashboard directly in that folder.

  If a dashboard is selected, the header bar of this pane can display a number of buttons, depending on the dashboard and the settings of the app:

  - Refresh button ![Refresh button](~/user-guide/images/DashboardsX_refresh.png) : Loads the most recent data in the displayed dashboard.

  - **Start editing**: Allows you to start editing the dashboard. In edit mode, the navigation pane on the left will be hidden.

  - **Stop editing**: Closes edit mode.

  - **Clear all**: Only displayed if the dashboard contains at least one feed. Clears the selection of all the feeds in the dashboard.

  - **PDF**: Available from DataMiner 10.2.12/10.3.0 onwards. Only displayed in read mode. Allows you to export the dashboard as a PDF file.

  - **Share** or **Start sharing**: Allows you to share the dashboard using dataminer.services. See [Sharing a dashboard](xref:Sharing_a_dashboard). This feature is only available in read mode, if the DataMiner System is connected to dataminer.services. See [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

  In the settings of the Dashboards app, you can configure whether the edit mode, clear feeds, export as PDF, and share dashboard buttons are always displayed (i.e. “pinned” to the header bar) or instead accessible via a button in the top-right corner of a dashboard.

> [!NOTE]
> If the app is viewed on a small screen, no options to edit dashboards or dashboard settings will be available.

## [Earlier versions](#tab/tabid-2)

The main page of the app consists of a header bar, a navigation pane, and a details pane.

- By default, the header bar contains the following buttons:

    | Button | Description |
    |--------|-------------|
    | ![Apps button](~/user-guide/images/NewRD_apps.png) | Apps button, for quick access to other DataMiner web apps. |
    | Dashboards | Click this button to return to the main page of the app at any time. |
    | New dashboard | Only displayed if a folder or dashboard is selected. |
    | ![Settings button](~/user-guide/images/NewRD_Settings.png) | Click this button to open a window where you can manage any available [dashboard themes](xref:Configuring_the_dashboard_layout). |
    | ![Info button](~/user-guide/images/NewRD_About.png) | Displays information about the app. |
    | \[Username\] | Click the username and select *Log out* to log out of the app. |

    > [!NOTE]
    > If a dashboard is too large to be displayed entirely on the screen, and you scroll downwards, the header bar of the app will be hidden. To display it again, simply scroll upwards.

- The navigation pane on the left shows a tree view of the folders containing the dashboards in the system:

  - Click any of the dashboards in the tree view to open it in the details pane on the right.

  - Use the filter box at the top of the navigation pane to filter the dashboards displayed in the pane.

  - Click the ![Recent dashboards button](~/user-guide/images/recent_dashboards.png) button to switch from the tree view to a list of recent items. Click the ![Tree view button](~/user-guide/images/treeview_dashboards.png) button to switch back to the tree view.

  - Either right-click in the pane or click the ![...](~/user-guide/images/more_dashboards.png) button to open a menu with the following options:

    - *Delete*: Only available if a dashboard or folder is selected. See [Deleting a dashboard](xref:Deleting_a_dashboard).

    - *Duplicate/Copy*: Only available if a dashboard or folder is selected. See [Duplicating a dashboard](xref:Duplicating_a_dashboard).

    - *Rename*: Only available if a dashboard or a folder is selected.

    - *Move*: Only available if a dashboard or folder is selected. See [Managing dashboard folders](xref:Managing_dashboard_folders).

    - *Import dashboard*: Allows you to import an example dashboard. By default, it will be added in the selected folder, but a different folder can be specified. See [Creating a dashboard based on an example](xref:Creating_a_dashboard_based_on_an_example).

    - *New dashboard*: Adds a new dashboard. By default, it will be added in the selected folder, but a different folder can be specified. See [Creating a completely new dashboard](xref:Creating_a_completely_new_dashboard).

    - *New folder*: Adds a new folder in the selected folder, or in the root folder if no folder is selected.

- The large details pane on the right shows detailed information on any folder or dashboard selected in the navigation pane.

  If no dashboard is selected, buttons are available that allow you to create a new blank dashboard, to create a dashboard based on an example or to navigate to a recently used dashboard.

  If a dashboard is selected, the header bar of this pane displays the following buttons, from left to right:

    | Button | Description |
    |--------|-------------|
    | ![Refresh button](~/user-guide/images/NewRD_Refresh.png) | Loads the most recent data in the displayed dashboard.                                                   |
    | ![Edit button](~/user-guide/images/NewRD_Edit.png)       | Allows you to start editing the dashboard. In edit mode, the navigation pane on the left will be hidden. |
    | ![Close edit mode button](~/user-guide/images/NewRD_NoEdit.png)   | Closes edit mode. |

> [!NOTE]
> If the app is viewed using a small screen, no options to edit dashboards or dashboard settings will be available.

***
