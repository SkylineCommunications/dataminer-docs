---
uid: Connector_help_Grass_Valley_IQLAM00
---

# Grass Valley IQLAM00

The **Grass Valley IQLAM00** provides a fast and efficient way to monitor channel branding, by detecting an on-air logo and comparing it with a stored logo signature file.

Multiple logo files can be stored on the module and loaded via triggers from the automation system as required, to provide confidence that the channel branding is correct.

This connector can be used to control and monitor the Grass Valley IQLAM00 via **SNMP**.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Slot number of the module in the chassis, e.g. *1.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

### Initialization

No additional configuration is required.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the following data pages:

- **General**: Displays the system information parameters, such as the **Description**, **Location** and **Up Time** of the device.
- **Logo Match**: Displays information about the logo match parameters, such as **Match Level**, **Signature File** and **Match Status**.
- **Configurations**: Allows you to configure/customize the logo match, with parameters such as the **Fail Level**, **Duration**, **Mode Selection** and **Match State**.
