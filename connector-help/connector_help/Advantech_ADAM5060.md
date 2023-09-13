---
uid: Connector_help_Advantech_ADAM5060
---

# Advantech ADAM5060

The ADAM-5060 features six relay output channels. Each channel can be independently configured, and can also be used to control heaters, pumps and power equipment.

This driver allows you to monitor these channels. The driver uses serial communication with the device. It is possible to invert the mode line.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.1.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.1.0.x   | 1.29                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device, by default *502*.
  - **Bus address**: The bus address of the device. Range: *0-7*.
    Note**:** This module is typically mounted in a 4- or 8-slot ADAM-5000 rack module and the bus address is determined by the slot position.

## How to use

This driver has only one data page, which allows you to monitor the **Real State** of each of the 6 channels.
