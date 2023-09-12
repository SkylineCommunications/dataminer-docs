---
uid: Connector_help_Cisco_ASA_5540
---

# Cisco ASA 5540

This driver can be used to monitor **Cisco ASA 5540** firewall devices via SNMP. The bitrate parameters are calculated from the octet counters. All other data is polled using SNMP.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

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

The **General** page displays general information such as the device name, location, uptime, etc. Via page buttons, you can access entity, interfaces, SNMP and Ethernet information.

The **Firewall** page displays statistics related to the firewall functionality of the device, while the **Remote Access** page displays remote access information.

The **Crypto Accelerators** page displays information about the cryptographic accelerator modules and the **IPsec** page displays information about IPsec phase 1 and 2.

The **Memory Pool** and **CPU** pages display a table showing the memory usage and a table showing the usage of all CPU cores, respectively.

On the **Physical Sensors** page, you can find the Physical Sensor Table and the Sensor Ext Threshold Table.
