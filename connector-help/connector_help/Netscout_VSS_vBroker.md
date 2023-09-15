---
uid: Connector_help_Netscout_VSS_vBroker
---

# Netscout VSS vBroker

The Netscout VSS vBroker protocol can monitor a vBroker device. The vBroker provides advanced network visibility by accessing, optimizing and delivering traffic from multiple networks to multiple network monitoring and security tools.

## About

This connector can be used to monitor the **Ports status** and the **Module status**. Statistics are available for the **Network Activity**.

- **SNMP** is used to retrieve some **General Info** parameters, **Power Supplies** data and **Network Activity** statistics.
- **HTTP** is used to retrieve information that is available in the **VSS API**.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 3.10.29                     |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: This is not required.

SNMP Settings:

- **Port number**: *161*
- **Get community string**: *public*
- **Set community string**: *private*

#### HTTP CommandAPI connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: *80*
- **Bus address**: *ByPassProxy*

## Usage

### General

This page displays the **System Settings**, the **Network Settings** and the **NTP Configuration**.

There is also a **Security** page button that opens a subpage where the **Username** and **Password** must be filled in to establish HTTP communication.

### Port Status

This page displays the **Ports** table. This table also contains a **Status** parameter.

### Network Activity

This page displays the **Network Activity Statistics** table.

### Module Information

This table displays the **Module Info** table and the **Module Ports** table.

### vStack+

This table displays the **Nodes** table and the **Links** table.

### Filter Library

This table displays the **Monitor Filtering** table, and allows you to add or delete a filter.

### Monitor Settings

This table displays the **Filtering Settings** table, and allows you to add or delete a filter mapping.

### Web interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
