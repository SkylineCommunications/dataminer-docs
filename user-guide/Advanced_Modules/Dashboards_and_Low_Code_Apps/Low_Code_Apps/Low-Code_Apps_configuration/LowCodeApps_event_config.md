---
uid: LowCodeApps_event_config
---

# Configuring low-code app events

You can configure actions for different types of events in DataMiner Low-Code Apps. These are the main types:

- *On open*: This event takes place when a page or panel is opened and all components are done loading. (See [Configuring a page of a low-code app](xref:LowCodeApps_page_config) and [Configuring a panel of a low-code app](xref:LowCodeApps_panel_config).)

  > [!NOTE]
  > Prior to DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7<!--RN 39604 + 39682 + 39636-->, this type of event is only available for low-code app pages and is called "On page load".

- *On click*: This event takes place when a user clicks a button. (See [Configuring the header bar of a low-code app page](xref:LowCodeApps_header_config).)

- *On close*: Available from DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7 onwards<!--RN 39604 + 39682 + 39668-->. This event takes place when a page or panel is closed.

  - A page can be closed either by manually navigating away using the sidebar or via an action.

  - A panel can be closed by clicking outside of it (if it was opened as an overlay), or when a [*Close a panel*](xref:LowCodeApps_event_config#closing-a-panel-of-the-app) or [*Close all panels*](xref:LowCodeApps_event_config#closing-all-panels-of-the-app) action is executed.

  > [!NOTE]
  >
  > - Navigating to the next page is blocked until all configured actions are executed.
  > - A panel will close only after all configured actions are executed.
  > - Actions linked to an *On close* page or panel event will not be executed when you close the app.

Other types are possible depending on the component and the DataMiner version. For each of these events, you can configure actions as detailed below.

> [!TIP]
> Actions can be combined and chained to create more complex behavior. For example, an *Open a page* action can be followed by an *Open a panel* action to open a panel on a specific page. While the panel is being opened, a *Launch a script* action can execute an Automation script that updates parameters that will be displayed on that panel. All of this can be triggered from a header bar button, for example on the initial page.
>
> See also: [Tutorials — Running a script when a page opens](xref:Tutorial_Apps_Script_Upon_Page_Load) and [Tutorials — Chaining actions](xref:Tutorial_Apps_Chaining_Actions).

## Launching a script

To configure an event to launch a script:

1. Select *Launch a script* and select the script.

1. If the script requires input such as dummies and parameters, configure these as well.

   When applicable, you can link a parameter to an existing feed. To do so, you can use the link icon (from DataMiner 10.3.5/10.4.0 onwards<!--  RN 35837 -->), or the *Use feed* checkbox (in earlier DataMiner versions).

1. Optionally, click the *Show settings* button to configure [script execution options](xref:Script_execution_options).

> [!NOTE]
> Feeds can often contain multiple values, and therefore the values will be wrapped in a JSON array. To be consistent, this will also be the case when only a single value is fed.

> [!IMPORTANT]
> From DataMiner 10.3.0 [CU14]/10.4.0 [CU2]/10.4.5 onwards<!-- RN 39027 -->, linking a script parameter to an empty feed will fill it with an empty array. The dialog to manually enter a parameter will no longer be shown when the action is launched. This change can break existing implementations when it is not handled by the script.

## Navigating to a URL

To configure an event to navigate to a URL:

1. Select *Navigate to a URL* and specify the URL.

   > [!TIP]
   >
   > - You can link the URL to a feed using the [feed link syntax](xref:Feed_Link#syntax).
   > - In the Template Editor (available from DataMiner 10.4.1/10.5.0 onwards), you can create dynamic links or pass context to a script by incorporating variables within the URL, denoted by enclosing the column name within curly brackets ("`{}`")<!--RN 34761-->. See [Dynamically referencing feed values in text](xref:Feed_Link).

1. Optionally, to open the webpage in a new tab, enable the option *Open in new tab*.

## Opening a page of the app

To configure an event to open another page of the app:

- Select *Open a page* and select the page.

## Opening a panel of the app

To configure an event to open a panel of the app:

1. select *Open a panel* and select the panel.

1. In the *Where* box, select where the panel should be opened: in a pop-up window, on the left, or on the right.

1. In the *Width* box, specify the width of the panel (in %) compared to the rest of the app.

1. Specify how the panel should be opened:

   - From DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7 onwards<!--RN 39649-->, you can select one of the following options:

     - *Basic*: The panel opens on top of the page.

     - *As overlay*: If a panel is opened as an overlay, the background for the panel is slightly blurred, and the panel is automatically hidden as soon as the user clicks outside of it. This is the default setting.

     - *Draggable*: This option is only available when *Where* is set to open the panel in a pop-up window. When the panel is draggable, you can move the panel by left-clicking and dragging the header of the panel to its destination.

   - Prior to DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7, to set the panel to open as an overlay, toggle the *As overlay* button.

## Closing a panel of the app

To configure an event to close a panel of the app:

1. Select *Close a panel* and select the panel.

1. In the *Where* box, select where the panel that should be closed is located: in a pop-up window, on the left, or on the right. This is necessary in case the same panel is opened multiple times in different places.

## Closing all panels of the app

Available from DataMiner 10.3.0 [CU16]/ 10.4.0 [CU4]/10.4.7 onwards<!--RN 39625-->.

To configure an event to close all panels of the app:

- Select *Close all panels*.

> [!NOTE]
> Prior to DataMiner 10.3.0 [CU16]/ 10.4.0 [CU4]/10.4.7, navigating to a different low-code app page would close any open panels. From DataMiner 10.3.0 [CU16]/ 10.4.0 [CU4]/10.4.7 onwards, panels remain open when you navigate to a different page. To ensure older apps function correctly after upgrading to DataMiner 10.3.0 [CU16]/ 10.4.0 [CU4]/10.4.7 or higher, an *On close* page event with a *Close all panels* action is automatically configured for each page of apps created before the upgrade<!--RN 39632-->. New pages and new apps added after the upgrade will not have these events configured.

## Opening an app

To configure an event to open another low-code app that has been published in your DMS:

- Select *Open an app* and select the app.

  > [!NOTE]
  > *Drafts* apps are included in the list of apps you can select.

## Opening a monitoring card

Available from DataMiner 10.3.4/10.4.0 onwards<!-- RN 35661 -->. To configure an event to open a monitoring card of a specific element, service, or view:

### [From DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12 onwards<!--RN 40814-->](#tab/tabid-1)

1. Select *Open monitoring card*.

1. In the *Type* box, select a type: element, service, or view.

1. Specify how you want to select the element, service, or view:

   - *ID*: Allows you to choose from a dropdown list of available elements, services, or views. This is the default option.

   - *Name*: Allows you to manually enter the name of the element, service, or view.

1. Based on the selected type, choose the element, service, or view for which the monitoring card should be opened:

   - If you selected the *ID* option, choose the desired element, service, or view from the dropdown list.

   - If you selected the *Name* option, enter the name manually.

   - To link to a feed instead of selecting a fixed element, service, or view, click the link icon next to the selection box, select the feed, and click *Apply*.

     If you selected the *Name* option, you can link to a text input feed, which allows you to dynamically enter the name of the element, service, or view in the published app.

     ![Open monitoring card](~/user-guide/images/Open_Monitoring_Card.gif)<br>*Low-Code Apps module in DataMiner 10.4.11*

1. Select *Add action*.

### [Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12](#tab/tabid-2)

1. Select *Open monitoring card*.

1. In the *Type* box, select a type: element, service, or view.

1. Based on the selected type, select the element, service, or view for which the monitoring card should be opened.

   > [!NOTE]
   > From DataMiner 10.3.5/10.4.0 onwards<!--  RN 35986 -->, instead of linking to a fixed element, service, or view, you can link to a feed. To do so, click the link icon to the right of the selection box, select the feed, and click *Apply*.

1. Select *Add action*.

***

> [!NOTE]
> When a low-code app is embedded in Cube (e.g. in Visual Overview), an *Open monitoring card* action will open the specified card in Cube.

## Executing a component action

This option is only displayed if there is a component action that can be executed.

To configure an event to execute a component action:

1. Select *Execute component action* and specify which action should be executed.

> [!NOTE]
> Actions applied to components will exclusively take effect on components that are currently visible. Any action attempted on an invisible component will be disregarded, along with any subsequent actions related to it.

Examples:

- If you configure this action for a [Table](xref:DashboardTable) component, you can select the options *Clear selection*, *Fetch the data*, or *Select an item*. Or from DataMiner 10.2.10/10.3.0 onwards, you can select *Fetch the data* for any component that uses query data as input, so that users can manually refresh the displayed data.

- If you add a line chart component and a button component, you can configure this action on the button and select the option *Set viewport*<!-- RN 39254 -->, so that users can use the button to set the viewport for the line chart. The action has two arguments, *To* and *From*, which can be either set to a static value or linked to a numeric value feed. Available from DataMiner 10.3.5/10.4.0 onwards. Prior to DataMiner 10.3.0 [CU14]/10.4.0 [CU2]/10.4.5, this option is named *Set timespan*<!-- RN 35933 -->.

- From DataMiner 10.3.0 [CU4]/10.4.0 [CU2]/10.4.5 onwards<!--RN 38974-->, if you configure this action for a [Node edge graph](xref:DashboardNodeEdgeGraph) component, you can select the option *Clear selection*.

- From DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 onwards<!--RN 40252-->, if you add a [numeric input](xref:DashboardNumericInputFeed), [text input](xref:DashboardTextInputFeed), or [search input](xref:DashboardSearchInputFeed) component, you can configure this action on, for example, a button and select the option *Set value*, so that users can use the button to set the current value of the component, which can either be set to a static value or linked to a feed.

  ![Set value](~/user-guide/images/Set_Value.gif)<br>*Grid, text input, and table components in DataMiner 10.4.9*

- From DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards<!--RN 40569-->, if you add a [time range feed component](xref:DashboardTimeRangeFeed), you can configure this action on, for example, a button and select the option *Set value*, so that users can use the button to set the current value of the component, which can either be set to a preset or custom time range.

  ![Set value - time range](~/user-guide/images/Set_Value_Time_Range.gif)<br>*Time range feed, button, and line & area chart components in DataMiner 10.4.11*

## Showing a context menu

From DataMiner 10.4.1/10.5.0 onwards<!--RN 37209-->, this option is only available during the configuration of actions in the [Template Editor](xref:Template_Editor) for *Icon*, *Rectangle*, and *Ellipse* layers.

To configure an event to show a context menu:

1. Select *Show context menu*.

1. Provide the necessary details for your menu item:

   - Optionally, click the gray square to the left, and choose an icon from the dropdown list or search for a specific one using the search bar functionality.

      The selected icon will be displayed in the square.

   - Enter a label name.

   - Click the ![Configure actions](~/user-guide/images/Configure_Actions.png) button to configure one or more actions to execute when the menu item is clicked.

     Save the actions by selecting *Ok* in the lower right corner.

1. Optionally, add additional menu items, following the same steps until you are satisfied with the number of menu items.

   > [!NOTE]
   >
   > - If there are multiple menu items, you can change their order by clicking the ![*Drag-and-drop*](~/user-guide/images/drag-and-drop.png) button and dragging the item up or down in the list. Release the mouse button when you reach the position where you want to place the selected item.
   > - To delete a menu item, click the ![Trashcan](~/user-guide/images/Trashcan.png) button.

## Showing a notification

Available from DataMiner 10.3.0 [CU12]/10.4.3 onwards<!--RN 38548-->. To configure an event to show a notification in the lower right corner of a low-code app:

1. Select *Show a notification*.

1. Provide the necessary details for your notification:

   - In the *Title* box, enter a custom title for the notification.

     > [!NOTE]
     > Only the first 80 characters of a title are displayed.

   - Optionally, in the *Message* box, enter a custom message that is displayed when the event is triggered.

     > [!NOTE]
     > Only the first 400 characters of a message are displayed.

   - To automatically dismiss the notification after it appears, enable the *Automatically clear notification* option. If this option is disabled, the notification stays visible until it is manually closed. Enabled by default.

   - Optionally, in the *Duration* box, specify how long (in seconds) the notification remains visible. If you do not edit the duration, the notification is displayed for 5 seconds by default. This option is only available when the *Automatically clear notification* option is enabled.

1. Select *Add action*.

> [!NOTE]
>
> - A maximum of 100 notifications can be open simultaneously. If a new notification appears when 100 notifications are already open, the oldest one is automatically removed.
> - In the Template Editor (available from DataMiner 10.4.1/10.5.0 onwards), you can enter a column name surrounded by curly brackets ("`{}`") to insert the corresponding cell value inside your title or message text.

## Configuring another action for the same event

After you have configured an action, you can click *Upon completion* to configure another action that should occur as soon as the previous action is completed.

Alternatively, you can configure another action that should happen at the same time with the *Add action* button in the lower right corner.

## Removing an action

To remove an action you have configured for an event:

1. In the action configuration window, click the garbage can icon in the top-right corner of the section for that action.

1. Click the confirmation icon.
