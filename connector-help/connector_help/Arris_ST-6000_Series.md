---
uid: Connector_help_Arris_ST-6000_Series
---

# Arris ST-6000 Series

This is a DataMiner connector for the **Arris ST-6000 Series**, an advanced multi-channel, multi-format video transcoder.

## About

The **Arris ST-6000 Series** connector is used to catch a failover trap and instruct the device during this procedure.

### Version Info

| **Range**     | **Description**                                     | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                    | No                  | Yes                     |
| 2.0.0.x              | Added buttons for individual failover elements.     | No                  | Yes                     |
| 2.0.1.x \[SLC Main\] | Full connector review.                                 | No                  | Yes                     |
| 2.1.0.x              | Adapted connector to work with firmware version 4.4.5. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 2.0.0.x          | Unknown                     |
| 2.0.1.x          | 1.1-2                       |
| 2.1.0.x          | 4.4.5                       |

## Installation and configuration

The connector has two interfaces. The **SNMP interface** is used for SNMP traps and to monitor the device, and the **HTTP interface** is used for communication with the device during failover.

#### Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.11.12.13.*

HTTP Settings:

- **Bus address**: This field can be used to bypass the proxy. To do so, fill in the value *bypassproxy*.

## Usage (1.0.0.x - 2.0.0.x)

The element should be part of a redundancy group that takes care of the failover.

### Configurations

Each operation has a **status parameter**, showing *Ok*, *Busy* or *Failed*. Below this, the **timestamp** shows the last time an operation was attempted and resulted in *Ok* or *Failed*. The operations can be started with the following buttons:

- **Save Configuration**: Request the device to store the current configuration.
- **Download Configuration File**: Download the created configuration file.
- **Disable Multicast Ports**: Disable active multicast ports and store which ones were active.
- **Re-enable UDP Ports**: Enable the previously active multicast ports.
- **Upload Configuration File**: Upload the local configuration file to the device.
- **Select Configuration File**: Load the configuration file as the active configuration.
- **Restart All Channels**: Restart all the channels to complete the configuration switch and set the device as active.

### General

This page displays general information about the device.

### Output UDP

On this page, the **Output UDP Table** shows information about each output and allows you to disable or enable each one. When one or more outputs are enabled, the **UDP Ports** status will change from *Disabled* to *Enabled*.

### Alarms

On this page, the **Status Current Alarm Table** lists all the active alarms of the device.

### Traps

On this page, you can edit the trap destination and settings in the **Trap Receivers Table**. The received traps can be viewed and cleared in the **Trap Status Table**.

### SNMP Pages

The following pages contain tables concerning additional settings and information about the streams processed by the device:

- **Channels**: Channel Names Table, Alarm Status Table and Operational Status Table.
- **Input Configuration**: Input Mpts Status Table, Input UDP Table, Input Source Table and Input Internal Source Table.
- **Audio**: Audio Table.
- **Video**: Video Avc Table.
- **Output**: Output Destination Table and Stat Mux Table.
- **Transport**: Transport Table.
- **ancData and adInsert**: Anc Data Table and Ad Insert Table.

### Web Interface

This page displays the web interface of the device. However, note that for this the client must be in the same network as the device.

## Usage (2.0.1.x)

The element should be part of a redundancy group that takes care of the failover.

### General

This page displays general information about the device.

### Configurations

Each operation has a **status parameter**, showing *Ok*, *Busy* or *Failed*. Below this, the **timestamp** shows the last time an operation was attempted and resulted in *Ok* or *Failed*. The operations can be started with the following buttons:

- **Save Configuration**: Request the device to store the current configuration.
- **Download Configuration File**: Download the created configuration file.
- **Disable Multicast Ports**: Disable active multicast ports and store which ones were active.
- **Re-enable UDP Ports**: Enable the previously active multicast ports.
- **Upload Configuration File**: Upload the local configuration file to the device.
- **Select Configuration File**: Load the configuration file as the active configuration.
- **Restart All Channels**: Restart all the channels to complete the configuration switch and set the device as active.

### Output UDP

On this page, the **Output UDP Table** shows information about each output and allows you to disable or enable each one. When one or more outputs are enabled, the **UDP Ports** status will change from *Disabled* to *Enabled*.

### Alarms

On this page, the **Status Current Alarm Table** lists all the active alarms of the device.

### Traps

On this page, you can edit the trap destination and settings in the **Trap Receivers Table**. The received traps can be viewed and cleared in the **Trap Status Table**.

### Channels

This page displays a table containing user-friendly names for the channels used in the GUI, which source to use for which channel, and the UDP parameters for each channel. These entries are only valid if UDP(1) is selected as input for the corresponding channel.

It also contains page buttons to the following subpages:

- **MPTS Status**: Displays a table containing the various MPTS or SPTS parameters.
- **UDP**: Displays a table containing the UDP parameters for each channel. These entries are only valid if UDP(1) is selected as input for the corresponding channel.
- **Source**: Displays a table that shows which source to use for each channel.
- **Internal Source**: Displays a table that shows which image numbers are used when the input type *Internal Source* is selected, per channel.

### Audio

This page displays a table containing parameters for the active and stored audio services.

### Video

This page displays a table containing the AVC video parameters for all stored services.

### Output

This page displays a table listing the output destination for each channel.

### Transport

This page displays a table containing transport parameters.

### Ancillary Data

This page displays a table containing ancillary data parameters.

### Advertisement Insert:

This page displays a table containing attributes for advertisement insertion.

### Web Interface

This page displays the web interface of the device. However, note that for this the client must be in the same network as the device.

## Usage (2.1.0.x)

The element should be part of a redundancy group that takes care of the failover.

### Configurations

Each operation has a **status parameter**, showing *Ok*, *Busy* or *Failed*. Below this, the **timestamp** shows the last time an operation was attempted and resulted in *Ok* or *Failed*. The operations can be started with the following buttons:

- **Save Configuration**: Request the device to store the current configuration.
- **Download Configuration File**: Download the created configuration file.
- **Upload Configuration File**: Upload the local configuration file to the device.
- **Select Configuration File**: Load the configuration file as the active configuration.
- **Restart All Channels**: Restart all the channels to complete the configuration switch and set the device as active.

### General

This page displays general information about the device.

### Alarms

On this page, the **Current Alarms table** lists all the active alarms of the device.

### Traps

On this page, you can edit the trap destination and settings in the **Trap Receivers table**. The received traps can be viewed and cleared in the **Trap Status Info table**.

### SNMP Pages

The following pages contain tables with additional settings and information about the streams processed by the device:

- **Network Settings**: Network-related parameters as well as **Virtual Interfaces** and **Transport Streams** tables (available via page buttons).
- **Service**: **Services** and **VBI Services** table.
- **Transport**: **FEC Info** table and transport-related parameters.
- **DVB**: DVB-related parameters and **TOT Descriptor** table (available via page button).
- **Input Configuration**: **Input Mpts Status Info** table and **Input Internal Source Info** table.
- **Audio**: Audio test tone parameters as well as **Audio Info** and **Proxy Audio Info** tables.
- **Video**: **Video AVC Info** and **Input Tuner Info** tables.
- **Output**: **Stat Mux Info** table.
- **Ancillary Data**: **Anc Data Info** table.

### Web Interface

This page displays the web interface of the device. However, note that for this the client must be in the same network as the device.
