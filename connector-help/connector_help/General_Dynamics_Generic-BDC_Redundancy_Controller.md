---
uid: Connector_help_General_Dynamics_Generic-BDC_Redundancy_Controller
---

# General Dynamics Generic-BDC Redundancy Controller

The **VertexRSI 1:2 Redundant Converter System** is designed for installation in satellite earth stations. The system consists of three block downconverters (-1201 models) or block upconverters (-1202 models) in a 1:2 redundant configuration, including automatic switchover logic, redundant power supplies, and redundant AC line inputs. The system monitors the status of its converters and switches the standby unit online when a failure of either primary unit is detected.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.092                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600* (default: *19200*). Range: *300* - *28800*.
  - **Databits**: Databits specified in the manual of the device, e.g. *7* (default: *8*).
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1* (default: *1*).
  - **Parity**: Parity specified in the manual of the device, e.g. *No* (default: *no*).
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No*. (default: *no*).

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Bus address**: The bus address of the device (range: *0* - *255*).

## How to use

The **General** page displays information about the type of product, the firmware, the power supplies, and the Remote and Auto mode.

The **Configuration** page allows you to configure some device settings.

Depending on the system configuration, the switch positions can be checked and configured on the **System Positions** and **System Switch Control** pages.

Other monitoring parameters can be found on the **Alarms** and **Faults pages.**
