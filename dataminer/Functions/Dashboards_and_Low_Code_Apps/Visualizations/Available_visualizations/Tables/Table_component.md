---
uid: DashboardTable
---

# Table

The table component is a highly flexible visualization designed to display the results of queries in a structured, row-column format, similar to a spreadsheet. It is ideal for working with **large sets of information**. The table visualization comes with functionalities such as sorting and filtering, but also offers endless customization options.

![Table component](~/dataminer/images/Table_Component.png)<br>*Table component in DataMiner 10.5.6*

With this component, you can:

- [Sort](#sorting-columns) and [filter data](#filtering-table-content) to quickly find the information you need.

- Easily spot key values, thanks to [conditional formatting](#conditional-coloring) that automatically highlights important data.

- View tables that are tailored to your needs, with a [custom layout](#column-appearance) that makes key data stand out and keeps things intuitive.

- [Copy](#copying-table-data) or [export data](#exporting-the-table) to CSV for reporting or further analysis.

- Interact with table entries. Click rows or cells to [trigger actions](#adding-actions-to-a-table) like opening a pop-up window with more details.

These capabilities make the table component a powerful tool for data exploration and interaction.

<div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
  <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
    <b>💡 TIPS TO TAKE FLIGHT</b><br>
    Interested in what's possible with the table component? Deploy our <a href="https://catalog.dataminer.services/details/6e79f0d1-e622-4fce-8939-d9779beed651" style="color: #657AB7;"><i>Table show case</i> app</a> to see the component in action.
  </div>
  <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
</div>

## Supported data types

The table component is used to display the results of queries in table format. It should therefore **always be configured with [query data input](xref:Query_Data)**.

Each row in a query corresponds to a row in a table.

> [!TIP]
> For an example of how to configure a GQI query that can be used as data input for a table component, see [Tutorial: Creating a custom parameter table connected to an element feed](xref:Creating_a_parameter_table_connected_to_an_element_feed).

## Filtering table content

From DataMiner 10.2.7/10.3.0 onwards, you can filter the contents of a table component using one of four available methods:

- Use the [search box](xref:Filtering_Table_Content#general-filter) to filter the entire table based on the entered value.

  ![General filter](~/dataminer/images/General_Filter.gif)<br>*Table component in DataMiner 10.5.6*

- Momentarily change how column data is displayed using [column filtering](xref:Filtering_Table_Content#column-based-filter). For example, you can show or hide specific values.

  ![Column filtering](~/dataminer/images/Column_Filtering.gif)<br>*Table component in DataMiner 10.5.6*

- Pass a [text string](xref:Filtering_Table_Content#filter-based-on-text-string) to the table, for example by using a text input component.

  ![Text string filter](~/dataminer/images/Text_String_Filter.gif)<br>*Table component in DataMiner 10.5.6*

- Add a [*Filter* operator](xref:Filtering_Table_Content#filter-using-a-query-operator) to a GQI query to apply a server-side filter. The filter value can be set dynamically via a component or the URL.

  ![Filter operator](~/dataminer/images/Filter_Operator.gif)<br>*Table component and grid component in DataMiner 10.5.6*

> [!TIP]
> If you have made changes to the way a table is displayed, and you want to quickly reset your changes and return to the initial table view, click the eye icon in the top-right corner of the component (available from DataMiner 10.2.11/10.3.0 onwards).

## Resizing the table columns

You can **resize the columns** of a table by dragging the edges of the column headers. From DataMiner 10.1.8/10.2.0 onwards, you can also change the order of the columns by dragging the column headers to a different position.

> [!TIP]
> From DataMiner 10.4.1/10.5.0 onwards<!--RN 37522-->, you can adjust the default column width by accessing the [Template Editor](xref:Template_Editor) through *Layout > Column appearance*.

![Resizing and moving columns](~/dataminer/images/Resizing.gif)<br>*Table component in DataMiner 10.5.6*

## Sorting columns

To sort the table, you can **click a column header**. To toggle between ascending and descending order, click the column header again.

![Column sorting](~/dataminer/images/Column_Sorting.png)<br>*Table component in DataMiner 10.5.6*

To apply **additional sorting**, press **Ctrl** while clicking one or more additional headers. The first column will then be used for the initial sorting, the next one to sort equal values of the first column, and so on.

Alternatively, you can also select one of the available sorting options in the **column header right-click menu**.

To **group** by a specific table column, right-click the column header and click *Group*. To stop grouping, right-click the header again and select *Stop grouping*.

## Copying table data

From DataMiner 10.2.7/10.3.0 onwards, you can copy a cell, a column, a row, or the entire table via the right-click menu of the component.

![Copy table data](~/dataminer/images/Copy_Table_Data.png)<br>*Table component in DataMiner 10.5.6*

Unless a single cell is copied, the copy is in CSV format. If an entire column or single cell is copied, the values will not be encapsulated in double quotes. Copying an entire row or table will encapsulate all values in accordance with CSV formatting. If a value contains a double quote, this will be escaped when it is copied.

## Exporting the table

From DataMiner 10.1.3/10.2.0 onwards, you can export the content of the table by clicking the ... button in the top-right corner of the component and selecting *Export to CSV*.

![Export to CSV](~/dataminer/images/Export_to_CSV.png)<br>*Table component in DataMiner 10.5.6*

What happens next depends on your DataMiner version:

- Prior to DataMiner 10.3.8/10.4.0, if nothing is selected in the table, the entire table will be exported; otherwise only the selected rows will be exported. The data will contain the display values, not the raw values. This means that units will be included for the parameter values and that discrete values will be replaced by their corresponding display values.

- From DataMiner 10.3.8/10.4.0 onwards, a pop-up window will open where you can select whether the raw values or the display values from the table should be exported. Exporting the display values will result in a CSV file that contains all the values as they are seen in the table, formatted and with units. If you export the raw values, no formatting will be applied to them. The only exception are discrete values, for which the corresponding display values will always be exported. If no rows are selected in the table, the entire table will be exported; otherwise only the selected rows will be exported.

The export file will be named “Query XXX” (XXX being the name of the query, as configured in the *Data* pane). The first line of the CSV file will contain the names of the columns. The subsequent lines will contain the data, each line being a row of the query result.

> [!NOTE]
> To only export specific columns, first apply a filter by dragging the columns onto the table component before you export the component.

## Configuration options

### Table layout

In the *Layout* pane, you can find the default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

Additionally, the following layout options are also available:

| Section | Option | Description |
|--|--|--|
| Filtering & Highlighting | Conditional coloring | Highlight cells based on a condition. For more information, refer to [Conditional coloring](#conditional-coloring). |
| Filtering & Highlighting | Show quick filter | Available from DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards<!--RN 40818-->. Toggle the switch to determine whether the search box, which lets you [apply a general filter](xref:Filtering_Table_Content#general-filter) across the table, is available in the top-right corner of the table. Enabled by default. |
| Column appearance | Column appearance | Available from DataMiner 10.4.1/10.5.0 onwards<!--RN 37522-->. Customize the appearance of a column. For more information, refer to [Column appearance](#column-appearance). |
| Advanced | Empty result message | Available from DataMiner 10.3.11/10.4.0 onwards<!--RN 37173-->. Configure the message shown when a query returns no results. From DataMiner 10.5.0 [CU12]/10.6.3 onwards<!-- RN 44472 -->, this setting can be left empty, in which case no message is displayed and the component remains empty. See also: [Displaying a custom empty component message](xref:Tutorial_Dashboards_Displaying_a_custom_empty_component_message). |

#### Conditional coloring

In the *Layout* pane for this component, the *Conditional coloring* option is available, which allows you to highlight cells based on a condition. You can configure this option as follows:

- If the column you want to use for highlighting contains **values for which a specific range can be specified**, select the column, indicate the range to be highlighted, select the range and then click the color icon on the right to specify a highlight color. Multiple ranges can be indicated for one column, each with a color of its own.

- Alternatively, from DataMiner 10.2.0/10.1.8 onwards, you can **filter on specific text** instead. To do so, select the column you want to use for highlighting, specify the text, and select the highlight color. You can change the filtering behavior by clicking *equal* above the text box and selecting one of the available options:

  - **Equal** (default): Highlights cells that are exactly equal to the specified text.

  - **Contain**: Highlights cells that contain the specified text anywhere.

  - **Match regex**: Highlights cells that match a regular expression. For example, to highlight empty cells, you can use the regex `^$`.

  You can also apply a negative filter by clicking *does*, which will make this field switch to *does not* instead.

  ![Conditional coloring](~/dataminer/images/Conditional_Coloring.png)<br>*Table component in DataMiner 10.5.6*

- **Multiple filters** can be applied on the same value. In that case, the filters will be applied from the top of the list to the bottom. Positive filters will get priority over negative filters.

- You can **remove a column filter** again by selecting *No color* instead of a specific color.

#### Column appearance

From DataMiner 10.4.1/10.5.0 onwards<!-- RN 37522 -->, in the *Layout* pane, the *Column appearance* option is available, which allows you to customize the appearance of a column.

##### Column appearance presets

To use one of the available presets to alter the column appearance, click the preview below the column name and select a preset option:

| Preset | Description |
|--|--|
| ![Left](~/dataminer/images/Preset_Left.png) | Aligns text to the left of the cell. This is the default setting for columns containing values of type string. |
| ![Center](~/dataminer/images/Preset_Center.png) | Centers the text within the cell. |
| ![Right](~/dataminer/images/Preset_Right.png) | Aligns text to the right of the cell. This is the default setting for columns containing values of type double or datetime. |
| ![Hyperlink](~/dataminer/images/Preset_Hyperlink.png) | Available in low-code apps only. Turns the text into a hyperlink that opens a webpage in a new tab. |
| ![Icon](~/dataminer/images/Preset_Icon.png) | Displays a centered icon in the cell. By default, the info icon is used. |
| ![Background](~/dataminer/images/Preset_Background.png) | Adds a background color to the cell. By default, a blue color (#1F68BF) is used. |

> [!NOTE]
> If you select the *Hyperlink* preset option, a [*Navigate to a URL* action](xref:LowCodeApps_event_config#navigating-to-a-url) is automatically configured. The target URL can be edited using the [Template Editor](xref:Template_Editor).

##### Custom column appearance

To freely **customize the appearance** of a column:

1. Click the ellipsis button ("...") next to the column name.

1. Select *Customize preset* to open the Template Editor.

> [!NOTE]
> If you open the Template Editor after selecting a preset option, the template may already contain certain configured layers.
>
> For example, if you selected the *Hyperlink* preset, a rectangle layer with opacity 0%, including a *Navigate to a URL* action, will be configured. Additionally, the text color of the text layer will be set to blue (#1F68BF), and the text inside the text box will be enclosed by HTML `<u>` elements to define underlined text.

From DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4 onwards<!--RN 42226-->, you can also **reuse saved templates** from the same dashboard or low-code app:

1. Click the ellipsis button ("...") next to the column name.

1. Select *Browse templates*.

> [!TIP]
> For thorough instructions on changing the column appearance within the Template Editor, refer to [Template Editor](xref:Template_Editor).

##### Examples

Below are two examples illustrating how the Template Editor can be used to customize the appearance and behavior of individual columns beyond the standard presets.

- A green checkmark icon is displayed when the status is set to `Paid`:

  ![Example 1](~/dataminer/images/Custom_Column_Appearance.png)<br>*Template Editor and table component in DataMiner 10.5.6*

- A currency conversion menu is added to the *Total* column using a calculator icon (only possible in Low-Code Apps):

  ![Example 2](~/dataminer/images/Custom_Column_Appearance2.png)<br>*Template Editor and table component in DataMiner 10.5.6*

  > [!TIP]
  > These examples illustrate that the Template Editor can be used not only to customize how data looks but also to add interactive elements. For more information, refer to [Adding actions to a table](#adding-actions-to-a-table).

### Table settings

In the *Settings* pane for this component, you can customize its behavior to suit your requirements.

| Section | Option | Description |
|--|--|--|
| WebSocket settings | Inherit WebSocket settings from page/panel | Clear the checkbox to use a custom polling interval for this component. When cleared, you can specify a different polling interval (in seconds). |
| General | Override dynamic units | Clear the checkbox to prevent parameter units from changing dynamically based on their value and protocol definition. Disabled by default. |
| Data retrieval | Update data | Available from DataMiner 10.2.0/10.2.1 onwards. Toggle the switch to determine whether the data in the table should be refreshed automatically (provided this is supported by the data source). |
| Actions | On double click | Configure one or more actions to be executed when a row is double-clicked. Only available in Low-Code Apps. |
| Initial selection | Select first row by default | Available from DataMiner 10.3.6/10.4.0 onwards<!-- RN 35984 -->. Toggle the switch to determine whether the first row is selected by default. When enabled, the first row will automatically be selected whenever the component is loaded or when the data in the table is refreshed. |

> [!NOTE]
>
> - While the *Update data* setting is available from DataMiner 10.2.0/10.2.1 onwards<!-- RN 31450 -->, in older DataMiner versions it can only be used with the *Get parameter table by ID* query data source. From DataMiner 10.3.10/10.4.0 onwards<!-- RN 36789 -->, other data sources are also supported.
> - Instead of enabling the *Update data* setting to refresh data automatically, you can also refresh it manually using a [trigger component](xref:DashboardTrigger) or a [component action](xref:LowCodeApps_event_config).
> - In versions prior to DataMiner 10.3.7/10.4.0, refreshing the table using a trigger component or component action causes the any selected data to be lost. From DataMiner 10.3.7/10.4.0 onwards, the component will try to reapply the selection. This means that the table will keep fetching more data until all previously selected rows are found. When a previously selected row is missing, the table will fetch all data looking for it. Reapplying the previous selection will take precedence over selecting the first row when the *Initial Selection* setting is enabled. The table will also update its data to reflect the new selection. <!-- RN 36372 -->

## Adding actions to a table

If you add a table component to a custom app using the [DataMiner Low-Code Apps](xref:Application_framework), you can also configure actions for the component. This feature is not available in the Dashboards app. <!-- RN 29394 -->

To configure actions:

- From DataMiner 10.4.1/10.5.0 onwards<!--RN 37522-->:

  - In the Template Editor, you can **configure actions for table columns**. Actions can be linked to the *On click* event of a shape in a column template, allowing you to define your own links or buttons inside a table.

    > [!TIP]
    > For more information, see [Changing template settings](xref:Template_Editor#changing-template-settings).

  - You can also **configure actions that are executed when a row is double-clicked**:

    1. In the *Component > Settings* pane, expand the *Actions* section.

    1. Click *On double-click*.

    1. In the pop-up window, select the action that should be executed. See [Configuring app events](xref:LowCodeApps_event_config).

- Prior to DataMiner 10.4.1/10.5.0:

  1. In the *Component* \> *Settings* pane, expand the *Actions* section.

  1. Click *Add action*.

  1. To specify how the action is triggered, at the top of the action configuration section, click the icon for text hyperlink, row double-click, or cell button.

  1. In the *Label* box, specify a label for the action.

  1. In the *Icon* box, select an icon for the action.

  1. In the *Action* box, select the action that should be executed. You can for instance use this to add an update action to the table, or to allow users to select an item or clear their selection. See [Configuring app events](xref:LowCodeApps_event_config).
