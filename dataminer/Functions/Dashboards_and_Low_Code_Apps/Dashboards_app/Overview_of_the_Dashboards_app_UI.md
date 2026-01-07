---
uid: Overview_of_the_Dashboards_app_UI
---

# Overview of the Dashboards app UI

The main page of the Dashboards app consists of the following main components:

- [Header bar](#the-dashboards-app-header-bar) (1)

- [Sidebar](#the-dashboards-app-sidebar) (2)

- [Details pane](#the-dashboards-app-details-pane) (3)

![Dashboards app UI](~/dataminer/images/Dashboards_app_UI.png)<br>*Dashboards app in DataMiner 10.4.5*

## The Dashboards app header bar

![Header bar](~/dataminer/images/Dashboards_app_headerbar.png)<br>*Dashboards app header bar in DataMiner 10.5.2*

The header bar contains the following items, from left to right:

- Apps button: The button in the top-left corner provides quick access to other DataMiner web apps.

- *Dashboards* button: Click this button to return to the main page of the app at any time.

- Search box: The box in the middle of the header bar allows you to search the app. As soon as you activate the box, a list of suggestions is displayed below it. The list gets updated with new suggestions as you type. Select a suggestion in the list to open the corresponding dashboard or dashboard folder.

- WebSocket connection status: Available from DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4<!--RN 38676--> up to DataMiner 10.4.0 [CU10]/10.5.1. This indicator shows the current status of your WebSocket connection. The available statuses include:

  - ![Successful connection](~/dataminer/images/WebSocket_Success.png) : A stable connection with instant updates.

  - ![Offline](~/dataminer/images/WebSocket_No_Connection.png) : An offline connection.

  - ![No real-time connection](~/dataminer/images/WebSocket_No_Real-Time_Connection.png) : No real-time connection could be established. Updates will happen more slowly than usual.

  - ![Establishing connection](~/dataminer/images/WebSocket_Establishing_Connection.gif) : Re-establishing a WebSocket connection. Updates will happen more slowly than usual.

  From DataMiner 10.4.0 [CU11]/10.5.2 onwards<!--RN 41669-->, WebSocket connection issues are indicated via colored banners directly below the header bar instead. When the connection is successful, no banner is displayed. Other options include:

  - The connection is offline: A red banner with the message `You are offline` is displayed.

    > [!NOTE]
    > If your connection is offline, a red "x" icon is also displayed on the user button.

  - The connection has been interrupted: An orange banner with the message `Connection has been interrupted` is displayed.

  - The connection is being re-established: An orange banner with the message `Busy recovering connection...` is displayed.

  - The connection has been re-established: A green banner with the message `Connection recovered` is displayed.

- User button: A button with the initials or an image of the current user is displayed in the top-right corner. Click this button to open a menu that provides access to the following options:

  - *(Dashboard) settings*: Allows you to manage any available [dashboard theme](xref:Configuring_the_dashboard_layout) (1) and configure whether [specific actions](#the-dashboards-app-details-pane) are pinned to the dashboard header bar (2).

    ![Dashboard settings](~/dataminer/images/DashboardSettings.png)<br>*Dashboard settings in DataMiner 10.4.10*

  - *About*: Displays information about the app.

  - *Help*: Available up to DataMiner 10.4.0 [CU19]/10.5.0 [CU7]/10.5.10. Opens the DataMiner documentation.

  - *User settings*: Available from DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43803-->. Allows you to configure user-specific settings such as changing your password.

    > [!NOTE]
    > User settings are only available if the following conditions are met:
    >
    > - In *System Center* > *Users*, the user's *User cannot change password* setting must be disabled.
    > - The user must have the [*Modules* > *System configuration* > *Security* > *Specific* > *Limited administrator* permission](xref:DataMiner_user_permissions#modules--system-configuration--security--specific--limited-administrator).
    > - The user must not be logged in with external or delegated authentication.

  - *Sign out*: Logs you out of the app and returns you to the logon screen.

## The Dashboards app sidebar

The sidebar on the left contains icons that can be used to expand different panes:

| Icon | Description |
|------|-------------|
| ![Navigation pane icon](~/dataminer/images/DashboardsX_navigation.png) | Opens the navigation pane, which allows you to navigate through the different dashboard folders in the app. Click a folder or dashboard to view it in the details pane on the right. |
| ![Recent items icon](~/dataminer/images/DashboardsX_recent.png) | Displays a list of recent items. |
| ![Private dashboards icon](~/dataminer/images/DashboardsX_private.png) | Displays a list of private dashboards. These are dashboards that can only be accessed by specific users (configured in the [dashboard settings](xref:Configuring_dashboard_security)). This icon is displayed from DataMiner 10.2.7/10.3.0 onwards if there are private dashboards available. |
| ![Shared dashboards icon](~/dataminer/images/DashboardsX_shared.png) | Displays a list of dashboards that have been shared via dataminer.services. This icon is displayed from DataMiner 10.2.7/10.3.0 onwards if there are shared dashboards available. |

### [From DataMiner 10.5.0 [CU11]/10.6.2 onwards<!--RN 44222 + 44432-->](#tab/tabid-1)

Right-click the background of the sidebar, or click the ellipsis ("...") button next to a dashboard or folder, to open a context menu with the following options:

- *Add* > *Dashboard*: Creates a new dashboard. By default, it will be added in the selected folder, but a different folder can be specified. See [Creating a completely new dashboard](xref:Creating_a_completely_new_dashboard).

- *Add* > *Folder*: Creates a new folder in the selected folder.

- *Add* > *From import*: Allows you to import an example dashboard. See [Creating a dashboard based on an example](xref:Creating_a_dashboard_based_on_an_example).

- *Add* > *From Catalog*: Allows you to deploy a dashboard from the DataMiner Catalog.

- *Settings*: Allows you to rename or move a dashboard or folder, or configure access permissions. See [Managing dashboard folders](xref:Managing_dashboard_folders).

  When a dashboard folder is selected and the parameter *showAdvancedSettings=true* has been added to the URL, the pop-up window also contains the option *Preserve selections*. When this option is selected, any selection you make in a dashboard in the folder is preserved when you navigate to another dashboard in the folder. Note that this only applies to the folder itself, not to any other folders it may contain.

- *Delete*: Deletes the selected dashboard or folder. See [Deleting a dashboard](xref:Deleting_a_dashboard).

- *Open in new tab*: Opens the selected dashboard in a new browser tab.

- *Duplicate*: Duplicates the selected dashboard. See [Duplicating a dashboard](xref:Duplicating_a_dashboard).

> [!NOTE]
> You can use the TAB key to navigate through dashboards and folders in the Dashboards app sidebar. The selected item is highlighted and can be opened by pressing Enter. Selected buttons are outlined in green and can also be activated with Enter. When a context menu is open, you can navigate through its options using the arrow keys<!--RN 44297-->.

### [Older versions](#tab/tabid-2)

Right-click in either of the panes or click the ... button to open a menu with the following options:

- *Open in new tab*: Opens the selected dashboard in a new browser tab.

- *Create folder* or *New folder*: Adds a new folder in the selected folder.

- *Create dashboard* or *New dashboard*: Adds a new dashboard. By default, it will be added in the selected folder, but a different folder can be specified. See [Creating a completely new dashboard](xref:Creating_a_completely_new_dashboard).

- *Import dashboard*: Allows you to import an example dashboard. By default, it will be added in the selected folder, but a different folder can be specified. See [Creating a dashboard based on an example](xref:Creating_a_dashboard_based_on_an_example).

- *Edit*: Available from DataMiner 10.2.0/10.1.12 up to DataMiner 10.3.0 [CU12]/10.4.3<!--RN 38278-->, if a dashboard folder is selected. Opens a pop-up window where you can rename the folder.

  The pop-up window also contains the option *Preserve feed selections*. When this option is selected, any selection you make in a dashboard in the folder is preserved when you navigate to another dashboard in the folder. Note that this only applies to the folder itself, not to any other folders it may contain.

- *Rename*: Only available if a non-shared dashboard is selected, or if a folder is selected prior to DataMiner 10.2.0/10.1.12. Allows you to rename the dashboard or folder. Obsolete from DataMiner 10.3.0 [CU12]/10.4.3 onwards<!--RN 38278-->.

- *Settings*: Available from DataMiner 10.3.0 [CU12]/10.4.3 onwards<!--RN 38278-->, if a dashboard or dashboard folder is selected. Opens a pop-up window where you can rename or move a dashboard or folder, or edit access to the dashboard or folder. See [Managing dashboard folders](xref:Managing_dashboard_folders).

  When a dashboard folder is selected and the parameter *showAdvancedSettings=true* has been added to the URL, the pop-up window also contains the option *Preserve selections*. Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12, this option is labeled *Preserve feed selections*. When this option is selected, any selection you make in a dashboard in the folder is preserved when you navigate to another dashboard in the folder. Note that this only applies to the folder itself, not to any other folders it may contain.

  > [!NOTE]
  > Prior to DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11<!--RN 40709-->, the *Preserve feed selections* option is available in the settings pop-up window regardless of whether the *showAdvancedSettings=true* parameter is present in the URL.

- *Duplicate* or *Copy*: Only available if a dashboard is selected. See [Duplicating a dashboard](xref:Duplicating_a_dashboard).

- *Move*: Only available if a dashboard or folder is selected. See [Managing dashboard folders](xref:Managing_dashboard_folders). Obsolete from DataMiner 10.3.0 [CU12]/10.4.3 onwards<!--RN 38278-->.

- *Delete*: Only available if a dashboard or folder is selected. See [Deleting a dashboard](xref:Deleting_a_dashboard).

***

## The Dashboards app details pane

The large pane on the right displays the contents of the selected folder or dashboard and provides context-specific actions.

### When no dashboard or folder is selected

- **From DataMiner 10.5.0 [CU11]/10.6.2 onwards<!--RN 44222-->**: An overview of all dashboards and folders is displayed as tiles. Each tile contains either a folder icon ![Folder](~/dataminer/images/Dashboard_Folder_Icon.png) or a dashboard icon ![Dashboard](~/dataminer/images/Dashboard_Icon.png), indicating whether it represents a folder or a dashboard. If a dashboard has been [shared via cloud share](xref:Sharing_a_dashboard#sharing-a-live-dashboard-via-cloud-share), this is indicated on the tile by a blue *Shared* button underneath the dashboard name.

  In the top-right corner of the details pane, the following buttons are available:

  - *Add*: Create a new dashboard or dashboard folder, import an example dashboard, or deploy a dashboard from the DataMiner Catalog.

  - *Settings*: Configure edit access to your dashboards and folders.

- **Prior to DataMiner 10.5.0 [CU11]/10.6.2**: Buttons are available that allow you to create a new blank dashboard, to create a dashboard based on an example, or to navigate to a recently used dashboard.

### When a folder is selected

When a folder is selected, the contents of the folder (subfolders and dashboards) are displayed in the details pane.

Depending on the DataMiner version, the following buttons may be available:

- *Add* > *Dashboard* / *Create dashboard*: Adds a new dashboard to the selected folder. See [Creating a completely new dashboard](xref:Creating_a_completely_new_dashboard).

- *Add* > *Folder*: Adds a new subfolder. Available from DataMiner 10.5.0 [CU11]/10.6.2 onwards.

- *Add* > *From import* / *Import dashboard*: Allows you to import an example dashboard into the selected folder. See [Creating a dashboard based on an example](xref:Creating_a_dashboard_based_on_an_example).

- *Add* > *From Catalog*: Allows you to deploy a dashboard from the DataMiner Catalog. Available from DataMiner 10.5.0 [CU11]/10.6.2 onwards.

- *Settings*: Configure edit access for the folder. Available from DataMiner 10.5.0 [CU11]/10.6.2 onwards.

- ...: Delete the folder. Available from DataMiner 10.5.0 [CU11]/10.6.2 onwards.

### When a dashboard is selected

When a dashboard is selected, the header bar of the details pane can display a number of buttons, depending on the dashboard and the settings of the app:

- Refresh button ![Refresh button](~/dataminer/images/DashboardsX_refresh.png) : Loads the most recent data in the displayed dashboard.

- *Start editing*: Allows you to start editing the dashboard. In edit mode, the navigation pane on the left will be hidden.

- *Stop editing*: Closes edit mode.

- *Clear selections*<!--RN 41141-->/*Clear all*: Only displayed if the dashboard contains at least one component. Clears the selection of all the data in the dashboard.

- *PDF*: Available from DataMiner 10.2.12/10.3.0 onwards. Only displayed in read mode. Allows you to export the dashboard as a PDF file.

- *Share* or *Start sharing*: Allows you to share the dashboard using dataminer.services. See [Sharing a dashboard](xref:Sharing_a_dashboard). This feature is only available in read mode, if the DataMiner System is connected to dataminer.services. See [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

In the [settings of the Dashboards app](#the-dashboards-app-header-bar), you can configure whether the edit mode, clear selections, create report/export as PDF, and share dashboard buttons are always displayed (i.e. “pinned” to the header bar) or instead accessible via a button in the top-right corner of a dashboard.

![Pin actions](~/dataminer/images/Pin_Actions.png)<br>*Dashboard settings in DataMiner 10.6.2*

> [!NOTE]
>
> - If the app is viewed on a small screen, no options to edit dashboards or dashboard settings will be available.
> - Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41141-->, the *Clear selections* option is called *"Clear feeds"*.
