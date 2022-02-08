---
uid: Dashboards_app_UI_prior_to_DataMiner_10_0_0_10_0_2
---

# Dashboards app UI prior to DataMiner 10.0.0/10.0.2

The main page of the app consists of a header bar, a navigation pane, and a details pane.

- By default, the header bar contains the following buttons:

    | Button | Description |
    |--------|-------------|
    | ![Apps button](~/user-guide/images/NewRD_apps.png) | Apps button, for quick access to other DataMiner web apps. |
    | Dashboards | Click this button to return to the main page of the app at any time. |
    | New dashboard | Only displayed if a folder or dashboard is selected. |
    | ![Settings button](~/user-guide/images/NewRD_Settings.png) | Click this button to open a window where you can manage any available dashboard themes. |
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

    - *Duplicate/Copy*: Only available if a dashboard or folder is selected. See [Duplicating a dashboard](xref:Duplicating_a_dashboard)

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
>
