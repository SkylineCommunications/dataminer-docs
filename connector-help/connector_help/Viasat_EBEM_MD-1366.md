---
uid: Connector_help_Viasat_EBEM_MD-1366
---

# Viasat EBEM MD-1366

The **Viasat EBEM MD-1366** connector is used to monitor and control a **local modem and distant modem** at remote locations (for example on the shore and on a ship).

## About

In the initial version **1.0.0.1**, the connector can be used to monitor and control (to a limited extent) the functionality of the modem.

Version **1.1.0.1** introduces a major update, supporting both **local and distant** monitoring, as well as **active (local) editing and control**. The connector allows the monitoring of **modem status** information, monitoring and control of **active (local) parameters** - with a limited number of configurable parameters (without dependencies on other parameter values), monitoring of **distant parameters**, and editing of parameters related to the local and Flash configuration. It also handles **event traps** for alarms, faults, configuration changes, power transmission changes and AUPC power transmission changes.

### Version Info

| **Range** | **Description**                                                                                                                    | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial range                                                                                                                      | No                  | No                      |
| 1.1.0.x          | Capability to monitor both a local and distant modem with a single connector, as well set the active (local) and flash configuration. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | NA                          |
| 1.1.0.x          | 02.01.05                    |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (**SNMPv1**) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string needed to read from the device. The default value is *PUBLIC*.
- **Set community string**: The community string needed to set to the device. The default value is *PUBLIC.*

## Usage

The connector contains different pages divided into several sections.

### General

This section contains the following pages:

- **General**: General parameters of the active (local) and distant device, with the main status of the active device. Also contains the Tx IF to RF Offset configuration parameter.
- **General Status**: Specific status parameters of the active device.
- **Distant General Status**: Specific status parameters of the distant device.

### Config

This section contains the following pages:

- **Config**: Allows you to set a number of modulator and demodulator configuration parameters of the active (local) device, as well as monitor its transmit and receive operation, Tx and Rx embedded channel, Tx and Rx IF carrier frequency, Tx and Rx RF carrier frequency, Tx IF carrier power and Rx equalizer operation.
- **ITA**: Displays the active Tx and Rx ITA properties and waveform mask.
- **System**: Displays active system properties.
- **Interfaces**: Displays active port properties, including serial port, TCP/IP and SNMP agent parameters.
- **Test**: Displays active bit error rate test properties.
- **Alarm**: Displays active alarm severity properties.
- **AUPC**: Displays active AUPC properties.
- **Expansion**: Displays active expansion module properties.

### Distant Config

This section contains the following pages:

- **Distant Config**: Allows you to set a number of modulator and demodulator configuration parameters of the distant device, as well as monitor its transmit and receive operation, Tx and Rx embedded channel, Tx and Rx IF carrier frequency, Tx and Rx RF carrier frequency, Tx IF carrier power and Rx equalizer operation.
- **ITA (Distant)**: Displays the distant Tx and Rx ITA properties and waveform mask.
- **System (Distant)**: Displays distant system properties.
- **Interfaces (Distant)**: Displays distant port properties, including serial port, TCP/IP and SNMP agent parameters.
- **Test (Distant)**: Displays distant bit error rate test properties.
- **Alarm (Distant)**: Displays distant alarm severity properties.
- **AUPC (Distant)**: Displays distant AUPC properties.
- **Expansion (Distant)**: Displays distant expansion module properties.

### Edit Config

This section contains the following pages:

- **Edit Config**: Allows you to select, edit and apply an active or Flash config to the device. Configurations can be loaded from or saved to 20 Flash config IDs. The page also allows you to monitor and set the transmit and receive operation, Tx & Rx embedded channel, Tx & Rx IF carrier frequency, Tx & Rx RF carrier frequency, Tx IF carrier power and Rx equalizer operation.
- **Mod/Demod Config (Edit)**: Allows you to edit the modem transmitter and receiver properties.
- **ITA (Edit)**: Allows you to edit the distant Tx and Rx ITA properties and waveform mask.
- **System (Edit)**: Allows you to edit the distant system properties.
- **Interfaces (Edit)**: Allows you to edit distant port properties, including serial port, TCP/IP and SNMP agent parameters.
- **Test (Edit)**: Allows you to edit distant bit error rate test properties.
- **AUPC (Edit)**: Allows you to edit distant AUPC properties.
- **Expansion (Edit)**: Allows you to edit distant expansion module properties.
- **Failure Events**: Displays the failed event sets with the message.

### Alarms

This page displays a table listing all the alarms of the EBEM. It also allows you to acknowledge all the alarms and to mute alarms. The number of alarms can also be set here.

### Events

This page contains two tables:

- **Config Change Event Table**: All the configurational changes that are made towards the EBEM both from DataMiner and from the EBEM GUI are listed in this table. A parameter above the table allows you to set the maximum number of entries in the table.
- **Transmit Power Adjust Change Events Table**: All the power adjustment changes both from DataMiner or from the EBEM GUI are listed in this table. A parameter above the table allows you to set the maximum number of entries in the table.

### Faults

This page displays a table listing all the faults of the EBEM. It also allows you to clear all the faults and set the number of faults.
