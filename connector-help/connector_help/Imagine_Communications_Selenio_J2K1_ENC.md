---
uid: Connector_help_Imagine_Communications_Selenio_J2K1_ENC
---

# Imagine Communications Selenio J2K1 ENC

This connector can be used to monitor and control the **encoder** functionality of the **Imagine Communications Selenio JPEG2000**.

The Imagine Communications Selenio JPEG2000 is a is a multichannel encoder/decoder solution, offering real-time, high-quality JPEG2000 compression over IP.

## About

There are 2 connectors that can be used to monitor and control the **Imagine Communications Selenio JPEG2000** card.

This connector only supports the **encoder** functionality. The [Imagine Communications Selenio J2K1 DEC](xref:Connector_help_Imagine_Communications_Selenio_J2K1_DEC) connector can be used to monitor and control the decoder functionality of the card.

Starting from version **3.0.0.1**, **DVEs** can be created for the 4 encoder channels.

### Version Info

| **Range**    | **Description**                                                                                                              | **DCF Integration** | **Cassandra Compliant** |
|---------------------|------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.90.x            | Initial range.                                                                                                               | No                  | No                      |
| 1.1.0.x             | Updated for firmware 2.0.13.                                                                                                 | No                  | No                      |
| 2.2.0.x             | Updated for firmware 2.0.                                                                                                    | No                  | No                      |
| 3.0.0.x             | DVEs for each encoder.                                                                                                       | No                  | Yes                     |
| \<10.0.0.x \[Main\] | The versioning of the connector is specifically engineered to tie in with the firmware version of the card the connector supports. | No                  | Yes                     |
| 10.0.0.x            | Replaced "dynamic snmp get" with "dynamicSnmpGet="true"" under parameter type tag.                                           | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                                                                                  |
|------------------|------------------------------------------------------------------------------------------------------------------------------|
| 1.0.90.x         | 1.0.90                                                                                                                       |
| 1.1.0.x          | 2.0.13                                                                                                                       |
| 2.2.0.x          | 2.0                                                                                                                          |
| 3.0.0.x          | 2.0                                                                                                                          |
| \<10.0.0.x       | The versioning of the connector is specifically engineered to tie in with the firmware version of the card the connector supports. |
| 10.0.0.x         | Requires controller firmware "S/W=7.0-38, H/W= rev 02" or higher and will not work on older firmware.                        |

### Exported connectors

| **Exported Connector**                            | **Description** |
|--------------------------------------------------|-----------------|
| Imagine Communications Selenio J2K1 ENC - Module | Encoder modules |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (**SNMPv2**) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Slot number that the card is plugged in at. Range *1-14.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string needed to read from the device. The default value is *public*.
- **Set community string**: The community string needed to set to the device. The default value is *public.*

## Usage

### General

Contains general information about the card.

### DVE

Available from version **3.0.0.1** onwards.

This page allows you to enable/disable **DVE creation** for each of the 4 encoder channels. You can also give a **custom name** to a DVE or **hide** it.

### Alarming

Contains the **Alarm Table**, with all the possible alarms that the card can generate and their current state (*Active priority 0-\>10* or *Inactive*).

**Alarm polling** can be toggled to *30 seconds* or *3 seconds*.

### Module

Contains **management** information for the module.

### Module Status

Displays **status** information for the module.

### Encoding Control

Contains information to manage sampling and latency.

### Encoder \[1 - 4\]

For each encoder channel (1 - 4), the same pages are available:

- **Encoder \[x\]** **Control**: Contains settings related to encoder control functions.
- **Encoder \[x\] Video**: Contains video information and settings.
- **Encoder \[x\] Audio**: Contains audio information and settings.
- **Encoder \[x\] Data**: Contains data information and settings.
- **Encoder \[x\] TS Mux**: Contains information and settings related to multiplexing.
- **Encoder \[x\] Encapsulation**: Contains IP settings and status information.

### IP LAN

Displays settings and information related to the data Ethernet interface.

### IP LAN \[A-D\]

These pages display general information to manage the data Ethernet interface of LAN type A - D.

### Audio Expansion Status

Displays general information about the audio expansion status.

### Audio Expansion Sync Select

Displays general information about audio expansion sync select.

### Audio Expansion Level

Displays general information about audio expansion input/output level.

### Audio Expansion Expander 1 Routing

Displays general information about audio expansion 1 output source.

### Audio Expansion Expander 2 Routing

Displays general information about audio expansion 2 output source.

### Selenio Controller

Displays the module webpage. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

### Timing

All data gets retrieved from the device in three ways.

1. Timers:

   - Slow timer that triggers every hour and retrieves non-essential and configurable parameters.
   - Medium timer that triggers every 15 minutes and retrieves status parameters.
   - Alarm slow timer that triggers every 30 seconds and retrieves alarm information. By default, this is retrieved every 3 seconds instead. It is advisable not to change this to 30 seconds unless you enable traps to be sent to DataMiner.
   - Fast timer that triggers every 10 seconds and retrieves slot information (state, temperature, protection).
   - Very fast timer that triggers every 3 seconds and retrieves dirty changes and alarm information. Alarm information can be toggled to be retrieved every 3 seconds instead.
   - Regular timer that triggers every 300 seconds.

1. Dirty changes

   - Every 3 seconds, the connector checks if any configurable values have changed. If it detects such a change, it instantly updates the displayed information with the new value. If the change is the cell of a table, the complete table is refreshed. After a change is detected, the check is boosted and performed every 0.5 seconds, until no more changes are detected.

1. Traps

   - When enabled and set up on the chassis, traps can be sent to DataMiner whenever an alarm occurs. The traps are accepted and processed for the ENC1 card.
