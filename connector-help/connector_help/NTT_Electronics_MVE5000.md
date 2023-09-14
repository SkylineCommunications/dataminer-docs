---
uid: Connector_help_NTT_Electronics_MVE5000
---

# NTT Electronics MVE5000

This connector is used to monitor and configure the **MVE5000** Encoder from **NTT Electronics**.

## About

This connector contains different pages with information and settings. More detailed information on these can be found in the **Usage** section of this document. The connector uses the **SNMP** protocol to communicate with the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |
| 1.0.1.x          | DCF integration | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | MVE5000 FirmVersion.04.30   |
| 1.0.1.x          | MVE5000 FirmVersion.04.30   |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains general information about the device, such as the **Firmware Version**, **Serial Number** and **System Up Time**.

### Status

This page displays information about the state of the device, including the **Device Icon**, **Temperature** and **Fan Status.**

### Output Status

This page displays the state of the outputs, e.g. the **Output Stream1 IP Rate**, **Stream 1 Packets Counter Media** and **Output Stream2 ARQ Receive**.

### Input

This page allows you to configure the input, e.g. the **Interface Audio/Video**, **Superimpose Text Display** and **Superimpose Upper Text**.

The **Advanced Input** page button provides access to additional settings.

### Encode

This page allows you to configure the encoder, e.g. the **Latency Mode**, **TS Rate** and **Audio 1 Format**.

A number of page buttons provide access to additional settings: **Advanced Video**, **Advanced Audio**, **Advanced PID**, **Advanced PMT**, **Advanced NIT** and **Advanced SDT**.

### Output

This page allows you to configure the output, e.g. the **IP TS Transmission Mode**, **IP Number of Transmit TS** and **DVB ASI Mode**.

### Stream1

This page allows you to configure the first stream, e.g. the **IP Version**, **Protocol** and **Port Number**.

Additional settings are available via the **Advanced Output2** page button.

### Stream2

This page allows you to configure the second stream, e.g. the **IP Version**, **Protocol** and **Port Number**.

Additional settings are available via the **Advanced Output1** page button.

### Network

This page allows you to view and configure the Gigabit Ethernet interface (**GbE Interface**) and the Fast Ethernet interface (**FE Interface**).

Additional settings are available via the **Net FE Advanced** and **Net GbE Advanced** page buttons.

### Network Services

This page allows you to view and configure the SAP, pass through, syslog and SNMP trap information.

The following page buttons are available: **SAP**, **Pass Through** and **Redundancy**.

### Administration

This page displays general information about the device and allows you to configure the **Time Zone**, **Date and Time**, **NTP Server Address**, etc.

At the bottom of the page, two buttons are available that allow you to **synchronize the clock** and **reset** the device.

### Preferences

This page allows you to view and configure the preset information.

The **Auto Apply** page button provides access to further preset settings.

### Web Interface

This page shows the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1**.**0.1.x** connector range of the **NTT Electronics MVE5000** protocol supports the usage of DCF and can only be used on a DMA with **8.5.7.2** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **SDI Input**: Physical SDI interface with type **in**.
- **SDI Analog Audio Input**: Physical SDI with Analog Audio interface with type **in**.
- **IP Output FE**: Physical IP FE interface with type **out**.
- **IP Output GbE**: Physical IP GbE interface with type **out**.

### Connections

#### Internal Connections

- Connections are made based on the condition of **Interface Audio/Video** on the **Input** page, and the condition of the **Transmission Stream 1, Transmission Stream 2, Transmit Interface Stream 1** and **Transmit Interface Stream 2** on the **Stream** page.
  The connection(s) start from the selected input interface and go to the **IP Output FE** and/or **IP Output GbE**. If the selected input is not an SDI interface, the DCF connections will not be made, since these interfaces are not supported for DCF in this connector.
- Example 1: Input **SDI** is selected for the **Interface Audio/Video, Transmission Stream 1** is **Enabled**, **Transmission Stream 2** is **Enabled, PPPoE \#1 (GbE)** is selected for **Transmit Interface Stream 1** and **FE** is selected for **Transmit Interface Stream 2**.
  Two connections will be made from the **SDI** **Input** interface to the **IP Output FE** and **IP Output GbE** interfaces.
- Example 2: Input **SDI Analog Audio** is selected, both transport streams are enabled and have the same transmit interface selected (**GbE**).
  One connection is made from the **SDI Analog Audio Input** interface to the **IP Output GbE** interface.
