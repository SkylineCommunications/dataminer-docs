---
uid: Connector_help_Symmetricom_TSC_4036B
---

# Symmetricom TSC 4036B

The 4036B provides fifteen outputs from a single input for distributing RF signals in laboratory, factory, and test and measurement environments where low phase noise and high channel isolation are required. The 4036B is a 1-input, 15-output RF distribution amplifier in a 1U chassis that provides fifteen isolated copies of a single input.

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

#### IP Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *10001*).

### Initialization

No additional configuration is required.

### Redundancy

There is no redundancy defined.

## How to use

You can find all the information needed to monitor the 4036B on the **General** data page, including the Input Frequency, Model Number, Software Version, Input Signal State and Outputs State Alarm Table.
