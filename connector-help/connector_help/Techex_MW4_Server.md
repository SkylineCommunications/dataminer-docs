---
uid: Connector_help_Techex_MW4_Server
---

# Techex MW4 Server

The **Techex MW4 Server** driver is an HTTP-based driver that is used to monitor and configure the **MW4 IPTV Management Platform**.

## About

This driver provides a monitoring and configuration interface for the **Techex MW4 Server**. It allows the user to perform basic operations on monitored devices and channels.

REST API calls are used to retrieve/send information from/to the server. The driver can optionally export each device as a DVE.

### Ranges of the driver

| **Driver Range**     | **Description** | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version | No                  | No                      |
| 1.0.1.x \[SLC_Main\] | DCF integration | Yes                 | No                      |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | 4.6.4                       |
| 1.0.1.x          | 5.0.1                       |

### Exported drivers

| **Exported Protocol**              | **Description**           |
|------------------------------------|---------------------------|
| Techex MW4 Server - Generic Device | Techex MW4 Server Device. |

## Installation and configuration

### Creation

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The server URL (e.g. *[https://middleware.techex.co.uk](https://middleware.techex.co.uk/))*

## Usage

### Login

On this page, you can enter the **Login Credentials** for the MW4 Server and monitor the **Login Status** (*Authorized*/*Not Authorized*).

### Devices

This page lists the retrieved devices. It allows you to **enable or disable** the DVE for each device.

Via a **context menu**, you can perform different operations on the retrieved devices: **Change Channel, Refresh, Reboot, Upgrade, Delete, TV On, TV Off, Power On** and **Power Off.**

### Channels

This page lists the retrieved channels. It allows you to **add new channels** and to **monitor or delete existing channels**.

### MWEdges

This page lists the retrieved **MWEdges,** **Streams** and **Outputs**, as well the relations between them.

It is also possible to add **SRT** and **UDP Outputs** via the **context menu** of the **Outputs** table. In addition, there is a subpage listing the **Output Resources** that can be linked to the referred **Outputs**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1.0.1.x** driver range of the Techex MW4 Server protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner Third Party protocols (for instance a manager).

Connectivity for all exported protocols is managed by this protocol.

### Interfaces

#### Dynamic Interfaces

Physical dynamic interfaces:

- Output: **parameter 8000**, **out**.

### Connections

There are no connections.
