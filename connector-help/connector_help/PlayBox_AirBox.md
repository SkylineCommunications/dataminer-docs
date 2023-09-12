---
uid: Connector_help_PlayBox_AirBox
---

# PlayBox AirBox

The PlayBox AirBox protocol can be used to monitor basic information about a playout server running the AirBox software and the TitleBox software.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

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

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.

### Initialization

By default, the protocol will only monitor the AirBox and TitleBox info.

If you also want to monitor information about the operating system or the hardware, set the relevant "Poll ... Parameters" **toggle buttons** to enabled. You can find these toggle buttons at the top of the Operating System page and the Hardware page.

### Redundancy

There is no redundancy defined.

## How to Use

The **General** page contains all the basic information about the AirBox and TitleBox software. If you see the value "Not Available", this means that the software is currently offline.

The **Operating System** page shows the total processor load and some basic information about the memory.

On the **Hardware** page, you can find data corresponding to the hardware, provided by SuperMicro. The health monitor table can contain temperature info, fan speeds and voltages. Limits can be set for each entry and the monitoring of each individual component can be enabled or disabled. Also, only for fan speeds, a divisor can be configured.
