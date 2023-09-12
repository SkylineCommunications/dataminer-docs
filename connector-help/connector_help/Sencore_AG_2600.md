---
uid: Connector_help_Sencore_AG_2600
---

# Sencore AG 2600

The AG 2600 is an Integrated Receiver/Decoder (IRD) card used as a turnaround product capable of receiving a transport stream from ASI, IP and DVB-S/S2 interfaces and converting it to ASI and/or IP output. It can also descramble BISS and DVB-CI scrambling.

This driver allows you to monitor the status and configuration of the AG 2600 module. It retrieves device status information and sets configuration data using SNMP.

## About

### Version Info

| **Range**            | **Key Features**                               | **Based on** | **System Impact** |
|----------------------|------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                               | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Extended naming implemented on Services table. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.2.1                  |
| 1.0.1.x   | 3.2.1                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Creation

#### SNMP connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default value: *public*).
- **Set community string**: The community string used when setting values on the device (default value: *private*).

## How to use

The element consists of the data pages detailed below.

### General

Contains general information such as the system uptime and the contact person for this system.

### Inputs

Contains information about the different interfaces from which the AG 2600 device can receive a transport stream. The active input source that is currently being used and the other available input sources are displayed.

Several page buttons are available, which display status information and settings: **MPEG/IP Inputs**, **DVB-S2** and **ASI**.

### Conditional Access

Contains information about the Condition Access Module (CAM) slot and the selected services/PIDs to descramble. The **Services** page button displays status information and user-configurable data of the available services.

### PID Filter

Contains the PID filter table, as well as a page button that shows the selected services/PIDs under each PID filter. On the subpage, you can also configure the TS bitrate, Table Processing Mode and the Selection Mode.

### Outputs

Contains information about the different output transport streams. Two page buttons are available that show additional status information and settings for MPEG/IP and MPE (Multi-Protocol Encapsulation).

### Admin

Contains general settings. More specific settings and configuration information are available via page buttons:

- **MPEG/IP Network Configuration**: Contains Default Gateway, ICMP Response and TCP/IP settings for the MPEG/IP ports.
- **Unit Network**: Contains port configuration settings.
- **Profiles**: Allows you to create, rename and delete profiles. All the created and saved profiles are also displayed on this subpage.
- **Update Unit**: Allows you to perform updates to the AG 2600 unit. The update status is also shown.
- **License Information**: Displays all the available licenses and their status.
- **Date/Time**: Contains date- and time-related information.
- **SNMP**: Contains the SNMP community strings and lists the trap managers that receive SNMP traps from the AG 2600.
- **Log Receiver**: The AG 2600 can be configured to send error and event logs formatted in the Log Receiver protocol to a remote user. Information of the remote user (server) is shown on this subpage.
- **In-Band Control**: The In-Band Control is used to change settings and receive updates from data within a PID in the incoming TS, as injected by the Sencore CMD 4000 In-band Control Server. The In-Band Control status and configuration information are shown on this subpage.

### Event Logs

Displays all the events and alarms that have affected the unit. You can clear the logs manually by setting **Event Log Clear** to *Clear*. Two page buttons are available:

- **Events Configuration**: Allows you to configure the events reported by the AG 2600.
- **Conditions Configuration**: Allows you to configure the alarms reported by the AG 2600.

### Alarms

Displays all the **active alarms** currently affecting the unit.

### Environment

Contains sensor, fan, temperature, and power supply information.

### About

Displays the hardware model and components, the related software versions, and the currently installed licenses.

### Web Interface

Displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
