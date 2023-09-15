---
uid: Connector_help_Arris_D5
---

# Arris D5

With this connector it is possible to monitor **Arris D5** devices with SNMP.

## About

The **Arris D5** will monitor the **Arris D5** Edge QAM devices.

Current Version: 1.0.0.18

## Installation and configuration

### Creation

The **Arris D5** is an **SNMP** connector. The **IP** has to be configured during creation of the **element**.

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*

**SNMP Settings**:

- **Port number**: the port of the connected device, default *161*
- **Get community string**: the community string in order to read from the device. The default value is public.
- **Set community string**: the community string in order to set to the device. The default value is private.

## Usage

### General Page

This page displays some general information such as:

- **System Name**
- **System Uptime**
- **System Description**

### Interface Overview Page

This page displays an Interface Overview table.

### QAM Interfaces Page

This page displays a **QAM Interfaces** table

### Physical Interfaces Page

This page displays a table with the **Physical Interfaces**.

### RF Ports Page

This page displays the table with the **RF Ports**

### UDP IP Streams Page

This page displays a table with the **UDP Streams**

### QAM Streams Page

This page displays a table of the **QAM Streams**. This page also contains a button to normalize the values of the table.

### Service Groups Page

The Service Groups Page contains a Service Groups table that provides the user with cumulated bit rates for the streams in each HFC-Segment. HFC-Segments are filled in using the UPC Nederland Subscriber Provisioner connector or changing the value manually.

### Video Stream Programs Page

This page displays some Video Stream tables:

- **Video Stream Programms In**
- **Video Stream Programms Out**

In this page there is a button to clear the entries not available in the tables. There is also a toggle button to automatically delete from the tables the entries that are no longer available.

### Elementary Streams Page

This page displays a table of the **Elementary Streams**.

### Active Program Mapping Page

This page displays a table of the **Active Mapping**.

### Active PIDs Mapping Page

This page displays a table of the **PIDs Mapping**.

### Video Control Page

This page displays some controllable parameters for the video such as:

- **Pass-Through Mode**
- **Timeout Interval**
- **NIT Transmission Interval**
- **SDT Transmission Interval**
- ...

### Jitter Buffering Page

This page displays some tables:

- **Jitter Buffering Table**
- **Jitter Status Table**

### Software/File Transfers Page

This page displays some controllable parameters for both software and file transfer:

- **Server**
- **Username**
- **Password**
- **File Path**
- **Transfer Status**
- **Protocol**
