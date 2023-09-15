---
uid: Connector_help_RGB_Networks_VMG2
---

# RGB Networks VMG2

This connector is used to monitor an RGB Networks VMG2.

## About

The VMG2 is a dense, hardware-based transcoder. The VMG2 chassis can be configured for the desired application by using the appropriate cards. Two types of cards are supported by the VMG2: the NPM (chassis controller), which controls redundancy within the chassis, and the TCM2(+), which performs the transcoding. Redundancy is a 1+1 hot standby for the NPM, and N+1 for the TCM cards.

Two external APIs are supported by the VMG2: there is SNMP support for traps and basic configuration information, and a full-featured XML-RPC interface for detailed configuration status and control. This connector only uses the XML-RPC interface.

Though several VMG2 chassis models exist, only the VMG-8 and the VMG-14 chassis are supported by this connector. The chassis are identical in terms of external API, and no configuration needs to be done within the connector.

The VMG2 API is very similar to the VMG1.

## Installation and Configuration

### Creation

This connector uses an HTTP connection and requires the following input during element creation:

**HTTP Connection:**

- **IP address/host:** The polling IP or URL of the destination, e.g. *10.11.12.13*.
- **IP port:** The IP port of the destination. The default port for the VMG is *8080*.
- **Bus address:** If the proxy server has to be bypassed, specify *byPassProxy.* This is enabled by default.

### Configuration

Credentials are required for the device to poll data from the VMG2. Those credentials can be filled in via the **Credentials** page button on the **General** page. Note that the default web interface of the VMG encrypts the credentials before sending them to the device. However, the connector does not automatically encrypt the credentials, so the user must then enter the encrypted values in DataMiner.

The default credentials are:

| **Clear Value** | **Encrypted Value** |                            |
|-----------------|---------------------|----------------------------|
| Username        | administrator       | 674e4e4c4743585a54475e4c57 |
| Password        | Admin               | 674e4e4c47                 |

## Usage

This connector contains 17 pages.

### General

This page displays general information about the connector: **Software Version**, **Chassis Type**, .

There are several controls on the page that allow you to manage the device: **Reboot**, **Restart,** .

The **Credentials.** button links to a page where you can specify a **Username** and **Password.**

### System Status

This page contains miscellaneous data regarding the system: **Alarms**, **Card Status**, .

### Cards

This page lists all cards present in the VMG2. The type of card (NPM or TCM) is detailed, along with more information such as **Status**, **Redundancy**, .

### Ports

This page displays two tables that provide information about the 8 ports of the active NPM Slots.

### Inputs

This page displays the Input Transport Streams, Input Programs and Input Elementary Streams.

You can add input using the three page buttons **Add Input TS...**, **Add Input Prog...**, and **Add Input ES**.

### Outputs

This page displays the Output Transport Streams, Output Programs and Output Elementary Streams.

You can create Transport Streams using the **Add MBR...** page button. Only multibitrate (MBT) transport stream are supported.

### Grooming

On this page, the **Grooming Table** lists all grooming links between an input and an output.

To add a new grooming link, go to the **Add Grooming** page, and then select the **Input Program Id** and the **MBR Id** to groom an input and an output.

### Alarms

This page contains the **Alarms** table and the **Events** Table.

### Network

This page displays the SNMP and NTP configuration.

### Inventory

This page displays miscellaneous parameters: **Controller**, **Backplane**.

### Power

This page displays information about the 6 power supplies.

### Dolby

This page displays the Dolby Audio parameters.

### Transcoder

This page displays the Transcoder Parameters: **Bitrate**, **PMT frequency**.

### Software Update

This page allows you to update the VMG2.

For now, only FTP update is supported. Select the **FTP URL**, enter your credentials and click the **Update** button.

### License

This page displays the license feature on this VMG2. The **Update.** page button provides access to the license management. A license can be updated by directly filling in the string key in the **Add License: Key** text box and clicking the **Update License** button.
