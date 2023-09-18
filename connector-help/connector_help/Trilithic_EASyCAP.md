---
uid: Connector_help_Trilithic_EASyCAP
---

# Trilithic EASyCAP

This connector can be used to display and configure information of the Trilithic EasyCap device. It also allows alarm monitoring of this device.

## About

This connector uses SNMP to communicate with the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 01.06                       |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains basic information about the device, including the **Product Type**, **Product Serial Number**, **Status Time Up** and **Number of Outputs**.

The page contains the following page buttons:

- **Version**: Displays additional information about the hardware and software.
- **License**: Displays additional information about the licenses.

### Playback

On this page, you can monitor the information related to the playback of the EAS messages and events.

### EAS Sources

This page contains the **Status EAS Source Table**, which displays status information for the configured EAS sources.

### CAP Sources

This page contains the **Status CAP Source Table**, which displays status information for the configured CAP sources.

### Traps

On this page, the **Trap Table** displays information on all the alarms for which a trap was received from the device. There are 15 different possible OIDs, such as *alarmCapConnectionDown (*reports if the connection to a CAP feed is lost), *alarmStartup* and *alarmSystemWarning*.

The rows in this table can be limited by age and by total number of rows, so that the table does not keep growing indefinitely.

### Web Page

This page provides access to the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
