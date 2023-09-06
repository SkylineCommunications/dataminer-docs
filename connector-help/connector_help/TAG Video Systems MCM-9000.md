---
uid: Connector_help_TAG_Video_Systems_MCM-9000
---

# TAG Video Systems MCM-9000

The MCM-9000 family of products enables real-time live monitoring of MPEG-2 and H.264 video sources, both in SD quality and HD quality.

## About

This connector uses an HTTP connection to poll data from the MCM-9000 device. If the system is a "stacked" system, all data will be polled through the main MCM-9000 device.

The connector can receive traps to update the channel and system events in real time.

### Version Info

Range **1.1.5.x** of the connector is based on the 1.1.4.7 version. It changes the **protocol type from "asci" to "unicode"**.

### Product Info

| **Range**                                           | **Supported Firmware**                    |
|-----------------------------------------------------|-------------------------------------------|
| 1.0.0.x 1.0.0.11 1.0.0.13-14 1.0.0.15-22 1.0.0.23\* | 2.3.3 2.4.6 2.5.2 2.5.3 2.5.4 2.6.7 4.1.1 |
| 1.1.0.x 1.1.1.x                                     | 3.3.5 4.1.1 4.1.7 4.2.3                   |
| 1.1.2.x                                             | 4.1.1 4.1.7 4.2.3 4.2.8 4.4.4 4.5.7       |
| 1.1.3.x                                             | 4.1.1 4.1.7 4.2.3 4.2.8 4.4.4 4.5.7 5.2.3 |
| 1.1.4.x \[SLC Main\]                                | 4.1.1 4.1.7 4.2.3 4.2.8 4.4.4 4.5.7 5.2.3 |
| 1.1.5.x                                             | 4.1.1 4.1.7 4.2.3 4.2.8 4.4.4 4.5.7 5.2.3 |

Firmware versions 2.5.2 and higher support HTTP Live Streaming (HLS). A Visio file is available to display the mosaic stream in DataMiner.
To display the HTTP Live Stream, VLC Media Player is required on the client computer.

## Configuration

### Connections

This connector uses a Simple Network Management Protocol (SNMP) connection to receive traps sent by the MCM-9000 system, as well as an HTTP connection, and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The IP of any MCM-9000 device in the stack.
- **IP port:** The IP port of the destination, by default *162*.

**HTTP CONNECTION:**

- **IP address/host:** The polling IP or URL of any MCM-9000 device in the stack.
- **IP port:** The IP port of the destination, by default *80*.
- **Bus address:** If the proxy server has to be bypassed, specify *bypassproxy*.

### Initialization

After an element has been created, the authentication settings need to be configured. To do so, go to the **System Information** page, click the **Connection Settings** button, and specify the settings in the pop-up window.

## Usage (1.0.0.x)

### System Information

On this page, you can view all device and licensing parameters for the whole (stacked) system.

### Overview

This page provides an overview of the network interfaces, the services, and all PIDs in a tree structure.

### Network

On this page, you can view all settings from all network interfaces from all devices in the stack.

### Services

All services of the MCM-9000 system can be monitored on this page.

On the pop-up page **Scan Channels**, all running and finished scans can be monitored.

### PIDs

On this page, the **PIDs Overview** table shows all PIDs in the system. These can be monitored separately.

### System Events

On this page, you can view all system events in the **System Events Overview** table. There is a separate table for heartbeats, the **Heartbeat Overview** table.

### Channel Events

On this page, the **Channel Events Overview** table displays all channel events. A separate table, the **Channel Status Overview**, displays the channel status.

### Output Stream

On this page, you can manipulate the mosaic stream.

To set a channel in a specific box on the stream, click the **Channel Position** page button, select a channel and a box, and click the **Set Channel Position** button. Deleting or adding an output stream is possible via the **Add Output Stream** and **Delete Output Stream** page buttons, respectively. Selecting a layout is possible via the **Layout** page button. However, note that these page buttons are only available from **version 1.0.0.17** of the connector onwards.

Note: A Visio file is available to display the mosaic stream in DataMiner. Manipulating the channel position is also possible from the Visio overview.

### Web Interface

This page displays the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage (1.1.0.2, 1.1.1.x, 1.1.2.x, 1.1.3.x)

### General

On this page, you can view all device and licensing parameters for the whole (stacked) system.

The page also displays the **Number of Monitored Channels** and allows you to activate the option to **Automatically Remove Missing Services and PIDs.** There are also buttons available to trigger a **soft reset**, to **reboot** or **shut down** the device, or to **save the configuration**.

### Overview

This page provides an overview of the network interfaces, the services, and all PIDs in a tree structure.

### Network

On this page, you can view and configure the settings from all network interfaces from all devices in the stack.

### Services

All services of the MCM-9000 system can be monitored on this page.

### PIDs

On this page, the **PIDs Overview** table displays information for all the PIDs in the system. These can be monitored separately.

For the specific video statistic information, you can manually retrieve the information using the **Get Video Statistics** button. You can also enable **Automatic Polling of Video Statistics** to get the information every minute.

### System Events

On this page, you can view all system events in the **System Events Overview** table. There is a separate table for heartbeats, the **Heartbeat Overview** table. Buttons are available to clear these tables automatically or manually.

### Channel Events

On this page, the **Channel Events Overview** table displays all channel events. Buttons are available to clear old inactive events.

By right-clicking, you can acknowledge channel events.

Note: From version 1.1.2.9 onwards, you can change the display key from "Name/Description" to "Name Description ExtraDescription".

### Scan Channels

On this page, you can modify and run the **Scanner Tasks** that will scan IPs and ports.

### Channel Status

A table with the **Channel Status** is displayed on this page, with important information such as the **Channel Service Minimum Bitrate**, **Channel Service Maximum Bitrate**, and **Channel Service Average Bitrate.**

With the **Channel Events to Keep** toggle button at the top of the page, you can choose to either keep all channel events or keep only active events with minor/major/critical severity.

Via the right-click menu of the table, you can **start or stop monitoring** a channel. You can also start or stop monitoring a channel using the "**Monitored**" column parameter in the table.

### Channel Configuration

Introduced in version 1.1.2.19. This page allows you to configure basic channel parameters. In order to fill in the parameters, a channel must be selected in the **Select an Input Channel** drop-down box at the top of the page.

Via page buttons, you can configure the channel content and miscellaneous information. The **Channel Profiles** and **Channel PIDs/Components** configuration tables are available on dedicated subpages.

### Output Stream

On this page, you can manipulate the mosaic stream.

You can configure any of the settings of the output stream on this page. Selecting layouts for each output and the **Layout Cycle Interval** is possible via the **Layout Selection** page button. You can add an output stream via the **Add Output Stream** page button.

Via the right-click menu in the **Encoder Configuration** table, you can **delete**, **enable**, or **disable** selected encoders.

Note: A Visio file is available to display the mosaic stream in DataMiner. Manipulating the channel position is also possible from the Visual Overview.

### Layouts

On this page, you can manipulate the individual **layouts**. You can add or remove channels from a layout by selecting a layout and then changing the selected channel in the **Layout Channels Table**. You can also use the **Add Layout** and **Delete Layout** page buttons to add or delete a layout, respectively.

### Alarm Presets

On this page, you can create and edit **Alarm Presets**. You can also import and export presets using .csv files.

Note: From version 1.1.2.8 onwards, the export and import alarm presets functionality uses .xml files.

### Web Interface

This page displays the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage (1.1.4.x and 1.1.5.x)

### Tally Layouts

This page displays the different types of tally layouts. You can edit different aspects of the channel tiles and the text tiles via the **Tally Layouts Channel Tiles** and **Tally Layouts Text Tiles** tables, respectively.

## Notes

For this connector to be able to poll the device, the following files are required:

- The file "SLSystem.Web.Helpers.dll" (renamed version of "System.Web.Helpers.dll") must be placed inside the ProtocolScripts folder.
- The file "System.Web.Helpers.dll" must be placed in the folder *C:\Windows\Microsoft.NET\assembly\GAC_MSIL\System.Web.Helpers\v4.0_1.0.0.0\_\_31bf3856ad364e35\\*.

## DataMiner Connectivity Framework

From version **1.0.4.21** of the connector onwards, DCF is supported. It can be enabled or disabled with the toggle button on **Network** page.
