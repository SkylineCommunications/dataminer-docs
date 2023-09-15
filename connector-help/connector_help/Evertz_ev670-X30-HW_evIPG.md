---
uid: Connector_help_Evertz_ev670-X30-HW_evIPG
---

# Evertz ev670-X30-HW evIPG

This protocol is used to monitor the Evertz ev670-X30-HW evIPG device.

The 670 is a virtualized media processing platform that enables users to move a broadcast services infrastructure to a generic hardware platform when required. It is an FPGA-accelerated compute blade that supports both 12G/3G/HD-SDI and IP interfaces. Its gateway capabilities for IP include encapsulation/de-encapsulation of SDI over 25 GbE, as well as protocol conversion including SMPTE ST 2022-6 and SMPTE ST 2110. It allows direct conversion of up to 16x input and 16x output SD/HD/3G signals to/from IP using SMPTE ST 2022-6 or ST 2110 formats, and also provides per-input AVM monitoring, time-stamped Ethernet outputs, and audio/video synchronization. It also features multi-path, multi-flow packet merging for bit error resilience in networks. The 670 can be managed via the integrated HTTP web interface, in-band via its 25 GbE interface, and using SNMP via frame controller.

## About

### Version Info

| **Range**            | **Key Features**                                                 | **Based on** | **System Impact**                                             |
|----------------------|------------------------------------------------------------------|--------------|---------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                                 | \-           | \-                                                            |
| 1.0.1.x \[Obsolete\] | Adds redundant polling.                                          | \-           | Adds interface for redundant polling.                         |
| 1.0.2.x \[SLC Main\] | Subtable functionality in all tables to filter out unneeded rows | 1.0.1.2      | Trending, Visio drawings and alarm templates may be affected. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |
| 1.0.1.x   | 2.9.2.r1.588           |
| 1.0.2.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |

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

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector has several data pages:

- The **General** page displays the uptime, ID, name and location of the system.
- The **System** page displays information about the Port Configuration and contains several subpages with information about the different system configuration options.
- On the **Route Control**, **SDI Input** and **SDI Output** pages, you can find numerous tables with information related to these topics.
- On the **IP Input** and **IP** **Output** pages, you can find several tables with information about the audio, video and ancillary channels.
- On the **Product Location, Hardware, Hardware LED, Software, Proxy Configuration** and **Time Management** pages, you can find various tables with information and settings related to these subjects.
- The **SNMP Traps, Video Notify, Audio Notify** and **Notify** pages display tables where you can add/remove traps destinations as well as read/change the state and value of traps.
