---
uid: Connector_help_Concurrent_MediaStore_3000
---

# Concurrent MediaStore 3000

This connector monitors the activity of the Concurrent MediaStore 3000 device.

## About

The MediaStore3000 is a multi-purpose storage device that provides over three times the storage capacity and double the bandwidth of earlier generations. It provides flexibility by allowing the user to independently scale storage from ingest, transcoding and streaming.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Rev. 0220              |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created using this connector consists of the following data pages:

- **General**: Displays general information about the device.
- **Connectivity Unit**: Displays the Connectivity Unit Table. On a subpage, you can find the Revision Table.
- **Sensor**: Contains the Sensor Table, which displays the state of the device sensors.
- **Ports**: Contains the Port Table, which displays the state of each of the device ports.
- **Events**: Contains the Events Table, which displays the latest device events.
- **Web Interface**: Displays the web interface of the device.
