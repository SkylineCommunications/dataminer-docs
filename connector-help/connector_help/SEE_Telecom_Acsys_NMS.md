---
uid: Connector_help_SEE_Telecom_Acsys_NMS
---

# SEE Telecom Acsys NMS

This protocol uses SNMP to monitor the SEE Telecom Acsys 2Rx Us receiver.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                  | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Development version                                                                                                               | \-           | \-                |
| 1.1.0.x \[SLC Main\] | Main version, with two timers: fast timer (every 30 s) for important parameters and slow timer (every hour) for other parameters. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |
| 1.1.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The **General** page of this connector provides a general overview of the device. The **Module Overview** page has a more detailed overview, and allows you to set the number of slots.
