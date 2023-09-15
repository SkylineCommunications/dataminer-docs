---
uid: Connector_help_Sittig_DVA
---

# Sittig DVA

The **Sittig DVA** connector is used to monitor the status of the Sittig DVA.

## About

The connector uses **SNMP** to retrieve the **monitoring** data from the Sittig DVA.

The Sittig DVA contains status information for each Sittig device per **location**. This connector is thus very simple, because it is only used for monitoring.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.0                         |

## Installation and configuration

### Creation

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: \[The community string used when reading values from the device (default: *public*).\]
- **Set community string**: \[The community string used when setting values on the device (default: private).\]

## Usage

### General

The **General** page displays some information about the device. The **Summary Status** and **Summary Errors** are also displayed. These parameter indictate the overal status and amount of errors in the system.

### Devices

The **Devices** page contains the **Devices** and the **Locations** table.

The **Devices** table has an overview of each device that is monitored by the Sittig DVA. The key of each entry is built in following format: *\[Location\]:\[Description\]*. For each of the devices, the **general status** and **errors** are being monitored. Some extra status parameters are available for **QS Servers** and **QC Clients**.

The **Locations** table contains an entry for each location with it's **status** and **errors**.

### Web Interface

The **webinterface** can be used to login on the Sittig DVA device. Note that the client machine has to be able to access the device, otherwise it will not be possible to open the web interface.
