---
uid: DataMiner_Cube_sidebar
---

# DataMiner Cube sidebar

From DataMiner 10.0.0/10.0.2 onwards, on the left-hand side of the Cube UI, a sidebar is displayed. This sidebar contains the following buttons:

- *Surveyor*: Opens the Surveyor pane. See [Surveyor pane](#surveyor-pane).

- *Activity*: Opens a pane listing recent items. See [Activity pane](#activity-pane).

- *Apps*: Opens a pane listing the different apps available in Cube. See [Apps pane](#apps-pane).

- *Workspaces*: Opens a pane where you can select and manage different Cube workspaces. See [Working with workspaces](xref:Working_with_workspaces).

- *Community*: This button is displayed from DataMiner 10.0.0 \[CU12\]/10.1.0 \[CU1\]/10.1.4 onwards. Clicking the button opens a menu with different links to the [DataMiner Dojo user community](https://community.dataminer.services/), including the blog, the learning hub, a library of resources, a page where you can ask questions about anything related to DataMiner, and a page that allows you to suggest new features.

From DataMiner 10.1.11/10.2.0 onwards, you can pin additional buttons to the sidebar using the “...” or “+” button. This button opens a menu where you can select the buttons you want to pin.

- *Overview*: Displays the root view page listing all items below the root view.

- *Search*: If an advanced search is done from the Cube header bar, an additional *Search* button is displayed, which displays the pane with the advanced search results. If this button is not pinned to the sidebar, it will no longer be displayed as soon as you click a different button. See [Searching in DataMiner Cube](xref:Searching_in_DataMiner_Cube).

- A button representing any of the available modules, the “About” information, the Help, or the settings.

To unpin a button again, right-click the button and select *Unpin*. This is not possible for the buttons that are displayed by default.

> [!NOTE]
>
> - At most 4 items can be pinned to the sidebar. If the maximum number of items has been added, the button to pin more items is no longer displayed, until an item is unpinned again.
> - It is possible to move the position of the sidebar to the right-hand side. To do so, press *Ctrl+Alt+Shift+RightArrow*. To move the pane back to the left-hand side, press *Ctrl+Alt+Shift+LeftArrow*. The sidebar position can also be changed in the Cube settings. See [Cube settings](xref:User_settings#cube-settings).

## Surveyor pane

The Surveyor pane contains a hierarchical overview of all views, elements, services, etc. in your DataMiner System. It features alarm bubble-up, state indication, etc.

When you click an item in the tree, it opens in a card:

- If you click the item with the left mouse button, the new card replaces a card that is already open.

- If you click the item with the middle mouse button, the new card is opened next to any cards that are already open.

> [!NOTE]
>
> - For the right-click menu options in the Surveyor, see [Surveyor right-click menu](xref:Main_Cube_UI_components_prior_to_DataMiner_10#surveyor-right-click-menu).
> - You can drag an element, service, view, or SLA from a card or from the Surveyor to another application, such as Microsoft Word or Outlook, to copy information about that DataMiner item to the application in question.

### Icons

The icons that precede an item name in the tree show what kind of item it is and what state and alarm state it is in.

> [!NOTE]
> Depending on the user settings, the legacy icons may be displayed instead of the icons described below. For more information on the legacy icons, see [Icons](xref:Main_Cube_UI_components_prior_to_DataMiner_10#icons).

- There are specific icons for different types of items:

  | Icon | Item description |
  |------|------------------|
  | ![View icon](~/user-guide/images/CubeXView.png) | View |
  | ![Element icon](~/user-guide/images/CubeXElement.png) | Element or default function DVE (prior to DataMiner 10.0.5 - requires DataMiner Service & Resource Management) |
  | ![Service icon](~/user-guide/images/CubeXService.png) | Service |
  | ![Service template icon](~/user-guide/images/CubeXServiceTemplate.png) | Service template |
  | ![Redundancy group icon](~/user-guide/images/CubeXRedunGroup.png) | Redundancy group |
  | ![SLA icon](~/user-guide/images/CubeXSLA.png) | SLA |
  | ![Protocol icon](~/user-guide/images/CubeXProtocol.png) | Protocol |
  | ![Parameter icon](~/user-guide/images/CubeXParameter.png) | Parameter |
  | ![Script icon](~/user-guide/images/CubeXScript.png) | Script |
  | ![Setting icon](~/user-guide/images/CubeXSetting.png) | Setting |
  | ![Function icon](~/user-guide/images/CubeXFunction.png) | Default function DVE (from DataMiner 10.0.5 onwards – requires DataMiner Service & Resource Management) |

- View icons are filled with a different color, depending on their alarm state. On other icons, a colored circle is displayed when they are in a particular alarm state. In addition to the default colors indicating the alarm severity, the circle can also be displayed in purple to indicate that an item is masked.

  > [!NOTE]
  > The alarm state color is determined by the most severe of all the current alarms for the item.

  > [!TIP]
  > See also:
  >
  > - [Alarm severity levels](xref:Alarm_types#alarm-severity-levels)
  > - [Changing the default alarm colors](xref:Changing_the_default_alarm_colors)

- There may be additional symbols on an icon to indicate a particular state:

  | Symbol  | Description   |
  |---------|---------------|
  | Gray square | Located in the corner of an icon to indicate that the item is stopped. |
  | Two vertical bars | Located in the corner of an icon to indicate that polling on the item is paused. |
  | Orange X | Indicates that an element in a view or service is in timeout state. |
  | White X on red background | Indicates that an element is in error state. |
  | Upwards arrow | Displayed next to a service child in case the capped severity of the service child is lower than the actual severity. The icon has the color of the severity that will bubble up to the parent service. |
  | Circle containing a horizontal line, for example: ![Unavailable element icon](~/user-guide/images/element_unavailable.png) | Indicates that the DMA hosting the item is currently unavailable. Though the information on the item is still available in the cache, it is not possible to execute any actions on the item. This icon is used from DataMiner 10.0.12 onwards. In this DataMiner version, it is only used for elements, and other items are not displayed when the DMA hosting them is unavailable. From DataMiner 10.0.13 onwards, it is also used for services and redundancy groups. |

### Surveyor right-click menu

In the Surveyor right-click menu, the following options are available, depending on what type of item is right-clicked:

| Menu option | Right-clicked item | Description |
|--|--|--|
| Expand all in alarm | View only | Expands all subviews with an active alarm. |
| Collapse level | View only | Collapses the level of the right-clicked view. |
| Open | Any | Opens the item in a card. |
| Open in new card | Any | Opens the item in a new card. |
| Open in new undocked card | Any | Opens the item in a new, undocked card. |
| Ticket | Element, service, view | Allows you to create a new ticket related to the right-clicked item. Only available on DMAs with a Ticketing license. See [Ticketing](xref:ticketing). |
| State | Element only | Opens a shortcut that allows you to change the element state. See [Changing the state of an element](xref:Changing_the_state_of_an_element). |
| Mask | Element only | Masks the element. See [Masking or unmasking an element](xref:Masking_or_unmasking_an_element) |
| Unmask | Element only | Unmasks the element. This option is only available for masked elements. |
| Multiple set | Element only | Opens the *Multiple set* dialog box. See [Setting a parameter value in multiple elements](xref:Updating_elements#setting-a-parameter-value-in-multiple-elements). |
| Protocols & Templates | Element, enhanced service | Opens a submenu where you can:<br> -  View the used protocol or service protocol, alarm template, and trend template.<br> -  Assign alternative templates.<br> -  View all available templates. |
| View | Element, service generated by a service template | For an element, a shortcut menu opens that allows quick access to DataMiner logging or Stream Viewer. <br> For a service generated by a service template, this option opens a card with service creation data and an overview of the service’s child elements.<br> Note that from DataMiner 9.5.1 onwards, all options related to generated services, including this one, have been moved to the *Service template* submenu. |
| Edit | Element, service | Opens a card where you can change the settings of the element or service. |
| Remove from parent | Any view child item, except a child view | Moves the item from the parent view to the root view. |
| Delete | Any except root view | Removes the item. |
| Duplicate | Element, service | Duplicates the item. |
| Rename | Element, service, view, redundancy group | Allows the user to rename the item |
| New | Any | Opens a submenu where you can select to create a new element, service, service template or SLA. If you right-clicked a view, you can also select to create a new view. |
| Actions | Element, service, view | Opens a shortcut menu with options to configure personal alerts, start Correlation analyzers, open a filtered alarm tab, and other options depending on the right-clicked item. |
| Properties | Element, service, view | Opens the item’s *Properties* window. |
| Drag and drop editing | Any | Enables drag-and-drop view editing mode. See [Editing a view](xref:Managing_views#editing-a-view). |

> [!NOTE]
>
> - For some special items, such as redundancy group templates or service templates, additional options are available.
> - The *View* option is also available for services using a protocol, with the options to view the protocol, alarm template or trend template of such a service.
> - When opening an item from the right-click menu, you can hold *Ctrl* while clicking the menu option to open the item in a new card, or hold *Shift* while clicking the option to open the item in a new undocked card.

## Activity pane

The activity button displays a pane listing recently opened items, such as elements, services, views and apps.

The following actions are possible with this list:

- Click an item in the list to open it in a card. If you wish to open the item in a new card, use the middle mouse button.

- Pin an item so that it is placed in the *Pinned* section at the top of the list: hover over the item with the mouse pointer until a pin icon appears to the right of it, then click the pin icon.

> [!NOTE]
>
> - Regardless of how frequently you view them, pinned items remain in the top section of the list until you click the pin icon again to remove them.
> - The list of recent and pinned items is kept synchronized between DataMiner Cube client and the Monitoring app.
> - Recent items can be views, elements, services, redundancy groups, service templates and DataMiner modules.

## Apps pane

The apps button displays a list of DataMiner applications.

Depending on the configuration of your DataMiner System, the list can contain up to four sections:

- **Applications**: Plug-in applications, e.g. IDP, PTP, etc.

- **Modules**: The different DataMiner modules, such as Trending, System Center, and add-on modules like Automation and Correlation.

- **General**: The Help, Settings, and About.

- **WFM**: Custom DataMiner WorkFlow Manager components.

Click any app in the list to open it. If you wish to open the app in a new card, use the middle mouse button.
