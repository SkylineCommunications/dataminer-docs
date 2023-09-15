---
uid: Connector_help_Nevion_CP505
---

# Nevion CP505

The **Nevion CP505** ATSC processor offers flexible ASI, SMPTE 310 and IP network adaptation and advanced Transport Stream processing in a compact 1RU solution. The basic model provides format conversion between ASI, SMPTE-310 or Transport Stream on IP/GigE (electical 1000Base-T or SFP), STM-1/OC-3 or E3/T3-DS3. The advanced model offers the basic features plus PID and program filtering with ATSC PSIP and DVB SI processing capabilities.

## About

This connector uses an **HTTP** connection to get and set information on the device. The commands sent are based on its own communication protocol, the **TXP - T-VIPS XML Protocol**.

The layout of the connector mirrors the device's web interface as much as possible. For more information, refer to: <http://nevion.com/products/processingmultiplexing/cp505>.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.2.14                      |

## Installation and configuration

### Creation

#### HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination, by default *80.*
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

### Configuration

Once the connection has been configured, data will polled from the device.

To be able to set new values on the device, the **Username** and **Password** must be provided on the **General** page.

## Usage

### General

On this page, you can set the **Username** and **Password**.

### Status - Current Alarms

This page displays the **Current Alarms** on the device, along with information about the configured severity of each of the elements that are part of it. This information can be found under the page buttons **Config** and **More**.

### Product Info

This page displays general information concerning the device.

### Alarms

On this page, you can get more information about the **Alarms Global Configuration**, and also configure the **Relays LED** and the **Log Settings**.

### Time Settings

This page contains all information related to the device time.

### Network Interfaces

This page displays the interfaces available on the device and related settings and measurement data.

### Network

This page contains more information on the interface settings and also allows you to configure the settings. This concerns **DHCP**, **VLAN**, **DNS**, **SNMP**, **IP Routing** and **TXP Settings**. **Ping** and **Traceroute** tools are also available via **Tools**.

### Save/Load Config

This page shows information about the **Stored Configurations**.

### Maintenance

This page displays **Operational Modes** and **Features** of the device.

### Users

This page contains information about the type of users that can access the device and its control levels.

### Tree Control

This page displays information about the **Inputs** and **Outputs** in a tree control.

### Ports Input

This page contains information on the current available type of **Inputs** as well as information concerning input ports, **IP RX** and **Switch Input**.

### Ports Output

This page contains information on the current available type of **Outputs** as well as information concerning output ports, **TS OFDM**, **IP TX** and **Config**.

### Ports Map

This page displays the port mapping currently established on the device.

### Ports PIDs

This page contains information about the **PIDs**, both concerning input and output ports.

### Ports Sign PIDs

This page contains information about the **Sign PIDs**, both concerning input and output ports.

### Ports Services

This page displays the currently available **Services**, from both input and output ports.

### Ports Service Status

This page displays the **Status** of the services of both inputs and outputs.

### Ports PSISI

This page displays information relevant to the **PSI/PSIP/SI** generators and service providers.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
