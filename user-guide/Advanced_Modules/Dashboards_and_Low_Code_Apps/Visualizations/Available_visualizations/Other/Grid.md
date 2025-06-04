---
uid: DashboardGrid
---

# Grid

Available from DataMiner 10.4.1/10.5.0 onwards<!--RN 34761-->.

The grid component is a versatile visualization designed to display the results of queries in a clear, tile-based grid format. It offers a wide range of customization options, such as dynamic scaling that automatically adjusts the layout, and features like conditional formatting and interactive behavior through templates. This lets you highlight key data and trigger actions directly from each grid block.

![Grid](~/user-guide/images/Grid.png)<br>*Grid component in DataMiner 10.5.6*

With this component, you can:

- Instantly assess the status of items at a glance, using conditional formatting that highlights issues. For example, a red block might indicate a service that requires attention.

- Interact with individual blocks to trigger actions, such as opening a pop-up window with more details about an upcoming event.

- Focus on items that meet specific criteria, with unmatched blocks automatically dimmed to reduce visual noise.

- Stay focused and avoid overwhelming views, even when there is a lot of data. You can limit how many grid blocks appear at once, while still being able to explore everything intuitively.

<div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
  <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
    <b>💡 TIPS TO TAKE FLIGHT</b><br>
    Interested in what's possible with the table component? Deploy our <a href="https://catalog.dataminer.services/details/6e79f0d1-e622-4fce-8939-d9779beed651" style="color: #657AB7;"><i>Table show case</i> app</a> to see the component in action.
  </div>
  <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
</div>

## Using the grid component

- In read mode, you can manipulate the grid component to **navigate through the columns and rows**:

  - If the number of items exceeds the size of the component, a scrollbar appears when you hover over the component, allowing you to navigate through the items.

  - From DataMiner 10.3.0 [CU11]/10.4.2 onwards<!--RN 38191-->, when you are using a mobile device:

    - You can move the grid left or right and up or down by sliding one finger across the component.

    - You can select grid items by tapping them.

- From DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4 onwards<!--RN 42322-->, when you **select a cell in the grid**, it will by default be highlighted with a blue border and a light-blue background. This can for instance be useful when the grid's [component data](xref:Component_Data) (i.e. *Components* > *Grid #* > *Selected items* > *Tables*) is used in another component, clearly indicating which data is driving the content in the linked component.

## Supported data types

The grid component is used to display the results of queries in grid format. It should therefore **always be configured with [query data input](xref:Query_Data)**.

Each row in a query corresponds to a column in the grid.

> [!TIP]
> For an example of how to configure a GQI query that can be used as data input for a grid component, see [Tutorial: Getting started with the grid component](xref:Tutorial_Apps_Grid).

## Configuration options

### Grid layout

In the *Layout* pane, you can find the default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

Additionally, the following layout options are also available:

| Section | Option | Description |
|--|--|--|
| Filtering & Highlighting | Highlight | Toggle the switch to determine whether the nodes that match the filter will be highlighted. Enabled by default. For more information, see [Using the *Highlight* option with a query filter](#using-the-highlight-option-with-a-query-filter). |
| Filtering & Highlighting | Opacity | Set the level of transparency of the items that do not match the filter. This option is only available when *Highlight* is enabled. For more information, see [Using the *Highlight* option with a query filter](#using-the-highlight-option-with-a-query-filter). |
| Advanced | Empty result message | Available from 10.3.11/10.4.0 onwards<!-- RN 37173 -->. Specify a custom message that is displayed when a query returns no results. See also: [Displaying a custom empty component message](xref:Tutorial_Dashboards_Displaying_a_custom_empty_component_message). |
| Advanced | Grid template | Configure the number of columns and rows in the grid, and adjust scaling options<!--RN 34761 + 34781-->. For more information, see [Layout and scaling options](#layout-and-scaling-options). |
| Item templates | Browse templates<br>*or* Reuse template (prior to DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4) | Reuse a saved template from another component in the same dashboard or low-code app. This option is only available if a template is already in use<!--RN 42226-->. |
| Item templates | Edit | Open the Template Editor<!--RN 34761--> to customize the appearance of grid items and configure actions, such as opening a panel when a cell is selected. For more information, refer to [Using the Template Editor](xref:Template_Editor). |

> [!NOTE]
>
> - When you disable the *Highlight* option, items that do not match the filter will no longer be displayed, and the remaining items will be reorganized.
> - Prior to DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4, the option to reuse a template is only available if another grid component in the same dashboard or low-code app uses a template.

#### Layout and scaling options

In the *Layout* pane for this component, the *Grid template* section is available, which allows you to configure the number of columns and rows displayed in the grid component, along with scaling options.

- By default, the number of displayed columns and rows is set to *Auto* (i.e. all columns and/or rows are displayed). To modify the number of displayed columns and rows, clear the checkbox in this section and specify the desired number. To revert to *Auto*, delete the entry.

- To switch between scaling options, select one of the following buttons:

  - ![Scaled to fit (fixed)](~/user-guide/images/Fixed.png) : The scaling of the cells in the columns and/or rows is adjusted dynamically to fit within the boundaries of the grid component.

  - ![Scaled to fit (scaling)](~/user-guide/images/Scaling.png) : The scaling of the cells in the columns and/or rows is set to a fixed size. This is the default setting.

> [!NOTE]
>
> - The number of items that can be displayed in a grid component is limited to 1000<!--RN 37699-->.
> - If the number of items to be displayed exceeds the number of cells displayed in the component, navigation buttons are available to navigate through the data<!--RN 34761-->.
> - When the scaling of the cells is set to a fixed size and there are too many columns and/or rows to show them at once in the component, in read mode, it is possible to scroll through them with a scrollbar that becomes visible when you hover over the component<!--RN 37699-->.

#### Custom item appearance

In the *Layout* pane for this component, the *Item templates* section is available, which allows you to customize the appearance of the grid items.

##### Examples

-

#### Using the 'highlight' option with a query filter

To **visually distinguish between items that match your filter criteria and those that do not**, you can combine the *Highlight* option of the grid component with a query filter component. This allows you to lower the opacity of non-matching items while keeping relevant results clearly visible.

1. In the *Layout* pane, make sure the *Filtering & Highlighting* > *Highlight* option is enabled.

1. Set your preferred opacity, e.g. 20 %. This determines how clearly you will see the grid items that do not meet the criteria specified in the query filter.

1. Add a [query filter visualization](xref:DashboardQueryFilter) to your app or dashboard.

1. Apply the same query data to the query filter that is used by the grid component.

1. In the *Data* pane, navigate to *All available data* > *Components* > *Query filter #*, and drag the *Query columns* data item onto your grid component.

   In read mode, you can now use the query filter component to filter and refine the data displayed in the grid component. Items that do not meet the specified criteria will be shown with lowered opacity.

![Highlight](~/user-guide/images/Grid_Highlight.gif)<br>*Grid component and query filter component in DataMiner 10.5.6*

### Grid settings

In the *Settings* pane for this component, you can customize its behavior to suit your requirements.

| Section | Option | Description |
|--|--|--|
| WebSocket settings | Inherit WebSocket settings from page/panel | Clear the checkbox to use a custom polling interval for this component. When cleared, you can specify a different polling interval (in seconds). |
| General | Override dynamic units | Clear the checkbox to prevent parameter units from changing dynamically based on their value and protocol definition. Disabled by default. |
| General | Use dynamic units | Determine whether parameter units will change dynamically based on their value and protocol definition. This option is only available when *Override dynamic units* is enabled. |
| Data retrieval | Update data | Toggle the switch to determine whether the data in the grid should be refreshed automatically (provided this is supported by the data source). See [Query updates](xref:Query_updates).<!--RN 37269--> |
| Initial selection | Select first item by default | Available from DataMiner 10.3.6/10.4.0 onwards<!-- RN 35984 -->. Toggle the switch to determine whether the first item is selected by default. When enabled, this is the value that will automatically be applied in the grid whenever the component is loaded or when the data in the grid is refreshed, unless a custom URL is used specifying a different value. Disabled by default. |

## Enabling the component in soft launch

From DataMiner 10.2.12 onwards, the grid component is available in soft launch, if the soft-launch option *ReportsAndDashboardsDynamicVisuals* is enabled. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

If you use the preview version of the grid component, its functionality may be different from what is described below.