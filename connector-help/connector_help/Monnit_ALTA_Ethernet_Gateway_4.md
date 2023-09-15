---
uid: Connector_help_Monnit_ALTA_Ethernet_Gateway_4
---

# Monnit ALTA Ethernet Gateway 4

The Monnit Ethernet Gateway 4 (EGW4) allows Monnit Wireless Sensors to communicate with iMonnit Online Wireless Sensor Monitoring and with the notification system without needing a PC.

This DataMiner connector retrieves relevant information from the device's sensors and acts as a monitoring platform.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 01.00.07.02            |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

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

The main function of this connector is to extract relevant information from the device's sensors, so that alarms can be generated in DataMiner when necessary. When you configure the alarm template, be careful to take the behavior of the parameters into account.
