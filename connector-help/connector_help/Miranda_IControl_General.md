---
uid: Connector_help_Miranda_IControl_General
---

# Miranda IControl General

The Miranda IControl General is a system controller. This connector displays all connected devices. For each device, the polling can be configured. The connector uses a poll action to sequentially poll all the cards it supports.

**SNMPv2** is used to retrieve all device information. The connector also supports **SNMP traps.**

From version **2.0.0.16** onwards, sets can be made to cards **HCO-3901** and **HMP-1801**.

From version **2.0.0.17** onwards, sets can be made to cards using the Oxtel protocol implementation for cards **DSK-3901** and **LGK-3901**. The IP and port number of the card need to be added. You can do so by going to the **General page** of each card that you want to use and adding it to the **Serial Configuration** parameter.

## About

### Version Info

| **Range**              | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   | **DCF Integration** | **Cassandra Compliant** |
|------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 2.0.0.x                | Initial version.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  | No                  | Yes                     |
| 2.0.1.x \[For DM 7.5\] | Only for DataMiner 7.5. Parameter sets on output and switch mode on HCO card added.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               | No                  | Yes                     |
| 2.0.2.x                | Reviewed standalone parameters and added new parameters for cards LGK-3901 and DSK-3901.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          | No                  | Yes                     |
| 2.0.3.x \[SLC Main\]   | Support added for HDA 1851 card.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  | No                  | Yes                     |
| 3.0.0.x                | Initial version. **Reason**: This is a completely new connector version that was created from scratch. The impact of the changes is such that a new range was required: the information is no longer polled via a serial connection, no IDs have been preserved, etc. **Impact**: All previous references can no longer be used. If they are reused, it can occur that entries in the database, e.g. for trend data, have a different meaning. In this range, all data is polled and can be controlled/set via iControl's REST API. (An iControl license is required for this.) Only the general system parameters are still polled over SNMP like in the 2.0.2.x range. This connector range currently supports **XVP-3901**, **SCO-1421**, **SDA-1402** and **IRG-3401** cards. | Yes                 | Yes                     |
| 3.0.1.x \[Obsolete\]   | Based on 3.0.0.15. Changed the discretes of parameter Program Output Status present in Miranda IControl General - SCO-1421 DVEs.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  | Yes                 | Yes                     |
| 3.0.2.x                | Based on 3.0.1.8. Adds connection for HCO GSM Alarms. Supports HCO 3901 cards. **Impact**: Element reconfiguration is needed.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     | Yes                 | Yes                     |

### Product Info

| **Range**              | **Supported Firmware** |
|------------------------|------------------------|
| 2.0.0.x                | Unknown                |
| 2.0.1.x \[For DM 7.5\] | Unknown                |
| 2.0.2.x                | Unknown                |
| 2.0.3.x                | Unknown                |
| 3.0.0.x                | Unknown                |
| 3.0.1.x                | Unknown                |
| 3.0.2.x                | Unknown                |

### Exported Connectors

| **Exported Connector**                                                                                                 | **Description**                                                                       |
|------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------|
| [Miranda IControl SDA-1402](xref:Connector_help_Miranda_IControl_SDA-1402)                                         | ASI distribution amplifier with EQ and reclocking (3.0.0.x)                           |
| [Miranda IControl EAP-1101](xref:Connector_help_Miranda_IControl_EAP-1101)                                         | Audio processor (prior to version 2.0.0.x)                                            |
| [Miranda IControl HCO-182x](xref:Connector_help_Miranda_IControl_HCO-182x)                                         | HD/SD/ASI changeover (prior to version 2.0.0.x)                                       |
| [Miranda IControl IRD-3802](xref:Connector_help_Miranda_IControl_IRD-3802)                                         | IRD (prior to version 2.0.0.x)                                                        |
| [Miranda IControl LGK-3901 1101](xref:Connector_help_Miranda_IControl_LGK-3901_1101)                             | Logo inserter/DSK (prior to version 2.0.0.x)                                          |
| [Miranda IControl SCO-1421](xref:Connector_help_Miranda_IControl_SCO-1421)                                         | ASI changeover (prior to version 2.0.0.x)                                             |
| [Miranda IControl DCO-1781](xref:Connector_help_Miranda_IControl_DCO-1781)                                         | 2/4 AES changeover (prior to version 2.0.0.x)                                         |
| [Miranda IControl SCP-1121](xref:Connector_help_Miranda_IControl_SCP-1121)                                         | SDI control probe (prior to version 2.0.0.x)                                          |
| [Miranda IControl General - XVP-3901](xref:Connector_help_Miranda_IControl_General_-_XVP-3901)                 | Video processor (prior to version 2.0.0.x)                                            |
| [Miranda IControl General - AMX-3981](xref:Connector_help_Miranda_IControl_General_-_AMX-3981)                 | Multiplexer (embedder) (prior to version 2.0.0.x)                                     |
| [Miranda IControl General - ADX-3981](xref:Connector_help_Miranda_IControl_General_-_ADX-3981)                 | De-multiplexer (de-embedder) (prior to version 2.0.0.x)                               |
| [Miranda IControl General - HLP-1801](xref:Connector_help_Miranda_IControl_General_-_HLP-1801)                 | Lip-sync probe (prior to version 2.0.0.x)                                             |
| [Miranda IControl General - HDC-1861](xref:Connector_help_Miranda_IControl_General_-_HDC-1861)                 | HD downconverter (prior to version 2.0.0.x)                                           |
| [Miranda IControl General - ADC-1722](xref:Connector_help_Miranda_IControl_General_-_ADC-1722)                 | Audio AD converter (prior to version 2.0.0.x)                                         |
| [Miranda IControl General - HDA-1931](xref:Connector_help_Miranda_IControl_General_-_HDA-1931)                 | HD video distribution amplifier (prior to version 2.0.0.x)                            |
| [Miranda IControl General - VDA-1002](xref:Connector_help_Miranda_IControl_General_-_VDA-1002)                 | Video distribution amplifier (prior to version 2.0.0.x)                               |
| [Miranda IControl General - WDA-1001](xref:Connector_help_Miranda_IControl_General_-_WDA-1001)                 | Word clock distribution amplifier (prior to version 2.0.0.x)                          |
| [Miranda IControl General - ADA-1033](xref:Connector_help_Miranda_IControl_General_-_ADA-1033)                 | Audio distribution amplifier (prior to version 2.0.0.x)                               |
| [Miranda IControl General - ADX-102](xref:Connector_help_Miranda_IControl_General_-_ADX-102)                   | Imaging card (prior to version 2.0.0.x)                                               |
| [Miranda IControl General - KMX-3901 OUT](xref:Connector_help_Miranda_IControl_General_-_KMX-3901-OUT)       | Dual-head output (prior to version 2.0.0.x)                                           |
| [Miranda IControl General - KMX-3901 IN](xref:Connector_help_Miranda_IControl_General_-_KMX-3901-IN)         | IP input module (prior to version 2.0.0.x)                                            |
| [Miranda IControl General - DSK-3901](xref:Connector_help_Miranda_IControl_General_-_DSK-3901)                 | 3G/HD/SD downstream keyer (prior to version 2.0.0.x)                                  |
| [Miranda IControl General - HCO-3901](xref:Connector_help_Miranda_IControl_General_-_HCO-3901)                 | 3G/HD/SD/ASI changeover with clean Switch and ALC (prior to version 2.0.0.x)          |
| [Miranda IControl General - REF-1801](xref:Connector_help_Miranda_IControl_General_-_REF-1801)                 | Reference module with optional sync pulse generator (prior to version 2.0.0.x)        |
| [Miranda IControl General - HMP-1801](xref:Connector_help_Miranda_IControl_General_-_HMP-1801)                 | HD/SD solid-state media server (prior to version 2.0.0.x)                             |
| [Miranda IControl General - DDA-1113](xref:Connector_help_Miranda_IControl_General_-_DDA-1113)                 | Digital audio distribution amplifier (prior to version 2.0.0.x)                       |
| [Miranda IControl General - FIO-19TT](xref:Connector_help_Miranda_IControl_General_-_FIO-19TT)                 | 3G/HD/SD electrical-to-fiberoptic converter (prior to version 2.0.0.x)                |
| [Miranda IControl General - FIO-19RR](xref:Connector_help_Miranda_IControl_General_-_FIO-19RR)                 | 3G/HD/SD fiberoptic-to-electrical converter (prior to version 2.0.0.x)                |
| [Miranda IControl General - FIO-19RT](xref:Connector_help_Miranda_IControl_General_-_FIO-19RT)                 | 3G/HD/SD bi-directional fiberoptic to electrical converter (prior to version 2.0.0.x) |
| [Miranda IControl General - VEA-1002](xref:Connector_help_Miranda_IControl_General_-_VEA-1002)                 | Analog video distribution amplifier (prior to version 2.0.0.x)                        |
| [Miranda IControl General - RFS-0886](xref:Connector_help_Miranda_IControl_General_-_RFS-0886)                 | Router frame sync (prior to version 2.0.0.x)                                          |
| [Miranda IControl General - FIO-19T](xref:Connector_help_Miranda_IControl_General_-_FIO-19T)                   | 3G/HD/SD electrical- to-fiberoptic converter                                          |
| [Miranda IControl General - AMX-1842](xref:Connector_help_Miranda_IControl_General_-_AMX-1842)                 | High-quality embedder                                                                 |
| [Miranda IControl General - Chassis Densite](xref:Connector_help_Miranda_IControl_General_-_Chassis_Densite) | Chassis Densite                                                                       |
| [Miranda IControl General - IRG-3401](xref:Connector_help_Miranda_IControl_General_-_IRG-3401)                 | ASI gateway                                                                           |
| [Miranda IControl General - HCP-1801](xref:Connector_help_Miranda_IControl_HCP-1801)                               | HCP-1801 SDI Video and Embedded Audio Control Probe (available from 3.0.1.7 onwards)  |
| [Miranda IControl General - HDA-1851](xref:Connector_help_Miranda_IControl_General_-_HDA-1851)                 | HDA 1851 Card                                                                         |

## Configuration

### Connections

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Connections</strong></td>
</tr>
<tr class="even">
<td>2.0.x.x</td>
<td>SNMP Main connection
<p>This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:</p>
<p>SNMP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
</ul>
<p>SNMP Settings:</p>
<ul>
<li><strong>Port number</strong>: The port of the connected device, by default <em>161</em>.</li>
<li><strong>Get community string</strong>: The community string used when reading values from the device, by default <em>public</em>.</li>
<li><strong>Set community string</strong>: The community string used when setting values on the device, by default <em>private</em>.</li>
</ul>
<h4 id="serial-connection">Serial connection</h4>
<p>This connector uses a serial connection and requires the following input during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li>Interface connection:</li>
<li><ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
<li><strong>IP port</strong>: The IP port of the device.</li>
</ul></li>
</ul></td>
</tr>
<tr class="odd">
<td>3.0.x.x</td>
<td><h4 id="snmp-main-connection">SNMP Main Connection</h4>
<p>This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:</p>
<p>SNMP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
</ul>
<p>SNMP Settings:</p>
<ul>
<li><strong>Port number</strong>: The port of the connected device, by default <em>161</em>.</li>
<li><strong>Get community string</strong>: The community string used when reading values from the device, by default <em>public</em>.</li>
<li><strong>Set community string</strong>: The community string used when setting values on the device, by default <em>private</em>.</li>
</ul>
<h4 id="http-connections">HTTP Connections</h4>
<p>This connector also uses three HTTP connections and requires the following input during element creation:</p>
<p>HTTP CONNECTION 1:</p>
<ul>
<li>Interface connection:</li>
<li><ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
<li><strong>IP port</strong>: The IP port of the device, by default <em>5955</em>.</li>
</ul></li>
</ul>
<p>HTTP CONNECTION 2</p>
<ul>
<li>Interface connection:</li>
<li><ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
<li><strong>IP port</strong>: The IP port of the device, by default <em>5953</em>.</li>
</ul></li>
</ul>
<p>HTTP CONNECTION 3</p>
<ul>
<li>Interface connection:</li>
<li><ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
<li><strong>IP port</strong>: The IP port of the device, by default <em>5951</em>.</li>
</ul></li>
</ul>
<p>HTTP CONNECTION 4</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
<li><strong>IP port</strong>: The IP port of the device, by default <em>5957</em>.</li>
</ul></td>
</tr>
</tbody>
</table>

## Usage (Range 2.0.x.x)

### General

This page contains the main DVE table.

The **Device Table** contains the **Device Name**, **Device Type**, **Custom Name**, and **IDX List**. It allows you to **Enable Polling**, **Enable DVE**, and add a **Label** for each device. For devices that are no longer available, the option **Remove Missing Device** is available.

Below the table, a **Refresh** button is available that can be used to manually refresh the table.

The page also contains the parameters **Status Info**, **Last Poll Duration**, **System Up Time**, **System Contact**, **System Name**, and **Communication Status.**

### Chassis

On this page, you can find the **Chassis Intrusion**, **Chassis Power Overload**, **Chassis Main Power Fault**, **Chassis Drive Fault**, **Chassis Power Control Fault**, and **Chassis Cooling Fan Fault**. There are also page buttons that provide access to the value tables of all DVEs created by the system. These value tables are used to show values in the corresponding protocols.

On each of the subpages, a **Refresh** button is available, which allows you to poll all parameters of a specific device again.

### CPU

This page displays the **User** name, the **System** being used, the **One Minute Load**, **Five Minute Load,** **Fifteen Minute Load**, **CPU Idle**, **CPU 1 Temperature**, and **CPU 2 Temperature**.

### Temperature

On this page, you can find the **Ambient**, **Planar**, **Memory**, **CPU 1**, and **CPU 2** temperature.

### Database

This page contains **SQL** values, including the **IsAlive** parameter, **Total Buffer Hits**, **Total Clients**, **Total Queries**, **Total Error Queries**, and **Disk Blocks Reads**.

### Disk

This page displays the **Total Space**, **Disk Available Space**, **Disk Used Space**, **Disk Percentage Used Space**, **Disk Reads**, and **Disk Temperature.**

### Failover

This page displays the failover **Status**, **Role**, **Configured IP**, **Current IP**, **Take-Over Mode**, and **Taken Over IP**.

### Fan

This page displays all fans: **1A**, **2A**, **3A**, **4A**, **5A**, **1B**, **2B**, **3B**, **4B**, **5B**, and the **Redundancy** **Fan**.

### Memory

This page displays the parameters **Swap Total**, **Swap Available**, **Swap percentage**, **Buffer**, **Server Memory Cached**, **Physical Memory Available**, **Memory Cached**, **Memory Buffer**, **Application Resident Memory**, and **Application Virtual Memory**.

### Process

This page displays the **Total Users**, **Total Processes**, **GSM Process**, **RMID Process**, **GSM Virtual Memory**, **RMID Virtual Memory**, **SSHD Process**, **Gateway Process**, **Lookup Process**, **Lookup Telenet Check**, **Router Telenet Check**, **Tomcat Process**, **Virtual Server Process**, **Densite Virtual memory**, **Gateway Virtual Memory**, **Lookup Virtual memory**, **Router Manual Virtual Memory**, **Tomcat Virtual memory**, **Virtual Server Memory**, and **Densite Process.**

### Voltage

On this page, you can find the **V-core Voltage**, **Voltage**, **Voltage 1 AUX 05**, **Voltage 1 AUX 08**, **Voltage Power Supply**, **Voltage 1 Lom Fail**, **Voltage 1 AUX Fail**, **Voltage CPU 1 Memory**, **Voltage CPU 1 VTT Fail**, and **Voltage 3.3V**.

## Usage (Range 3.0.x.x)

### General

This page contains the main DVE table. The **Card Table** contains the **Device Name**, **Type**, **Custom Name**, and **Connection Number**. It allows you to **Enable Polling**, **Enable DVE** and add a **Label** for each device.

Below the table, a **Refresh** button is available that can be used to manually refresh this table. There is also a **Status Info** and **Last Poll Duration** parameter. For devices that are no longer available, the option **Remove Missing Device** is available.

To enable polling, the **User** and **Password** need to be configured via the **Configure Session** page button.

### DCF Tables

This page contains the XVP3901 DCF Inputs and Outputs tables.

### Chassis

This page contains page buttons that provide access to the value tables of all DVEs created by the system. These value tables are used to show values in the corresponding connectors.

Note: For now, only the XVP-3901 card is supported.

## Notes

The connector supports traps (1.3.6.1.4.1.3872.11.4.\*).
