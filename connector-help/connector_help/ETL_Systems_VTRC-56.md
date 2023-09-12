---
uid: Connector_help_ETL_Systems_VTRC-56
---

# ETL Systems VTRC-56

This connector is used to monitor a ETL Systems VTRC-56 device. The VTRC-56 is a combining matrix: multiple inputs can be connected to a single output.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[obsolete\] | Initial version  | \-           | \-                |
| 1.0.1.x \[SLC Main\] | DCF integration  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.2                    |
| 1.0.1.x   | 1.2                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. Default value: *public*.
- **Set community string**: The community string used when setting values on the device. Default value: *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The matrix is displayed on the **Matrix View** page. More data about the input and output signals is available on the **Inputs** and **Outputs** pages.
