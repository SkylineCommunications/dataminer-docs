---
uid: Connector_help_Inverto_IDLV-5x00
---

# Inverto IDLV-5x00

This connector is used to manage and monitor the Inverto IDLV-5x00.

## About

With this connector, you can manage and monitor the professional multi-format HDTV integrated receiver decoder Inverto IDLV-5x00 via **SNMP** polling.

SNMP traps can be retrieved when this is enabled on the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 51PR0022                    |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device. (Default: *public*)
- **Set community string**: The community string used when setting values on the device. (Default: *private*)

## Usage

### General

This page contains module-specific **hardware** information.

### Status

This page displays status information for the **DVB-S2 Tuner** and **ASI1**/**ASI2** inputs.

### Tuner

This page contains **DVB-S2** configuration parameters.

### CI

On this page, the **CI Source** can be selected from the available input list. It is also possible to set the corresponding **CI** **Programs** list on each **CI slot**.

### Decoder

This page contains page buttons that open the following subpages:

- **Decoder Play**: Allows you to select the **input source** and set the decoder. You can also enable/disable the **Video** and **Audio** alarming system.
- **Audio**: Decoder audio configuration page.
- **Video**: Decoder video configuration page.

### Output

On this page, you can select the **input source** for **ASI1** and **ASI2** **Output** interfaces.

### BISS

On this page, you can select the **input source** from the available input list. The page also displays the corresponding **BISS** **Programs** list.

### Mux

This page can be used for the **Mux** configuration. It also contains the **Mux Programs** list, where programs can be added to the multiplexer.

### TS over IP

This page can be used for the **TS over IP** configuration, including the **input source** selection from the available input list, and stream configuration parameters.

The page contains page buttons that open the following subpages:

- **DVB**: Allows you to configure **Uni/Multicast** parameters, i.e. the **IP address**, **UDP Port** and **MAC Address**.
- **IPTV**: Allows you to configure the **IPTV** channels, including the **Channel Status**, **IP address**, **UDP Port**, **Target MAC address**, **EIT** and **TDT/TOT**. You can also check the lists of **Programs** that are running on each **IPTV** channel. However, it is not possible to edit these lists (i.e. to add or remove programs).

### Backup

This page contains **Backup** configuration parameters.

### System

This page contains page buttons that open the following subpages:

- **Device**: Contains device configuration parameters, e.g. **Board Type**, **Mux** **Function**, **Backup** **Function**, **Reboot** Command, **Default** settings, etc.
- **Version**: Displays the software version.
- **Network**: Allows you to configure the network parameters, e.g. **Device** **IP**, **Subnet** **Mask**, etc.

### Traps

This page contains a table detailing the received traps.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
