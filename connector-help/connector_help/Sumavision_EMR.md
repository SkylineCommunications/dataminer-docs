---
uid: Connector_help_Sumavision_EMR
---

# Sumavision EMR

With this connector, you can monitor **Sumavision Enhanced Multimedia Router** devices with SNMP.

## About

| **Range** | **Key Features**  | **Based on** | **System Impact** |
|-----------|-------------------|--------------|-------------------|
| 1.0.0.x   | Initial version   | \-           | \-                |
| 1.1.0.x   | Reviewed version. | 1.0.0.5      |                   |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |
| 1.1.0.x   | V3.0.4.39RC2           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
|-----------|---------------------|-------------------------|-----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| 1.1.0.x   | No                  | Yes                     | \-                    | [Sumavision EMR - Sumavision C562](/Driver%20Help/Sumavision%20EMR%20-%20Sumavision%20C562.aspx) [Sumavision EMR - Sumavision C355](/Driver%20Help/Sumavision%20EMR%20-%20Sumavision%20C355.aspx) [Sumavision EMR - Sumavision C544](/Driver%20Help/Sumavision%20EMR%20-%20Sumavision%20C544.aspx) [Sumavision EMR - Sumavision C545](/Driver%20Help/Sumavision%20EMR%20-%20Sumavision%20C545.aspx) [Sumavision EMR - Sumavision C451E](/Driver%20Help/Sumavision%20EMR%20-%20Sumavision%20C451E.aspx) [Sumavision EMR - Sumavision C150A](xref:Connector_help_Sumavision_EMR_-_Sumavision_C150A) |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses an SNMP connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## How to Use

### General Page

This page displays information about the router:

- Hardware version
- FPGA version
- Software version
- IP configuration

### Message Page

This page displays a table with alarm messages containing:

- State
- Source
- Text
- Type
- Level

### GBE Card Page

This page displays a table with information about C451E cards:

- Software version
- Hardware version
- FPGA version

### General Page (C150A DVE)

This page displays a table with information about C150A cards:

- Software version
- Hardware version
- FPGA version

### Port 1 Page (C150A DVE)

This page contains audio and video values associated with port 1 of the card.

### Port 2 Page (C150A DVE)

This page contains audio and video values associated with port 2 of the card.

### GBE Network Page (C451E DVE)

This page contains tables about the network interfaces of the card:

- Main Network Table
- Backup Network Table

### GBE Port Page (C451E DVE)

This page contains tables about the network ports of the card:

- Network Backup Input Port
- Input Port
- Output Port
- Network Backup Output Port
