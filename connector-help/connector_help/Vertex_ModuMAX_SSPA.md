---
uid: Connector_help_Vertex_ModuMAX_SSPA
---

# Vertex ModuMAX SSPA

The Vertex ModuMax product connector was designed to monitor and manage the ModuMAX SSPA solid-state power amplifier, which is commonly used for uplink applications in satellite communications systems.

The connector uses SNMP communication to retrieve information related to the amplifier's hardware options, module information, current states, faults and event logs. It can also configure the amplifier's forward and reflected power and gain.

## About

### Version Info

| **Range**            | **Key Features**                                                             | **Based on** | **System Impact** |
|----------------------|------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Generates/updates a DataMiner service with the received channel information. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 106 02.31              |

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
- **IP port**: The IP port of the destination. (default: *161*)

SNMP Settings:

- **Get community string:** *public*
- **Set community string:** *private*

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element has the following data pages:

- **General**: Displays the general information (product type, network and firmware version, etc.) and hardware options (presence of parallel I/O, antenna/dummy load, redundant power supply).
- **Status**: Displays the current unit and RF state.
- **Modules**: Displays information related to the modules (temperature, voltage, current, version, operation state, etc.)
- **Power**: Displays the forward and reflected power, as well as their limits for alarming. Also allows you to set the power units and power limits.
- **Parallel I/O**: Displays the current state of the parallel I/O and its assigned functions.
- **Faults**: Displays the current amplifier faults.
- **Settings**: Allows you to configure the amplifier (gain, position, mute, SMFC).
