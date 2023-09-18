---
uid: Connector_help_SED_32x8
---

# SED 32x8

This connector uses GPIB communication to monitor and configure an SED 32x8 matrix.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.0                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### GPIB Main Connection

This connector uses a GPIB connection and requires the following input during element creation:

GPIB CONNECTION:

- Interface connection:

  -**I/O API**: Choose between SICL or VISA

  - **Device address**: Specify the IP address and GPIB address. For example:

    `lan[192.168.122.19]:gpib0,30`

    - "lan" is the "SICL Interface name" in the IO configuration.
    - "192.168.122.19" is the "machineName", which is the IP address of the network GPIB interface.
    - "gpib0" is the "Remote SICL Interface Name".
    - "30" is the bus address on the device.

## How to Use

The **General** page displays the device **Application Information**, **Temperature Status**, and **Power Status.**

The **Matrix View** page displays the matrix.

The **Table View** page displays the **Inputs** table and the **Outputs** table.
