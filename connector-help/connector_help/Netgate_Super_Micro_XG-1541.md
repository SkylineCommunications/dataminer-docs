---
uid: Connector_help_Netgate_Super_Micro_XG-1541
---

# Netgate Super Micro XG-1541

The Netgate XG-1541 security gateway uses pfSenser Plus software and features an 8 Core Intelr Xeonr D-1541 processor with AES-NI to support a high level of I/O throughput and optimal performance per watt. This appliance can be configured as a firewall, LAN or WAN router, VPN appliance, DHCP server, DNS server, and IDS/IPS with optional packages.

## About

### Version Info

| **Range**            | **Key Features**                               | **Based on** | **System Impact** |
|----------------------|------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version - Based on Linux Platform SNMP | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 21.02.2-RELEASE        |

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
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device (not used by default).

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

### General

This page displays general information, such as:

- **Device info**
- **Total Processor Load**: Only available if **Poll Task Manager** is enabled (on the Task Manager page).
- **Memory usage**
- etc.

The page contains several page buttons:

- **Load:** Displays load information.
- **Raw CPU:** Displays detailed information on CPU usage.
- **Processor**: Displays processor load information.

### Firewall

This page displays information about the firewall, such as the **Status**, **Runtime**, etc.

The page contains several subpages:

- **Timeouts:** Displays information about PF Timeouts.
- **PF Interfaces:** Displays the PF Interface table.
- **Rules:** Displays the Rules table.

### Task Manager

On this page, you can enable **Poll Task Manager** in order to retrieve all the data from the **Task Manager Table**. Click **Auto Clear Task Manager** to automatically clear inactive processes.

### Network Info

This page displays all interfaces and data rates.

The page contains several subpages:

- The **Interface Monitor Config** page:

- This page displays the **status** of all interfaces.
  - In the **Monitor** column, you can enable or disable rows to configure which rows are shown in the **Interfaces Tables** on the **Network Info** page.
  - Four buttons at the top of the page allow you to **Enable All** interfaces, **Disable All** interfaces, **Enable Operational Up** and **Refresh** the table.

- **Ping:** Allows you to configure the ping definitions.

- **Routes:** Displays the Routes Table.

- **ARP:** Displays the ARP Table.

### Memory Info

This page displays memory information in the **Storage Table**, if **Storage Table Polling** is enabled.

The following page buttons are available:

- **Storage Availability:** Displays the Storage Availability Table.
- **More Memory**: Displays additional memory information.
- **Disk IO**: Displays the Disk IO Table.

### Disks Info

This page displays disk info, if **Linux Monitored Disks Polling** is enabled.

One page button is available, **Mount Availability**, which shows whether the mount is available (*present/not present*).

### Software Info

This page displays a list of all installed software.
