---
uid: Connector_help_Imagine_Communications_Selenio_DEM1
---

# Imagine Communications Selenio DEM1

The **Imagine Communications Selenio DEM1** is one of the types of cards that can be slotted into a Selenio chassis. This connector contains a full overview of all the data available in such a card. Specifically, it contains information regarding audio, video and data decoding.

## About

This connector displays information on different pages, described in the **Usage** section of this document.

The **versioning** for the connector is specifically engineered to tie in with the firmware version of the card the connector supports. It uses the following format: X.X.X.Y, with X.X.X being the firmware version of the card, and .Y the specific connector iteration for this firmware. For example, *5.0.28.2* means the connector is the second iteration for firmware *5.0.28.*

### Version Info

| **Range** | **Description**                                                                                                                               | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| \<10.0.0.x       | **\[Main\]** The **versioning** of the connector is specifically engineered to tie in with the firmware version of the card the connector supports. | No                  | Yes                     |
| 10.0.0.x         | Replaced the "dynamic snmp get" with "dynamicSnmpGet="true"" under parameter type tag.                                                        | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                                                                                                   |
|------------------|-----------------------------------------------------------------------------------------------------------------------------------------------|
| \<10.0.0.x       | **\[Main\]** The **versioning** of the connector is specifically engineered to tie in with the firmware version of the card the connector supports. |
| 10.0.0.x         | Requires controller firmware "S/W=7.0-38, H/W= rev 02" or higher and will not work with older firmware.                                       |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Slot number where the card is plugged in at. Range *1-14.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string needed to read from the device. The default value is *public*.
- **Set community string**: The community string needed to set to the device. The default value is *public.*

### Timing

Data gets retrieved from the device in three ways.

1. **Timers**

   - **Slow Timer**: Triggers every hour and retrieves non-essential and configurable parameters.
   - **Medium Timer**: Triggers every 15 minutes and retrieves status parameters.
   - **Alarm Slow Timer**: Triggers every 30 seconds and retrieves alarm information (see note below).
   - **Fast Timer**: Triggers every 10 seconds and retrieves slot information (state, temperature, protection).
   - **Very Fast Timer**: Triggers every 3 seconds and retrieves dirty changes and alarm information (see note below).

1. **Dirty changes**

   - Every 3 seconds, a check is done for any changed configurable values. If such a change is detected, the new value is retrieved and instantly updated in the element. (If the change concerns a table cell, the complete table is refreshed.) After a change is detected, the check occurs faster and is performed every 0.5 seconds until no more changes are detected.

1. **Traps**

   - When enabled and set up on the chassis, traps can be sent to DataMiner whenever an alarm occurs. The traps are accepted and processed.

> [!NOTE]
> You can toggle alarm information to be retrieved either every 30 seconds or every 3 seconds. The default value is every 3 seconds. It is recommended to only change this to 30 seconds when you enable traps to be sent to DataMiner.

## Usage

This connector contains different pages, divided into several sections using separators.

### General section

This section consists of the following pages:

- **General:** Contains information such as the slot number, state, temperature, protection status and chassis IP.
- **Alarming:** Contains a table with all the alarms the card can generate and its current state (*Active priority 0* -\>*10* or *Inactive*). Alarm polling can be toggled to 30 seconds or 3 seconds.

### Demodulation section

This section consists of the following pages:

- **Demodulation**: Contains the **Advanced Modulation Standards** parameter.
- **RF1 and RF2**: Provides the status and configuration for the RF 1 and RF 2.

### Transport Stream Input

This section consists of the following pages:

- **TS Input 1 and TS Input 2**: Displays the status of both transport streams and their input programs and individual elementary streams.
- **ASI Status**: ASI 1-2 loss of signal, format and errors.

### Transport Stream Output

This section contains the **Decrypt 1 and 2** pages, which display decryption parameters and the **Decrypt Programs** table.

### IP Encapsulation

This page contains the **Transmit Configuration** and **Status** for IP Encapsulation 1 and 2.

### IP LAN

This page contains general settings for all LANs. Detailed information is present in tables for the **Primary Data IP LANs** and the **Secondary Data IP LANs**.

### Misc section

This section contains a number of miscellaneous parameters.

### Inband Firmware Upgrade

This section contains the **Inband Firmware Upgrade** parameters.

### Selenio-Controller

This page displays the module web host page. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
