---
uid: Connector_help_SEE_Telecom_eAcsys_Tx_Ds
---

# SEE Telecom eAcsys Tx Ds

The SEE Telecom eAcsys Tx DS is a transmitter. This connector allows you to monitor and control this device via SNMP communication. The native web interface of the device is also available through the connector.

## About

### Version Info

| **Range**            | **Key Features**                    | **Based on** | **System Impact** |
|----------------------|-------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                    | \-           | \-                |
| 1.1.0.x \[SLC Main\] | Release version.                    | 1.0.0.x      | \-                |
| 2.1.0.x              | Revised layout, ranges, and timers. | 1.1.0.9      | \-                |
| 3.0.0.x              | Custom version (VOO).               | 1.1.1.8      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |
| 1.1.0.x   | N/A                    |
| 2.1.0.x   | N/A                    |
| 3.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.1.0.x   | No                  | Yes                     | \-                    | \-                      |
| 3.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device (range: *1* - *16*).

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

The element created with this connector consists of the following data pages:

- **General**: Displays general information about the device, such as the Serial Number, Software Version, and Temperature.
- **Optical**: Displays information about the optical functionality of the device, such as the Laser Bias Current, the Measured Laser Output Power, and the Laser Temperature.
- **RF**: Displays information about the RF functionality of the device, such as the RF Power, the Attenuator, RF Overdrive, Adjustment Mode.
