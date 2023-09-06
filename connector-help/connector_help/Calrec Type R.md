---
uid: Connector_help_Calrec_Type_R
---

# Calrec Type R

The Calrec Type R is a modular IP mixing system that uses standard network technology and can be tailored to individual operator needs.

## About

### Version Info

| **Range**            | **Key Features**                                        | **Based on** | **System Impact** |
|----------------------|---------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version with support for all Ember+ parameters. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.3.7                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### IP Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *62001*).
  - **Bus address**: The bus address of the device.

## How to use

This connector uses Ember+ calls to retrieve and send the information to the device.

You can view and control the inputs and outputs in the respective tables. There are three ways of enabling or disabling an input: toggle, pulse, or inverted pulse. Both the pulse and inverted pulse durations can be edited with this connector.

You can also view and control the memory variables, such as memory selection and feedback.
