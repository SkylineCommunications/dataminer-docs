---
uid: Connector_help_Evertz_Scorpion_6
---

# Evertz Scorpion 6

This protocol is used to monitor the Evertz Scorpion 6 device.

The SCORPION-6 Media Processing Platform is a standalone, compact form factor, multi-service signal conversion, aggregation gateway capable of simultaneously transporting video, audio and data services over Ethernet and fiber networks. Using SCORPION Mini I/O modules, the SCORPION-6 can accommodate a multitude of signals including 4K SDI, Ethernet, MADI, AES, HDMI, intercom and serial data. The SCORPION-6 features encapsulation and de-encapsulation to IP over dual 10 GbE or 25 GbE trunk ports. When deployed as a flexible IP edge device, the SCORPION-6 becomes part of an integrated, scalable transport network, enabling the sharing of content from different sites using different transport media. The SCORPION-6 possesses a small fanless form factor and is designed to be operated in portable and/or low-noise environments. SCORPION-6 is ideal for mobile and live sports production applications.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

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

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### SNMP Redundant2 Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

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

The element created with this connector has several data pages:

- The **General** page displays the uptime, ID, name, and location of the system.
- The **System** page displays information about the different system configuration options.
- On the **Network Management**, **Time Management**, **SFP** and **Trunk Port** pages, you can find numerous tables with information related to these topics.
- On the **IP Input** and **IP** **Output** pages, you can find several tables with information about the Audio, Video, and Ancillary channels.
- On the **Module**, **Top Level Crosspoint**, **Frame Status** and **Test Analysis** pages, you can find various tables with information and settings related to these subjects.
- The **Traps** and **Notify** pages display tables where you can read/change the state and value of traps.
