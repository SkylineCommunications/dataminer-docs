---
uid: Main_Cube_UI_components_prior_to_DataMiner_10
---

# Main Cube UI components prior to DataMiner 10

The DataMiner Cube UI consists of the following main components prior to DataMiner 10.0.0/10.0.2:

- [Header bar](#header-bar)

- [DataMiner Cube navigation pane](#dataminer-cube-navigation-pane)

- [Card pane](#card-pane)

- [Alarm Console](#alarm-console)

## Header bar

In the header bar of DataMiner Cube, using a version prior to DataMiner 10.0.0/10.0.2, you can find the following items.

- **Cube side indicators**: Four blue squares, each representing one of the four Cube sides. The largest square marks the Cube side that is currently displayed.

    - Click a square to switch to a particular Cube side.

- **User name and DMS time**: The name of the user who is currently logged on, followed by the DMS time (i.e. the time that is kept synchronized among all DataMiner Agents in the DMS).

    - Click to open the *Contacts* panel, which allows you to exchange chat messages with other users of your DataMiner System.

    - Click and select *Log off* to end your current DataMiner Cube session.

    - Click and select *Settings* to open the *Settings* window.

    - Click and select *My account* to open your user card.

    > [!TIP]
    > See also:
    > [Chat collaboration](xref:chat#chat-collaboration)

- **![](~/user-guide/images/card_layout_icon.png) Card layout icon**: An icon that can be used to change the layout of the cards in Cube.

    > [!TIP]
    > See also:
    > [Changing the card layout](xref:Working_with_cards_in_DataMiner_Cube#changing-the-card-layout)

- **Question mark**: An icon that allows you to quickly access the online help and the About box.

    - Click and select *Help* to view the DataMiner online help.

    - Click and select *About* to view the About box. This box consists of several tabs, and three buttons:

        - The *general* tab mentions the upgrade version of your DMA. It also contains contact information and a link to the Skyline license terms and to third-party notices.

        - The *assemblies* tab mentions the assemblies used by your DMA.

        - The *connection* tab contains information about the connection of client to server.

        - The *versions* tab shows the server and client version, as well as the version of the various DataMiner files and the DMA upgrade history.

        - The *license* tab contains license information as well as activated license counter information. For demo licenses, the expiration date is shown at the top.

            > [!NOTE]
            > To view license information regarding third-party software, go to *http(s)://**\[DMA name or IP\]**/Licenses* (available from DataMiner 9.5.14 onwards).

        - The buttons at the bottom of the box allow you to export, email or copy the information for troubleshooting purposes.

- **![](~/user-guide/images/updates_icon.png) Updates icon**: An icon that allows you to quickly access the update center to check for and download protocol updates.

    > [!TIP]
    > See also:
    > [Updating protocols with the Update Center](xref:Adding_a_protocol_or_protocol_version_to_your_DataMiner_System#updating-protocols-with-the-update-center)

- **![](~/user-guide/images/client_communicator_icon.png) Client communication indicator**: An icon that visualizes the communication streams between the DMA and the DataMiner Cube client application.

    - When messages are sent from the client application to the DataMiner Agent or vice versa, the arrows turn blue.

    - Click the icon to view all connected DMAs, grouped per DMS, along with their status. In that list, the right-click menu allows you to start, restart, stop, shut down, reboot or upgrade a DMA, as well as access the *Failover* window. The *System Center* and *Agents* buttons allow quick access to the system configuration.

## DataMiner Cube navigation pane

The Cube navigation pane, in DataMiner versions prior to DataMiner 10.0.0/10.0.2, consists of:

- A search box at the top, with a button that opens the root view. See [Searching in DataMiner Cube](xref:Searching_in_DataMiner_Cube).

- The Surveyor tab. See [Surveyor](#surveyor).

- The recent items tab. See [Recent items](#recent-items).

- The apps tab. See [Apps](#apps).

- The workspaces tab. See [Workspaces](#workspaces).

For more information on how to move the navigation pane, see [Moving the navigation pane](#moving-the-navigation-pane).

### Surveyor

The Surveyor is the leftmost tab of the navigation pane, indicated with the following icon: ![](~/user-guide/images/surveyor_icon.png)

This tab contains a hierarchical overview of all views, elements, services, etc. in your DataMiner System. It features alarm bubble-up, state indication, etc.

When you click an item in the tree, it opens in a card:

- If you click the item with the left mouse button, the new card replaces a card that is already open.

- If you click the item with the middle mouse button, a new card is opened next to any cards that are already open.

> [!NOTE]
> - It is also possible to search in the navigation pane. For more information, see [Searching in DataMiner Cube](xref:Searching_in_DataMiner_Cube).
> - For the right-click menu options in the Surveyor, see [Surveyor right-click menu](#surveyor-right-click-menu).
> - You can drag an element, service, view, or SLA from a card or from the Surveyor to another application, such as Microsoft Word or Outlook, to copy information about that DataMiner item to the application in question.

#### Icons

The icons that precede an item name in the tree show what kind of item it is and what state and alarm state it is in.

- There are specific icons for different types of items:

    | Icon                                                                             | Item description                                                |
    |------------------------------------------------------------------------------------|-----------------------------------------------------------------|
    | ![](~/user-guide/images/IconElement.png)             | Element                                                         |
    | ![](~/user-guide/images/IconService.png)             | Service                                                         |
    | ![](~/user-guide/images/IconServiceTemplate.png)     | Service template                                                |
    | ![](~/user-guide/images/IconRG.PNG)         | Redundancy group                                                |
    | ![](~/user-guide/images/IconSLA.PNG)             | SLA                                                             |
    | ![](~/user-guide/images/Icon_function.png) | Function DVE (requires DataMiner Service & Resource Management) |
    | ![](~/user-guide/images/IconProtocol.png)           | Protocol                                                        |
    | ![](~/user-guide/images/IconParameter.png) | Parameter                                                       |
    | ![](~/user-guide/images/IconScript.png)               | Script                                                          |
    | ![](~/user-guide/images/IconSetting.png)     | Setting                                                         |
    | None                                                                               | View                                                            |

- Icons are preceded by a colored bar that indicates the item’s alarm state. In addition to the default colors indicating the alarm severity, the following colors are possible:

    | Color | Description                                 |
    |---------|---------------------------------------------|
    | Gray    | There is no alarm monitoring for this item. |
    | Purple  | The item is masked.                         |
    | Orange  | The item is in timeout state.               |

    > [!NOTE]
    > The color reflects the most severe of all the current parameter alarms for the item.

    > [!TIP]
    > See also:
    > - [Alarm severity levels](xref:Alarm_types#alarm-severity-levels)
    > - [Changing the default alarm colors](xref:Changing_the_default_alarm_colors)

- There may be additional symbols on an icon to indicate a particular state:

    | Symbol                  | Description                                                                                                                                                                                             |
    |---------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Gray square               | Located in the corner of an icon to indicate that the item is stopped.                                                                                                                                  |
    | Two vertical bars         | Located in the corner of an icon to indicate that polling on the item is paused.                                                                                                                        |
    | Orange X                  | Indicates that an element in a view or service is in timeout state.                                                                                                                                     |
    | White X on red background | Indicates that an element is in an error state.                                                                                                                                                         |
    | Upwards arrow             | Displayed next to a service child in case the capped severity of the service child is lower than the actual severity. The icon has the color of the severity that will bubble up to the parent service. |

#### Special icon settings

In the DataMiner settings, there are several options to show more alarm information next to an icon than just the current state.

The following options are available:

- **Split view alarm level**: Shows the alarm color of child views in a second rectangle separated from the alarm color of the elements directly in the view.

- **View/element/service latch level**: Shows the latched alarm color in a smaller rectangle. This is the color of the previous highest alarm severity level of the item.

    > [!NOTE]
    > When this setting is activated, you can reset the latch level of items in the Surveyor. To do so, right-click the item and select *Reset latch level*.

- **Timeout state overrules element alarm level**: Though normally a timeout state is shown separately from the last known element alarm level, you can also have the timeout override the alarm level.

- **View aggregation level**: Indicates aggregated alarms on views with a triangle next to the colored bar indicating the view alarm state.

> [!TIP]
> See also:
>
> - [Icons settings](xref:User_settings#icons-settings)
> - [Surveyor – Using latched and special icons](https://community.dataminer.services/video/surveyor-using-latched-and-special-icons/) ![Video](~/user-guide/images/video_Duo.png)

> [!NOTE]
> From DataMiner 10.0.0/10.0.2 onwards, these icon settings can only be used if the *Use modern icons* setting is not enabled.

#### Surveyor right-click menu

In the Surveyor right-click menu, the following options are available, depending on what type of item is right-clicked:

| Menu option               | Right-clicked item                               | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
|---------------------------|--------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Expand all in alarm       | View only                                        | Expands all subviews with an active alarm.                                                                                                                                                                                                                                                                                                                                                                                                                  |
| Collapse level            | View only                                        | Collapses the level of the right-clicked view.                                                                                                                                                                                                                                                                                                                                                                                                              |
| Open                      | Any                                              | Opens the item in a card.                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| Open in new card          | Any                                              | Opens the item in a new card.                                                                                                                                                                                                                                                                                                                                                                                                                               |
| Open in new undocked card | Any                                              | Opens the item in a new, undocked card.                                                                                                                                                                                                                                                                                                                                                                                                                     |
| Ticket                    | Element, service, view                           | Allows you to create a new ticket related to the right-clicked item. Only available on DMAs with a Ticketing license.<br> See [Ticketing](xref:ticketing).                                                                                                                                                                                                                                                           |
| State                     | Element only                                     | Opens a shortcut that allows you to change the element state. See [Changing the state of an element](xref:Changing_the_state_of_an_element).                                                                                                                                                                                                                                                                                            |
| Mask                      | Element only                                     | Masks the element. See [Masking or unmasking an element](xref:Masking_or_unmasking_an_element)                                                                                                                                                                                                                                                      |
| Unmask                    | Element only                                     | Unmasks the element. This option is only available for masked elements.                                                                                                                                                                                                                                                                                                                                                                                     |
| Multiple set              | Element only                                     | Opens the *Multiple set* dialog box. See [Setting a parameter value in multiple elements](xref:Updating_elements#setting-a-parameter-value-in-multiple-elements).                                                                                                                                                                                                                                        |
| Protocols & Templates     | Element, enhanced service                        | Opens a submenu where you can:<br> -  View the used protocol or service protocol, alarm template, and trend template.<br> -  Assign alternative templates.<br> -  View all available templates.                                                                |
| View                      | Element, service generated by a service template | For an element, a shortcut menu opens that allows quick access to DataMiner logging or Stream Viewer. <br> For a service generated by a service template, this option opens a card with service creation data and an overview of the service’s child elements.<br> Note that from DataMiner 9.5.1 onwards, all options related to generated services, including this one, have been moved to the *Service template* submenu. |
| Edit                      | Element, service                                 | Opens a card where you can change the settings of the element or service.                                                                                                                                                                                                                                                                                                                                                                                   |
| Remove from parent        | Any view child item, except a child view         | Moves the item from the parent view to the root view.                                                                                                                                                                                                                                                                                                                                                                                                       |
| Delete                    | Any except root view                             | Removes the item.                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| Duplicate                 | Element, service                                 | Duplicates the item.                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| Rename                    | Element, service, view, redundancy group         | Allows the user to rename the item                                                                                                                                                                                                                                                                                                                                                                                                                          |
| New                       | Any                                              | Opens a submenu where you can select to create a new element, service, service template or SLA. If you right-clicked a view, you can also select to create a new view.                                                                                                                                                                                                                                                                                      |
| Actions                   | Element, service, view                           | Opens a shortcut menu with options to configure personal alerts, start Correlation analyzers, open a filtered alarm tab, and other options depending on the right-clicked item.                                                                                                                                                                                                                                                                             |
| Properties                | Element, service, view                           | Opens the item’s *Properties* window.                                                                                                                                                                                                                                                                                                                                                                                        |
| Drag and drop editing     | Any                                              | Enables drag-and-drop view editing mode. See [Editing a view](xref:Managing_views#editing-a-view).                                                                                                                                                                                                                                                                                                                                         |

> [!NOTE]
> - For some special items, such as redundancy group templates or service templates, additional options are available.
> - The *View* option is also available for services using a protocol, with the options to view the protocol, alarm template or trend template of such a service.
> - When opening an item from the right-click menu, you can hold *Ctrl* while clicking the menu option to open the item in a new card, or hold *Shift* while clicking the option to open the item in a new undocked card.

### Recent items

A list of recently viewed items, such as elements, services, views and apps, is available under the second tab from the left in the navigation pane.

This tab is indicated with the following icon: ![](~/user-guide/images/IconRecentItems.png)

The following actions are possible with this list:

- Click an item in the list to open it in a card. If you wish to open the item in a new card, use the middle mouse button.

- Pin an item so that it is placed in the *Pinned* section at the top of the list: hover over the item with the mouse pointer until a pin icon appears to the right of it, then click the pin icon.

> [!NOTE]
> - Regardless of how frequently you view them, pinned items remain in the top section of the list until you click the pin icon again to remove them.
> - The list of recent and pinned items is kept synchronized between the DataMiner Cube app and the Monitoring web app.
> - Recent items can be views, elements, services, redundancy groups, service templates and DataMiner modules.

> [!TIP]
> See also:
> [Rui’s Rapid Recap – Recent & pinned items](https://community.dataminer.services/video/ruis-rapid-recap-recent-pinned-items/) ![Video](~/user-guide/images/video_Duo.png)

### Apps

A list of DataMiner applications is available under the second tab from the right in the navigation pane.

This tab is indicated with the following icon: ![](~/user-guide/images/IconApps.png)

Depending on the configuration of your DataMiner System, the list can contain up to four sections:

- **Applications**: Custom-made DataMiner applications.

- **Modules**: The different DataMiner modules, such as Trending, System Center, and add-on modules like Automation and Correlation.

- **General**: The Help, Settings, and About.

- **WFM**: Custom DataMiner WorkFlow Manager components.

Click any app in the list to open it. If you wish to open the app in a new card, use the middle mouse button.

### Workspaces

A list of workspaces is available in the first tab from the right in the navigation pane.

This tab is indicated with the following icon: ![](~/user-guide/images/IconWorkspaces.png)

For more information on how to work with workspaces, see [Working with workspaces](xref:Working_with_workspaces).

### Moving the navigation pane

#### Changing the navigation pane position

By default, the navigation pane is located on the right-hand side of the screen. However, it is possible to place it at the other side of the screen:

- To move it to the left-hand side of the screen, click anywhere inside the pane and press *Ctrl+Alt+Shift+LeftArrow*.

- To move it to the right-hand side of the screen, click anywhere inside the pane and press *Ctrl+Alt+Shift+RightArrow*.

> [!NOTE]
> The default location of the navigation pane can be specified in *Settings \> User \> Surveyor \> Surveyor docking position*

#### Changing the navigation pane size

You can change the size of the navigation pane in the following ways:

- Collapse the pane with the arrow button next to the *Search* box.

- Expand the pane by clicking the arrow button at the top of the collapsed pane.

- While the pane is collapsed, click any of the tab icons to “peek” at the pane, i.e. to open it so that it closes again as soon as you have clicked an item.

- Resize the pane by placing the cursor over the edge of the pane and dragging.

    > [!NOTE]
    > It is also possible to collapse and expand the pane by dragging its edge.

## Card pane

When you click an item in the Surveyor or when you right-click an alarm in the Alarm Console and select *Open \> Alarm Card*, the details of that item or that alarm are displayed in a special window called a card.

For more information, see [Working with cards in DataMiner Cube](xref:Working_with_cards_in_DataMiner_Cube).

### Card header bar buttons

At the top of each card, there are a number of buttons:

| Button                                                                                     | Description                                                                                                                                                                                                                                                                                    |
|--------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ![](~/user-guide/images/Hamburger_button.png)   | Hamburger button in the top-left corner of a card. Provides access to a shortcut menu with a number of commands. See [Card header bar menu](xref:Working_with_cards_in_DataMiner_Cube#card-header-bar-menu). |
| ![](~/user-guide/images/Back_button.png)             | Back button. As soon as you have gone from one card to another, this button becomes available, allowing you to go back to a previous card.                                                                                                                                                     |
| ![](~/user-guide/images/Maximize_button.png)     | Maximize button. Click this button to expand a card to its maximal size.                                                                                                                                                                                                                       |
| ![](~/user-guide/images/Restore_button.png)       | Restore button. If a card has been maximized, use this button to restore it to its previous size.                                                                                                                                                                                              |
| ![](~/user-guide/images/Close_button.png)           | Close button. Shift-click the button to close all open cards.                                                                                                                                                                                                                                  |
| ![](~/user-guide/images/CubeMaximize00023.png) | Fullscreen button. Displayed in the top-right corner of a page showing data, a table parameter, a visual overview or trending. Expands the page over the entire Cube UI. To exit this fullscreen mode, click the button again.                                                                 |

> [!NOTE]
> To move back and forward between the Visual Overview pages of different cards, use the *Back* and *Forward* options in the right-click menu.

## Alarm Console

The Alarm Console is the section of the DataMiner Cube user interface that allows you to view and manipulate active alarms, historical alarms and information events.

For more information on how to use the Alarm Console, see [Working with the Alarm Console](xref:Working_with_the_Alarm_Console).
