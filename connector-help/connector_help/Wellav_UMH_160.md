---
uid: Connector_help_Wellav_UMH_160
---

# Wellav UMH 160

The **Wellav UMH 160** connector is used to monitor and control a **Wellav UMH 160** IRD device.

## About

This connector allows the user to retrieve information about the input and output streams of the device (bit rates, frequency, etc.).

Data is retrieved via the SNMP protocol.

### Version Info

| **Range** | **Description**                                                                                                   | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                                                   | No                  | Yes                     |
| 1.1.0.x          | Skyline implementation of new range for device with older firmware which was not supported by the previous range. | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                                   |
|------------------|-------------------------------------------------------------------------------|
| 1.0.0.x          | Unknown                                                                       |
| 1.1.0.x          | Hardware version: \[V123\]2010.08.04 Software version: \[150.0110\]2012.11.12 |

## Installation and Configuration

### Creation

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
<td><h4 id="snmp-main-connection">SNMP Main connection</h4>
<p>This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:</p>
<p>SNMP Connection:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device, e.g. <em>10.11.12.13</em>.</li>
</ul>
<p>SNMP Settings:</p>
<ul>
<li><strong>Port number</strong>: The port of the connected device, by default <em>161</em>.</li>
<li><strong>Get community string</strong>: The community string used when reading values from the device. The default value is <em>public</em>.</li>
<li><strong>Set community string</strong>: The community string used when setting values on the device. The default value is <em>private</em>.</li>
</ul></td>
</tr>
<tr class="odd">
<td>1.1.0.x</td>
<td><h4 id="snmp-main-connection-1">SNMP Main Connection</h4>
<p>This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:</p>
<p>SNMP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
</ul>
<p>SNMP Settings:</p>
<ul>
<li><strong>IP port</strong>: The IP port of the device.</li>
<li><strong>Get community string</strong>: The community string used when reading values from the device. The default value is <em>public</em>.</li>
<li><strong>Set community string</strong>: The community string used when setting values on the device. The default value is <em>private</em>.</li>
</ul>
<h4 id="serial-connection">SERIAL Connection</h4>
<p>This version of the connector also uses a serial connection to retrieve some data from the HTML pages of the device's web UI (for which SNMP is not available). As such, the following information also has to be specified during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li>Interface connection:
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
<li><strong>IP port</strong>: The IP port to retrieve data via HTTP, by default <em>80</em>.</li>
</ul></li>
<li>The timeout is set to 2500 ms by default, because the device can be relatively slow when responding to a request.</li>
</ul></td>
</tr>
</tbody>
</table>

## Usage (Range 1.0.0.x)

This connector contains 6 pages.

### General Page

This page displays the connection settings of the device (**IP address**, etc.) and the status of the two input slots.

### Input

This page displays parameters related to the three kinds of inputs: Tuner, ASI and IP. For each input, you can click a **Program** button to display the contained programs.

### Output

This page displays data about the current decoding program. You can find the programs list displayed in a table, and select the current program with the **Program Index** selection box.

Information about ASI and IP output are also available here.

### Status

This page contains various parameters with input and output information (lock, bit rates, etc.). These parameters are the most frequently polled by the connector (every 10 seconds by default).

### Alarms

This page displays various alarms. These parameters are not polled from the device, but updated when the associated trap is received.

### Web Interface

The native web interface of the device.

The client machine has to be able to access the device. If not, it will not be possible to open the web interface.

## Usage (Range 1.1.0.x)

### Status

This page displays the main parameters regarding the status of the:

- **Receiver**: Showing the status of the **Signal**, **BER**, **C/N**, the **Input** **Level**, the **Total** and **Effective** **TS** **Rate**.
- **Outputs**: Showing the index of the **Playing Program** and the **PIDs** of **Video**, **Audio1** and **Audio2**.
- **CI**: Showing the status of the **CI Slot 1** and **2**.

### Input

This page displays the configuration of the **Receiver**, i.e. the type of **Source**, **LNB** (**Frequency**, **Voltage** and **22KHz**), **Satellite** **Frequency**, **Symbol** **Rate** and **CI MultiDecryption mode.** **Tuner** **Type**, **QAM** and **COFDM** information are also displayed.

The page button at the bottom of the page displays the **Program** **List** table, which contains information regarding all the available received programs.

### Decoder Setup

This page displays the configuration of:

- **Video**, i.e. **Standard**, **Screen** **Mode**, **Fail** **Mode**, **DVB** **Subtitle** and **EBU** **Subtitle**
- **Audio,** i.e. **Level, Mode** and **Language**
- **SDI/HDMI**, i.e. the **Video Format**

In addition, the name of the **Playing** **Program** is displayed at the top of the page.

### IP Input

This page displays the configuration of the **Channel**, the **IP Board**, the **Host** and the **FEC parameters.**

### IP Output

This page displays a table with information about the **Channels** in transmission.

### System

This page displays the setup of the **Local** device (i.e. **IP** **Address**, **Network** **Mask**, **Gateway**, **MAC** **Address**, **HW** and **SW** **Versions** etc.) and the **BISS settings**.

### Web Interface

This page allows you to access the web UI of the device upon login. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
