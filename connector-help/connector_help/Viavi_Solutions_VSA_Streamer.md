---
uid: Connector_help_Viavi_Solutions_VSA_Streamer
---

# Viavi Solutions VSA Streamer

This connector monitors the activity of the Viavi Solutions VSA Streamer, a transport stream monitor.

The Video Service Assurance (VSA) Streaming probe was developed by modifying the existing JDSU MVP and DTS video analytics to operate on a commercially available off-the-shelf server using a commercially available off-the-shelf network interface card.

## About

This connector polls data from the device using an HTTP connection and allows the user to retrieve WMI data from the server.

The connector supports one board per element and receives SNMP traps from the device in order to update the Alarms status.

### Version Info

| **Range** | **Description**       | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------|---------------------|-------------------------|
| 1.0.0.x          | One element per board | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.2.0.14                    |

## Installation and configuration

### Creation

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the destination.
- **Bus address**: The ID of the Board

#### SNMP Traps connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the destination.
- **Get community string**: The community string used when reading values from the device. (default: public)
- **Set community string**: The community string used when setting values on the device. (default: private)

## Usage

### General

This page displays the device information, including the **Name**, **Type**, **Software Version** and **API** of the device. It also displays information about the connected board.

In the **File Directory** parameter, you can specify the path of the configuration files. To be able to export the configuration files from the boards, this parameter must be filled in.

On this page, you can download the XML configuration file of the board and upload an XML file with a new configuration, using the **Download Config** and **Upload Config** buttons.

The download and upload files will be stored in the **Directory Path** defined in the main element.

If any information related to the path or the config file is missing, a message will be displayed by the **Status** parameters. If any error occurs during the operation, the **Status** parameters will also display a error message.

The **Communication** parameter displays the current state of communication with the device.

### Overview

This page displays a **tree control** with all the data from the board, the **Transport Streams** configured on the device and the associated **Programs** and **PIDs**.

Different tabs display information like the alarm states, the stats and the alarm/error counts.

### Streams

This page displays information about the transport streams. The page contains several tables:

- The **Streams** table displays a list of the transport streams and the associated alarms.
- The **Streams Alarm/Error Count** table displays data about the number of alarms/errors generated so far.
- The **Streams Stats** table displays statistical data related to the transport streams.

### Programs

This page displays information about the programs. The page contains several tables:

- The **Programs** table displays a list of the programs and the associated alarms.
- The **Programs Alarm/Error Count** table displays data about the number of alarms/errors generated so far.
- The **Programs Stats** and **Programs PTS Stats** tables contain statistical data related to the programs.

### PIDs

This page displays information about the PIDs. The page contains several tables:

- The **PIDs** table displays a list of the PIDs and the associated alarms.
- The **PIDs Alarm/Error Count** table displays data about the number of alarms/errors generated so far.
- The **PID Stats** and **PID PTS Stats** tables contain statistical data related to the PIDs.

### Traps

This page contains a table with the latest received traps. It is possible to define the **Maximum Number of Traps** in the table and to **Remove All** traps with a button.

The **Notifications** page button lists the notifications available on the device.

### Alarm Presets

On this page, the **Alarm Presets** table displays a list of all presets. Via the context menu of the table, you can **Add** and **Delete Presets** manually.

It is also possible to import or export a xml file with the list of alarm presets and the presets assignments on the tables . The **Import/Export Status** displays the state of this operation. The list of xml files to be imported is in the **Configurations** folder. The exported xml file will be stored in the generic DataMiner Documents folder, within a subfolder with the name **Configurations**.

The **Refresh** button will refresh the xml file list and the alarm presets displayed in the table columns.

### Disk Info

This page displays the **Disk Information** from the server.

The **Performance/Disk Polling** toggle button can be used to enable or disable this feature.

### Performance

This page displays the **Performance** data of the server.

The page contains one page button, **Security**, which opens a subpage where you can enter the **credentials** of the server.

### Task Manager

This page displays information about the current processes running on the server.
