---
uid: Connector_help_ADVA_Optical_Networking_OSA_5422
---

# ADVA Optical Networking OSA 5422

The ADVA Optical Networking OSA 5422 is an SNMP-based synchronization device. The device can be used as a **PTP grandmaster clock** or an **NTP server**. It also supports **GNSS receiver** capabilities and 5G.

## About

### Version Info

| **Range**            | **Key Features**                                                    | **Based on** | **System Impact**                                                                                |
|----------------------|---------------------------------------------------------------------|--------------|--------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version.                                                    | \-           | \-                                                                                               |
| 1.0.1.x \[SLC Main\] | Possibility added to enable/disable polling of specific parameters. | 1.0.0.1      | Discrete values have changed (remote gets/sets will no longer work on the old displayed values). |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. Default port: *161*.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The data pages of the element are similar to the pages in the tree view of the web interface:

- **General**: Displays general device parameters.

- On the subpage "**Enable Polling**" you can choose which parameters and tables are polled from the device.

- **System**: Contains information related to the system and file services.

- **Administration**: Contains parameters related to remote authentication, database and users.

- **Communication**: Contains parameters and tables related to IP and IPv6

- **Port**: Contains parameters and tables related to the network element ports

- **PTP**: Contains all parameters related to PTP.

- On the **Alarm Severity Assignment** and **NE Alarm** pages, buttons are available that can be used to trigger the polling of alarm information.
