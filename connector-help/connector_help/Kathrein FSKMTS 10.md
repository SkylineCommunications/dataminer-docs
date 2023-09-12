---
uid: Connector_help_Kathrein_FSKMTS_10
---

# Kathrein FSKMTS 10

Kathrein FSKMTS 10 is an FSK Management Termination System used to send commands to amplifiers on the network that are only able to receive FSK commands. In order to be able to send FSK commands to the amplifiers, a list of the amplifiers managed by the given HEC must be loaded. This list is also called the "node list". This connector can be used to import the node list into the device and show an overview of the nodes.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.1                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The **General** page of this connector displays information about the modules.

On the **RMTS Information** page, you can configure device settings.

On the **Import Configuration** page, you can manually import a node list and configure the settings for automatically importing the node list from a directory. Importing from both local directories and network locations is supported. When importing from a network location, it is important to specify the Network Username, Network Password, and Network Domain.

The **Nodes** page contains all information about the nodes and can be used to add, edit, or delete nodes. Note that when a node is added, it is possible that the Hardware Type or Alias may not be immediately shown correctly in the table because the device needs a bit of time to process this.
