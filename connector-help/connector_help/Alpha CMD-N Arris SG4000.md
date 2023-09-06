---
uid: Connector_help_Alpha_CMD-N_Arris_SG4000
---

# Alpha CMD-N Arris SG4000

The CMD-N transponder provides the ability to manage fiber nodes through an existing cable modem infrastructure. The transponder transmits data to a management system over the network's existing DOCSIS infrastructure, using standard SNMP (Simple Network Management Protocol). Status monitoring information is compatible with ANSI/SCTE HMS standards.

## About

This driver maps SNMP parameters from DOCSIS MIBs in order to collect measured analog signals and digital SCTE/HMS data from fiber nodes.

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**             |
|-----------|------------------------------------|
| 1.0.0.x   | DOCSIS 1.0, DOCSIS 1.1, DOCSIS 2.0 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main connection

This driver uses a Simple Network Management Protocol (SNMP) connection to connect to the transponder and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device. (Default: *161*.)
- **Get community string**: The community string used when reading values from the device. (Default: *public*.)
- **Set community string**: The community string used when setting values on the device. (Default: *private*.)

#### DDNS functionality

The driver is capable of polling from an IP resolved via a DDNS mechanism. To enable this, when the element is created/edited, you need to specify a string that will be parsed. The DNS will translate the enclosed MAC address into the polling IP to be used.
This following input must be specified during element creation/editing:

- **IP address**: 0.0.0.0
- **Device address**: \<DNS-Server-IP\>:\<Device-MAC-Address\>.alphamon

## How to Use

### General

This page contains general information about the system, such as the **number of lasers** installed in the system, the **number of optical amplifiers**, the **number of alarms** currently active in the system, the **software** and the **serial number** of the device.

### Physical Data

This page lists all the physical boards available in the SG4000 chassis.

### RF Ports

This page shows the **RF slots that are running** in the system. The page also displays the current (in mA) for each active RF.

### AB Switch

This page contains the main settings for each optical receiver in the switch, if there is one active.

### Power Units

This page displays all the **power units available/running** in the system, along with information on the **operating voltage**.

### Transponder

This page displays detailed information about the transponder, such as the **Vendor**, **Vendor info**, **Community String**, **Alarm Detection, Internal Temperature, Physical Address** and **Network Element Status**.

### Analog Transmitters

This page contains information on the return laser, such as the **current (in mA)**, **Laser Control** (allows you to set the laser on/off), **wavelength**, **optical power** and **type of the laser.**

### Digital Transmitters

This page contains two tables with information about the digital return transmitters or DRT:

- **DRT Data:** Contains information about the unit control, such as SFP part number, serial number, hardware version and wavelength.
- **DRT Status:** Contains information about the optical power, such as the 24V power supply current and voltage, the temperature and the alarm status.

### Optical Receivers

This page shows the **State**, the **Power**, the **Signal Strength** (conversion from mW to dBm), the **Current** and the index of the **RF Active** associated with the optical receiver.

### Cable Modem - Status

This page displays information about the state of the CM (operation mode, modulation type, TX power and some CM counters).

### Cable Modem - Channel

This page displays detailed status information for the **downstream** and **upstream** channel:

- **Downstream Channel table**: Interleave, channel power and channel annex.
- **Upstream Channel table**: Channel type, slot size and the TX timing offset.

### Event Log

This page shows the **Event Log table**, which contains a log of network and device events that may be of interest in fault isolation and troubleshooting.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
