---
uid: Connector_help_VPG_TIMS_SDI
---

# VPG TIMS SDI

The main purpose of the **VPG TIMS SDI** connector is to monitor an SDI monitor and configure its channels.

## About

This is an SNMP and serial protocol. Channel-specific information and general alarms are received via an XML file requested through serial communication. More detailed traffic data and status messages are retrieved via SNMP and displayed in tables.

## Installation and configuration

### Creation

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.
- **Device address**: Required. Range: *1-16*.

**SNMP Settings:**

- **Port number**: The port of the connected device, e.g. *161*.
- **Get community string**: The community string used when reading values from the device, e.g. *public*.
- **Set community string**: The community string used when setting values on the device, e.g. *private*.

#### Serial connection

This connector also uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION:**

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device. This value is *80* by default and cannot be edited.
- **Bus address**: The bus address of the device. Required. Range: *1-16.*

## Usage

### General

This page displays general information concerning the current channel: **Channel Number, Signal Present, Line Stream Data Rate**, etc.

### Alarm Status

On this page, you can find the different alarm statuses for the current channel: **Loss of Synchronisation, Audio Group Error, AV Delay Alarm, ANC IDA Error**, etc.

### Input Status

On this page, the **Input Status Table** displays the signal status for each channel: **Sync Status, Input Status**, etc.

### Configuration

In the **Channel Config Table** on this page, you can view and edit the channel configuration: **Service Name (Channel), Switching Ctrl, Snmp Informs.**

In the **IP Decode Config Table**, you can edit the **Input Mode,** **VLAN**, and **Source/Destination IP Address/Port.**

### Notification

On this page, the **Notification Table** displays the **Type, Destination** (IP address), **Sent Count**, and **Notification Alarm.**

### ASI Status

This page contains three tables with status information for the channels configured in ASI mode*:*

- The **ASI Status Table** displays the **ASI Status Signal,** **ASI Status Transport Stream ID,** **ASI Status** **PAT Version**, etc.
- The **ASI Status Program Table** displays amongst others the **ASI Status Prog Provider, ASI Status Prog Name**, etc.
- The **ASI Status PCR Table** displays the **ASI Status PCR Rate, ASI Status PCR Distance Avg**, etc.

### SDI Status

This page contains information referring only to the SDI channels:

- The **SDI Status Table** displays the **SDI Status Signal**, **SDI Status Video Standard**, **SDI Status EDH**, etc.
- The **SDI** **Status Audio Table** shows the **SDI Status Audio Sample Rate** and the **SDI Status Audio** **Level.**

### Service Info

On this page, the **Service Info** **Table** displays service-specific information such as the **Service Provider,** **Service PMT PID, Service Rate**, etc.

### Embedded Web Server

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
