---
uid: Connector_help_Bridge_Technologies_VB288
---

# Bridge Technologies VB288

This connector can be used to display and configure information of the Bridge Technologies VB288 device.

## About

This connector can be used to monitor and control Bridge Technologies VB288 devices. An **HTTP** connection is used in order to successfully retrieve and configure the information of the device.

### Version Info

| **Range**            | **Key Features**                                                                                                                         | **Based on** | **System Impact**                                             |
|----------------------|------------------------------------------------------------------------------------------------------------------------------------------|--------------|---------------------------------------------------------------|
| 1.0.0.x              | Initial version                                                                                                                          | \-           | \-                                                            |
| 1.0.1.x              | \- Fix for duplicate keys.- New firmware version supported.- DCF interfaces implemented.                                                 | 1.0.0.2      | Supported firmware version: 5.1.0.4.                          |
| 1.1.0.x              | \- New firmware version supported.- Unsupported parameters removed.- Audio and video parameters added to the multicast.- Services Table. | 1.0.1.1      | Supported firmware version: 5.4.0.4                           |
| 1.2.0.x \[obsolete\] | New firmware version supported.                                                                                                          | 1.1.0.8      | Supported firmware version: 5.5.0-6.                          |
| 1.2.1.x              | Correct alarm severity discrete parameter PID 1402.                                                                                      | 1.2.0.3      | Alarm monitoring on table Alarms PID 1400 should be reviewed. |
| 1.2.2.x              | Change column descriptions: remove prefix and add table name at the end of the description.                                              | 1.2.1.2      | Automation scripts should be reviewed.                        |
| 1.3.2.x \[SLC Main\] | New firmware version supported.                                                                                                          | 1.2.2.6      | Supported firmware version: 6.1.                              |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |
| 1.0.1.x   | 5.1.0.4                |
| 1.1.0.x   | 5.4.0.4                |
| 1.2.0.x   | 5.5.0-6                |
| 1.2.1.x   | 5.5.0-6                |
| 1.2.2.x   | 5.5.0-6                |
| 1.3.2.x   | 6.1                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.1.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.2.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.2.1.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.2.2.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.3.2.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP port type:** TCP/IP
- **IP address/host:** The polling IP of the device.
- **IP port:** The port of the connected device, by default *80*.

## Usage

### Overview

This page contains a tree control for both the **Multicast** and the **OTT** channels.

### General

This page displays:

- System information, such as **UpTime**, **Name**, **Location**, etc.
- Device information, such as **CPU Temperature**, **Model ID**, etc.
- **Interfaces**: The available interfaces of the device.
- **Alarms**: An overview of the last 20 alarms of the device.

The following subpages are available:

- **Traps**: An overview of the last 20 traps of the device.
- **Trap Destinations**: The trap destinations of the device.
- **SYS Alarms**: An overview of the system alarms.

### Login

This page contains the login information that is required to gain access in order to configure the device.

### Setup

This page contains general settings, such as **EBU Mode**, **Freeze Log**, **SNMP** settings, etc.

The following subpages are available:

- **Colors**: The configuration of the color information of the device.
- **VBC**: VBC-related settings.
- **Login**: Similar settings as those on the main Login page.
- **Scheduling**: Overview and configuration of the schedule.
- **License**: The license and product information of the device.

### Alarms

This page contains an overview of **System Alarms**, **ETH Alarms** and **OTT Alarms**.

On the **Alarm** subpage, you can configure the alarms of the device.

### Multicast

This page contains an overview of all available **Multicast Streams** and **Multicast Services**.

The following subpages are available:

- **Thresholds**: Configuration of the multicast (service) thresholds.
- **PID**: Overview of the multicast PIDs with extra details for **Audio** and **Video** PIDs.
- **Alarms**: Overview of the multicast alarms.
- **Configuration**: Configuration of the multicast streams.

### OTT

This page displays the **OTT Round Time** as well as an overview of all available **OTT Channels** and **OTT Profiles**.

The following subpages are available:

- **Thresholds**: Configuration of the OTT thresholds.
- **PID**: Overview of the OTT PIDs.
- **Alarms**: Overview of the OTT alarms.
- **Configuration**: Configuration of the OTT channels.

### Remote Video Wall

For each remote video wall of the device, there is a page available with the related settings, e.g. **Mode**, **SuperFrame**, etc.

### Mosaic

For each remote video wall, a **Mosaic** page is available, which displays a live stream with the configured settings.

### Web Interface

The web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
