---
uid: Connector_help_Zixi_Broadcaster
---

# Zixi Broadcaster

The **Zixi Broadcaster** processes video stream from Zixi Feeder, enabling transcoding, transmuxing, recording and distribution in multiple bitrates and protocols to any device anywhere. It is an intelligent and versatile video distribution component that can be used on site or as a cloud service.

## About

The Zixi Broadcaster connector uses HTTP communication to allow users to monitor and manage the device.

### Version Info

| **Range** | **Description**                                                                           | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                                                                          | No                  | Yes                     |
| 1.0.1.x          | Added an SNMP connection for interface information.                                       | No                  | Yes                     |
| 1.0.2.x          | Reviewed Outputs and Outputs Statistics index so pull streams will reuse an existing row. | No                  | Yes                     |

### Product Info

| **Range**        | **Device Firmware Version** |
|-------------------------|-----------------------------|
| 1.0.0.x 1.0.1.x 1.0.2.x | API 1.10                    |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host:** The polling IP.
- **IP Port:** The IP port of the destination.

#### SNMP Secondary Connection

This connector uses an SNMP connection to gather interface information and requires the following input during creation:

SNMP CONNECTION

- **IP address/host:** The IP of the SNMP connection.
- **IP Port:** The IP port of the destination, by default *161*.

## Usage (1.0.0.x)

### General

This page displays general information related to the device and to the usage and utilization of the unit.

By default, an input or an output and their statistics and alerts get deleted when they are removed on the transcoder. To avoid this behavior, change **Missing Data Behavior** to ***Mark as Removed***. In this case, the status of the input or output will be changed to *Removed*, so that alarm monitoring and trending are still possible on the missing stream. The input or output will then still be removed after the expiration period defined in **Removed Data Expiration Time**.

### License Information

This page contains information on the available license services and their status.

### Inputs

This page displays all the **input streams** that have been created, with their current status, their type, the source host and port number, the bitrate and the amount of time the stream has been active.

It also allows you to configure and access various actions that can be performed on this input stream, and displays the statistics for each input.

Creating and editing inputs can be done on the **Input New/Edit** page, which can be accessed via a page button. To edit an input, first select the input. To create an input, first set a **New Stream ID**. Then select an input type and fill in the required fields.

### Outputs

This page displays all the outputs that have been set. The following types are supported: **UDP**, **RTPM**, **Pull Stream** and **Push Stream**. The page lists the status of the output, the type, the destination host, the bitrate, and whether the output has been active.

It also allows you to configure and access various actions that can be performed on this output stream and displays the statistics for each output.

Creating and editing outputs can be done on the **Output New/Edit** page, which can be accessed via a page button. To create or edit an output, select an **Output Name** and fill in the required fields.

### Purge Connections

This page allows you to manage the inactive connections, set the **Purge Timeout** value and enable the purge for inputs and/or outputs. The latter is done with the **Purge** button, and will delete all connections that have been inactive for at least the indicated number of timeout seconds.

### Adaptive Groups

This page allows you to group multiple inputs of the same content encoded at different bitrates.

### VOD

This page displays the structure of the repository directory, listing the generated video-on-demand files.

### Settings

This page displays the unit general configuration. Currently, the only managed values are the **GUI web port for HTTP administration**, the **administrator and user password** and **the public and private ports** used as listening ports for pull outputs and push inputs.

### Settings - Live Protocol

This page displays the unit configuration for **HTTP Server** and **RTMP Server** values.

### Settings - Multicast / VOD

This page displays the current unit configuration for **Multicast Settings** and **VOD Settings**.

### Settings - Auth / Log

This page displays the current **Authorization** and **Logging Settings**.

### Event Log

This page displays the list of the last events contained in the unit.

### Matrix

This page connects to the unit web interface page, which displays preview thumbnails of the selected inputs and output to show the stream in the matrix.
Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

### Device Web Interface

This page provide access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage (from 1.0.1.x onwards)

### General

This page displays general information related to the device and to the usage and utilization of the unit.

The **Interfaces** page button provides access to SNMP interface information, such as the available **NICs**, the **IP Addresses** and their **Status**.

From version 1.0.1.2 onwards, the **Interface Polling** toggle button on the Interfaces subpage can be used to disable or enable SNMP polling.

### License Information

This page contains information on the available license services and their status.

### Inputs

This page displays all the **input streams** that have been created, with their current status, their type, the source host and port number, the bitrate and the amount of time the stream has been active.

It also allows you to configure and access various actions that can be performed on this input stream, and displays the statistics for each input.

At the bottom of the page, the **Stream Alerts** table shows various tr101 alerts and stream alerts for each stream.

Creating and editing inputs can be done on the **Input New/Edit** page, which can be accessed via a page button. To edit an input, first select the input. To create an input, first set a **New Stream ID**. Then select an input type and fill in the required fields.

To see data usage for the inputs in the last hours/days/weeks/months, navigate to the **Input History Stats** page, which is also available via a page button. On this page, you can also find the total cost of usage for the last day, week and month. The total cost is calculated by taking the usage and multiplying it by the cost per GB, which is a user-defined parameter.

The **Input Summary** page contains the totals of all history usage and all costs for all inputs.

The **Stream Summary** page contains the totals of key KPIs for all inputs in the Stream Statistics table.

### Outputs

This page displays all the outputs that have been set. The following types are supported: **UDP**, **RTPM**, **Pull Stream** and **Push Stream**. The page lists the status of the output, the type, the destination host, the bitrate, and whether the output has been active.

It also allows you to configure and access various actions that can be performed on this output stream, and displays the statistics for each output.

Creating and editing outputs can be done on the **Output New/Edit** page, which can be accessed via a page button. To create or edit an output, select an **Output Name** and fill in the required fields.

**Note**:

- For outputs with multiple hosts (e.g. a push output), separate the fields with commas (",") without adding spaces. For example: "*213.222.10.15,213.222.10.16,213.222.10.17*".
- For **NICs/Devices**, it is possible to specify "*Any"*. **Backup** streams can be selected by specifying *Disabled* or *Enabled*.
- For the **Max Bitrate**, specify the desired number (in kbps) and then "*kbps*", separated by a space. You can also specify *Unlimited* for unlimited bitrates. For example, a 3-host system could be specified as follows: "*13 kbps,Unlimited,14 kbps"*.

### Purge Connections

This page allows you to manage the inactive connections, set the **Purge Timeout** value and enable the purge for inputs and/or outputs. The latter is done with the **Purge** button, and will delete all connections that have been inactive for at least the indicated number of timeout seconds.

### Adaptive Groups

This page allows you to group multiple inputs of the same content encoded at different bitrates.

### VOD

This page displays the structure of the repository directory, listing the generated video-on-demand files.

### Settings

This page displays the unit general configuration. Currently, the only managed values are the **GUI web port for HTTP administration**, the **administrator and user password** and **the public and private ports** used as listening ports for pull outputs and push inputs.

### Settings - Live Protocol

This page displays the unit configuration for **HTTP Server** and **RTMP Server** values.

### Settings - Multicast / VOD

This page displays the current unit configuration for **Multicast Settings** and **VOD Settings**.

### Settings - Auth / Log

This page displays the current **Authorization** and **Logging Settings**.

### Event Log

This page displays the list of the last events contained in the unit.

### Matrix

This page connects to the unit web interface page, which displays preview thumbnails of the selected inputs and output to show the stream in the matrix. If **HTTPS Access** is disabled, the interface will use an HTTP address.
Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

### Device Web Interface

This page provides access to the web interface page of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
