---
uid: Connector_help_Media_Excel_Hero_Management_System
---

# Media Excel Hero Management System

With this connector, you can monitor the Hero Management System and view events on and information about the available devices and channels. It is also possible to start and stop any channel.

## About

This connector uses HTTP (through a SOAP web service) and SNMP in order to monitor a Hero Management System. SOAP calls are used to retrieve the groups, devices, channels and events from the system, and SNMP is used to retrieve other system-specific information.

The Hero Management System is a centralized network management solution, designed to cooperate with all Media Excel HERO products. It allows remote management of transcoding devices.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 3.26.139.58                 |

## Installation and configuration

### Creation

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The IP port of the destination, e.g. *80*.

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General Page

This page displays general information regarding the Hero Management System:

- **System information**
- **CPU usage and idle time**
- **Total number of devices**

### Network Info

This page displays all interfaces and their:

- **Operational Status**
- **Input Octet Count/Discard Count & Error Count**
- **Output Octet Count/Discard Count & Error Count**

### Events

This page displays a log of all the events that occurred in the system along with a Time/Date Stamp and Severity Level.

### Groups

This page shows the list of groups for the managed devices.

### Devices

This page shows a table with the devices that are currently being managed by the Hero Management System, as well as some information pertaining to each device.

### Channels

This page displays information about the channels of all the devices currently being managed. It is also possible to start and stop each channel here.

### Web Interface

This page displays the web interface of the device, from where it is possible to perform other actions. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
