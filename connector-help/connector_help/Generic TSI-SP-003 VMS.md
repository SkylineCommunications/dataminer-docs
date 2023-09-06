---
uid: Connector_help_Generic_TSI-SP-003_VMS
---

# Generic TSI-SP-003 VMS

This connector works with the standard TSI-SP-003 protocol for VMS systems (Variable Message Signs). It supports all devices that communicate with the TSI-SP-003 protocol.

## About

### Version Info

| **Range**            | **Key Features**                                | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. Includes text frame, planning. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 5.0                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### IP Connection - Main

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.

### Initialization

To log in to the device, on the **General** page, fill in the **Controller ID**, **Seed Offset**, and **Password Seed Offset**.

## How to use

The **General** page contains general status information. It also allows you to specify manual input for the text frames.

The **Signs** page contains a table with all the signs displayed with the currently displayed text.

The **Text Frames** page contains the 255 text frame slots that you can configure.

The **Plans** page contains the plans and allows you to create new plans.
