---
uid: Connector_help_SpacePath_Communications_SPC1100
---

# SpacePath Communications SPC1100

This is an SNMP connector that is used to monitor and configure the SpacePath Communications SPC1100 equipment.

## About

### Version Info

| **Range**           | **Key Features** | **Based on** | **System Impact** |
|---------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SL Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

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

### Initialization

The connector does not require credentials, so setting it up is rather straightforward. To make sure the device can be polled, define the port where the device can be found.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

On the **General** page, you can find general information about the equipment.

On the **Modules**, **BUC Configuration** and **Measurements** pages, you can find some configurable parameters that allows you to control/monitor the SPC1100 equipment.

The **Redundancy** shows which BUC is in online or in standby mode.

The **Alarms** shows all the alarms for the device.
