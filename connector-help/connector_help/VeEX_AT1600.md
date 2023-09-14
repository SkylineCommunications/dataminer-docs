---
uid: Connector_help_VeEX_AT1600
---

# VeEX AT1600

The main function of this connector is to configure the output port parameters and the routing in an AT1600 series multiplexer. This connector supports both the AT1601E and AT1602E multiplexers.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 4.03                   |

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
- **IP port**: The IP port of the destination (default value: 80).
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Initialization

No additional configuration of parameters is necessary in a newly created element.

### Redundancy

Redundancy is not defined in the connector.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The connector will retrieve the general device information and the port configuration settings at regular intervals using the HTTP API. Updating values will also be done using the HTTP API.

The **matrix** on the **General** page allows you to define the routing for each output. Alternatively, you can also define the routing in the **Outputs** table using the **Connected Input** parameter.

On the **Inputs/Outputs** page, you can find an overview of the available inputs and outputs. Here you can update the labels for the inputs and outputs. Note that these labels are only used locally and are not updated on the device itself (this is not supported). The outputs table also allows you to configure the port settings for the different output ports (one or two depending on the type of multiplexer).

Note: The **control mode of the output** **has to be set to** **API/CX280X** in order to update values on the device through the connector. If you change the control mode from the connector, you will need to change it back to API/CX280X in the manner defined by the new control mode in order to perform sets from the connector. Changing the control mode will reset the configured values for the output port.
