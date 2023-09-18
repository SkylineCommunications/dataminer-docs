---
uid: Connector_help_Evertz_VIP-X
---

# Evertz VIP-X

The **Evertz VIP-X** connector is used to monitor and control different kinds of Evertz VIP-X video cards.

## About

This connector uses an SNMP connection to display information on an Evertz VIP-X video card and allow its configuration.

### Version Info

| **Range**     | **Description**              | **DCF Integration** | **Cassandra Compliant** |
|----------------------|------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version              | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | Fixed indexes, TOO BIG error | No                  | Yes                     |

## Installation and Configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

### General

This page displays the **Card Type** and the number of **Video Inputs**.

### Video Input

This page contains general information about the different video inputs, such as the **Video standard**.

Via the page buttons, e.g. **SCTE 104**, additional information is available.

### Video monitoring

On this page, the **Monitoring Behavior Control** table allows you to enable or disable monitoring of all inputs, as well as to switch between the main or backup input.

The **Input Monitoring Control Table** allows you to specify the conditions for which a fault will be raised on the device.

### Audio

On this page, you can find information on the loudness of each video program in the **Audio Loudness Table**.

### Audio Control

Both tables on this page control the conditions for which an audio fault will be raised on the device.

### GPI

The tables on this page allow you to monitor the GPI settings

### Output

This page contains data about the different outputs.

### Video Alarms

On this page, the **Video Alarms Table** lists the current status of all the video faults. Each row is associated with a trap. When a trap is received, the table is polled again.

Traps can be disabled or enabled via the **Send Trap Video** parameter.

### Audio Alarms

On this page, the **Audio Alarm Table** lists the current status of all the audio faults. Each row is associated with a trap. When a trap is received, the table is polled again.

Traps can be disabled or enabled via the **Send Trap Audio** parameter.

### Extended Alarms

On this page, the **Extended Alarm Table** lists the current status of all the extended faults. Each row is associated with a trap. When a trap is received, the table is polled again.

Traps can be disabled or enabled via the **Send Trap Extended** parameter.
