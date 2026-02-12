---
uid: DataMiner_Cube_sidebar
---

# DataMiner Cube sidebar

On the left-hand side of the Cube UI, a sidebar is displayed. By default, this sidebar contains the following buttons:

| Icon | Name | Description |
|--|--|--|
| ![Surveyor](~/dataminer/images/Surveyor.png) | Surveyor | Opens the Surveyor pane. See [Surveyor pane](#surveyor-pane). |
| ![Activity](~/dataminer/images/Activity.png) | Activity | Opens a pane listing recent items. See [Activity pane](#activity-pane). |
| ![Apps](~/dataminer/images/Apps.png) | Apps | Opens a pane listing the different apps available in Cube. See [Apps pane](#apps-pane). |
| ![Workspace](~/dataminer/images/Workspace.png) | Workspace | Opens a pane where you can select and manage different Cube workspaces. See [Working with workspaces](xref:Working_with_workspaces). |
| ![Community](~/dataminer/images/Community.png) | Community | Clicking the button opens a menu with different links to the [DataMiner Dojo user community](https://community.dataminer.services/), including the blog, the learning hub, a page where you can ask questions about anything related to DataMiner, a page that allows you to suggest new features, and a page that allows you to provide feedback<!--RN 41605-->. |

You can pin additional buttons to the sidebar using the "..." or "+" button. This button opens a menu where you can select the buttons you want to pin.

| Icon | Name | Description |
|:--:|:--:|--|
| ![Overview](~/dataminer/images/Overview.png) | Overview | Displays the root view page listing all items below the root view. |
| ![Search](~/dataminer/images/Search.png) | Search | If an advanced search is done from the Cube header bar, an additional *Search* button is displayed, which displays the pane with the advanced search results. If this button is not pinned to the sidebar, it will no longer be displayed as soon as you click a different button. See [Searching in DataMiner Cube](xref:Searching_in_DataMiner_Cube). |
| ... | ... |  A button representing any of the available modules, the "About" information, the Help, or the settings. |

To unpin a button again, right-click the button and select *Unpin*. This is not possible for the buttons that are displayed by default.

![Unpin a button](~/dataminer/images/Unpin_Button.png)<br>*DataMiner Cube sidebar in DataMiner 10.4.5*

> [!NOTE]
>
> - At most 4 items can be pinned to the sidebar. If the maximum number of items has been added, the button to pin more items is no longer displayed, until an item is unpinned again.
> - It is possible to move the position of the sidebar to the right-hand side. To do so, press *Ctrl+Alt+Shift+RightArrow*. To move the pane back to the left-hand side, press *Ctrl+Alt+Shift+LeftArrow*. The sidebar position can also be changed in the Cube settings. See [Cube settings](xref:User_settings#cube-settings).
> - In an EPM environment, an additional *Topology* button can be available, which allows you to navigate through the EPM topology.<!-- RN 42221 -->

## Surveyor pane

The Surveyor pane contains a hierarchical overview of all views, elements, services, etc. in your DataMiner System. It features alarm bubble-up, state indication, etc.

When you click an item in the tree, it opens in a card:

- If you click the item with the left mouse button, the new card replaces a card that is already open.

- If you click the item with the middle mouse button, the new card is opened next to any cards that are already open.

> [!NOTE]
>
> - For the right-click menu options in the Surveyor, see [Surveyor right-click menu](#surveyor-right-click-menu).
> - You can drag an element, service, view, or SLA from a card or from the Surveyor to another application, such as Microsoft Word or Outlook, to copy information about that DataMiner item to the application in question.

### Icons

The icons that precede an item name in the tree show what kind of item it is and what state and alarm state it is in.

> [!NOTE]
> Depending on the user settings, the legacy icons may be displayed instead of the icons described below. These look similar to the icons displayed below but allow some [additional icon settings](#special-icon-settings).

- There are specific icons for different types of items:

  | Icon | Item description |
  |------|------------------|
  | ![View icon](~/dataminer/images/CubeXView.png) | View |
  | ![Element icon](~/dataminer/images/CubeXElement.png) | Element |
  | ![Service icon](~/dataminer/images/CubeXService.png) | Service |
  | ![Service template icon](~/dataminer/images/CubeXServiceTemplate.png) | Service template |
  | ![Redundancy group icon](~/dataminer/images/CubeXRedunGroup.png) | Redundancy group |
  | ![SLA icon](~/dataminer/images/CubeXSLA.png) | SLA |
  | ![Protocol icon](~/dataminer/images/CubeXProtocol.png) | Protocol |
  | ![Parameter icon](~/dataminer/images/CubeXParameter.png) | Parameter |
  | ![Script icon](~/dataminer/images/CubeXScript.png) | Script |
  | ![Setting icon](~/dataminer/images/CubeXSetting.png) | Setting |
  | ![Function icon](~/dataminer/images/CubeXFunction.png) | Default function DVE (requires DataMiner Service & Resource Management) |

- View icons are filled with a different color, depending on their alarm state. On other icons, a colored circle is displayed when they are in a particular alarm state. In addition to the default colors indicating the alarm severity, the circle can also be displayed in purple to indicate that an item is masked.

  <div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
    <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
      <b>💡 TIPS TO TAKE FLIGHT</b><br>The alarm state color is determined by the most severe of all the current alarms for the item. There are four <a href="xref:Alarm_types#alarm-severity-levels" style="color: #657AB7;">alarm severity levels</a>, each indicated by a color. These default alarm colors can be changed in the <a href="xref:Changing_the_default_alarm_colors" style="color: #657AB7;"><i>DataMiner.xml</i> file</a>.
    </div>
    <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
  </div>
  <br>

- There may be additional symbols on an icon to indicate a particular state:

  | Symbol  | Description   |
  |---------|---------------|
  | Gray square | Located in the corner of an icon to indicate that the item is stopped. |
  | Two vertical bars | Located in the corner of an icon to indicate that polling on the item is paused. |
  | Orange X | Indicates that an element in a view or service is in timeout state. |
  | White X on red background | Indicates that an element is in error state. |
  | Upwards arrow | Displayed next to a service child in case the capped severity of the service child is lower than the actual severity. The icon has the color of the severity that will bubble up to the parent service. |
  | Circle containing a horizontal line, for example: ![Unavailable element icon](~/dataminer/images/element_unavailable.png) | Indicates that the DMA hosting the item is currently unavailable. Though the information on the item is still available in the cache, it is not possible to execute any actions on the item. |

#### Special icon settings

In the DataMiner settings, there are several options to show more alarm information next to an icon than just the current state. These icon settings are only available if the [Use modern icons](xref:User_settings#icons-settings) setting is **not** enabled.

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

### Surveyor right-click menu

In the Surveyor right-click menu, the following options are available, depending on what type of item is right-clicked:

| Menu option | Right-clicked item | Description |
|--|--|--|
| Expand all in alarm | View only | Expands all subviews with an active alarm. |
| Collapse level | View only | Collapses the level of the right-clicked view. |
| Open | Any | Opens the item in a card. |
| Open in new card | Any | Opens the item in a new card. |
| Open in new undocked card | Any | Opens the item in a new, undocked card. |
| Ticket | Element, service, view | Obsolete. See [Ticketing](xref:ticketing). |
| State | Element only | Opens a shortcut that allows you to [change the element state](xref:Changing_the_state_of_an_element). |
| Mask | Element only | [Masks the element](xref:Masking_or_unmasking_an_element). |
| Unmask | Element only | [Unmasks the element](xref:Masking_or_unmasking_an_element#unmasking-an-element). This option is only available for masked elements. |
| Multiple set | Element only | Allows you to [set a parameter value in multiple elements](xref:Updating_elements#setting-a-parameter-value-in-multiple-elements). From DataMiner 10.4.0 [CU17]/10.5.0 [CU5]/10.5.8 onwards<!--RN 43135-->, this menu option is only available when the [*Enable 'Multiple set'* Cube user setting](xref:User_settings#cube-settings) is enabled. |
| Protocols & Templates | Element, enhanced service | Opens a submenu where you can:<br> - View the used [protocol](xref:Protocols1) or [service protocol](xref:About_services#enhanced-services), [alarm template](xref:About_alarm_templates), and [trend template](xref:About_trend_templates).<br> - Assign alternative templates.<br> - View all available templates. |
| View | Element | Opens a shortcut menu that allows quick access to [DataMiner logging](xref:Consulting_the_DataMiner_logs_in_DataMiner_Cube) or [Stream Viewer](xref:Connecting_to_an_element_using_Stream_Viewer). |
| Edit | Element, service | Opens a card where you can change the configuration of the element or service. |
| Remove from parent | Any view child item, except a child view | Moves the item from the parent view to the root view. |
| Delete | Any except root view | Removes the item. |
| Duplicate | Element, service | Duplicates the item. |
| Rename | Element, service, view, redundancy group | Allows you to rename the item. |
| New | Any | Opens a submenu where you can select to create a new [element](xref:About_elements), [service](xref:About_services), [service template](xref:Service_templates), [redundancy group](xref:About_redundancy_groups),[redundancy group template](xref:About_redundancy_groups#redundancy-group-templates), or [SLA](xref:sla). If you right-clicked a view, you can also select to create a new view. |
| Actions > Alert me | Element, service, view | Allows you to [configure a personal alert](xref:Configuring_notifications_directly_from_the_Alarm_Console_or_Surveyor) for alarms related to the right-clicked item. |
| Actions > Export | Element, service, view | Allows you to export the selected item [to a DataMiner package](xref:Exporting_elements_services_etc_to_a_dmimport_file) or [to a CSV file](xref:Importing_and_exporting_elements#exporting-elements-to-a-csv-file). |
| Actions > Import | View | Allows you to [import a DataMiner package](xref:Importing_elements_services_etc_from_a_dmimport_file) or [a CSV file](xref:Importing_and_exporting_elements) in the right-clicked view. |
| Actions > Create simulation | Element | Allows you to [create a simulation file](xref:Creating_a_simulated_element#creating-a-simulation-file) based on the right-clicked element, which can be used to create a [simulated element](xref:Simulated_elements). |
| Actions > Enable simulation | Element | Allows you to [create a simulated element](xref:Creating_a_simulated_element). |
| Actions > Add tab to global Alarm Console | Element, service, view | Creates a filtered tab in the Alarm Console to show alarms for the right-clicked item only. |
| Actions > Apply service template | View | Allows you to [apply a service template](xref:Applying_service_templates) to the right-clicked view. |
| Actions > Upgrade to service | View without child views | Allows you to transform the right-clicked view into a service. The child elements in the view will become child elements of the new service. |
| Actions > Analyze | Element, service, view | Allows you to [analyze the alarms](xref:Using_Correlation_analyzers) for the right-clicked item in order to create a correlation rule based on that analysis. |
| Actions > Add element/service to dashboard | Element, service | Allows you to add the right-clicked item to a legacy dashboard. However, note that the [legacy dashboards module](xref:dashboards) is being retired, and it is by default disabled from DataMiner 10.4.0/10.4.1 onwards. |
| Properties | Element, service, view | Opens the item’s *Properties* window. |
| Drag and drop editing | Any | Enables the [drag-and-drop view editing mode](xref:Managing_views#editing-a-view). |

> [!NOTE]
>
> - For some special items, such as redundancy group templates or service templates, additional options are available.
> - The *View* option is also available for [enhanced services](xref:About_services#enhanced-services), with the options to view the protocol, alarm template, or trend template of such a service.
> - When opening an item from the right-click menu, you can hold *Ctrl* while clicking the menu option to open the item in a new card, or hold *Shift* while clicking the option to open the item in a new undocked card.

## Activity pane

The activity button displays a pane listing recently opened items, such as elements, services, views, and apps.

The following actions are possible with this list:

- Click an item in the list to open it in a card. If you wish to open the item in a new card, use the middle mouse button.

- Pin an item so that it is placed in the *Pinned* section at the top of the list: hover over the item with the mouse pointer until a pin icon appears to the right of it, then click the pin icon.

  ![Pin an item](~/dataminer/images/Pin_Item.png)<br>*Activity pane in DataMiner 10.4.5*

> [!NOTE]
>
> - Regardless of how frequently you view them, pinned items remain in the top section of the list until you click the pin icon again to remove them.
> - The list of recent and pinned items is kept synchronized between DataMiner Cube client and the Monitoring app.
> - Recent items can be views, elements, services, redundancy groups, service templates and DataMiner modules.

## Apps pane

The apps button displays a list of DataMiner applications.

Depending on the configuration and version of your DataMiner System, as well as on which user permissions you have been assigned, the list can contain the following sections:

- **Modules**: DataMiner modules such as [Automation](xref:automation), [Documents](xref:About_the_Documents_module), and [Trending](xref:Accessing_trend_information_from_the_Trending_module).

- **Applications**: Plug-in applications, e.g. [IDP](xref:SolIDP), [PTP](xref:SolPTP), etc.

- **Web Apps**: The [Monitoring app](xref:Working_with_the_Monitoring_app), [Dashboards app](xref:newR_D), and any available [low-code apps](xref:Dashboards_and_Low_Code_Apps).<!-- RN 33944 -->

- **General**: The Help, Settings, and About.

- **WFM**: Custom DataMiner WorkFlow Manager components.

- Any custom sections [configured in the DataMiner Low-Code Apps module](xref:LowCodeApps_organizing_landing_page), listing low-code apps.<!-- RN 33944 -->

Click any item in the list to open it. If you wish to open the item in a new card, click the item while pressing the *Ctrl* key. However, note that the web apps will always open in a browser tab instead of in DataMiner Cube.
