---
uid: Connector_help_Promax_RANGERNeo_4
---

# Promax RANGERNeo 4

This connector can be used to monitor and control a Promax Ranger Neo 4 using the SNMP protocol.

The Promax Ranger Neo 4 is a universal analyzer that covers several of the most popular standards (DVB, ISDB-T) as well as formats such as MPEG-2, MPEG-4, etc.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.2.45                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The **General** page displays configuration parameters for the signal that needs to be monitored: Frequency, Polarization, etc.

The **Status** page displays parameters measured from the configured signal: Power, Bandwidth, Symbol Rate, etc.
