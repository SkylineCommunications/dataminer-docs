---
uid: Connector_help_CEFD_CDM-760
---

# CEFD CDM-760

The **CDM-760** can retrieve **Configuration** information, **Status** information and **Packet Processor** informaton if it is *installed*. **Modem** configuration is found here, as well as **Utilities**, **Mask**, **Test**, **LNB**, **CID**, **MEO**, **ASI**. **CFG**. Also, the **Alarms**, **Logs**, **Info**, **IP Statistics**, **Ethernet**, **MAC** **Table**, **Packet Flows**, **Router**, **WAN,** **Header Comp**, **QoS**, and **BB Statistics**.

## About

The connector runs three **Timers** every *10 seconds*, every *1 minute,* and every *24 hours.* Always polling information accordently and if modules are not *installed* then it won't poll those groups. The new version *(1.5.7)* supports all *66* **ModCods** and the **Packet Processo**r.

Ranges of the connector

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
<td>1.0.0.x [SLC Main]</td>
<td>Initial version</td>
<td>No</td>
<td>No</td>
</tr>
<tr class="odd">
<td>1.1.0.x</td>
<td><p>Based on 1.0.0.13</p>
<p>Firmware changed to 1.5.7. ModMods range (1-66)</p></td>
<td>No</td>
<td>No</td>
</tr>
<tr class="even">
<td>1.1.1.x</td>
<td>Based on 1.1.0.4unneeded parameters removed</td>
<td>No</td>
<td>No</td>
</tr>
<tr class="odd">
<td>1.1.2.x</td>
<td>Cassandra compliant</td>
<td>No</td>
<td>Yes</td>
</tr>
</tbody>
</table>

Supported firmware versions

| **Range** | **Device Firmware Version**                   |
|------------------|-----------------------------------------------|
| 1.0.0.x          | 1.1.1                                         |
| 1.1.0.x          | 1.5.71.2.2 - If Packet Processor is installed |
| 1.1.1.x          | 1.5.71.2.2 - If Packet Processor is installed |
| 1.1.2.x          | 1.5.71.2.2 - If Packet Processor is installed |

## Installation and configuration

This connector uses a Simple Network Management Protocol (**SNMP**) connection and needs following user information:

**SNMP CONNECTION**:

- **IP address/host**: the polling IP of the device e.g. *10.11.12.13*

**SNMP Settings**:

- **Port number**: the port of the connected device, default *161.*
- **Get community string**: the community string in order to read from the device. The default value is *public*.
- **Set community string**: the community string in order to set to the device. The default value is *private.*

## Usage

### General

The **General** page provides **System Information** and **Device Overall Status**. this information includes **model**, **Software** **Revision**, **Unit** **Alarm**, *state* of the **G-Zip Card**, **Packet** **Processor**, **Mod** **Card**, and **Demodulator** **Card**. On the right side, **Traffic** **Alarms**, **Redundancy, DCP** **Option, High Speed Option, Modulation,** and **NetSpec.** At last, there is a page button to see and set the **Ethernet**.

### Admin - SNMP

This page is used for **Contact information** and also to *read* and *set* **Trap IP** **(1-2)**, **Trap** **Version**, and the **Trap Community String**.

### Config - Modem

The **Network Spec** and the **Operating Mode** is right at the top of the page, The **Transmitter** and **Receiver** modules are similar, except for a few parameters, and the **Transmmiter** has more parameters that can be set. Some items includes the **DVB-S2 Frame, ModCod, Data Rate, Frequency, Spectrum,** and **Gold Code**.

### Config - Utilities

Here, you can see the **Circuit ID** module with **ID String**, **Utility Demo Mode** that can *disable* or *enable*. Next is the **Date & Time** module with the **RTC Time** and a **Time** **Sync** page button. Other parameters include **Frequency Reference**, **1:N Redundancy**, **Redundancy Mode**, **Active Image**, **Local Location**, and **Save Location**.

### Config - Mask

**Alarm Settings** are found on the page. These values can also be *set*. The following are found here**: Ext Reference**, **RX AGC**, **Es/No**, **Decompression Invalid**, **LNB**, **Etherenet Link Down,** and **AUPC**.

### Config - Test

The **Unit Test Mode** is foundhere. It also includes **BERT** information like the *state* of it, **Pattern**, **Total Errors**, **Total Bits**, and **Ave BER**. It also has a button to **Restart** the service.

### Config - LNB

**LNB** modules are on this page. Parameters of the module are the **DC Power Reference**, **Current Threshold Low**, **Current Threshold High**, and the **Current** and **Voltage**.

### Config - CID

Besides displaying the **MAC Address** of the device, the **Meta-Carrier Info** is displayed here. All input fields have a length limitation.

### Config - MEO

**Modem Status** like **Operating Mode**, **RX ModCod**, **TX ModCod**, **Local Es/No**, and the **Remote Es/No** are on here.

### Config - ASI

The **Interface ASI Table** is found on the page. Columns include are the **Mode**, **Terrestrial**, **PCR Re-Stamping** for both, the **Transmmiter** and the **Receiver**.

### Save Load CFG

The **Save Load CFG Table** is found here, Columns are the **Valid** and the **Name**.

### Status

**Unit Alarm,** **Status of the Unit, Traffic Alarm**, and **Traffic Status** are here. Also, **Local Es/No,** **ModCod State, Frequency Offset, Level, CnC Status**, and **General** information, including **Temperature, WAN Buffere Fill Status, PHC1 Buffer Fill Status, Minimum RX EsNo**. and **Baseband Frame Error Rate**.

### Status - Alarms

You can see the *active* **Alarms** from the **Unit, TX Traffic**, and the **RX Traffic**.

### Status - CPU (Version 1.0.0.15)

This page shows the **Aggregate CPU Usage** and **Core CPU Usage Table** information.

### Status - Logs

**Events** are seen on a table, with it's **Indicator, Description**, and **Date Time**. You can also **Clear** and **Refresh** events.

### Status - Info

**General Information** is here with **Circuit ID String**, **Serial Number,** **Software Revision,** **Active Image**, and **Model Number**.

### Status - IP Statistics

You can find **GIGE(1-2)** **Statistics**, **WAN Statistics**, **Optical Statistics**, **Monitor and Cotrol Statistics**, **Compression Statistics,** **Decompression Statistics,** **TX Data Throughput**, and **RX Data Throughput.** There are also three buttons to open **Clear IP Statistics**, **Clear** **Comp/Decomp Stats**, and **Clear All Statistics.**

### Status - Ethernet

Here is the **Ethernet Statistics Table** that can also be **Clear**, and **Refresh**.

### Status - MAC Table

The **MAC Table** is here, columns found are the **DBNum**, **CPU, P(1-4)**, **WAN,** and **Type.**

### Status - Packet Flows

From this page, you can **Clear** and **Refresh Statistics,** it also gives you the values of all the **Flows** in the system, and a **Summary** of them.

### Status - Router

From this page, you can **Clear** and **Refresh Statistics**, it can read **Router Counters,** **Router Errors**, and **Management Counters**.

### Status - Bridge

Like the last two pages, **Clear** and **Refresh** can be done on **Bridge**, and also read the **Bridge Counters**.

### Status - WAN

**Clear** and **Refresh** the **WAN Statistics**, read the **WAN Counters**, **Errors**, and **Detailed Satellite RX Errors**.

### Status - Header Comp

**Clear** and **Refresh** of the **Header Compression Statistics Table**.

### Status - QoS

**Clear** and **Refresh** of the **QoS Statistics Table**.

### Status - BB Statistics

**Clear** and **Refresh** of the Baseband Statistics.

### Interface - Ethernet/PIIC

**GBEI Interfaces** are here with **GBEI1** and **GBEI2,** also **Optical Ethernet,** **Status,** **PHC,** **PHC1,** and **PHC2.**

### Packet Processor

This page will only be polled if the **Packet Processor** is installed. On the page you can find **Model Number**, **Management Information**, **Switch Ports**, **WAN Interface**, **LAN Address**, **ARP**, and **Router.**

### Web Interface

Use this page to have access to the Web Interface provided by the device's web server. It is only possible in a LAN environment to have access to this page.
