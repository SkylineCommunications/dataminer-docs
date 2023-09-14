---
uid: Connector_help_Evertz_160RM
---

# Evertz 160RM

The **Evertz 160RM** device can interface with a consumer STB using standard connectors and an IR interface to replicate the "remote" control of the STB.

## About

This connector communicates with the Evertz 160RM using **SNMP** commands.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

On this page, you can set up the encoder's parameters as well as read its status.

### Input Settings

On this page, you can configure the **Input Type** and the **Refresh Rate**.

### AVM Control

This page contains the controls that can be used to define fault conditions.

### STB Control

This page contains all IR controls. To configure these, first set the **STB Type**.

### Cycling Control

On this page, you can use the **Monitoring** parameters to configure the internal monitoring state of the input. With **Start/Reset Web CCA** you can start/stop the CCA monitor cycling and the **Trap Tag** can be set to a given input.

**Audio** and **Video Management Fault Tables** provide information about Audio and Video faults. If you set **Audio/Video Fault Send Trap** to *True,* a trap will be sent when there is a fault.

### Advanced Controls

On this page, you can set the **Frame Rate** and **Scaling**.

### SNMP Controls

On this page, you can set the **Read/Write Community Strings** and **Trap Destinations**. The **Traps** table shows all the traps that have been sent. The **Auto Clear** page button can be used to define how long an entry will be kept in the table.

### Web Interface

This page provides access to the device's configuration web page. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
