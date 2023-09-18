---
uid: Connector_help_Integral_Systems_Monics_Automon_UDP
---

# Integral Systems Monics Automon UDP

The Kratos Monics System is an automatic satellite carrier monitoring system (or CMS) that checks carrier presence and performance at local and remote sites. It is designed mainly to watch over satellite up- and downlink performance. The system is also capable of sending **UDP formatted carrier and transponder data** for external application consumption.

## About

This is a smart-serial connector that receives carrier, transponder and beacon stream measurements and event fault streams.

### Version Info

| **Range**     | **Description**                                                                                          | **DCF Integration** | **Cassandra Compliant** |
|----------------------|----------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version                                                                                          | No                  | Yes                     |
| 2.0.0.x \[SLC Main\] | Alarm presets. Communication with SES Channel Manager.                                                   | No                  | Yes                     |
| 2.0.1.x \[Obsolete\] | Removed parameters that control the rows displayed based on the number or age. Added auto clear feature. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 2.0.0.x          | Unknown                     |
| 2.0.1.x          | Unknown                     |

## Installation and creation

### Creation

#### Smart-serial connection

This connector uses a smart-serial connection and requires the following input during element creation:

Smart-Serial Connection:

- **IP address/host:** The device IP.
- **Port Type:** The default value is *UDP*.
- **IP port:** The default value is *345*.
- **Bus address:** The device IP that is being monitored.

## Usage

### General Page

This page displays stream-related information:

- **Source IP:Port**: Displays the **Source IP:Port** for the system that is being monitored.
- **Stream Status**: Displays the stream status based on the **Automon Start** or **Stop** event.
- **Last Packet Received**: Displays the last time that a packet was received/updated.

Packet statistics:

- **Received Packets in 5 Minutes Interval**: Displays how many packets were received in the last 5-minute period.
- **Received Packets in 30 Minutes Interval**: Displays how many packets were received in the last 30-minute period.

### Carrier Page

This page displays a table with information and measurement values for carriers.

### Transponder Page

This page displays a table with information and measurement values for transponders.

### Beacon Page

This page displays a table with information and measurement values for beacons.

### Alarms Page

This page displays a table for each type of possible event: Carrier, Transponder, Beacon and Noise.

### Alarm Presets Page

On this page, you can create and edit **Alarm Presets** to be used on **Carrier**, **Beacon** and **Transponder** tables. You can also import and export presets using .csv files.

### Table Configuration

On this page, you can define how long a packet should be stored in a table.

If the **Maximum Age of Packets** setting is enabled and set to a particular number of days, then the day after this number of days has passed, the packet will be deleted from the table.

In range 2.0.1.x, this page is not available, as its parameters are no longer needed.
