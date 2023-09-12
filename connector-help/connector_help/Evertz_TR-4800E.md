---
uid: Connector_help_Evertz_TR-4800E
---

# Evertz TR-4800E

The TR-4800E Tally Router is an Ethernet-controlled interface for 32 general-purpose inputs (GPIs) and 48 general-purpose outputs (GPOs). It is the successor the TR-3200E.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a smart-serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Bus address**: The bus address of the device.

## How to use

On the **General** page, you can find the number of general-purpose inputs and outputs.

The **Inputs** page contains a table with the status for each input of the system.

The **Outputs** page contains a table where you can configure and view the status of each output of the system.
