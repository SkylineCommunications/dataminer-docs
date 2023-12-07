---
uid: Working_with_Huawei_Manager_dashboard
---
            
# Working with the Huawei Manager Dashboard

To access the Huawei Manager Dashboard:

1. Go to `http(s)://[DMA name]/dashboard`.

1. Select *Huawei Switch Infrastructure Generic* to start using the dashboard.

## The Huawei Manager Dashboard interface

The Huawei Manager Dashboard UI consists of the following main components:

![Huawei Manager dashboard UI](~/user-guide/images/Huawei_Manager_dashboard_UI.png)

- [Alarms counter](#alarms-counter) (1)

- [Switch information](#switch-information) (2)

- [General devices monitoring](#general-devices-monitoring) (3)

- [Element and interface selection](#element-and-interface-selection) (4)

- [Detailed interface information](#detailed-interface-information) (5)

### Alarms counter

The *Alarms counter* section shows the number of alarms for each severity (warning, minor, major and critical).

### Switch information

This section shows general selected switch information such as:

- **Element name**: The name of the selected switch, e.g. *GDL_SW5300_LSW_06*.

- **System uptime**: Total time the device has been running without a break since the last time it was turned on or restarted, e.g. *178 days 19h 19m 39s*.

- **System contact**: Contact information associated to the device vendor, e.g. *R&D Beijing, Huawei Technology*.

- **System Location**: The configured location of the device, e.g. *occidente*.

### General devices monitoring

The *General Devices Monitoring* section provides data on performance KPIs, including maximum (max), minimum (min), and average (avg) values for CPU, memory, and Tx/Rx bitrate.

There is also a chart illustrating the distribution of switches in specific areas, along with two additional charts highlighting the top 5 switches with the highest Tx and Rx bit rates.

### Element and interface selection

In the *Element and interface selection* section, you can select a Huawei Switch element from a list of all the Huawei Switch elements in the DataMiner System.

When you have selected an element, you can use the second selection box to pick the desired interface from the switch.

### Detailed interface information

The *Detailed interface information* shows relevant KPIs about the selected element/interface.

The following information sections are available on the dashboard:

- **Details**: This section provides comprehensive information about each interface, including the interface name, associated physical address, available bandwidth, current utilization, and the administrative and operational states of the interface.

  ![Huawei Manager interface details](~/user-guide/images/Huawe_manager_interface_details.png)

- **Bitrate data**: This refers to the total data transfer rate encompassing both inbound (receive) and outbound (send) data, as well as the combined total.

  ![Huawei Manager interface details](~/user-guide/images/Huawe_manager_bitrate_info.png)

- **Alarms**: The total alarms of the selected element and interface.

- **CPU and memory usage**: The overall CPU and memory utilization of the switch, presented as a percentage and visually represented in a graph.

  ![Huawei Manager interface details](~/user-guide/images/Huawei_manager_cpu_usage_interface.png)

- **Entity state**: The equipment modules and the performance data associated with each of them.

At the bottom of the *Detailed interface information* section, several buttons are available that allow you to select a specific time range, so that only the data within that selected time range are displayed.
