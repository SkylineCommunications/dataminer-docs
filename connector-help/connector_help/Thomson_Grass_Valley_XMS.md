---
uid: Connector_help_Thomson_Grass_Valley_XMS
---

Thomson Grass Valley XMS

The **Thomson Grass Valley XMS** is used to control/manage the XMS Manager. This manager keeps track of all the connected devices that are used in the network. Trending and alarming are available on many important parameters.

## About

The Thomson Grass Valley XMS is used to manage and control the devices connected to the network, and to see their state. You can easily see how devices are configured (e.g. redundant devices). All the data is polled by **SNMP**. For each device, it is possible to create a DVE, which provides an overview of all information connected to this device.

## Installation and configuration

Creation

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device.

**SNMP Settings:**

- **Port Number:** The port of the connection device, by default *161*.
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage

### General page

The **General Page** displays the general information of the device manager. At the top of the page you can find the polling configuration. This allows you to enable or disable the Fast Polling and Slow Polling of the tables.

Below the configuration section, you can find the **Device Table**. This table contains all the available devices in the network. Device Names, Descriptions, Statuses, Types, Functions and States are available in this table for each device entry. With the button **Refresh Device Table** it is possible to manually update this table immediately. Below the table, you can find some settings. You can disable/enable a DVE for one single device, or you can enable/disable DVEs for all the devices at once.
For each created DVE, an entry is added in the **Dynamic Virtual Element (DVE) Table** and a DVE is created under the same view as that of the main element. Also, it is possible to import a CSV file with the information of the name and the view of the element, so that the user can easily move the elements in to the desired view.

Below this table, there are two alarm tables. The first alarm table is the **Device Trap Alarm Overview** table. This table contains all the alarms that were pushed from the device XMS manager via Trap updates. The second alarm table is the **General Alarm Overview** table. This table contains other alarms that are polled by SNMP. In both tables there are foreign key relations with the DVEs. So the separate DVEs will only contain information related to their device.

### Switcher Crosspoints page

This page contains a table **Switch Crosspoints Information**, which displays all the crosspoint connections, their **Connection Status** (*Connected* or *Disconnected*), and their **Locked Status** (*Locked* or *Unlocked*).

## Notes

For each DVE that has been created, the same two pages will be available. Only the information that is relevant to the Device DVE will be shown.
