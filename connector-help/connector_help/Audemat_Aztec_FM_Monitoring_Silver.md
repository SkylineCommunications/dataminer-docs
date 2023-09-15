---
uid: Connector_help_Audemat_Aztec_FM_Monitoring_Silver
---

# Audemat Aztec FM Monitoring Silver

The **Audemat Aztec FM Monitoring Silver** connector can be used to display and configure information regarding the related device.

## About

This protocol can be used to monitor and control the Audemat Aztec FM Monitoring Silver device. An SNMP connection is used in order to successfully retrieve and configure the information of the device.

### Version Info

| **Range** | **Description**                                                                                                                                                                     | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                                                                                                                     | No                  | Yes                     |
| 2.0.0.x          | New firmware based on 1.0.0.x                                                                                                                                                       | No                  | Yes                     |
| 3.0.0.x          | Connector rebuilt based on Audemat Aztec GoldenEagle FM v2.1.0.4. UI totally rebuilt. Support for all previous firmware versions. Added HTTP connection in order to create Tuner page. | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**           |
|------------------|---------------------------------------|
| 1.0.0.x          | N/A                                   |
| 2.0.0.x          | 2.5.1                                 |
| 3.0.0.x          | Support for all versions up to 2.5.1. |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP Address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

## Usage

### General Page

This page displays general parameters of the **Audemat Aztec FM Monitoring Silver** device, such as the **System Name**, **Software Version** and **Serial Number**.

This page also contains the **Channels** table, which displays all configured FM channels.

### Carriers Page

This page contains a tree view with all available channels and their measured values.

The page also contains a page button that displays the raw data used to build the tree view.

### Alarms Page

This page contains a tree view with all available channels and their alarm values.

The page also contains a page button that displays the raw data used to build the tree view.

### Tuner Page

This page shows the current **Tuner Status**. It also allows you to **Start** and **Stop Streams**.

### Web Interface Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
