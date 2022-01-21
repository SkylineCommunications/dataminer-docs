---
uid: Dashboards_app_UI_from_DataMiner_10_0_0_10_0_2_onwards
---

## Dashboards app UI from DataMiner 10.0.0/10.0.2 onwards

The main page of the app consists of a header bar, a sidebar, and a details pane.

- The header bar contains the following items, from left to right:

    - Apps button: The button in the top-left corner provides quick access to other DataMiner web apps.

    - *Dashboards* button: Click this button to return to the main page of the app at any time.

    - Search box: The box in the middle of the header bar allows you to search the app. As soon as you activate the box, a list of suggestions is displayed below it. The list gets updated with new suggestions as you type. Select a suggestion in the list to open the corresponding dashboard or dashboard folder.

    - User button: A button with the initials of the current user is displayed in the top-right corner. Click this button to open a menu that provides access to the following options:

        - *Settings*: Allows you to manage any available dashboard themes and configure whether specific actions are pinned to the dashboard header bar.

        - *About*: Displays information about the app.

        - *Sign out*: Logs you out of the app and returns you to the logon screen.

- The sidebar on the left contains two icons, which can be used to expand different panes:

    | Icon                                                                                                | Description                                                                                                                                                                          |
    |-------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | ![](../../images/DashboardsX_navigation.png) | Opens the navigation pane, which allows you to navigate through the different dashboard folders in the app. Click a folder or dashboard to view it in the details pane on the right. |
    | ![](../../images/DashboardsX_recent.png)         | Displays a list of recent items.                                                                                                                                                     |

    Right-click in either of the panes or click the ... button to open a menu with the following options:

    - *Delete*: Only available if a dashboard or folder is selected. See [Deleting a dashboard](Deleting_a_dashboard.md).

    - *Rename*: Only available if a dashboard or a folder is selected.

    - *Copy*: Only available if a dashboard or folder is selected. See [Duplicating a dashboard](Duplicating_a_dashboard.md)

    - *Move*: Only available if a dashboard or folder is selected. See [Managing dashboard folders](Managing_dashboard_folders.md).

    - *Import dashboard*: Allows you to import an example dashboard. By default, it will be added in the selected folder, but a different folder can be specified. See [Creating a dashboard based on an example](Creating_a_dashboard_based_on_an_example.md).

    - *New dashboard*: Adds a new dashboard. By default, it will be added in the selected folder, but a different folder can be specified. See [Creating a completely new dashboard](Creating_a_completely_new_dashboard.md).

    - *New folder*: Adds a new folder in the selected folder.

- The large pane on the right shows any folder or dashboard selected in the navigation pane.

    If no dashboard is selected, buttons are available that allow you to create a new blank dashboard, to create a dashboard based on an example or to navigate to a recently used dashboard.     If an empty folder is selected, from DataMiner 10.0.13 onwards, buttons are available that allow you to create or import a dashboard directly in that folder.
    If a dashboard is selected, the header bar of this pane can display a number of buttons, depending on the dashboard and the settings of the app:

    | Button                                                                                        | Description                                                                                                                                                                                                                                                                                                                                                                                                                               |
    |-------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | ![](../../images/DashboardsX_refresh.png) | Loads the most recent data in the displayed dashboard.                                                                                                                                                                                                                                                                                                                                                                                    |
    | Start editing                                                                                   | Allows you to start editing the dashboard. In edit mode, the navigation pane on the left will be hidden.                                                                                                                                                                                                                                                                                                                                  |
    | Stop editing                                                                                    | Closes edit mode                                                                                                                                                                                                                                                                                                                                                                                                                          |
    | Clear all                                                                                       | Only displayed if the dashboard contains at least one feed. Clears the selection of all the feeds in the dashboard.                                                                                                                                                                                                                                                                                                                       |
    | Start sharing                                                                                   | Allows you to share the dashboard using the DataMiner Cloud Platform. See [Sharing a dashboard using the Live Sharing Service](Sharing_a_dashboard_using_the_Live_Sharing_Service.md).<br> This is a soft-launch feature that is only available if the DataMiner Agent is connected to the cloud. See [Connecting your DataMiner System to the cloud](../../part_51/AboutCloudPlatform/Connecting_your_DataMiner_System_to_the_cloud.md). |

    In the settings of the dashboards app, you can configure whether the edit mode and clear feeds buttons are always displayed or “pinned” to the header bar, or instead accessible via an arrow button in the top-right corner of a dashboard.

> [!NOTE]
> If the app is viewed on a small screen, no options to edit dashboards or dashboard settings will be available.
>
