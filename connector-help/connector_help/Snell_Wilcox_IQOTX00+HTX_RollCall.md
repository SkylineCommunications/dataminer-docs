---
uid: Connector_help_Snell_Wilcox_IQOTX00+HTX_RollCall
---

# Snell Wilcox IQOTX00+HTX RollCall

This driver monitors the activity of the Snell Wilcox IQOTX00+HTX RollCall device, an Optical Transmitter.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial Version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**          |
|-----------|---------------------------------|
| 1.0.0.x   | 0003 - 5.0.5 (software version) |



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
  - **IP port**: \[The IP port of the destination. (default: *2050*)\]
  - **Bus address**: \[The bus address of the device. (default: *UU.PP (Hex)*)\]

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### General

This page displays general information about the device, like the product info. It is possible to **Restart** the device and to set the **Factory Default**.

### I/0

In this page it is possible to set the device output state.

### Logging

In this page the user can check the logging state. There is a subpage for the **Configuration.**

### Memories

This page is related with the device Memories.

### Roll Track

In this page it is possible to check the Roll Track information.

### Connection Info

This page displays the connection status.
