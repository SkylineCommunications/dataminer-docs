---
uid: Connector_help_Ovzon_Control_Terminal
---

# Ovzon Control Terminal

The Ovzon Control Terminal is Ovzon's internal management and testing tool. This connector uses a UDP connection to communicate with this tool.

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

#### Main connection

This driver uses a smart-serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. This is required. The default value is *21963*; the range is *0* to *65535*.

## Usage

The connector contains a page with different kinds of status information and a page with information and settings related to the ping command.
