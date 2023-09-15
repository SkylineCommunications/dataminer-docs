---
uid: Connector_help_Specialty_Microwave_Corp_13966-505
---

# Specialty Microwave Corp 13966-505

This connector uses serial communication to communicate with a switching module. It allows you to switch from high to low and check the power supply status.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v2.x                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device (default: *49*; range: *126 - 33*).

## How to use

On the **General** page, you can toggle the position of the switch, if the **Local Indicator** parameter indicates *Remote*. If Local Indicator indicates *Local*, remote sets are not possible.

The power supply status 1 and 2 are also displayed on this page.
