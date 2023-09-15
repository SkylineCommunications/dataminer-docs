---
uid: Connector_help_Imagine_Communications_Selenio_MDX1
---

# Imagine Communications Selenio MDX1

The **Imagine Communications Selenio MDX1** is a type of card that can be slotted into a Selenio chassis. This connector contains a full overview of all the data available in this card. The Selenio MDX1 encapsulates streams for transport. It can multiplex, de-multiplex and re-multiplex transport streams and also provides a host of options to adjust or add additional content to streams. Compared to the MDX2, the MDX1 provides very similar options, but lacks the DVB-T2 options.

## About

This connector displays information on different pages, described in the **Usage** section of this document.

The **versioning** for the connector is specifically engineered to tie in with the firmware version of the card the connector supports. It uses the following format: X.X.X.Y, with X.X.X being the firmware version of the card and .Y the specific connector iteration for this firmware. For example, *5.0.28.2* means the connector is the second iteration for firmware *5.0.28.*

### Version Info

| **Range** | **Description**                                                                                                                               | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| \<10.0.0.x       | **\[Main\]** The **versioning** of the connector is specifically engineered to tie in with the firmware version of the card the connector supports. | No                  | Yes                     |
| 10.0.0.x         | Replaced the "dynamic snmp get" with "dynamicSnmpGet="true"" under parameter type tag.                                                        | No                  | Yes                     |
| 5.5.0.x          | Based on 5.4.9.4 DCF implementation.                                                                                                          | Yes                 | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                                                                                                   |
|------------------|-----------------------------------------------------------------------------------------------------------------------------------------------|
| \<10.0.0.x       | **\[Main\]** The **versioning** of the connector is specifically engineered to tie in with the firmware version of the card the connector supports. |
| 10.0.0.x         | Requires controller firmware "S/W=7.0-38, H/W= rev 02" or higher and will not work with older firmware.                                       |
| 5.5.0.x          | Requires controller firmware 5.4.9                                                                                                            |

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

   - Every 7 seconds, a check is done for any changed configurable values. If such a change is detected, the new value is retrieved and instantly updated in the element. If the change is the cell of a table, the complete table is refreshed. After a change is detected, the check is boosted and performed every 0.5 seconds, until no more changes are detected.

## Usage

The connector contains different pages divided into several sections using separators.

### General section

This section contains the following pages:

- **General:** Contains information such as the slot number, state, temperature, protection status and chassis IP.
- **Alarming:** Contains a table with all the possible alarms that the card can generate and its current state (*Active priority 0-\>10* or *Inactive*).

### Module section and Reference Section

These sections contain data concerning the general module, such as **DST Date and Time** and the **Reference Clock**.

### IP Lan section

This section contains general settings for all LANs. Detailed information is present in tables for the **Primary Data IP LANs** and the **Secondary Data IP LANs**.

### Functions section

This section contains only the **Function** page, which displays two tables that indicate the function type and additional information.

### Multiplexer Functions section

This section consists of the following pages: **Multiplexers**, **Input Channels**, **DVBT SFN Transmitter**, **Output Program Status** and **Output Elementary Streams.**

They contain all data concerning the multiplexing of transport streams.

### De-Multiplexer Functions section

This section consists of the following pages: **Demultiplexer PID Map**, **Demultiplexers**, **Output Channels**, **Input Program Status** and **Input Elementary Streams.**

They contain all data concerning the de-multiplexing of transport streams.

### Conditional Access section

This section consists of the following pages: **Conditional Access**, **CA Systems**, **ECMG**, **EMMG**, **Access Criteria**, **Scrambling Control Groups**, **ECM** and **ISDBT SFN Transmitter.**

They allow you to configure the **External Conditional Access Systems**. Different **Access Criteria** can be applied. This section also allows you to control **Encryption Modes**.

## DataMiner Connectivity Framework

The **5.5.0.x** connector range of the **Imagine Communications Selenio MDX1** protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **EXT GPS 10 MHz:** **in**
- **EXT GPS 1PPS: in**
- **EXT ASI 1: inout**
- **EXT ASI 2: inout**
- **EXT ASI 3: inout**
- **EXT ASI 4: inout**
- **EXT ASI 5: inout**
- **EXT ASI 6: inout**
- **EXT ASI 7: inout**
- **EXT ASI 8: inout**
- **EXT IP: inout**

## Notes

Because of the large amount of data present in tables for this device, the demands on the network, memory and CPU for this connector will be significantly higher than for the other Imagine Communications Selenio cards. As a consequence, even though sets are executed on the device within 2 to 5 seconds, it may take a few additional seconds for the changes to show in the element. This depends on the size of the table containing the changed value and on the current workload of the DMA.
