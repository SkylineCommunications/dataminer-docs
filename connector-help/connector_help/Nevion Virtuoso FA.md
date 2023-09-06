---
uid: Connector_help_Nevion_Virtuoso_FA
---

# Nevion Virtuoso FA

This is a DataMiner connector for the Nevion Virtuoso FA, a media server designed for broadcast carrier-class applications. The connector uses an HTTP connection to allow monitoring of the Nevion Virtuoso FA.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.10.8                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (fixed value: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

To make sure the connector can retrieve data, fill in the **Login Credentials** of the device on the **Settings** page.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product. It's also important to note that the web interface currently requires flash player support which may cause issues.

## How to use

The element using this connector consists of the data pages detailed below.

### General

This page displays basic information about the device, e.g. **Device Name**, **Software Version**.

The page also contains page buttons to the following subpages:

- **Frames**: Lists the cards and ports.
- **Slots**: Lists the slots on the device.
- **Licenses**: Contains all daylight-saving time settings.

### IP Interfaces

This page displays information about the IP Interfaces, e.g. **State**, **IPv4 Address**.

### Ethernet

### This page displays information about the Ethernet, e.g. State, Rx Bitrate and Load.

The page also contains page buttons to the following subpages:

- **Sync Input**: Lists the sync input for the ethernet ports.
- **Status**: Lists the status, received status, trasmit status, and errors for the ethernet ports.
- **Routing**: Lists receiver and trasmitter routing for the ethernet ports.

### ASI Input

This page displays information about the ASI Inputs on each of the ethernet ports, e.g. **Packet Length,** **Destination Formats**.

### ASI Output

This page displays information about the ASI Outputs on each of the ethernet ports, e.g. **Ts Mode,** **Stream Mode**.

### IP Input

### This page displays information about the Ip Inputs, e.g. Flow A & B Source Interface, Expected Lagging Flow.

The page also contains page buttons to the following subpages:

- **Flow A**: Lists the Rx Status for the Flow A values.
- **Flow B**: Lists the Rx Status for the Flow B values.
- **FEC**: Lists fecs for the ethernet ports.
- **Buffer Regulator**: Lists the buffer regulators for the ethernet ports.

### TS Input Switch

This page displays information about the TS Input Switches, e.g. **Switch and Return Delay,** **Selected Input GID**.

### Transport Streams

### This page displays information about the Transport Streams, e.g. Source Interface, Multicast Address.

### Services

This page displays information about the services, e.g. **Service Provider,** **Service Type**.

### Alarms

This page displays information about the alarms, e.g. **Desriptions,** **Severity**.
