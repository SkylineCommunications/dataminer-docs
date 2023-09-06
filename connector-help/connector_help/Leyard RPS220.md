---
uid: Connector_help_Leyard_RPS220
---

# Leyard RPS220

The RPS220 device is used for an LED wall ecosystem, consisting of power supply, video wall controller, and LED panels.

This connector monitors the different parameters configured in the RPS220 device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 8.0.1084               |

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

- **IP address/host**: The polling IP of the device, e.g. *10.110.29.49*.
  - **Type of port**: By default *UDP/IP*.
  - **IP Port**: By default *57*.

## How to use

The following pages are available:

- **General**: Displays basic information about the device such as the model name, firmware version, serial number, etc.
- **Configuration**: Contains basic information about the device configuration such as the IP address, default gateway, subnet mask, etc.
- **System Information**: Contains system information (state, auto power, device temperature, etc.) and a Breakers and Fuses subpage that contains breaker and fuse state information tables.
