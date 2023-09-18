---
uid: Connector_help_Generic_TSL_Tally_Message_Processor
---

# Generic TSL Tally Processor

This is a generic connector intended to monitor display devices using the TSL protocol.

## About

### Version Info

| **Range** | **Key Features**                                                                                        | **Based on** | **System Impact** |
|-----------|---------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x   | \- Initial version. - Features: republish tallies, add publisher, add functions, and process CSV files. | \-           | \-                |

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

SMART-SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600*.
  - **Databits**: Databits specified in the manual of the device, e.g. *7*.
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1*.
  - **Parity**: Parity specified in the manual of the device, e.g. *No*.
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No*.

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. Default: *5727*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

On the **General** page, buttons are available to add a publisher and to add color functions.

It is also possible to import a file. With the **Import File** button, you can import a table from a different connector with the same table. This can be done for both the publisher and the color functions.

On the **Messages** page, you can view the connection state and the messages received from Ross MC1.

## Notes

This connector **requires** **.NET 4.0 or higher**, as System.Web.Extensions.dll must be available.
