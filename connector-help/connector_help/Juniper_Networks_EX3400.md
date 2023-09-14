---
uid: Connector_help_Juniper_Networks_EX3400
---

# Juniper Networks EX3400

The Juniper Networks EX4300 connector is an SNMP-based connector used to monitor and configure the Juniper Networks EX4300.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

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

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).
- **Port number**: The port of the connected device, by default 161.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product. Note that this interface should be enabled first on the device.

## How to use

Several important settings can be found on the **Configuration** page, which allow you to enable/disable the polling of several tables. Those tables, located on other pages of the connector, contain different functional information about the device.

There is also an import/export file feature available on the **Operating States** page. **Import** makes it possible to set described data from the file into the desired table. Via **export** you can create a file that contains all the table data. Before you can execute an **import** or **export**, you first need to fill in the **file name** and the **file path**.

On the **Virtual Chassis** page, beneath **Chassis**, you can find the **software version** of the device, which can be useful to know in some cases.
