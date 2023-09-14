---
uid: Connector_help_General_Dynamics_RSC1111
---

# General Dynamics RSC1111

Downtime must be minimized in today's complex systems. The failure of a single online unit can put a system off the air. Designed to minimize downtime, a dual 1:1 system consists of two independent 1:1 systems (usually mounted on one switching assembly) for two polarizations, each of which has one standby unit and one main unit. The dual 1:1 redundant system controller monitors the status of the units and switches the standby unit online when a failure of the primary unit is detected.

This DataMiner protocol allows you to monitor a General Dynamics RSC1111 dual redundant system.

## About

### Version Info

| **Range**            | **Key Features**                 | **Based on** | **System Impact** |
|----------------------|----------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Monitors main device parameters. | \-           | \-                |

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

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Bus address**: The bus address of the device.

## How to use

This protocol uses a serial connection to retrieve device status, configuration, alarms, faults, measurements, etc.

It has two timers to poll information at different rates. Static data, like the firmware version and product type, is refreshed every hour. Dynamic information, like the device status, faults and alarms, is refreshed every 10 seconds.

This is a polling protocol, meaning that controllers answer only when they receive a correctly formatted message from the DataMiner.

The element consists of the following data pages:

- **General**: Displays the Controller Type, Firmware version, Firmware Mask, and Redundancy Mode.
- **Status**: Contains device status information, including the switch, alarm and fault status.
- **Configuration**: Contains configuration parameters, including the alarm and fault configuration.
- **Measurements**: Displays the voltages of the power supplies, as well as different current values.
- **Alarms**: Displays the latched and active alarms for Controller Fault, External Alarm and Unit Current Alarm. Buttons are available to reset the latched alarms and mask the active alarms.
- **Faults**: Displays the device faults.
