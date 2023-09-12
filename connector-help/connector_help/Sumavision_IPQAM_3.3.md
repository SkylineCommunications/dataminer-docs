---
uid: Connector_help_Sumavision_IPQAM_3.3
---

# Sumavision IPQAM 3.3

Sumavision IPQAM 3.3 is a modulator for all-IP networking transmission and VOD (Video-On-Demand) systems. It can be placed directly in the headend of the system, the sub-headend, and any HUB node of an optical fiber trunk network in a residential quarter for the reception, routing, multiplexing, scrambling, modulation and up-conversion to a RF cable television band of GbE (Gigabit Ethernet) data of MPEG over IP.

This driver uses **SNMP** to poll data from the Sumavision IPQAM 3.3.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.0.12                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver consists of the data pages detailed below.

### General

This page contains general system information

### Summary

This page contains status information related to **Power Supplies, Temperature** and **Fans, Card** and **Device.**

### Batch Configuration QAM Channel

On this page, you can configure the QAM Start and End Card, QAM Start and End RF Port, and also QAM Start and End Channel, as well as other settings such as Start Value of Frequency, Modulation, Symbol Rate, Channel Mode and PCR Mode.

### Batch Configuration UDP Port

This page has two subpages, **Non Fix Map** and **Fix Map**, each containing parameters related to the UDP port.

### ERM

This page contains parameters such as Bandwidth Update Threshold, Routing Cost, RTSP Port, Keep Alive, ERM Status, etc.

### QAM Card

This page has three subpages:

- **Output**: Contains several tables related to output monitoring and configuration.
- **Port**: Contains several tables, including the Channel Add Table. This table adds the specified channel, unless this channel already exists. It only shows the channels that are available for creation or that have already been creation.
- **Channel**: Contains the PSI/SI Table and the Channel Modify Table, which allows you to configure channel-related parameters.

### Net

This page contains several tables related to net and UDP monitoring and configuration.

## Notes

It can take some time before changes to some settings are implemented, for instance those on the Batch Configuration QAM Channel, ERM, Non Fix Map and Fix Map pages. This is because these parameters require a specific setting mechanism that may sometimes take a while.
