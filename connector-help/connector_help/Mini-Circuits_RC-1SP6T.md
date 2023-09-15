---
uid: Connector_help_Mini-Circuits_RC-1SP6T
---

# Mini-Circuits RC-1SP6T

The Mini-Circuits RC series of RF switch matrices is capable of USB and Ethernet (HTTP and Telnet protocols) control.

This connector is used to monitor and control the SP6T switch module RC-1SP6T-A18.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | F2-2                   |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device (default: *80*).

## How to use

The **General** page displays the device model, firmware version, and serial number.

On the **Controller** page, you can set an individual switch within an SP6T switch matrix while leaving any other switches (if applicable) unchanged. The page shows the number of switching cycles undertaken by a specified SP6T switch. You can also define the power-up mode of the machine.

On the **Alarms** page, you can see the sensor's alarms state, as received from the device.
