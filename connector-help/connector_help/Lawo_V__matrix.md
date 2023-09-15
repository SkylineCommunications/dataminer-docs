---
uid: Connector_help_Lawo_V__matrix
---

# Lawo V\_\_matrix

The Lawo V\_\_matrix is a software-defined IP core routing, processing, and multi-viewing platform.

In range 1.0.0.x and 1.1.0.x, the **Ember+** protocol is used to communicate with the device, which is a **smart-serial** way of communicating. The most important functions of the device are polled.

From range 2.0.0.x onwards, **WebSocket** communication is used instead.

From range 2.0.1.x onwards, the information is retrieved via **WebSocket** subscriptions to enhance update speed.

## About

### Version Info

| **Range**            | **Description**                                                                                                                            | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version. **It is not advised to use this range, except in case it was agreed to use Ember+ instead of the vendor-advised method.** | No                  | Yes                     |
| 1.1.0.x              | Ember 1.8 system support. Some parameters are no longer supported in this range.                                                           | No                  | Yes                     |
| 2.0.0.x              | WebSocket implementation.                                                                                                                  | No                  | Yes                     |
| 2.0.1.x \[SLC Main\] | DCF connections added.                                                                                                                     | Yes                 | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.7                    |
| 1.1.0.x   | 1.8                    |
| 2.0.0.x   | 1.10.598               |
| 2.0.1.x   | 1.11.2600              |

### Exported Components

| **Exported Connector**                                                                                  | **Description**    |
|--------------------------------------------------------------------------------------------------------|--------------------|
| [Lawo V\_\_matrix - IP Streaming](xref:Connector_help_Lawo_V__matrix_-_IP_Streaming)           | IP streaming.      |
| [Lawo V\_\_matrix - Multiviewer Slave](xref:Connector_help_Lawo_V__matrix_-_Multiviewer_Slave) | Multiviewer slave. |

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
<td>1.0.0.x/1.1.0.x</td>
<td><h4 id="serial-main-connection">Serial Main Connection</h4>
<p>This connector uses a smart-serial connection and requires the following input during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li>Interface connection:</li>
<li><ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
<li><strong>IP port</strong>: The IP port of the device. This is required. The default value is <em>9000</em>, <strong></strong> the range is <em>0</em> <strong></strong> to <em>65535</em>.</li>
</ul></li>
</ul></td>
</tr>
<tr class="odd">
<td>2.0.0.x/2.0.1.x</td>
<td><h4 id="http-main-connection">HTTP Main Connection</h4>
<p>This connector uses an HTTP connection and requires the following input during element creation:</p>
<p>HTTP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP or URL of the destination.</li>
<li><strong>IP port</strong>: The IP port of the destination (default: <em>80</em>).</li>
<li><strong>Device address</strong>: The bus address of the device. If the proxy server has to be bypassed, specify <em>BypassProxy</em>.</li>
</ul></td>
</tr>
</tbody>
</table>

## Usage

### General

This page contains general information about the device, such as the **Product**, **Company**, **Recovery Version** and **Uptime**.

### System

This page contains information about the operating state of the device, such as **PSU 1 Current In**, **PSU 2 Voltage Out**, **Temperature Alert Level**, **Temperature CPU**, etc.

It also contains the **QFSP Table**, with the **UW Level**, **dBm Level** and the **State** for that particular QSFP.

### PTP

This page contains information about the PTP of the device, such as **PTP Clock State**, **PTP Master Timeout** and the **PTP Agent Statistics Table**, which displays information about the PTP agents, such as **Syncs Received**, **Follow-ups received**, **Delay Requests Sent**, etc.

### RTP Receiver (range 1.0.0.x)

This page contains information about the RTP receiver of the device, such as **Legacy SDP Format** and **Generated SDP Format**, as well as the following tables:

- **RTP Sessions Table**: Contains information about the RTP sessions, such as Switch Type, Active Command, SDP A Command, etc.
- **Audio Receiver Table**: Contains information about the audio receivers, such as Audio Receiver Mode, Audio Receiver State, Blocked By, etc.
- **Video** **Receiver Table**: Contains information about the video receivers, such as Video Receiver Mode, Video Receiver State, Blocked By, etc.
- **Packet Stream Pairs** **Table**: Contains information about the packet stream pairs, such as Primary Drift, Primary M Packets Received, Secondary Drift Resolution, etc.

### RTP Receiver (range 1.1.0.x)

This page contains information about the RTP receiver of the device, such as **Legacy SDP Format**, as well as the following tables:

- **RTP Sessions Table**: Contains information about the RTP sessions, such as Switch Type, Active Command, SDP A Command, etc.
- **Audio Receiver Table**: Contains information about the audio receivers, such as Audio Receiver State and Command Preparation Time.
- **Video** **Receiver Table**: Contains information about the video receivers, such as Video Receiver State and Command Preparation Time.

### Video Transmitter Overview

This page displays a tree view that provides an overview of the video transmitter part of the device.

This tree structure shows the **video transmitter pools**, with underneath each pool the video transmitter pool **output pools**:

- Click a specific **video transmitter pool** to view the name of that video transmitter, its **Status Standard** and a table with the **Output Pools** for that device. The table includes information such as the Port Command Type, Generator, Lane, etc.
- Click a specific **output pool**, linked to a particular **video transmitter pool**, to view parameters related to this particular output pool/video transmitter pool combination, such as Video Transmitter, Port Command Type, Generator, etc.

The **RTP Sessions Table** contains information about the **RTP Sessions**, such as **Switch Type**, **Active Command**, **SDP A Command**, etc.

This page also contains a page button that provides access to the **Video Transmitter subpage**, which shows the information from the Video Transmitter Overview page in table format, in the following tables:

- **Video Transmitter Pool:** Displays the video transmitter name and **Status Standard**.
- **Video Transmitter Output:** Contains information about output pools linked to a particular video transmitter. In range 1.0.0.x, It contains information such as Video Transmitter, Port Command Type, Generator, etc. In range 1.1.0.x, it contains information such as VLAN ID, Port SDP A and Payload Type Command.

### I/O Ports

This page contains information about the I/O ports of the device in the **Output IO Ports** **Table**, including the Name, SDI In Phase, SDI Phase Reset, etc.

### Network Interfaces Overview

This page displays a tree view that provides an overview of the **Network Interfaces** of the device.

The tree structure shows the **network ports**, with underneath each port the linked **FGPA Lanes**:

- Click a specific **network port** to view the name of that network port, its Device Name, Total Multicast bytes, etc. A table with information about the **FGPA Statistics** is also displayed, with information such as the Maximum Throughput, TX Total Packets, TX Bytes per Second, etc.
- Click a specific **FPGA lane**, linked to a **network port**, to view parameters for that particular lane, such as Port Brief, Maximum Throughput, TX Total Bytes, etc.

This page also contains a page button that provides access to the **Network Interfaces subpage**, where you can find the information of the Network Interfaces Overview page in a table format, in the following tables:

- **Network Interfaces Table**: Displays the **Name** of the network ports, the **Briefs**, the **Maximum Throughput**, etc.
- **FPGA Statistics Table**: Displays statistics per lane, with each network interface linked to several lanes. This includes information such as Port Brief, Max. Throughput, TX Total Bytes, TX Packets per Second, etc.
- **Network Aggregate Statistics** **Table**: Displays statistics per network port (totaling all lanes). This includes information such as Total RX Unicast Bytes, RX Unicast Gigabytes per Second, Total Multicast Bytes, etc.

### Time Flows (available since version 1.1.0.1)

This page displays information about the aligners and the combinators.

- **Time Flows Aligners:** Displays the Name, Alert Level, Warning Threshold and Holdover Grains.
- **Time Flows Combinators:** Displays the Name, Required Type, Min Drift Tolerance, Quorum Command, Session Length Command and Drift Reference Frame.
