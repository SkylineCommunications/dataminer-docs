---
uid: Connector_help_Cross_Technologies_2082-14x
---

# Cross Technologies 2082-14x

This SNMP connector provides an overview of the status of the available amplifiers used by the model 2082-14x series. The connector allows you to manually select the redundancy mode that corresponds with the used model.

## About

### Version Info

| **Range**            | **Key Features**                                             | **Based on** | **System Impact** |
|----------------------|--------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Retrieve amplifier data based on configured redundancy mode. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Rev: 6.00              |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

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

Select the needed redundancy mode on the **Configuration** page. Based on this, either amplifier 1 and 2 (redundancy mode 1:1) will be monitored or amplifier 1, 2 and 3 (redundancy mode 1:2).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

On the **Config** page, configure the **Redundancy Mode** that is used by the connected unit. This will indicate what module type is expected and retrieve the amplifier data, which will then be displayed on the **General** page.

## Notes

