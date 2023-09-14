---
uid: Connector_help_Astro_U261
---

# Astro U261

With this connector, it is possible to gather and view information from the Astro U261 and to configure this device.

## About

This connector uses HTTP to monitor the Astro U261. The connector also has an SNMP interface to receive traps from the device.

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

The connector is implemented to support direct **HTTP** communication with the Astro **U261** device, but it also supports proxy communication if necessary.

In either case, the **SNMP** interface collects the traps sent by the device, so the SNMP IP address must be the IP address of the device.

#### HTTP Connection for Direct Communication

- **IP address/host**: The IP address of the U261.
- **IP port**: The port of the destination e.g. *80*.
- **Bus address**: This field can be used to bypass the proxy. To do so, fill in the value *ByPassProxy*.

#### SNMP Connection

- **IP Address/host**: The polling IP of the U261, e.g. *10.11.12.13*.
- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

### Configuration

When a new element is created, no further configuration is necessary to poll information from the device without authentication.

However, to perform sets on the devices, you must configure the **Username** and **Password** credentials on the **Login** page of the element. The default credentials are Username: **admin** and Password: **astro**.

## Usage

### General

This page displays general information about the device.

The credentials required to perform sets on the device can be filled in via the **Login** page button (see Configuration section above).

The **Licensing** settings are available at the bottom of the first column. This section contains information on the licensed equipment and features.

With the **input mask**, you can insert and activate the acquired license keys by selecting the option **Submit**.

Several buttons are also available that allow you to save the current settings, load default settings or reboot the system to the operating parameters saved in the flash memory.

### Status

This page displays the status of the device, including the **Memory** and **CPU Load**.

### Main

On this page, you can access the main configuration of the device. This configuration consists of **IP Management Settings** (e.g. **DNS**, **Time Source**, **Management Channels configurations**, ...) and **IP Data Settings** (**Data Channels Configurations** and **Status**).

### TestGen

On this page, the test generator settings can be configured (e.g. **Data Rate** and **Packet Id**).

### IP RX Status

On this page, you can find information on the current configuration and statistics for the 16 receivers (e.g. **Selected Port**, **Service Info**, **Data Rate**, ...).

### IP RX Settings

On this page, you can configure communication settings of the 16 receivers (e.g. **Source IP/Port**, **Encapsulation**, **Priority**, ...).

### IP TX1 Settings

On this page, you can configure the output IP transmitter settings (E.g. **Destination IP/Port**, **TOS**, **TTL**, **FEC** configs, ...).

### Input MUX

On this page, you can route the input IP receiver signal, ASI TP input or input test signal to the output IP transmitter channel. The page also allows you to perform settings on the ASI TP Input.

### DVB ASI Outputs Settings

On this page, the ASI outputs can be configured (e.g. **State**, **Packet Length**, ...).

### Output MUX

This page displays a matrix which can be used to establish connections between the system inputs (IP receivers, ASI TP and test signal) and the DVB ASI outputs of the system. The same input can be connected to multiple outputs.

### Update/Config

On this page, you can perform a software update. The Astro MIB files, the log file and the device status/configuration files can also be downloaded on this page.

### System Log

This page contains a table listing all the log entries. To access the log settings, click the **System Log Config** page button.

### Active Alarms

This page displays a table with the current alarms on the device.

### Network

This page displays network parameters. Note that these parameters are retrieved via SNMP. Polling for these parameters can be enabled or disabled using the **Network Data Polling** toggle button.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

DCF is supported in the connector range 1.0.0.x, from the initial version onwards. The connector can only be used on a DMA with **9.0.0 \[CU6\]** as the minimum version.

### Interfaces

#### Fixed Interfaces

- **ASI TP Input** (type: in).

#### Dynamic Interfaces

The Ethernet data ports are full duplex, which means that they work as inputs in reception mode and outputs in transmission mode.

- **Ethernet Data Inputs (Data A and Data B)** (type: in).
- **IP TX1 Ethernet Data Outputs (Data A and Data B)** (type: out).
- **DVB ASI Outputs (ASI 1 .. 16)** (type: out).

### Connections

#### Internal Connections

**Internal Connections** between the system inputs (**Ethernet Data Inputs** and **ASI TP**) and the system outputs (**IP TX Ethernet Data Outputs** and **DVB ASI Outputs**) are mapped and characterized by the following connection properties: **Input Receiver**, **TS-ID**, **ONID**, **Alias**, **Reception IP:Port**, **Source IP** and **Destination IP:Port**.
