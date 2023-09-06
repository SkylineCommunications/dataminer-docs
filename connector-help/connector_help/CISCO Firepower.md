---
uid: Connector_help_CISCO_Firepower
---

# CISCO Firepower

This connector uses SNMP or HTTP communication in order to monitor a CISCO Firepower device. It retrieves fan statistics, monitor statistics, power supply statistics and more. It also provides an overview of how all these components are behaving. It displays the average, maximum and minimum values for specific parameters such as the fan speed and the motherboard input and output current.

## About

### Version Info

| **Range**            | **Key Features**      | **Based on** | **System Impact** |
|----------------------|-----------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | SNMP initial version. | \-           | \-                |
| 2.0.0.x \[SLC Main\] | HTTP initial version. | \-           | \-                |

### Product Info

| **Range** | **Device Firmware Version** |
|-----------|-----------------------------|
| 1.0.0.x   | N/A                         |
| 2.0.0.x   | N/A                         |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |
| 2.0.0.x   | No                  | No                      | \-                    | \-                      |

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
<td>1.0.0.x</td>
<td>SNMP connection - Main
<p>This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:</p>
<p>SNMP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
</ul>
<p>SNMP Settings:</p>
<ul>
<li><strong>Port number</strong>: The port of the connected device, by default <em>161</em>.</li>
<li><strong>Get community string</strong>: The community string used when reading values from the device, by default <em>public</em>.</li>
<li><strong>Set community string</strong>: The community string used when setting values on the device, by default <em>private</em>.</li>
</ul></td>
</tr>
<tr class="odd">
<td>2.0.0.x</td>
<td>HTTP Connection - Main
<p>This connector uses an HTTP connection and requires the following input during element creation:</p>
<p>HTTP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP or URL of the destination.</li>
</ul></td>
</tr>
</tbody>
</table>

## Usage

### General Page

This page displays general system information, including the **System** **Description**, **Model**, **System Up Time**, **System Contact**, **System Name**, **System Location**, **CPU Usage** and **Memory Usage**.

The **System Services** page button displays a subpage with the status (*Active* or *Not Active*) for the following layers:

- Physical
- Data Link
- Network
- Transport
- Session
- Presentation
- Application

### SM Monitor Page

This page contains the **SM Monitor Statistics Table**, which contains information such as **CPU Total Load Average**, **Disk File System Count**, **Memory Free**, **Memory Total**, **OS Version**, etc.

### Chassis Page

This page displays the following statistics tables:

- **Fan Statistics Table**: Includes information such as the current, average, maximum and minimum value of the fan speed.
- **Fan Module Statistics**: Includes information such as the current, average, maximum and minimum value of the ambient temperature.
- **Chassis Statistics**: Includes information such as the current, average, maximum and minimum value of the input and output power.
- **Power Supply Statistics**: Includes information such as Ambient Temperature, Input Volts, Output Volts, Output Current, Output Power and PSU Temperature.
- **IO Card Statistics**: Includes information such as Ambient Temperature, DIMM Temperature and Processor Temperature.

### Motherboard Page

This page displays the following tables with motherboard statistics:

- **Motherboard Power Statistics** **Table**: Includes information such as the Consumed Power, Input Current and Input Voltage.
- **Motherboard Temperature Statistics Table**: Includes information such as Temperature Sensor IO, Temperature Sensor Rear, Temperature Sensor Rear L and Temperature Sensor Rear R.

### Processor Page

This page displays the **Processor Environment Statistics Table**, which for example includes the **current, average, max and min** value of the **input current and temperature**.

### Ethernet Statistics Page

This page displays several Ethernet statistics tables, for example:

- **Error Statistics Table**: Includes the columns Align, Deferred Tx, Frame Check Sequence, Internal MAC Rx, Internal MAC Tx and Out Discard.
- **Loss Statistics Table**: Includes the columns SQE Test Delta, Carrier Sense, Excess Collision, Giants and Late Collision.
- **Pause Statistics Table**: Includes the columns Receive Pause, Resets and Transmit Pause.

### Interface Detailed Page

This page displays the Interface Details Table, in which you can among others find the following information:

- **Name**
- **Bandwidth**
- **Utilization**
- **Utilization Percentage**
- **Type**
- **MTU**
- **Duplex**
- **Physical Address**
- **Administrator Status**

## Revision History

DATE VERSION AUTHOR COMMENTS02/10/2017 1.0.0.1 RSA , Skyline Initial version04/30/2018 1.0.0.2 JGA , Skyline Fixed MultipleGetNext option05/23/2018 1.0.0.3 JGA , Skyline Added System Information, System Services and Network Interface Table27/06/2018 1.0.0.4 AIG, Skyline Quick protocol review20/10/2021 2.0.0.1 MFR, Skyline NF: HTTP initial version.
