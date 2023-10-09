---
uid: Working_with_Ping_Monitoring
---

# Working with the Ping Monitoring tool

> [!TIP]
> See also:
>
> - [Ping Monitoring - DataMiner Use Case Demo](https://www.youtube.com/watch?v=LpYbxc0jIro) for a visual guide ![Video](~/user-guide/images/video_Duo.png)
> - [Ping Monitoring use case](https://community.dataminer.services/use-case/ping-monitoring/) for several use cases and application highlights

## The Ping Monitoring tool user interface

To access the Ping Monitoring tool:

1. Go to `http(s)://[DMA name]/root`.

1. Select *PING Monitor* to start using the application.

   ![PING Monitor](~/user-guide/images/Ping_Monitor.png)

The Ping Monitoring tool UI consists of the following main components:

- [Header bar](#the-ping-monitoring-header-bar) (1)

- [Sidebar](#the-ping-monitoring-sidebar) (2)

- [Overview pane](#the-ping-monitoring-overview-pane) (3)

![Ping Monitoring UI](~/user-guide/images/PingMonitoring_UI.png)

### The Ping Monitoring header bar

You can find the following functionalities in the header bar of the application:

- **Refresh**: Available only in the [*Destinations* tab](#the-destinations-tab). Allows you to update the destinations available in your DataMiner System.

- **Alarm History**: Available only in the [*Alarms* tab](#the-alarms-tab). Allows you to access all alarms that occurred in the last 15 minutes, hour, 3 hours, or 24 hours.

### The Ping Monitoring sidebar

The sidebar on the left of the Ping Monitoring tool contains buttons that can be used to expand different panes:

- ![Destinations](~/user-guide/images/Destinations_PM.png) : Clicking the *Destinations* button displays a list overview of all available destinations in your DataMiner System, along with all available information. See [The *Destinations* tab](#the-destinations-tab).

- ![Grid View](~/user-guide/images/Grid_View.png) : Clicking the *Grid View* button displays a grid overview of all available destinations in your DataMiner System. See [The *Grid View* tab](#the-grid-view-tab).

- ![Groups](~/user-guide/images/Groups_PM.png) : Clicking the *Groups* button displays an overview of all active groups in your DataMiner System. Each group corresponds to a Generic Ping element. See [The *Groups* tab](#the-groups-tab).

- ![Alarms](~/user-guide/images/Alarms_PM.png) : Clicking the *Alarms* button displays an overview of all active alarms in the groups. See [The *Alarms* tab](#the-alarms-tab).

### The Ping Monitoring overview pane

#### The 'Destinations' tab

The *Destinations* tab offers an overview of all internet destinations in your DataMiner System receiving ping commands on a predefined, customized basis.

The following information is available for each destination:

- **Destination address**: The URL or IP address of an internet destination, e.g. *www.skyline.be*.

- **Description**: A brief description provided to the destination, e.g. *Skyline*.

- **Group**: The group the destination belongs to, corresponding to a Generic Ping element, e.g. *Websites*.

- **Admin status**: The status (enabled or disabled) of the destination.

- **Ping result**: The time required for destinations to receive and respond to a ping command, e.g. *4 ms*.

- **Cycle packet loss**: The percentage of lost packets during ping command and response process, e.g. *0.00 %*.

Clicking the ![additional information](~/user-guide/images/additional_information.png) button displays additional information about the destination, including host information, results, settings, and more.

#### The 'Grid View' tab

The *Grid View* tab offers a compact grid overview of all destinations, ideal for managing a large number of destinations. The color of each grid tile indicates the associated destination's [alarm severity level](xref:Alarm_types#alarm-severity-levels).

![Grid View](~/user-guide/images/Grid_View_Image.png)

Click any tile in the grid to display additional information about the destination, including host information, results, settings, and more.

#### The 'Groups' tab

The *Groups* tab offers an overview of all active groups, with each group corresponding to a Generic Ping element in your DataMiner System.

This is the main information that is available for each group:

- **# Dst enabled**: The number of enabled destinations in the group.

- **# Dst disabled**: The number of disabled destinations in the group.

- **Current responding ping**: The percentage of destinations responding to ping commands, e.g. *100.00 %*.

- **Average ping time**: The average time it takes for destinations within the group to receive and respond to a ping command, e.g. *11.46 ms*.

Selecting a group in the overview will display all destinations configured within that group in the *Destinations in Selected Group* pane.

![Destinations selected group](~/user-guide/images/Destinations_Selected_Group.png)

Clicking the *Slowest Destinations in Group* button will display any outliers in the groups, i.e. destinations that take a longer time than average to receive and respond to a ping command.

#### The 'Alarms' tab

The *Alarms* tab offers an overview of all active alarms in the groups. A filter pane on the left allows you to filter by group.

#### The filter pane

In the *Destinations* and *Grid View* tabs, a filter pane on the left enables you to narrow down destinations based on their properties.

![Filter pane](~/user-guide/images/Filter_PM.png)

To limit the filter pane to an overview of the currently active filters, enable the toggle button in the top-right corner. Disable the toggle button to return to the full view.

In the lower-left corner, you can see the total destinations as well as the destinations that are currently active in your DataMiner System.
