---
uid: Connector_help_Liebert_UPStation_GXT2-700RT230
---

# Liebert UPStation GXT2-700RT230

The Liebert UPStation GXT2U is a compact, on-line UPS. It continuously conditions and regulates its output voltage, whether mains power is present or not. It supplies connected equipment with clean sinewave power.

## About

The Liebert UPStation GXT2-700RT230 connector uses SNMP to poll data from the device. The data will be displayed on different pages, each related to a different subject.

For some of the parameters, the value can be changed. The rate at which the data is polled can also be configured: *High* or *Slow*.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and needs following user information:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General page

This page shows several general parameters related to the device.

### Alarm

This page displays the **UPS** **Alarm** **Table**, where all the active alarms are displayed.

In addition, another table is displayed, in which the different alarm descriptions are shown, and for each it is indicated whether they are *OK* or in *Alarm* state.

### UPS Input

This page displays the **UPS** **Input** **Table**.

### UPS Output

This page displays the **UPS** **Output** **Table**.

### UPS Bypass

This page displays the **UPS** **Bypass** **Table**.

### UPS Control and Config

On this page, you can check and set parameters regarding the control and configuration of the device.

### Polling Configuration

On this page, you can set the polling speed to *Slow* or *High.* By default, it is set to *High*.

### Web Interface

On this page, the web interface of the device is displayed. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
