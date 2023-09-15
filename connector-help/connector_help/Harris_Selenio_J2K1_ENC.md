---
uid: Connector_help_Harris_Selenio_J2K1_ENC
---

# Harris Selenio J2K1 ENC

The **Harris Selenio J2K1 ENC** is one of the types of cards that can be slotted into a Selenio chassis. This connector contains a full overview of all the data available in such a card. Specifically, it contains information regarding audio, video and data encoding for up to 4 encoders.

## About

The information in this connector is displayed on different pages, described in the "Usage" section of this document.

The different **versions** of the connector tie in with the firmware version of the card the connector supports. The format "X.X.X.Y" is used, where "X.X.X" corresponds to the firmware version of the card and "Y" corresponds to the specific connector iteration for this firmware. For example, *5.0.28.2* means the connector is the second iteration for firmware *5.0.28.*

The current version is *1.0.90.1*

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

All data gets retrieved from the device in three ways.

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
> You can toggle alarm information to be received either every 30 seconds or every 3 seconds. The default value is every 3 seconds. It is recommended to only change this to 30 seconds when you enable traps to be sent to DataMiner.

## Usage

The connector contains different pages, divided into different sections using separators.

### General section

This section consists of the following pages:

- **General:** Contains information such as the slot number, state, temperature, protection status and chassis IP.
- **Alarming:** Contains a table with all the alarms the card can generate and its current state (*Active priority 0* -\>*10* or *Inactive*). Alarm polling can be toggled to 30 seconds or 3 seconds.

### Encoding Control

On this page, you can configure the **Encoding Control Sampling Structure** and **Latency Mode**.

### Module

- **TS Input 1 and TS Input 2:** Displays the status of both transport streams and their input programs and individual elementary streams.
- **ASI Status:** ASI 1-2 loss of signal, format and errors.

### Encoder 1-2-3-4

Four sections contain all settings and statuses for each unique encoder.

- **Encoder Control**: Generic settings and statuses for this particular encoder, e.g. **Enable/Disable Encoder Function**.
- **Encoder Video:** Video input and video compression settings.
- **Encoder Audio**: De-Embedded Audio and Encoder Audio Pairs 1 to 8.
- **Encoder Data:** Encoder Ancillary Data and VBI Data.
- **Encoder TS Mux:** PID Configuration and Video Audio and Data Stream Rates.
- **Encoder IP Encapsulation:** IP Configuration primary and secondary IP settings.

### IP LAN

- **IP LAN A-D**: Primary and secondary Ethernet settings.
- **IP LAN SFP** Status of the SFP Transmit Signal, Power, Link, Speed and Medium for both primary and secondary LAN.

### Audio Expansion Status

- **Expansion Status:** Expander detect statuses for Analog, AES for Expander 1 and Expander 2.
- **Expansion Sync Select:** Expander 1 and 2 Sync Selections and Lock Sources Selection.
- **Expansion Level:** Input and Output Levels for Expander 1 and 2.
- **Expander 1 Routing:** Allows the selection of Output Sources for AES/Analog and AES.
- **Expander 2 Routing:** Allows the selection of Output Sources for AES/Analog and AES.
