---
uid: Connector_help_2WCOM_IP-8e
---

# 2WCOM IP-8e

The 2WCOM IP-8e is a point-to-point or point-to-multipoint audio encoder using IP-based audio network technologies for real-time streaming.

## About

### Version Info

| **Range**            | **Key Features**                                                                        | **Based on** | **System Impact**                                                                                                               |
|----------------------|-----------------------------------------------------------------------------------------|--------------|---------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x \[SLC Main\] | Initial version.                                                                        | \-           | \-                                                                                                                              |
| 1.0.1.x              | \- DataMiner Connectivity Framework (DCF) integration added. - Redundant polling added. | 1.0.0.1      | \- DCF can cause an additional load on the system. - Existing elements need to be reconfigured to use the redundant connection. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.11.12                |
| 1.0.1.x   | 2.11.12                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### SNM Connection - Redundancy (range 1.0.1.x or higher)

From range 1.0.1.x onwards, a redundant SNMP connection needs to be configured. It requires the same configuration as the main SNMP connection.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This connector uses SNMP parameters to access and modify the device parameters.

The connector uses a UI structure similar to the web interface of the device. You can also control the parameters in a similar way.

To add new multiplexers, you will need to use the web interface of the device (available on a page of the element). These will then be accessible through the parameters of the connector. Multiplexer serves and payloads can also not be added or removed directly with the parameters of the connector.

The connector does not provide access to sensitive information such as the User, Storage, or Log pages of the web interface.
