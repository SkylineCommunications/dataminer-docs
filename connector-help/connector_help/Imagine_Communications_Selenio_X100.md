---
uid: Connector_help_Imagine_Communications_Selenio_X100
---

# Imagine Communications Selenio X100

The **Imagine Communications Selenio X100** is a standalone frame synchronizer and converter unit. This connector provides complete monitoring and configuration for this device. Specifically, it contains information regarding audio, video, data and GPI processing.

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
| 10.0.0.x         | Requires controller firmware "S/W=7.0-38, H/W= rev 02" or higher and will not work with older firmware.                                       |

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

All data gets retrieved from the device in three ways.

1. **Timers**

   - **Slow Timer**: Triggers every hour and retrieves non-essential and configurable parameters.
   - **Medium Timer**: Triggers every 15 minutes and retrieves status parameters.
   - **Alarm Slow Timer**: Triggers every 30 seconds and retrieves alarm information (see note below).
   - **Very Fast Timer**: Triggers every 3 seconds and retrieves dirty changes and alarm information (see note below).

1. **Dirty Changes**

   - Every 3 seconds, a check is done for any changed configurable values. If such a change is detected, the new value is retrieved and instantly updated in the element. (If the change concerns a table cell, the complete table is refreshed.) After a change is detected, the check occurs faster and is performed every 0.5 seconds until no more changes are detected.

1. **Traps**

   - When enabled and set up on the device (via *Misc* \> *SNMP*), traps can be sent to DataMiner whenever an alarm occurs. The traps are accepted and processed.

> [!NOTE]
> You can toggle alarm information to be retrieved either every 30 seconds or every 3 seconds. The default value is every 3 seconds. It is recommended to only change this to 30 seconds when you enable traps to be sent to DataMiner.

## Usage

The connector contains different pages, divided into several sections using separators.

### General section

This section consists of the following pages:

- **General**: Contains information such as a configurable **Custom Name**, the **Version** and the **Serial Number**.
- **Alarming**: Contains a table with the possible alarms the device can generate and its current state (*Active priority 0* -\>*10* or *Inactive*). Alarm polling can be toggled to 30 seconds or 3 seconds.
- **Status**: Contains status parameters for **Temperature**, **Power Supply** and **Fans**, and a parameter value for the **Main Board LEDs**.

### Video section

In this section, you can find monitoring and configuration values for the **Video Input**, **Analog Input Control**, **Video Output and Routing**, **Analog Output Control**, **Video Reference** and **Processing Channel 1 and 2.**

### Audio section

In this section, you can find data concerning **AAP 1-4 Configuration**, **AES IO Assignment**, **Input Control and Status**, **De-embedding**, **Embedding**, **Input Delay and Sync**, **Audio TSG**, **ProcAmp**, **Advanced Audio Processing**, **Output Routing and Delay** and **Audio Metadata.**

### Misc section

This section contains various data concerning the **Serial**, **SNMP** and **Network Setup**, as well as **Versioning** and **Licensing**, **Green (Power save setup)**, **SFP Status** and **Cal (AnalogAudio and VID).**

### Data section

This section contains **Output**, **Input and Advanced Status** and **Control settings**.

### Control section

This section contains the **GPI and Rules Engine**.
