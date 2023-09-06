---
uid: Connector_help_Work_Microwave_RSCC-X
---

# Work Microwave RSCC-X

The RSCC-X is a redundancy switch from WORK Microwave used for redundant configurations with automatic or manual switchover for subsystems using WORK Microwave modulators, upconverters, downconverters, or similar equipment.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x              | Initial version  | \-           | \-                |
| 1.1.0.x \[SLC Main\] | New firmware     | 1.0.0.2      | \-                |

### Product Info

| **Range** | **Supported Firmware**     |
|-----------|----------------------------|
| 1.0.0.x   | RedSwi-RYA01.03-2018-12-04 |
| 1.1.0.x   | RSCC-X-RS485               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: 161

SNMP Settings:

- **Get community string**: public
- **Set community string**: private

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to Use

The connector polls the general information of the device and monitors its current status, history alarms, and events. Settings related to the redundancy operation are available as well. These functionalities are available on the following pages:

- **General**: Displays information related to licensing, firmware, controller board, and MAC address. The configuration of the system's date, name, and alarm relay are available as well.
- **Status:** Shows the current operational status of the device (alarms delay, current alarms, spare configured, spare in use, etc.).
- **Alarm History**: Displays the past alarms on the device, with a maximum of 99 entries.
- **Event History**: Displays the past events on the device, with a maximum of 99 entries.
- **Redundancy Configuration**: Contains settings related to the redundancy operation of the device, including the switch mode (manual or auto), the spare functionality, alarm off delay, query cycle, etc.
- **Unit Configuration**: Contains a table with the configuration parameters for the operation of the device (e.g. redundancy operation, IP address, gain offset, and priority). On a subpage, the SNMP configuration is available.
- **RS485 Termination \[1.1.0.x\]**:Allows you to enable or disable the TX or RX of the RS485.**Trap Sink server \[1.1.0.x\]**: Displays the trap sink server information and configuration.

The current version does not monitor the Relay Alarm IF and RF, since the device sends a null value for an integer parameter, which causes it to fail to retrieve these values.
