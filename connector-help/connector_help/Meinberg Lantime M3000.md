---
uid: Connector_help_Meinberg_Lantime_M3000
---

# Meinberg Lantime M3000

This is a DataMiner connector for the Meinberg Lantime M3000, a time and frequency synchronization platform.

The connector uses an SNMP connection to monitor and configure the Meinberg Lantime M3000.

## About

### Version Info

| **Range**            | **Key Features**                                                          | **Based on** | **System Impact** |
|----------------------|---------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version.                                                          | \-           | \-                |
| 1.0.1.x              | DVE name change, firmware version compatibility update, and port editing. | 1.0.0.5      | \-                |

### Product Info

| **Range** | **Supported Firmware**                                                                                                                               |
|-----------|------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | 2.9.2.r1.588 7.00.001 - 7.00.007 (starting from 7.00.005, there is a new REST API available, which is used to retrieve some PTP parameters)          |
| 1.0.1.x   | 2.9.2.r1.588 7.00.001 - 7.00.007 (starting from 7.00.005, there is a new REST API available, which is used to retrieve some PTP parameters) 7.02.004 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**               |
|-----------|---------------------|-------------------------|-----------------------|---------------------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | Meinberg Lantime M3000 - PTPv2 Module |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | Meinberg Lantime M3000 - PTPv2 Module |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

### Initialization

The **Web Interface** login credentials on the **Security** page need to be filled in to allow the **Sync Monitoring** data to be retrieved.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element using this connector consists of the data pages detailed below.

### General

This page allows you to monitor and configure basic information about the device, e.g. **System Description**, **Firmware Version**.

It can also be used to request the execution of commands to the time server.

The page also contains page buttons to the following subpages:

- **System Hardware:** Lists all power supplies and system fans.
- **Reference Clocks:** Lists all reference clocks and their configuration.

### Network

This page allows you to monitor all interfaces and their metrics, e.g. **Bit Rate**, **Maximum Transmission Unit**.

It also contains page buttons to the following subpages:

- **Device Interfaces**: Lists all the metrics of each interface.
- **Ethernet**: Allows you to configure general Ethernet parameters.
- **Physical Interfaces**: Allows you to configure physical options for each Ethernet interface.
- **VLAN Interfaces**: Allows you to configure VLAN options for each Ethernet interface.
- **Miscellaneous Interfaces**: Allows you to configure miscellaneous options for each Ethernet interface.
- **IP Interfaces**: Allows you to configure IP options for each Ethernet interface.
- **Services Interfaces**: Allows you to enable services for each Ethernet interface.
- **Cluster Interfaces**: Allows you to configure cluster options for each Ethernet interface.

### Notification

This page allows you to configure notification settings for the device, e.g. **Email notifications**, **External Syslog Server**.

### Security

This page allows you to configure basic security settings for the device, e.g. **Root Login**, **Network Discovery**.

### SNMP

This page allows you to configure SNMP settings for the device, e.g. **SNMP Contact**, **SNMP Retries**.

It also contains page buttons to the following subpages:

- **Trap Receiver:** Allows you to configure each trap receiver.
- **Trap Configuration:** Allows you to enable signaling information for specific events, e.g. **Antenna Faulty**, **Fan Failure**.
  Multiple signaling outputs can be configured, e.g. E-mail, SNMP, VP100. A comma-separated string stating the signaling outputs is to be set for each event.

### NTP

This page allows you to monitor and configure NTP information regarding the device, e.g. **Trust Time**, **Client Counter Duration**. It displays statistics regarding the client counter of the device.

It also contains page buttons to the following subpages:

- **External NTP**: Allows you to configure each NTP server.
- **Broadcast Settings**: Lists all broadcast servers.
- **Routing**: Allows you to configure the Multicast and Manycast settings.

### PTP

This page allows you to monitor PTP parameters for each PTPv2 module, e.g. **PTP seconds**, **Delay Mechanism**. The PTP table allows you to **remove DVEs** for modules that have been deleted. An "Auto-remove DVEs" option is also available for the automatic removal of DVEs.

The page also contains page buttons to the following subpages:

- **Network Configuration**: Allows the network configuration of each PTPv2 module.
- **Module Configuration**: Allows you to configure PTP-specific variables for each PTPv2 module.

### Sync Monitoring

This page allows you to monitor the status nodes and their configuration, e.g. **Location**, **Offset Limit**.

However, for this, the **Web Interface** login credentials on the **Security page** must be filled in.

Note that the Sync Monitoring Table is only displayed if at least **firmware version 7.xx** is used.

## DataMiner Connectivity Framework

The **1.0.0.x** range of the Meinberg Lantime M3000 connector supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

Connectivity for all exported connectors is managed by the parent connector Meinberg Lantime M3000. Each row in the **PTP** table (PTP page) establishes a physical dynamic interface.
