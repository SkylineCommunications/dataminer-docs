---
uid: User_settings
---

# User settings

Many settings in DataMiner can be adapted according to the preferences of the user. This can be done in the *Settings* window.

## Accessing the user settings

The user settings can be accessed in different ways:

- From DataMiner 10.0.0/10.0.2 onwards:

  - Click the apps button in the sidebar and select *Settings* at the bottom of the apps panel.

  - Click the user icon in the header bar and select *Settings* in the menu.

- Prior to DataMiner 10.0.0/10.0.2:

  - In the navigation pane, click the apps button and select *Settings*.

  - Click the current user in the header bar, and click *Settings*.

The settings window consists of two tabs. The tab with the user settings is opened by default. It consists of different pages that you can navigate between using the table of contents on the left.

> [!NOTE]
>
> - For more information on the computer settings, see [Computer settings](xref:Computer_settings).
> - Depending on the configuration of your user account, it is possible that some settings are not shown.

## Overview of the user settings

The DataMiner Cube user settings are divided in the following sections:

- [General settings](#general-settings)

- [Alarm Console settings](#alarm-console-settings)

- [Card settings](#card-settings)

- [Connection settings](#connection-settings)

- [Cube settings](#cube-settings)

- [Cube sides settings](#cube-sides-settings)

- [Data Display settings](#data-display-settings)

- [Icons settings](#icons-settings)

- [Regional settings](#regional-settings)

- [Surveyor/Sidebar settings](#surveyorsidebar-settings)

- [Trending settings](#trending-settings)

- [Visual Overview settings](#visual-overview-settings)

- [Advanced settings](#advanced-settings)

### General settings

On the *General* page, the following settings are available:

- **Background theme**: In the drop-down box, you can select the background theme for DataMiner Cube. From DataMiner 9.0 onwards, two themes are available: *Skyline Mixed* and *Skyline Black*. From DataMiner 10.2.9/10.3.0 onwards, the *Skyline Light* theme is also available.

    > [!NOTE]
    > When you have modified this setting, reconnect your DataMiner Cube session to make sure the change is applied throughout the UI.

- **Show DMA status messages**: Select this setting to no longer be notified when a DMA in your system is not running, disconnected, starting, or switching over to another DMA in Failover.

### Alarm Console settings

On the *Alarm Console* page, several settings are available:

- **Display Alarm Console group statistics**: When this setting is selected, and the grouping feature is enabled in the Alarm Console, group statistics will be displayed next to each group title.

- **Display horizontal scrollbar in the alarm list**: Select this setting to display a horizontal scrollbar in the Alarm Console. This can be very handy when many columns have been added in the list in the Alarm Console.

- **Alarm Console time format**: Select *Today/Yesterday* to use the numeric date format only for dates earlier than “Yesterday”, or select *Full date* to always display the complete date in numeric format.

  The setting will be applied on the time columns and group headers in the Alarm Console, the side panel of the Alarm Console, alarm cards and alarm lists in Visio.

  > [!NOTE]
  > The current default setting is “Today/Yesterday”, so only timestamps older than 2 days will show the full date.

- **Alarm double-click action**: From DataMiner 9.0.5 onwards, this setting determines what happens when you double-click an alarm in the Alarm Console. If *Open alarm card* is selected, the alarm card will be opened. If *Open side panel* is selected, the alarm side panel is opened, or closed in case it was already open. If the default option *Open element card* is selected:

  - For an alarm on an element, the element card is opened.

  - For an alarm on a service, the service card is opened.

  - For an aggregation alarm, the view card is opened, displaying the relevant aggregation rule.

- **Time before alarm banner hides**: Select this setting to set a delay of 30 seconds before the alarm banner hides. In order to set a different delay, select the setting and enter a different number of seconds in the box on the right.

- **Enable alarm storm protection by grouping alarms with the same parameter name**: Select this setting to group alarms with the same parameter name as soon as a certain number of these alarms occur at the same time. Configure when to start and stop grouping in the boxes below the setting.

  > [!NOTE]
  > From DataMiner version 8.5.2 onwards, this setting is enabled by default, with a start value of 2000 and a stop value of 1900.

  > [!TIP]
  > See also: [Alarm storm protection](xref:Alarm_storm_protection)

- **Enable alarm storm protection by applying a delay on the alarms**: Available from DataMiner 9.5.2/9.5.0 CU4 onwards. When you select this setting, as soon as the specified number of alarms occur within the specified time range, these alarms will be delayed until the specified period of time has passed. The alarm storm protection is applied as long as there are more alarms than the number specified next to *Stop delaying below*. As long as the alarms are delayed, they will not be displayed in Cube. If an alarm is cleared before the delay time has passed, it will not be displayed at all.

  While Cube is in alarm storm mode, a red *Alarm storm mode* label is displayed at the top of the window. If you click this label, a card is opened listing all alarms that are currently delayed, in the same layout as in the Alarm Console. This list is not automatically updated, but can be refreshed using a refresh button on the right-hand side.

  > [!NOTE]
  > This alarm storm protection is triggered by the total number of alarm updates, information events included.

- **Filter the alarms before they enter Cube**: Select this setting and then select one of the existing alarm filters in the drop-down list in order to apply it as a server-side alarm filter. When you do so, the *Active alarms* tab of the Alarm Console will only list alarms that match this filter.

  > [!NOTE]
  >
  > - When you have modified this setting, you will need to reconnect your DataMiner Cube session in order to apply the change.
  > - Applying this setting can lead to inconsistencies between the Alarm Console and element alarm states. In other words, alarms could be present in the DMS that cannot be seen in the Alarm Console, because the server side filter overrides any other filter you set in the Alarm Console.
  > - If this setting is applied, the message *Limited Alarm Access* is shown at the top of the screen. If you hover the mouse pointer over this text, a list of possible inconsistencies will be shown.
  > - For more information on alarm filters, see [Alarm filters](xref:Alarm_filters).

- **Condition to set an alarm unread**: Available from DataMiner 9.5.11 onwards. This setting determines when a read alarm should become unread again. The following options are available:

  - *On each alarm update*: A read alarm will become unread again when it is updated (default behavior).

  - *On each alarm update with increases severity*: A read alarm will only become unread again if its severity is increased by an update.

- **Keep track of the full history of a correlated alarm**: Available from DataMiner 9.6.1 onwards. If this option is selected, the entire alarm tree will be shown for a correlated alarm in the Alarm Console. Otherwise, only the most recent alarm will be displayed, and its sources will be displayed underneath. By default, this option is selected.

- **Configure Alarm Console**: With this setting you can configure the tabs in the Alarm Console for the different sides of the Cube.

    > [!TIP]
    > See also: [Setting the default alarm tabs and columns in the Cube settings](xref:ChangingTheAlarmConsoleLayout#setting-the-default-alarm-tabs-and-columns-in-the-cube-settings)

#### Alarm Console \> Card-specific

From DataMiner 9.5.6 onwards, the Alarm Console page also has a *Card-specific* subpage, where you can configure custom active alarms tabs for the ALARMS pages of element, service or view cards. For element cards, you can also configure custom alarm tabs for cards of specific element protocols.

To configure a custom tab page:

1. In the first column, select the type of card for which you wish to configure a custom tab.

1. In the second column, right-click to add a tab page or select an existing tab page.

1. In the remaining columns, specify any options that should apply to the custom tab page, similar to the regular Alarm Console configuration setting mentioned above.

> [!NOTE]
> It is not possible to remove the three default tab pages (*Active alarms*, *Masked alarms* and *Information events*).

### Card settings

On the *Card* page, the settings are divided into four sections, i.e. a section for view cards, element cards, service cards, and all cards. Some settings return in several sections, so that they can be applied separately for different types of card.

- **How to show view/element/EPM/service card Visual pages**: This setting can be configured separately for view cards, element cards, EPM cards and service cards. It provides three options for navigation between Visual Overview pages:

    | Option                         | Description                                                                                                       |
    |----------------------------------|-------------------------------------------------------------------------------------------------------------------|
    | Show in side panel               | The available Visual Overview pages are only shown in the navigation pane.                                        |
    | Show in tabs                     | The available Visual Overview pages are only shown in tabs at the top of the card.                                |
    | Show in both side panel and tabs | The available Visual Overview pages are shown both in the navigation pane and in the tabs at the top of the card. |

    > [!NOTE]
    > Visio pages that have been explicitly hidden, will never be displayed in the card navigation pane.

- **How to show element card Data pages**: This setting provides three options for navigation between Data Display pages on an element card:

    | Option                                  | Description                                                                                                                                                                                                            |
    |-------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Show in side panel                        | To go to a different Data Display page, you must select it in the navigation pane under the DATA heading.                                                                                                              |
    | Show in drop-down box                     | To go to a different Data Display page, you must select it in a drop-down box at the top of the card. Note that the navigation pane will still have a DATA heading, but no pages will be shown underneath the heading. |
    | Show in both side panel and drop-down box | To go to a different Data Display page, you can either select it in the navigation pane, or in the drop-down box.                                                                                                      |

- **How to show service card Data pages**: This setting provides three options for navigation between Data Display pages on a service card:

    | Option                         | Description                                                                                                    |
    |----------------------------------|----------------------------------------------------------------------------------------------------------------|
    | Show in side panel               | To go to a different Data Display page, you must select it in the navigation pane under the DATA heading.      |
    | Show in tabs                     | The available Data Display pages are only shown in tabs at the top of the card.                                |
    | Show in both side panel and tabs | The available Data Display pages are shown both in the navigation pane and in the tabs at the top of the card. |

- **Default view/element/EPM/service card page**: With these settings you can choose which page of view, element, EPM and service cards will be shown when you open them.

    By default, this is the Visual Overview page. It is also possible to set cards to show a Data Display page or one of the default pages, to show the page that was last visible when the card was closed, or to show the Visual Overview page only if a Visio file has been assigned to it.

- **Open element cards undocked**: Select this setting to open element cards in a new, undocked window. The setting also applies to parameter cards.

    > [!NOTE]
    > If you select this setting, element cards will always open undocked, whether you open them from the Surveyor or from a Visual Overview. However, there is one exception to this: in workspaces that were saved with element cards docked, the element cards will remain docked.

- **Show excluded devices**: Determines whether devices are displayed on the card of an enhanced service when they are excluded based one or more conditions. By default, excluded devices are displayed.

- **Show general parameters page**: Determines whether the general parameters page is displayed on the card of an enhanced service. By default, this page is hidden.

- **Show footer**: Select this setting to display a card footer when possible.

- **Show breadcrumbs**: Select one of the following three options:

  - **Full**: Always displays all breadcrumbs on cards.

  - **Views only**: Only displays breadcrumbs on view cards. These breadcrumbs only contain other views. (This corresponds to the functionality of the breadcrumbs prior to DataMiner 9.0.0.)

  - **None**: No breadcrumbs are displayed at the top of cards. For optimal performance in very complex systems, use this setting.

  > [!NOTE]
  > When you have modified this setting, reconnect your DataMiner Cube session to make sure the change is applied throughout the UI.

- **Default opening behavior for cards showing measurement points**: With this setting, you can select whether measurement point cards will by default display a service or a spectrum analyzer when opened. The alternative opening behavior can then be accessed via the measurement point’s context menu.

- **Spectrum card behavior upon preset modification**: From DataMiner 9.5.1 onwards, this setting can be used to determine what happens when a spectrum card has loaded a particular preset and this preset is edited elsewhere. Three different kinds of behavior are possible:

  - *Notify*: An information bar is displayed on the element card, which allows the user to reload the spectrum preset.

  - *Skip*: The settings that were originally saved in the preset remain in use.

  - *Update automatically*: The new settings saved in the updated preset are automatically loaded.

### Connection settings

On the *Connection* page, the following settings are available:

- **Time before automatic disconnect (minutes)**: Select this setting to enable automatic disconnection when DataMiner Cube is left unattended for some time, and fill in the number of minutes after which you want automatic disconnection to occur.

- **Automatic reconnect after connection loss**: Select this setting to ensure that DataMiner Cube will automatically reconnect after connection has been lost.

### Cube settings

On the *Cube* page, the following settings are available:

- **Never ask for confirmation after setting parameter value**: When you select this setting, no confirmation boxes will appear when a parameter value is set.

- **Do not show compatibility warnings for Visio drawings**: When you select this setting, no compatibility warnings will appear when you open a Visio file, for instance when you open a VDX file in a recent version of MS Visio.

- **Do not confirm program executions from scripts**: Available from DataMiner 10.3.3/10.4.0 onwards. When you select this setting, no confirmation box will be displayed when an interactive Automation script tries to execute a program. <!-- RN 35418 -->

- **Mouse word highlighting in Alarm Console**: This setting determines which key should be pressed in order to highlight words by moving the mouse over them, with the purpose of adding them to a filter.

- **Use compact alarm banner**: Available from DataMiner 10.0.0/10.0.2 onwards. If the alarms are configured to be shown in a banner (in the Alarm Console settings), this setting determines whether a full banner is displayed in the header, or only a banner containing the number of alarms and the highest severity.

    > [!TIP]
    > See also: [Alarm Console settings](xref:AlarmConsoleSettings)

- **Show the news section**: Available from DataMiner 9.5.14 onwards. Determines whether the optional news section is displayed on the DataMiner Pulse welcome page in Cube.

- **Show the DataMiner TV section**: Obsolete. Determines whether the optional DataMiner TV section is displayed on the DataMiner Pulse welcome page in Cube. Available from DataMiner 9.5.14 up to DataMiner 10.1.0 [CU22]/10.2.0 [CU10]/10.3.1.

- **Display the workspace buttons in the header**: Available from DataMiner 10.0.0/10.0.2 onwards. Determines whether the four blue squares indicating the Cube workspaces are displayed in the header. This setting can also be enabled or disabled via the header quick menu.

- **Display the server time in the header**: Available from DataMiner 10.0.0/10.0.2 onwards. Determines whether server time is displayed in the header. This setting can also be enabled or disabled via the header quick menu.

- **Display the search box in the header**: Available from DataMiner 10.3.5/10.4.0 onwards. Determines whether the search box is displayed in the header. This setting can also be enabled or disabled via the header quick menu.

### Cube sides settings

On the *Cube sides* page, you can change the following settings for each side of Cube:

- **Default workspace**: The workspace that will be loaded when DataMiner Cube is started.

- **# Cards**: The maximum number of cards that can be opened on a Cube side.

### Data Display settings

On the *Data Display* page, several settings are available, some of which are only applicable for Lite mode.

- **Parameter display mode**: With this option, you can choose whether to visualize parameter controls in *Normal* mode or *Lite* mode. When you select Lite mode, parameters will be shown in a more compact way. Several options to customize the way parameters are represented are also available for Lite mode.

    > [!TIP]
    > See also:
    > [Working with Lite parameters](xref:Working_with_Lite_parameters)

- **Analog display mode**: Only available in Normal mode. This setting allows you to choose whether analog parameters are displayed with a LED bar or an oscilloscope.

    > [!NOTE]
    > If a card is open when you change this setting, you must reopen the card for the setting to take effect.

- **Parameter title font**: Only available in Lite mode. With this setting you can change the title font for parameters.

    > [!NOTE]
    > The font of table parameters cannot be adjusted.

- **Parameter value font**: Only available in Lite mode. With this setting you can change the font for parameter values.

    > [!NOTE]
    > The font of table parameters cannot be adjusted.

- **Parameter value alignment**: Only available in Lite mode. With this setting you can determine whether the parameter values are aligned on the left or on the right.

- **Always show editor controls**: Only available in Lite mode. Select this setting to display the write controls for parameters.

- **Outer margin**: Only available in Lite mode. Enter 1, 2 or 4 values, separated by commas, to determine the outer margin around parameters.

- **Inner margin**: Only available in Lite mode. Enter 1, 2 or 4 values, separated by commas, to determine the inner margin between parameters.

- **Show General Parameters debug page**: Select this setting along with the computer setting *Debug settings visible* to show an additional Data Display page called *General parameters DEBUG*. This page contains general parameters that are only used for debug purposes and that are not usually displayed.

    > [!NOTE]
    > This setting is only displayed if the computer setting *Debug settings visible* is selected. See [Debug settings](xref:Computer_settings#debug-settings).

- **Enable heat map on table parameters**: Enable this setting to give table cells with numeric parameters a background color intensity that matches their value.

- **Enable histogram link on table column parameters**: Enable this setting to display a link in the column headers of table parameters, which displays a histogram with the spread of the column values.

- **Enable header sum on table column parameters**: Enable this setting to display an extra label in the column header of table parameters, which indicates the sum of the column values.

- **Maximum number of items kept in the table parameter filter history**: To determine the number of items kept in the filter history of filter boxes for table parameters, enter a value in the box for this setting.

- **Table export column separator**: Determines which separator is used between table columns when tables are exported. You can choose between a comma, a semicolon, a tab, or the list separator defined in the culture of the client machine. This setting is available from DataMiner 9.5.3 onwards.

    From DataMiner 10.0.0/10.0.2 onwards, this setting is no longer available. The regional setting *CSV separator* should be used instead. See [Regional settings](#regional-settings).

> [!NOTE]
> Up to DataMiner 9.0.0, this section also includes the trending settings. In later versions, these settings have been moved to a separate section. See [Trending settings](#trending-settings).

### Icons settings

These settings allow you to specify which alarm levels and icons are shown next to the icons of views, services and elements in the DataMiner Cube user interface.

- **Use modern icons**: Available from DataMiner 10.0.0/10.0.2 onwards. When this option is selected, the redesigned DataMiner 10 icons are used instead of the legacy icons. However, in this case icons cannot display latch levels, aggregation levels, or split view alarm levels.

- **View alarm level**: In the drop-down list next to this setting, choose either *Consolidated* to show the alarm level of all child items, or *Split* to show the alarm level of the first-level child items on the left and the alarm level of the child items on the deeper levels on the right. Not supported if *Use modern icons* is selected.

- **View latch level**: In the drop-down list next to this setting, choose either *Show* to show the latch level for views, or *Hide* to hide it. Not supported if *Use modern icons* is selected.

- **View aggregation level**: With this option, aggregated alarms on views are indicated with a triangle next to the colored bar indicating the view alarm level. In the drop-down list next to this setting, choose either *Show* to show this triangle, or *Hide* to hide it. Not supported if *Use modern icons* is selected.

- **Element alarm level**: In the drop-down list next to this setting, choose either *Separate from timeout* to show a timeout icon and the last-known alarm level, or *Timeout overrules* to show a timeout icon and the timeout color.

- **Element latch level**: In the drop-down list next to this setting, choose either *Show* to show the latch level for elements, or *Hide* to hide it. Not supported if *Use modern icons* is selected.

- **Service latch level**: In the drop-down list next to this setting, choose either *Show* to show the latch level for services, or *Hide* to hide it. Not supported if *Use modern icons* is selected.

> [!TIP]
> See also:
> [Special icon settings](xref:Main_Cube_UI_components_prior_to_DataMiner_10#special-icon-settings)

### Regional settings

On the *Regional* page, the following settings are available:

- **Language of the user interface**: Choose the language for the user interface. You must restart DataMiner Cube for this setting to take effect. Currently, the officially supported languages are Dutch, French, German, Portuguese (Portugal), Russian and Spanish. Other languages are available for demo purposes only.

    > [!NOTE]
    > From DataMiner 9.5.2 onwards, by default, only the officially supported languages can be selected in the user settings.

- **Regional date and time format**: Select a culture in the drop-down list to customize the format of dates and times in DataMiner Cube to that culture.

- **CSV separator**: Select which separator should be used in CSV exports from Cube. This setting replaces the legacy *Table export column separator* setting. Available from DataMiner 10.0.0/10.0.2 onwards.

    > [!NOTE]
    > - When you copy data to the Windows clipboard, that data will always be delimited by TAB characters, regardless of this setting.
    > - This setting only determines the separator used for CSV exports via Cube. Exports that are done via the server, such as service template exports, use the settings of the server.

### Surveyor/Sidebar settings

On the *Sidebar page,* or prior to DataMiner 10.2.0/10.1.3, the *Surveyor* page, the following settings are available:

- **Sidebar docking position**: Available from DataMiner 10.0.0/10.0.2 onwards. Select *Right* or *Left* to determine at which side of the screen the Cube sidebar will be displayed. By default, it is displayed on the left.

- **Surveyor docking position** (obsolete): Select *Right* or *Left* to determine at which side of the screen the Surveyor will be displayed. This setting is no longer available from DataMiner 10.0.0/10.0.2 onwards.

- **Allow to expand/collapse service nodes**: Select this setting to enable users to expand services in the Surveyor to see the child items of the services.

- **Collapse DVE elements beneath their main element**: Available from DataMiner 10.2.0/10.1.4 onwards. This setting allows you to determine how DVE child elements are displayed. By default, this setting is disabled, and DVE child elements are displayed in the same way as other elements. If you set this to *All DVEs*, DVE child elements will be displayed on the level below the parent elements in the tree structure, so that you can collapse and expand the list of child elements. If you set this to *Only function DVEs*, this will only happen for function DVEs.

- **Link the Surveyor selection to the selected card in the workspace**: If this option is selected, the Surveyor will automatically select the item displayed in the currently selected card. (Available from DataMiner 9.5.9 onwards.)

- **Launch EPM card on filter selection**: Available from DataMiner 10.2.0/10.1.3 onwards. Select this checkbox to have an EPM card opened when an item is selected in a filter in an EPM topology tab.

### Trending settings

- **Trend Y-axis mode**: Select *Auto* to automatically optimize the vertical range of a trend graph during pan and zoom operations. Select *Range* to fix the vertical range to the minimum and maximum defined in the protocol.

    > [!NOTE]
    >
    > - If a trend display is already open when you change this setting, you must reload the trend display for the setting to take effect.
    > - When the *Range* setting is selected, the range of the y-axis is determined by the first parameter loaded in the trend graph. After the initial range is determined, it will not be adjusted until all parameters are cleared.

- **Trend Y-axis includes exceptions**: Select this setting to allow the vertical range of the Y-axis to extend with exception values.

- **Show alarm template colors on vertical axis**: Obsolete from DataMiner 10.3.0/10.2.4 onwards. Enable this setting to show the alarm colors next to the vertical axis of trend graphs. The setting *Display the alarm template in the trend graph* allows you to further specify how the alarm colors are displayed.

- **Display the alarm template in the trend graph**: In the drop-down list next to this setting, choose *Line* to show alarm template colors as a small line next to the Y-axis, or *Band* to show them as semi-transparent horizontal bands across the trend graph. From DataMiner 10.3.0/10.2.4 onwards, the checkbox in front of this setting must be selected for alarm colors to be shown next to the vertical axis of trend graphs.

- **Show most detailed data**: If you select this option, the most detailed data available will be shown, rather than average data. In order to ensure optimal performance in case a large amount of trend data must be displayed, this option is by default not selected.

- **Show percentile**: Obsolete from DataMiner 10.3.0/10.2.4 onwards. Available from DataMiner 10.0.12 onwards. Select this option to show a percentile line on trend graphs by default.

- **Percentile to calculate**: Available from DataMiner 10.0.12 onwards, if *Show percentile* is selected. From DataMiner 10.3.0/10.2.4 onwards, select the checkbox in front of this setting to show a percentile line. You can then configure which percentile is displayed. By default, this is set to *95*.

- **Trend prediction range**: Select either *Manual*, if you want to manually change the trend prediction range, or *Auto*, if you want DataMiner to select the range depending on the zoom level.

- **Left mouse button action on graph**: Select the action executed by dragging the left mouse button on a trend graph.

  - Up to DataMiner 10.0.6, the default action is *Select*, which means that the left mouse button can be used to select a section of the graph to zoom in on. Other options are *Pan* or *None*.

  - From DataMiner 10.0.7 onwards, the default action is *Pan*. Other options are *Select*, *Zoom* or *None*. The *Zoom* option does the same as the *Select* option from earlier DataMiner versions. The *Select* option now allows you to select a part of the graph in order to assign tags to it. However, note that this is only possible on systems with a Cassandra database and Elasticsearch database.

- **Right mouse button action on graph**: Select the action executed by dragging the right mouse button on a trend graph.

  - Up to DataMiner 10.0.6, the default action is *Pan*. Other options are *None* or *Select*, which allows you to use the left mouse button to select a section of the graph to zoom in on.

  - From DataMiner 10.0.7 onwards, the default action is *Zoom*, which does the same as the *Select* option from earlier DataMiner versions. Other options are *Pan*, *Select* or *None*. The *Select* option now allows you to select a part of the graph in order to assign tags to it. However, note that this is only possible on systems with a Cassandra database and Elasticsearch database.

- **Hotkey for mouse button action on graph**: Available from DataMiner 10.0.7 onwards. Allows you to specify which key can be used in order to apply an action on a trend graph by pressing this key and dragging with the left mouse button at the same time. The default hotkey is *Ctrl*. Other options are *Alt* and *Shift*.

- **Hotkey + left mouse button action on graph**: Available from DataMiner 10.0.7 onwards. Select the action executed by pressing the hotkey configured in the setting above and dragging the left mouse button on a trend graph. The default option is Select, which allows you to select a part of the graph in order to assign tags to it. However, note that this is only possible on systems with a Cassandra database and Elasticsearch database. Other options are *Zoom*, *Pan* or *None*.

- **Extend trend data from the database with real-time parameter changes**: Available from DataMiner 9.5.7 onwards. From that version of DataMiner onwards, by default, trend graphs are redrawn after each parameter change. When this setting is enabled, parameter changes will be displayed using a lighter color in order to clearly show the difference between this parameter data and “confirmed” trend data from the database. The moment a trend data update is received, the confirmed trend data will be drawn using the standard trend data color.

- **Current timeline**: Available from DataMiner 9.5.9 onwards (previously available as “Follow mode”). Determines the behavior of a trend graph’s current timeline. The following options are available:

    | Value | Behavior                                                                                                                                                                  |
    |---------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Mixed   | The current timeline will slide to the right as the graph gets updated, but the “Now” line will slide back into view when data is added past the right edge of the graph. |
    | Fixed   | If the “Now” timeline is displayed, it will stay at its current position when the graph is updated (default value).                                                       |
    | Sliding | The current timeline will slide to the right as the graph gets updated. The graph and time axis will remain at the current position                                       |

- **Visualize trend predictions**: Available from DataMiner 9.5.13 onwards. When this option is disabled, predicted trend data based on trend data analysis will no longer be displayed.

- **Visualize change points**: Available from DataMiner 10.0.0/10.0.2 onwards. When this option is disabled, change points detected based on trend data analysis will no longer be displayed.

- **Update interval**: Available from DataMiner 10.3.0/10.2.4 onwards. Allows you to specify a custom refresh rate for trend graphs (ranging from 5 seconds to 5 minutes). By default, this is set to 2 minutes.

> [!NOTE]
> - Changing this refresh rate can have a minor effect on overall performance, especially when trend graphs with more than 10 parameters are opened.
> - If you change this setting, you will need to close and reopen any currently opened trend graphs for the setting to take effect on them.

### Visual Overview settings

On the *Visual Overview* page, the following settings are available:

- **Enable coloring when severity is normal or undefined**: Select this option to ensure that elements, services and views will also be colored if their alarm severity level is normal or undefined.

- **Enable page loading message**: Select this option to have a “Loading” message displayed as long as not all components in a Visual Overview have been loaded.

- **Maximum number of child shapes in a ‘Children’ container shape**: Enter a value in the box to determine the maximum number of dynamically generated Visio shapes in a “Children” container shape. For more information, see [Generating shapes based on table rows](xref:Generating_shapes_based_on_table_rows) and [Generating shapes based on child items in a view or a service](xref:Generating_shapes_based_on_child_items_in_a_view_or_a_service).

### Advanced settings

On the *Advanced* page, the following settings are available:

- **Group profile**: Select a group in the drop-down list to override all user settings with the settings of this group. This setting is no longer available from DataMiner 9.0.0 CU8 onwards.

- **DataMiner Cube User \[username\] reset**: Click the button *Factory defaults* to reset all settings back to default.

> [!NOTE]
> - If a setting other than the default has been applied, it will be displayed in bold. You can quickly reset to the default setting by clicking the *Reset to \[setting\]* field underneath the setting.
> - If a setting requires that you enter a value in a box, and the value you entered is incorrect, the edge of the box will be displayed in red and the change to the setting will not be applied.
> - It is possible to limit the changes a user can apply to the settings. For more information, see [Configuring a set of user group settings](xref:Configuring_a_set_of_user_group_settings).
>
