---
uid: Connector_help_Linux_Platform_SSH
---

# Linux Platform SSH

This connector can be used to monitor Linux Platforms with **SSH**.

## About

### Version Info

| **Range**            | **Description**                                                               | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[Obsolete\] | Initial version, continued as 2.0.0.x.                                        | No                  | No                      |
| 1.0.1.x \[Obsolete\] | Added SNMP connection.                                                        | Yes                 | Yes                     |
| 1.0.2.x \[SLC Main\] | Forced SNMPv2.                                                                | No                  | No                      |
| 2.0.0.x              | Continuation of 1.0.0.x.                                                      | No                  | Yes                     |
| 3.0.0.x              | To be used for a port different than 22. Minimum required DMA version: 9.6.0. | Yes                 | Yes                     |

### Product Info

| **Range** | **Supported Firmware**   |
|-----------|--------------------------|
| 1.0.0.x   | Slackware Kernel 3.10.17 |
| 1.0.1.x   | Slackware Kernel 3.10.17 |
| 2.0.0.x   | Slackware Kernel 3.10.17 |
| 3.0.0.x   | Slackware Kernel 3.10.17 |

## Installation and creation

### Creation

Starting from range **1.0.1.x**, an SNMP connection is used, which means that when you update the connector, you will have to create a new element to configure both connections as follows:

**SNMP CONNECTION**:

Only applicable from version **1.0.1.x** onwards.

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string in order to read from the device. The default value is *public*.
- **Set community string:** The community string in order to set to the device. The default value is *private*.

**SERIAL CONNECTION**:

- **IP address/host:** The polling IP of the Linux Platform.
- **IP port:** The IP port of the device, by default *22* (SSH).
- **Local IP port:** The local IP port, by default *49155*.
- **Timeout:** Command timeout value, by default *10000* ms.

### Configuration SSH

On the **General page**, click **Security** to enter the login and password. Then click the **Login** button to start the communication.

## Usage

### General Page

This page displays general information related to the Linux Platform, such as device info and CPU usage.

The page contains several page buttons:

- **Details CPU Info**: Opens a page with detailed information on the **CPU usage**.
- **Manual Command**: Allows you to manually send commands to the device and check the results.
- **Ping:** Allows you to configure the ping definitions.
- **Security**: Opens a page where you can configure security. You can also set the terminal width by first setting the **Overwrite Terminal Width** parameter to *enable* and then entering the desired value in the **Overwritten Terminal Width** box. The default terminal width is 132, so when you disable Overwrite Terminal Width, the width is automatically set back to 132. The minimum width that can be set is 80 and the maximum width is 2000.

### File Reader Page

A list of the files located in the **Storage Location** directory is displayed in the **Local Data Overview** table. Each file is read, and its content is added in the table.

### Network Details Page

If network details need to be monitored, click the **Add** button on this page to add these network details.

Click the **UDP Statistics** page button to view UDP information, such as **UDP Datagrams Rx**, **UDP Errors Rx** and **UDP Datagrams Tx**.

Click the **Interfaces** page button to view interface information. Click the **Load** button to refresh the data.

Other statistics can also be found via the relevant page buttons:

- **TCP Statistics**
- **ICMP Statistics**
- **IP Statistics**
- **IPExt Statistics**
- **TCPExt Statistics**

### Memory Page

This page displays memory information, such as:

- **Kernel threads info**
- **Available swap and memory**
- **Page reclaims**
- **Minor faults**
- **Interrupts**

### Process List Page

This page displays a list of all the processes running on the Linux Platform. With the **Clean Up** button, you can remove processes that no longer exist.

It is possible to enable process validation on the **Process List**. This is configured via the **Process Validation** page button. Validation can only be done on existing processes.

You can select a single process via the **Process to Validate** drop-down box. The result will be available in the **Process Validation Status** parameter. If you want to validate multiple processes, you can add multiple processes by right-clicking in the **Process Validation** table and selecting **Add Process** in the context menu.

The **Process Rules Table** contains the processes that need to be monitored, taking into account a rule, user, status, and process name (or a prefix).

### Disks Page

This page displays disk information:

- **Disk Usage**
- **Disk Md IO**
- **Disk Inodes**

### HP/Dell Page

From version **1.0.1.x** onwards, if the Linux platform is installed on an HP/Dell platform, you can enable **Poll HP Parameters** or **Poll Dell Parameters** to receive specific HP or Dell data.

The following page buttons allow access to additional HP or Dell info:

- **Fan**
- **Power Supply**
- **Temperature**
- **Memory**
- **CPU**
- **Disk**

## Notes

The external data can also be linked to a **Sun Solaris** or **Sun File Reader** connector.

## DataMiner Connectivity Framework

This connector supports the usage of DCF.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party protocols (for instance a manager).

### Interfaces

#### Dynamic Interfaces

Physical dynamic interfaces:

- The physical dynamic interface is created for the parameter **Network Interface Table** and its interface is **inout**.
