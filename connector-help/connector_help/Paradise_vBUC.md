---
uid: Connector_help_Paradise_vBUC
---

# Paradise vBUC

Teledyne Paradise Datacom's second-generation VSAT Block Up Converters (vBUCs) have been designed to offer the maximum utility in VSAT systems while maintaining the highest possible reliability.

This driver polls the status and power information from the Paradise vBUC using the RS485 serial interface.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial release. | \-           | \-                |

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

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *6703*).

### Initialization

Once the element has been created, specify the **Destination Address** and **Source Address** on the **Configuration** page. These are needed to be able to gather data using the serial interface. Once these parameters are filled in, the data will be polled and displayed on the other pages.

Note that the address parameters are in **decimal format**. For instance, for an address of hex "10", you must enter the decimal value 16.

### Redundancy

There is no redundancy defined.

## How to use

When the Destination Address and Source Address have been correctly specified on the Configuration page, you can check status information on the General page, configuration information on the System Settings page, and various measurements (e.g. temperature, current, voltage) on the System Conditions page.
