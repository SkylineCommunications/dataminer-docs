---
uid: Connector_help_Nevion_Virtuoso_MI
---

# Nevion Virtuoso MI

This is a DataMiner connector for the Nevion Virtuoso MI, a media server designed for broadcast carrier-class applications. The connector uses an HTTP connection to allow monitoring of the Nevion Virtuoso MI.

## About

### Version Info

| **Range**            | **Key Features**                                    | **Based on** | **System Impact**                                                                         |
|----------------------|-----------------------------------------------------|--------------|-------------------------------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                    | \-           | \-                                                                                        |
| 1.0.1.x \[SLC Main\] | SNMP traps implemented.                             | 1.0.0.1      | Existing elements need to be reconfigured before the new connection will be taken in use. |
| 1.1.0.x \[SLC Main\] | Support added for firmware using TXP communication. | \-           | Most parameters present in previous ranges do not exist in this range.                    |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.2.14                 |
| 1.0.1.x   | 1.2.14                 |
| 1.1.0.x   | 2.10.8                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (fixed value: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

### Initialization

To make sure the connector can retrieve data, fill in the **Login Credentials** of the device on the **Settings** page.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element using this connector consists of the data pages detailed below.

### General

This page displays basic information about the device, e.g. **Device Name**, **Software Version**.

The page also contains page buttons to the following subpages:

- **General Alarms**: Lists alarms and severities.
- **SNMP**: Contains SNMP settings.
- **Daylight Saving Time**: Contains all daylight-saving time settings.
- **Time**: Contains settings related to the local time zone, reference clock, and SNTP.

### Definitions

This page displays the types of alarms that have been defined and their behavior, e.g. **Alarm Description**, **Send SNMP Trap**.

The page also contains a page button to the **Limits** subpage, which lists all thresholds for alarms to be triggered.

### Alarms

This page displays basic logging and filter information, e.g. **Sequence Number**, **Log Size**.

The page also contains a page button to the **Group Lists** subpage, which displays all alarms grouped in specific lists.

### Features

This page displays information about the licenses installed for each slot and the services they enable, e.g. **Filename**, **Is Activated**.

### Shelf

This page displays information about the physical location of the modules, e.g. **Position**, **Software Version**.

### Ethernet

This page displays general information about each Ethernet interface and its severities, e.g. **Speed/Duplex Mode**, **Top Severity**.

The page also contains page buttons to the following subpages:

- **Routing**: Displays routing information for each Ethernet interface.
- **Status**: Displays metrics for received and transmitted packets for each Ethernet interface.
- **Sync Input**: Displays information regarding the sync input for each Ethernet interface.

### Network

This page displays network information for each interface, e.g. **Allow Management Traffic**, **Allow NMOS mDNS-SD**.

The page also contains a page button to the **Network Routing** subpage, which displays routing information for each interface.

### NetworkR

This page displays NetworkR information for each interface, e.g. **Allow Management Traffic**, **Allow NMOS mDNS-SD**.

The page also contains a page button to the **NetworkR Routing** subpage, which displays routing information for each interface.

### Settings

This page allows you to fill in the credentials in order to **enable polling** and displays the configuration of the device.

### Slot

This page displays basic information about the slot, e.g. **Product Name**, **Model**.

The page also contains page buttons to the following subpages:

- **Slot Configuration**: Lists slot configuration and memory usage information.
- **Slot Definitions**: Lists the type of alarms that are defined and their threshold value.
- **Slot Alarms**: Lists alarms.
- **Slot Shelf**: Lists information regarding the inserted card.

### Slot Ethernet

This page displays general information about the Ethernet interface of each slot, e.g. **Speed/Duplex Mode**, **PTP Support**.

The page also contains page buttons to the following subpages:

- **Slot Routing**: Displays routing information for the Ethernet interface of each slot.
- **Slot Status**: Displays metrics for received and transmitted packets for the Ethernet interface of each slot.
- **Slot Alarms**: Displays the severities for the Ethernet interface of each slot.

### Slot SFP

This page displays information about the SFP, e.g. **SFP Present**, **SFP Mode**.

The page also contains page buttons to the following subpages:

- **Slot SFP Routing**: Lists SFP routing information.
- **Slot SFP Channels**: Lists information about each specific SFP channel.

### Slot Generic UDP Input

This page displays information about the generic UDP input, e.g. **UDP Maximum Rate**, **Current RTP SSRC**.

The page also contains page buttons to the following subpages:

- **Generic UDP Input Routing**: Lists routing information for the generic UDP input.
- **Generic UDP Input Alarms**: Lists current alarms for the generic UDP input.
- **Generic UDP Input SIPS**: Lists SIPS information for the generic UDP input.
- **Generic UDP Input IP Source**: Lists IP source information for the generic UDP input.

### Slot IP Input

This page displays information about the IP inputs, e.g. **Enabled**, **Initial Rate**.

The page also contains page buttons to the following subpages:

- **IP Inputs Routing**: Lists routing information for the IP inputs.
- **IP Inputs Alarms**: Lists current alarms for the IP inputs.
- **IP Inputs SIPS**: Lists SIPS information for the IP inputs.
- **IP Inputs IP Source**: Lists IP source information for the IP inputs.

### Slot Generic UDP Output

This page displays information about the generic UDP output, e.g. **Minimum Depth**, **Maximum Size**.

The page also contains page buttons to the following subpages:

- **Generic UDP Output Routing**: Lists routing information for the generic UDP output.
- **Generic UDP Output Alarms**: Lists current alarms for the generic UDP output.
- **Generic UDP Output Destination**: Lists destination information for the generic UDP output.
