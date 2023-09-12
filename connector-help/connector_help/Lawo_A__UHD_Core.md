---
uid: Connector_help_Lawo_A__UHD_Core
---

# Lawo A\_\_UHD Core

The A\_\_UHD Core is an audio engine for Lawo mcý audio production consoles. It is a network-based, software-defined IP DSP engine with:

- 1024 Lawo-grade DSP channels on 1RU (512 channels in 96 kHz mode)
- IP network processor based on open standards (ST2110-30/-31, AES67, RAVENNA)
- Full redundancy: SPS stream redundancy (ST2022-7) and hardware redundancy via hot-spare redundancy unit
- Scalable DSP performance via flexible licensing system and possibility to share DSP resources among multiple consoles

This driver uses **smart-serial Ember+** communication to poll data from the Lawo A\_\_UHD Core.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.8.0.73               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination. (default: *9000*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this driver consists of the data pages detailed below.

### General

This page contains general parameters such as **Company**, **Product** and **Version**, as well as system status parameters such as Fans Revolutions, Temperatures and Voltages.

It also contains parameters related to Ember+:

- **Discovered Nodes:** The number of discovered nodes in the Ember+ tree
- **Node Discovery:** The progress of checking the discovered nodes in the Ember+ tree. This will display the path that is currently being checked during Ember+ tree discovery.
- The **Start Node Discovery** button will manually start a new Ember+ tree discovery.

### Network

This page contains a tree control that provides an overview of all available network interfaces. The **Interfaces Tables** subpage shows the tables that this tree control is based on.

### Streaming

This page contains two tree controls, one for TX streams and one for RX streams. On the **RX Streams** and **TX Streams** subpages you can find this information in table format.

### Synchronization/PTP

This page contains PTP clock status parameters, such as the Time Stamp, Clock ID, Clock Class and Clock Traceability.

The **PTP Ports** subpage contains a table with information about each available PTP port.

### Alarms

This page shows the active alarms.
