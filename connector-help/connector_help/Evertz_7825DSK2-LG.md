---
uid: Connector_help_Evertz_7825DSK2-LG
---

# Evertz 7825DSK2-LG

With this connector, it is possible to monitor and configure the Evertz 7825DSK2 Logo Inserter

## About

The Evertz 7825DSK2-LG connector retrieves basic information about the system.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device. (default: public)
- **Set community string**: The community string used when setting values on the device. (default: private)

## Usage

### General

This page displays general system information.

### Configuration

This page contains various debug toggle buttons as well as the **Router Status**, and the **MCPIP Address Setup** table. It also contains several page buttons and a **Reboot** button:

- **Transition...** Contains various transition-related configurable parameters.
- **DSK...** Contains various DSK/Keyer related configurable parameters for key 1 and key 2.
- **Matte...** Contains various Matte configurable parameters.
- **Presets...** Contains various parameters that allow you to set the Recall, Store, and Export presets.
- **Temperature...** contains various Temperature-related parameters. The range of the temperature will vary based on the temperature format.
- **Network...** Contains network information, such as the IP, Subnet Mask, and MAC address.

### Video

This page displays different parameters that have information related to the **Video**, such as: the **Video Standard**, **Reference Type**, and **Offsets**. The range of the **Offset** is dependent on the current **Video Standard**. The page also contains the **Mandatory Video Inputs** table.

### Audio

This page contains two Audio retrieved tables, **Background Audio Info** and **Audio Voiceover Info**. They are expanded and readable versions of their (not visible) SNMP counterparts, and sets will be performed to their SNMP tables. **Note**: The **R**outer** Status** will affect the sources of these channels, and changing it will cause the table to regenerate.

### Time

This page displays various Time-related parameters including the **Local**, **Real**, and **UTC** times present on the device. It also includes the **Time Configuration** table.

### GPI/GPO

This page contains the **GPI/GPO info** tables. The **GPO Info** table is a basic SNMP table allowing the confugration of the 4 GPOs' states, and the **GPI table** is a retrieved table that is an expanded/readable version of its (not-visible) SNMP table.

### Media

This page contains various configurable parameters related to the device's media, such as **Program Control**, **Preview Channel**, and **Voiceover Control** parameters.

### Faults

This page displays a table of the faults. Note: only those found in the VistaLink will be shown in the table.

### Web Interface

The web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.


