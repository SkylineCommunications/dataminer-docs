---
uid: Connector_help_Miranda_Kaleido_X
---

# Miranda Kaleido X

The Kaleido X connector displays information related to the Kaleido X device. In addition, this connector also allows you to retrieve and set specific parameters using RCP (Gateway) commands. The connector uses two protocols to communicate with the Kaleido device: SNMP is used to retrieve information concerning the device, and TCP is used to execute RCP commands.

## About

### Version Info

| **Range**            | **Key Features**               | **Based on** | **System Impact** |
|----------------------|--------------------------------|--------------|-------------------|
| 2.0.0.x \[Obsolete\] | Initial version                | \-           | \-                |
| 2.0.1.x              | Customer-specific branch       | \-           | \-                |
| 2.0.2.x \[SLC Main\] | Change to Discrete Audio Table | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 2.0.0.x   | \-                     |
| 2.0.1.x   | \-                     |
| 2.0.2.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.2.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

#### Serial connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **Type of port:** TCP/IP.
- **IP address/host**: The polling IP or URL of the destination, e.g. *10145.1.12*.
- **IP port**: The port of the destination, e.g. *13000*.
- **Timeout of a single command:***2500 ms* (minimum).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### General

This page contains general information about the device, such as the frame model, layouts defined in the Kaleido X device, software version, number of inputs, slot count, card count and frame, fan and power supply status.

In a drop-down list, the parameter **Layout List** displays all the layouts defined in the Kaleido X device. Each layout displayed in the list has the following format: *RoomName/LayoutName.kg2*. When you have selected the desired layout, the connector will send an RCP command to set the selected layout in the Kaleido X device.

In addition, the button **Set Channel** can be used to set the channel of the Kaleido X device according to the values set in **Channel Name** and **Monitor name**. The parameter **Channel Name** has a drop-down list with all the available channels obtained from the Video table. Note that the RCP command will not be sent to the device unless at least both parameters (Channel Name and Monitor Name) are filled in.

The **On-Air Services Scheduler** table can be accessed via a page button. It allows you to configure different time slots when each service is or is not on air.

### Card List

This page displays a table that contains an entry for every slot in the frame.

### Video

This page displays a table with all the video inputs of the frame. This table contains an extra column, **Video Channel Text**, that is used to retrieve and set the UMD channel text for each channel on the Kaleido X device using RCP commands. The button displayed at the top of the page, **Set all UMDs**, will set the UMD channel text according to the values defined in this column.

From version **2.0.1.11** of the connector onwards, the **Video Channel Text** column is filled in with the data from the **Friendly Name** column of the **Virtual Alarm Table**.

### Embedded Audio

The table on this page displays the embedded audio of all frame video.

### Discrete Audio

The table on this page displays all discrete audio available on the device.

From version **2.0.2.1** of the connector onwards, the display key of the table is configurable.

### RCP

This page displays the **RCP Command** to send and the **RCP Response**.

### Virtual Alarms (version 2.0.1.11 onwards)

This page displays the **Virtual Alarm Table**, with information about the alarms for each video channel.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
