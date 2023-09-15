---
uid: Connector_help_Concurrent_Mediahawk_4500
---

# Concurrent Mediahawk 4500

This connector can be used to monitor **Concurrent Mediahawk 4500** devices via SNMPv2.

## About

This connector is used to monitor **Concurrent Mediahawk 4500** video server devices.

This connector will export different connectors based on the retrieved data. A list can be found in the section 'Exported Connectors'.

### Version Info

| **Range** | **Description**                 | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                 | No                  | No                      |
| 1.1.0.x          | Initial version                 | No                  | No                      |
| 1.1.1.x          | Initial version (connector review) | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**     |
|------------------|---------------------------------|
| 1.0.0.x          | Unknown                         |
| 1.1.0.x          | Unknown                         |
| 1.1.1.x          | CCUR Video Server Version 3.2.5 |

### Exported connectors

| **Exported Connector**            | **Description**                    |
|----------------------------------|------------------------------------|
| Concurrent Mediahawk 4500 - Host | A Concurrent Mediahawk 4500 device |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMPv2) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays information about general parameters.

### Hosts Page

This page displays information about the **Hosts**.

### Video Page

This page displays tables with information about the **Video**, **Video Pumps** and **Video Instance**.

### Resources Page

This page displays tables with information about the **Disks**, **Service Providers**, **Cluster** and **Network Resources**. It also contains several page buttons that provide access to the **Path Table**, **RFS Table**, **Media Server Table**, etc.

### Cache Page

This page displays a table with the **Cache**.

### Elements Page

This page displays tables with information about the **Elements** and the **Content Providers**.

### Streams Page

This page displays tables with information about the **Streams**.

### Sessions Page

This page displays information about the **Session Table** and the **Active Users Table**.

### Content Page

This page displays information about the **Contents**.

### Menu Page

This page displays information about the **Menu Table**.

### Media Page

This page displays a table about the **Media**.

### Service Groups Page

This page displays a table about the **Service Groups**.

### Attachments Page

This page displays a table with information about **Disk Attachments**.

### Disks Page

This page displays a number of tables with information about the **Disk Drives**, **Partitions** and **Paths**. There is also a page button that provides more information about the **Disks**.

### Environmental Status Page

This page displays information about **Temperatures**, **Fan Status** and **Power Supply**. There is also a page button that provides more **Environmental** information.

### Configuration Page

This page displays some configurable parameters for **Streams**, **Sessions**, **Clusters**, **Content**, etc.

### Errors Page

This page displays tables with information about errors in **Application** and **Stream Service Elements**.

### Traps Page

This page contains the settings for **Trap Generation**.

### Web Interface

This page displays the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
