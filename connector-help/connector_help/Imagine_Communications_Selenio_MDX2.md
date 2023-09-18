---
uid: Connector_help_Imagine_Communications_Selenio_MDX2
---

# Imagine Communications Selenio MDX2

The **Imagine Communications Selenio MDX2** is a type of card that can be slotted into a Selenio chassis. This connector contains a full overview of all the data available in this card. The Selenio MDX2 encapsulates streams for transport. It can multiplex, de-multiplex and re-multiplex transport streams and also provides a large host of options to adjust or add additional content to streams. Compared to the MDX1, the MDX2 provides more options concerning DVB-T2.

## About

This connector displays information on different pages, described in the **Usage** section of this document, and it uses snmpv2 polling to get information from the device.

All data gets retrieved from the device in two ways.

1. **Timers**

   - Slow timer that triggers every hour and retrieves non-essential and configurable parameters.
   - Medium timer that triggers every 15 minutes and retrieves status parameters.
   - Fast timer that triggers every 7 seconds and retrieves slot information (state, temperature, protection and Source State). Alarm information is also retrieved every 7 seconds, but this can be changed to every 30 seconds. The latter is recommended when traps are configured on the Selenio.

1. **Dirty changes**

   - Every 7 seconds, a check is done for any changed configurable values. If such a change is detected, the new value is retrieved and instantly updated in the element. If the change is the cell of a table, the complete table is refreshed. After a change is detected, the check is boosted and performed every 0.5 seconds, until no more changes are detected.

The **versioning** for the connector is specifically engineered to tie in with the firmware version of the card the connector supports. It uses the following format: X.X.X.Y, with X.X.X being the firmware version of the card, and .Y the specific connector iteration for this firmware. For example, *5.0.28.2* means the connector is the second iteration for firmware *5.0.28.*

### Version Info

<table>
<colgroup>
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Description</strong></td>
<td><strong>DCF Integration</strong></td>
<td><strong>Cassandra Compliant</strong></td>
</tr>
<tr class="even">
<td>5.1.24.x</td>
<td>Initial range</td>
<td>No</td>
<td>No</td>
</tr>
<tr class="odd">
<td>5.4.9.x [SLC Main]</td>
<td><p>Based on 5.1.24.2</p>
<p>Implemented support for New firmware (<em>Ref. Firmware version table</em>)</p>
<p>Parameter listed in <strong>Notes</strong> section is no longer available, there are also some changes in PIDs/descriptions. So please verify any references in DMS to these parameters.(Visio, Automation Scripts, DMS Filters, Reports ...)</p></td>
<td>No</td>
<td>No</td>
</tr>
<tr class="even">
<td>10.0.0.x</td>
<td><p>Replaced the "dynamic snmp get" with "dynamicSnmpGet="true"" under parameter type tag.</p>
<p><strong>Not still used, until vendor release new firmware that completly support it.</strong></p></td>
<td>No</td>
<td>Yes</td>
</tr>
</tbody>
</table>

### Product Info

| **Range** | **Device Firmware Version**                                                                             |
|------------------|---------------------------------------------------------------------------------------------------------|
| 5.4.9.x          | Update for firmware 5.4.9                                                                               |
| 10.0.0.x         | Requires controller firmware "S/W=7.0-38, H/W= rev 02" or higher and will not work with older firmware. |

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

## Usage

The connector contains different pages divided into several sections using separators. For each page, there is a toggle button available to enable/disable polling of the section related to such page.

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

This section consists of the following pages: **Multiplexers, Input Channels, DVBT SFN Transmitter, Output Program Status** and **Output Elementary Streams.**

They contain all data concerning the multiplexing of transport streams.

### De-Multiplexer Functions section

This section consists of the following pages: **Demultiplexer PID Map, Demultiplexers, Output Channels, Input Program Status** and **Input Elementary Streams.**

They contain all data concerning the de-multiplexing of transport streams.

### Conditional Access section:

This section consists of the following pages: **Conditional Access, CA Systems, ECMG, EMMG, Access Criteria, Scrambling Control Groups, ECM, ISDBT SFN Transmitter.**

They allow you to configure the **External Conditional Access Systems**. Different **Access Criteria** can be applied. This section also allows you to control **Encryption Modes**.

### DVB-T2 Gateway section

This section consists of the following pages: **DVB-T2 Gateway, Frame, System** and **SFN.**

Control and monitoring of **Digital Video Broadcasting options** is available on these pages**.**

## Notes

Because of the high amount of data present in tables for this device, the demands on the network, memory and CPU for this connector will be significantly higher than for the other Imagine Communications Selenio cards. As a consequence, even though sets are executed on the device within 2 to 5 seconds, it may take a few additional seconds for the changes to show in the element. This depends on the size of the table containing the changed value and on the current workload of the DMA.

Changes from range 5.1.24.x to 5.4.9.x:

\- Parameter IP LANs Selected Receive Interface (PID30003) is no longer available.

\- Changes in Parameter IDs/descriptions aroud the connector.
