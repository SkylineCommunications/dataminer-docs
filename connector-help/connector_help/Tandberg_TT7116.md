---
uid: Connector_help_Tandberg_TT7116
---

# Tandberg TT7116

This is a multiport connector that uses both a **serial** and an **SNMP** connection. It show the status of the different parameters of a **Tandberg** **TT7116**.

## About

The Tandberg TT7116 is an **IPStreamer** device.

## Installation and Configuration

### Creation

This connector uses both a serial connection (HTTP) and an SNMP connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Port**: The port of the device, by default *80.*
- **Bus address**: Not needed.

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Port**: The port of the device, by default *161.*
- **Get Community**: The community string used when reading values from the device. The default value is *public.*
- **Set Community**: The community string used when setting values on the device. The default value is *private.*

### Configuration

To configure the user credentials for Telnet communication, go to the **General** page, and configure the username and password in the lower right corner.

## Usage

### Main View Page

This page contains general status information such as the **IP Address**, **Subnet Mask**, etc.

### General Page

This page contains general status information, such as the **IP Address**, the **Alarm Status**, the **Device Serial Number**, etc.

On the left-hand side, the **Trap Destination Table** is displayed, as well as the **Get Serial ID** button, which can be used to retrieve the Unique Serial ID of this device.

On the right-hand side, there is a **Reset** button, as well as several page buttons: **Port Table, Features Table, Board Table** and **Configurations**.

- The **Port Table** contains a list of port numbers and some more information about them, such as **Port Type, Port Direction**, etc.
- The **Features Table** contains a list of features and some more information about them, such as the **PAT**, the **Featuring Mode**, etc.
- The **Board Table** contains more information about the boards installed in the system.
- The **Configurations** subpage allows you to back up or restore a configuration.

In the lower right corner, you can configure the username and password necessary for **Telnet** communication, and also start a **Full Reset**.

### Inputs Page

On this page, the **Inputs** table is displayed, which shows information about the Inputs in the system, such as the **ASI Input Name**, **Input Status**, **Effective Bitrate**, etc.

With the **Clear Inputs** button, you can clear the table.

There are also two page buttons:

- **Services**: Shows a table with more information about the services, such as the **Input Of Service,** **Stream Id**, **PCR**, etc. Individual services can be deleted from this page.
- **PIDs**: Shows a page with information about the various PIDs in the system, such as the **PID Index**, **PID rate**, etc. Individual **PIDs** can be deleted from this page.

### Streams Page

This page displays the **Streams** table, which contains information about the different streams in the system. It shows amongst others the **Stream Id**, the **Output DVB Transport Stream**, and the **Bitrate.**

### Outputs Page

This page displays the **Outputs** table, which shows information about the Outputs in the system, such as **Output Status**, **Output IP Address**, **Ethernet Line Speed**, etc.

With the **Clear Outputs** button, you can clear the table.

The **Output Streams** page button opens a table with information about the **Destination IP, Threshold, Output Stream Status**, etc.

### Trap Page

This page displays the **Trap Table**, which contains parameters such as **Trap Index, Input Lock Status, Video Status,** etc.

### Web Interface

This page links to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to display the web interface.
