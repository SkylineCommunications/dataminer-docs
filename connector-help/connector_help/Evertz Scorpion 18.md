---
uid: Connector_help_Evertz_Scorpion_18
---

# Evertz Scorpion 18

This protocol is used to monitor the Evertz Scorpion 18 device.

The SCORPION-X18 Media Processing Platform is a high-density signal conversion, video processing, routing, aggregation, and transport platform capable of simultaneously transporting video, audio and data over traditional dark fiber and/or managed IP networks. Using SCORPION Mini I/O modules, the SCORPION-X18 is highly flexible and can accommodate 12G/6G/3G/HD/SD-SDI, DVB-ASI, 10/100/1000 MbE, 10 GbE, analog/AES/MADI audio, HDMI, intercom, serial data, and Telco interfaces. An on-board 12G crosspoint allows uncompressed routing internal to the chassis.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

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
- **IP port**: The IP port of the destination

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### SNMP Redundant2 Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver has several data pages:

- The **General** page displays the uptime, ID, name, and location of the system.
- The **System** page displays information about the different system configuration options.
- On the **Network Management**, **Time Management**, and **SFP** pages, you can find numerous tables with information related to these topics.
- On the **Module, Frame Status, Diagnostic** and **Network Diagnostic**pages, you can find various tables with information and settings related to these subjects.
- The **Traps** and **Notify** pages display tables where you can read/change the state and value of traps.
