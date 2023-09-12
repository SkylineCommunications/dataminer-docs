---
uid: Connector_help_Lawo_Nova73_HD
---

# Lawo Nova73 HD

This driver is used to monitor a Lawo Nova73 HD router. This router supports up to 16 slot-in modules (Ravenna, MADI, SDH/STM-1 and AES3 modules).

No DVEs are created for these modules as they can be polled individually. Currently, a driver is available for the HD Core Ravenna modules. Each installed module requires a corresponding element in DataMiner.

## About

### Version Info

| **Range** | **Key Features**                                                            | **Based on** | **System Impact** |
|-----------|-----------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version. HD Core and Compact Core device compatible since v1.0.0.3. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 5-16-0-0 build 115     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Smart-Serial Main Connection

This driver uses the Ember+ protocol over a smart-serial connection and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device. Required (default value: 9000)

#### Smart-Serial Redundant Connection

In case the main connection fails (timeout event), the driver will automatically switch to an alternate IP connection.

For this connection, the following input is required during element creation:

SMART-SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.

### Initialization

No additional configuration is required. When a new element is created/started, the Ember+ tree will be polled. This can take up to 30 seconds. Progress of this action can be monitored using the Discovered Nodes and Node Discovery parameters. This action is repeated every day in case something changes in this tree.

### Redundancy

Redundancy is not defined in the driver.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

This driver uses the Ember+ protocol to communicate with the device. On startup, the driver will poll the entire Ember+ tree to determine the paths to nodes that need to be accessed. This action can take up to 30 seconds and its progress can be followed using the Discovered Nodes and Node Discovery parameters on the General page. Once this action is complete, polling of the parameters will start. This discovery action is repeated every day, in case the Ember+ tree were to change.
