---
uid: Connector_help_RGB_Networks_VMG1
---

# RGB Networks VMG1

This connector is used to monitor an **RGB Networks VMG1**, a dense, hardware-based transcoder. The VMG1 chassis can be configured for the desired application through the use of the appropriate cards.

Two types of cards are supported by the VMG1: the NPM (chassis controller), which controls redundancy within the chassis, and the TCM, which performs the transcoding. Redundancy is a 1+1 hot standby for the NPM, and N+1 for the TCM cards.

## About

Two external APIs are supported by the VMG1: there is SNMP support for traps and basic configuration information, and a full-featured XML-RPC interface provides detailed configuration information and control. This connector only uses the XML-RPC interface.

The VMG1 API is very similar to the VMG2.

## Installation and Configuration

### Creation

HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

**HTTP Connection:**

- **IP address/host:** The polling IP or URL of the destination, e.g. *10.11.12.13*.
- **IP port:** The IP port of the destination. The default port for the VMG is *8080*.
- **Bus address:** If the proxy server has to be bypassed, specify *byPassProxy.* This is enabled by default.

### Configuration

The device needs credentials to poll data from the VMG1. Those credentials can be filled in on the "General" page, on the "Credentials" subpage. Note that the default web interface of the device encrypts the credentials before sending them to the device. The connector does not automatically encrypt the credentials, so the user should enter the encrypted values in DataMiner.

The default credentials are:

|          | **Clear Value** | **Encrypted Value**        |
|----------|-----------------|----------------------------|
| Username | administrator   | 674e4e4c4743585a54475e4c57 |
| Password | Admin           | 674e4e4c47                 |

## Usage

### General

This page displays general information about the connector: **Software Version**, **Chassis Type**, .

The page contains controls to manage the device: **Reboot**, **Restart**.

The **Credentials.** button links to a page where users can specify their **Username** and **Password**. (See "Configuration" section above)

### System Status

This page contains miscellaneous data about the system: **Alarms**, **Card Status**, .

### Cards

This page lists all cards present in the VMG1. The type of the card (NPM or TCM) is detailed with more information, such as **Status**, **Redundancy**, .

### Ports

This page displays two tables that provide information about the 8 ports of the active NPM Slots.

### Inputs

This page displays the input transport streams, input programs and input elementary streams.

It is possible to add input using the three page buttons on this page:

- **Add Input TS...**
- **Add Input Prog...**
- **Add Input ES...**

### Outputs

This page displays the output transport streams, output programs and output elementary streams.

It is possible to create transport streams using the **Add MBR...** page button. Only multibitrate (MBT) transport streams are supported.

### Grooming

On this page, the **Grooming Table** lists all grooming links between an input and an output.

To add a new grooming link, go to the **Add Grooming** page, and then select the **Input Program ID** and the **MBR ID** to groom an input and an output.

### Alarms

This page contains the **Alarms** table and the **Events** table.

### Network

This page displays the SNMP and NTP configuration.

### Inventory

This page displays miscellaneous parameters: **Controller**, **Backplane**, .

### Power

This page displays information about the 6 power supplies.

### Dolby

This page displays the **Dolby Audio** parameters.

### Transcoder

This page displays the transcoder parameters: **Bitrate**, **PMT frequency**, .

### Software Update

This page allows you to update the VMG1.

For now, only FTP update is supported. Select the **FTP URL**, enter your credentials and click the **Update** button.

### License

This page displays the license feature on this VMG1. The **Update.** page button provides access to the license management. A license can be updated by directly filling in the string key in the **Add License: Key** text box and clicking the **Update License** button.
