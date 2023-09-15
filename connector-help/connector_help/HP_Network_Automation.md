---
uid: Connector_help_HP_Network_Automation
---

# HP Network Automation

This connector polls the HP Network Automation API for device configuration information.

## About

### Version Info

| **Range**            | **Key Features**      | **Based on** | **System Impact**                                                                      |
|----------------------|-----------------------|--------------|----------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version       | \-           | \-                                                                                     |
| 1.0.1.x \[SLC Main\] | Supports EPM solution | 1.0.0.x      | \- Layout updates. - Polling functionality changed from Automation to importing files. |

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

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).

### Initialization

To make sure the connector can communicate with the API, fill in the credentials on the Configuration page.

### Redundancy

There is no redundancy defined.

## How to use

### Range 1.0.0.x

The connector polls the HP Network Automation API. To make it fill in the table, set parameter 998 with a list of elements to poll. The elements in the list should be separated by pipe ("\|") characters. You can set the parameter using an Automation script.

After you have filled in the correct credentials so the connector can log in to the device, every row in the table will be polled every hour.

### Range 1.0.1.x

This range of the connector imports files that contain devices name used to poll the HP Network Automation API.

There are three different polling modes:

- Generic: All the data from the interface is polled, via the import data. (Currently this is similar to the Centralized mode.)
- Distributed: Only the data for devices detected with the same DMA ID is polled.
- Centralized: All the data for the devices within the DMS is polled.
