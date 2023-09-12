---
uid: Connector_help_Anevia_Viamotion_Origin
---

# Anevia Viamotion Origin

The Anevia Viamotion Origin consists of a Streamer control panel. There is also a web interface to control the device.

This is a **serial** connector that will show the status of the different parameters of an Anevia Viamotion Origin.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

## Configuration

### Connections

#### Serial Main Connection

This is a serial connector. The IP and port have to be configured during element creation.

SERIAL CONNECTION:

- **Type of port**: TCP/IP
- **IP address**: The IP of the device, e.g. *10.11.12.13*.
- **IP Port**: The IP port of the device, *8080*.

### Initialization

When the element has been created, go to the **General** \> **Credentials** page, and fill in the username and password for the device.

## Usage

### General Page

This page contains general information about the device, such as the system API version, CPU load, and free RAM.

On the **Credentials** subpage, the username and password for the device must be filled in, to make sure the connector can communicate with the device.

The **Import/Export** functionality is similar to the import and export functionality on the device web interface under System \>Save/Load.

This page also contains a **Reboot Server** button.

### Profiles Page

This page contains information about the **Stream Adaptations** and the **Stream Adaptation Families**. You can edit the **Destination NPVR**, **Login**, and **Password** of the stream adaptation here.

### Live Channels Page

This page contains information about the **Live Channels**, including their **Stream Adaptation Family**. The number of **Running Channels** and **Not Running Channels** is also displayed.

### Interfaces Page

This page contains a table with information about the interfaces of this unit.

### Disks Page

This page contains a table with information about the disks of this unit.

### HTTP Content Page

This page contains a table with information about HTTP content.

### nPVR Table Page

This page contains a table with information about NPVR.

To edit an NPVR (start and end date and time only), click **Edit** and select the NPVR that you want to edit by **Name**.

To create a new NPVR, use the **New NPVR** button.

The table will only be polled if the toggle button **NPVR Polling** is set to *Enabled*.

### Alarms Table Page

This page contains a table with information about **Current Alarms**
