---
uid: Connector_help_Lawo_HD_Core_Ravenna
---

# Lawo HD Core Ravenna

This driver is used to monitor a Lawo HD Core Ravenna module. This module is an I/O card for the HD Core. These modules are placed in a Lawo chassis, e.g. Lawo Nova73, and offer real-time distribution of audio and other media content within IP-based network environments.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 10-0-4-30              |

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

### Initialization

No additional configuration is required. When a new element is created/started, the Ember+ tree will be polled. This can take up to 5 minutes. Progress of this action can be monitored using the Discovered Nodes and Node Discovery parameters. This action is repeated every day in case something changes in this tree.

### Redundancy

Redundancy is not defined in the driver.

### Web Interface

The web interface of the module is available through the Web Interface page.

The web interface is only accessible when the client machine has network access to the product.

## How to Use

This driver uses the Ember+ protocol to communicate with the device. On startup, the driver will poll the entire Ember+ tree to determine the paths to nodes that need to be accessed. This action can take up to 5 minutes and its progress can be followed using the Discovered Nodes and Node Discovery parameters on the General page. Once this action is complete, polling of the parameters will start. This discovery action is repeated every day, in case the Ember+ tree were to change.
