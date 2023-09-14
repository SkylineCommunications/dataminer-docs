---
uid: Connector_help_ETL_Systems_24500
---

# ETL Systems 24500

The **ETL Systems 24500** is a 16-channel dual 10MHz source housed in a rack-mountable chassis that can be used for telecom and instrumentation (LNB, BUCs and frequency converters).

## About

This connector uses **SNMP** to enable the configuration of the **ETL Systems 24500**, including hot and cold standby, local control via push buttons and display, and remote control and monitoring via Ethernet port. Independent level control is available on each channel.

### Version Info

| **Range** | **Description** |
|------------------|-----------------|
| 1.0.0.x          | Initial version |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.3 (06/05/2015)            |

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *10.150.3.3*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *public*.

## Usage

The connector contains 3 pages.

### Status

This page displays two blocks of parameters:

- **Status**: Summary status, including the **Source Selected**, **Main**, **Standy**, **Amp 1** to **5**, **PSU 1** and **2**, **PSU Bus**, and **Temperature Status**.
- **Chassis Status**: Current status of the system.

### Configuration

This page displays one block of parameters and two page buttons that display 5 tables.

The **Source Control** section of this page displays the following parameters:

- **Source Select**: *Main* or *Standby* mode can be selected.
- **Operating Mode**: *Manual* or Auto mode can be selected.
- **Standby Mode**: *Cold* or *Hot* mode can be selected.

The **Config** page button displays the following four tables **Serial Connection Setting**, **Network Configuration**, **Dataport Configuration**, **Ethernet Configuration**.

The **Output Settings** page button displays:

- The **Output Settings Table**, which displays the currently selected output, the current enable state of the output and the power level of output.
- The **Source Trim** section, with the parameters **Main Oscillator Trim** and **Standby Oscillator Trim**.

### Web Interface

This page displays the web interface of the device.

Note that the client machine has to able to access the device, as otherwise it will not be possible to open the web interface.
