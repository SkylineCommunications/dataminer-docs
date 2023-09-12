---
uid: Connector_help_Sony_HDCU-3000_Series
---

# Sony HDCU-3000 Series

This is a smart-serial connector (Ember+) that is used to monitor and configure the Sony HDCU-3000 series camera control units.

## About

### Version Info

| **Range**            | **Key Features**                     | **Based on** | **System Impact** |
|----------------------|--------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                      | \-           | \-                |
| 1.0.1.x              | \-                                   | 1.0.0.16     | \-                |
| 1.0.2.x              | Changed button name (display value). | 1.0.1.4      | \-                |
| 1.0.3.x \[SLC Main\] | Added DCF support.                   | 1.0.2.7      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |
| 1.0.2.x   | \-                     |
| 1.0.3.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.3.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL Connection

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *9000*).

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public.*
- **Set community string**: The community string used when setting values on the device, by default *private.*

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created using this connector consists of the data pages detailed below.

### General

This page displays system information, including the **System Time**, **System Description**, **System Location**, **System Contact**, **System Up Time**, and other general parameters.

### Network

This page displays the **Interfaces** tables. This table displays the operational status of the interfaces available in the workstation. This operational status can also change based on incoming traps.

The following page buttons allow you to monitor and configure related information:

- CNS Settings
- IP Address
- Network Genlock
- IP Live
- NMOS

### Alarms

This page displays the **Error Status** table. This table is both polled and updated based on traps. The table is cleared when a "Coldstart" trap is received.

### Product Information

This page displays the **Product Information**, **Modules**, and **Remote Maintenance** tables.

### Traps

This page displays the **Traps Destination** table.

### System Configuration

This page allows you to monitor and configure the camera control unit. It contains all the system configuration settings, such as the **Gen Lock** and **Multi Format** configuration.

Additional information is displayed on the following subpages:

- Video IO UHD
- Video IO SDI
- Output Format UHD-SDI
- Output Format IP-Out
- Output Format SDI-IO
- Output Format SDI-Out
- Return Format IP-Ret
- Return Format UHD-SDI
- Return Format SDI-IO
- Return Format SDI-Re

### Video

This page allows you to monitor and configure the video-related settings, such as **Color Bar**, **Mono Color** and **Down Convert**.

### Monitor

This page allows you to monitor and configure the monitor-related settings. Additional information is displayed on the following subpages:

- Aspect Marker
- Gate Marker
- Level Gate

### Audio

This page allows you to monitor and configure audio-related settings, such as the **Microphone Gain** and **Audio Output**.

Via a page button, the **Analog Output** settings can be configured.

### Intercom

This page allows you to monitor and configure intercom-related settings. The page is divided in two main sections: **Intercom** and **Front Intercom**.

### IP Audio

This page allows you to monitor and configure IP audio-related settings. The page is divided in three main sections: **Audio Out**, **HD Trunk Audio Out**, and **PGM In**.

### IP Intercom

This page allows you to monitor and configure IP intercom-related settings. Information on the **Intercom Out** and **Intercom In** settings is displayed in a table.

### Maintenance

On this page, settings related to the **Tally Input** can be configured. In future versions, other maintenance-related settings may also become available on this page.

### Configuration File

This page displays information related to the configuration files. At the top of the page, you can select a file and recall its content. There is also a table where the available files are listed, and where each of the files can be renamed and also stored.

### Sony IP Live

This page displays information related to the 2110 monitoring.
