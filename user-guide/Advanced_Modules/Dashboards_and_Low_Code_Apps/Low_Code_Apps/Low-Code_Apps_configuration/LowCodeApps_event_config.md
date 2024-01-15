---
uid: LowCodeApps_event_config
---

# Configuring low-code app events

At present, you can configure actions for two types of events in the DataMiner Low-Code Apps:

- *On page load*: This event takes place when a page is loaded. (See [Configuring a page of a low-code app](xref:LowCodeApps_page_config).)
- *On click*: This event takes place when a user clicks a button. (See [Configuring the header bar of a low-code app page](xref:LowCodeApps_header_config).)

For each of these events, you can configure actions as detailed below.

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

1. If the panel should be opened as an overlay, toggle the *As overlay* button.

   If a panel is opened as an overlay, the background for the panel is slightly blurred, and the panel is automatically hidden as soon as the user clicks outside it.

## Closing a panel of the app

To configure an event to close a panel of the app:

1. Select *Close a panel* and select the panel.

1. In the *Where* box, select where the panel that should be closed is located: in a pop-up window, on the left, or on the right. This is necessary in case the same panel is opened multiple times in different places.

## Opening an app

To configure an event to open another low-code app that has been published in your DMS:

- Select *Open an app* and select the app.

  > [!NOTE]
  > *Drafts* apps are included in the list of apps you can select.

## Opening a monitoring card

Available from DataMiner 10.3.4/10.4.0 onwards<!-- RN 35661 -->. To configure an event to open a monitoring card of a specific element, service, or view:

1. Select *Open monitoring card*.

1. In the *Type* box, select a type: element, service, or view.

1. Based on the selected type, select the element, service, or view for which the monitoring card should be opened.

   > [!NOTE]
   > From DataMiner 10.3.5/10.4.0 onwards<!--  RN 35986 -->, instead of linking to a fixed element, service, or view, you can link to a feed. To do so, click the link icon to the right of the selection box, select the feed, and click *Apply*.

1. Select *Add action*.

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

- From DataMiner 10.3.5/10.4.0 onwards<!--  RN 35933 -->, if you add a line chart component and a button component, you can configure this action on the button and select the option *Set timespan*, so that users can use the button to set the timespan for the line chart. The action has two arguments, To and From, which can be either set to a static value or linked to a numeric value feed.

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

## Configuring another action for the same event

After you have configured an action, you can click *Upon completion* to configure another action that should occur as soon as the previous action is completed.

Alternatively, you can configure another action that should happen at the same time with the *Add action* button in the lower right corner.

## Removing an action

To remove an action you have configured for an event:

1. In the action configuration window, click the garbage can icon in the top-right corner of the section for that action.

1. Click the confirmation icon.
