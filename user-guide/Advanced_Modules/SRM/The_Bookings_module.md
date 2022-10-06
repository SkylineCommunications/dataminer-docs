---
uid: The_Bookings_module
---

# The Bookings module

This module is available from DataMiner 9.6.4 onwards under the name *Reservations*, and from DataMiner 9.6.7 onwards under *Bookings*. You can find it in the apps list in Cube.

The module consists of two main areas:

- A list of bookings at the top. See [Bookings list](#bookings-list).

- A timeline showing the bookings below this. See [Bookings timeline](#bookings-timeline).

### Bookings list

Only the bookings that are booked within the area displayed by the timeline are displayed in the list. If you select an item in the list, it is also selected on the timeline.

The list can be customized as follows:

- To sort the items in the list by a particular column, click the header of that column. Click the header again to reverse the sort order.

- To filter which bookings are displayed in the list, click the filter icon for the column you want to apply a filter to and enter a filter in the box below the column header.

- To apply a custom column configuration, see [Creating a new column configuration](#creating-a-new-column-configuration) and [Loading the default column configuration](#loading-the-default-column-configuration).

- From DataMiner 9.6.13 onwards, the color displayed in the *Color* column of the list can be customized using the *Visual.Background* property of bookings. In DataMiner 10.0.0/10.0.2, this property is renamed to *VisualBackground*. See [Customizing the color of booking blocks](xref:Embedding_a_Resource_Manager_component#customizing-the-color-of-booking-blocks).

> [!NOTE]
> When an item is selected in the list, a session variable is populated with the booking ID, which can be of use for Visio drawings.

#### Creating a new column configuration

1. Right-click in the list header, and apply the following configuration as you see fit:

    - Select *Add/Remove column* and indicate which columns should be added or removed.

    - Select *Alignment* and then choose a different text alignment for the columns.

    - Select *Change column name* and specify a new column name.

    - Select *Manage column configuration* (from DataMiner 10.0.4 onwards) or *Add/Remove column* \> *More* (up to DataMiner 10.0.3) to open a window where you can do the following:

        - Show or hide a column by selecting or clearing its checkbox, or by selecting it and clicking *Show* or *Hide*.

        - Move a column up or down by selecting it and clicking *Move up* or *Move down*.

        - Up to DataMiner 9.6.13, a number of additional checkboxes are available for each possible column:

            - Select the *Icon* checkbox of a particular column to have its contents replaced by icons. From DataMiner 9.6.12 onwards, this option is supported for ID columns.

            - Select the *Color* checkbox of a particular column to visualize the cells in that column as colored blocks.

        - From DataMiner 10.0.0/10.0.2 onwards, for columns based on custom properties, you can instead select a different type (e.g. *Custom icon*, *Color*) in the *Column type* drop-down lists. For the default columns, the column type cannot be changed.

        - In the *Filter by type* section, indicate which type of columns you want to choose from: *Bookings* (or *Reservations* in earlier DataMiner versions) or *Properties*.

2. Right-click in the list header and select *Save current column configuration*.
    When the module is opened again, this column configuration will be displayed. If you do not apply this last step, the column configuration will be reset when the module is closed.

#### Loading the default column configuration

- Right-click in the list header, select *Load default column configuration*, and select the configuration you want to load.

### Bookings timeline

The timeline area of the *Bookings* module can be used as follows:

- The timeline has a preview pane at the bottom. The main timeline is an enlargement of the white section of the preview pane.

- To zoom in or out, either scroll in the main pane, or drag the edges of the white area in the preview pane.

- To pan the displayed timeline, drag the white area in the preview pane to the left or right.

- To zoom to a particular time, e.g. the next hour, or the past month, right-click the timeline, and select *Zoom to \[time\]*.

- For more navigation options:

    1. Right-click the timeline, and select *Show navigation panel*.

    2. Expand the *Navigation* section below the panel.

        This panel allows the following actions:

        - To make the timeline move along with the current time, in the lower left corner, select *Follow mode*. This option is also available via the timeline context menu.

        - To change the time zone for the timeline, in the lower right corner, select a different *Time zone*.

> [!NOTE]
> - If you zoom to a particular time period on the timeline, the bookings list will also be updated to display only the bookings in that time period.
> - Prior to DataMiner 10.1.0 \[CU6\]/10.1.9, When you zoom in or out while the current time is within the zoom range, follow mode will automatically be enabled.
>
