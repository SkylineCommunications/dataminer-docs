---
uid: Connector_help_FVA_DSR9040A_ASI_Router_Switch
---

# FVA DSR9040A ASI Router Switch

The **FVA DSR9040A** is an ASI router that can handle up to 128 inputs and outputs.

This connector monitors the router using IP communication and displays the input/output connections in a matrix.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### IP Main Connection

This connector uses an IP connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **Type of port**: TCP/IP or UDP/IP. Default: *UDP/IP*.
  - **IP address/host**: The IP address of the device.
  - **IP port**: Port of the device. Default: *9900*.
  - **Local IP port**: Client port used by DataMiner to connect to the device. Default: *9902*.

## How to use

The **General** page displays the number of inputs and outputs of the device. The number of outputs can be retrieved from the device, but the number of inputs cannot be retrieved. When the element is created, the connector assumes the number of inputs is equal to the number of outputs. However, you can change these numbers manually.

The matrix data is retrieved every minute. The **Refresh Matrix** button can be used to force the polling of the matrix.

The **Matrix View** page displays the matrix.

The **Table View** page displays the same information as the **Matrix View** page, but in the form of a table.

The **Alarms** page contains some parameters that need to be linked with an external connector (Gateway) in order to retrieve the needed values via the **Element Connections** module. To configure this, in DataMiner Cube, go to Apps \> Modules \> Element Connections, then select the name of the element running this connector, and select the linked element, parameter and instance corresponding to the alarm values.
