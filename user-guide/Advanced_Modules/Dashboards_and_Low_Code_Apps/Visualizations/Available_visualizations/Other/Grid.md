---
uid: DashboardGrid
---

# Grid

Available from DataMiner 10.4.1/10.5.0 onwards<!--RN 34761-->.

The grid component is a versatile visualization designed to display the results of queries in a tile-based layout. It is particularly suited for  It is perfect for dashboards that  displays query-based data in a clear, grid format with support for configurable display of rows and columns, item templates, and dynamic scaling to fit any dashboard design. Templates allow full visual customization of grid items, including conditional formatting and interactive behaviors like triggering actions on cell selection.

With this component, you can:

-

This component allows you to visualize data as a grid.

![Grid](~/user-guide/images/Grid.png)<br>*Grid component in DataMiner 10.4.1*

From DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4 onwards<!--RN 42128-->, when you right-click the grid component, you can access the browser's context menu and its options. For example, you can select text in a grid component and copy it to another application using the browser's *Copy* command.

## Enabling the component in soft launch

From DataMiner 10.2.12 onwards, the grid component is available in soft launch, if the soft-launch option *ReportsAndDashboardsDynamicVisuals* is enabled. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

If you use the preview version of the grid component, its functionality may be different from what is described below.

## Supported data types

The grid component is used to display the results of queries in grid format. It should therefore **always be configured with [query data input](xref:Query_Data)**.

> [!TIP]
> For an example of how to configure a GQI query that can be used as data input for a grid component, see [Tutorial: Getting started with the grid component](xref:Tutorial_Apps_Grid).

## Using the grid component in read mode

- In read mode, you can manipulate the grid component to **navigate through the columns and rows**:

  - If the number of items exceeds the size of the component, a scrollbar appears when you hover over the component, allowing you to navigate through the items.

  - From DataMiner 10.3.0 [CU11]/10.4.2 onwards<!--RN 38191-->, when you are using a mobile device:

    - You can move the grid left or right and up or down by sliding one finger across the component.

    - You can select grid items by tapping them.

- From DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4 onwards<!--RN 42322-->, when you **select a cell in the grid**, it will by default be highlighted with a blue border and a light-blue background. This can for instance be useful when the grid's [component data](xref:Component_Data) (i.e. *Components* > *Grid #* > *Selected items* > *Tables*) is used in another component, clearly indicating which data is driving the content in the linked component.

## Filtering grid data via the URL

You can filter the content of a grid component by specifying a query column and a filter value directly in the page URL.

1. Hover the mouse pointer over the component and click the filter icon.

1. Add a filter from the *URL* > *Data* > *Query column* section of the *Data* pane.

   > [!NOTE]
   > Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41141-->, you can find the query column filter in the *Feeds > URL > Query columns* section of the *Data* pane.

You can repeat this several times in order to filter on several query columns<!--RN 34761-->.

## Configuration options

### Grid layout

In the *Layout* pane, you can find the default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

Additionally, the following layout options are also available:

| Section | Option | Description |
|--|--|--|
| Filtering & Highlighting | Highlight | Toggle the switch to determine whether the nodes that match the filter will be highlighted. Enabled by default. |
| Filtering & Highlighting | Opacity | Set the level of transparency of the items that do not match the filter. This option is only available when *Highlight* is enabled. |
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

### Grid settings

In the *Settings* pane for this component, you can customize its behavior to suit your requirements.

| Section | Option | Description |
|--|--|--|
| WebSocket settings | Inherit WebSocket settings from page/panel | Clear the checkbox to use a custom polling interval for this component. When cleared, you can specify a different polling interval (in seconds). |
| General | Override dynamic units | Clear the checkbox to prevent parameter units from changing dynamically based on their value and protocol definition. Disabled by default. |
| General | Use dynamic units | Determine whether parameter units will change dynamically based on their value and protocol definition. This option is only available when *Override dynamic units* is enabled. |
| Data retrieval | Update data | Toggle the switch to determine whether the data in the grid should be refreshed automatically (provided this is supported by the data source). See [Query updates](xref:Query_updates).<!--RN 37269--> |
| Initial selection | Select first item by default | Available from DataMiner 10.3.6/10.4.0 onwards<!-- RN 35984 -->. Toggle the switch to determine whether the first item is selected by default. When enabled, this is the value that will automatically be applied in the grid whenever the component is loaded or when the data in the grid is refreshed, unless a custom URL is used specifying a different value. Disabled by default. |
