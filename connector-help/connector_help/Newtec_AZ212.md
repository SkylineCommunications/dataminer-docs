---
uid: Connector_help_Newtec_AZ212
---

# Newtec AZ212

This connector uses an **SNMP** connection to monitor and configure a Newtec **1+1 Modulator Redundancy Switch**, which provides a 1+1 protection scheme for satellite modulators. The AZ210-2 simultaneously switches the input data signals and output IF/RF signals.

## About

With this connector, you can configure the main networking options and receive traps to display alarms, as well as configure the switches available in the device.

### Version Info

| **Range** | **Description**                                                                   | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                                                                  | No                  | No                      |
| 1.2.0.2(.x)      | For software version 2.0.2, based on 1.0.0.1. \[Obsolete: Use range 1.3.0.x.\]    | No                  | No                      |
| 1.2.0.4.x        | For software version 2.0.4, based on 1.2.0.2. \[Obsolete: Use a 4-number range.\] | Yes                 | No                      |
| 1.3.0.x          | Standardized range, continuation of 1.2.0.2.2. Added DCF.                         | Yes                 | No                      |
| 1.3.1.x          | New range for Cassandra compliancy. Changed displayColumn to naming.              | Yes                 | Yes                     |

> [!NOTE]
>
> - "Software version" refers to the value found in the **USS Bucket Version** parameter. We suspect there are 2 version numbers that need to be taken into account, but further information on this is still pending.
> - Ranges with additional numbers for firmware versions existed at some point in time, but the current rule requires 4 numbers.
> - Not Cassandra-compliant prior to range 1.3.1.x, because table PID 400 has the option **displayColumn**.

### Product Info

| **Range**            | **Device Firmware Version**                |
|-----------------------------|--------------------------------------------|
| 1.0.0.x                     | Bucket Name: AZ212-1.1.2 SW version: 1.1.0 |
| 1.2.0.2(.x) 1.3.0.x 1.3.1.x | Bucket Name: AZ212-2.0.2                   |
| 1.2.0.4.x                   | Bucket Name: AZ212-2.0.4                   |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161.*
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage

Once created, the element can be used immediately. There are 4 pages available.

### General

This page displays general information such as software versions, device name and networking configuration.

### Switch Control

On this page, you can configure and monitor the switch itself, the redundancy mode and the switchback behavior. You can also configure some options related to the alarms, such as the alarm delay.

The page contains two buttons with extra configuration options:

- **Setup Options:** Can be used to configure the device IP address and the state of its interfaces.
- **Operation Parameters:** Displays detailed information about the operation parameters of the connected devices such as position, configuration learned or alarm availability.

### Alarms

All available alarms reported by this device are displayed on this page. The alarm table is refreshed every time a trap with new alarm notification arrives.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
