---
uid: Connector_help_Imagine_Communications_Selenio_DEC1
---

# Imagine Communications Selenio DEC1

The **Imagine Communications Selenio DEC1** is a type of card that can be slotted into a Selenio chassis. This connector contains a full overview of all the data available in such a card. Specifically, it contains information regarding audio, video and data decoding.

## About

This connector displays information on different pages, described in the **Usage** section of this document.

The **versioning** for the connector is specifically engineered to tie in with the firmware version of the card the connector supports. It uses the following format: X.X.X.Y, with X.X.X being the firmware version of the card and .Y the specific connector iteration for this firmware. For example, *5.0.28.2* means the connector is the second iteration for firmware *5.0.28.*

### Version Info

| **Range** | **Description**                                                                                                                               | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| \<10.0.0.x       | **\[Main\]** The **versioning** of the connector is specifically engineered to tie in with the firmware version of the card the connector supports. | No                  | Yes                     |
| 10.0.0.x         | Replaced the "dynamic snmp get" with "dynamicSnmpGet="true"" under parameter type tag.                                                        | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                                                                                                   |
|------------------|-----------------------------------------------------------------------------------------------------------------------------------------------|
| \<10.0.0.x       | **\[Main\]** The **versioning** of the connector is specifically engineered to tie in with the firmware version of the card the connector supports. |
| 10.0.0.x         | Requires controller firmware "S/W=7.0-38, H/W= rev 02" or higher and will not work on older firmware                                          |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Slot number where the card is plugged in. Range *1-14.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string needed to read from the device. The default value is *public*.
- **Set community string**: The community string needed to set to the device. The default value is *public.*

### Timing

All data gets retrieved from the device in two ways.

1. **Timers**

   - Slow timer that triggers every hour and retrieves non-essential and configurable parameters.
   - Medium timer that triggers every 15 minutes and retrieves status parameters.
   - Fast timer that triggers every 3 seconds and retrieves slot information (state, temperature, protection).

1. **Dirty changes**

   - Every 3 seconds, a check is done for any changed configurable values. If such a change is detected, the new value is retrieved and instantly updated in the element. If the change is the cell of a table, the complete table is refreshed. After a change is detected, the check is boosted and performed every 0.5 seconds, until no more changes are detected.

## Usage

The connector contains different pages divided into several sections using separators:

### General section

This section contains the following pages:

- **General**: Contains information such as the slot number, state, temperature, protection status and chassis IP.
- **Alarming**: Contains a table with all the possible alarms that the card can generate and its current state (*Active priority 0-\>10* or *Inactive*).

### Video section

In this section, the **Video** and **Video Status** pages display configurable and status parameters for video settings.

### Audio section

This section contains the following pages:

- **Audio 1 -\> Audio 8**: These pages contain all configurable and status parameters for the audio (status, Dolby Digital control, metadata).
- **Audio Routing**: A list of AES and EMB output sources and channel routing parameters.

### Data section

This section contains the following pages:

- **VANC Processing:** All information concerning the **Vertical Ancillary Data Space** of the signal.
- **VBI Processing:** A list of all **Vertical Blanking Interval Processing Field** functions (per line) and statuses.

### TS Input section

This section contains 5 pages listing statuses and general settings concerning the transport stream input, such as primary and secondary IP configurations, general IP status, ASI status and the source of the stream.

### TS Demux section

This section displays all relevant data regarding individual components extracted from the **transport stream**. Among the different components are **Video**, **Audio**, **Data**, **Subtitles** and **BISS Scrambling**.

### Control section

This section contains the following pages:

- **IP**: Control information concerning primary and secondary data Ethernet.
- **Serial**: Control information concerning Serial 1 and Serial 2.
- **GPI**: GPI Out 1-\>4 statuses.

### Misc section

This section contains a number of miscellaneous parameters.
