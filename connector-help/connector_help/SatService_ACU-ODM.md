---
uid: Connector_help_SatService_ACU-ODM
---

# SatService ACU-ODM

The SatService ACU-ODM connector is used to monitor and configure the ACU-ODM Antenna Controller.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.2.081 2019-12-10     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination, *default value: 80*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Initialization

No additional configuration of parameters is necessary in a newly created element.

### Redundancy

No redundancy is defined in the connector.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The connector will use HTTP GET calls to retrieve and set the parameters from the device.

The **Targets** table is polled incrementally, meaning that the target with ID 0 is polled first, up to 199. Should one of the calls fail (status code is not 200) during the polling, then the polling of the Targets table will fail.
