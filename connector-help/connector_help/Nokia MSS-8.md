---
uid: Connector_help_Nokia_MSS-8
---

# Nokia MSS-8

The Nokia Wavence **Microwave Service Switch** provides advanced Carrier Ethernet networking, aggregation, and demarcation functions.

## About

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                                                                                                                                           |
|-----------|---------------------|-------------------------|-----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \- [Nokia MSS-8 - CorEvo-1G](/Driver%20Help/Nokia%20MSS-8%20-%20CorEvo-1G.aspx) - [Nokia MSS-8 - EASv2](/Driver%20Help/Nokia%20MSS-8%20-%20EASv2.aspx) - [Nokia MSS-8 - MPT-HLS](xref:Connector_help_Nokia_MSS-8_-_MPT-HLS) |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## How to use

The **General page** contains generic system information as well as the Equipment overview table. To create dynamic virtual elements for the CorEvo, EAS or MPT-HLS cards, set the **DVE** parameter in the **Equipment table** to *Export*.
Note: for a full list of the possible exported connectors, check the System Info table above.

The **Active Alarms** page contains a list of all open alarms on the system.

All Ethernet-related information and statistics can be found on the **Ethernet** **Interfaces**, **Ethernet** **Statistics**, and **Networking** **Configuration** pages.

The redundancy settings for the CorEvo cards can be found on the **Protection** **Settings** and **Protection** **Maintenance** pages.

All radio information and measurements are displayed on the **Radio** **Interfaces**, **Radio** **Analog** **Measurements**, and **Radio** **Maintenance** pages.
