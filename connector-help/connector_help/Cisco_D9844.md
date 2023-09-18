---
uid: Connector_help_Cisco_D9844
---

# Cisco D9844

The **Cisco D9844** is designed to receive broadcasts using **MPEG-2 4:2:0 digital compression**.

## About

The **Cisco D9844** connector polls values in order to display information about the device, and allows you to configure certain parameters.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.9.5.9                     |

## Installation and configuration

### Creation

SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default: *public*.
- **Set community string**: The community string used when setting values on the device, by default: *private*.

## Usage

### General

This page displays general parameters, such as **Up Time**, **Software Revision**, **Serial Number**, etc.

### Overview

This page displays a tree view representing the stream with the services and their PIDs.

### Interface

On this page, you can find the **Interface Table**.

### Satellite

This page contains a number of tables related to the satellite.

The following three tables are displayed: the **Satellite** **Status Table**, the **Satellite** **Config Table**, and the **Stream** **Satellite** **Delivery System Table**.

### Video

This page contains a number of tables related to Video:

- **Video Mpeg Header Table**
- **Video Config** **Table**
- **Osd Config** **Table**
- **Osd Text Insertion Config Table**

### Audio

This page contains two tables: the **Audio** **Mpeg** **Header** **Table** and the **Audio** **config** **Table**, where you can configure some audio parameters.

### Network

This page contains two tables: the **Ip** **Table** and the **Stream** **Network** **Name** **Table**.

### Service

This page contains two tables: the **Service** **Config** **Port Table**, and the **Stream Service Table**.

Here you can configure some parameters related to the **Service** **Ports**.

### Mpeg - PSI - Pat - Cat

This page contains three tables related to **Mpeg2**. However, it's not possible to configure any parameters on this page.

### Mpeg - PSI - Pmt

This page contains two tables related to **Mpeg2**. However, it's not possible to configure any parameters on this page.

### Stream ISO - Vbi

This page contains the following three tables:

- **Stream Iso639 Language Table**
- **Stream Vbi Data** **Table**
- **Vbi Config** **Table**

### Stream Tele - Sub - Ac3

This page contains the following three tables:

- **Stream Teletext Table**
- **Stream Subtitling Table**
- **Stream Ac3 Table**

### Web Interface

This page provides access to the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
