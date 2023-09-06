---
uid: Connector_help_Fraunhofer_DRM_Content_Server
---

# Fraunhofer DRM Content Server

This connector is able to retrieve and set data on the Fraunhofer content server through SNMP.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact**                        |
|----------------------|------------------|--------------|------------------------------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                                       |
| 1.0.1.1              | New MIB support. | 1.0.0.1      | New primary key within the Status table. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |
| 1.0.1.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device. By default, this is not used.

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

On the **General** page, you can find basic configuration parameters like system time, system version, etc.

The page also includes the very important **Configuration** parameter, which allows you to start or stop the transmission. You can also reboot the content server, and more.

You also can verify the **status** of every existing module, including timestamps, results and messages.

On the **Broadcast Activation** page, you can configure the **Broadcast Configuration ID.** Note that at the moment only sets are possible for this specific parameter.
