---
uid: The_Bookings_module
---

# The Bookings module

This module is available from DataMiner 9.6.4 onwards under the name *Reservations*, and from DataMiner 9.6.7 onwards under *Bookings*. You can find it in the apps list in Cube.

The module consists of two main areas:

- A list of bookings at the top. See [Bookings list](#bookings-list).

- A timeline showing the bookings below this. See [Bookings timeline](#bookings-timeline).

## Bookings list

Only the bookings that are booked within the area displayed by the timeline are displayed in the list. If you select an item in the list, it is also selected on the timeline.

The list is similar to a list view component in Visual Overview. For more information on how to work with this list, see [Customizing a list view in DataMiner Cube](xref:Creating_a_list_view#customizing-a-list-view-in-dataminer-cube).

## Bookings timeline

### Preview and main pane

The timeline area of the *Bookings* module can be used as follows:

- The timeline has a preview pane at the bottom. The main timeline is an enlargement of the white section of the preview pane.

- To zoom in or out, either scroll in the main pane, or drag the edges of the white area in the preview pane.

- To pan the displayed timeline, drag the white area in the preview pane to the left or right.

- To zoom to a particular time, e.g. the next hour, or the past month, right-click the timeline, and select *Zoom to \[time\]*.

> [!NOTE]
>
> - If you zoom to a particular time period on the timeline, the bookings list will also be updated to display only the bookings in that time period.
> - Prior to DataMiner 10.1.0 \[CU6\]/10.1.9, When you zoom in or out while the current time is within the zoom range, follow mode will automatically be enabled.

### Settings/Navigation pane

#### [From DataMiner 10.3.0/10.3.1 onwards](#tab/tabid-1)

- For more navigation options:

  1. Right-click the timeline, and select *Show settings panel*.

  1. Expand the *Settings* section below the panel.

     This panel allows the following actions:

     - To change the time zone for the timeline, in the lower right corner, select a different *Time zone*.

     - To make the timeline move along with the current time, in the lower left corner, select *Follow mode*. This option is also available via the timeline context menu.

       > [!NOTE]
       > When you navigate away from the line that represents now while follow mode is enabled, follow mode will temporarily be paused. As soon as you navigate back in view of the line that represents now, follow mode will be activated again.

#### [Prior to DataMiner 10.3.0/10.3.1](#tab/tabid-2)

- For more navigation options:

  1. Right-click the timeline, and select *Show navigation panel*.

  1. Expand the *Navigation* section below the panel.

     This panel allows the following actions:

     - To change the time zone for the timeline, in the lower right corner, select a different *Time zone*.

     - To make the timeline move along with the current time, in the lower left corner, select *Follow mode*. This option is also available via the timeline context menu.

       > [!NOTE]
       > When you navigate away from the line that represents now while follow mode is enabled, follow mode will temporarily be paused. As soon as you navigate back in view of the line that represents now, follow mode will be activated again.

***
