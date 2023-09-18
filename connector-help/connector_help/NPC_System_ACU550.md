---
uid: Connector_help_NPC_System_ACU550
---

# NPC System ACU550

The NEYRPICr ACU550 is a microprocessor-based Antenna Control Unit (ACU) for the tracking of geostationary and low-orbit satellites.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                              |
|-----------|---------------------------------------------------------------------|
| 1.0.0.x   | There are no known firmware versions that the connector depends on. |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Connection

This connector uses a TCP/IP connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device (by default 645).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This connector will allow monitoring and control of the ACU. No special actions are required to use it.

The connector creates a TCP client to retrieve all data from the ACU, so no data will be available in Stream Viewer.
