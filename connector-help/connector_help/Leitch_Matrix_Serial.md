---
uid: Connector_help_Leitch_Matrix_Serial
---

# Leitch Matrix Serial

The Leitch Matrix Serial connector is used to control and monitor a Leitch Matrix router. A matrix is used to display the connections between the inputs and the outputs of the router.

## About

### Version Info

| **Range**            | **Key Features**                             | **Based on** | **System Impact**                                                                   |
|----------------------|----------------------------------------------|--------------|-------------------------------------------------------------------------------------|
| 1.1.0.x \[Obsolete\] | Initial version                              | \-           | \-                                                                                  |
| 1.1.1.x              | \- Driver converted to Unicode. - DCF added. | 1.1.0.4      | Element data and trend data will be lost when moving from range 1.1.0.x to 1.1.1.x. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.1.0.x   | N/A                    |
| 1.1.1.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.

## How to Use

The **Main View** displays the matrix that represents the connections between the inputs and the outputs.

The **General** page allows you to select the number of inputs and outputs to display.
