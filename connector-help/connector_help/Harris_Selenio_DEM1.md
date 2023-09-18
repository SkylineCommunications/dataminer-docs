---
uid: Connector_help_Harris_Selenio_DEM1
---

# Harris Selenio DEM1

The **Harris Selenio DEM1** is one of the types of cards that can be slotted into a Harris Selenio Chassis. This connector contains a full overview of all the data available in such a card. Specifically, it contains information for Audio, Video and Data Decoding.

## About

The information displayed in this connector is divided over different pages. The displayed information and settings of each page are described in the "Usage" section of this document.

The different **versions** of the connector tie in with the firmware version of the card the connector supports. The format "X.X.X.Y" is used, where "X.X.X" corresponds to the firmware version of the card and "Y" corresponds to the specific connector iteration for this firmware. (E.g. *5.0.28.2* means the connector is the second iteration for firmware *5.0.28.*)

The current version is *1.0.36.1.*

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.
- **Device address**: Slot number where the card is plugged in. Range *1-14*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *public*.

### Timing

Data gets retrieved from the device in three ways.

1. **Timers**

   - **Slow Timer**: Triggers every hour and retrieves non-essential and configurable parameters.
   - **Medium Timer**: Triggers every 15 minutes and retrieves status parameters.
   - **Alarm Slow Timer**: Triggers every 30 seconds and retrieves alarm information (see note below).
   - **Fast Timer**: Triggers every 10 seconds and retrieves slot information (state, temperature, protection).
   - **Very Fast Timer**: Triggers every 3 seconds and retrieves Dirty Changes and alarm information (see note below).

1. **Dirty Changes**

   - Every 3 seconds a check is done for any changed configurable values. If such a change is detected, the new value is retrieved and instantly updated in the element. (If the change concerns a table cell, the complete table is refreshed.) After a change is detected, the check occurs faster and is performed every 0.5 seconds until no more changes are waiting to be detected.

1. **Traps**

   - When enabled and set up on the chassis, traps can be sent to DataMiner whenever an alarm occurs. The traps are accepted and processed.

Note: You can toggle alarm information to be received either every 30 seconds or every 3 seconds. The default value is every 3 seconds. It is recommended to only change this to 30 seconds when you enable traps to be sent to DataMiner.

## Usage

This connector contains different pages, divided into different sections using separators.

### General section

This section consists of the following pages:

- **General:** Contains information such as the slot number, state, temperature, protection status and chassis IP.
- **Alarming:** Contains a table with all the alarms the card can generate and its current state (Active priority 0-\>10 or Inactive). Alarm polling can be toggled to 30 seconds or 3 seconds.

### Demodulation section

This section consist of the following pages:

- **Demodulation**: Contains the **Advanced Modulation Standards** parameter.
- **RF1 and RF2**: Provides the status and configuration for the RF 1 and RF 2.

### Transport Stream Input

This section consists of the following pages:

- **TS Input 1 and TS Input 2**: Displays the status of both Transport Streams and their Input Programs and individual elementary streams.
- **ASI Status**: ASI 1-2 loss of signal, format and errors.

### Transport Stream Output

This section consists of the following pages:

- **Decrypt 1 and 2**: Contains decryption parameters and the **Decrypt Programs** table.

### IP Encapsulation

This page contains the **Transmit Configuration** and **Status** for IP Encapsulation 1 and 2.

### Control

This page displays the IP Lan A and IP Lan B with Primary and Secondary IP Configuration.

### Misc section

This section contains a number of miscellaneous parameters and the **Inband Firmware Upgrade** parameters.
