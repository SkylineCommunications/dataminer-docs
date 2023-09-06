---
uid: Connector_help_Dell_Equallogic
---

# Dell Equallogic

This driver allows you to monitor the **Dell Equallogic** disk array. Information from the disk array is retrieved via **SNMP**. Traps can be retrieved if this is enabled on the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: public).
- **Set community string**: The community string used when setting values on the device (default: private).

### Web Interface

The web interface is only accessible when the client machine has network access to the product

## How to use

The element consists of the data pages detailed below.

### General

This page displays **general information** about the device, like its name, location, etc. Page buttons provide access to additional information about the NTP server, DNS server, SysLog server, SMTP server, RADIUS authentication, emails used for alerts, and admin account.

### Storage

This page displays information related to the **storage group**, i.e. the information of each group, compatibilities, and status.

### Member

This page displays information about the **configuration, health and storage of a member**. It also provides access to subpages with detailed temperature information, FAN details, detailed chassis information, power supply information, RAID information, information about hardware components, and cache statistics.

### Disk

This page displays **disk-related statistics and errors**. A page button provides access to a page with smart info for each disk.

### Controller

This page contains **status information about each controller**. A page button provides access to a page with status information about the backplane.

### IP Address

This page contains information about the **IP address entries and interfaces**. The **IF States** page buttondisplays interface status information, while the **INET Addr Entry** page buttons displays IP-related address information.
