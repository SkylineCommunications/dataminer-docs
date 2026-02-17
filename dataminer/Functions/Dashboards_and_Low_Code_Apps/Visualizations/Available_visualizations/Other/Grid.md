---
uid: DashboardGrid
---

# Grid

Available from DataMiner 10.4.0/10.4.1 onwards<!--RN 34761-->.

The grid component is a versatile visualization designed to display the results of queries in a clear, tile-based grid format. It offers a **wide range of customization options**, including dynamic scaling, conditional formatting, and interactive features that let you trigger actions directly from each grid block.

![Grid](~/dataminer/images/Grid.png)<br>*Grid component in DataMiner 10.5.6*

With this component, you can:

- Instantly assess the status of items, thanks to [conditional formatting](#customizing-grid-items), e.g., red may indicate a service is in alarm.

- [Use grid selections](#using-the-grid-as-a-selector) to pass data to other components. For example, clicking a grid item can control what's displayed in a different component.

- Interact with individual blocks to [trigger actions](#adding-actions-to-a-grid), such as opening a pop-up window with more details about an upcoming event.

- Focus on items that meet specific criteria, with unmatched blocks [automatically dimmed](#highlighting-filtered-results) to reduce visual noise.

- Stay focused and avoid overwhelming views, even when there is a lot of data. You can [limit how many grid blocks appear at once](#layout-and-scaling-options), while still being able to explore everything intuitively.

<div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
  <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
    <b>💡 TIPS TO TAKE FLIGHT</b><br>
    Interested in getting some hands-on experience with the grid component? Follow <a href="xref:Tutorial_Apps_Grid" style="color: #657AB7;">this beginner-friendly tutorial</a>!
  </div>
  <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
</div>

## Navigating grid content

A grid component displays a number of columns and rows, depending on the [layout options](#layout-and-scaling-options) configured in the *Grid template* section of the *Layout* pane. These settings determine how many items are shown at once.

If there are more items than can fit in the grid, **navigation arrows** appear below it<!--RN 34761-->. Click these arrows to move forward and backward through the additional items.

![Navigation arrows](~/dataminer/images/Grid_Navigation_Arrows.gif)<br>*Grid component in DataMiner 10.5.7*

If the individual grid blocks are too large to fit within the visible area of the component, a **scrollbar** appears when you hover over the grid<!--RN 37699-->. Use this scrollbar to scroll through the content.

![Scrollbar](~/dataminer/images/Grid_Scrollbar.gif)<br>*Grid component in DataMiner 10.5.7*

> [!NOTE]
> You can edit the size of the grid blocks in the [Template Editor](xref:Template_Editor).

From DataMiner 10.3.0 [CU11]/10.4.2 onwards<!--RN 38191-->, grid components support the following **touch interactions on mobile devices**:

- Swipe with one finger to scroll horizontally or vertically.

- Tap to select grid items.

## Supported data types

The grid component is used to display the results of queries in grid format. It should therefore **always be configured with [query data input](xref:Query_Data)**.

Each row in a query corresponds to an item in the grid.

> [!TIP]
> For an example of how to configure a GQI query that can be used as data input for a grid component, see [Tutorial: Getting started with the grid component](xref:Tutorial_Apps_Grid).

## Using the grid as a selector

You can use a grid component as a dynamic selector, i.e., a component whose selection **determines behavior or data elsewhere in your dashboard or app**. A common use case is controlling what is shown in another component, but selected values can also serve as input for scripts, queries, or conditional behavior.

When you select an item in the grid, the selected data (e.g., *All available data* > *Components* > *[Page name]* > *Grid* > *Selected items* > *Tables*) becomes automatically available for use in other components.

In the example below, a grid filters a table component based on job state. By selecting a grid item, users can quickly switch between active, upcoming, completed, or all jobs.

![Grid as a selector](~/dataminer/images/Grid_as_Selector.gif)<br>*Grid component and table component in DataMiner 10.5.7*

> [!TIP]
> For another good example of the grid component functioning as a selector, see [Example use case: Pan and zoom the map via grid selection](xref:DashboardMaps#example-use-case-pan-and-zoom-the-map-via-grid-selection).

To **clear the selection** in a grid, keep Ctrl pressed and click each selected item.

From DataMiner 10.4.0 [CU20]/10.5.0 [CU8]/10.5.11 onwards<!--RN 43635-->, an action can also be configured on another component (e.g., a button) so that this can be used to clear the grid selection (see [Configuring app events](xref:LowCodeApps_event_config)).

## Configuration options

### Grid layout

In the *Layout* pane, you can find the default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

Additionally, the following layout options are also available:

| Section | Subsection | Option | Description |
|--|--|--|--|
| Filtering & Highlighting | N/A | Highlight | Toggle the switch to determine whether the nodes that match the criteria specified in a query filter will be highlighted. Enabled by default. For more information, see [Highlighting filtered results](#highlighting-filtered-results). |
| Filtering & Highlighting | N/A | Opacity | Set the level of transparency of the items that do not match the criteria specified in a query filter. This option is only available when *Highlight* is enabled. For more information, see [Highlighting filtered results](#highlighting-filtered-results). |
| Advanced | N/A | Empty result message | Available from 10.3.11/10.4.0 onwards<!-- RN 37173 -->. Specify a custom message that is displayed when a query returns no results. From DataMiner 10.5.0 [CU12]/10.6.3 onwards<!-- RN 44472 -->, this setting can be left empty, in which case no message is displayed and the component remains empty. See also: [Displaying a custom empty component message](xref:Tutorial_Dashboards_Displaying_a_custom_empty_component_message). |
| Advanced | N/A | Grid template | Available up to DataMiner 10.4.0 [CU20]/10.5.0 [CU8]/10.5.11<!--RN 43889-->. Configure the number of columns and rows in the grid, and adjust scaling options<!--RN 34761 + 34781-->. For more information, see [Layout and scaling options](#layout-and-scaling-options). |
| Grid layout | Columns | Fixed column count | Available from DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43889-->. Determine how many columns are displayed. For more information, see [Layout and scaling options](#layout-and-scaling-options). |
| Grid layout | Columns | Columns | Available from DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43889-->, when the *Fixed column count* option is enabled. Specify the number of columns to display. |
| Grid layout | Columns | Stretch to fit | Available from DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43889-->. Enable this setting to have items expand horizontally to fill the container. Enabled by default. |
| Grid layout | Columns | Stretch mode | Available from DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43889-->, when *Stretch to fit* is enabled and *Fix column count* is disabled. Control how items behave when stretched. For more information, see [Layout and scaling options](#layout-and-scaling-options). |
| Grid layout | Columns | Horizontal scroll | Available from DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43889-->, when *Stretch to fit* is disabled. Enable this setting to allow horizontal scrolling instead of wrapping or clipping content. |
| Grid layout | Rows | Fixed row count | Available from DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43889-->. Toggle the switch to determine how many rows are displayed. For more information, see [Layout and scaling options](#layout-and-scaling-options). |
| Grid layout | Rows | Rows | Available from DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43889-->, when *Fixed row count* is enabled. Specify the number of rows to display. |
| Grid layout | Rows | Stretch to fit | Available from DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43889-->. Enable this setting to have items expand vertically to fill the container. Disabled by default. |
| Grid layout | Rows | Stretch mode | Available from DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43889-->, when *Stretch to fit* is enabled and *Fix column count* is disabled. Control how items behave when stretched. For more information, see [Layout and scaling options](#layout-and-scaling-options). |
| Grid layout | Rows | Vertical scroll | Available from DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43889-->, when *Stretch to fit* is disabled. Enable this option to allow vertical scrolling instead of wrapping or clipping content. Enabled by default. |
| Item templates | N/A | Browse templates *or*<br>Reuse template (prior to DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4) | Reuse a saved template from another component in the same dashboard or low-code app. This option is only available if a template is already in use<!--RN 42226-->. |
| Item templates | N/A | Edit | Open the Template Editor<!--RN 34761--> to customize the appearance of grid items and configure actions, such as opening a panel when a cell is selected. For more information, refer to [Customize grid items](#customizing-grid-items). |

> [!NOTE]
>
> - When you disable the *Highlight* option, items that do not match the filter will no longer be displayed, and the remaining items will be reorganized.
> - Prior to DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4, the option to reuse a template is only available if another grid component in the same dashboard or low-code app uses a template.

#### Layout and scaling options

##### [From DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43889-->](#tab/tabid-1)

In the *Layout* pane, under *Grid layout*, you can **configure the number of columns and rows** displayed in the grid component and **choose how items scale** within the available space.

- By default, the grid automatically displays all columns and rows, adapted to the available width and height. To show a fixed number of columns or rows, enable *Fixed column count* or *Fixed row count* and enter the desired value.

  ![Fixed column count](~/dataminer/images/Fixed_Column_Count.gif)<br>*Grid component in DataMiner 10.5.12*

- To have items expand and fill the available space, enable the *Stretch to fit* option for columns and/or rows. When enabled for columns, items scale horizontally. When enabled for rows, items scale vertically.

  ![Stretch to fit](~/dataminer/images/Stretch_to_Fit.gif)<br>*Grid component in DataMiner 10.5.12*

- When *Stretch to fit* is enabled, you can refine how items scale using the *Stretch mode* options:

  - ![Fit](~/dataminer/images/Stretch_Mode_Fit.png) Fit: Items shrink so as many as possible can be displayed within the grid.

  - ![Limit](~/dataminer/images/Stretch_Mode_Limit.png) Limit: The item size configured in the item template is preserved. Any overflow is paginated. This is the default setting.

  ![Stretch mode](~/dataminer/images/Stretch_Mode.gif)<br>*Grid component in DataMiner 10.5.12*

##### [Earlier versions](#tab/tabid-2)

In the *Layout* pane, under *Advanced* > *Grid template*, you can **configure the number of columns and rows** displayed in the grid component and **choose how items scale** within the available space.

![*Grid template* section](~/dataminer/images/Grid_Template.png)<br>*Grid layout settings in DataMiner 10.5.7*

- By default, the number of displayed columns and rows is set to *Auto* (i.e., all columns and/or rows are displayed). To specify a fixed number, clear the checkbox and enter the desired value(s). To revert to *Auto*, delete the entry.

- To switch between scaling options, click the icon next to the column or row count:

  - ![Scaled to fit (fixed)](~/dataminer/images/Fixed.png) : The cells are scaled dynamically to fit the grid.

  - ![Scaled to fit (scaling)](~/dataminer/images/Scaling.png) : The cells have a fixed size. This is the default setting.

***

> [!NOTE]
> The number of items that can be displayed in a grid component is limited to 1000<!--RN 37699-->.

#### Customizing grid items

Using the Template Editor, you can fully customize the appearance of each grid item (or block). Thanks to [conditional formatting](xref:Template_Editor#adding-conditional-cases-to-a-layer), **each item can be styled differently** to highlight key information.

To edit the grid item template:

1. In the *Layout* pane, navigate to the *Item templates* section.

   This section shows a preview of the template currently applied to the grid component.

1. Click *Edit* to open the Template Editor.

1. Make your changes as described under [Using the Template Editor](xref:Template_Editor).

<div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
  <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
    <b>💡 TIPS TO TAKE FLIGHT</b><br>
    More of a visual learner? Watch the <a href="https://community.dataminer.services/courses/kata-16/" style="color: #657AB7;"><i>Introducing grid components</i> video tutorial</a> to see the Template Editor at work!
  </div>
  <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
</div>

<br>

Some **real-life examples**:

- In this example, each block represents a service. The background color reflects the current alarm status, while small media players and logos make it easy to identify which services are affected just by scanning the page.

  ![Penalty box](~/dataminer/images/Penalty_Box.png)<br>*Grid component in DataMiner 10.5.7*

- This example shows a grid component used on the landing page of an event management app. It shows the next five upcoming events. Each block displays basic details like the event title and its start and end time.

  ![Next 5 events](~/dataminer/images/Next_Five_Events.png)<br>*Grid component in DataMiner 10.4.3*

  > [!TIP]
  > While basic event details are already displayed, you can configure the grid to open a panel with additional information when a user clicks an item. For more info, see [Adding actions to a grid](#adding-actions-to-a-grid).

#### Default grid template

By default, the template of a grid component includes the following **pre-configured layers**:

| Layer | Type | Description |
|--|--|--|
| ![Text layer](~/dataminer/images/Grid_Text_Layer.png) | Text | Displays the value from the first column in the data source. |
| ![Rectangle layer 1](~/dataminer/images/Grid_Rectangle_Layer.png) | Rectangle | Acts as the background of each grid block, with conditional formatting for hover and selection. |
| ![Rectangle layer 2](~/dataminer/images/Grid_Rectangle_Layer2.png) | Rectangle | Acts as a visual border by being slightly larger than the background layer, with conditional formatting for selection. |

This default template (available from DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4 onwards<!--RN 42322-->) ensures that a grid block is highlighted when hovered over and stands out when selected, with a light-blue background and a blue border.

![Selecting a grid block](~/dataminer/images/Selecting_Grid_Block.gif)<br>*Grid component in DataMiner 10.5.7*

This can for instance be useful when the grid's [component data](xref:Component_Data) (e.g., *Components* > *[Page name]* > *Grid* > *Selected items* > *Tables*) is used in another component. The highlight helps users identify which data is driving the content of the linked component.

#### Highlighting filtered results

To **visually distinguish items that match your filter criteria from others**, you can combine the *Highlight* option with a query filter component. This allows you to lower the opacity of non-matching items while keeping relevant results clearly visible.

![Highlight](~/dataminer/images/Grid_Highlight.gif)<br>*Grid component and query filter component in DataMiner 10.5.6*

1. In the *Layout* pane, make sure the *Filtering & Highlighting* > *Highlight* option is enabled.

1. Set your preferred opacity, e.g., 20 %. This determines how clearly you will see the grid items that do not meet the criteria specified in the query filter.

   ![Highlight filtered results](~/dataminer/images/Highlight_Filtered_Results.png)<br>*Grid layout settings in DataMiner 10.5.7*

1. Add a [query filter visualization](xref:DashboardQueryFilter) to your app or dashboard.

1. Apply the same query data to the query filter that is used by the grid component.

1. From DataMiner 10.5.0 [CU12]/10.6.3 onwards<!--RN 44015-->, navigate to *All available data* > *Components* > *[Page name]* > *Query filter* in the *Data* pane, and drag the *Query columns* data item onto your grid component.

   Note that depending on your setup, the exact path may be different. For example, in versions prior to DataMiner [CU21]/10.3.0 [CU9]/10.4.12<!--RN 41141-->, component data is found under the *Feeds* data category.

   In read mode, you can now use the query filter component to filter and refine the data displayed in the grid component. Items that do not meet the specified criteria will be shown with lowered opacity.

### Grid settings

In the *Settings* pane for this component, you can customize its behavior to suit your requirements.

| Section | Option | Description |
|--|--|--|
| WebSocket settings | Inherit WebSocket settings from page/panel | Clear the checkbox to use a custom polling interval for this component. When cleared, you can specify a different polling interval (in seconds). |
| General | Override dynamic units | Clear the checkbox to prevent parameter units from changing dynamically based on their value and protocol definition. Disabled by default. |
| General | Use dynamic units | Determine whether parameter units will change dynamically based on their value and protocol definition. This option is only available if *Override dynamic units* is enabled. |
| Data retrieval | Update data | Toggle the switch to determine whether the data in the grid should be refreshed automatically (provided this is supported by the data source). See [Query updates](xref:Query_updates).<!--RN 37269--> |
| Initial selection | Select first item by default | Available from DataMiner 10.3.6/10.4.0 onwards<!-- RN 35984 -->. Toggle the switch to determine whether the first item is selected by default. When enabled, this is the value that will automatically be applied in the grid whenever the component is loaded or when the data in the grid is refreshed, unless a custom URL is used specifying a different value. Disabled by default. |

## Adding actions to a grid

If you add a grid component to a low-code app, you can configure actions that are triggered when users interact with elements inside the grid. This feature is not supported in the Dashboards app.

In the Template Editor, you can define actions for grid items. These actions can be triggered by the *On click* event of a shape in the item template, allowing you to define your own links or buttons inside the grid.

> [!TIP]
> For more information, see [Adding conditional cases to a layer](xref:Template_Editor#adding-conditional-cases-to-a-layer).

Some **real-life examples**:

- In the example below, grid components are used to connect sources to destinations. By configuring on-click actions behind the scenes, users can select sources and destinations in read mode and connect or disconnect them directly.

  ![Control Surface](~/dataminer/images/Control_Surface.png)<br>*Grid component and button component in DataMiner 10.5.1*

- In this example, an on-click action is configured on a pencil icon within each grid item. When a user clicks the icon, a pop-up panel opens, allowing them to edit the corresponding contract directly.

  ![Edit contract](~/dataminer/images/Edit_Contract.gif)<br>*Low-Code Apps module in DataMiner 10.5.7*

## Enabling the component in soft launch

From DataMiner 10.2.12 onwards, the grid component is available in soft launch, if the soft-launch option *ReportsAndDashboardsDynamicVisuals* is enabled. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

If you use the preview version of the grid component, its functionality may be different from what is described on this page.
