---
uid: Connector_help_Astro_U262
---

# Astro U262

With this connector it is possible to gather and view information from the Astro U262 as well as to configure this device.

## About

This connector uses HTTP to monitor the Astro U262. The connector also has an SNMP interface to receive traps from the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4881                        |

## Installation and configuration

### Creation

This connector uses two interfaces: an HTTP interface to retrieve the data and an SNMP interface to collect the traps.

The connector is implemented to support direct HTTP communication with the Astro U262 device, but it also has support for proxy communication in case this should be necessary.

In either case, the SNMP interface collects the traps emitted by the device, so the SNMP IP address must be the IP address of the device.

#### HTTP Connection for Direct Communication

- **IP address/host**: The IP address of the U262.
- **IP port**: The port of the destination e.g. *80*.
- **Bus address**: This field can be used to bypass the proxy. To do so, fill in the value *ByPassProxy*.

#### SNMP Connection

- **IP Address/host**: The polling IP of the U262, e.g. *10.11.12.13*.
- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

### Configuration

When a new element is created, if the communication settings are in order, information can be polled from the device without authentication. However, to perform sets on the device, the **Username** and **Password** credentials must be configured on the **Login** page. The default credentials are:

- Username: *admin*
- Password: *astro*

## Usage

### General

This page displays general information about the device.

The credentials of the device can be filled in via the **Login** page button.

The **Licensing** settings, including information on the already licensed equipment and features, are available at the bottom of the first column. In the input mask, you can insert the acquired license keys and activate them by selecting the option **Submit**.

To the right of the Licensing section, several buttons are available, which allow you to save the current settings, load default settings or reboot the system to the operating parameters saved in the flash memory.

### Status

This page displays the status of the device, including the **Memory** and **CPU Load**.

### Main

On this page, you can access the main configuration of the device. This includes the **IP Management Settings** (e.g. **DNS**, **Time Source**, **Management Channels configurations**, etc.) and **IP Data Settings** (**Data Channels configurations** and **status**).

### TestGen

On this page, the test generator settings can be configured (e.g. **Data Rate** and **Packet ID**).

### IP Rx1 Status

On this page, you can find information on the current configuration as well as statistics for the IP receiver input (e.g. **Selected Port**, **Service Info**, **Data Rate**, etc.).

### IP Rx1 Settings

On this page, you can configure the IP receiver input settings (e.g. **Source IP/Port**, **Encapsulation**, **Priority**, **Reception IP/Port**, etc.).

### DVB ASI Settings

On this page, the ASI inputs can be configured (e.g. **State**, **Inversion**, **Alias**, etc.).

### Input MUX

On this page, you can route one of the ASI input signals, the IP Rx input or the input test signal to one of the output IP transmitters.

### IP Tx Eth Settings

On this page, you can configure the settings of the available IP output Ethernet channels (e.g. **Destination IP/Port**, **TOS**, **TTL**, **FEC** configs, etc.). Each IP transmitter can be enabled to transmit to one or both the Ethernet data channels.

### IP Tx Settings

On this page, you can configure the settings of the 16 IP transmitters (e.g. **Packets**, **Frame Encapsulation**, **FEC** configs, etc.).

### Output MUX

On this page, you can route one of the ASI input signals, the IP Rx input or the input test signal to the ASI TP output.

### Software Update

On this page, you can perform a software update.

### System Log

This page contains a table listing all the log entries. To access the log settings, click the **System Log Config** page button.

### Active Alarms

This page displays a table with the current alarms on the device.

### Download Files

On this page, you can download the Astro MIB files, the log file and the device status/configuration files.

### Network

This page displays network parameters.

Note that these parameters are retrieved via SNMP. The polling can be enabled/disabled using the **Network Data Polling** toggle button.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

DCF is supported in the connector range 1.0.0.x, from the initial version onwards, and can only be used on a DMA with 9.0.0 \[CU6\] as the minimum version.

### Interfaces

#### Dynamic Interfaces

The Ethernet data ports are full duplex, which means that they work as inputs in reception mode and outputs in transmission mode.

- **Ethernet Data Outputs (Data A & Data B)** (type: out).
- **ASI TP Output** (type: out).
- **IP Rx1 Ethernet Data Input (Data A & Data B)** (type: in).
- **DVB ASI Inputs (ASI 1 to 16)** (type: in).

### Connections

#### Internal Connections

**Internal Connections** between the system inputs (**IP Rx1 Eth Input (A & B)** and **DVB ASI Inputs**) and the system outputs (**IP Eth Data Outputs A & B (eth2 & 3)** and **ASI TP Output**) are mapped and characterized by the following connection properties:

- **Input Receiver**, **TS-ID**, **ONID**, **Alias**, **Reception IP:Port**, **Source IP** and **Destination IP:Port**.
